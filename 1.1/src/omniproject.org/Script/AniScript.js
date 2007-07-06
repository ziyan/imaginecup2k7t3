/*
 * AniScript v.1.0.1
 * 
 * @author Ziyan Zhou
 *
 */
 
/*
 * $(id) used to get element in document
 */ 
function $(id)
{
    return document.getElementById(id);
}


/*
 * Namespace manipulates the namespaces we used
 */ 
var Namespace = new function()
{
    //create a namespace
    function add(namespacePath)
    {
	    var rootObject=window;
	    var namespaceParts=namespacePath.split('.');
	    for(var i=0;i<namespaceParts.length;i++)
	    {
		    var currentPart=namespaceParts[i];
		    if(!rootObject[currentPart])
		    {
			    rootObject[currentPart]=new Object();
		    }
		    rootObject=rootObject[currentPart];
	    }
    }        
    this.add = add;    
}

//create the namespaces we need
Namespace.add("AniScript");

Namespace.add("AniScript.Web");
Namespace.add("AniScript.Web.Ajax");
Namespace.add("AniScript.Web.Cookie");

Namespace.add("AniScript.Utility");
Namespace.add("AniScript.Utility.Uri");
Namespace.add("AniScript.Utility.Guid");
Namespace.add("AniScript.Utility.Regex");
Namespace.add("AniScript.Utility.Validator");

Namespace.add("AniScript.Math");
Namespace.add("AniScript.Loader");
Namespace.add("AniScript.Unloader");

//mapping some useful classes
AniScript.Math = Math;


/*
 * AniScript.Loader
 */ 
AniScript.Loader = new function()
{
    var handlers = new Array();
    function add(handler)
    {
        handlers[handlers.length]=handler;
    }
    function load()
    {
       for(i=0;i<handlers.length;i++)
           handlers[i]();
    }
    this.add=add;
    this.load=load;
}
if (window.addEventListener)
	window.addEventListener('load', AniScript.Loader.load, false);
else
    window.onload = AniScript.Loader.load;


/*
 * AniScript.Unloader
 */ 
AniScript.Unloader = new function()
{
    var handlers = new Array();
    function add(handler)
    {
        handlers[handlers.length]=handler;
    }
    function unload()
    {
       for(i=0;i<handlers.length;i++)
           handlers[i]();
    }
    this.add=add;
    this.unload=unload;
}
if (window.addEventListener)
	window.addEventListener('unload', AniScript.Unloader.unload, false);
else
    window.onunload = AniScript.Unloader.unload;


/*
 * AniScript.Web v.1.0.2
 * 
 * @author Ziyan Zhou
 *
 */

/*
 * AniScript.Web.Ajax
 */ 
