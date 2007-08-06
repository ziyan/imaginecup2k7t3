/*
 * Account related functions
 */


//some global accessible variable for user
var user_current_ajax = new AniScript.Web.Ajax(); //ajax object
var user_current_interests_ajax = null; //ajax object
var user_current_languages_ajax = null; //ajax object
var user_current_id = 0;
var user_current_obj = null;
var user_current_summary_obj = null;
var user_current_summary_ajax = new AniScript.Web.Ajax(); //ajax object

var user_current_obj_lang = null; // IDs only.
// This is pulled over on with UserCurrent, unlike user_current_languages

var user_current_languages = null;
var user_current_interests = null;

//init function to check user status
function user_init()
{
    user_loading = true;
    //$("userpanel_not_logged_in").style.display="none";
    $("usermenu").innerHTML = loading_img + " " + lang_getHTML("UserMenuLoading");
    user_current_ajax.setHandler(user_current_callback);
    user_current_ajax.request(hosturl+"handler/user/currenthandler.ashx");
}
//AniScript.Loader.add(user_init);

//callback from profile update
function user_current_callback()
{
    if(!user_current_ajax.isDone()) return;
    user_loading = false;
    if(user_current_ajax.hasError())
    {
        server_error = true;
        user_current_userid = 0;
        user_state_update();
        return;
    }
    if(user_current_ajax.getJSON().loggedin)
    {
        user_current_id = user_current_ajax.getJSON().user.id;
        user_current_obj = user_current_ajax.getJSON().user;
        user_current_obj_lang = user_current_ajax.getJSON().user_lang;
        //user_current_summary_obj = user_current_ajax.getJSON().summary;
    }
    else
    {
        user_info_clear();
    }
    user_state_update();
}

function user_summary_retrieve()
{
    if(!user_is_logged_in()) return;
    
    $("usercontrolpanel_status").innerHTML = loading_img + " " + lang_getHTML("UserControlPanelLoading");
    $("usercontrolpanel_complete").style.display = "none";
    
    user_current_summary_ajax.setHandler(user_summary_callback);
    user_current_summary_ajax.request(hosturl+"handler/user/summaryhandler.ashx","user_id="+user_current_id);
}

function user_summary_callback()
{
    if(!user_current_summary_ajax.isDone()) return;
    if(user_current_summary_ajax.hasError())
    {
        $("usercontrolpanel_status").innerHTML = "<span id=\"Omni_Localized_UserControlPanelStatusError\" style=\"color:#993333;line-height:20px\">"+lang_getText("UserControlPanelStatusError")+"</span>";
        return;
    }
    if(user_current_summary_ajax.getJSON().status=="OK")
    {
        user_current_summary_obj = user_current_summary_ajax.getJSON().summary;
        $("usercontrolpanel_status").innerHTML = "";
        $("usercontrolpanel_complete").style.display = "";
        user_control_panel_init();
    }
    else
    {
        $("usercontrolpanel_status").innerHTML = "<span id=\"Omni_Localized_UserControlPanelStatusError\" style=\"color:#993333;line-height:20px\">"+lang_getText("UserControlPanelStatusError")+"</span>";
    }
}

//check if user is logged in
function user_is_logged_in()
{
    return user_current_id>0;
}

//update site component according to user status
function user_state_update()
{
    if(user_is_logged_in())
    {
        //logged in
        $("usermenu").innerHTML=lang_getHTML("UserMenuWelcome")+user_current_obj.name+" | <a href=\"#\" onclick=\"user_logout();return false\">"+lang_getHTML("UserMenuLogout")+"</a> ";
        $("userpanel_not_logged_in").style.display="none";
        $("userpanel_logged_in").style.display="block";
        $("omnihomepanel_not_logged_in").style.display="none";
        $("omnihomepanel_logged_in").style.display="block";
        
        //clear the form
        $("form_user_login_username").disabled=false;
        $("form_user_login_username").value="";
        $("form_user_login_password").disabled=false;
        $("form_user_login_password").value="";
        $("Omni_Localized_UserLoginSubmitButton").disabled=false;
        $("userpanel_status").innerHTML="";
        
        home_init(); // Re-initialize home page
        
        if(page_current == "Home")
        {
            if(user_is_logged_in())
                page_layout_equal_left_right();
            else page_layout_big_left_right();
        }
        
        page_update();
    }
    else
    {
        //not logged in
        $("usermenu").innerHTML="<a href=\"#\" onclick=\"page_change('Register');return false\">"+lang_getHTML("UserMenuRegister")+"</a> | <a href=\"#\" onclick=\"page_change('Home');return false\">"+lang_getHTML("UserMenuLogin")+"</a> ";
        $("userpanel_not_logged_in").style.display="block";
        $("userpanel_logged_in").style.display="none";
        $("omnihomepanel_not_logged_in").style.display="block";
        $("omnihomepanel_logged_in").style.display="none";
        
        if(page_current == "Home")
        {
            if(user_is_logged_in())
                page_layout_equal_left_right();
            else page_layout_big_left_right();
        }
        
        page_update(); 
    }
}

