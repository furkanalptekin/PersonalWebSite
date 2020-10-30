$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Career");
    helper.createDatePicker("baslangicTarihi");
    helper.createDatePicker("bitisTarihi");
    helper.createTabStrip("tabstrip");

    $("#File").kendoUpload({
        multiple: false
    });

    var columns = [
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
            command: [
                helper.fieldUpdate(),
                helper.fieldDelete()
            ]
        }
    ]

    helper.createGrid("Exp", columns);
});


function AddData(data) {
    var grid = $('#Exp').data("kendoGrid");
    if (data.FirmaIcon !== null) {
        var tempArray = data.FirmaIcon.split("|");
    }
    else {
        var tempArray = ["-", "-"];
    }
    var temp = {
        Id: data.Id,
        Firma: data.Firma,
        IconExt: tempArray[0],
        Icon: tempArray[1],
        Pozisyon: data.Pozisyon,
        BaslangicTarihi: new Date(data.BaslangicTarih).toLocaleDateString(),
        BitisTarihi: data.BitisTarihi !== null ? new Date(data.BitisTarih).toLocaleDateString() : '-',
        EklemeTarihi: new Date(data.EklemeTarihi).toLocaleString(),
        DegisimTarihi: data.DegisimTarihi !== null ? new Date(data.DegisimTarihi).toLocaleString() : '-'
    };
    grid.dataSource.add(temp);
}