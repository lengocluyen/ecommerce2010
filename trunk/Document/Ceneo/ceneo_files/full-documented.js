 var ceneoTools={ getWindowSize: function()
{
	var windowWidth = windowHeight =0;

  	if( typeof( window.innerWidth ) == 'number' )
	{
	    windowWidth = window.innerWidth;
	    windowHeight = window.innerHeight;
	}
	else if(document.documentElement && ( document.documentElement.clientWidth || document.documentElement.clientHeight ) )
	{
	    windowWidth = document.documentElement.clientWidth;
	    windowHeight = document.documentElement.clientHeight;
	}
	else if( document.body && ( document.body.clientWidth || document.body.clientHeight ) )
	{
   	    windowWidth = document.body.clientWidth;
	    windowHeight = document.body.clientHeight;
  	}


	return [windowWidth, windowHeight];
},
 getScroll: function()
{
	var sX = sY = 0;

	if (document.documentElement && document.documentElement.clientHeight)
	{
		sY = document.documentElement.scrollTop;
		sX = document.documentElement.scrollLeft;
	}
	else
	{
		sY = document.body.scrollTop;
		sX = document.body.scrollLeft;
	}

	return [sX,sY];
},
findPos:function(obj)
{
	var curleft = curtop = 0;
	if (obj.offsetParent)
	{
		curleft = obj.offsetLeft
		curtop = obj.offsetTop
		while (obj = obj.offsetParent)
		{
			curleft += obj.offsetLeft
			curtop += obj.offsetTop
		}
	}

	return [curleft,curtop];
},
popupWindow:function(fileUrl, winW, winH, winN, scrollB) {    
    var nn4 = (document.layers) ? true : false;
    var ie4 = (document.all) ? true : false;
    var dom = (document.createTextNode)? true : false;
	var winWidth = (winW)? winW : 740;
	var winHeight = (winH)? winH : 520;
	var winName = (winN)? winN : 'popupWin'
	var scrollBars = (scrollB)? scrollB : 'auto'
	if (nn4 || ie4 || dom) {
		if (screen.width < winWidth + 50) { winWidth = screen.width - 50; scrollbars = 'yes' }
		if (screen.height < winHeight + 100) { winHeight = screen.height - 100; scrollbars = 'yes' }
		posX = Math.round((screen.width - winWidth) / 2);
		posY = Math.round((screen.height - winHeight) / 2);
		posCode = (nn4)? "screenX="+posX+",screenY="+posY : "left="+posX+",top="+posY;
	} else {
		posCode = "";
	}
	var popupWin = window.open(fileUrl, winName,"menubar=no,toolbar=no,scrollbars=" + scrollBars + ",status=yes,resizable=yes,width=" + winWidth + ",height=" + winHeight + "," + posCode);
	if (popupWin) popupWin.focus();
}
};

/* Copyright © 2005-2008 Ceneo SA */

/* === VARIABLES === */

var ceneoBoxes = {
	ids: ['filters', 'history', 'links'],
	init: function()
	{
		forEach(ceneoBoxes.ids, function()
		{
			var x = document.getElementById('close-' + this);
			if(x)
			{
				x.style.display = 'block';
				if(cookie.get(this) == 'hide')
				{
					ceneoBoxes.hide(this);
				}
				forEach(x.getElementsByTagName('a'), function()
				{
					this.onclick = function()
					{
						ceneoBoxes.toogle(this.href.split('#box-')[1]);
						this.blur();
						return false;
					};
				});
			}
		});
	},
	toogle: function(id)
	{
		if(document.getElementById('box-' + id).style.display == 'none')
		{
			ceneoBoxes.show(id);
			cookie.del(id);
		}
		else
		{
			ceneoBoxes.hide(id);
			cookie.set(id, 'hide', 90);
		}
	},
	show: function(id)
	{
		var x = document.getElementById('close-' + id).getElementsByTagName('img')[0], y = document.getElementById('box-' + id);
		x.src = x.src.replace(/ico\-show\.gif/, 'ico-hide.gif');
		x.alt = 'ukryj';
		x.parentNode.parentNode.getElementsByTagName('a')[0].innerHTML = 'ukryj';
		y.style.display = 'block';
	},
	hide: function(id)
	{
		var x = document.getElementById('close-' + id).getElementsByTagName('img')[0], y = document.getElementById('box-' + id);
		x.src = x.src.replace(/ico\-hide\.gif/, 'ico-show.gif');
		x.alt = 'pokaż';
		x.parentNode.parentNode.getElementsByTagName('a')[0].innerHTML = 'pokaż';
		y.style.display = 'none';
	}
};

