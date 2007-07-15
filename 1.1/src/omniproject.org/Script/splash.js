/*
 * Splash control
 */
 
function splash_init()
{
    splash_check_status();
    $("screen").style.display="none";
    $("splash_status").innerHTML = loading_img + " Loading language settings ...";
    lang_init();
    splash_wait_for_lang();
}
AniScript.Loader.add(splash_init);

function splash_check_status()
{
    if(server_error)
    {
        $("screen").style.display="none";
        $("splash").style.display = "block";
        $("splash").style.opacity =1.00;
        $("splash").style.filter="alpha(opacity=100)";
        $("splash_status").style.color="red";
        $("splash_status").innerHTML = "Error connecting to server. Please try again later.";
        return;
    }
    var timer = setTimeout("splash_check_status()", 500);
}

function splash_wait_for_lang()
{
    if(!lang_loading)
    {
        if(server_error) return;
        //loading page
        $("splash_status").innerHTML = loading_img + " " + lang_getHTML("SplashPageInit");
        page_init();
        if(server_error) return;

        //loading system interests info
        $("splash_status").innerHTML = loading_img + " " + lang_getHTML("SplashSystemInterestsInit");
        system_interests_init();
        splash_wait_for_system_interests();
        return;
    }
    var timer = setTimeout("splash_wait_for_lang()", 500);
}


function splash_wait_for_system_interests()
{
    if(!system_interests_loading)
    {
        if(server_error) return;
        //loading languages info
        $("splash_status").innerHTML = loading_img + " " + lang_getHTML("SplashSystemLanguagesInit");
        //system_langauges_init();
        splash_wait_for_system_languages();
        return;
    }
    setTimeout("splash_wait_for_system_interests()", 500);
}

function splash_wait_for_system_languages()
{
    if(!system_languages_loading)
    {
        if(server_error) return;
        //loading user info
        $("splash_status").innerHTML = loading_img + " " + lang_getHTML("SplashUserInit");
        user_init();
        splash_wait_for_user();
        return;
    }
    setTimeout("splash_wait_for_system_languages()", 500);
}

function splash_wait_for_user()
{
    if(!user_loading)
    {
        if(server_error) return;
        $("splash_status").innerHTML = loading_img + " " + lang_getHTML("SplashInitDone");
        setTimeout("splash_fade()", 500);
        return;
    }
    setTimeout("splash_wait_for_user()", 500);
}

function splash_fade()
{
    if($("splash").style.opacity>0)
    {
        $("screen").style.display="block";
        $("splash").style.opacity-=0.10;
        $("splash").style.filter="alpha(opacity="+($("splash").style.opacity*100)+")";
        var timer = setTimeout("splash_fade()", 10);
    }
    else
    {
        $("splash").style.display = "none";
        user_register_update_captcha();
    }
}
