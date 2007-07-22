/*
 * Service related functions
 * Dictionary and Translation
 */
 
var service_trans_ajax = null;
function service_trans()
{
    $("servicetranspanel_status").innerHTML="";
    var msg=$("form_servicetrans_msg").value;
    var direction=$("form_servicetrans_direction").value;
    if(direction.indexOf("_")<=-1) return;
    if(msg=="")
    {
        $("servicetranspanel_status").innerHTML=lang_getHTML("ServiceTransNoMsg");
        return;
    }
    var src_lang = direction.split("_")[0];
    var dst_lang = direction.split("_")[1];
    
    //$("servicetranspanel_resultpanel").style.display="block";
    $("servicetranspanel_loading").style.display="block";
    $("servicetranspanel_result").style.display="none";
    $("form_servicetrans_msg").style.display = "none";    
    //ajax
    if(service_trans_ajax==null) service_trans_ajax = new AniScript.Web.Ajax();
    service_trans_ajax.setHandler(service_trans_callback);
    service_trans_ajax.request(hosturl+"handler/service/translationhandler.ashx","message="+escape(msg)+"&src_lang="+escape(src_lang)+"&dst_lang="+escape(dst_lang));
}
function service_trans_callback()
{
    if(!service_trans_ajax.isDone()) return;
    if(service_trans_ajax.hasError())
    {
        service_trans_reset();
        $("servicetranspanel_status").innerHTML=lang_getHTML("ServiceTransError");
        $("form_servicetrans_msg").style.display = "block";    
        return;
    }
    //$("servicetranspanel_resultpanel").style.display="block";
    $("servicetranspanel_loading").style.display="none";
    $("servicetranspanel_result").value = service_trans_ajax.getJSON().message;
    $("servicetranspanel_result").style.display="block";
    $("form_servicetrans_msg").style.display = "none";
    
    $("Omni_Localized_ServiceTransSubmitButton").disabled = true;
    $("form_servicetrans_direction").disabled = true;
    langbar_results = true;
    
}
function service_trans_reset()
{
    $("servicetranspanel_status").innerHTML="";
    //$("servicetranspanel_resultpanel").style.display="none";
    $("servicetranspanel_loading").style.display="none";
    $("servicetranspanel_result").style.display="none";
    $("servicetranspanel_result").innerText = "";
    if(langbar_results)
    {
        $("Omni_Localized_ServiceTransSubmitButton").disabled = false;
        $("form_servicetrans_direction").disabled = false;
        $("form_servicetrans_msg").style.display = "block";
        langbar_results = false;
    }

}


//dictionary service
var service_dict_ajax = null;
function service_dict()
{
    $("servicedictpanel_status").innerHTML="";
    var word=$("form_servicedict_word").value;
    var lang=$("form_servicedict_lang").value;
    if(word==""||lang==""||lang.length>5) return;
    $("servicedictpanel_status").innerHTML=loading_img;
    //ajax
    if(service_dict_ajax==null) service_dict_ajax = new AniScript.Web.Ajax();
    service_dict_ajax.setHandler(service_dict_callback);
    service_dict_ajax.request(hosturl+"handler/service/dictionaryhandler.ashx","word="+escape(word)+"&lang="+escape(lang));
}
function service_dict_callback()
{
    if(!service_dict_ajax.isDone()) return;
    $("servicedictpanel_status").innerHTML="";
    if(service_dict_ajax.hasError()) return;
    $("servicedictpanel_resultpanel").style.display="block";
    $("servicedictpanel_result").value = service_dict_ajax.getJSON().definition;
}
function service_dict_reset()
{
    $("servicedictpanel_status").innerHTML="";
    $("servicedictpanel_resultpanel").style.display="none";
    $("servicedictpanel_result").innerText = "";
}