var ceneoFilters = {
    init: function() {
        var x = document.getElementById('form-body-filters');
        if (x) {
            forEach(x.getElementsByTagName('input'), function() {
                if (this.type == 'text') {
                    if (hasInSpaceSeparated('number', this.className)) {
                        this.onfocus = function() {
                            //ceneoFilters.toogle('none');
                            if ((hasInSpaceSeparated('half-1', this.className) && (this.value == '- od -')) || (hasInSpaceSeparated('half-2', this.className) && (this.value == '- do -'))) {
                                this.value = '';
                            }
                            this.style.color = '#000';
                        };
                        this.onblur = function() {
                            if (this.value === '') {
                                this.value = hasInSpaceSeparated('half-1', this.className) ? '- od -' : '- do -';
                                this.style.color = '';
                            }
                            else {
                                this.style.color = /^[\d]*((,|\.)[\d]+)?$/.test(this.value) ? '#000' : 'red';
                            }
                        };
                    }
                    else if (hasInSpaceSeparated('string', this.className)) {
                        this.onfocus = function() {
                            ceneoFilters.toogle('none');
                            if (this.value == '- wpisz -') {
                                this.value = '';
                            }
                            this.style.color = '#000';
                            this.style.textAlign = 'left';
                        };
                        this.onblur = function() {
                            if (this.value === '') {
                                this.value = '- wpisz -';
                                this.style.color = '';
                                this.style.textAlign = '';
                            }
                            else {
                                this.style.color = /^[a-zA-Z0-9_ ]*$/.test(this.value) ? '#000' : 'red';
                            }
                        };
                    }
                }
            });
            forEach(x.getElementsByTagName('div'), function() {
                if (hasInSpaceSeparated('filter', this.className)) {
                    forEach(this.getElementsByTagName('a'), function() {
                        if (this.parentNode && this.parentNode.tagName.toLowerCase() == 'label') {
                            this.onclick = function() {
                                this.blur();
                                this.parentNode.parentNode.getElementsByTagName('input')[0].checked = true;
                                var elements = this.parentNode.parentNode.parentNode.parentNode.parentNode.getElementsByTagName('button');
                                if (elements.length > 0)
                                    elements[0].onclick();
                                //zmiana false na true, klikniecie w linka na divie powoduje przeladowanie strony
                                return true;
                            };
                        }
                    });
                }
            });
            forEach(x.getElementsByTagName('a'), function() {
                if (this.parentNode && this.parentNode.tagName.toLowerCase() == 'p') {
                    this.style.display = 'block';
                }
            });
            forEach(x.getElementsByTagName('select'), function() {
                if (hasInSpaceSeparated('multiple', this.className)) {
                    this.multiple = true;
                }

                if (!hasInSpaceSeparated('donthide', this.className)) {
                    this.style.display = 'none';

                    this.parentNode.getElementsByTagName('label')[0].onclick = function() {
                        ceneoFilters.toogle(this.parentNode.getElementsByTagName('select')[0].id);
                        return false;
                    };
                }


            });
        }
        if (document.getElementById('filters-choosen')) {
            ceneoBoxes.hide('filters');
            forEach(document.getElementById('close-filters').getElementsByTagName('a'), function() {
                this.onclick = function() {
                    ceneoBoxes.toogle(this.href.split('#box-')[1]);
                    document.getElementById('filters-choosen').style.display = 'none';
                    this.blur();
                    return false;
                };
            });
        }
    },
    onKeyCheck: function(e) {
        e = e || window.event;
        if (e.keyCode == 27) {
            ceneoFilters.toogle('none');
        }
    },
    toogle: function(x) {
        document.onkeydown = null;
        forEach(document.getElementById('form-body-filters').getElementsByTagName('div'), function() {
            if (hasInSpaceSeparated('filter', this.className)) {
                var id = this.id.replace(/js\-tip\-/, ''), y = document.getElementById(this.id), z = 0;
                if (id == x && y.style.display != 'block') {
                    z = 1;
                    document.onkeydown = ceneoFilters.onKeyCheck;
                }
                if (!isIE6) {
                    document.getElementById(id).parentNode.getElementsByTagName('label')[0].style.fontWeight = z ? 'bold' : 'normal';
                }
                document.getElementById('js-val-' + id).className = z ? 'filter-active' : (document.getElementById('js-val-' + id).innerHTML == '- wybierz -' ? 'filter' : 'filter-choosen');
                y.style.display = z ? 'block' : 'none';


                $(y).find("div.values div").height("auto");
                $(y).find("div.values div").css("overflow", "hidden");
                
                if ($(y).height() > $(document).height()) {
                    $(y).find("div.values div").height($(document).height() - 500);
                    $(y).find("div.values div").css("overflow-y", "scroll");
                }
            }
        });
        return false;
    },
    apply: function(x) {
        var txt = [], val = '', y = document.getElementById('js-val-' + x); y.innerHtml = "";
        forEach(document.getElementById(x).getElementsByTagName('option'), function() {
            this.selected = false;
        });
        forEach(document.getElementById('js-tip-' + x).getElementsByTagName('input'), function() {
            if (this.id && this.checked && this.type != "text") {
                var z = document.getElementById(this.id.replace(/js\-/, ''));
                txt.push(z.text.trim());
                z.selected = true;
            }
        });
        forEach(document.getElementById('js-tip-' + x).getElementsByTagName('option'), function() {
            if (this.id && this.selected) {
                var z = document.getElementById(this.id.replace(/js\-/, ''));
                txt.push(z.text.trim());
                z.selected = true;
            }
        });
        forEach(document.getElementById('js-tip-' + x).getElementsByTagName('input'), function() {
            if (this.id && this.type == "text") {
                if (this.name == "price-min" && this.value == "- od -") { return; }
                if (this.name == "price-max" && this.value == "- do -") { return; }
                var z = document.getElementById(this.id.replace(/js\-/, ''));
                z.text = this.value;
                z.value = this.value;
                z.selected = true;
                var prefix = "";
                if (this.name == "price-min" && this.value != "- od -") {
                    prefix += "od ";
                }
                if (this.name == "price-max" && this.value != "- do -") {
                    prefix += "do ";
                }
                txt.push(prefix + z.text.trim());
            }
        });
        if (txt.length === 0) {
            y.title = '';
            y.innerHTML = '- wybierz -';
            y.style.color = '';
        }
        else {
            forEach(txt, function() {
                if (val.length < 8) {
                    if (val.length !== 0) {
                        val += ', ';
                    }
                    val += this;
                }
            });
            if (val.length > 12) {
                val = val.substring(0, 10).trim() + '...';
            }
            else if (val.length != txt.join(', ').length) {
                if (val.length > 10) {
                    val = val.substring(0, 10).trim();
                }
                val += '...';
            }
            y.title = txt.join(', ');
            y.innerHTML = val;
            y.style.color = '#000';
        }
        return ceneoFilters.toogle(x);
    },
    erase: function(x) {
        var y = document.getElementById('js-val-' + x);
        forEach(document.getElementById(x).getElementsByTagName('option'), function() {
            this.selected = false;
        });
        y.title = '';
        y.innerHTML = '- wybierz -';
        y.style.color = '';
        return ceneoFilters.toogle(x);
    }
};

