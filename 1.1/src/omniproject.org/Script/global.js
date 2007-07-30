// Site URL for debugging
var hostpage = "";
var hosturl = location.href.toLowerCase();
if(hosturl.indexOf("index.htm") >= 0)
{
    hosturl = hosturl.substring(0,hosturl.indexOf("index.htm"));
    hostpage = "index.htm";
}
else
{
    if(hosturl.indexOf("#") >= 0)
    {
        hosturl = hosturl.substring(0,hosturl.indexOf("#"));
    }
    if(hosturl.charAt(hosturl.length-1) != "/") hosturl = hosturl + "/";
}

// Global settings
var loading_img = "<img alt=\"\" src=\"image/loading.gif\" title=\"loading\" style=\"width:16px;height:16px\" />";
var username_pattern = /[0-9a-zA-Z\.\-_]{3,100}$/;


// Global variables
var server_error = false;
var lang_loading = false;
var user_loading = false;
var system_languages_loading = false;
var system_interests_loading = false;

// Language bar status
var langbar_expanded = false;
var langbar_results = false;

// Input validation
function stripHTML(str) {
    return str.replace(/(<([^>]+)>)/ig,"");
}

// Newline correction for string <-> html
function newlnString2HTML(str) {
    return str.replace(/\n/g,"<br>");
}

function newlnHTML2String(str) {
    return str.replace(/<br>/g,"\n");
}

// Clear globally cached results on logout
function clear_cached_results()
{
    // user.js
    user_temp_languages = null;
    user_temp_language_skills = null;
    // friends.js
    omni_profile_panel_user = null;
    friends = null;
    friends_search_results_users = null;
    get_introduced_results = null;
    friends_removed_friend = null;
    friends_added_friend = null;
    // trans.js
    view_trans_active_tab_id = null;
    view_trans_active_trans_id = null;
    view_trans_details_req_obj = null;
    view_trans_details_ans_obj = null;
    view_trans_init();
}
