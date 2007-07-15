// Global settings

var loading_img = "<img alt=\"\" src=\"/image/loading.gif\" title=\"loading\" style=\"width:16px;height:16px\" />";
var username_pattern = /[0-9a-zA-Z\.\-_]{3,100}$/;


// Global variables
var server_error = false;
var lang_loading = false;
var user_loading = false;
var system_languages_loading = false;
var system_interests_loading = false;

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
