var sx_={};sx_.lib=function(){var F={};var C=/(-[a-z])/gi;var B=function(H,I){return I.charAt(1).toUpperCase()};var G=function(I){var H;if(!(H=F[I])){H=F[I]=I.replace(C,B)}return H};var A=document.defaultView;var E=/alpha\([^\)]*\)/gi;var D=function(J,H){var I=J.style;if(window.ActiveXObject){I.zoom=1;I.filter=(I.filter||"").replace(E,"")+(H==1?"":" alpha(opacity="+(H*100)+")")}else{I.opacity=H}};return{adapter:"standalone",getStyle:function(){return A&&A.getComputedStyle?function(L,K){var H,J,I;if(K=="float"){K="cssFloat"}if(H=L.style[K]){return H}if(J=A.getComputedStyle(L,"")){return J[G(K)]}return null}:function(M,L){var I,K,J;if(L=="opacity"){if(typeof M.style.filter=="string"){var H=M.style.filter.match(/alpha\(opacity=(.+)\)/i);if(H){var N=parseFloat(H[1]);if(!isNaN(N)){return(N?N/100:0)}}}return 1}else{if(L=="float"){L="styleFloat"}}var J=G(L);if(I=M.style[J]){return I}if(K=M.currentStyle){return K[J]}return null}}(),setStyle:function(K,J,L){if(typeof J=="string"){var H=G(J);if(H=="opacity"){D(K,L)}else{try{K.style[H]=L}catch(err){}}}else{for(var I in J){this.setStyle(K,I,J[I])}}},get:function(H){return typeof H=="string"?document.getElementById(H):H},remove:function(H){H.parentNode.removeChild(H)},getTarget:function(I){var H=I.target?I.target:I.srcElement;return H.nodeType==3?H.parentNode:H},getPageXY:function(I){var H=I.pageX||(I.clientX+(document.documentElement.scrollLeft||document.body.scrollLeft));var J=I.pageY||(I.clientY+(document.documentElement.scrollTop||document.body.scrollTop));return[H,J]},preventDefault:function(H){if(H.preventDefault){H.preventDefault()}else{H.returnValue=false}},keyCode:function(H){return H.which?H.which:H.keyCode},addEvent:function(J,H,I){if(J.addEventListener){J.addEventListener(H,I,false)}else{if(J.attachEvent){J.attachEvent("on"+H,I)}}},removeEvent:function(J,H,I){if(J.removeEventListener){J.removeEventListener(H,I,false)}else{if(J.detachEvent){J.detachEvent("on"+H,I)}}},append:function(J,I){if(J.insertAdjacentHTML){J.insertAdjacentHTML("BeforeEnd",I)}else{if(J.lastChild){var H=J.ownerDocument.createRange();H.setStartAfter(J.lastChild);var K=H.createContextualFragment(I);J.appendChild(K)}else{J.innerHTML=I}}}}}();if(typeof sx_=="undefined"){throw"er1"}(function(){var u="2.0";var y={animate:true,animateFade:true,animSequence:"wh",flvPlayer:"flvplayer.swf",modal:false,overlayColor:"#000",overlayOpacity:0.6,flashBgColor:"#000000",autoplayMovies:false,showMovieControls:false,slideshowDelay:0,resizeDuration:0.55,fadeDuration:0.35,displayNav:true,continuous:false,displayCounter:false,counterType:"default",counterLimit:10,viewportPadding:20,handleOversize:"resize",handleException:null,handleUnsupported:"link",initialHeight:160,initialWidth:320,enableKeys:true,onOpen:null,onFinish:null,onChange:null,onClose:null,skipSetup:false,errors:{},ext:{iframe:["html"]}};var z=sx_;var A=z.lib;var B;var C={domain:/:\/\/(.*?)[:\/]/,inline:/#(.+)$/,rel:/^(lightSug|rad)box/i,gallery:/^(lightSug|rad)box\[(.*?)\]/i,unsupported:/^unsupported-(\w+)/,param:/\s*([a-z_]*?)\s*=\s*(.+)\s*/,empty:/^(?:br|frame|hr|img|input|link|meta|range|spacer|wbr|area|param|col)$/i};var D=[];var E;var F;var G;var H="sx_content";var I;var J=false;var K=false;var L;var M;var N=0;var O=navigator.userAgent.toLowerCase();var P={isStrict:document.compatMode=="CSS1Compat",isOpera:O.indexOf("opera")>-1,isIE:O.indexOf("msie")>-1,isIE7:O.indexOf("msie 7")>-1,isSafari:/webkit|khtml/.test(O),isWindows:O.indexOf("windows")!=-1||O.indexOf("win32")!=-1,isMac:O.indexOf("macintosh")!=-1||O.indexOf("mac os x")!=-1,isLinux:O.indexOf("linux")!=-1};P.isBorderBox=P.isIE&&!P.isStrict;P.isSafari3=P.isSafari&&!!(document.evaluate);P.isGecko=O.indexOf("gecko")!=-1&&!P.isSafari;var Q=P.isIE&&!P.isIE7;var R;if(navigator.plugins&&navigator.plugins.length){var S=function(a){var b=false;for(var i=0,len=navigator.plugins.length;i<len;++i){if(navigator.plugins[i].name.indexOf(a)>-1){b=true;break}}return b};var T=S("Flip4Mac");R={fla:S("Shockwave Flash"),qt:S("QuickTime"),wmp:!T&&S("Windows Media"),f4m:T}}else{var S=function(a){var b=false;try{var c=new ActiveXObject(a);if(c){b=true}}catch(e){}return b};R={}}var U=function(o,e){for(var p in e){o[p]=e[p]}return o};var V=function(a){return a&&typeof a.tagName=="string"&&(a.tagName.toUpperCase()=="A"||a.tagName.toUpperCase()=="AREA")};A.getViewportHeight=function(){var h=window.innerHeight;var a=document.compatMode;if((a||P.isIE)&&!P.isOpera){h=P.isStrict?document.documentElement.clientHeight:document.body.clientHeight}return h};A.getViewportWidth=function(){var w=window.innerWidth;var a=document.compatMode;if(a||P.isIE){w=P.isStrict?document.documentElement.clientWidth:document.body.clientWidth}return w};A.createHTML=function(a){var b="<"+a.tag;for(var c in a){if(c=="tag"||c=="html"||c=="children"){continue}if(c=="cls"){b+=' class="'+a.cls+'"'}else{b+=" "+c+'="'+a[c]+'"'}}if(C.empty.test(a.tag)){b+="/>"}else{b+=">";var d=a.children;if(d){for(var i=0,len=d.length;i<len;++i){b+=this.createHTML(d[i])}}if(a.html){b+=a.html}b+="</"+a.tag+">"}return b};var W=function(x){return 1+Math.pow(x-1,3)};var X=function(b,p,c,d,e){var f=parseFloat(A.getStyle(b,p));if(isNaN(f)){f=0}if(f==c){if(typeof e=="function"){e()}return}var g=c-f;var h=p=="opacity";var i=h?"":"px";var j=function(a){A.setStyle(b,p,f+a*g+i)};if(!y.animate&&!h||h&&!y.animateFade){j(1);if(typeof e=="function"){e()}return}d*=1000;var k=new Date().getTime();var l=k+d;var m=setInterval(function(){var a=new Date().getTime();if(a>=l){clearInterval(m);j(1);if(typeof e=="function"){e()}}else{j(W((a-k)/d))}},10)};var Y=function(a){var s=a.style;if(P.isIE){if(typeof s.filter=="string"&&(/alpha/i).test(s.filter)){s.filter=s.filter.replace(/[\w\.]*alpha\(.*?\);?/i,"")}}else{s.opacity="";s["-moz-opacity"]="";s["-khtml-opacity"]=""}};var Z=function(a){var h=Math.max(a.offsetHeight,a.clientHeight);if(!h){h=parseInt(A.getStyle(a,"height"),10)||0;if(!P.isBorderBox){h+=parseInt(A.getStyle(a,"padding-top"),10)+parseInt(A.getStyle(a,"padding-bottom"),10)+parseInt(A.getStyle(a,"border-top-width"),10)+parseInt(A.getStyle(a,"border-bottom-width"),10)}}return h};var bs=function(a){return"iframe"};var bt=function(a){var b;if(V(this)){b=this}else{b=A.getTarget(a);while(!V(b)&&b.parentNode){b=b.parentNode}}if(b){z.open(b);if(E.length){A.preventDefault(a)}}};var bu=function(a,b){var c=A.get("sx_nav_"+a);if(c){c.style.display=b?"":"none"}};var bv=function(a){var b=E[F];var d=A.get("sx_title_inner");d.innerHTML=b.title||"";var e=A.get("sx_nav");if(e){var c,n,pl,pa,p;if(y.displayNav){c=true;var f=E.length;if(f>1){if(y.continuous){n=p=true}else{n=(f-1)>F;p=F>0}}if(y.slideshowDelay>0&&bI()){pa=L!="paused";pl=!pa}}else{c=n=pl=pa=p=false}bu("close",c);bu("next",n);bu("play",pl);bu("pause",pa);bu("previous",p)}var g=A.get("sx_counter");if(g){var j="";if(y.displayCounter&&E.length>1){if(y.counterType=="skip"){var i=0,f=E.length,end=f;var k=parseInt(y.counterLimit);if(k<f){var h=Math.round(k/2);i=F-h;if(i<0){i+=f}end=F+(k-h);if(end>f){end-=f}}while(i!=end){if(i==f){i=0}j+='<a onclick="sx_.change('+i+');"';if(i==F){j+=' class="sx_counter_current"'}j+=">"+(++i)+"</a>"}}else{j=(F+1)+" "+z.LANG.of+" "+f}}g.innerHTML=j}a()};var bw=function(a,b){var c=E[F];var d=A.get("sx_title");var e=A.get("sx_info");var f=A.get("sx_title_inner");var g=A.get("sx_info_inner");var h=function(){bv(b)};var i=Z(d);var j=Z(e)*-1;if(a){X(f,"margin-top",i,0.35);X(g,"margin-top",j,0.35,h)}else{A.setStyle(f,"margin-top",i+"px");A.setStyle(g,"margin-top",j+"px");h()}};var bx=function(a){var b=A.get("sx_title_inner");var c=A.get("sx_info_inner");var t=b.innerHTML!="";if(t){X(b,"margin-top",0,0.35)}X(c,"margin-top",0,0.35,a)};var by=function(){var c=E[F];if(!c){return}var d=false;if(G){G.remove();d=true}var p=c.player=="inline"?"html":c.player;if(typeof z[p]!="function"){z.raise("Unknown player "+c.player)}G=new z[p](H,c);bD(false);bF(true);bw(d,function(){if(!G){return}if(!d){A.get("radbox").style.display=""}var a=function(){bA(function(){if(!G){return}bx(function(){if(!G){return}A.get("sx_body_inner").innerHTML=A.createHTML(G.markup(I));bF(false,function(){if(!G){return}if(typeof G.onLoad=="function"){G.onLoad()}if(y.onFinish&&typeof y.onFinish=="function"){y.onFinish(E[F])}if(L!="paused"){z.play()}bD(true)})})})};if(typeof G.ready!="undefined"){var b=setInterval(function(){if(G){if(G.ready){clearInterval(b);b=null;a()}}else{clearInterval(b);b=null}},100)}else{a()}});if(E.length>1){var e=E[F+1]||E[0];if(e.player=="img"){var a=new Image();a.src=e.content}var f=E[F-1]||E[E.length-1];if(f.player=="img"){var b=new Image();b.src=f.content}}};var bz=function(a,b,c){c=c||false;var d=A.get("sx_body");var h=a=parseInt(a);var w=b=parseInt(b);var e=A.getViewportHeight();var f=A.getViewportWidth();var g=parseInt(A.getStyle(d,"border-left-width"),10)+parseInt(A.getStyle(d,"border-right-width"),10);var i=g+2*y.viewportPadding;if(w+i>=f){w=f-i}var j=parseInt(A.getStyle(d,"border-top-width"),10)+parseInt(A.getStyle(d,"border-bottom-width"),10);var k=Z(A.get("sx_title"))+Z(A.get("sx_info"));var l=j+2*y.viewportPadding+k;if(h+l>=e){h=e-l}var m=false;var n=a;var o=b;var p=y.handleOversize;if(c&&(p=="resize"||p=="drag")){var q=(a-h)/a;var r=(b-w)/b;if(p=="resize"){if(q>r){w=Math.round((b/a)*h)}else{if(r>q){h=Math.round((a/b)*w)}}o=w;n=h}else{var s=E[F];if(s){m=s.player=="img"&&(q>0||r>0)}}}I={height:h+j+k,width:w+g,inner_h:h,inner_w:w,top:(e-(h+l))/2+y.viewportPadding,resize_h:n,resize_w:o,drag:m}};var bA=function(a){if(!G){return}bz(G.height,G.width,G.resizable);if(a){switch(y.animSequence){case"hw":bB(I.inner_h,I.top,true,function(){bC(I.width,true,a)});break;case"wh":bC(I.width,true,function(){bB(I.inner_h,I.top,true,a)});break;case"sync":default:bC(I.width,true);bB(I.inner_h,I.top,true,a)}}else{bC(I.width,false);bB(I.inner_h,I.top,false);var c=A.get(H);if(c){if(G.resizable&&y.handleOversize=="resize"){c.height=I.resize_h;c.width=I.resize_w}if(E[F].player=="img"&&y.handleOversize=="drag"){var b=parseInt(A.getStyle(c,"top"));if(b+G.height<I.inner_h){A.setStyle(c,"top",I.inner_h-G.height+"px")}var d=parseInt(A.getStyle(c,"left"));if(d+G.width<I.inner_w){A.setStyle(c,"left",I.inner_w-G.width+"px")}}}}};var bB=function(a,b,c,d){a=parseInt(a);var e=A.get("sx_body");if(c){X(e,"height",a,y.resizeDuration)}else{A.setStyle(e,"height",a+"px")}var s=A.get("radbox");if(c){X(s,"top",b,y.resizeDuration,d)}else{A.setStyle(s,"top",b+"px");if(typeof d=="function"){d()}}};var bC=function(a,b,c){a=parseInt(a);var s=A.get("radbox");if(b){X(s,"width",a,y.resizeDuration,c)}else{A.setStyle(s,"width",a+"px");if(typeof c=="function"){c()}}};var bD=function(a){if(!y.enableKeys){return}A[(a?"add":"remove")+"Event"](document,"keydown",bE)};var bE=function(e){var a=A.keyCode(e);A.preventDefault(e);if(a==81||a==88||a==27){z.close()}else{if(a==37){z.previous()}else{if(a==39){z.next()}else{if(a==32){z[(typeof L=="number"?"pause":"play")]()}}}}};var bF=function(a,b){var c=A.get("sx_loading");if(a){c.style.display="";if(typeof b=="function"){b()}}else{var p=E[F].player;var d=(p=="img"||p=="html");var e=function(){c.style.display="none";Y(c);if(typeof b=="function"){b()}};if(d){X(c,"opacity",0,y.fadeDuration,e)}else{e()}}};var bG=function(){A.get("sx_container").style.top=document.documentElement.scrollTop+"px"};var bH=function(){A.get("sx_overlay").style.height=A.getViewportHeight()+"px"};var bI=function(){return E.length>1&&(F!=E.length-1||y.continuous)};var bJ=function(a){var b,v=(a)?"hidden":"visible";var c=["select","object","embed"];for(var i=0;i<c.length;++i){b=document.getElementsByTagName(c[i]);for(var j=0,len=b.length;j<len;++j){b[j].style.visibility=v}}var d=A.get("sx_overlay");var e=A.get("sx_container");var f=A.get("radbox");if(a){A.setStyle(d,{backgroundColor:y.overlayColor,opacity:0});if(!y.modal){A.addEvent(d,"click",z.close)}if(Q){bG();bH();A.addEvent(window,"scroll",bG)}f.style.display="none";e.style.visibility="visible";X(d,"opacity",parseFloat(y.overlayOpacity),y.fadeDuration,a)}else{A.removeEvent(d,"click",z.close);if(Q){A.removeEvent(window,"scroll",bG)}f.style.display="none";X(d,"opacity",0,y.fadeDuration,function(){e.style.visibility="hidden";f.style.display="";Y(d)})}};sx_.init=function(a){if(J){return}if(typeof z.LANG=="undefined"){z.raise("No sx_ language loaded");return}if(typeof z.SKIN=="undefined"){z.raise("er skin");return}U(y,a||{});var b=z.SKIN.markup.replace(/\{(\w+)\}/g,function(m,p){return z.LANG[p]});var c=document.body||document.documentElement;A.append(c,b);if(Q){A.setStyle(A.get("sx_container"),"position","absolute");A.get("sx_body").style.zoom=1;var d=z.SKIN.png_fix;if(d&&d.constructor==Array){for(var i=0;i<d.length;++i){var f=A.get(d[i]);if(f){var g=A.getStyle(f,"background-image").match(/url\("(.*\.png)"\)/);if(g){A.setStyle(f,{backgroundImage:"none",filter:"progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true,src="+g[1]+",sizingMethod=scale);"})}}}}}for(var e in y.ext){C[e]=new RegExp(".("+y.ext[e].join("|")+")s*$","i")}var h;A.addEvent(window,"resize",function(){if(h){clearTimeout(h);h=null}h=setTimeout(function(){if(Q){bH()}bA()},50)});if(!y.skipSetup){z.setup()}J=true};sx_.loadSkin=function(a,b){if(!(/\/$/.test(b))){b+="/"}a=b+a+"/";document.write('<link rel="stylesheet" type="text/css" href="'+a+'sugester.css">');sx_.SKIN={markup:'<div id="sx_container">'+'<div id="sx_overlay"></div>'+'<div id="radbox">'+'<div id="sx_title">'+'<div id="sx_title_inner"></div>'+'</div>'+'<div id="sx_body">'+'<div id="sx_body_inner"></div>'+'<div id="sx_loading">'+'<div id="sx_loading_indicator"></div>'+'<span><a onclick="sx_.close();">{cancel}</a></span>'+'</div>'+'</div>'+'<div id="sx_info">'+'<div id="sx_info_inner">'+'<div id="sx_counter"></div>'+'<div id="sx_nav">'+'<a id="sx_nav_close" title="{close}" onclick="sx_.close()"></a>'+'</div>'+'<div class="sx_clear"></div>'+'</div>'+'</div>'+'</div>'+'</div>',png_fix:['sx_nav_close']}};sx_.loadLanguage=function(a,b){if(!(/\/$/.test(b))){b+="/"}};sx_.loadPlayer=function(a,b){if(typeof a=="string"){a=[a]}if(!(/\/$/.test(b))){b+="/"}};sx_.setup=function(b,c){if(!b){var b=[];var a=document.getElementsByTagName("a"),rel;for(var i=0,len=a.length;i<len;++i){rel=a[i].getAttribute("rel");if(rel&&C.rel.test(rel)){b[b.length]=a[i]}}}else{if(!b.length){b=[b]}}var d;for(var i=0,len=b.length;i<len;++i){d=b[i];if(typeof d.radboxCacheKey=="undefined"){d.radboxCacheKey=D.length;A.addEvent(d,"click",bt)}D[d.radboxCacheKey]=this.buildCacheObj(d,c)}};sx_.buildCacheObj=function(a,b){var c=a.href;var o={el:a,title:a.getAttribute("title"),player:bs(c),options:U({},b||{}),content:c};var d,l_opts=["player","title","height","width","gallery"];for(var i=0,len=l_opts.length;i<len;++i){d=l_opts[i];if(typeof o.options[d]!="undefined"){o[d]=o.options[d];delete o.options[d]}}var e=a.getAttribute("rel");if(e){var f=e.match(C.gallery);if(f){o.gallery=escape(f[2])}var g=e.split(";");for(var i=0,len=g.length;i<len;++i){f=g[i].match(C.param);if(f){if(f[1]=="options"){eval("apply(o.options, "+f[2]+")")}else{o[f[1]]=f[2]}}}}return o};sx_.applyOptions=function(a){if(a){B=U({},y);y=U(y,a)}};sx_.revertOptions=function(){if(B){y=B;B=null}};sx_.open=function(b,c){this.revertOptions();if(V(b)){if(typeof b.radboxCacheKey=="undefined"||typeof D[b.radboxCacheKey]=="undefined"){b=this.buildCacheObj(b,c)}else{b=D[b.radboxCacheKey]}}if(b.constructor==Array){E=b;F=0}else{var d=U({},b);if(!b.gallery){E=[d];F=0}else{F=null;E=[];var e;for(var i=0,len=D.length;i<len;++i){e=D[i];if(e.gallery){if(e.content==b.content&&e.gallery==b.gallery&&e.title==b.title){F=E.length}if(e.gallery==b.gallery){E.push(U({},e))}}}if(F==null){E.unshift(d);F=0}}}b=E[F];if(b.options||c){this.applyOptions(U(U({},b.options||{}),c||{}))}var f,r;for(var i=0,len=E.length;i<len;++i){r=false;if(E[i].player=="unsupported"){r=true}else{if(f=C.unsupported.exec(E[i].player)){if(y.handleUnsupported=="link"){E[i].player="html";var s,a,oe=y.errors;switch(f[1]){case"qtwmp":s="either";a=[oe.qt.url,oe.qt.name,oe.wmp.url,oe.wmp.name];break;case"qtf4m":s="shared";a=[oe.qt.url,oe.qt.name,oe.f4m.url,oe.f4m.name];break;default:s="single";if(f[1]=="swf"||f[1]=="flv"){f[1]="fla"}a=[oe[f[1]].url,oe[f[1]].name]}var g=z.LANG.errors[s].replace(/\{(\d+)\}/g,function(m,i){return a[i]});E[i].content='<div class="sx_message">'+g+"</div>"}else{r=true}}else{if(E[i].player=="inline"){var f=C.inline.exec(E[i].content);if(f){var h;if(h=A.get(f[1])){E[i].content=h.innerHTML}else{z.raise("er4"+f[1])}}else{z.raise("er3")}}}}if(r){E.splice(i,1);if(i<F){--F}else{if(i==F){F=i>0?F-1:i}}--i;len=E.length}}if(E.length){if(y.onOpen&&typeof y.onOpen=="function"){y.onOpen(b)}if(!K){bz(y.initialHeight,y.initialWidth);bB(I.inner_h,I.top,false);bC(I.width,false);bJ(by)}else{by()}K=true}};sx_.change=function(a){if(!E){return}if(!E[a]){if(!y.continuous){return}else{a=a<0?(E.length-1):0}}if(typeof L=="number"){clearTimeout(L);L=null;N=M=0}F=a;if(y.onChange&&typeof y.onChange=="function"){y.onChange(E[F])}by()};sx_.next=function(){this.change(F+1)};sx_.previous=function(){this.change(F-1)};sx_.play=function(){if(!bI()){return}if(!N){N=y.slideshowDelay*1000}if(N){M=new Date().getTime();L=setTimeout(function(){N=M=0;z.next()},N);bu("play",false);bu("pause",true)}};sx_.pause=function(){if(typeof L=="number"){var a=new Date().getTime();N=Math.max(0,N-(a-M));if(N){clearTimeout(L);L="paused"}bu("pause",false);bu("play",true)}};sx_.close=function(){if(!K){return}bD(false);bJ(false);if(G){G.remove();G=null}if(typeof L=="number"){clearTimeout(L)}L=null;N=0;if(y.onClose&&typeof y.onClose=="function"){y.onClose(E[F])}K=false};sx_.clearCache=function(){for(var i=0,len=D.length;i<len;++i){if(D[i].el){A.removeEvent(D[i].el,"click",bt);delete D[i].el.radboxCacheKey}}D=[]};sx_.getPlugins=function(){return R};sx_.getOptions=function(){return y};sx_.getCurrent=function(){return E[F]};sx_.getVersion=function(){return u};sx_.getClient=function(){return P};sx_.getContent=function(){return G};sx_.getDimensions=function(){return I};sx_.raise=function(e){if(typeof y.handleException=="function"){y.handleException(e)}else{throw e}}})();if(typeof sx_=="undefined"){throw"er2."}sx_.LANG={code:"pl",of:"z",loading:"wczytywanie",cancel:"Anuluj",next:"Dalej",previous:"Wróć",play:"Odtwarzaj",pause:"Pauza",close:"Zamknij",errors:{}};(function(){var A=sx_;var B=A.lib;var D=A.getClient();sx_.iframe=function(E,C){this.id=E;this.obj=C;this.height=this.obj.height?parseInt(this.obj.height,10):B.getViewportHeight();this.width=this.obj.width?parseInt(this.obj.width,10):B.getViewportWidth()};sx_.iframe.prototype={markup:function(E){var C={tag:"iframe",id:this.id,name:this.id,height:"100%",width:"100%",frameborder:"0",marginwidth:"0",marginheight:"0",scrolling:"auto"};if(D.isIE){C.allowtransparency="true";if(!D.isIE7){C.src='javascript:false;document.write("");'}}return C},onLoad:function(){var C=(D.isIE)?B.get(this.id).contentWindow:window.frames[this.id];C.location=this.obj.content},remove:function(){var C=B.get(this.id);if(C){B.remove(C);if(D.isGecko){delete window.frames[this.id]}}}}})();document.write('<a title="Twoja sugestia" rel="radbox;width=574;height=315" href="http://ceneo-pl.sugester.pl/app/form.html" id="sugester_widget" class="sugester_widget_1 sugester_widget_right" onclick="return false;"></a>');sx_.loadSkin('sugester','http://app.sugester.pl/stylesheets');f1=window.onload;window.onload=function(){sx_.init();if(f1!=undefined)f1()};