AniScript.Web.Ajax = function(){
	var self=this;
	var AjaxObject = null;
	var AjaxHandler = null;
	function newAjax(){
		var newObj = null;
		if (window.XMLHttpRequest)
		newObj = new XMLHttpRequest();	
		else if(window.ActiveXObject)
		{
			try
			{
				newObj = new ActiveXObject("Msxml2.XMLHTTP");
			}
			catch(e)
			{
 				try
 				{
 					newObj = new ActiveXObject("Microsoft.XMLHTTP");
 				}
 				catch(e){}
			}
		}
		return newObj;
	}
	function setHandler(handler)
	{
		AjaxHandler = handler;
	}
	function request(url){
		request(url,null);
	}
	function request(url,data){
		request(url,data,null);
	}
	function request(url,data,handler){	    
		try{
		    AjaxObject = newAjax();
			if(AjaxObject==null) return false;	
			if(handler!=null) AjaxHandler = handler;
			var async = true;
			if(AjaxHandler!=null){async = true;}else{async = false;}
			if(async) AjaxObject.onreadystatechange= function(){if(isDone())AjaxHandler();};
			
			if(data!=null)
			{
				AjaxObject.open("POST",url,async);
				AjaxObject.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
		        AjaxObject.setRequestHeader("Content-length", data.length);
	  		    AjaxObject.setRequestHeader("Connection", "close");
				AjaxObject.send(data);
			}else{
				AjaxObject.open("GET",url,async);
				AjaxObject.send(null);
			}
			return true;
		}catch(e){return false;}
	}
	function getState(){
		if(AjaxObject!=null)
			return AjaxObject.readyState;		
		else
			return 0;
	}
	function getStatus(){
		if(AjaxObject!=null)
			return AjaxObject.status;		
		else
			return 0;
	}
	function isDone(){
		if(AjaxObject!=null&&getState()==4)
			return true;
		else
			return false;
	}	
	function hasError(){
		if(isDone()&&getStatus()==200)
			return false;
		else
			return true;
	}		
	function getResponseXML(){
		if(!hasError()) return AjaxObject.responseXML;
		return null;
	}
	function getResponseText(){
		if(!hasError()) return AjaxObject.responseText;
		return null;
	}
	function getRSS(){
		return getRSS(10000000);
	}
	function getRSS(num){
		try{
			var items = getResponseXML().documentElement.getElementsByTagName("item");
			var itemArray = new Array();
			
			for(i = 0;i<items.length;i++){
				try{
					var item = new Array();
					item["title"] = items[i].getElementsByTagName("title")[0].firstChild.data.toString();
					try{item["description"] = items[i].getElementsByTagName("description")[0].firstChild.data.toString();}catch(e){item["description"]="";}
					try{item["pubDate"] = items[i].getElementsByTagName("pubDate")[0].firstChild.data.toString();}catch(e){item["pubDate"]="";}
					try{item["link"] = items[i].getElementsByTagName("link")[0].firstChild.data.toString();}catch(e){item["link"]="";}
					itemArray[i] = item;
					num--;
					if(num<=0) break;
				}catch(e){}			
			}
			return itemArray;
		}catch(e){}
		return null;
	}
	function getAtom(){
		return getAtom(10000000);
	}
	
	function getAjaxObject(){
		return AjaxObject;
	}	
	function getAtom(num){
		try{
			var items = getResponseXML().documentElement.getElementsByTagName("entry");
			var itemArray = new Array();
			for(i = 0;i<items.length;i++){				
				try{
					var item = new Array();
					item["id"] = items[i].getElementsByTagName("id")[0].firstChild.data.toString();
					item["title"] = items[i].getElementsByTagName("title")[0].firstChild.data.toString();
					try{item["content"] = items[i].getElementsByTagName("content")[0].firstChild.data.toString();}catch(e){item["content"]="";}
					try{item["published"] = items[i].getElementsByTagName("published")[0].firstChild.data.toString();}catch(e){item["published"]="";}
					try{item["updated"] = items[i].getElementsByTagName("updated")[0].firstChild.data.toString();}catch(e){item["updated"]="";}
					try{item["author"] = items[i].getElementsByTagName("author")[0].getElementsByTagName("name")[0].firstChild.data.toString();}catch(e){item["author"]="";}
					try{item["link"] = items[i].getElementsByTagName("link")[0].getAttribute("href").toString();}catch(e){item["link"]="#";}
					itemArray[i] = item;
					num--;
					if(num<=0) break;

				}catch(e){}			
			}
			return itemArray;
		}catch(e){}
		return null;
	}
	function getJSON()
	{
	    if(hasError()) return null;
        return AjaxObject.responseText.parseJSON(function (key, value) {
                return key.indexOf('date') >= 0 ? new Date(value) : value;
            });
	}
	this.getAjaxObject=getAjaxObject;
	this.getRSS = getRSS;
	this.getAtom = getAtom;
	this.getResponseXML = getResponseXML;
	this.getResponseText = getResponseText;
	this.getJSON = getJSON;
	this.hasError = hasError;
	this.getState = getState;
	this.setHandler = setHandler;
	this.request = request;
	this.isDone= isDone;
	this.getStatus = getStatus;	
}
/*
 * AniScript.Web.Cookie
 */ 
