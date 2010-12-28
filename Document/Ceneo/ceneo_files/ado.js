var AdoElement=function(a){var b=this;this.loadingLib=false;this.buff=ado.placeholder;this.tmpBuff="";this.config=a;this.onLoad=a.onLoad;this.DOMElement={};this.DOMElementBufor="";this.regs={scriptBegin:/^\s*(<script\s*)(\s*(\w+)\s*=\s*(([^\s\"\'>]{1}[^\s>]*)|\"([^\"]*)\"|\'([^\']*)\'))*[^\w>]*>/i,scriptEnd:/(<\/script\b([^>\"\']|\"[^\"]*\"|\'[^\']*\')*>)/i,attr:/(\s*(\w+)\s*=\s*(([^\s\"\'>]{1}[^\s>]*)|\"([^\"]*)\"|\'([^\']*)\'))/};this.myWrite=function(c){b.tmpBuff+=c};this.myWriteln=function(c){b.myWrite(c+"\n")};this.isMaster=function(){return this.config.master};this.isSlave=function(){return this.config.slave};this.initBuffor=function(){ado.busy=true;window.document.open=function(){};window.document.close=function(){};document.write=b.myWrite;document.writeln=b.myWriteln};this.rewriteBuffor=function(){if(this.buff.indexOf(ado.placeholder)!==-1){this.buff=b.buff.replace(ado.placeholder,b.tmpBuff)}else{this.buff=this.tmpBuff+this.buff}this.tmpBuff=""};this.preDispatch=function(){if(typeof this.config!=="object"){return}if(!this.config.id||!this.config.server){return}if(ado.protocol.substr(0,4)!=="http"){return}this.getDOMElement();this.emptyDOMElement();this.DOMElementBufor="";if(!this.isSlave()){if(this.config.preview){this.config.url=this.config.server}else{this.makeUrl()}}this.appendRedirUrl();if(ado.mode==="old"||!ado.isBrowserSupport()){document.write("<script type='text/javascript' src='"+b.config.url+"'><\/script>")}else{this.initBuffor();this.appendScript(this.config.url,null,true)}};this.postDispatch=function(){this.flushDOMBufor();ado.busy=false;ado.start()};this.dispatch=function(){this.deleteComment();var d=[];var f=this;if(this.regs.scriptBegin.test(this.buff)&&this.regs.scriptBegin.test(this.buff)){d=this.regs.scriptBegin.exec(f.buff);var c=this.processAttributes(d[0]);if(c.src){this.processSrcScript(d,c.src,c.charset)}else{if(c.language!=="VBScript"&&c.type!="text/vbscript"){this.processInlineScript(d)}else{this.processVBScript(d)}}}else{var h=function(){if(f.DOMElement){f.addToDOMElement(f.buff.replace(ado.placeholder,""));f.buff=""}if(typeof f.config.onLoad==="function"){f.onLoad();f.onLoad=false}f.postDispatch()};if(!this.regs.scriptBegin.test(this.buff)){var g=/<script/i;d=g.exec(this.buff);if(d){var e=f.buff.indexOf(d[0]);f.DOMElement=ado.getById(f.config.id);if(f.DOMElement){f.addToDOMElement(this.buff.substr(0,e).replace(ado.placeholder,""))}this.buff=this.buff.substr(e);this.dispatch()}else{h()}}}return};this.deleteComment=function(){var d=/\<!\s*--(.*?)(--\s*\>)/m;while(d.test(b.buff)){b.buff=b.buff.replace(d,"")}};this.processVBScript=function(c){var d=this.regs.scriptEnd.exec(b.buff);td_flashinstalled=2;td_browserFlashversion=8;this.buff=ado.placeholder+this.buff.substr(d.index+d[0].length);b.dispatch()};this.processSrcScript=function(c,e,f){this.buff=b.buff.substr(c[0].length);var d=this.regs.scriptEnd.exec(b.buff);this.buff=ado.placeholder+this.buff.substr(d.index+d[0].length);this.appendScript(e,f)};this.appendScript=function(e,g,c,f){var d=function(h){b.loadingLib=false;if(typeof f==="function"){f()}b.rewriteBuffor();b.dispatch()};this.loadingLib=true;ado.loadScript(e,d,g);return};this.onServerEmission=function(){var e=function(){if(typeof b.config.onServerEmissionEmpty==="function"){b.config.onServerEmissionEmpty()}};if(typeof adserver_emissions==="object"){var d=0;for(var c in adserver_emissions){if(typeof adserver_emissions[c]!=="function"){d++}}if(d>ado.adserverEmissions){ado.adserverEmissions++;if(typeof b.config.onServerEmission==="function"){b.config.onServerEmission()}}else{e()}}else{e()}};this.processInlineScript=function(c){if(b.loadingLib){return}this.buff=this.buff.substr(c[0].length);var f=this.regs.scriptEnd.exec(b.buff);var e=this.buff.substr(0,f.index);this.buff=ado.placeholder+this.buff.substr(f.index+f[0].length);e=e.replace("/*<![CDATA[*/","");e=e.replace("<![CDATA[","");e=e.replace("/* <![CDATA[ */","");e=e.replace("/* ]]> */","");e=e.replace("/*]]>*/","");e=e.replace("<!--","");e=e.replace("//-->","");e=e.replace("//]]>-->","");e=e.replace(/\/\*.*\*\//g,"");try{ado.evaluate(e)}catch(d){}this.rewriteBuffor();this.dispatch();return};this.processAttributes=function(d){var e={};while(d.length>0){var c=b.regs.attr.exec(d);if(!c){break}d=d.substr(c.index+c[1].length);var f=null;if(c[4]){f=c[4]}if(c[5]){f=c[5]}if(c[6]){f=c[6]}e[c[2].toLowerCase()]=f}return e};this.getDOMElement=function(){this.DOMElement=ado.getById(this.config.id);if(!this.DOMElement){return}};this.emptyDOMElement=function(){if(this.DOMElement){this.DOMElement.innerHTML="";this.DOMElement.style.display="none"}};this.flushDOMBufor=function(){this.insertToDOMElement(this.DOMElementBufor);this.DOMElementBufor=""};this.addToDOMElement=function(c){this.DOMElementBufor+=c};this.insertToDOMElement=function(c){if(this.DOMElement&&c!==""){this.DOMElement.style.display="block";this.DOMElement.innerHTML=c}};this.makeUrl=function(){if(this.config.preview){this.config.server=this.config.emiter}var c=this.config.contentType;switch(c){case"txt":case"xml":case"js":break;default:c="js";break}this.config.url=ado.protocol+"//"+this.config.server;this.config.url+="/_"+(new Date()).getTime()+"/ad."+c+"?id="+ado.trimAdoPrefix(this.config.orgId)+"/x="+screen.width+"/y="+screen.height;this.config.url+=ado.makeKeywords(this.config.keys)+ado.makeVars(this.config.vars)+ado.makeFlash();return};this.appendRedirUrl=function(){if(this.config.redir&&this.config.redir!==""&&this.config.redir!="<%%REDIR%%>"){this.config.url=this.config.url+"/redir="+this.config.redir}}};var AdoContainer=function(){var that=this;var userAgent=navigator.userAgent.toLowerCase();var tuneId=function(config){config.orgId=config.id;config.id=config.id+""+ado.iterator++;var de=ado.getById(config.orgId);if(de){de.id=config.id}return config};var keywordEncode=function(s){var d="";var k=0;var c="";if(!s){return}for(k=0;k<s.length;k++){c=s.charCodeAt(k);if(c<128){d+=s.charAt(k)}else{if(c>=128&&c<=2047){d+=String.fromCharCode(((c>>6)&31)|192,(c&63)|128)}else{d+=String.fromCharCode((c>>12)|224,((c>>6)&63)|128,(c&63)|128)}}}return escape(d).replace(/\//g,"%2F").replace(/\@/g,"%40").replace(/\*/g,"%2A").replace(/\+/g,"%2B").replace(/\%/g,"$")};this.elems=[];this.urlsMapping=[];this.masterSlaves=[];this.queue=[];this.iterator=0;this.busy=false;this.placeholder="__MARKER__";this.mode="old";this.characterEncoding=true;this.xml=false;this.previewUrl="";this.previewEnabled=[];this.tmp=[];this.adserverEmissions=0;this.windowLoad=false;this.protocol="";this.browser={version:(userAgent.match(/.+(?:rv|it|ra|ie)[\/: ]([\d.]+)/)||[])[1],safari:/webkit/.test(userAgent),opera:/opera/.test(userAgent),msie:/msie/.test(userAgent)&&!/opera/.test(userAgent),mozilla:/mozilla/.test(userAgent)&&!/(compatible|webkit)/.test(userAgent)};this.config=function(cfg){this.mode=cfg.mode;this.xml=cfg.xml;this.characterEncoding=cfg.characterEncoding;if(cfg.protocol){this.protocol=cfg.protocol}else{this.protocol=location.protocol}};this.resolvId=function(id,soft){for(var i in ado.elems){var cfg=ado.elems[i].config;if(cfg){if(soft){if(cfg.orgId===id||cfg.orgId==="ado-"+id){return i}}else{if((cfg.orgId===id||cfg.orgId==="ado-"+id)&&ado.elems[i].begin===false){return i}}}}return false};this.addAdoPrefix=function(config){if(config.id.length===46){config.id="ado-"+config.id}return config};this.trimAdoPrefix=function(orgId){if(orgId.length==46){return orgId}else{if(orgId.indexOf("ado-")===0){return orgId.substring(4,50)}else{return orgId}}};this.beginCreative=function(config){var tmp=this.elems[ado.resolvId(config.id,true)];if(tmp){tmp.onServerEmission()}return tmp};this.beginExternal=function(){};this.endExternal=function(){};this.refresh=function(id){var elem=ado.elems[ado.resolvId(id,true)];if(elem.isMaster()){ado.master(elem.config);this.masterSlaves[elem.config.orgId]=[];for(var i in ado.elems){if(typeof ado.elems[i]==="object"&&ado.elems[i].config.slave&&ado.elems[i].config.myMaster===elem.config.orgId){var config=ado.elems[i].config;ado.elems[i].emptyDOMElement();ado.slave(config.orgId,config)}}}else{ado.placement(elem.config);ado.start()}};this.placement=function(config){if(!config.id||!config.server){return}if(!config.orgId){config=tuneId(config)}var test=(ado.mode=="new"&&!ado.windowLoad&&this.isBrowserSupport());if((ado.mode=="new"&&!ado.windowLoad&&this.isBrowserSupport())||ado.busy){ado.queue.unshift(function(){ado.placement(config)});return}if(ado.previewEnabled["http://"+config.server]){config.preview=true;config.server=ado.previewUrl+"?id="+ado.trimAdoPrefix(config.orgId)}this.elems[config.id]=new AdoElement(config);if(!ado.elems[config.id].DOMElement){return}this.elems[config.id].preDispatch()};this.master=function(config){config.master=true;if((ado.mode=="new"&&!ado.windowLoad&&this.isBrowserSupport())||ado.busy){ado.queue.unshift(function(){ado.master(config)});return}if(!config.orgId){config=tuneId(config)}if(typeof this.masterSlaves[config.orgId]==="undefined"){this.masterSlaves[config.orgId]=[]}this.elems[config.id]=new AdoElement(config);if(ado.previewEnabled["http://"+config.server]){config.preview=true;config.server=ado.previewUrl+"?id="+ado.trimAdoPrefix(config.orgId)}this.elems[config.id].preDispatch()};this.slave=function(fnName,config){if(!fnName||typeof fnName!=="string"||fnName===""){return}if(!config||!config.myMaster){return}if(!config.id){config.id=fnName}config.slave=true;if((ado.mode=="new"&&!ado.windowLoad&&this.isBrowserSupport())||ado.busy){ado.queue.unshift(function(){ado.slave(fnName,config)});return}if(typeof this.masterSlaves[config.myMaster]!=="object"){this.masterSlaves[config.myMaster]=[]}this.masterSlaves[config.myMaster].push(fnName);if(!config.orgId){config=tuneId(config)}this.elems[config.id]=new AdoElement(config);this.elems[config.id].getDOMElement();this.elems[config.id].emptyDOMElement();if(ado.mode==="old"||!this.isBrowserSupport()){document.write("<script type='text/javascript'>if(typeof "+config.orgId+"=='function'){"+config.orgId+"();}<\/script>");if(typeof config.onLoad==="function"){config.onLoad();config.onLoad=false}}else{this.slaveStart(config)}};this.slaveStart=function(config){eval(config.orgId);this.elems[config.id].buff='<script type="text/javascript">'+config.orgId+"();<\/script>";this.elems[config.id].begin=false;this.elems[config.id].initBuffor();this.elems[config.id].dispatch()};this.preview=function(config){if(config.enabled===false){return}config.server=config.emiter;if(config.preview!==true){config.url=ado.protocol+"//"+config.server+"/_"+(new Date()).getTime()+"/ad.js?id="+config.id}if(!config.orgId){config=tuneId(config)}if(ado.mode=="new"&&!ado.windowLoad&&ado.isBrowserSupport()){ado.queue.unshift(function(){ado.preview(config)});return}if(ado.mode=="old"){document.write('<script src="'+config.url+'"><\/script>')}else{this.elems[config.id]=new AdoElement(config);this.elems[config.id].preDispatch()}};this.turnOnPreview=function(){for(var i in ado.tmp){if(typeof ado.previewEnabled[ado.tmp[i]]!=="function"){ado.previewEnabled[ado.tmp[i]]=true}}ado.tmp=[]};this.turnOffPreview=function(){for(var i in ado.previewEnabled){if(typeof ado.previewEnabled[i]!=="function"){if(ado.previewEnabled[i]){ado.tmp.push(i)}ado.previewEnabled[i]=false}}};this.getByTag=function(n,i){if(!i){i=0}var objs=ado.getAllByTag(n);return objs[i]};this.getAllByTag=function(n){var objs=[];if(document.all){objs=document.all.tags(n)}else{if(document.getElementsByTagName){objs=document.getElementsByTagName(n)}else{if(document.layers){objs=document.layers[n]}}}return objs};this.bind=function(elem,eventName,fn){if(elem.addEventListener){elem.addEventListener(eventName,fn,false)}else{if(elem.attachEvent){elem.attachEvent("on"+eventName,fn)}else{if(document.getElementById){}}}};this.isBrowserSupport=function(){return(document.createElement&&document.appendChild&&document.getElementById)?true:false};this.evaluate=function(code){if(window.execScript){window.execScript(code);return null}var result=globalScope.eval?globalScope.eval(code):eval(code);return result};this.loadScript=function(url,callback,charset){var done=false;var script=document.createElement("script");var indexOf=url.indexOf("javascript:");if(url.indexOf("javascript:")!==-1){var fn=url.substr(indexOf);ado.evaluate(fn);callback(this);return}var onload=function(){if(!done&&(!this.readyState||this.readyState=="loaded"||this.readyState=="complete")){done=true;callback(this)}};if(ado.browser.msie){script.onreadystatechange=onload}else{script.onload=onload}script.src=url;if(typeof charset!=="undefined"&&charset!==null){script.charset=charset}if(ado.browser.msie&&ado.loadingPreviewSettings){ado.onDOMReady(function(){ado.head.appendChild(script)})}else{if(ado.busy&&script.src.indexOf("redot.js")!=-1){if(ado.browser.msie){script.onreadystatechange=function(){}}else{script.onload=function(){}}setTimeout(function(){onload()},1)}ado.head.appendChild(script)}};this.makeKeywords=function(keys){var addNuggaddKey=function(keys){if(typeof na_prof==="string"){if(keys===""){keys="/key="}else{keys+=","}keys+=na_prof}return keys};if(typeof keys==="string"){keys=keys.split(",")}var k="";if(typeof keys==="object"&&keys.length>0){for(var key in keys){if(typeof keys[key]==="string"){if(ado.characterEncoding){k+=","+keywordEncode(keys[key].toLowerCase())}else{k+=","+keys[key].toLowerCase()}}}k="/key="+k.slice(1)}k=addNuggaddKey(k);return k};this.makeVars=function(vars){var v="";if(typeof vars==="object"){for(var key in vars){if(typeof vars[key]==="string"||typeof vars[key]==="number"){v+="/"+key+"="+vars[key]}}}else{if(typeof vars==="string"){if(vars.charAt(0)!=="&"){vars="&"+vars}if(vars.charAt(vars.length-1)==="&"){vars=vars.substr(0,vars.length-1)}vars=vars.replace("&","/");while(vars.indexOf("&")!==-1){vars=vars.replace("&","/")}v=vars}}return v};this.makeFlash=function(){var fv="-";var fo=null;eval('try { f=(d==top.document)?1:2; if (typeof top.document.referrer=="string") { ref=top.document.referrer } } catch(e) {f=3;}');eval('try { fv=navigator.plugins["Shockwave Flash"].description; } catch (e) {}');eval('if (typeof ActiveXObject!="undefined") { try { fo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.7"); } catch(e) { try { fo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.6"); fv="X"; fo.AllowScriptAccess="always"; } catch(e) { if (fv=="X") { fv="WIN 6,0,20,0"; }} try { fo=new ActiveXObject("ShockwaveFlash.ShockwaveFlash"); } catch(e) {} } if ((fv=="-" || fv=="X") && fo) { fv=fo.GetVariable("$version"); }}');return"/fv="+escape(fv)};this.getById=function(id){return document.getElementById(id)};this.onDOMReady=function(readyFn){var countStyleSheets=function(){var style=ado.getAllByTag("style");var links=ado.getAllByTag("link");var j=0;for(var i in links){if(links[i].rel==="stylesheet"){j++}}return style.length+j};function bindReady(){if(document.addEventListener&&!ado.browser.opera){document.addEventListener("DOMContentLoaded",readyFn,false);ado.windowLoad=true;return}else{if(ado.browser.msie&&window==top){(function(){if(ado.windowLoad){return}try{document.documentElement.doScroll("left")}catch(error){setTimeout(arguments.callee,1);return}readyFn();ado.windowLoad=true;return})()}else{if(ado.browser.opera){document.addEventListener("DOMContentLoaded",function(){if(ado.windowLoad){return}for(var i=0;i<document.styleSheets.length;i++){if(document.styleSheets[i].disabled){setTimeout(arguments.callee,0);return}}readyFn();ado.windowLoad=true;return},false)}else{if(ado.browser.safari){var numStyles;(function(){if(ado.windowLoad){return}if(document.readyState!="loaded"&&document.readyState!="complete"){setTimeout(arguments.callee,0);return}if(numStyles===undefined){numStyles=countStyleSheets()}if(document.styleSheets.length!=numStyles){setTimeout(arguments.callee,0);return}readyFn();ado.windowLoad=true;return})()}else{window.onload=readyFn;ado.windowLoad=true;return}}}}}bindReady()};this.closeLivePreview=function(){window.location=ado.previewDisableUrl+"?url="+encodeURIComponent(encodeURIComponent(window.location.href))};this.start=function(){if(ado.queue.length>0){var fn=ado.queue.pop();if(typeof fn==="function"){fn()}}}};if(typeof ado==="undefined"){ado=new AdoContainer();if(typeof ado.head==="undefined"){ado.head=ado.getByTag("head",0)}var go=function(){ado.windowLoad=true;ado.start()};if(window.addEventListener){window.addEventListener("load",go,true)}else{if(window.attachEvent){window.attachEvent("onload",go)}else{if(document.getElementById){window.onload=go}}}}var globalScope=this;