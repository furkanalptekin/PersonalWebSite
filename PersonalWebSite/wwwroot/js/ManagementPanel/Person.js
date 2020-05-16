$(document).ready(function () {
    window.setTimeout(RemoveAlert, 5000);
    kendo.culture("tr-TR");

    $("#DogumTarihi").kendoDatePicker();
    $("#TecilTarihi").kendoDatePicker();

    $("#Ehliyet").kendoMultiSelect({
        autoClose: false
    }).data("kendoMultiSelect");

    $("#File").kendoUpload({
        multiple: false
    });

    $("#tabstrip").kendoTabStrip({
        animation: {
            open: {
                effects: "fadeIn"
            }
        }
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