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

    $("#accounts").kendoGrid({
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
            { field: "KullaniciAdi", title: "Kullanıcı Adı" },
            { field: "AdSoyad", title: "Ad Soyad" },
            { field: "EklemeTarihi", title: "Ekleme Tarihi" },
            { field: "DegisimTarihi", title: "Değişim Tarihi" },
            {
                title: "İşlemler",
                command: [
                    {
                        name: "goster",
                        text: "",
                        iconClass: "k-icon k-i-select-all m-0",
                        click: function (e) {
                            e.preventDefault();
                            var data = this.dataItem($(e.target).closest("tr"));
                            ChangeURL('/Account/Show/', data.Id);
                        }
                    },
                    {
                        name: "guncelle",
                        text: "",
                        iconClass: "k-icon k-i-edit m-0",
                        click: function (e) {
                            e.preventDefault();
                            var data = this.dataItem($(e.target).closest("tr"));
                            ChangeURL('/Account/Update/', data.Id);
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
                            Delete('/Account/Delete/', data.Id, tr);
                        }
                    }]
            }
        ]
    });
});

function GetData() {
    var grid = $('#accounts').data("kendoGrid");
    if (grid !== undefined) {
        grid.dataSource.data([]);
    }

    $.ajax({
        url: '/Account/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
        }
    });
}

function AddData(data) {
    var grid = $('#accounts').data("kendoGrid");
    var temp = {
        Id: data.Id,
        KullaniciAdi: data.KullaniciAdi,
        AdSoyad: data.AdSoyad,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}