//clear user info
function user_info_clear()
{
    user_current_id = 0;
    user_current_obj = null;
    user_current_summary_obj = null;
    user_current_obj_lang = null;
    user_current_interests = null;
    user_current_languages = null;
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
    user_login_ajax.request(hosturl+"handler/user/loginhandler.ashx","username="+escape(username)+"&md5password="+escape(md5password));
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


//user logout
var user_logout_ajax = null; //ajax object
function user_logout()
{
    if(user_logout_ajax == null) user_logout_ajax = new AniScript.Web.Ajax();
    user_logout_ajax.setHandler(user_logout_callback);
    user_logout_ajax.request(hosturl+"handler/user/logouthandler.ashx");
    //$("usermenu").innerHTML = loading_img + lang_getHTML("UserMenuLoggingOut");
    user_info_clear();
    
    // Clear cache of any saved data from last user
    clear_cached_results();    
    user_state_update();
}
function user_logout_callback()
{
    //if(!user_logout_ajax.isDone()) return;
}



function home_init()
{
    var title = $("Omni_Localized_UserPanelTitle");
    if(title != undefined && title != null && user_current_obj != null)
    {
        title.innerHTML = lang_fill_placeholder("UserPanelTitle", user_current_obj.name);
    }
    else title.innerHTML = lang_fill_placeholder("UserPanelTitle", "");
    
    user_summary_retrieve();
}

function user_control_panel_init()
{
    if(!user_is_logged_in()) return;
    if(user_current_summary_obj == null) return;
    
    var has_updated_profile = user_current_summary_obj.has_updated_profile
    var unread_msgs = user_current_summary_obj.unread_msgs;
    var open_personal_trans_req = user_current_summary_obj.open_personal_trans_req;
    var trans_req_to_approve = user_current_summary_obj.trans_req_to_approve;
    var open_global_trans_req = user_current_summary_obj.open_global_trans_req;
    
    if(has_updated_profile == 0)
    {
        $("usercontrolpanel_updateprofile").style.display = '';
    }
    else
    {
        $("usercontrolpanel_updateprofile").style.display = 'none';
    }
    
    if(trans_req_to_approve == 0)
    {
        $("usercontrolpanel_approvetrans0").style.display = '';
        $("usercontrolpanel_approvetrans1").style.display = 'none';
        $("usercontrolpanel_approvetrans2").style.display = 'none';        
    }
    else if(trans_req_to_approve == 1)
    {
        $("usercontrolpanel_approvetrans0").style.display = 'none';
        $("usercontrolpanel_approvetrans1").style.display = '';
        $("usercontrolpanel_approvetrans2").style.display = 'none';        
    }
    else
    {
        $("usercontrolpanel_approvetrans0").style.display = 'none';
        $("usercontrolpanel_approvetrans1").style.display = 'none';
        $("usercontrolpanel_approvetrans2").style.display = ''; 
        
        $("Omni_Localized_UserControlPanelApproveTrans2").innerHTML = lang_fill_placeholder("UserControlPanelApproveTrans2", trans_req_to_approve);      
    } 
    
    if(unread_msgs == 0)
    {
        $("usercontrolpanel_unreadmsgs0").style.display = '';
        $("usercontrolpanel_unreadmsgs1").style.display = 'none';
        $("usercontrolpanel_unreadmsgs2").style.display = 'none';        
    }
    else if(unread_msgs == 1)
    {
        $("usercontrolpanel_unreadmsgs0").style.display = 'none';
        $("usercontrolpanel_unreadmsgs1").style.display = '';
        $("usercontrolpanel_unreadmsgs2").style.display = 'none';        
    }
    else
    {
        $("usercontrolpanel_unreadmsgs0").style.display = 'none';
        $("usercontrolpanel_unreadmsgs1").style.display = 'none';
        $("usercontrolpanel_unreadmsgs2").style.display = ''; 
        
        $("Omni_Localized_UserControlPanelUnreadMsgs2").innerHTML = lang_fill_placeholder("UserControlPanelUnreadMsgs2", unread_msgs);      
    }     
    
    if(has_updated_profile != 0)
    {
        $("usercontrolpanel_globalreq").style.display = '';
        $("Omni_Localized_UserControlPanelGlobalReq").innerHTML = lang_fill_placeholder("UserControlPanelGlobalReq", open_global_trans_req);
    }
    else $("usercontrolpanel_globalreq").style.display = 'none';
    
    if(open_personal_trans_req == 1)
    {
        $("usercontrolpanel_personalreq1").style.display = '';
        $("usercontrolpanel_personalreq2").style.display = 'none';        
    }
    else
    {
        $("usercontrolpanel_personalreq1").style.display = 'none';
        $("usercontrolpanel_personalreq2").style.display = ''; 
        $("Omni_Localized_UserControlPanelPersonalReq2").innerHTML = lang_fill_placeholder("UserControlPanelPersonalReq2", open_personal_trans_req);      
    }     
    
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
    user_register_ajax.request(hosturl+"handler/user/registerhandler.ashx","username="+escape(username)+"&md5password="+escape(md5password)+"&email="+escape(email)+"&name="+escape(name)+"&captcha="+escape(captcha));
}
function user_register_callback()
{
    if(!user_register_ajax.isDone()) return;
    $("form_user_register_name").disabled=false;
    $("form_user_register_username").disabled=false;
    $("form_user_register_email").disabled=false;
    $("form_user_register_password").disabled=false;
    $("form_user_register_password2").disabled=false;
    $("form_user_register_captcha").disabled=false;
    $("form_user_register_captcha").value="";
    $("Omni_Localized_UserRegisterSubmitButton").disabled=false;
    if(user_register_ajax.hasError())
    {
        $("userregisterpanel_status").innerHTML="<span id=\"Omni_Localized_UserRegisterStatusError\" style=\"color:#993333;\">"+lang_getText("UserRegisterStatusError")+"</span>";
        return;
    }
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
    $('userregisterpanel_captcha').src=hosturl+'handler/user/captchahandler.ashx?width=200&height=80&date='+escape(new Date());
}
function user_register_reset()
{
    $("userregisterpanel_status").innerHTML="";
    user_register_update_captcha();
}







// user profile
function user_profile_retrieve()
{
    if(user_current_obj != null)
    {
        $("form_user_profile_username").innerHTML = user_current_obj.username;
        $("form_user_profile_name").value = user_current_obj.name;
        $("form_user_profile_email").value = user_current_obj.email;
        $("form_user_profile_description").value = user_current_obj.description;
        $("form_user_profile_sn_network").value = user_current_obj.sn_network;
        $("form_user_profile_sn_screenname").value = user_current_obj.sn_screenname;
        $("form_user_profile_interests").innerHTML = loading_img+" "+lang_getHTML("UserProfileLoading","Interest");
        $("form_user_profile_languages").innerHTML = loading_img+" "+lang_getHTML("UserProfileLoading","Language");
        $("Omni_Localized_UserProfileSubmitButton").disabled = true;
        // ajax
        if(user_current_interests_ajax == null) user_current_interests_ajax = new AniScript.Web.Ajax();
        user_current_interests_ajax.setHandler(user_current_interests_callback);
        user_current_interests_ajax.request(hosturl+"handler/user/interestshandler.ashx","user_id="+escape(user_current_id));
        if(user_current_languages_ajax == null) user_current_languages_ajax = new AniScript.Web.Ajax();
        user_current_languages_ajax.setHandler(user_current_languages_callback);
        user_current_languages_ajax.request(hosturl+"handler/user/languageshandler.ashx","user_id="+escape(user_current_id));
    }
}
function user_current_interests_callback()
{
    if(!user_current_interests_ajax.isDone()) return;
    $("Omni_Localized_UserProfileSubmitButton").disabled = false;
    if(user_current_interests_ajax.hasError())
    {
        $("form_user_profile_interests").innerHTML="<span id=\"Omni_Localized_UserProfileStatusError_Int\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusError")+"</span>";
        user_current_interests = null;
        return;
    }    
    var status = user_current_interests_ajax.getJSON().status;
    if(status=="OK")
    {
        user_current_interests = user_current_interests_ajax.getJSON().interests;
        $("form_user_profile_interests").innerHTML = system_interests_table("userprofilepanel");
        // Add checkboxes
        for(var x=0; x<system_interests.length; x++)
        {
            var cell = $("userprofilepanel_interest_"+system_interests[x].id);
            if(cell != undefined)
            {
                var chk = document.createElement("INPUT");
                chk.setAttribute("type","checkbox");
                chk.setAttribute("value",system_interests[x].id);
                chk.setAttribute("id","userprofilepanel_interest_"+system_interests[x].id+"_chk");
                chk.setAttribute("defaultChecked",false);
                cell.appendChild(chk);
                cell.width = 20;
            }
        }
        for(var x=0; x<user_current_interests.length; x++)
        {
            var chk = $("userprofilepanel_interest_"+user_current_interests[x]/*.id*/+"_chk");
            if(chk != null && chk != undefined)
                chk.checked = true;
        }
    }
    else
    {
        $("form_user_profile_interests").innerHTML="<span id=\"Omni_Localized_UserProfileStatusError_Int\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusError")+"</span>";
        user_current_interests = null;
    }    
}