var ceneoFiltersAlt = {
	link: {
	hide: '<a href="javascript:void(0);" onclick="return ceneoFiltersAlt.hide(this.parentNode);"><img src="common/image/icon/hide.gif" alt="mniej" /></a> <a href="javascript:void(0);" onclick="return ceneoFiltersAlt.hide(this.parentNode);">mniej</a>',
		show: '<a href="javascript:void(0);" onclick="return ceneoFiltersAlt.show(this.parentNode);"><img src="common/image/icon/show.gif" alt="więcej" /></a> <a href="javascript:void(0);" onclick="return ceneoFiltersAlt.show(this.parentNode);">więcej</a>'
	},
	init: function()
	{
		var x = document.getElementById('form-body-filters-alt');
		if(x)
		{
			forEach(x.getElementsByTagName('input'), function()
			{
				if(this.type == 'text')
				{
					if(hasInSpaceSeparated('number', this.className))
					{
						this.onfocus = function()
						{
							//ceneoFilters.toogle('none');
							if((hasInSpaceSeparated('half-1', this.className) && (this.value == '- od -')) || (hasInSpaceSeparated('half-2', this.className) && (this.value == '- do -')))
							{
								this.value = '';
							}
							this.style.color = '#000';
						};
						this.onblur = function()
						{
							if(this.value === '')
							{
								this.value = hasInSpaceSeparated('half-1', this.className) ? '- od -' : '- do -';
								this.style.color = '';
							}
							else
							{
								this.style.color = /^[\d]*((,|\.)[\d]+)?$/.test(this.value) ? '#000' : 'red';
							}
						};
					}
					else if(hasInSpaceSeparated('string', this.className))
					{
						this.onfocus = function()
						{
							//ceneoFilters.toogle('none');
							if(this.value == '- wpisz -')
							{
								this.value = '';
							}
							this.style.color = '#000';
							this.style.textAlign = 'left';
						};
						this.onblur = function()
						{
							if(this.value === '')
							{
								this.value = '- wpisz -';
								this.style.color = '';
								this.style.textAlign = '';
							}
							else
							{
								this.style.color = /^[a-zA-Z0-9_ ]*$/.test(this.value) ? '#000' : 'red';
							}
						};
					}
				}				
			});
			forEach(x.getElementsByTagName('div'), function()
			{
				var count = 0;
				forEach(this.getElementsByTagName('label'), function()
				{
					if(hasInSpaceSeparated('hide', this.className))
					{
						count++;
					}
				});
				if(count)
				{
					var moreLink = '<p class="manage">' + ceneoFiltersAlt.link.show + '</p>';
					
					var moreLinkPlaceholder = $('span', this);
					if(moreLinkPlaceholder.length && moreLinkPlaceholder.hasClass('moreLinkPlaceholder'))
					{
					    moreLinkPlaceholder.before(moreLink).remove();
					}					
                    else 
                    {
                        this.innerHTML = this.innerHTML + moreLink;
                    }
				}
			});
			
			$('#form-body-filters-alt').find('input[type=checkbox]').click(function()
			{
			    var checked = $(this).attr('checked');
			    $('#form-body-filters-alt').find('input[id=' + this.id + ']').each(function()
			    {
			        $(this).attr('checked', checked);
			    });
			});			    
		}
	},
	show: function(x)
	{
		x.innerHTML = ceneoFiltersAlt.link.hide;
		forEach(x.parentNode.getElementsByTagName('label'), function()
		{
			if(hasInSpaceSeparated('hide', this.className))
			{
				this.style.display = 'block';
			}
			if(hasInSpaceSeparated('forcehide', this.className))
			{
				this.style.display = 'none';
			}
		});
		return false;
	},
	hide: function(x)
	{
		x.innerHTML = ceneoFiltersAlt.link.show;
		forEach(x.parentNode.getElementsByTagName('label'), function()
		{
			if(hasInSpaceSeparated('hide', this.className))
			{
				this.style.display = '';
			}
			if(hasInSpaceSeparated('forcehide', this.className))
			{
				this.style.display = '';
			}
		});
		return false;
	}
};

