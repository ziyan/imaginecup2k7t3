/*
 * Splash control
 */
 
function splash_init()
{
    splash_check_status();
    $("splash_status").innerHTML = loading_img + " Loading language settings ...";
    lang_init();
    splash_wait_for_lang();
}
AniScript.Loader.add(splash_init);

function splash_check_status()
{
    if(server_error)
    {
        $("splash").style.display = "block";
        $("splash").style.opacity =0.90;
        $("splash").style.filter="alpha(opacity=90)";
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
        
        //loading user info
        $("splash_status").innerHTML = loading_img + " " + lang_getHTML("SplashUserInit");
        user_init();
        splash_wait_for_user()
        return;
    }
    var timer = setTimeout("splash_wait_for_lang()", 500);
}

function splash_wait_for_user()
{
    if(!user_loading)
    {
        if(server_error) return;
    }
    else
    {
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
        $("splash").style.opacity-=0.10;
        $("splash").style.filter="alpha(opacity="+($("splash").style.opacity*100)+")";
        var timer = setTimeout("splash_fade()", 10);
    }
    else
    {
        $("splash").style.display = "none";
    }
}
