$(function () {
	var slideHeight = 84; // px
	var defHeight = $('div.productDescription').height();
	if (defHeight >= slideHeight) {
		$('div.productDescription').css('height', slideHeight + 'px');
		$('div.expandField').append("<div class=\"clearall\"></div><div style=\"float:left; width:800px; text-align:right;\"><span class=\"bullet-down-up\"></span></div>");
		$('span.bullet-down-up').click(function () {
			var curHeight = $('div.productDescription').height();
			if (curHeight == slideHeight) {
				$('div.productDescription').animate({
					height: defHeight
				}, "normal");
				$("span.bullet-down-up").css("background-image", "url('../../Content/Images/icon_bullet_up.jpg')");
			} else {
				$('div.productDescription').animate({
					height: slideHeight
				}, "normal");
				$("span.bullet-down-up").css("background-image", "url('../../Content/Images/icon_bullet_down.jpg')");
			}
		});
	}
});