function Update(url, id) {
    window.location.href = window.location.origin + url + id;
}

function Show(url, id) {
    window.location.href = window.location.origin + url + id;
}

function Delete(url, id, tr) {
    var result = confirm("Silmek istediğinize emin misiniz?");
    if (result) {
        $.ajax({
            url: url,
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