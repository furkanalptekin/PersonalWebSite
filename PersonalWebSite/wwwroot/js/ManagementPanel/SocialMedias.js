$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("SocialMedia");
    helper.createTabStrip("tabstrip");

    $("#File").kendoUpload({
        multiple: false
    });

    var columns = [
            { field: "Id", title: "Id" },
            { field: "SosyalMedyaAdi", title: "Adı" },
            {
                template: ' <img width="64" height="64" src="data:image/#:IconExt#; base64, #:Icon#"/>',
                field: "Icon",
                title: "Icon"
            },
            { field: "Adres", title: "Adresi" },
            { field: "EklemeTarihi", title: "Ekleme Tarihi" },
            { field: "DegisimTarihi", title: "Değişim Tarihi" },
            {
                title: "İşlemler",
                command: [
                    helper.fieldUpdate(),
                    helper.fieldDelete()
                ]
            }
    ]

    helper.createGrid("SocialMedias", columns);
});

function AddData(data) {
    var grid = $('#SocialMedias').data("kendoGrid");
    if (data.Ikon !== null) {
        var tempArray = data.Ikon.split("|");
    }
    else {
        var tempArray = ["-", "-"];
    }
    var temp = {
        Id: data.Id,
        SosyalMedyaAdi: data.SosyalMedyaAdi,
        IconExt: tempArray[0],
        Icon: tempArray[1],
        Adres: data.Adres,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}