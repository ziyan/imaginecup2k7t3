﻿/*
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
    user_loading = true;
    $("userpanel_not_logged_in").style.display="none";
    $("usermenu").innerHTML = loading_img + " " + lang_getHTML("UserMenuLoading");
    user_current_ajax.setHandler(user_current_callback);
    user_current_ajax.request("/handler/user/currenthandler.ashx");
}
//AniScript.Loader.add(user_init);

//callback from init
function user_current_callback()
{
    if(!user_current_ajax.isDone()) return;
    user_loading = false;
    if(user_current_ajax.hasError())
    {
        server_error = true;
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
        //logged in
        $("usermenu").innerHTML=lang_getHTML("UserMenuWelcome")+user_current_name+" | <a href=\"#\" onclick=\"user_logout();return false\">"+lang_getHTML("UserMenuLogout")+"</a> ";
        $("userpanel_not_logged_in").style.display="none";
        
        //clear the form
        $("form_user_login_username").disabled=false;
        $("form_user_login_username").value="";
        $("form_user_login_password").disabled=false;
        $("form_user_login_password").value="";
        $("Omni_Localized_UserLoginSubmitButton").disabled=false;
        $("userpanel_status").innerHTML="";
    }
    else
    {
        //not logged in
        $("usermenu").innerHTML="<a href=\"#\" onclick=\"page_change('Register');return false\">"+lang_getHTML("UserMenuRegister")+"</a> ";
        $("userpanel_not_logged_in").style.display="block";
        
        
    }
    page_update_menu();
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
var user_login_ajax = null; //ajax object
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
    if(AniScript.Utility.Regex.replace(username,username_pattern,"").length!=0)
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
    if(user_login_ajax==null) user_login_ajax = new AniScript.Web.Ajax();
    user_login_ajax.setHandler(user_login_callback);
    user_login_ajax.request("/handler/user/loginhandler.ashx","username="+escape(username)+"&md5password="+escape(md5password));
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
        page_change('Home');
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


//user logout
var user_logout_ajax = null; //ajax object
function user_logout()
{
    if(user_logout_ajax == null) user_logout_ajax = new AniScript.Web.Ajax();
    user_logout_ajax.setHandler(user_logout_callback);
    user_logout_ajax.request("/handler/user/logouthandler.ashx");
    $("usermenu").innerHTML = loading_img + lang_getHTML("UserMenuLoggingOut");
}
function user_logout_callback()
{
    if(!user_logout_ajax.isDone()) return;
    user_info_clear();
    user_state_update();
}


//user register
var user_register_ajax = null; //ajax object
function user_register()
{
    $("userregisterpanel_status").innerHTML="";
    if(!$("form_user_register_agree").checked)
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusDisagree\" style=\"color:#993333\">"+lang_getText("UserRegisterStatusDisagree")+"</span>";
        return;
    }
    //fields
    var name = $("form_user_register_name").value;
    var email = $("form_user_register_email").value;
    var username = $("form_user_register_username").value;
    var password = $("form_user_register_password").value;
    var password2 = $("form_user_register_password2").value;
    var captcha = $("form_user_register_captcha").value;
    
    if(name==""||email==""||username==""||password==""||password2==""||captcha=="")
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusInfoIncomplete\" style=\"color:#993333\">"+lang_getText("UserRegisterStatusInfoIncomplete")+"</span>";
        return;
    }
    if(!AniScript.Utility.Validator.isEmail(email))
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusEmailInvalid\" style=\"color:#993333\">"+lang_getText("UserRegisterStatusEmailInvalid")+"</span>";
        $("form_user_register_email").focus();
        return;
    }
    if(AniScript.Utility.Regex.replace(username,username_pattern,"").length!=0)
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusUsernameInvalid\" style=\"color:#993333\">"+lang_getText("UserRegisterStatusUsernameInvalid")+"</span>";
        $("form_user_register_username").focus();
        return;
    }
    if(password.length<6)
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusPasswordShort\" style=\"color:#993333\">"+lang_getText("UserRegisterStatusPasswordShort")+"</span>";
        $("form_user_register_password").focus();
        return;
    }
    if(password!=password2)
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusPasswordsDiffer\" style=\"color:#993333\">"+lang_getText("UserRegisterStatusPasswordsDiffer")+"</span>";
        $("form_user_register_password2").focus();
        return;
    }
    if(captcha.length!=5)
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusCaptchaInvalid\" style=\"color:#993333\">"+lang_getText("UserRegisterStatusCaptchaInvalid")+"</span>";
        $("form_user_register_captcha").focus();
        return;
    }

    //encrypt password
    $("userregisterpanel_status").innerHTML=loading_img+" <span id=\"Omni_Localized_UserRegisterStatusEncryptingPassword\" style=\"line-height:20px\">"+lang_getText("UserRegisterStatusEncryptingPassword")+"</span>";
    var md5password = hex_md5(password);
    $("userregisterpanel_status").innerHTML=loading_img+" <span id=\"Omni_Localized_UserRegisterStatusRegistering\" style=\"line-height:20px\">"+lang_getText("UserRegisterStatusRegistering")+"</span>";
    
    //lock all fields
    $("form_user_register_name").disabled=true;
    $("form_user_register_username").disabled=true;
    $("form_user_register_email").disabled=true;
    $("form_user_register_password").disabled=true;
    $("form_user_register_password2").disabled=true;
    $("form_user_register_captcha").disabled=true;
    $("Omni_Localized_UserRegisterSubmitButton").disabled=true;
    //ajax
    if(user_register_ajax == null) user_register_ajax = new AniScript.Web.Ajax();
    user_register_ajax.setHandler(user_register_callback);
    user_register_ajax.request("/handler/user/registerhandler.ashx","username="+escape(username)+"&md5password="+escape(md5password)+"&email="+escape(email)+"&name="+escape(name)+"&captcha="+escape(captcha));
}
function user_register_callback()
{
    if(!user_register_ajax.isDone()) return;
    if(user_register_ajax.hasError())
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusError\" style=\"color:#993333;\">"+lang_getText("UserRegisterStatusError")+"</span>";
        return;
    }
    $("form_user_register_name").disabled=false;
    $("form_user_register_username").disabled=false;
    $("form_user_register_email").disabled=false;
    $("form_user_register_password").disabled=false;
    $("form_user_register_password2").disabled=false;
    $("form_user_register_captcha").disabled=false;
    $("form_user_register_captcha").value="";
    $("Omni_Localized_UserRegisterSubmitButton").disabled=false;
    user_register_update_captcha();
    
    var status = user_register_ajax.getJSON().status;
    if(status=="Registered")
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusRegistered\" style=\"color:green;\">"+lang_getText("UserRegisterStatusRegistered")+"</span>";
        $("form_user_register_name").value="";
        $("form_user_register_username").value="";
        $("form_user_register_email").value="";
        $("form_user_register_password").value="";
        $("form_user_register_password2").value="";
        $("form_user_register_captcha").value="";
    }
    else if(status=="AlreadyLoggedIn")
    {
        page_change('Home');
        user_init();
        return;
    }
    else if(status=="InvalidCaptcha")
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusCaptchaMismatch\" style=\"color:#993333;\">"+lang_getText("UserRegisterStatusCaptchaMismatch")+"</span>";
        $("form_user_register_captcha").focus();
    }
    else if(status=="DuplicateUsername")
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusDuplicateUsername\" style=\"color:#993333;\">"+lang_getText("UserRegisterStatusDuplicateUsername")+"</span>";
        $("form_user_register_username").focus();
    }
    else if(status=="DuplicateEmail")
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusDuplicateEmail\" style=\"color:#993333;\">"+lang_getText("UserRegisterStatusDuplicateEmail")+"</span>";
        $("form_user_register_email").focus();
    }
    else
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusError\" style=\"color:#993333;\">"+lang_getText("UserRegisterStatusError")+"</span>";
    }
}
function user_register_update_captcha()
{
    $('userregisterpanel_captcha').src='/handler/user/captchahandler.ashx?width=200&height=80&date='+escape(new Date());
}
function user_is_logged_in()
{
    return user_current_id>0;
}