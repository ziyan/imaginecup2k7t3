/*
 * Page control
 */

var pool = null;
var content = null;
var content_left_center_right = null;
var content_equal_left_right = null;
var content_big_left_right = null;
var content_left_big_right = null;
var content_big_center = null;

var content_left = null;
var content_center = null;
var content_right = null;

var page_current = "";

var page_not_logged_in = ["Home","Register","HallOfFame"/*,"About"*/];
var page_logged_in = ["Home","Profile","GetIntroduced","Friends","Messages",/*"Groups",*/"HallOfFame"/*,"About"*/];
var langbar_not_logged_in = ["AutoTrans","ViewTrans"];
var langbar_logged_in = ["AutoTrans","ViewTrans","PerformTrans","RequestTrans"];

function page_init()
{
    pool = $("pool");
    content = $("content");
    content_left_center_right=$("content_left_center_right");
    content_equal_left_right=$("content_equal_left_right");
    content_big_left_right=$("content_big_left_right");
    content_left_big_right=$("content_left_big_right");
    content_big_center=$("content_big_center");
    content_left=$("content_left");
    content_center=$("content_center");
    content_right=$("content_right");
    page_location_watch();
}
//AniScript.Loader.add(page_init);

//page watcher
function page_location_watch()
{
    //detect bookmarked page and back button
    var page_name_string = "";
    if(location.href.indexOf("#")>-1)
        page_name_string=location.href.split("#")[1];    
    if(page_name_string=="")
    {
        page_change("Home");
    }
    else if(page_name_string!=page_current)
    {
        page_change(page_name_string);
    }
    setTimeout("page_location_watch()",100);
}

//clear the content
function page_clear()
{
    for(var i=0;i<content_left.childNodes.length;i++)
    {
        pool.appendChild(content_left.childNodes[i]);
    }
    for(var i=0;i<content_center.childNodes.length;i++)
    {
        pool.appendChild(content_center.childNodes[i]);
    }
    for(var i=0;i<content_right.childNodes.length;i++)
    {
        pool.appendChild(content_right.childNodes[i]);
    }
    pool.appendChild(content_left_center_right);
    pool.appendChild(content_equal_left_right);    
    pool.appendChild(content_big_left_right);
    pool.appendChild(content_left_big_right);
    pool.appendChild(content_big_center);
    pool.appendChild(content_left);
    pool.appendChild(content_center);
    pool.appendChild(content_right);
}

//layouts
function page_layout_left_center_right()
{
    content.appendChild(content_left_center_right);
    content_left_center_right.appendChild(content_left);
    content_left_center_right.appendChild(content_center);
    content_left_center_right.appendChild(content_right);
}

function page_layout_equal_left_right()
{
    content.appendChild(content_equal_left_right);
    content_equal_left_right.appendChild(content_left);
    //content_big_left_right.appendChild(content_center);
    content_equal_left_right.appendChild(content_right);
}

function page_layout_big_left_right()
{
    content.appendChild(content_big_left_right);
    content_big_left_right.appendChild(content_left);
    //content_big_left_right.appendChild(content_center);
    content_big_left_right.appendChild(content_right);
}

function page_layout_left_big_right()
{
    content.appendChild(content_left_big_right);
    content_left_big_right.appendChild(content_left);
    //content_left_big_right.appendChild(content_center);
    content_left_big_right.appendChild(content_right);
}

function page_layout_big_center()
{
    content.appendChild(content_big_center);
    //content_big_center.appendChild(content_left);
    content_big_center.appendChild(content_center);
    //content_big_center.appendChild(content_right);
}

//changing page
function page_change(page_name)
{
    if (pool === null) return; // this happens during initialization

    page_clear();
    switch(page_name)
    {
        case "Home":
            page_goto_home();
            break;
        case "Register":
            page_goto_register();
            break;
        case "Profile":
            page_goto_profile();
            break;
        case "GetIntroduced":
            page_goto_get_introduced();
            break;
        case "Friends":
            page_goto_friends();
            break;    
        case "ViewTrans":
            page_goto_view_trans();
            break;                
        default:
            page_name = "Home";
            page_goto_home();
            break;
    }
    page_current = page_name;
    location.href=hosturl+hostpage+"#"+page_current;
    page_update();
}

