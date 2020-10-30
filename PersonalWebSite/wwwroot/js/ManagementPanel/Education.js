$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Education");
    helper.createDatePicker("baslangicTarihi");
    helper.createDatePicker("bitisTarihi");

    helper.createTabStrip("tabstrip");

    var columns = [
        { field: "Id", title: "Id" },
        { field: "OkulAdi", title: "Okul Adı" },
        { field: "MezuniyetDerecesi", title: "Mezuniyet Derecesi" },
        { field: "Bolum", title: "Bölüm" },
        { field: "BaslangicTarihi", title: "Başlangıç Tarihi" },
        { field: "BitisTarihi", title: "Bitiş Tarihi" },
        { field: "EklemeTarihi", title: "Ekleme Tarihi" },
        { field: "DegisimTarihi", title: "Değişim Tarihi" },
        {
            title: "İşlemler",
            command: [
                helper.fieldShow(),
                helper.fieldUpdate(),
                helper.fieldDelete()
            ]
        }
    ]

    helper.createGrid("educations", columns);
});

function AddData(data) {
    var grid = $('#educations').data("kendoGrid");
    var temp = {
        Id: data.Id,
        OkulAdi: data.OkulAdi,
        MezuniyetDerecesi: data.MezuniyetDerecesi,
        Bolum: data.Bolum,
        BaslangicTarihi: new Date(data.BaslangicTarihi).toLocaleDateString(),
        BitisTarihi: data.BitisTarihi !== null ? new Date(data.BitisTarihi).toLocaleDateString() : '-',
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}

function GetDistricts() {
    var CityId = $('#CityId').val();
    $.ajax({
        url: '/Education/GetDistricts/',
        type: "POST",
        dataType: "JSON",
        data: { CityId: CityId },
        success: function (result) {
            $("#districts").html("");
            $.each(result, function (i, r) {
                $("#districts").append(
                    $('<option></option>').val(r.value).html(r.text));
            });
        }
    });
}