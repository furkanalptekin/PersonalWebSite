$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("SkillCategories");
    helper.createTabStrip("tabstrip");

    var columns = [
            { field: "Id", title: "Id" },
            { field: "Adi", title: "Kategori Adı" },
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
    helper.createGrid("Categories", columns);
});

function AddData(data) {
    var grid = $('#Categories').data("kendoGrid");
    var temp = {
        Id: data.Id,
        Adi: data.Adi,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}