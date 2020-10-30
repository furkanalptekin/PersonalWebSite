$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("CV");
    helper.createTabStrip("tabstrip");

    $("#File").kendoUpload({
        validation: {
            allowedExtensions: [".pdf"]
        },
        multiple: false,
        localization: {
            select: "Dosya Seçiniz",
            invalidFileExtension: "Geçersiz Dosya Uzantısı!"
        }
    });

    var columns = [
        { field: "Id", title: "Id" },
        { field: "CvAdi", title: "Cv Adı" },
        { field: "EklemeTarihi", title: "Ekleme Tarihi" },
        {
            title: "İşlemler",
            command: [
                {
                    name: "goster",
                    text: "",
                    iconClass: "k-icon k-i-select-all m-0",
                    click: function (e) {
                        e.preventDefault();
                        var data = this.dataItem($(e.target).closest("tr"));
                        OpenPDF(data.Id);
                    }
                },
                helper.fieldDelete()
            ]
        }
    ]

    helper.createGrid("CV", columns);
});

function AddData(data) {
    var grid = $('#CV').data("kendoGrid");
    var temp = {
        Id: data.Id,
        CvAdi: data.CvAdi,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString()
    };
    grid.dataSource.add(temp);
}

function OpenPDF(id) {
    $.ajax({
        url: '/CV/Show/',
        type: "POST",
        dataType: "JSON",
        data: { id: id },
        success: function (response) {
            if (response.success) {
                var objbuilder = '';
                objbuilder += ('<object width="100%" height="100%"      data="data:application/pdf;base64,');
                objbuilder += (response.b64);
                objbuilder += ('" type="application/pdf" class="internal">');
                objbuilder += ('<embed src="data:application/pdf;base64,');
                objbuilder += (response.b64);
                objbuilder += ('" type="application/pdf" />');
                objbuilder += ('</object>');

                var win = window.open("", "_blank", "titlebar=yes, left=50, top=50");
                win.document.title = response.cvName;
                win.document.write('<html><body>');
                win.document.write(objbuilder);
                win.document.write('</body></html>');
                layer = jQuery(win.document);
            }
        }
    });
}