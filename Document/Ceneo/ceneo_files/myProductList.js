var MyProductsList = {
    loaded: 0,
    expanded: 0,
    animationSpeed: 200,
    tabIndex: 1,
    showMe: true,
    maxNameLength: 70,
    maxCheckedProduct: 5,
    animating: false,
    allCategoriesText: 'wszystkie kategorie',
    npSavedProductsEmptyHtml: "<li isEmpty=\"true\" class=\"empty\"><h4>Schowek jest pusty.</h4></li>",
    npLVProductsEmptyHtml: "<li isEmpty=\"true\" class=\"empty\"><h4>Nie masz żadnych ostatnio przeglądanych produktów.</h4> <br/> Sprawdź <a href=\"/info/notes.html\">jak działa funkcja Ostatnio  przeglądane produkty w Ceneo?</a></li>",
    npLVProductsDisabledHtml: "<span class=\"empty\"><h4>Funkcja zapamiętywania przeglądanych produktów jest wyłączona.</h4> <br/><a href=\"#\"  onclick=\"return MyProductsList.ToggleLastVisitedState();\">Kliknij aby włączyć funkcję zapamiętywania przeglądanych produktów.</a></span>",

    Add: function(productId, categoryId, categoryName) {
        var items = this.GetCounter();
        if (items < 100) {
            var removeLink = $(".removeFromMyProductList" + productId);
            var addLink = $(".addToMyProductList" + productId);
            if (!addLink.attr("block")) {
                removeLink.attr("block", "1");
                addLink.attr("block", "1");
                if (MyProductsList.expanded == 0) {
                    MyProductsList.ToggleVisibility(true);
                }
                $.ajax({
                    url: '/MyProductListAdd/' + productId,
                    cache: false,
                    success: function(data) {
                        if (MyProductsList.showMe && data.length > 0) {
                            var ul = $("#npSavedProducts");
                            if (ul.find('li.[isEmpty]').length == 0) {
                                ul.prepend(data);
                            } else {
                                ul.html(data);
                            }

                            if ($("#cat-notes-" + categoryId).length == 0) {
                                var liCount = $("#notesCategories li").length;
                                var liCat = $("#notesCategories li:first-child");
                                var cat = "<li><a href=\"#\" id=\"cat-notes-" + categoryId + "\" onclick=\"return MyProductsList.GetByCategoryId(" + categoryId + ");\">" + categoryName + " (<span>1</span>)</a></li>";
                                for (var i = 0; i < liCount; i++) {
                                    if (liCat.text() >= categoryName) {
                                        break;
                                    }
                                    liCat = liCat.next();
                                }
                                if (liCat.text() >= categoryName) {
                                    $(cat).insertBefore(liCat);
                                } else {
                                    $("#notesCategories").append(cat);
                                }
                            }
                            else {
                                var catVisible = $("#NotesSTabBtn dl dt a");
                                var cat = $("#cat-notes-" + categoryId);
                                if (catVisible.html() == cat.html()) {
                                    var catVisibleSpan = $(catVisible).find("span");
                                    catVisibleSpan.text(parseInt(catVisibleSpan.text()) + 1);
                                }
                                var catSpan = $("#cat-notes-" + categoryId + " span");
                                catSpan.text(parseInt(catSpan.text()) + 1);
                            }

                            MyProductsList.ShowSaved();

                            //ProductCarousel.Reset(1);
                            ProductCarousel.Check(1);
                            var name = $(data).find(".name").attr("title");
                            MyProductsList.Info.ShowAdded("Produkt <strong>" + (name.length > MyProductsList.maxNameLength ? name.substring(0, MyProductsList.maxNameLength) + '...' : name) + "</strong> dodano do schowka.");
                        }

                        MyProductsList.SetCounter(MyProductsList.GetCounter() + 1);
                        addLink.hide().removeAttr("block");
                        removeLink.show().removeAttr("block");
                    },
                    dataType: "html"
                });
            }
        } else {
            this.Info.ShowAdded("Do schowka możesz dodać maksymalnie <strong>100</strong> produktów.");
        }
        return false;
    },

    Remove: function(productId, categoryId, selector) {
        var removeLink = $(".removeFromMyProductList" + productId);
        var addLink = $(".addToMyProductList" + productId);
        if (!removeLink.attr("block")) {
            removeLink.attr("block", "1");
            addLink.attr("block", "1");
            $.ajax({
                url: '/MyProductListRemove/' + productId,
                cache: false,
                type: 'POST',
                success: function(data) {
                    if (eval(data)) {
                        var count = MyProductsList.GetCounter() - 1;
                        if (MyProductsList.showMe) {
                            var name = $("#np-" + productId + " a.name").attr("title");
                            if (name == "" || name == undefined) {
                                name = selector.find(".desc h2 a").text();
                                if (name == "" || name == undefined) {
                                    name = selector.find(".desc h2").text();
                                }
                            }
                            $("#np-" + productId).replaceWith("");
                            if (count <= 0) {
                                $("#npSavedProducts").html(MyProductsList.npSavedProductsEmptyHtml);
                            }
                            var catVisible = $("#NotesSTabBtn dl dt a");
                            var cat = $("#cat-notes-" + categoryId);
                            if ($("#npSavedProducts li[cat=" + categoryId + "]").length == 0) {
                                if (catVisible.html() == cat.html()) {
                                    MyProductsList.ShowSaved();
                                }
                                $(cat).remove();
                            } else {
                                if (catVisible.html() == cat.html()) {
                                    //MyProductsList.ShowSavedReset();
                                    MyProductsList.CheckByCategoryId(categoryId);
                                    var catVisibleSpan = $(catVisible).find("span");
                                    catVisibleSpan.text(parseInt(catVisibleSpan.text()) - 1);
                                }
                                var catSpan = $(cat).find("span");
                                catSpan.text(parseInt(catSpan.text()) - 1);
                            }

                            ProductCarousel.CheckAndPrev(1);
                            ProductCarousel.Check(1);
                            MyProductsList.Info.ShowAdded("Produkt <strong>" + (name.length > MyProductsList.maxNameLength ? name.substring(0, MyProductsList.maxNameLength) + '...' : name) + "</strong> usunięto ze schowka.");
                        }

                        if (document.title.indexOf("Produkty dodane do schowka", 0) >= 0) {
                            selector.find("script").remove();
                            selector.fadeOut(100);
                        }

                        MyProductsList.SetCounter(count);
                        removeLink.hide().removeAttr("block");
                        addLink.show().removeAttr("block");
                    }
                },
                data: { foodata: "1"}    //  <- set data to prevent http://dev.jquery.com/ticket/2284 error
            });
        }
        return false;
    },

    RemoveAll: function() {
        $.ajax({
            url: '/MyProductListRemove',
            cache: false,
            type: 'POST',
            success: function(data) {
                MyProductsList.SetCounter(0);
                if (MyProductsList.showMe) {
                    $("#npSavedProducts").html(MyProductsList.npSavedProductsEmptyHtml);
                    $("#notesCategories").html("");
                    $("#notesCategories").hide();
                    ProductCarousel.Reset(1);
                    ProductCarousel.Check(1);
                    MyProductsList.Info.ShowAdded("Usunięto wszystkie produkty ze schowka.");

                }
                $("a[class^=removeFromMyProductList]").hide();
                $("a[class^=addToMyProductList]").fadeIn(1000);

            },
            data: { foodata: "1"}    //  <- set data to prevent http://dev.jquery.com/ticket/2284 error
        });

        return false;
    },

    RemoveLV: function(productId, categoryId, selector) {
        $.ajax({
            url: '/MyProductListRemoveLastVisited/' + productId,
            cache: false,
            type: 'POST',
            success: function(data) {
                if (MyProductsList.showMe) {
                    var name = $("#np-lv-" + productId + " a.name").attr("title");
                    var count = 0;
                    //counter for LV is visible
                    var counter = $("#NotesLVTabBtn").find("span");
                    if (counter.length) {
                        count = parseInt(counter.text()) - 1;
                        count = count < 0 ? 0 : count;
                        counter.text(count);
                    }
                    $("#np-lv-" + productId).replaceWith("");
                    if (count == 0) {
                        $("#npLVProducts").html(MyProductsList.npLVProductsEmptyHtml);
                    }
                    ProductCarousel.CheckAndPrev(0);
                    ProductCarousel.Check(0);
                    MyProductsList.Info.ShowAdded("Produkt <strong>" + (name.length > MyProductsList.maxNameLength ? name.substring(0, MyProductsList.maxNameLength) + '...' : name) + "</strong> usunięto z ostatnio przeglądanych.");

                }

            },
            data: { foodata: "1"}    //  <- set data to prevent http://dev.jquery.com/ticket/2284 error
        });

        return false;
    },

    RemoveAllLV: function() {
        $.ajax({
            url: '/MyProductListRemoveLastVisited/',
            cache: false,
            type: 'POST',
            success: function(data) {
                if (MyProductsList.showMe) {
                    $("#NotesLVTabBtn").find("span").text(0);
                    $("#npLVProducts").html(MyProductsList.npLVProductsEmptyHtml);
                    ProductCarousel.Check(0);
                    MyProductsList.Info.ShowAdded("Usunięto wszystkie produkty z ostatnio przeglądanych.");
                }
            },
            data: { foodata: "1"}    //  <- set data to prevent http://dev.jquery.com/ticket/2284 error
        });

        return false;
    },

    ToggleVisibility: function(autoExecuted) {
        if (this.showMe && !this.animating) {
            this.animating = true;
            if (this.expanded == 0) {
                if (this.loaded == 0) {
                    var fromUrl = new String(window.location).replace(window.location.protocol + "//", "").replace(window.location.host, "").replace("/", "");
                    var mplUrl = "/MyProductList/" + fromUrl;
                    $.ajax({
                        url: mplUrl,
                        cache: false,
                        success: function(data) {
                            $("#NotesPanel").html(data);
                            MyProductsList.loaded = 1;
                        },
                        dataType: "html",
                        async: false
                    });
                    this.CheckCompare("-notes");
                    ProductCarousel.Check(MyProductsList.tabIndex);
                }
                //show bar
                $("#toggleNotesPanel").toggleClass("active");
                $(".notes").animate({ bottom: "0px" }, this.animationSpeed);
            }
            else if (this.expanded == 1) {
                //hide bar
                $("#toggleNotesPanel").toggleClass("active");
                $(".notes").animate({ bottom: "-170px" }, this.animationSpeed);
            }

            this.expanded = (this.expanded + 1) % 2;
            if (!autoExecuted) {
                $.ajax({ url: "/MyProductListToggleVisibility/" + (this.expanded == 1), cache: false });
            }
            this.animating = false;
        }
        return false;
    },

    ShowLite: function() {
        if (this.showMe) {
            var fromUrl = new String(window.location).replace(window.location.protocol + "//", "").replace(window.location.host, "").replace("/", "");
            var mplUrl = "/MyProductList/" + fromUrl;
            $.ajax({
                url: mplUrl,
                cache: false,
                success: function(data) {
                    $("#NotesPanel").html(data);
                    //show bar
                    $(".notes").animate({ bottom: "0px" }, 0);
                    $("#toggleNotesPanel").toggleClass("active");
                    MyProductsList.CheckCompare("-notes");
                    ProductCarousel.Check(MyProductsList.tabIndex);
                    MyProductsList.expanded = 1;
                    MyProductsList.loaded = 1;
                },
                dataType: "html"
            });
        }
    },

    CheckByCategoryId: function(categoryId) {
        $("#npSavedProducts li input:checkbox").attr("checked", false);
        var len = $("#npSavedProducts li[cat=" + categoryId + "]").length;
        var li = $("#npSavedProducts li[cat=" + categoryId + "]:last");
        if (li != null) {
            for (i = 0; i < this.maxCheckedProduct && i < len; i++) {
                $(li).find(":checkbox").attr("checked", "checked");
                li = li.prevAll("li[cat=" + categoryId + "]:first");
            }
        }
        return false;
    },

    GetByCategoryId: function(categoryId) {
        $("#notesCategories").hide();
        ProductCarousel.Reset(1);
        $("#NotesSTabBtn dl dt a").html($("#cat-notes-" + categoryId).html());
        $("#npSavedProducts li[cat!=" + categoryId + "]").hide(400);
        $("#npSavedProducts li[cat=" + categoryId + "]").show(400);
        setTimeout("ProductCarousel.Check(1)", 410);
        this.CheckByCategoryId(categoryId);
        return false;
    },

    ToggleCategories: function() {
        $("#notesCategories").slideToggle(300);
        return false;
    },

    ToggleLastVisitedState: function() {
        $.ajax({
            url: '/MyProductListToggleLastVisitedState',
            cache: false,
            type: 'POST',
            data: { foodata: "1" },    //  <- set data to prevent http://dev.jquery.com/ticket/2284 error
            success: function(data) {
                if (MyProductsList.showMe) {
                    var enabled = eval(data);
                    if (!enabled) {
                        $("#NotesLVTabBtn").find("span").text(0);
                        $("#NotesLVTab").html(MyProductsList.npLVProductsDisabledHtml);
                        MyProductsList.Info.ShowAdded("Wyłączono ostatnio przeglądane.");

                    }
                    else {
                        $.ajax({
                            url: '/MyProductList',
                            cache: false,
                            success: function(data) {
                                $("#NotesPanel").html(data);
                                MyProductsList.loaded = 1;
                                MyProductsList.tabIndex = 1; //SLV has if
                                MyProductsList.ShowLastVisited();
                            },
                            dataType: "html"
                        });
                        MyProductsList.Info.ShowAdded("Włączono ostatnio przeglądane.");
                    }
                }
            }
        });
        return false;
    },

    HideIfNeeded: function() {
        if (document.title.indexOf("Produkty dodane do schowka", 0) >= 0) {
            this.showMe = false;
            $("#NotesPanel").hide();
            $("#notesHide").hide();
        }
    },

    GetCounter: function() {
        var counter = $("#cat-notes span");
        if (counter.length) {
            return parseInt(counter.text());
        } else {
            var topCounter = $("#MyProductListCount");
            if (topCounter.length) {
                return parseInt(topCounter.text());
            }
        }
        return 0;
    },

    SetCounter: function(value) {
        if (value >= 0) {
            var counter = $("#cat-notes span");
            if (counter.length) {
                counter.text(value);
            }
            var topCounter = $("#MyProductListCount");
            if (topCounter.length) {
                topCounter.hide();
                if (value >= 0) {
                    topCounter.text(value);
                }
                //topCounter.text(value);
                topCounter.fadeIn(1000, function() { if (value == 0 && document.title.indexOf("Produkty dodane do schowka", 0) >= 0) location.reload(); });
            }
        }
    },

    ShowLastVisited: function() {
        if (this.showMe && this.tabIndex != 0) {
            $("#NotesLVTabBtn").addClass("current");
            $("#NotesSTabBtn").removeClass("current");
            //add/remove class - for IE
            $("#NotesLVTab").attr("style", "display:block;").addClass("NotesPanelBody");
            $("#NotesSTab").attr("style", "display:none;").removeClass("NotesPanelBody");
            $("#NotesSTabBtn dl").hide();
            ProductCarousel.Check(0);
            this.tabIndex = 0;
        }
        return false;
    },

    ShowSaved: function() {
        if (this.showMe) {
            this.ShowSavedReset();
            ProductCarousel.Reset(1);
            $("#NotesSTabBtn dl dt a").text(this.allCategoriesText);
            $("#notesCategories").hide();
            $("#npSavedProducts li").show(400);
            $("#npSavedProducts li input:checkbox").attr("checked", false);
            //setTimeout("ProductCarousel.Reset(1)", 409);
            setTimeout("ProductCarousel.Check(1)", 410);
        }
        return false;
    },

    ShowSavedReset: function() {
        if (this.tabIndex != 1) {
            $("#NotesLVTabBtn").removeClass("current");
            $("#NotesSTabBtn").addClass("current");
            $("#NotesLVTab").attr("style", "display:none;").removeClass("NotesPanelBody"); //hide
            $("#NotesSTab").attr("style", "display:block;").addClass("NotesPanelBody"); //show
            $("#NotesSTabBtn dl").show();
            this.tabIndex = 1;
        }
    },

    //copy from full-documented.js
    CheckCompare: function(id) {
        var x = document.getElementById('form-body-compare' + (id ? id : ""));
        if (x) {
            //x.action = '.?page=compare'; // temp
            //x.action += ((x.action.indexOf('?') != -1) ? '&' : '?') + 'type=lite';
            x.onsubmit = function() {
                var count = 0;
                forEach(this.getElementsByTagName('input'), function() {
                    if (this.type == 'checkbox' && this.checked) {
                        count++;
                    }
                });
                if (count === 0) {
                    alert('Zaznacz produkty do porównania');
                    return false;
                }
                else if (count == 1) {
                    alert('Zaznacz drugi produkt do porównania');
                    return false;
                }
                else if (count > 5) {
                    alert('Możesz porównać do 5 produktów za jednym razem');
                    return false;
                }

                var singleCategory = true;
                var categoryId = null;
                var tmpHidden = null;

                forEach(this.getElementsByTagName('input'), function() {
                    if (this.type == 'checkbox' && this.checked) {
                        var tmpCategoryId = this.id.replace("form-body-compare-chbx-", "").replace("-" + this.value, "");
                        if (categoryId == null) {
                            categoryId = tmpCategoryId;
                        } else if (categoryId != tmpCategoryId) {
                            singleCategory = false;
                        }
                    }
                });

                if (!singleCategory) {
                    alert('Porównywane produkty muszą należeć do tej samej kategorii. W panelu "Moje produkty/ Dodane do schowka" masz możliwość ograniczenia listy do wybranej kategorii i porównania zaznaczonych produktów');
                    return false;
                }

                document.getElementById('form-body-compare-categoryId' + (id ? id : "")).value = categoryId;
            };
        }
    },

    Info: {
        visibilityDuration: 3000,
        ShowAdded: function(content) {
            if (MyProductsList.showMe) {
                var nInfo = $("#NotesInfo");

                $(nInfo).html(content);
                $(nInfo).fadeIn(function() {
                    400,
                    setTimeout("MyProductsList.Info.HideAdded();", MyProductsList.Info.visibilityDuration);
                });
            }
        },

        HideAdded: function() {
            if (MyProductsList.showMe) {
                $("#NotesInfo").fadeOut(400);
            }
        }
    },

    Email: {
        jQemailFormId: "#email-form-myproductslist",

        ShowEmailForm: function() {
            //$(".promoted-products-popup").hide(); //hide other email forms
            var lvpCount = parseInt($("#NotesLVTabBtn span").text());
            var spCount = MyProductsList.GetCounter();
            if (lvpCount == 0 && spCount == 0) {
                diplayModal('<div><h3>' + "Nie masz żadnych produktów w schowku, ani w ostatnio przeglądanych" + '<img src="common/image/icon/close.gif" style="position: absolute; top: 15px; right: 15px; cursor:pointer;" /></h3></div>');
                return false;
            }

            var container = $(this.jQemailFormId);
            this.ResetEmailCaptcha(container);
            container.find("input[name=lastVisited]").attr('checked', lvpCount > 0).attr('disabled', lvpCount > 0 ? '' : 'disabled');
            container.find("input[name=saved]").attr('checked', spCount > 0).attr('disabled', spCount > 0 ? '' : 'disabled');
            var pos = $("#notesHide").offset();
            container.css({ position: "absolute", top: (-150), left: (450) });
            container.show();
            container.find("strong img").click(function() {
                $(MyProductsList.Email.jQemailFormId).hide();
            });
            return false;
        },

        ResetEmailCaptcha: function(container) {
            container.find(".form-body-captchaimage").attr("alt", "Ładuję obrazek...");
            container.find(".form-body-captchaimage").attr("src", "");
            $.getJSON("GetEmailNotifierCaptchaData", (new Date().toString()), function(data, textStatus) {
                container.find("input[name=captcha-hidden]").val(data.EncryptedText);
                container.find(".form-body-captchaimage").attr("src", data.Url.replace('~/', ''));
                container.find(".form-body-captchaimage").attr("alt", "Przepisz kod z obrazka do pola niżej");
                container.find("input[name=captcha]").val("");
            });
        },

        SendEmailRequest: function() {
            var container = $(this.jQemailFormId);
            var captcha = container.find("input[name=captcha]").val();
            var captchaHidden = container.find("input[name=captcha-hidden]").val();
            var email = container.find("input[name=email]").val();
            var accept = container.find("input[name=accept]").is(':checked');
            var lastVisited = container.find("input[name=lastVisited]").is(':checked');
            var saved = container.find("input[name=saved]").is(':checked');
            $.getJSON("SendMyProductsList",
                { email: email,
                    captcha: captcha,
                    captchaHidden: captchaHidden,
                    lastVisited: lastVisited,
                    saved: saved,
                    accept: accept
                },
                function(data, textStatus) {
                    if (data.IsValid) {
                        container.hide();
                        container.find("input[name=email]").val("");
                        container.find("input[name=captcha]").val("");
                        container.find("input[name=accept]").attr('checked', false);
                        container.find("input[name=lastVisited]").attr('checked', true);
                        container.find("input[name=saved]").attr('checked', true);
                        container.find("#error").hide();
                        container.find("#errEmail").html("");
                        container.find("#errProducts").html("");
                        container.find("#errCaptcha").html("");
                        container.find("#errTerms").html("");
                        diplayModal('<div><h3>' + data.SuccessMessage + '<img src="common/image/icon/close.gif" style="position: absolute; top: 15px; right: 15px; cursor:pointer;" /></h3></div>');
                    }
                    else {
                        MyProductsList.Email.ResetEmailCaptcha(container)
                        container.find("#error").show();
                        if (data.errEmail) {
                            container.find("#errEmail").html("*");
                        } else {
                            container.find("#errEmail").html("");
                        }
                        if (data.errProducts) {
                            container.find("#errProducts").html("*");
                        } else {
                            container.find("#errProducts").html("");
                        }
                        if (data.errCaptcha) {
                            container.find("#errCaptcha").html("*");
                        } else {
                            container.find("#errCaptcha").html("");
                        }
                        if (data.errTerms) {
                            container.find("#errTerms").html("*");
                        } else {
                            container.find("#errTerms").html("");
                        }
                    }
                });
            return false;
        }
    }

};

