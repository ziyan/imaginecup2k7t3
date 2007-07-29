/*
 * Translation related functions
 */

var view_trans_active_tab_id = null;
function view_trans_init()
{
    var tabs = $("viewtranstab");
    var tabArray = new Array();
    if(user_is_logged_in())
    {
        tabArray.push("MyTranslations");
        tabArray.push("NeedApproval");
    }
    tabArray.push("AllTranslations");
    
    
    tabs.innerHTML = "";
    if(view_trans_active_tab_id == null)
    {
        if(user_is_logged_in()) view_trans_active_tab_id = "ViewTransTabMyTranslations";
        else view_trans_active_tab_id = "ViewTransTabAllTranslations";
    }
    for(var x=0; x<tabArray.length; x++)
    {
        var link_class = "";
        if(view_trans_active_tab_id!=null && view_trans_active_tab_id.indexOf(tabArray[x])>-1)
            link_class="class=\"select\"";
        tabs.innerHTML += "<a id=\"ViewTransTab"+tabArray[x]+"\" href=\"#\" "+link_class+" onclick=\"view_trans_tab_change('ViewTransTab"+tabArray[x]+"');return false;\">"+lang_getHTML("ViewTransTab"+tabArray[x])+"</a>";
    }
   
    // Logic
    if(view_trans_active_tab_id != null)
    {
        if(view_trans_active_tab_id.indexOf("AllTranslations")>-1)
        {
            $("viewtranspanel_searchpanel").style.display = null;
        }
        else if(view_trans_active_tab_id.indexOf("MyTranslations")>-1)
        {
            $("viewtranspanel_searchpanel").style.display = "none";
        }
        else if(view_trans_active_tab_id.indexOf("NeedApproval")>-1)
        {
            $("viewtranspanel_searchpanel").style.display = "none";
        }
    }
}

function view_trans_tab_change(str)
{
    view_trans_active_tab_id = str;
    view_trans_init();
}
