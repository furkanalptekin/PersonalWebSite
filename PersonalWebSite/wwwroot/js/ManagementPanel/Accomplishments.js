$(document).ready(function () {
    kendo.culture("tr-TR");

    $("#datepicker").kendoDatePicker();

    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
    });

    $("#Accomplishments").kendoGrid({
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
        scrollable: {
            virtual: false
        },
        cancel: function (e) {
            GetData()
        },
        columns: [
            { field: "Id", title: "Id" },
            { field: "Adi", title: "Adı" },
            { field: "Firma", title: "Firma" },
            { field: "Tarih", title: "Tarih" },
            { field: "EklemeTarihi", title: "Ekleme Tarihi" },
            { field: "DegisimTarihi", title: "Değişim Tarihi" },
            {
                title: "İşlemler",
                command: [
                    {
                        name: "GÖSTER",
                        title: "GÖSTER",
                        click: function (e) {
                            e.preventDefault();
                            var data = this.dataItem($(e.target).closest("tr"));
                            Show('/Accomplishment/Show/', data.Id);
                        }
                    },
                    {
                        name: "GÜNCELLE",
                        title: "GÜNCELLE",
                        click: function (e) {
                            e.preventDefault();
                            var data = this.dataItem($(e.target).closest("tr"));
                            Update('/Accomplishment/Update/', data.Id);
                        }
                    },
                    {
                        name: "SİL",
                        title: "SİL",
                        click: function (e) {
                            e.preventDefault();
                            var tr = $(e.target).closest("tr");
                            var data = this.dataItem(tr);
                            Delete('/Accomplishment/Delete/', data.Id, tr);
                        }
                    }]
            }
        ]
    });
});

function GetData() {
    var grid = $('#Accomplishments').data("kendoGrid");
    if (grid !== undefined) {
        grid.dataSource.data([]);
    }

    $.ajax({
        url: '/Accomplishment/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
        }
    });
}

function AddData(data) {
    var grid = $('#Accomplishments').data("kendoGrid");
    console.log(data);
    var array = data.Tarih.split(".");
    var tempDate = new Date(array[2], array[1] - 1, array[0]);
    var temp = {
        Id: data.Id,
        Adi: data.Adi,
        Firma: data.Firma,
        Tarih: tempDate.toLocaleDateString(),
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}