$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Accomplishment");
    helper.createDatePicker("datepicker");
    helper.createTabStrip("tabstrip");

    var columns = [
        { field: "Id", title: "Id" },
        { field: "Adi", title: "Adı" },
        { field: "Firma", title: "Firma" },
        { field: "Tarih", title: "Tarih" },
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

    helper.createGrid("Accomplishments", columns);
});


function AddData(data) {
    var grid = $('#Accomplishments').data("kendoGrid");
    var array = data.Tarih.split(".");
    var tempDate = new Date(array[2], array[1] - 1, array[0]);
    var temp = {
        Id: data.Id,
        Adi: data.Adi,
        Firma: data.Firma,
        Tarih: tempDate.toLocaleDateString(),
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}