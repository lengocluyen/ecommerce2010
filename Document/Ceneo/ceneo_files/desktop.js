$(document).ready(function()
{
	var today = new Date();
	var dateFrom = new Date(2010, 4, 24, 0, 0, 0);
	var dateTo = new Date(2010, 4, 30, 23, 59, 0);
	if (today >= dateFrom && today <= dateTo)
		$("body").attr("id", "home");
});

$(document).ready(function() {
    function megaHoverOver() {
        if (this.className == "mAC_ubezpiecznie") 
        { 
            <!-- (c) 2000-2010 Gemius SA ver 1.4 Emisje: Ceneo, link -->
            //<![CDATA[
            _gde_toffmidkrx = new Image(1,1);
            _gde_toffmidkrx.src='http://gde-default.hit.gemius.pl/_'+(new Date()).getTime()+'/redot.gif?id=bOGbwhyMAA6.FkcjZ.AsdZcPnJ6sp8vRf4B2uraB3Q..k7/stparam=toffmidkrx';
            //]]>
        }
        $(this).find(".sub").stop().fadeTo('fast', 1, function() { $(this).find(".pop-cat-img").each(function() { this.src = popularCategorySrc + this.id + '.jpg'; }) }).show();
        var topconst = 288;
        var scroll = $(window).scrollTop();
        var windowHeight = $(window).height();
        var pageOffsetFromTopOfTheScreen = $(this).offset().top;
        var subHeight = $(this).find(".sub").height();
        var farFromTopOfTheScreen = pageOffsetFromTopOfTheScreen - scroll;
        var farFromBottomOfTheScreen = windowHeight - pageOffsetFromTopOfTheScreen + scroll;
        var topcss = 0;
        if (farFromBottomOfTheScreen < subHeight + 32) {
            if (subHeight - farFromBottomOfTheScreen + 40 < farFromTopOfTheScreen)
                topcss = topcss - (subHeight - farFromBottomOfTheScreen) - 15;
            else
                topcss = topcss - farFromTopOfTheScreen + 6;
        }
        $(this).find(".sub").css({ 'top': topcss });

        //document.getElementById('boldStuff').innerHTML = 'scr=' + scroll + ';ofs=' + pageOffsetFromTopOfTheScreen + ';winY=' + windowHeight + ';odlg=' + farFromTopOfTheScreen + ';odld=' + farFromBottomOfTheScreen + ';sub=' + subHeight;

        //Calculate width of all ul's
        (function($) {
            jQuery.fn.calcSubWidth = function() {

                //Calculate row

            };
        })(jQuery);
    }

    function megaHoverOut() {
        $(this).find(".sub").stop().fadeTo('fast', 0, function() {
            $(this).hide();
        });
    }


    var config = {
        sensitivity: 20, // number = sensitivity threshold (must be 1 or higher)    
        interval: 100, // number = milliseconds for onMouseOver polling interval    
        over: megaHoverOver, // function = onMouseOver callback (REQUIRED)    
        timeout: 100, // number = milliseconds delay before onMouseOut    
        out: megaHoverOut // function = onMouseOut callback (REQUIRED)    
    };

    $("ul#menuLeft li .sub").css({ 'opacity': '0' });
    $("ul#menuLeft li").hoverIntent(config);



});



