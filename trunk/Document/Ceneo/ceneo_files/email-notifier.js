function ShowEmailNotifierForm(CategoryId, CategoryPromotedProductsTypeId) {

    $(".promoted-products-popup").hide();
    var element = $("#email-notifier-form-" + CategoryId + "-" + CategoryPromotedProductsTypeId)
    ResetEmailNotifierCaptcha(element);
    var pos = $("#email-notifier-link-" + CategoryId + "-" + CategoryPromotedProductsTypeId).offset();
    element.css({ position: "absolute", top: (pos.top - 100), left: (pos.left-435) });
    element.show();
    element.find("strong img").click(function() {
        $(".promoted-products-popup").hide();
    });
}

function ResetEmailNotifierCaptcha(element) {
    $(element).find(".form-body-captchaimage").attr("alt", "Ładuję obrazek...");
    $(element).find(".form-body-captchaimage").attr("src", "");
    $.getJSON("GetEmailNotifierCaptchaData", (new Date().toString()), function(data, textStatus) {
        $(element).find("input[name=captcha-hidden]").val(data.EncryptedText);
        $(element).find(".form-body-captchaimage").attr("src", data.Url.replace('~/', ''));
        $(element).find(".form-body-captchaimage").attr("alt", "Przepisz kod z obrazka do pola niżej");
        $(element).find("input[name=captcha]").val("");
    });
}

function SendEmailNotifierRequest(element) {

    var container = $(element).parent().parent();
    var captcha = container.find("input[name=captcha]").val();
    var captchaHidden = container.find("input[name=captcha-hidden]").val();
    var email = container.find("input[name=email]").val();
    var categoryId = container.find("input[name=category-id]").val();
    var typeId = container.find("input[name=type-id]").val();
    var accept = container.find("input[name=accept]").is(':checked');
    $.getJSON("AddEmailNotifier", { categoryId: categoryId, categoryPromotedProductsTypeId: typeId, email: email, captcha: captcha, captchaHidden: captchaHidden, accept: accept }, function(data, textStatus) {
        if (data.IsValid) {
            $(".promoted-products-popup").hide();
            $(".promoted-products-popup input[name=email]").val("");
            $(".promoted-products-popup input[name=captcha]").val("");
            $(".promoted-products-popup input[name=accept]").attr('checked', false);
            diplayModal('<div><h3>' + data.SuccessMessage + '<img src="common/image/icon/close.gif" style="position: absolute; top: 15px; right: 15px; cursor:pointer;" /></h3></div>');

        }
        else {
            ResetEmailNotifierCaptcha(container)
            diplayModal('<div><h3>' + data.ErrorsMessage + '<img src="common/image/icon/close.gif" style="position: absolute; top: 15px; right: 15px; cursor:pointer;" /></h3></div>');
        }
    });
}

function ResetEmailNotifierNewsletterCaptcha(element) {
    //$(element).find(".form-body-captchaimage").attr("alt", "Ładuję obrazek...");
    //$(element).find(".form-body-captchaimage").attr("src", "");
    $.getJSON("GetEmailNotifierCaptchaData", (new Date().toString()), function(data, textStatus) {
        element.find("input[name=captchaHidden]").val(data.EncryptedText);
        element.find(".form-body-captchaimage").attr("src", data.Url.replace('~/', ''));
        //$(element).find(".form-body-captchaimage").attr("alt", "Przepisz kod z obrazka do pola niżej");
        element.find("input[name=captcha]").val("");        
    });
}

function SendEmailNotifierNewsletterRequest(container, captchaValidate, newsletterSourceName, categoryId) {        
    var email = container.find("input[name=email]").val();
    var accept = container.find("input[name=accept]").is(':checked');
    var t = container.find(".form-body-captchaimage");
    var captcha, captchaHidden;
    if (captchaValidate) {
        captcha = container.find("input[name=captcha]").val();
        captchaHidden = container.find("input[name=captchaHidden]").val();
    }
    $.getJSON("AccessToNewsletterList", { email: email, accept: accept, captcha: captcha, captchaHidden: captchaHidden, captchaValidate: captchaValidate, newsletterSourceName: newsletterSourceName, categoryId: categoryId }, function(data, textStatus) {
        if (data.IsValid) {
            $(".promoted-products-popup").hide();
            $(".promoted-products-popup input[name=email]").val("");
            $(".promoted-products-popup input[name=captcha]").val("");
            $(".promoted-products-popup input[name=accept]").attr('checked', false);
            diplayModal('<div><h3>' + data.SuccessMessage + '<img src="common/image/icon/close.gif" style="position: absolute; top: 15px; right: 15px; cursor:pointer;" /></h3></div>');

        }
        else {
            ResetEmailNotifierNewsletterCaptcha(container)
            diplayModal('<div><h3>' + data.ErrorsMessage + '<img src="common/image/icon/close.gif" style="position: absolute; top: 15px; right: 15px; cursor:pointer;" /></h3></div>');
        }
    });
}


var overlay = $("<div id='modal-overlay'></div>");
var modalWindow = $("<div id='modal-window'></div>");

function diplayModal(text) {
    if (typeof document.body.style.maxHeight === "undefined") { //IE 6 
        $("body", "html").css({ height: "100%", width: "100%" });
        $("html").css("overflow", "hidden");
    }
    $("body").append(overlay.click(function() { modalHide(); }))
    overlay.fadeIn(0);
    $(document).keydown(handleEscape);

    modalWindow.css({
        "margin-left": -270,
        "margin-top": -100
    });

    modalWindow.append(text);
    $("body").append(modalWindow);
    $("#modal-window img").click(function() { modalHide(); });
    modalWindow.fadeIn(0);
}

function modalHide() {
    $(document).unbind("keydown", handleEscape)
    var remove = function() { $(this).remove(); };
    overlay.fadeOut(remove);
    modalWindow
					.hide()
					.empty();
}

function handleEscape(e) {
    if (e.keyCode == 27) {
        modalHide();
    }
}