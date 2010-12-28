function gxyadem_parameters() {
	var d=document;
	var w=window;
	var href=new String(d.location.href);
	var ref;
	var f=0;
	var fv='-';
	var dd;
	if (d.referrer) { ref=new String(d.referrer); } else { ref=''; }
	if (typeof Error!='undefined') {
		var fo;
		eval('try { f=(d==top.document)?1:2; if (typeof top.document.referrer=="string") { ref=top.document.referrer } } catch(e) {f=3;}');
		eval('try { fv=navigator.plugins["Shockwave Flash"].description; } catch (e) {}');
		eval('if (typeof ActiveXObject!="undefined") { try { fo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.7"); } catch(e) { try { fo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.6"); fv="X"; fo.AllowScriptAccess="always"; } catch(e) { if (fv=="X") { fv="WIN 6,0,20,0"; }} try { fo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash"); } catch(e) {} } if ((fv=="-" || fv=="X") && fo) { fv=fo.GetVariable("$version"); }}');
	}
	var url='&fr='+f+'&fv='+escape(fv)+'&tz='+(new Date()).getTimezoneOffset();
	if (typeof encodeURIComponent != 'undefined') {
		url+='&href='+encodeURIComponent(href.substring(0,499))+'&ref='+encodeURIComponent(ref.substring(0,499));
	}
	if (screen) {
		var s=screen;
		if (s.width) url+='&screen='+s.width+'x'+s.height;
		if (s.colorDepth) url+='&col='+s.colorDepth;
	}
	if (typeof w.innerWidth=='number') {
		url+='&window='+w.innerWidth+'x'+w.innerHeight;
	} else if ( ((dd = d.documentElement) && (dd.clientWidth || dd.clientHeight)) || ((dd = d.body) && (dd.clientWidth || dd.clientHeight)) ) {
		url+='&window='+dd.clientWidth+'x'+dd.clientHeight;
	}
	return url;
}

function gxyadem_add_onload_event(obj,fn) {
	if (obj.attachEvent) { 
		obj.attachEvent("onload", fn);
	} else if(obj.addEventListener) {
		obj.addEventListener("load", fn, false);
	}

}

function gxyadem_append_script() {
	if(typeof Error !='undefined') {
		eval("try { xp_javascript = document.createElement('script'); xp_javascript.src = window.gxyadem_gemius_script; xp_javascript.type = 'text/javascript'; xp_javascript.defer = true; document.body.appendChild(xp_javascript); } catch(exception) { }");
	}
}

function gxyadem_obj_loaded() {
	window.gxyadem_gemius_loaded+=1;
	if (window.gxyadem_gemius_loaded==2 && window.gxyadem_gemius_image.width) {
		if (window.gxyadem_gemius_image.width>1) {
			gxyadem_append_script();
		} else if (typeof window.statlayer == 'undefined') {
			gxyadem_emission();
		}
	}
}

if (typeof window.gxyadem_gemius_image != 'undefined') {
	if (typeof window.gxyadem_gemius_images == 'undefined') {
	        window.gxyadem_gemius_images = new Array();
	}
	var gxyadem_l = window.gxyadem_gemius_images.length;
	window.gxyadem_gemius_images[gxyadem_l]=new Image();
	window.gxyadem_gemius_images[gxyadem_l].src = gxyadem_gemius_host+'/redot.gif?'+gxyadem_gemius_args+gxyadem_parameters();
} else {
	window.gxyadem_gemius_loaded = 0;
	window.gxyadem_gemius_script = gxyadem_gemius_host+'/pp.js?'+gxyadem_gemius_args;
	gxyadem_add_onload_event(window,gxyadem_obj_loaded);
	window.gxyadem_gemius_image = new Image();
	gxyadem_add_onload_event(window.gxyadem_gemius_image,gxyadem_obj_loaded);
	window.gxyadem_gemius_image.src = gxyadem_gemius_host+'/rexdot.gif?l=11&'+gxyadem_gemius_args+gxyadem_parameters();
}

