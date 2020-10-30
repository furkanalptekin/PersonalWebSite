$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Certificates");
    helper.createDatePicker("tarih");
    helper.createDatePicker("gecerlilikSuresi");
    helper.createTabStrip("tabstrip");

    var columns = [
        { field: "Id", title: "Id" },
        { field: "Adi", title: "Adı" },
        { field: "Brans", title: "Branş" },
        { field: "Firma", title: "Firma" },
        { field: "Tarih", title: "Tarih" },
        { field: "GecerlilikSuresi", title: "Geçerlilik Süresi" },
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

    helper.createGrid("certificates", columns);
});

function AddData(data) {
    var grid = $('#certificates').data("kendoGrid");
    var temp = {
        Id: data.Id,
        Adi: data.Adi,
        Brans: data.Brans,
        Firma: data.Firma,
        Tarih: new Date(data.Tarih).toLocaleDateString(),
        GecerlilikSuresi: data.GecerlilikSuresi !== null ? new Date(data.GecerlilikSuresi).toLocaleDateString() : '-',
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}