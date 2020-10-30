$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Projects");
    helper.createDatePicker("baslangicTarihi");
    helper.createDatePicker("bitisTarihi");
    helper.createTabStrip("tabstrip");

    var columns = [
        { field: "Id", title: "Id" },
        { field: "Adi", title: "Adı" },
        { field: "BaslangicTarihi", title: "Başlangıç Tarihi" },
        { field: "BitisTarihi", title: "Bitiş Tarihi" },
        { field: "KullanilanDiller", title: "Kullanılan Diller" },
        { field: "Kategori", title: "Kategori" },
        { field: "EklemeTarihi", title: "Ekleme Tarihi" },
        { field: "DegisimTarihi", title: "Değişim Tarihi" },
        {
            template: '<a href="#:Link#" class="k-button"><i class="k-icon k-i-hyperlink-open"></i></a>',
            field: "Link",
            title: ""
        },
        {
            title: "İşlemler",
            command: [
                helper.fieldShow(),
                helper.fieldUpdate(),
                helper.fieldDelete()
            ]
        }
    ]

    helper.createGrid("projects", columns);
});

function AddData(data) {
    var grid = $('#projects').data("kendoGrid");
    var temp = {
        Id: data.Id,
        Adi: data.Adi,
        Link: data.Link,
        BaslangicTarihi: new Date(data.BaslangicTarihi).toLocaleDateString(),
        BitisTarihi: data.BitisTarihi !== null ? new Date(data.BitisTarihi).toLocaleDateString() : '-',
        KullanilanDiller: data.KullanilanDiller,
        Kategori: data.Kategori,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}