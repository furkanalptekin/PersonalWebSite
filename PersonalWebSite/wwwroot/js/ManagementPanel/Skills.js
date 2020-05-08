$(document).ready(function () {
    kendo.culture("tr-TR");

    $("#colorPicker").kendoColorPicker({
        value: "#ffffff",
        buttons: false
    });

    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
    });

    $("#Skills").kendoGrid({
        dataSource: {
            data: GetList(),
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
            GetList()
        },
        columns: [
            { field: "Id", title: "Id" },
            { field: "Adi", title: "Kategori Adı" },
            { field: "BasariOrani", title: "Başarı Oranı" },
            { field: "Kategori", title: "Kategori" },
            { field: "RenkKodu", title: "Renk" },
            { field: "EklemeTarihi", title: "Ekleme Tarihi" },
            { field: "DegisimTarihi", title: "Değişim Tarihi" },
            {
                title: "İşlemler",
                command: [{
                    name: "GÜNCELLE",
                    title: "GÜNCELLE",
                    click: function (e) {
                        e.preventDefault();
                        var data = this.dataItem($(e.target).closest("tr"));
                        Update(data.Id);
                    },
                    title: " ",
                    width: 110
                },
                {
                    name: "SİL",
                    title: "SİL",
                    click: function (e) {
                        e.preventDefault();
                        var tr = $(e.target).closest("tr");
                        var data = this.dataItem(tr);
                        Delete(data.Id, tr);
                    },
                    title: " ",
                    width: 110
                }]
            }
        ]
    });
});

function GetList() {
    var grid = $('#Skills').data("kendoGrid");
    if (grid !== undefined) {
        grid.dataSource.data([]);
    }
    $.ajax({
        url: '/Skills/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
            ColorTest();
        }
    });
}

function AddData(data) {
    var grid = $('#Skills').data("kendoGrid");
    var temp = {
        Id: data.Id,
        Adi: data.Adi,
        BasariOrani: data.BasariOrani,
        Kategori: data.KategoriAdi,
        RenkKodu: data.RenkKodu,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}

function ColorTest() {
    var grid = $("#Skills").data("kendoGrid");
    var data = grid.dataSource.data();
    $.each(data, function (i, row) {
        $('tr[data-uid="' + row.uid + '"] ').css("background-color", row.RenkKodu);
    })
}

function GetRandomColor() {
    var colorPicker = $('#colorPicker').data("kendoColorPicker");
    var randomColor = "#000000".replace(/0/g, function () { return (~~(Math.random() * 16)).toString(16); });
    colorPicker.value(randomColor);
}

function Update(id) {
    window.location.href = window.location.origin + '/Skills/Update/' + id;
}

function Delete(id, tr) {
    var result = confirm("Silmek istediğinize emin misiniz?");
    if (result) {
        $.ajax({
            url: '/Skills/Delete/',
            type: "POST",
            dataType: "JSON",
            data: { id: id },
            success: function (response) {
                if (response.success) {
                    tr.find('td').fadeOut(1000, function () {
                        tr.remove();
                    });
                }
            }
        });
    }
}