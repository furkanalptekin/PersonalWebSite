$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);
    kendo.culture("tr-TR");

    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
    });

    $("#Lang").kendoGrid({
        dataSource: {
            data: GetData(),
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
            GetData()
        },
        columns: [
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
                command: [{
                    name: "guncelle",
                    text: "",
                    iconClass: "k-icon k-i-edit m-0",
                    click: function (e) {
                        e.preventDefault();
                        var data = this.dataItem($(e.target).closest("tr"));
                        ChangeURL('/Languages/Update/', data.Id);
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
                        Delete('/Languages/Delete/', data.Id, tr);
                    }
                }]
            }
        ]
    });
});

function GetData() {
    var grid = $('#Lang').data("kendoGrid");
    if (grid !== undefined) {
        grid.dataSource.data([]);
    }

    $.ajax({
        url: '/Languages/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
        }
    });
}

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