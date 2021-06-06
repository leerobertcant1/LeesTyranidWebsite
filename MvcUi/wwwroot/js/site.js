$(document).ready(function () {
    var navbarItemId = sessionStorage.getItem(globals.properties.ids.navbar);

    if (!navbarItemId) {
        return;
    }

    setNavBarCss(navbarItemId);
    setImageSize();

    $(window).on("resize", function () {
        setImageSize();
    });
});

function setImageSize() {
    if (window.location.href.indexOf("Models?") == -1) {
        return;
    }

    let imageItems = $(".img-item");
    let imageRow = $(".img-row");
    let limits = { Mobile: 600, OnePictureLarge: 1000, OnePictureSmall: 600 };

    for (let rowIndex = 0; rowIndex < imageRow.length; rowIndex++) {
        for (let itemIndex = 0; itemIndex < imageItems.length; itemIndex++) {
            let isMobile = imageRow[rowIndex].clientWidth < limits.Mobile;

            imageItems[itemIndex].width = isMobile ? 400 : 500;
            imageItems[itemIndex].height = isMobile ? 400 : 600;

            setImgCss({ ImageRow: imageRow, RowIndex: rowIndex, ImageItems: imageItems, ItemIndex: itemIndex, Limits: limits });

            console.log(`${imageRow[rowIndex].clientWidth}`);
        }
    }
}

function setImgCss(values) {
    if (values.ImageRow[values.RowIndex].clientWidth < values.Limits.OnePictureLarge && values.ImageRow[values.RowIndex].clientWidth > values.Limits.OnePictureSmall) {
        $(values.ImageItems[values.ItemIndex]).addClass("left-margin-large");
        $(values.ImageItems[values.ItemIndex]).removeClass("left-margin-small");
        $(".model-role-title", ".tyranids-title").removeClass("left-margin-large");
        $(".model-role-title", ".tyranids-title").removeClass("left-margin-small");
    } else if (values.ImageRow[values.RowIndex].clientWidth < values.Limits.OnePictureLarge) {
        $(values.ImageItems[values.ItemIndex]).removeClass("left-margin-large");
        $(values.ImageItems[values.ItemIndex], ".model-role-title", ".tyranids-title").addClass("left-margin-small");
    } else {
        $(values.ImageItems[values.ItemIndex], ".model-role-title", ".tyranids-title").removeClass("left-margin-large");
        $(values.ImageItems[values.ItemIndex], ".model-role-title", ".tyranids-title").removeClass("left-margin-small");
    }
}

function setNavBarCss(navbarItemId) {
    removeNavbarHighlight();

    var isNavBarHome = $.trim(("#" + navbarItemId)).toLowerCase() === "navbarhome";

    if (isNavBarHome) {
        sessionStorage.setItem(globals.properties.ids.navbar, null);
        return;
    }

    $("#" + navbarItemId).addClass("navbar-brand");

    sessionStorage.setItem(globals.properties.ids.navbar, navbarItemId);
}

function removeNavbarHighlight(){
    var navbarItems = $(".navbar-item");

    if (!navbarItems) {
        return;
    }

    for (var i = 0; i < navbarItems.length; i++) {
        $(navbarItems[i]).removeClass("navbar-brand");
    }
}

