window.onload = function () {
    validateCookieArea();
}

var cookieData = {
    names : {
        cookieConsent: "cookieConsent"
    }
}

function getCookie(cookieName) {
    var concatenatedCookieName = cookieName + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var splitCookie = decodedCookie.split(';');

    for (var index = 0; index < splitCookie.length; index++) {
        var cookieAttribute = splitCookie[index];

        while (cookieAttribute.charAt(0) == ' ') {
            cookieAttribute = cookieAttribute.substring(1);
        }

        if (cookieAttribute.indexOf(concatenatedCookieName) == 0) {
            return cookieAttribute.substring(concatenatedCookieName.length, cookieAttribute.length);
        }
    }

    return "";
}

function getCookieDateInYear() {
    var date = new Date();
    var year = date.getFullYear();
    var month = date.getMonth();
    var day = date.getDate();

    return new Date(year + 1, month, day);
}

function hideCookieArea() {
    $("#cookieConsent").css("display", "none");
}

function showCookieArea() {
    $("#cookieConsent").css("display", "block");
}

function setCookie() {
    hideCookieArea();
    document.cookie = `cookieConsent=true; expires=${getCookieDateInYear()}`;
}

function validateCookieArea() {
    var consentCookie = getCookie(cookieData.names.cookieConsent);
    var isNoCookieSet = consentCookie === undefined || consentCookie === null || consentCookie === ""

    if (!isNoCookieSet) {
        return;
    }   

    showCookieArea();
}