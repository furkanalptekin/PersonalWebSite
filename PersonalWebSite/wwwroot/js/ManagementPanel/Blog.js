$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);
    kendo.culture("tr-TR");

    $("#Baslangic").kendoDateTimePicker();
    $("#Bitis").kendoDateTimePicker();

    $("#File").kendoUpload({
        multiple: false
    });

    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
    });

    $("#tabstrip2").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
    });
    $("#editor").kendoEditor({
        tools: [
            "bold",
            "italic",
            "underline",
            "strikethrough",
            "justifyLeft",
            "justifyCenter",
            "justifyRight",
            "justifyFull",
            "insertUnorderedList",
            "insertOrderedList",
            "indent",
            "outdent",
            "createLink",
            "unlink",
            "insertImage",
            "insertFile",
            "subscript",
            "superscript",
            "tableWizard",
            "createTable",
            "addRowAbove",
            "addRowBelow",
            "addColumnLeft",
            "addColumnRight",
            "deleteRow",
            "deleteColumn",
            "mergeCellsHorizontally",
            "mergeCellsVertically",
            "splitCellHorizontally",
            "splitCellVertically",
            "viewHtml",
            "formatting",
            "cleanFormatting",
            "copyFormat",
            "applyFormat",
            "fontName",
            "fontSize",
            "foreColor",
            "backColor",
            "print"
        ]
    });

    $("#Blogs").kendoGrid({
        dataSource: {
            data: GetData(),
            type: "odata",
            serverPaging: true,
            serverSorting: true,
            pageSize: 10,
        },
        autoSync: true,
        batch: true,
        height: "75vh",
        scrollable: false,
        cancel: function (e) {
            GetData()
        },
        columns: [
            { field: "Id", title: "Id" },
            {
                template: ' <img width="64" height="64" src="data:image/#:IconExt#; base64, #:Icon#"/>',
                field: "Icon",
                title: "Fotoğraf"
            },
            { field: "Baslik", title: "Başlık" },
            { field: "GosterimBaslangicTarihi", title: "Gösterim Başlangıç Tarihi" },
            { field: "GosterimBitisTarihi", title: "Gösterim Bitiş Tarihi" },
            { field: "EklemeTarihi", title: "Ekleme Tarihi" },
            { field: "DegisimTarihi", title: "Değişim Tarihi" },
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
                            ChangeURL('/Blog/Show/', data.Id);
                        }
                    },
                    {
                        name: "guncelle",
                        text: "",
                        iconClass: "k-icon k-i-edit m-0",
                        click: function (e) {
                            e.preventDefault();
                            var data = this.dataItem($(e.target).closest("tr"));
                            ChangeURL('/Blog/Update/', data.Id);
                        }
                    },
                    {
                        name: "sil",
                        text: "",
                        iconClass: "k-icon k-i-delete m-0",
                        click: function (e) {
                            e.preventDefault();
                            var tr = $(e.target).closest("tr");
                            var data = this.dataItem(tr);
                            Delete('/Blog/Delete/', data.Id, tr);
                        }
                    }]
            }
        ]
    });
});

function GetData() {
    var grid = $('#Blogs').data("kendoGrid");
    if (grid !== undefined) {
        grid.dataSource.data([]);
    }

    $.ajax({
        url: '/Blog/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
        }
    });
}

function AddData(data) {
    var grid = $('#Blogs').data("kendoGrid");
    var temp = {
        Id: data.Id,
        Baslik: data.Baslik,
        Icon: data.Icon,
        IconExt: data.IconExt,
        GosterimBaslangicTarihi: new Date(data.GosterimBaslangicTarihi).toLocaleString(),
        GosterimBitisTarihi: data.GosterimBitisTarihi !== null ? new Date(data.GosterimBitisTarihi).toLocaleString() : '-',
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}