var gxy_align_match = /[&;\/?]align=(center|left|right)([&;\/]|$)/.exec(gxy_url_params);
var gxy_type_match = /[&;\/?]type=(percent|absolute)([&;\/]|$)/.exec(gxy_url_params);
var gxy_align = gxy_align_match?gxy_align_match[1].substr(0,1):'x';
var gxy_type = gxy_type_match?gxy_type_match[1].substr(0,1):'x';
var gxy_images = new Image();
var gxy_last_x = -1;
var gxy_last_y = -1;

function gxy_add_event(ob,evname,fn) {
	if (ob.attachEvent) {
		ob.attachEvent("on"+evname,fn);
	} else if(ob.addEventListener) {
		ob.addEventListener(evname,fn, false);
	}
}

function gxy_get_window_params() {
	var w = window;
	var d = document;
	var dd;
	var wparam = 'r'+screen.width+','+screen.height;
	if (typeof w.innerWidth=='number') {
		wparam += '|s'+w.innerWidth+','+w.innerHeight+'|a'+gxy_align.substr(0,1)+'|t'+gxy_type.substr(0,1)+'|m'+w.pageXOffset+','+w.pageYOffset+'|p';
	} else if ( ((dd = d.documentElement) && (dd.clientWidth || dd.clientHeight)) || ((dd = d.body) && (dd.clientWidth || dd.clientHeight)) ) {
		wparam += '|s'+dd.clientWidth+','+dd.clientHeight+'|a'+gxy_align.substr(0,1)+'|t'+gxy_type.substr(0,1)+'|m'+dd.scrollLeft+','+dd.scrollTop+'|p';
	}
	if (d.body && typeof(d.body.scrollWidth)!='undefined' && typeof(d.body.scrollHeight)!='undefined') {
		wparam += d.body.scrollWidth+','+d.body.scrollHeight;
	}
	return wparam;
}

function gxy_delay() {
	var start = (new Date()).getTime();
	while (start+200>(new Date()).getTime());
}

function gxy_reset() {
	gxy_last_x = -1;
	gxy_last_y = -1;
}

function gxy_sendxy(x,y) {
	if (x<gxy_last_x-1 || x>gxy_last_x+1 || y<gxy_last_y-1 || y>gxy_last_y+1) {
		var href = new String(document.location.href);
		var gxy_url = gxy_host+'arg=1&sarg='+gxy_get_window_params()+'&href='+escape(href.substring(0,499))+'&ref=http%3A%2F%2F0.0.0.0%2Fxy%3D'+x+':'+y;
		var gxy_image = new Image();
		gxy_image.src = gxy_url;
		gxy_images[gxy_images.length] = gxy_image;
		if (window.opera) {
			var start = (new Date()).getTime();
			while (start+200>(new Date()).getTime());
		}
		gxy_last_x = x;
		gxy_last_y = y;
	}
}

function gxy_click(ev) {
	gxy_sendxy(ev.clientX,ev.clientY);
}

function gxy_flash(id,xx,yy) {
	var gxy_obj = document.getElementById(id);
        if (gxy_obj) {
		var x=0;
		var y=0;
		if (gxy_obj.offsetParent) {
			do {
				x += gxy_obj.offsetLeft;
				y += gxy_obj.offsetTop;
				gxy_obj = gxy_obj.offsetParent;
			} while (gxy_obj);
		} else {
			if (gxy_obj.x) {
				x = gxy_obj.x;
			}
			if (gxy_obj.y) {
				y = gxy_obj.y;
			}
		}
		x+=xx;
		y+=yy;
		gxy_sendxy(x,y);
	}
}

gxy_add_event(document,"click",gxy_click);
gxy_add_event(window,"unload",gxy_delay);
gxy_add_event(window,"scroll",gxy_reset);
gxy_add_event(window,"resize",gxy_reset);