var ceneoGmap = {
	area: null,
	gmap: null,
	icon: null,
	current: 0,
	types: [
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 18.680191, 'Y': 54.404145, 'ZoomLevel': 11},
		{'X': 19.057159, 'Y': 50.321792, 'ZoomLevel': 11},
		{'X': 19.978638, 'Y': 50.121899, 'ZoomLevel': 11},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6},
		{'X': 19.145136, 'Y': 51.919438, 'ZoomLevel': 6}
	],
	markers: [],
	init: function()
	{
		var x = new Image(), y = new Image();
		if(ceneoGmap.area)
		{
			if(typeof GBrowserIsCompatible != 'function')
			{
				ceneoGmap.area.innerHTML = [
					'<div class="gmap-msg">',
						'<div class="warning-msg">',
							'<h3>Mapy sklepów nie mogą zostać wyświetlone</h3>',
							'<p>Mapy sklepów korzystają z zewnętrznych serwerów, co sprawia, że od czasu do czasu niestety mogą być niedostępne.</p>',
							'<p>Spróbuj ponownie za kilka minut. Przepraszamy za niedogodności.</p>',
						'</div>',
					'</div>'
				].join('');
			}
			else if(!GBrowserIsCompatible())
			{
				ceneoGmap.area.innerHTML = [
					'<div class="gmap-msg">',
						'<div class="warning-msg">',
							'<h3>Mapy sklepów nie mogą zostać wyświetlone</h3>',
							'<p>Mapy sklepów korzystają z najnowszych technologii internetowych, których Twoja przeglądarka nie obsługuje.</p>',
							'<p>Aby wyświetlić mapy sklepów, zaktualizuj przeglądarkę do najnowszej wersji, a następnie spróbuj ponownie.</p>',
						'</div>',
					'</div>'
				].join('');
			}
			else
			{
				x.src = 'common/image/icon/gmap-icon.gif';
				y.src = 'common/image/icon/gmap-shadow.png';
				window.onunload = GUnload;
				forEach([G_NORMAL_MAP, G_HYBRID_MAP], function()
				{
					this.getMinimumResolution = function()
					{
						return 3;
					};
					this.getMaximumResolution = function()
					{
						return 17;
					};
				});
				G_NORMAL_MAP.getName = function()
				{
					return 'Mapa ulic';
				};
				G_HYBRID_MAP.getName = function()
				{
					return 'Satelitarna';
				};
				ceneoGmap.gmap = new GMap2(ceneoGmap.area);
				ceneoGmap.gmap.removeMapType(G_SATELLITE_MAP);
				ceneoGmap.gmap.setCenter(new GLatLng(ceneoGmap.types[ceneoGmap.current].Y, ceneoGmap.types[ceneoGmap.current].X), ceneoGmap.types[ceneoGmap.current].ZoomLevel);
				ceneoGmap.gmap.addControl(new GLargeMapControl());
				ceneoGmap.gmap.addControl(new GMapTypeControl());
				ceneoGmap.icon = new GIcon();
				ceneoGmap.icon.image = x.src;
				ceneoGmap.icon.shadow = y.src;
				ceneoGmap.icon.iconSize = new GSize(27, 24);
				ceneoGmap.icon.shadowSize = new GSize(40, 24);
				ceneoGmap.icon.iconAnchor = new GPoint(14, 24);
				forEach(ceneoGmap.markers, function()
				{
					ceneoGmap.addMarker(this);
				});
				if((x = document.getElementById('form-body-geo')))
				{
					x.onsubmit = function()
					{
						ceneoGmap.current = parseInt(document.getElementById('form-body-geo-map').value, 10);
						ceneoGmap.gmap.setCenter(new GLatLng(ceneoGmap.types[ceneoGmap.current].Y, ceneoGmap.types[ceneoGmap.current].X), ceneoGmap.types[ceneoGmap.current].ZoomLevel);
						this.getElementsByTagName('select')[0].blur();
						this.getElementsByTagName('button')[0].blur();
						return false;
					};
				}
			}
		}
	},
	setArea: function(el)
	{
		el = document.getElementById(el);
		el.innerHTML = '';
		ceneoGmap.area = el;
	},
	prepareHtml: function(obj)
	{
		return [
			'<div style="width: 270px;">',
				'<p><a href="' + obj.link + '" rel="external nofollow"><img src="' + obj.logoSrc + '" alt="' + obj.logoAlt + '" height="40" /></a></p>',
				'<p style="width: 132px; float: left;">' + obj.address + '<br />(<a href="javascript:void(0);" onclick="return ceneoGmap.zoomIn(this);">przybliż mapę</a>)</p>',
				'<p style="width: 132px; float: right;">' + (obj.phone ? '<img src="common/image/icon/phone.gif" alt="telefon" /> ' + obj.phone + '<br />' : '') + (obj.hours ? '<strong>Godziny otwarcia:</strong><br />' + obj.hours : '') + '</p>',
				'<p style="padding: 7px 0 2px; clear: both; overflow: hidden;">' + (obj.productName ? 'Produkt: ' + obj.productName + '</p><p>Cena: <strong>' + obj.productPrice + '</strong> zł' + (obj.productPriceTotal ? ', z dostawą: od <big>' + obj.productPriceTotal + '</big> zł' : '') + '<br />' : '') + '<br /><a target="_blank" href="' + obj.link + '" class="buy" onmousedown=\'' + obj.onmousedownEventCode + '\'><span>Idź do sklepu &raquo;</span></a></p>',
			'</div>'
		].join('');
	},
	addMarker: function(point)
	{
		var marker = new GMarker(new GLatLng(point.Y, point.X), {title: point.Title, icon: ceneoGmap.icon});
		GEvent.addListener(marker, 'click', function()
		{
			ceneoGmap.gmap.openInfoWindowHtml(new GLatLng(point.Y, point.X), ceneoGmap.prepareHtml(point.Html));
		});
		ceneoGmap.gmap.addOverlay(marker);
	},
	zoomIn: function(x)
	{
		ceneoGmap.gmap.setZoom(15);
		x.blur();
		x.innerHTML = 'oddal mapę';
		x.onclick = function()
		{
			return ceneoGmap.zoomOut(this);
		};
		return false;
	},
	zoomOut: function(x)
	{
		ceneoGmap.gmap.setZoom(ceneoGmap.types[ceneoGmap.current].ZoomLevel);
		x.blur();
		x.innerHTML = 'przybliż mapę';
		x.onclick = function()
		{
			return ceneoGmap.zoomIn(this);
		};
		return false;
	}
};