AniScript.Web.Cookie = new function()
{
	function create(name,value)
	{
		AniScript.Web.Cookie.create(name,value,null);
	}

	function create(name, value, days)
	{
		var expires = "";
		if (days!=null)
		{
			var date = new Date();
			date.setTime(date.getTime()+(days*24*60*60*1000));
			expires = "; expires="+date.toGMTString();
		}
		document.cookie = name+"="+escape(value)+expires+"; path=/";
	}
	

	function read(name) {
		var nameEQ = name + "=";
		var ca = document.cookie.split(';');
		for(var i=0;i < ca.length;i++)
		{
			var c = ca[i];
			while (c.charAt(0)==' ')
				c = c.substring(1,c.length);
			if (c.indexOf(nameEQ) == 0)
				return unescape(c.substring(nameEQ.length,c.length));
		}
		return null;
	}
	
	function remove(name)
	{
		AniScript.Web.Cookie.create(name,"",-1);
	}
	
	this.create = create;
	this.read = read;
	this.remove = remove;
}



/*
 * AniScript.Web.MouseWheel
 */

AniScript.Web.MouseWheel = new function()
{
	var self=this;
	var handlers = new Array();
	function add(handler)
	{
		handlers[handlers.length]=handler;
	}
	function trig(event)
	{
		var delta = 0;
        if (!event)
			event = window.event;
        if (event.wheelDelta) {
			delta = event.wheelDelta/120;
			if (window.opera)
			delta = -delta;
        } else if (event.detail) {
	        delta = -event.detail/3;
        }
        
        var preventDefault = false;
		if(delta)
		{
			for(i=0;i<handlers.length;i++)
			{
				if(handlers[i](delta))				
					preventDefault = true;
	        }          
	        
	        if (event.preventDefault && preventDefault && handlers.length > 0)
				event.preventDefault();
	    }
        event.returnValue = !preventDefault;
	}
	this.trig = trig;
	this.add = add;
}

if (window.addEventListener)
	window.addEventListener('DOMMouseScroll', AniScript.Web.MouseWheel.trig, false);
window.onmousewheel = document.onmousewheel = AniScript.Web.MouseWheel.trig;




/*
 * AniScript.Utility v.1.0.2
 * 
 * @author Ziyan Zhou
 *
 */


/*
 * AniScript.Utility.Regex
 */
AniScript.Utility.Regex = new function()
{
    function match(value,regex)
    {
        return match(value,regex,null)
    }
    function match(value,regex,options)
    {
        var re;
        if(options!=null)        
            re=new RegExp(regex);
        else
            re=new RegExp(regex,options);
        return value.match(re);
    }
    function repalce(value,regex,replacement)
    {
        return repalce(value,regex,replacement,null)
    }
    function replace(value,regex,replacement,options)
    {
        var re;
        if(options!=null)        
            re=new RegExp(regex);
        else
            re=new RegExp(regex,options);
        return value.replace(re,replacement);
    }
    function matches(value,regex)
    {
        return matches(value,regex,null)
    }
    function matches(value,regex,options)
    {
        var re;
        if(options!=null)        
            re=new RegExp(regex);
        else
            re=new RegExp(regex,options);
        return re.exec(value);
    }
    this.match=match;
    this.matches=matches;
    this.replace=replace;
}


/*
 * AniScript.Utility.Validator
 */
AniScript.Utility.Validator = new function()
{
    function isEmail(email)
    {        
        return email!=null&&email!=""&&AniScript.Utility.Regex.replace(email,/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/,"").length==0;
    }
    function isInteger(integer)
    {
        return integer!=null&&integer!=""&&AniScript.Utility.Regex.replace(integer,/[0-9]+$/,"").length==0;
    }
    this.isEmail=isEmail;
    this.isInteger = isInteger;
}









/*
 * AniScript.Utility.Guid
 */
AniScript.Utility.Guid=function(g)
{
	var self=this;
	var guid=g||'00000000-0000-0000-0000-000000000000';
	
	this.compareTo=function(value)
	{
		if(guid<value.toString())
		{
			return-1;
		}
		else if(guid>value.toString())
		{
			return 1;
		}
		return 0;
	}
	
	this.equals=function(g)
	{
		return(guid==g.toString());
	}
	this.toString=function()
	{
		return guid;
	}
}

