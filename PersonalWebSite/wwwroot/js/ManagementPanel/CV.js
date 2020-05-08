﻿$(document).ready(function () {
    kendo.culture("tr-TR");

    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
    });

    $("#File").kendoUpload({
        validation: {
            allowedExtensions: [".pdf"]
        },
        multiple: false,
        localization: {
            select: "Dosya Seçiniz",
            invalidFileExtension: "Geçersiz Dosya Uzantısı!"
        }
    });

    $("#CV").kendoGrid({
        dataSource: {
            data: GetCVs(),
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
            GetCVs()
        },
        columns: [
            { field: "Id", title: "Id" },
            { field: "CvAdi", title: "Cv Adı" },
            { field: "EklemeTarihi", title: "Ekleme Tarihi" },
            {
                title: "İşlemler",
                command: [{
                    name: "GÖSTER",
                    title: "GÖSTER",
                    click: function (e) {
                        e.preventDefault();
                        var data = this.dataItem($(e.target).closest("tr"));
                        OpenPDF(data.Id);
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
                        DeletePDF(data.Id, tr);
                    },
                    title: " ",
                    width: 110
                }]
            }
        ]
    });
});

function GetCVs() {
    var cv = $('#CV').data("kendoGrid");
    if (cv !== undefined) {
        cv.dataSource.data([]);
    }
    $.ajax({
        url: '/CV/List/',
        type: "GET",
        success: function (response) {
            response.data.forEach(element => AddData(JSON.parse(element)));
        }
    });
}

function AddData(data) {
    var grid = $('#CV').data("kendoGrid");
    var temp = {
        Id: data.Id,
        CvAdi: data.CvAdi,
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString()
    };
    grid.dataSource.add(temp);
}

function OpenPDF(id) {
    $.ajax({
        url: '/CV/GetPDF/',
        type: "POST",
        dataType: "JSON",
        data: { id: id },
        success: function (response) {
            if (response.success) {
                var objbuilder = '';
                objbuilder += ('<object width="100%" height="100%"      data="data:application/pdf;base64,');
                objbuilder += (response.b64);
                objbuilder += ('" type="application/pdf" class="internal">');
                objbuilder += ('<embed src="data:application/pdf;base64,');
                objbuilder += (response.b64);
                objbuilder += ('" type="application/pdf" />');
                objbuilder += ('</object>');

                var win = window.open("", "_blank", "titlebar=yes, left=50, top=50");
                win.document.title = response.cvName;
                win.document.write('<html><body>');
                win.document.write(objbuilder);
                win.document.write('</body></html>');
                layer = jQuery(win.document);
            }
        }
    });
}

function DeletePDF(id, tr) {
    var result = confirm("Silmek istediğinize emin misiniz?");
    if (result) {
        $.ajax({
            url: '/CV/Delete/',
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