var changeLitePopup = {
    popupcode: '',
    links_c: null,
    popup: null,
    toggle: function(productID) {
        with (this) {
            popup.style.display = popup.style.display == 'none' ? 'block' : 'none';
        }
        $('#form-body-changes-productID').val(productID);
    },
    init: function() {
        with (this) {
            if (!(links_c = document.getElementById('changes-in-price'))) return;
            popup = document.createElement('div');
            popup.style.display = 'none';
            popup.id = 'form-body-changes-div';
            popup.innerHTML = popupcode;
            document.getElementById('changes-popup').appendChild(popup);
            //    	forEach(links_c.getElementsByTagName('a'),function(){
            //      		this.onclick=function(){changeLitePopup.toggle(); return false;};
            //    	});

        }
    },
    closePopup: function() {
        document.getElementById('form-body-changes-div').style.display = 'none';
    }

};
/*
var problemLitePopup={
  popupcode: '',
  links_c: null,
  popup: null,
  toggle: function(){  with(this){
    popup.style.display= popup.style.display=='none' ? 'block' : 'none';
  }},
   closePopup: function(){
		document.getElementById('form-body-problem-div').style.display='none';
	},
  init: function(){ with(this){
		if( ! (links_c = document.getElementById('zglos') ) ) return ;
		
		popup = document.createElement('div');
		popup.style.display='none';
		popup.id = 'form-body-problem-div';
		popup.innerHTML=popupcode;
    	document.getElementById('problem-popup').appendChild(popup);
    	forEach(links_c.getElementsByTagName('a'),function(){
      		this.onclick=function(){problemLitePopup.toggle(); return false;};
    	});

  } }

};
*/
var categoryChangesLitePopup = {
    borderColor: '',
    popupcode: '',
    links_c: null,
    popup: null,
    toggle: function() {
        with (this) {
            if (popupcode == '') {
                $.get("categoryChanges/form", function(data, textStatus) { popupcode = data; popup.innerHTML = popupcode; }, "html");
            }
            popup.style.display = popup.style.display == 'none' ? 'block' : 'none';
        }
    },
    closePopup: function() {
        document.getElementById('form-body-cat-changes-div').style.display = 'none';
    },
    init: function() {
        with (this) {
            if (!(links_c = document.getElementById('category-changes'))) return;
            popup = document.createElement('div');
            popup.style.display = 'none';
            popup.id = 'form-body-cat-changes-div';
            document.getElementById('category-change-popup').appendChild(popup);
            forEach(links_c.getElementsByTagName('a'), function() {
                this.onclick = function() { categoryChangesLitePopup.toggle(); return false; };
            });
        }
    },
    send: function() {
        var messageInput = $("#form-body-problem-msg")[0];
        var emailInput = $("#form-body-problem-email")[0];
        if (messageInput.value != undefined && messageInput.value.length > 0) {
            $.post("requestCategoryChange", { msg: messageInput.value, email: emailInput.value });
            messageInput.style.borderColor = categoryChangesLitePopup.borderColor;
            categoryChangesLitePopup.closePopup();
            modalPopup.displayModal($("#modal-window-content")[0].innerHTML);
            $("#form-body-problem-msg").val("");
            $("#form-body-problem-email").val("");
        } else {
            borderColor = messageInput.style.borderColor;
            messageInput.style.borderColor = 'red';
        }
        return false;
    }
};

var modalPopup={
    overlay : $("<div id='modal-overlay'></div>"),
    modalWindow : $("<div id='modal-window'></div>"),
    displayModal: function(text) {
                 
                if (typeof document.body.style.maxHeight === "undefined") { //IE 6 
                    $("body", "html").css({ height: "100%", width: "100%" });
                    $("html").css("overflow", "hidden");
                }
                
                $("body").append(modalPopup.overlay.click(function() { modalPopup.modalHide(); }))
                modalPopup.overlay.fadeIn(0);
                $(document).keydown(modalPopup.handleEscape);
                //$("modalWindow").css({ "left": "500px" });
                modalPopup.modalWindow.css({
                    "margin-left": -270,
                    "margin-top": -100
                });
                modalPopup.modalWindow.append(text);
                $("body").append(modalPopup.modalWindow);
                $("#modal-window img").click(function() { modalPopup.modalHide(); });
                modalPopup.modalWindow.fadeIn(0);
            },
    modalHide: function() {
            $(document).unbind("keydown", modalPopup.handleEscape)
            var remove = function() { $(this).remove(); };
            modalPopup.overlay.fadeOut(remove);
            modalPopup.modalWindow
				        .hide()
				        .empty();
        },

    handleEscape: function(e) {
            if (e.keyCode == 27) {
                modalPopup.modalHide();
            }
        }  
    
}

var problemLitePopup = {
	popupcode: '',
	showPopup: function(el, accountID, dontShowEmail)
	{
		var param;
		var classname = new String(el.className);
		var params = new Array(0);
		params = classname.split(" ");

		var shop = 0; var product = 0;

		var l = params.length;

		for (var i = 0; i < l; i++)
		{
			if (params[i].length < 6) continue;
			param = params[i].substring(0, 4);
			if (param == 'shop') shop = params[i].substr(5);
			else if (param == 'prod') product = params[i].substr(5);
		}

		pos = ceneoTools.findPos(el); x = pos[0]; y = pos[1];

		document.getElementById('problem-email').style.display = (dontShowEmail) ? 'none' : '';

		popup = document.getElementById('form-body-problem-div');

		var left = x - 305; //window.screen.width/2 - 100;//x+305;
		var top = y; //100;

		//popup.style.display='hidden';

		//document.getElementById('form-body-problem-msg').value='';
		//document.getElementById('form-body-problem-email').value='';
		//document.getElementById('form-body-changes-captcha').value='';
		document.getElementById('form-body-problem-shop').value = accountID;
		//document.getElementById('form-body-problem-product').value=product;
		popup.style.left = left + 'px';
		popup.style.top = top + 'px';
		popup.style.display = 'block';
	},
	closePopup: function()
	{
		document.getElementById('form-body-problem-div').style.display = 'none';
	},
	init: function()
	{
		with (this)
		{
			if (popupcode.length < 1) return;

			var ps = document.getElementById('product-tab').getElementsByTagName('p');
			var i; l = ps.length; var p; var arr;
			if (!l) return;


			popup = document.createElement('div');
			popup.style.display = 'none';
			popup.id = 'form-body-problem-div';
			popup.innerHTML = popupcode;
			document.getElementsByTagName('body')[0].appendChild(popup);

			for (i = 0; i < l; i++)
			{
				p = ps[i];

				if (!p.attributes.rel || p.attributes.rel.value != 'zglos') continue;



				arr = p.getElementsByTagName('a'); if (!arr[0]) continue;
				//arr[0].onclick= problemLitePopup_showPopup; //- mk
			}




		}
	}
};
function problemLitePopup_showPopup(element, accountID, dontShowEmail) { problemLitePopup.showPopup(element, accountID, dontShowEmail); return false; }