var user_temp_languages = null;
var user_temp_language_skills = null;

function user_profile_lang_add(id)
{
    user_profile_update_temp_lang_skills();
    user_temp_languages.push(id);
    get_user_current_language_html();
}

function user_profile_lang_remove(id)
{
    user_profile_update_temp_lang_skills();
    var myArray = new Array();
    for(var x=0; x<user_temp_languages.length; x++)
    {
        if(user_temp_languages[x] != id)
            myArray.push(user_temp_languages[x]);
    }
    user_temp_languages = myArray;
    get_user_current_language_html();
}

function user_profile_update_temp_lang_skills()
{
    for(var i=0;i<user_temp_languages.length; i++)
    {
        for(var k=1; k<=5; k++)
        {
            var myId = "UserProfileLangRating_"+user_temp_languages[i]+"_"+k;
            var myObj = $(myId);
            if(myObj != null && myObj != undefined)
            {
                if(myObj.checked)
                {
                    user_temp_language_skills[user_temp_languages[i]] = k;
                    break;
                }
            }
        }
    }
}

function get_user_current_language_html()
{
    var html = "";
    
    user_temp_languages.sort();
    
    if(user_temp_languages.length < system_languages.length)
    {
        html += "<select id=\"userprofile_langdd\" size=\"1\">";
        for(var i=0; i<system_languages.length;i++)
        {
            var remove = false;
            for(var j=0;j<user_temp_languages.length;j++)
            {
                if(user_temp_languages[j] == system_languages[i].id)
                {
                    remove = true;
                    break;
                }
            }
            if(!remove)
                html += "<option id=\"Omni_Localized_LanguageName"+system_languages[i].short_code+"\" value=\""+system_languages[i].id+"\">"+sys_lang_by_short_code(system_languages[i].short_code, "EditProfileLangDD")+"</option>";
        }
        html += "</select>&nbsp;&nbsp;&nbsp;&nbsp;";
        html += "<a href=\"#\" onclick=\"user_profile_lang_add($('userprofile_langdd').options[$('userprofile_langdd').selectedIndex].value); return false\">"+lang_getHTML("UserProfileLanguagesAdd")+"</a>";
    }
    html += "<br/>";
    
    if(user_temp_languages.length>0)
        html += "<table class=\"detailtable\" cellpadding=\"2\"><th>"+lang_getHTML("UserProfileLanguagesLanguage")+"</th><th>"+lang_getHTML("UserProfileLanguagesSkill")+"</th><th></th>";
    for(var i=0; i<user_temp_languages.length; i++)
    {
        var rating = 1;
        var ratingObj = null;
        if(user_temp_language_skills != null && user_temp_language_skills != undefined)
            ratingObj = user_temp_language_skills[user_temp_languages[i]];
        if(ratingObj != null && ratingObj != undefined) {
            rating = ratingObj; }
    
        html += "<tr><td>"+sys_lang_by_id(user_temp_languages[i],"UserProfileLang"+i,true)+"</td>";
        html += "<td style=\"font-size: 100%;\">";
        for(var k=1; k<=5; k++)
        {
            var chk = "";
            if(k == rating) chk = " checked ";
            html += "<input type=\"radio\" "+chk+" name=\"UserProfileLang"+user_temp_languages[i]+"\" id=\"UserProfileLangRating_"+user_temp_languages[i]+"_"+k+"\" value=\""+k+"\"> "+k;
            if(k<5) html += " | ";
        }
        html += "</td>";
        html += "<td><a href=\"#\" onclick=\"user_profile_lang_remove("+user_temp_languages[i]+"); return false\">"+lang_getHTML("UserProfileLanguagesRemove")+"</a></td></tr>";
    }
    if(user_temp_languages.length>0)
        html += "</table>";
    //html += "<br/>";
    
    $("form_user_profile_languages").innerHTML = html;
}

