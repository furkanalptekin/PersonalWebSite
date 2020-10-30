$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Skills");
    helper.createTabStrip("tabstrip");

    $("#colorPicker").kendoColorPicker({
        value: "#ffffff",
        buttons: false
    });

    var columns = [
        { field: "Id", title: "Id" },
        { field: "Adi", title: "Kategori Adı" },
        { field: "BasariOrani", title: "Başarı Oranı" },
        { field: "Kategori", title: "Kategori" },
        { field: "RenkKodu", title: "Renk" },
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

    helper.createGrid("Skills", columns);
});

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