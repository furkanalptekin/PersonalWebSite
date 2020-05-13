﻿$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);
    kendo.culture("tr-TR");

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

    $("#SocialMedias").kendoGrid({
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
            { field: "SosyalMedyaAdi", title: "Adı" },
            {
                template: ' <img width="64" height="64" src="data:image/#:IconExt#; base64, #:Icon#"/>',
                field: "Icon",
                title: "Icon"
            },
            { field: "Adres", title: "Adresi" },
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
                        ChangeURL('/SocialMedia/Update/', data.Id);
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
                        Delete('/SocialMedia/Delete/', data.Id, tr);
                    }
                }]
            }
        ]
    });
});

function GetData() {
    var grid = $('#SocialMedias').data("kendoGrid");
    if (grid !== undefined) {
        grid.dataSource.data([]);
    }

    $.ajax({
        url: '/SocialMedia/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
        }
    });
}

function AddData(data) {
    var grid = $('#SocialMedias').data("kendoGrid");
    var temp = {
        Id: data.Id,
        SosyalMedyaAdi: data.SosyalMedyaAdi,
        Icon: data.Icon,
        IconExt: data.IconExt,
        Adres: data.Adres,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}