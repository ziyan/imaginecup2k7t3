/*
 * Splash control
 */
 
function splash_init()
{
    splash_check_status();
    $("splash_status").innerHTML = loading_img + " Loading language settings ...";
    lang_init();
    if(server_error) return;
    $("splash_status").innerHTML = loading_img + " " + lang_getHTML("SplashPageInit");
    page_init();
    if(server_error) return;
    $("splash_status").innerHTML = loading_img + " " + lang_getHTML("SplashUserInit");
    user_init();
    if(server_error) return;
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
    else if(init_done && !splash_faded)
    {
        splash_faded = true;
        $("splash_status").innerHTML = loading_img + " " + lang_getHTML("SplashInitDone");
        setTimeout("splash_fade()", 500);
    }
    var timer = setTimeout("splash_check_status()", 500);
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