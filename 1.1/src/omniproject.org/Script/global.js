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

//alert(hosturl);


// Placeholder for localized strings
// Ex: "Welcome, __"
var localized_placeholder = "__";

// Global settings
var loading_img = "<img alt=\"\" src=\"image/loading.gif\" title=\"loading\" style=\"width:16px;height:16px\" />";
var error_img = "<img alt=\"\" src=\"image/error.gif\" title=\"error\"/>";
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

// Misc
function strIsTrue(str)
{
    return str.toLowerCase() == "true" || str == "1";
}

function roundTenths(val)
{
    return Math.round(val*10)/10;
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
    friends_list_retrieve_silent_callback = null;
    omni_profile_panel_reset();
    // trans.js
    view_trans_active_tab_id = null;
    trans_details_active_trans_id = null;
    view_trans_details_req_obj = null;
    view_trans_details_ans_obj = null;
    request_trans_message = null;
    request_trans_subject = null;
    view_trans_init(false);
    // halloffame.js
    hall_of_fame_init(false);
    // lang.js
    lang_placeholder_db = new Object();
    // messages.js
    message_details_active_msg_id = null;
    message_details_obj = null;
    messages_received_obj = null;
    messages_sent_obj = null;
    compose_message_user = null;
}
