function ChangeURL(url, id) {
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

function RemoveAlert() {
    var div = document.getElementById("Alert");
    if (div !== null) {
        fadeOutEffect(div);
    }
}

function fadeOutEffect(div) {
    var fadeEffect = setInterval(function () {
        if (!div.style.opacity) {
            div.style.opacity = 1;
        }
        if (div.style.opacity > 0) {
            div.style.opacity -= 0.1;
        } else {
            clearInterval(fadeEffect);
            div.remove();
        }
    }, 50);
}