$(document).ready(function () {
    kendo.culture("tr-TR");

    $("#baslangicTarihi").kendoDatePicker();
    $("#bitisTarihi").kendoDatePicker();

    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
    });

    $("#projects").kendoGrid({
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
                    {
                        name: "goster",
                        text: "",
                        iconClass: "k-icon k-i-select-all m-0",
                        click: function (e) {
                            e.preventDefault();
                            var data = this.dataItem($(e.target).closest("tr"));
                            ChangeURL('/Projects/Show/', data.Id);
                        }
                    },
                    {
                        name: "guncelle",
                        text: "",
                        iconClass: "k-icon k-i-edit m-0",
                        click: function (e) {
                            e.preventDefault();
                            var data = this.dataItem($(e.target).closest("tr"));
                            ChangeURL('/Projects/Update/', data.Id);
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
                            Delete('/Projects/Delete/', data.Id, tr);
                        }
                    }]
            }
        ]
    });
});

function GetData() {
    var grid = $('#projects').data("kendoGrid");
    if (grid !== undefined) {
        grid.dataSource.data([]);
    }

    $.ajax({
        url: '/Projects/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
        }
    });
}

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