function user_current_languages_callback()
{
    if(!user_current_languages_ajax.isDone()) return;
    $("Omni_Localized_UserProfileSubmitButton").disabled = false;
    if(user_current_languages_ajax.hasError())
    {
        $("form_user_profile_languages").innerHTML="<span id=\"Omni_Localized_UserProfileStatusError_Lang\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusError")+"</span>";
        user_current_languages = null;
        user_temp_languages = null;
        return;
    }    
    var status = user_current_languages_ajax.getJSON().status;
    if(status=="OK")
    {
        user_current_languages = user_current_languages_ajax.getJSON().languages;
        //$("form_user_profile_languages").innerHTML = user_current_languages.toJSONString();
        user_temp_languages = new Array();
        user_temp_language_skills = new Object();
        for(var x=0;x<user_current_languages.length;x++)
        {
            user_temp_languages.push(user_current_languages[x].lang_id);
            user_temp_language_skills[user_current_languages[x].lang_id] = user_current_languages[x].self_rating;
        }
        get_user_current_language_html();
    }
    else
    {
        $("form_user_profile_languages").innerHTML="<span id=\"Omni_Localized_UserProfileStatusError_Lang\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusError")+"</span>";
        user_current_languages = null;
        user_temp_languages = null;
    }        
}






function user_profile_reset()
{
    $("userprofilepanel_status").innerHTML="";
    user_profile_retrieve();
}