var ceneoPopups = {
	changes: null,
	compare: null,
	gallery: null
};

var ceneoPreview = {
	el: {},
	images: {},
	last_elem: false,
	init: function()
	{ceneoPreview
		ceneoPreview.el = {
			div: document.getElementById('js-preview'),
			img: document.getElementById('js-preview-image')
		};
		if(ceneoPreview.el.div)
		{
			forEach(document.getElementsByTagName('a'), function()
			{
				if(hasInSpaceSeparated('preview', this.rel))
				{
					this.onmouseover = function()
					{
						var x = ' ' + this.rel + ' ';
						ceneoPreview.last_elem=this;
						ceneoPreview.show((x.match(/\s+image\-\d+\s+/) + ' ').trim());
					};
					this.onmouseout = function()
					{
						ceneoPreview.hide();
					};
				}
			});
		}
	},


	show: function(img)
	{
		ceneoPreview.el.img.src = 'common/image/icon/loading.gif';
		var x = new Image();
		/*x.onload = function()
		{			
						
		};*/
		x.src = ceneoPreview.images[img];
		ceneoPreview.el.img.src = x.src;
		ceneoPreview.el.div.style.display = 'block';
			ceneoPreview.move(ceneoPreview.last_event,ceneoPreview.last_elem);		
	},
	hide: function()
	{
		ceneoPreview.el.div.style.display = 'none';		
	},
	
	move: function(e,elem)
	{
		wsize = ceneoTools.getWindowSize(); 
		wscroll = ceneoTools.getScroll();
		epos=ceneoTools.findPos(elem);		
  		w_w = wsize[0]; w_h=wsize[1]; 
  		w_x=wscroll[0]; w_y=wscroll[1];
  		e_x=epos[0]; e_y=epos[1];
  		
  		
  		e_w=elem.clientWidth; e_h=elem.clientHeight*0.5;
  		
  		el_h = ceneoPreview.el.div.clientHeight;  el_w = ceneoPreview.el.div.clientWidth ;
  		
  		m_left = e_x + e_w; 
  		m_top = e_y + e_h ;
  		
  		
  		
   		if( m_left + el_w >= w_w + w_x ){ m_left = e_x - el_w ; }
   		if( m_top + el_h >=w_h + w_y ) m_top = e_y - el_h ;
  		
  		ceneoPreview.el.div.style.top =  m_top + 'px';
		ceneoPreview.el.div.style.left =  m_left + 'px';
  		
	}
};

$(document).ready(function() {

    if ($('#product-desc-uni-inner').height() > 120) {
        $("#product-desc-more-control").show();
        $('#product-desc-uni').animate({ height: "50px" }, 400);

        $("#product-desc-more-control").click(function() {
            $("#product-desc-more-control").hide();
            $(".product-desc-less-control").show();
            $('#product-desc-uni').animate({ height: ($('#product-desc-uni-inner').height()+20) + "px" }, 400);
        });

        $(".product-desc-less-control").click(function() {
            $(".product-desc-less-control").hide();
            $("#product-desc-more-control").show();
            $('#product-desc-uni').animate({ height: "50px" }, 400);
            $('html,body').animate({scrollTop: 0}, 400);
            $('html,body').animate({scrollTop: 0}, 400);
        });
    }
    else {
        $('#product-desc-uni').animate({ height: ($('#product-desc-uni-inner').height()) + "px" }, 400);
    }

});

var ceneoRecommend = {
	box: null,
	current: 0,
	init: function()
	{
		var x = document.getElementById('products-recommended-control');
		if(x)
		{
			forEach(x.getElementsByTagName('a'), function()
			{
				this.onclick = function()
				{
					ceneoRecommend.next();
					this.blur();
					return false;
				};
			});
			ceneoRecommend.box = document.getElementById('products-recommended');
			ceneoRecommend.box.onmouseout = function()
			{
				ceneoRecommend.timer = window.setInterval(ceneoRecommend.next, 2000);
			};
			ceneoRecommend.box.onmouseover = function()
			{
				window.clearInterval(ceneoRecommend.timer);
				ceneoRecommend.timer = null;
			};
			ceneoRecommend.timer = window.setInterval(ceneoRecommend.next, 2000);
		}
	},
	next: function()
	{
		var x = ceneoRecommend.box.getElementsByTagName('li');
		x[ceneoRecommend.current].className = 'hide';
		if(ceneoRecommend.current >= x.length - 1)
		{
			ceneoRecommend.current = 0;
		}
		else
		{
			ceneoRecommend.current++;
		}
		x[ceneoRecommend.current].className = 'show';
	},
	timer: null
};

