$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Account");
    helper.createTabStrip("tabstrip");

    var columns = [
        { field: "Id", title: "Id" },
        { field: "Email", title: "Email" },
        { field: "NameSurname", title: "Ad Soyad" },
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
    helper.createGrid("accounts", columns);

});

function AddData(data) {
    var grid = $('#accounts').data("kendoGrid");
    var temp = {
        Id: data.Id,
        Email: data.Email,
        NameSurname: data.NameSurname,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}