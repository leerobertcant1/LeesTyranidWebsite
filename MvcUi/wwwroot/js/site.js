$(document).ready(function () {
    var navbarItemId = sessionStorage.getItem(globals.properties.ids.navbar);

    if (!navbarItemId) {
        return;
    }

    setNavBarCss(navbarItemId);
});

function setNavBarCss(navbarItemId)
{
    removeNavbarHighlight();

    var isNavBarHome = $.trim(("#" + navbarItemId)).toLowerCase() === "navbarhome";

    if (isNavBarHome) {
        sessionStorage.setItem(globals.properties.ids.navbar, null);
        return;
    }

    $("#" + navbarItemId).addClass("navbar-brand");

    sessionStorage.setItem(globals.properties.ids.navbar, navbarItemId);
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

