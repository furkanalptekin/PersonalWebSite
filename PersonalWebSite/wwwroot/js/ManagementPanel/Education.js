$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);
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

    $("#educations").kendoGrid({
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
                    {
                        name: "goster",
                        text: "",
                        iconClass: "k-icon k-i-select-all m-0",
                        click: function (e) {
                            e.preventDefault();
                            var data = this.dataItem($(e.target).closest("tr"));
                            ChangeURL('/Education/Show/', data.Id);
                        }
                    },
                    {
                        name: "guncelle",
                        text: "",
                        iconClass: "k-icon k-i-edit m-0",
                        click: function (e) {
                            e.preventDefault();
                            var data = this.dataItem($(e.target).closest("tr"));
                            ChangeURL('/Education/Update/', data.Id);
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
                            Delete('/Education/Delete/', data.Id, tr);
                        }
                    }]
            }
        ]
    });
});

function GetData() {
    var grid = $('#educations').data("kendoGrid");
    if (grid !== undefined) {
        grid.dataSource.data([]);
    }

    $.ajax({
        url: '/Education/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
        }
    });
}

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