AniScript.Utility.Guid.createEmpty=function()
{
	return new AniScript.Utility.Guid('00000000-0000-0000-0000-000000000000');
}

AniScript.Utility.Guid.createNew=function()
{
	var guid="";
	var characters="0123456789abcdef";
	var parts=[8,4,4,4,12];
	for(var i=0;i<parts.length;++i)
	{
		for(var j=0;j<parts[i];++j)
		{
			var index=Math.round(Math.random()*16);guid+=characters.charAt(index);
		}
		if(i!=parts.length-1)
		{
			guid+="-"
		}
	}
	return new AniScript.Utility.Guid(guid);
}





/*
 * AniScript.Utility.String
 */
AniScript.Utility.String=function(){}
AniScript.Utility.String.createEmpty=function()
{
	return ""
}
AniScript.Utility.String.format=function()
{
	var params=AniScript.Utility.String.format.arguments;
	var myString=params[0];
	for(var i=1;i<params.length;i++)
	{
		var regex=new RegExp('\\{'+(i-1)+'\\}','g');
		myString=myString.replace(regex,params[i].toString());
	}
	return myString;
}


/*
 * AniScirpt.Utility.Uri
 */

AniScript.Utility.Uri=function(uriString)
{
	var self=this;
	var absoluteUri=uriString;
	var regex=/(\w+):\/\/([\w:.]+)\/(\S*)/;
	function getDefaultPort(scheme)
	{
		switch(scheme)
		{
			case'file':return'';
			case'ftp':return 21;
			case'gopher':return 70;
			case'http':return 80;
			case'https':return 443;
			case'mailto':return 25;
			case'news':return 119;
			case'nntp':return 119;
			default:return'';
		}
	}
	this.getAbsolutePath=function()
	{
		return absoluteUri.match(regex)[3];
	}
	this.getAbsoluteUri=function()
	{
		return absoluteUri;
	}
	this.getAuthority=function()
	{
		var authority=self.getHost();
		if(!self.isDefaultPort())
		{
		authority+=':'+self.getPort();
		}
		return authority;
	}
	this.getFragment=function()
	{
		return absoluteUri.substring(absoluteUri.indexOf('#'));
	}
	this.getHost=function()
	{
		return absoluteUri.match(regex)[2].split(':')[0];
	}
	this.getPathAndQuery=function()
	{
		return self.getAbsolutePath()+self.getQuery();
	}
	this.getPort=function()
	{
		if(absoluteUri.match(regex)[2].split(':')[1])
		{
			return parseInt(absoluteUri.match(regex)[2].split(':')[1]);
		}
		else
		{
			return getDefaultPort(self.getScheme());
		}
	}
	this.getQuery=function()
	{
		if(absoluteUri.indexOf('?')>-1)
			return absoluteUri.substring(absoluteUri.indexOf('?'));
		else
			return "";
	}
	this.getQueryParameters=function()
	{
		var parameters={};
		var myUri=absoluteUri;
		var q=myUri.indexOf("?");
		if(q<0)
		{
			return parameters;
		}
		myUri=myUri.substring(q+1);
		var pairs=myUri.split("&");
		for(var i=0;i<pairs.length;i++)
		{
			var keyval=pairs[i].split("=");
			parameters[keyval[0]]=decodeURIComponent(keyval[1]);
		}
		return parameters;
	}
	this.getScheme=function()
	{
		return absoluteUri.match(regex)[1].toLowerCase();
	}
	this.isDefaultPort=function()
	{
		return(self.getPort()==getDefaultPort(self.getScheme()));
	}
	this.isFile=function()
	{
		return(self.getScheme()=='file');
	}
	this.isLoopback=function()
	{
		var host=self.getHost();
		if(host=='127.0.0.1'||host=='loopback'||host=='localhost')
		{
			return true;
		}
		return false;
	}
}
//uncomment this to see if there is grammer error
//alert("Testing");