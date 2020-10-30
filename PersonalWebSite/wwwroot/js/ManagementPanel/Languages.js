$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Languages");
    helper.createDatePicker("datepicker");
    helper.createTabStrip("tabstrip");

    var columns = [
        { field: "Id", title: "Id" },
        { field: "Adi", title: "Adı" },
        { field: "Seviyesi", title: "Seviyesi" },
        { field: "OkumaSeviyesi", title: "Okuma Seviyesi" },
        { field: "YazmaSeviyesi", title: "Yazma Seviyesi" },
        { field: "KonusmaSeviyesi", title: "Konuşma Seviyesi" },
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

    helper.createGrid("Lang", columns);
});

function AddData(data) {
    var grid = $('#Lang').data("kendoGrid");
    var temp = {
        Id: data.Id,
        Adi: data.Adi,
        Seviyesi: data.Seviyesi,
        OkumaSeviyesi: data.OkumaSeviyesi,
        YazmaSeviyesi: data.YazmaSeviyesi,
        KonusmaSeviyesi: data.KonusmaSeviyesi,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}