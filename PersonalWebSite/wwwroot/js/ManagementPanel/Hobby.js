$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Hobby");
    helper.createDatePicker("datepicker");
    helper.createTabStrip("tabstrip");

    $("#File").kendoUpload({
        multiple: false
    });


    var columns = [
        { field: "Id", title: "Id" },
        { field: "Adi", title: "Adı" },
        {
            template: ' <img width="64" height="64" src="data:image/#:IconExt#; base64, #:Icon#"/>',
            field: "Icon",
            title: "Icon"
        },
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

    helper.createGrid("Hobbies", columns);
});

function AddData(data) {
    var grid = $('#Hobbies').data("kendoGrid");
    if (data.Ikon !== null) {
        var tempArray = data.Ikon.split("|");
    }
    else {
        var tempArray = ["-", "-"];
    }
    var temp = {
        Id: data.Id,
        Adi: data.Adi,
        IconExt: tempArray[0],
        Icon: tempArray[1],
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}