var ceneoShipping = {
	offers: {},
	current: null,
	init: function()
	{
		forEach(document.getElementsByTagName('a'), function()
		{
			if(hasInSpaceSeparated('shipping', this.rel))
			{
				this.onclick = function()
				{
				    x = ' ' + this.rel + ' ', y = (x.match(/\s+shop\-\d+\s+/) + ' ').trim();
				    if(this.parsed)
				    {  
				        return ceneoShipping.toogle(this.tipid, this.id);
				    }
				    var link = this;
				    $.getJSON("ShopDeliveryInfo/" + y.replace('shop-',''),
                    function(offer)
                    {  
                        if(!link.parsed)
					    {
						    var html = '', x = ' ' + offer.rel + ' ', y = (x.match(/\s+shop\-\d+\s+/) + ' ').trim();
						    link.tipid = y + '-' + new Date().getTime() + '-' + Math.floor(Math.random() * 101);
						    html += [
							    '<div class="jstip" id="js-tip-' + link.tipid + '" style="top: -19px; left: -83px;">',
								    '<div>',
									    '<p><a href="javascript:void(0);" title="Zamknij" class="close" onclick="return ceneoShipping.toogle(\'' + link.tipid + '\', \'' + link.id + '\');">Zamknij</a></p>',
									    '<big>Szczegóły dostawy w sklepie <a href="' + offer.link + '">' + offer.name + '</a></big>',
									    '<table style="margin: 6px 9px !important; width: 335px !important;" class="stripeMe">' 
						    ].join('');
						    if(!offer.data)
						    {
							    offer.data = [{
								    keys: offer.keys,
								    vals: offer.vals
							    }];
						    }
						    forEach(offer.data, function()
						    {
							    x = this.keys.length;
							    if(this.head)
							    {
    								
							    }
							    html +='<tr><th class="l">' + this.keys.join('</th><th class="l">') + '</th>';
							    forEach(this.vals, function()
							    {
								    html += '<td>' + this.label + ((this.value === null) ? '<strong>Gratis!</strong></td>' : '<strong>' + this.value.join('</strong> </td><strong>') + '</strong> </td>') + '</tr>';
							    });
    							
						    });
						    if(offer.note)
						    {
							    html += '<small style="margin: 3px 9px !important;">' + offer.note + '</small>';
						    }
						    html += [
								    '</table>',
								    '</div>',
							    '</div>'
						    ].join('');
						    y = link.parentNode.parentNode.getElementsByTagName('div')[0];
						    y.className = 'jstipparent';
						    y.innerHTML = html;
						    link.parsed = 1;
					    }
					    return ceneoShipping.toogle(link.tipid, link.id);
                    });
				};
			}
		});
	},
	toogle: function(x, y)
	{
		x = document.getElementById('js-tip-' + x);
		if(x.style.display != 'block')
		{
			if(ceneoShipping.current)
			{
				ceneoShipping.current.parentNode.parentNode.getElementsByTagName('a')[0].style.fontWeight = '';
				ceneoShipping.current.style.display = 'none';
			}
			ceneoShipping.current = x;
			ceneoShipping.current.style.display = 'block';
			ceneoShipping.current.parentNode.parentNode.getElementsByTagName('a')[0].style.fontWeight = 'bold';
			document.onkeydown = ceneoShipping.onKeyCheck;
		}
		else
		{
			document.onkeydown = null;
			ceneoShipping.current.parentNode.parentNode.getElementsByTagName('a')[0].style.fontWeight = '';
			ceneoShipping.current.style.display = 'none';
			ceneoShipping.current = null;
		}
		document.getElementById(y).blur();
		return false;
	},
	onKeyCheck: function(e)
	{
		e = e || window.event;
		if(e.keyCode == 27)
		{
			ceneoShipping.toogle(ceneoShipping.current.id.split('-tip-')[1], null);
		}
	}
};

var ceneoShowcase = {
    current: $('.show').attr('id') == null ? 1 : $('.show').attr('id').split('showcase-content-')[1],
	el: {},
	interval: null,
	init: function()
	{
		var x = document.getElementById('showcase');
		if(x)
		{
			x.onmouseover = function()
			{
				window.clearInterval(ceneoShowcase.interval);
				ceneoShowcase.interval = null;
			};
			x.onmouseout = function()
			{
				ceneoShowcase.interval = window.setInterval(ceneoShowcase.change, 7000);
			};
			ceneoShowcase.interval = window.setInterval(ceneoShowcase.change, 7000);
			ceneoShowcase.el = {
				content: document.getElementById('showcase-content'),
				controls: document.getElementById('showcase-controls')
			};
			forEach(ceneoShowcase.el.controls.getElementsByTagName('a'), function()
			{
				this.onclick = function()
				{
					ceneoShowcase.change(this);
					return false;
				};
			});
		}
	},
	change: function(el)
	{
		document.getElementById('showcase-control-' + ceneoShowcase.current).className = '';
		document.getElementById('showcase-content-' + ceneoShowcase.current).className = 'hide';
		if(el && el.href)
		{
			el.blur();
			ceneoShowcase.current = el.href.split('#showcase-content-')[1];
		}
		else
		{
			ceneoShowcase.current++;
			if(!document.getElementById('showcase-content-' + ceneoShowcase.current) || !document.getElementById('showcase-content-' + ceneoShowcase.current).tagName)
			{
				ceneoShowcase.current = 1;
			}
		}
		document.getElementById('showcase-control-' + ceneoShowcase.current).className = 'current';
		document.getElementById('showcase-content-' + ceneoShowcase.current).className = 'show';
	}
};

var ceneoStars = {
	init: function()
	{
		var x = document.getElementById('form_body_opinion');
		if(x)
		{
			forEach(x.getElementsByTagName('select'), function()
			{
				var html = '<ul class="rating" onmouseover="this.className = \'rating rating-active\';" onmouseout="this.className = \'rating rating-inactive\';">';
				forEach(this.getElementsByTagName('option'), function()
				{
					html += '<li class="star-' + this.value + '"><a href="javascript:void(0);" title="' + this.text + '" onclick="return ceneoStars.select(this, ' + this.value + ');">' + this.text + '</a></li>';
				});
				html += '</ul>';
				this.style.display = 'none';
				this.parentNode.getElementsByTagName('label')[0].style.cursor = 'text';
				this.parentNode.innerHTML += html;
			});
		}
	},
	select: function(el, val)
	{
		var x = el.parentNode.parentNode;
		forEach(x.getElementsByTagName('a'), function()
		{
			this.className = '';
		});
		x.className = 'rating rating-inactive';
		el.className = 'selected';
		forEach(x.parentNode.getElementsByTagName('select')[0].getElementsByTagName('option'), function()
		{
			this.selected = (this.value == val);
		});
		el.blur();
		return false;
	}
};