var user_update_ajax = null; //ajax object
var user_update_interests_ajax = null; //ajax object
var user_update_languages_ajax = null; //ajax object

function user_update()
{
    $("userprofilepanel_status").innerHTML="";
    // fields
    var name = $("form_user_profile_name").value.slice(0,100);
    var email = $("form_user_profile_email").value;
    var description = $("form_user_profile_description").value;
    var sn_network = $("form_user_profile_sn_network").value.slice(0,100);
    var sn_screenname = $("form_user_profile_sn_screenname").value.slice(0,255);
    
    if(!AniScript.Utility.Validator.isEmail(email))
    {
        $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusEmailInvalid\" style=\"color:#993333\">"+lang_getText("UserProfileStatusEmailInvalid")+"</span>";
        $("form_user_profile_email").focus();
        return;
    }
    description = newlnHTML2String(description);
    description = stripHTML(description);
    
    var ids = new Array();
    for(var x=0; x < system_interests.length; x++)
    {
        var curId = "userprofilepanel_interest_"+system_interests[x].id+"_chk";
        var ele = $(curId);
        if(ele != null && ele != undefined)
        {
            if(ele.checked)
                ids.push(system_interests[x].id);
        }
    }
    
    var arrayStr;
    if(user_current_interests == null) arrayStr = ""; //won't update interests
    else arrayStr = ids.toJSONString();
    
    // Languages
    var langIdStr, langSkillStr;
    if(user_temp_languages == null)
    {
        langIdStr = "";
        langSkillStr = "";
    }
    else
    {
        var langIdArray = new Array();
        //langIdStr = user_temp_languages.toJSONString();
        var langSkillArray = new Array();   
        for(var x=0; x<user_temp_languages.length; x++)
        {
            langIdArray.push(parseInt(user_temp_languages[x]));
        
            var skill = user_temp_language_skills[user_temp_languages[x]];
            if(skill != null && skill != undefined)
            {
                langSkillArray.push(parseInt(skill));
            }
            else langSkillArray.push(1);
        }
        langSkillStr = langSkillArray.toJSONString();
        langIdStr = langIdArray.toJSONString();
    }
    
    // lock fields
    $("form_user_profile_name").disabled = true;
    $("form_user_profile_email").disabled = true;
    $("form_user_profile_description").disabled = true;
    $("form_user_profile_sn_network").disabled = true;
    $("form_user_profile_sn_screenname").disabled = true;
    $("form_user_profile_interests").style.display = "none";
    $("userprofilepanel_interestsupdating").style.display = '';
    $("form_user_profile_languages").style.display = "none";
    $("userprofilepanel_languagesupdating").style.display = '';
    $("Omni_Localized_UserProfileSubmitButton").disabled = true;
    $("userprofilepanel_status").innerHTML=loading_img+" "+ lang_getHTML("UserProfileUpdating");
    // ajax
    if(user_update_ajax == null) user_update_ajax = new AniScript.Web.Ajax();
    user_update_ajax.setHandler(user_update_callback);
    user_update_ajax.request(hosturl+"handler/user/updatehandler.ashx","name="+escape(name)+"&email="+escape(email)+"&description="+escape(description)+"&snnetwork="+escape(sn_network)+"&snscreenname="+escape(sn_screenname));
    // interests ajax
    if(user_update_interests_ajax == null) user_update_interests_ajax = new AniScript.Web.Ajax();
    user_update_interests_ajax.setHandler(user_update_interests_callback);
    user_update_interests_ajax.request(hosturl+"handler/user/updateinterestshandler.ashx","interests="+escape(arrayStr));
    // languages ajax
    if(user_update_languages_ajax == null) user_update_languages_ajax = new AniScript.Web.Ajax();
    user_update_languages_ajax.setHandler(user_update_languages_callback);
    user_update_languages_ajax.request(hosturl+"handler/user/updatelanguageshandler.ashx","languages="+escape(langIdStr)+"&skills="+escape(langSkillStr));
    
}
function user_update_callback()
{
    if(!user_update_ajax.isDone()) return;
    $("form_user_profile_name").disabled = false;
    $("form_user_profile_email").disabled = false;
    $("form_user_profile_description").disabled = false;
    $("form_user_profile_sn_network").disabled = false;
    $("form_user_profile_sn_screenname").disabled = false;
    $("Omni_Localized_UserProfileSubmitButton").disabled = false;
    if(user_update_ajax.hasError())
    {
        $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusError\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusError")+"</span>";
        return;
    }

    var status = user_update_ajax.getJSON().status;
    if(status=="Updated")
    {
        // Don't overwrite another error msg w/ a success one
        if($("userprofilepanel_status").innerHTML.indexOf("UserProfileUpdating") > -1)
            $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusUpdated\" style=\"color:green;\">"+lang_getText("UserProfileStatusUpdated")+"</span>";  
        user_init();   
    }
    else if(status=="DuplicateEmail")
    {
        $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusDuplicateEmail\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusDuplicateEmail")+"</span>";
        $("form_user_profile_email").focus();
    }
    else
    {
        $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusError\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusError")+"</span>";
    }
}

