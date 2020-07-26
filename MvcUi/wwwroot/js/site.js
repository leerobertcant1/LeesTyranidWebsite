$(document).ready(function ()
{
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

function setNavBarCss(navbarItemId)
{
    removeNavbarHighlight();

    $("#" + navbarItemId).addClass("navbar-brand");
}

function removeNavbarHighlight()
{
    var navbarItems = $(".navbar-item");

    if (!navbarItems) {
        return;
    }

    for (var i = 0; i < navbarItems.length; i++) {
        $(navbarItems[i]).removeClass("navbar-brand");
    }
}