var ProductCarousel = {
    step: 1,
    current: [0, 0],
    liSize: 100,
    visible: 7,
    carouselSpeed: 200,

    CheckAndPrev: function(id) {
        var maximum = $("#notesCarousel" + id + " .notesProducts ul li:visible").size();
        if (this.current[id] > maximum - this.visible) {
            this.Prev(id);
        }
        return false;
    },

    Next: function(id) {
        var maximum = $("#notesCarousel" + id + " .notesProducts ul li:visible").size();
        if (this.current[id] + this.step > maximum - this.visible) {
            return false;
        }
        else {
            //slide the item
            this.current[id] = this.current[id] + this.step;
            $("#notesCarousel" + id + " .notesProducts ul").animate({ left: -(this.liSize * this.current[id]) }, this.carouselSpeed);
        }
        if (this.current[id] >= maximum - this.visible) {
            $("#notesCarousel" + id + " .nextProds").removeClass("nextProdsEnabled");
            $("#notesCarousel" + id + " .nextProds").addClass("nextProdsDisabled");
        }
        else {
            $("#notesCarousel" + id + " .nextProds").removeClass("nextProdsDisabled");
            $("#notesCarousel" + id + " .nextProds").addClass("nextProdsEnabled");
        }
        if (/*this.current[id] <= 0 ||*/this.current[id] > maximum - this.visible) {
            $("#notesCarousel" + id + " .prevProds").removeClass("prevProdsEnabled");
            $("#notesCarousel" + id + " .prevProds").addClass("prevProdsDisabled");
        }
        else {
            $("#notesCarousel" + id + " .prevProds").removeClass("prevProdsDisabled");
            $("#notesCarousel" + id + " .prevProds").addClass("prevProdsEnabled");
        }

        return false;
    },

    Prev: function(id) {
        var maximum = $("#notesCarousel" + id + " .notesProducts ul li:visible").size();
        if (this.current[id] - this.step < 0) {
            return false;
        }
        else {
            //slide the item
            this.current[id] = this.current[id] - this.step;
            $("#notesCarousel" + id + " .notesProducts ul").animate({ left: -(this.liSize * this.current[id]) }, this.carouselSpeed);
        }
        if (this.current[id] >= maximum - this.visible) {
            $("#notesCarousel" + id + " .nextProds").removeClass("nextProdsEnabled");
            $("#notesCarousel" + id + " .nextProds").addClass("nextProdsDisabled");
        }
        else {
            $("#notesCarousel" + id + " .nextProds").removeClass("nextProdsDisabled");
            $("#notesCarousel" + id + " .nextProds").addClass("nextProdsEnabled");
        }
        if (this.current[id] <= 0) {
            $("#notesCarousel" + id + " .prevProds").removeClass("prevProdsEnabled");
            $("#notesCarousel" + id + " .prevProds").addClass("prevProdsDisabled");
        }
        else {
            $("#notesCarousel" + id + " .prevProds").removeClass("prevProdsDisabled");
            $("#notesCarousel" + id + " .prevProds").addClass("prevProdsEnabled");
        }

        return false;
    },

    Check: function(id) {
        var maximum = $("#notesCarousel" + id + " .notesProducts ul li:visible").size();
        if (this.current[id] >= maximum - this.visible) {
            $("#notesCarousel" + id + " .nextProds").removeClass("nextProdsEnabled");
            $("#notesCarousel" + id + " .nextProds").addClass("nextProdsDisabled");
        }
        else {
            $("#notesCarousel" + id + " .nextProds").removeClass("nextProdsDisabled");
            $("#notesCarousel" + id + " .nextProds").addClass("nextProdsEnabled");
        }
        if (this.current[id] > maximum - this.visible || this.current[id] <= 0) {
            $("#notesCarousel" + id + " .prevProds").removeClass("prevProdsEnabled");
            $("#notesCarousel" + id + " .prevProds").addClass("prevProdsDisabled");
        } else {
            $("#notesCarousel" + id + " .prevProds").removeClass("prevProdsDisabled");
            $("#notesCarousel" + id + " .prevProds").addClass("prevProdsEnabled");
        }
        return false;
    },

    Reset: function(id) {
        this.current[id] = 0;
        $("#notesCarousel" + id + " .notesProducts ul").animate({ left: -(this.liSize * this.current[id]) }, this.carouselSpeed);
        return false;
    }
}



//MyProductsList.init();