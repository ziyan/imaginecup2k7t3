/*
 * Translation related functions
 */

var trans_auto_ajax = null;
function trans_auto()
{
    $("transautopanel_status").innerHTML="";
    var msg=$("form_transauto_msg").value;
    var direction=$("form_transauto_direction").value;
    if(direction.indexOf("_")<=-1) return;
    if(msg=="")
    {
        $("transautopanel_status").innerHTML=lang_getHTML("TransAutoNoMsg");
        return;
    }
    var src_lang = direction.split("_")[0];
    var dst_lang = direction.split("_")[1];
    
    $("transautopanel_resultpanel").style.display="block";
    $("transautopanel_loading").style.display="block";
    $("transautopanel_result").style.display="none";
    //ajax
    if(trans_auto_ajax==null) trans_auto_ajax = new AniScript.Web.Ajax();
    trans_auto_ajax.setHandler(trans_auto_callback);
    trans_auto_ajax.request("/handler/service/translationhandler.ashx","message="+escape(msg)+"&src_lang="+escape(src_lang)+"&dst_lang="+escape(dst_lang));
}
function trans_auto_callback()
{
    if(!trans_auto_ajax.isDone()) return;
    if(trans_auto_ajax.hasError())
    {
        trans_auto_reset();
        $("transautopanel_status").innerHTML=lang_getHTML("TransAutoError");
        return;
    }
    $("transautopanel_resultpanel").style.display="block";
    $("transautopanel_loading").style.display="none";
    $("transautopanel_result").value = trans_auto_ajax.getJSON().message;
    $("transautopanel_result").style.display="block";
    
    
}
function trans_auto_reset()
{
    $("transautopanel_status").innerHTML="";
    $("transautopanel_resultpanel").style.display="none";
    $("transautopanel_loading").style.display="none";
    $("transautopanel_result").style.display="none";
    $("transautopanel_result").innerText = "";
}