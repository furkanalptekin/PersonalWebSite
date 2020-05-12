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

    $("#File").kendoUpload({
        multiple: false
    });

    $("#Exp").kendoGrid({
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
            { field: "Firma", title: "Firma" },
            {
                template: '<img width="64" height="64" src="data:image/#:IconExt#; base64, #:Icon#"/>',
                field: "Icon",
                title: "Icon"
            },
            { field: "Pozisyon", title: "Pozisyon" },
            { field: "BaslangicTarihi", title: "Başlangıç Tarihi" },
            { field: "BitisTarihi", title: "Bitiş Tarihi" },
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
                        ChangeURL('/Career/Update/', data.Id);
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
                        Delete('/Career/Delete/', data.Id, tr);
                    }
                }]
            }
        ]
    });
});

function GetData() {
    var grid = $('#Exp').data("kendoGrid");
    if (grid !== undefined) {
        grid.dataSource.data([]);
    }

    $.ajax({
        url: '/Career/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
        }
    });
}

function AddData(data) {
    var grid = $('#Exp').data("kendoGrid");
    var temp = {
        Id: data.Id,
        Firma: data.Firma,
        Icon: data.Icon,
        IconExt: data.IconExt,
        Pozisyon: data.Pozisyon,
        BaslangicTarihi: new Date(data.BaslangicTarihi).toLocaleDateString(),
        BitisTarihi: data.BitisTarihi !== null ? new Date(data.BitisTarihi).toLocaleDateString() : '-',
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}