/* === FUNCTIONS === */

function ceneoEnv()
{
	if(arguments.callee.done)
	{
		return;
	}
	arguments.callee.done = 1;
	ceneoBoxes.init();
	ceneoFilters.init();
	ceneoFiltersAlt.init();
	ceneoGallery.init(3);
	ceneoGmap.init();
	ceneoPreview.init();
	ceneoRecommend.init();
	ceneoShipping.init();
	ceneoShowcase.init();
	ceneoStars.init();
	problemLitePopup.init();
	categoryChangesLitePopup.init();

	forEach(document.getElementsByTagName('a'), function() {
	    if (hasInSpaceSeparated('external', this.rel)) {
	        this.target = '_blank';
	    }
	    if (hasInSpaceSeparated('gallery', this.rel)) {
	        //			this.onclick = function()
	        //			{
	        //				if(ceneoPopups.gallery !== null && !ceneoPopups.gallery.closed)
	        //				{
	        //					ceneoPopups.gallery.close();
	        //				}
	        //				this.blur();
	        //				this.href = '.?page=gallery'; // temp
	        //				ceneoPopups.gallery = window.open(this.href + ((this.href.indexOf('?') != -1) ? '&' : '?') + 'type=lite', 'ceneoPopupsGallery', 'width=637,height=450,resizable=0,scrollbars=1');
	        //				ceneoPopups.gallery.focus();
	        //				return false;
	        //			};
	    }
	});
	//check compare
	var x = document.getElementById('form-body-compare');
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
	            alert('Porównywane produkty muszą należeć do tej samej kategorii');
	            return false;
	        }

	        document.getElementById('form-body-compare-categoryId').value = categoryId;

	        //			else
	        //			{
	        //				if(ceneoPopups.compare !== null && !ceneoPopups.compare.closed)
	        //				{
	        //					ceneoPopups.compare.close();
	        //				}
	        //				var handle = 'ceneoPopupsCompare' + new Date().getTime();
	        //				this.target = handle;
	        //				ceneoPopups.compare = window.open('about:blank', handle, 'width=' + (20 + 190 + 178 * count) + ',height=450,resizable=0,scrollbars=1');
	        //				ceneoPopups.compare.focus();
	        //				if(window.opera && !ceneoPopups.opera)
	        //				{
	        //					this.action = this.action.substring(0, this.action.length-10);
	        //					this.target = '';
	        //				}
	        //				return true;
	        //			}
	    };
	}
	//end compare
	changeLitePopup.init();
	/*
	if((x = document.getElementById('changes-in-price')))
	{
		forEach(x.getElementsByTagName('a'), function()
		{
			this.onclick = function()
			{
				if(ceneoPopups.changes !== null && !ceneoPopups.changes.closed)
				{
					ceneoPopups.changes.close();
				}
				this.blur();
				this.href = '.?page=changes'; // temp
				ceneoPopups.changes = window.open(this.href + ((this.href.indexOf('?') != -1) ? '&' : '?') + 'type=lite', 'ceneoPopupsChanges', 'width=637,height=337,resizable=0,scrollbars=1');
				ceneoPopups.changes.focus();
				return false;
			};
		});
	}
	*/
	if((x = document.getElementById('mylist-clean')))
	{
		forEach(x.getElementsByTagName('a'), function()
		{
			this.onclick = function()
			{
				this.blur();
				return confirm('Czy chcesz usunąć całą zawartość listy produktów?');
			};
		});
	}
	if((x = document.getElementById('kredytonline')))
	{
		forEach(x.getElementsByTagName('form'), function()
		{
			this.target = '_blank';
		});
	}
	if(isIE)
	{
		forEach(document.getElementsByTagName('button'), function()
		{
			this.onmouseover = function()
			{
				this.className = 'hover';
			};
			this.onmouseout = function()
			{
				this.className = '';
			};
		});
	}
}

function pageTracker_onmousedown(orderId, shopname, ProductID, ProductName, MainCategory, City, prefix) 
{
    if (prefix == null)
        prefix = '';
        
    try {
        _gaq.push([prefix + '_addTrans',
                    City + orderId,
                    shopname,
                    "1",
                    "",
                    "",
                    City,
                    "",
                    ""
                ]);
        _gaq.push([prefix + '_addItem',
                    City + orderId,
                    ProductID,
                    ProductName,
                    MainCategory,
                    "1",
                    "1"
                ]);
        _gaq.push([prefix + '_trackTrans']);
        
        if(prefix == 'c.')
            pageTracker_onmousedown(orderId, shopname, ProductID, ProductName, MainCategory, City, '');
    }
    catch (err) {
        window_onerror('pagetrackerError-' + err, location.href, null);
    }
}

function clickWrapper(link, action, url) {
    try {
        link.href = action + url;
        link.target = '_blank';
    }
    catch (message) {
        window_onerror('clickWrapperError-' + message, location.href, null)
    }
}

var allegroTools = {
    timers: [null],
    productGalleryTimer: 0,

    loadAllegroContent: function(containerId, contentUrl) {
        if (contentUrl != "") {
            $.get(contentUrl, function(data, textStatus) {
                $("#" + containerId).html(data);
            }, "html");
        }
    },

    startLoadingTimer: function(timer, containerId, timeoutTarget, timeoutValue) {
        allegroTools.timers[timer] = setTimeout("allegroTools.loadAllegroContent(\"" + containerId + "\",\"" + timeoutTarget + "\");", timeoutValue);
    },

    clearLoadingTimer: function(timer) {
        if (allegroTools.timers[timer]) {
            clearTimeout(allegroTools.timers[timer]);
        }
    }
}
