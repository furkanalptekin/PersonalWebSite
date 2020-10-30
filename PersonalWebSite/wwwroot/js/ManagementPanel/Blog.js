$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Blog");
    helper.createDateTimePicker("Baslangic");
    helper.createDateTimePicker("Bitis");

    helper.createTabStrip("tabstrip");
    helper.createTabStrip("tabstrip2");

    $("#File").kendoUpload({
        multiple: false
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

    var columns = [
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
                helper.fieldShow(),
                helper.fieldUpdate(),
                helper.fieldDelete()
            ]
        }
    ]
    helper.createGrid("Blogs", columns);
});

function AddData(data) {
    var grid = $('#Blogs').data("kendoGrid");
    if (data.Fotograf !== null) {
        var tempArray = data.Fotograf.split("|");
    }
    else {
        var tempArray = ["-", "-"];
    }
    var temp = {
        Id: data.Id,
        Baslik: data.Baslik,
        IconExt: tempArray[0],
        Icon: tempArray[1],
        GosterimBaslangicTarihi: new Date(data.GosterimBaslangicTarihi).toLocaleString(),
        GosterimBitisTarihi: data.GosterimBitisTarihi !== null ? new Date(data.GosterimBitisTarihi).toLocaleString() : '-',
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}