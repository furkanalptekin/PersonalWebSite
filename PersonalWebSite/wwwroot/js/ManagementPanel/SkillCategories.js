$(document).ready(function () {
    kendo.culture("tr-TR");

    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
    });

    $("#Categories").kendoGrid({
        dataSource: {
            data: GetSkillCategories(),
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
            GetSkillCategories()
        },
        columns: [
            { field: "Id", title: "Id" },
            { field: "Adi", title: "Kategori Adı" },
            { field: "EklemeTarihi", title: "Ekleme Tarihi" },
            { field: "DegisimTarihi", title: "Değişim Tarihi" },
            {
                title: "İşlemler",
                command: [{
                    name: "guncelle",
                    text: "",
                    iconClass: "k-icon k-i-edit m-0",
                    click: function (e) {
                        e.preventDefault();
                        var data = this.dataItem($(e.target).closest("tr"));
                        ChangeURL('/SkillCategories/Update/', data.Id);
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
                        Delete('/SkillCategories/Delete/', data.Id, tr);
                    }
                }]
            }
        ]
    });
});

function GetSkillCategories() {
    var grid = $('#Categories').data("kendoGrid");
    if (grid !== undefined) {
        grid.dataSource.data([]);
    }

    $.ajax({
        url: '/SkillCategories/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
        }
    });
}

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