function user_update_interests_callback()
{
    if(!user_update_interests_ajax.isDone()) return;
    $("form_user_profile_interests").style.display = '';
    $("userprofilepanel_interestsupdating").style.display = "none";
    
    $("Omni_Localized_UserProfileSubmitButton").disabled = false;
    if(user_update_interests_ajax.hasError())
    {
        $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusError\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusError")+"</span>";
        return;
    }

    var status = user_update_interests_ajax.getJSON().status;
    if(status=="OK")
    {
        // Don't overwrite another error msg w/ a success one
        if($("userprofilepanel_status").innerHTML.indexOf("UserProfileUpdating") > -1)
        {
            $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusUpdated\" style=\"color:green;\">"+lang_getText("UserProfileStatusUpdated")+"</span>";
        }
    }
    else
    {
        $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusError\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusError")+"</span>";
    }
}

function user_update_languages_callback()
{
    if(!user_update_languages_ajax.isDone()) return;
    $("form_user_profile_languages").style.display = '';
    $("userprofilepanel_languagesupdating").style.display = "none";
    
    $("Omni_Localized_UserProfileSubmitButton").disabled = false;
    if(user_update_languages_ajax.hasError())
    {
        $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusError\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusError")+"</span>";
        return;
    }

    var status = user_update_languages_ajax.getJSON().status;
    if(status=="OK")
    {
        // Don't overwrite another error msg w/ a success one
        if($("userprofilepanel_status").innerHTML.indexOf("UserProfileUpdating") > -1)
        {
            $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusUpdated\" style=\"color:green;\">"+lang_getText("UserProfileStatusUpdated")+"</span>";
        }

        // FIXME : Totally unnecessary
        var langIdArray = new Array();
        for(var x=0; x<user_temp_languages.length; x++)
        {
            langIdArray.push(parseInt(user_temp_languages[x]));
        }        
        user_current_obj_lang = langIdArray;        

        user_summary_retrieve();
    }
    else
    {
        $("userprofilepanel_status").innerHTML="<span id=\"Omni_Localized_UserProfileStatusError\" style=\"color:#993333;\">"+lang_getText("UserProfileStatusError")+"</span>";
    }
}