//updating page
function page_update()
{
    var pages = user_is_logged_in()?page_logged_in:page_not_logged_in;
    var langbarpages = user_is_logged_in()?langbar_logged_in:langbar_not_logged_in;
    var page_should_be_displayed = false;
    for(var i=0;i<pages.length;i++)
    {
        if(pages[i]==page_current)
            page_should_be_displayed=true;
        if(langbarpages[i]==page_current)
            page_should_be_displayed=true;            
    }
    if(!page_should_be_displayed)
        page_change("Home");
        
    page_update_menu();
    page_update_langbar();
    lang_update_title();
}

//updating menu
function page_update_menu()
{
    var pages = user_is_logged_in()?page_logged_in:page_not_logged_in;
    $("page_menu").innerHTML = "";
    for(var i=0;i<pages.length;i++)
    {
        var link_class = "";
        if(pages[i]==page_current) link_class="class=\"select\"";
        $("page_menu").innerHTML+="<a href=\"#\" "+link_class+" onclick=\"page_change('"+pages[i]+"');return false;\">"+lang_getHTML("MenuLink"+pages[i])+"</a>";
    }
}

//update the language bar
function page_update_langbar()
{
    var pages = user_is_logged_in()?langbar_logged_in:langbar_not_logged_in;
    $("langbarlinks").innerHTML = "";
    for(var i=0;i<pages.length;i++)
    {
        var link_class = "";
        if(pages[i]==page_current) link_class="class=\"select\"";
        if(pages[i] == "AutoTrans")
        {
            if(langbar_expanded) link_class="class=\"select\"";
            $("langbarlinks").innerHTML+="<a id=\"LangBarLink"+pages[i]+"\" href=\"#\" "+link_class+" onclick=\"langbar_auto_trans();return false;\">"+lang_getHTML("LangBarLink"+pages[i])+"</a>";
        }
        else
            $("langbarlinks").innerHTML+="<a id=\"LangBarLink"+pages[i]+"\" href=\"#\" "+link_class+" onclick=\"page_change('"+pages[i]+"');return false;\">"+lang_getHTML("LangBarLink"+pages[i])+"</a>";
    }
}

function langbar_auto_trans()
{
    langbar_expanded = !langbar_expanded;
    page_update_langbar();

    if(langbar_expanded)
    {
        $("langbar").style.height = "120px";
        $("langbar").style.background = "#ff6d06 url('Image/bg/bg_orange_120h.gif')";
        
        $("langbar").appendChild($("servicetranspanel"));
    }
    else
    {
        $("langbar").style.height = "30px";
        $("langbar").style.background = "#ff6d06 url('Image/bg/bg_orange_30h.gif')";
        
        pool.appendChild($("servicetranspanel"));
    }
}

//pages
function page_goto_home()
{
    page_layout_big_left_right();
    content_right.appendChild($("userpanel"));
    //content_center.appendChild($("servicetranspanel"));
    //content_left.appendChild($("servicedictpanel"));
    content_left.appendChild($("omnihomepanel"));
}

function page_goto_register()
{
    page_layout_big_left_right();
    content_right.appendChild($("userpanel"));
    content_left.appendChild($("userregisterpanel"));
}

function page_goto_profile()
{
    page_layout_big_left_right();
    content_right.appendChild($("userpanel"));
    content_left.appendChild($("userprofilepanel"));
    user_profile_retrieve();
}

function page_goto_get_introduced()
{
    page_layout_equal_left_right();
    content_right.appendChild($("omniprofilepanel"));
    content_left.appendChild($("get_introduced_panel"));
    omni_profile_panel_reset();
    get_introduced_retrieve();
}

function page_goto_friends()
{
    page_layout_equal_left_right();
    content_right.appendChild($("omniprofilepanel"));
    content_left.appendChild($("friendspanel"));
    omni_profile_panel_reset();
    friends_list_retrieve();    
}

function page_goto_view_trans()
{
    page_layout_equal_left_right();
    content_right.appendChild($("transdetailpanel"));
    content_left.appendChild($("viewtranspanel"));
    view_trans_init();
}