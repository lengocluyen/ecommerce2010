/* Copyright © 2005-2009 Ceneo SA */

/* === WINDOW EVENTS === */

    // onerror
    window.onerror = window_onerror;

    function window_onerror(message,url,lineNumber) {
        var src = '/SubmitReport/JsError?onerrorMessage=' + escape(message)
		    + '&onerrorUrl=' + escape(url)
		    + '&onerrorLineNumber=' + lineNumber;
	    var onerrorImage = new Image();
	    onerrorImage.src = src;
	    return true;
    }


/* === VARIABLES === */

var isIE = /*@cc_on!@*/false;
var isIE6 = $.browser.msie && $.browser.version.substr(0, 1) == "6"

var cookie = {
	set: function(name, value, days)
	{
		var date = new Date(), expires = '';
		if(days)
		{
			date.setTime(date.getTime() + days * 24 * 60 * 60 * 1000);
			expires = '; expires=' + date.toGMTString();
		}
		document.cookie = name + '=' + value + expires + '; path=/';
	},
	get: function(name)
	{
		name += '=';
		for(var i = 0, c = document.cookie.split(';'); i < c.length; i++)
		{
			while(c[i].charAt(0) == ' ')
			{
				c[i] = c[i].substring(1, c[i].length);
			}
			if(c[i].indexOf(name) === 0)
			{
				return c[i].substring(name.length, c[i].length);
			}
		}
		return null;
	},
	del: function(name)
	{
		cookie.set(name, '', -1);
	}
};

var ceneoGallery = {
	thumbs: 0,
	init: function(x)
	{
		ceneoGallery.thumbs = x;
		x = document.getElementById('gallery-thumbs');
		if(x)
		{
			if(document.getElementById('gallery-photo'))
			{
				forEach(x.getElementsByTagName('a'), function()
				{
					this.target = '';
					this.onclick = function()
					{
						var x = new Image(), y = document.getElementById('gallery-photo').getElementsByTagName('img')[0];
						x.src = this.getElementsByTagName('img')[0].src.replace(/\.jpg/, '-big.jpg'); // todo: regular expression to match ceneo file path
						y.src = x.src;
						//y.style.width = (ceneoGallery.thumbs == 2) ? ((x.width > 470) ? 470 + 'px' : '') : ((x.width > 600) ? 600 + 'px' : '');
                  if (x.width > 0) {
                     y.style.width = (x.width > 470) ? 470 + 'px' : x.width + 'px';
                  }
                  this.blur();
						return false;
					};
				});
			}
			x = x.getElementsByTagName('li');
			if(x.length > ceneoGallery.thumbs)
			{
				document.getElementById('gallery-control').style.display = 'block';
				document.getElementById('gallery-control-prev').style.display = 'none';
				document.getElementById('gallery-control-prev').getElementsByTagName('a')[0].onclick = function()
				{
					ceneoGallery.prev();
					this.blur();
					return false;
				};
				document.getElementById('gallery-control-next').getElementsByTagName('a')[0].onclick = function()
				{
					ceneoGallery.next();
					this.blur();
					return false;
				};
				forEach(x, function(i)
				{
					this.style.display = (i >= ceneoGallery.thumbs) ? 'none' : 'block';
				});
			}
		}
	},
	controls: function(x)
	{
		document.getElementById('gallery-control-prev').style.display = (x[0].style.display == 'none') ? 'block' : 'none';
		document.getElementById('gallery-control-next').style.display = (x[x.length-1].style.display == 'none') ? 'block' : 'none';
	},
	prev: function()
	{
		var i, x = document.getElementById('gallery-thumbs').getElementsByTagName('li');
		if(x[0].style.display == 'none')
		{
			for(i = x.length - 1; i >= 0; i--)
			{
				if(x[i].style.display != 'none')
				{
					x[i].style.display = 'none';
					break;
				}
			}
			for(i--; i >= 0; i--)
			{
				if(x[i].style.display == 'none')
				{
					x[i].style.display = 'block';
					break;
				}
			}
		}
		ceneoGallery.controls(x);
	},
	next: function()
	{
		var i, x = document.getElementById('gallery-thumbs').getElementsByTagName('li');
		if(x[x.length-1].style.display == 'none')
		{
			for(i = 0; i < x.length; i++)
			{
				if(x[i].style.display != 'none')
				{
					x[i].style.display = 'none';
					break;
				}
			}
			for(i++; i < x.length; i++)
			{
				if(x[i].style.display == 'none')
				{
					x[i].style.display = 'block';
					break;
				}
			}
		}
		ceneoGallery.controls(x);
	}
};

