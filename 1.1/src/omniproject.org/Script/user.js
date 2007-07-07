/*
 * Account related functions
 */


//some global accessible variable for user
var user_current_ajax = new AniScript.Web.Ajax(); //ajax object
var user_current_id = 0;
var user_current_username = null;
var user_current_name = null;
var user_current_email = null;
var user_current_reg_date = null;
var user_current_log_date = null;

//init function to check user status
function user_init()
{
    user_current_ajax.setHandler(user_current_callback);
    user_current_ajax.request("/handler/user/currenthandler.ashx");
    $("userpanel_not_logged_in").dispaly="none";
}
AniScript.Loader.add(user_init);

//callback from init
function user_current_callback()
{
    if(!user_current_ajax.isDone()) return;
    if(user_current_ajax.hasError())
    {
        user_current_userid = 0;
        user_current_username = null;
        user_state_update();
        return;
    }
    if(user_current_ajax.getJSON().loggedin)
    {
        user_current_id = user_current_ajax.getJSON().id;
        user_current_username = user_current_ajax.getJSON().username;
        user_current_name = user_current_ajax.getJSON().name;
        user_current_email = user_current_ajax.getJSON().email;
        user_current_reg_date = user_current_ajax.getJSON().reg_date;
        user_current_log_date = user_current_ajax.getJSON().log_date;
    }
    else
    {
        user_info_clear();
    }
    user_state_update();
}


//update site component according to user status
function user_state_update()
{
    if(user_current_id>0)
    {
        $("userpanel_not_logged_in").style.display="none";
    }
    else
    {
        $("userpanel_not_logged_in").style.display="block";
    }
}

//clear user info
function user_info_clear()
{
    user_current_id = 0;
    user_current_username = null;
    user_current_name = null;
    user_current_email = null;
    user_current_reg_date = null;
    user_current_log_date = null;
}

//user login
var user_login_ajax = new AniScript.Web.Ajax(); //ajax object
function user_login()
{
    var username = $("form_user_login_username").value;
    var password = $("form_user_login_password").value;
    
    $("userpanel_status").innerHTML="";
    //check for completion
    if(username==""||password=="")
    {
        $("userpanel_status").innerHTML="<span id=\"Omni_Localized_UserLoginStatusInfoIncomplete\" style=\"color:#993333; line-height:20px\">"+lang_getText("UserLoginStatusInfoIncomplete")+"</span>";
        return;
    }
    //check for username validity
    if(AniScript.Utility.Regex.replace(username,/[0-9a-zA-Z\.\-_]{3,100}$/,"").length!=0)
    {
        $("userpanel_status").innerHTML="<span id=\"Omni_Localized_UserLoginStatusUsernameInvalid\" style=\"color:#993333; line-height:20px\">"+lang_getText("UserLoginStatusUsernameInvalid")+"</span>";
        return;
    }
    //encrypt password
    $("userpanel_status").innerHTML=loading_img+" <span id=\"Omni_Localized_UserLoginStatusEncryptingPassword\" style=\"line-height:20px\">"+lang_getText("UserLoginStatusEncryptingPassword")+"</span>";
    var md5password = hex_md5(password);
    $("userpanel_status").innerHTML=loading_img+" <span id=\"Omni_Localized_UserLoginStatusSigningIn\" style=\"line-height:20px\">"+lang_getText("UserLoginStatusSigningIn")+"</span>";
    
    //lock all fields
    $("form_user_login_username").disabled=true;
    $("form_user_login_password").disabled=true;
    $("Omni_Localized_UserLoginSubmitButton").disabled=true;
    //ajax
    user_login_ajax.setHandler(user_login_callback);
    user_login_ajax.request("/handler/user/loginhandler.ashx","username="+escape(username)+"&md5password="+escape(md5password))
}

function user_login_callback()
{
    if(!user_login_ajax.isDone()) return;
    if(user_login_ajax.hasError())
    {
        $("userpanel_status").innerHTML="<span id=\"Omni_Localized_UserLoginStatusError\" style=\"color:#993333;line-height:20px\">"+lang_getText("UserLoginStatusError")+"</span>";
        $("form_user_login_username").disabled=false;
        $("form_user_login_password").disabled=false;
        $("Omni_Localized_UserLoginSubmitButton").disabled=false;
        user_info_clear();
        user_state_update();
        return;
    }
    var status = user_login_ajax.getJSON().status;
    if(status=="LoggedIn" || status=="AlreadyLoggedIn")
    {
        $("userpanel_status").innerHTML="<span id=\"Omni_Localized_UserLoginStatusLoggedIn\" style=\"color:green;line-height:20px\">"+lang_getText("UserLoginStatusLoggedIn")+"</span>";
        user_init();
        return;
    }
    else if(status=="Mismatch")
    {
        $("userpanel_status").innerHTML="<span id=\"Omni_Localized_UserLoginStatusMismatch\" style=\"color:#993333;line-height:20px\">"+lang_getText("UserLoginStatusMismatch")+"</span>";
    }
    else if(status=="TooManyTrial")
    {
        $("userpanel_status").innerHTML="<span id=\"Omni_Localized_UserLoginStatusTooManyTrial\" style=\"color:#993333;line-height:20px\">"+lang_getText("UserLoginStatusTooManyTrial")+"</span>";
    }
    else
    {
        $("userpanel_status").innerHTML="<span id=\"Omni_Localized_UserLoginStatusError\" style=\"color:#993333;line-height:20px\">"+lang_getText("UserLoginStatusError")+"</span>";
    }
    
    $("form_user_login_username").disabled=false;
    $("form_user_login_password").disabled=false;
    $("form_user_login_password").value = "";
    $("form_user_login_password").focus();
    $("Omni_Localized_UserLoginSubmitButton").disabled=false;
    user_info_clear();
    user_state_update();
}