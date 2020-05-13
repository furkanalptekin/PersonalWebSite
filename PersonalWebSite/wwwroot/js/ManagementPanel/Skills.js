$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);
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
        scrollable: false,
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
                    name: "guncelle",
                    text: "",
                    iconClass: "k-icon k-i-edit m-0",
                    click: function (e) {
                        e.preventDefault();
                        var data = this.dataItem($(e.target).closest("tr"));
                        ChangeURL('/Skills/Update/', data.Id);
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
                        Delete('/Skills/Delete/', data.Id, tr);
                    }
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
            BackgroundColors();
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

function BackgroundColors() {
    //var grid = $("#Skills").data("kendoGrid");
    //var data = grid.dataSource.data();
    //$.each(data, function (i, row) {
    //    $('tr[data-uid="' + row.uid + '"] ').css("background-color", row.RenkKodu);
    //});
    var trs = document.getElementById("Skills").getElementsByTagName("tr");
    for (var i = 1; i < trs.length; i++) {
        var temp = trs[i].getElementsByTagName("td");
        temp[4].style.backgroundColor = temp[4].innerHTML;
    }
}

function GetRandomColor() {
    var colorPicker = $('#colorPicker').data("kendoColorPicker");
    var randomColor = "#000000".replace(/0/g, function () { return (~~(Math.random() * 16)).toString(16); });
    colorPicker.value(randomColor);
}