var ceneoGalleryLite = {
	thumbs: 0,
	init: function(x)
	{
		ceneoGalleryLite.thumbs = x;
		x = document.getElementById('lite-gallery-thumbs');
		if(x)
		{
			if(document.getElementById('lite-gallery-photo'))
			{
				forEach(x.getElementsByTagName('a'), function()
				{
					this.target = '';
					this.onclick = function()
					{
						var x = new Image(), y = document.getElementById('lite-gallery-photo').getElementsByTagName('img')[0];
						x.src = this.getElementsByTagName('img')[0].src.replace(/productToCategory\.jpg/, 'product.jpg'); // TODO: obejsc sie bez regular expressionow, niech nazwy plikow w obu wersjach przychodza z "kontrolera"
						y.src = x.src;
						y.style.width = (ceneoGalleryLite.thumbs == 2) ? ((x.width > 470) ? 470 + 'px' : '') : ((x.width > 600) ? 600 + 'px' : '');
						this.blur();
						return false;
					};
				});
			}
			x = x.getElementsByTagName('li');
			if(x.length > ceneoGalleryLite.thumbs)
			{
				document.getElementById('lite-gallery-control').style.display = 'block';
				document.getElementById('lite-gallery-control-prev').style.display = 'none';
				document.getElementById('lite-gallery-control-prev').getElementsByTagName('a')[0].onclick = function()
				{
					ceneoGalleryLite.prev();
					this.blur();
					return false;
				};
				document.getElementById('lite-gallery-control-next').getElementsByTagName('a')[0].onclick = function()
				{
					ceneoGalleryLite.next();
					this.blur();
					return false;
				};
				forEach(x, function(i)
				{
					this.style.display = (i >= ceneoGalleryLite.thumbs) ? 'none' : 'block';
				});
			}
		}
	},
	controls: function(x)
	{
		document.getElementById('lite-gallery-control-prev').style.display = (x[0].style.display == 'none') ? 'block' : 'none';
		document.getElementById('lite-gallery-control-next').style.display = (x[x.length-1].style.display == 'none') ? 'block' : 'none';
	},
	prev: function()
	{
		var i, x = document.getElementById('lite-gallery-thumbs').getElementsByTagName('li');
		if(x[0].style.display == 'none')
		{
			for(i = x.length - 1; i >= 0; i--)
			{
				if(x[i].style.display != 'none')
				{
					x[i].style.display = 'none';
					break;
				}
			}
			for(i--; i >= 0; i--)
			{
				if(x[i].style.display == 'none')
				{
					x[i].style.display = 'block';
					break;
				}
			}
		}
		ceneoGalleryLite.controls(x);
	},
	next: function()
	{
		var i, x = document.getElementById('lite-gallery-thumbs').getElementsByTagName('li');
		if(x[x.length-1].style.display == 'none')
		{
			for(i = 0; i < x.length; i++)
			{
				if(x[i].style.display != 'none')
				{
					x[i].style.display = 'none';
					break;
				}
			}
			for(i++; i < x.length; i++)
			{
				if(x[i].style.display == 'none')
				{
					x[i].style.display = 'block';
					break;
				}
			}
		}
		ceneoGalleryLite.controls(x);
	}
};

/* === FUNCTIONS === */

function hasInSpaceSeparated(key, val)
{
	val = ' ' + val + ' ';
	return (val.indexOf(key) > -1);
}

function forEach(object, callback)
{
	var i, l = object.length, x;
	if(l === undefined)
	{
		for(x in object)
		{
			if(callback.call(object[x], x, object[x]) === false)
			{
				break;
			}
		}
	}
	else
	{
		for(i = 0, x = object[0]; i < l && callback.call(x, i, x) !== false; x = object[++i])
		{
		}
	}
}

function documentInit(fun)
{
	if(document.addEventListener)
	{
		document.addEventListener('DOMContentLoaded', fun, false);
	}
	if(/Apple|KDE/i.test(window.navigator.vendor))
	{
		t = window.setInterval(function()
		{
			if(/loaded|complete/.test(document.readyState))
			{
				window.clearInterval(t);
				t = null;
				fun();
			}
		}, 10);
	}
	window.onload = fun;
}

/* === INIT === */

//if(window.self != window.top)
//{
//	window.top.location.href = window.self.location.href;
//}

if(!String.prototype.trim)
{
	String.prototype.trim = function()
	{
		return this.replace(/^\s+|\s+$/g, '');
	};
}

if(document.getElementById && document.createElement && [].push) // not for old browsers such as IE 5.01
{
	if(isIE) // for IE
	{
		document.createElement('abbr');
	}
	documentInit(ceneoEnv);
}