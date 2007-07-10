/*
 * Language control
 */
var lang_ajax = new AniScript.Web.Ajax(); //ajax object
var lang_db = null; //json object
var lang_page_title = "OmniDefaultTitle";
//initialize the page
function lang_init()
{
    var lang_code = lang_get();
    if(lang_code==null)
    {
        //no language set
        //return;
        lang_code = "en-US";
    }
    var lang_options = $("lang_selector").getElementsByTagName("option");
    for(var i=0;i<lang_options.length;i++)
    {
        if(lang_code == lang_options[i].value)
            lang_options[i].selected=true;
        else
            lang_options[i].selected=false;
    }
    lang_load(lang_code);
}
//AniScript.Loader.add(lang_init);

//send a request for localization database
function lang_load(lang_code)
{
    lang_loading = true;
    $("lang_selector").disabled = true;
    $("lang_loading").innerHTML = loading_img;
    lang_ajax.setHandler(lang_load_callback);
    lang_ajax.request("/Localization/"+lang_code+".txt");
}
function lang_load_callback()
{
    if(!lang_ajax.isDone()) return;
    lang_loading = false;
    $("lang_selector").disabled = false;
    $("lang_loading").innerHTML = "";
    if(lang_ajax.hasError())
    {
        server_error = true;
    }
    else
    {
        lang_db = lang_ajax.getJSON();
        lang_display();
    }
}

//get a localized string in code (NOT RECOMMENDED)
function lang_getText(key)
{
    if(eval("lang_db."+key)!=undefined)
        return eval("lang_db."+key);
    else
        return "";
}
//get a localized string with auto update function in code (RECOMMENDED)
function lang_getHTML(key)
{
    return "<span id=\"Omni_Localized_"+key+"\">"+lang_getText(key)+"</span>";
}

//selector
function lang_select()
{
    lang_set($("lang_selector").value);
}
//set a language
function lang_set(lang_code)
{
    AniScript.Web.Cookie.create("Omni_Language",lang_code,3650);
    lang_init();
}
//get default language
function lang_get()
{
    return AniScript.Web.Cookie.read("Omni_Language");
}
//display
function lang_display()
{
    //page title
    if(eval("lang_db."+lang_page_title)!=undefined)
    {
        document.title = eval("lang_db."+lang_page_title);
    }
    
    //spans
    var spans = document.body.getElementsByTagName("span");
    for(var i=0;i<spans.length;i++)
    {
        if(spans[i].id.indexOf("Omni_Localized_")==0)
        {
            var key = spans[i].id.split("_")[2];
            if(eval("lang_db."+key)!=undefined)
                spans[i].innerHTML = eval("lang_db."+key);
        }
    }
    //divs
    var divs = document.body.getElementsByTagName("div");
    for(var i=0;i<divs.length;i++)
    {
        if(divs[i].id.indexOf("Omni_Localized_")==0)
        {
            var key = divs[i].id.split("_")[2];
            if(eval("lang_db."+key)!=undefined)
                divs[i].innerHTML = eval("lang_db."+key);
        }
    }
    //buttons
    var buttons = document.body.getElementsByTagName("button");
    for(var i=0;i<buttons.length;i++)
    {
        if(buttons[i].id.indexOf("Omni_Localized_")==0)
        {
            var key = buttons[i].id.split("_")[2];
            if(eval("lang_db."+key)!=undefined)
                buttons[i].innerHTML = eval("lang_db."+key);
        }
    }
    //textareas
    var textareas = document.body.getElementsByTagName("textarea");
    for(var i=0;i<textareas.length;i++)
    {
        if(textareas[i].id.indexOf("Omni_Localized_")==0)
        {
            var key = textareas[i].id.split("_")[2];
            if(eval("lang_db."+key)!=undefined)
                textareas[i].innerHTML = eval("lang_db."+key);
        }
    }
    //options
    var options = document.body.getElementsByTagName("option");
    for(var i=0;i<options.length;i++)
    {
        if(options[i].id.indexOf("Omni_Localized_")==0)
        {
            var key = options[i].id.split("_")[2];
            if(eval("lang_db."+key)!=undefined)
                options[i].innerHTML = eval("lang_db."+key);
        }
    }
    //optgroups
    var optgroups = document.body.getElementsByTagName("optgroup");
    for(var i=0;i<optgroups.length;i++)
    {
        if(optgroups[i].id.indexOf("Omni_Localized_")==0)
        {
            var key = optgroups[i].id.split("_")[2];
            if(eval("lang_db."+key)!=undefined)
                optgroups[i].label = eval("lang_db."+key);
        }
    }
    //inputs
    var inputs = document.body.getElementsByTagName("input");
    for(var i=0;i<inputs.length;i++)
    {
        if(inputs[i].id.indexOf("Omni_Localized_")==0)
        {
            var key = inputs[i].id.split("_")[2];
            if(eval("lang_db."+key)!=undefined)
                inputs[i].value = eval("lang_db."+key);
        }
    }
}