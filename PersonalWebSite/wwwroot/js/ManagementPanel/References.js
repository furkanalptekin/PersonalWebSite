$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("References");
    helper.createTabStrip("tabstrip");

    var columns = [
        { field: "Id", title: "Id" },
        { field: "Adi", title: "Adı" },
        { field: "Soyadi", title: "Soyadı" },
        { field: "Firma", title: "Firma" },
        { field: "Meslek", title: "Meslek" },
        { field: "Pozisyon", title: "Pozisyon" },
        { field: "Eposta", title: "Eposta" },
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

    helper.createGrid("references", columns);
});

function AddData(data) {
    var grid = $('#references').data("kendoGrid");
    var temp = {
        Id: data.Id,
        Adi: data.Adi,
        Soyadi: data.Soyadi,
        Firma: data.Firma,
        Meslek: data.Meslek,
        Pozisyon: data.Pozisyon,
        Eposta: data.Eposta,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}