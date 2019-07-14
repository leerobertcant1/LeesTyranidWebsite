$(document).ready(function () {
    $.ajax({
        url: 'Home/GetBannerData',
        type: 'GET',
        contentType: 'application/json;',
        success: function (response) {
            let titles = response.split(',');

            titles.forEach(function (entry) {
                $("#navbarHeader").append("<a class='navbar-brand' href='/'>" + entry + "</a>");
            });
        }
    });
});

