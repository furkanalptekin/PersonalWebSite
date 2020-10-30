$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);

    const helper = new KendoHelper("Person");
    helper.createDatePicker("DogumTarihi");
    helper.createDatePicker("TecilTarihi");
    helper.createTabStrip("tabstrip");

    $("#Ehliyet").kendoMultiSelect({
        autoClose: false
    }).data("kendoMultiSelect");

    $("#File").kendoUpload({
        multiple: false
    });

});

function GetDistricts(CitySelectName, DistrictsSelectName) {
    var CityId = $(CitySelectName).val();
    $.ajax({
        url: '/Person/GetDistricts/',
        type: "POST",
        dataType: "JSON",
        data: { CityId: CityId },
        success: function (result) {
            $(DistrictsSelectName).html("");
            $.each(result, function (i, r) {
                $(DistrictsSelectName).append(
                    $('<option></option>').val(r.value).html(r.text));
            });
        }
    });
}