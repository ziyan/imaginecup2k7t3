/*
 * Translation related functions
 */
 
/*
-- Translation Object --
== (Note, all fields are strings) ==
type; { Request, Full }
// Request Stuff
request_id;
user_id;
username;
src_lang_id;
dst_lang_id;
dst_id;
dst_type; { Public, User, Group }
dst_username;
subject;
orig_body;
date;
completed;
//Answer Stuff
trans_id;
trans_body;
trans_rating;
trans_date;
trans_user;
*/

function get_trans_table(prefix, translations, requestor, translator, languages, completed)
{
    var cols = 1;
    var tablestr = "<table class=\"detailtable\" cellpadding=\"2\" style=\"font-size: 95%;\" ><tr><th>"+lang_getHTML("TransHeaderDate", prefix)+"</th>";
    if(requestor)
    {
        tablestr += "<th>"+lang_getHTML("TransHeaderRequestor", prefix)+"</th>";
        cols++;
    }
    if(translator)
    {
        tablestr += "<th>"+lang_getHTML("TransHeaderTranslator", prefix)+"</th>";
        cols++;
    }
    tablestr += "<th>"+lang_getHTML("TransHeaderSubject", prefix)+"</th>";
    cols++;
    if(languages)
    {
        tablestr += "<th>"+lang_getHTML("TransHeaderSrcLang", prefix)+"</th>";
        tablestr += "<th>"+lang_getHTML("TransHeaderDstLang", prefix)+"</th>";
        cols = cols + 2;
    }
    if(completed)
    {
        tablestr += "<th>"+lang_getHTML("TransHeaderCompleted", prefix)+"</th>";
        cols++;
    }
    tablestr += "</tr>";
    if(translations.length == 0)
    {
        tablestr += "<tr><td colspan=\""+cols+"\">"+lang_getHTML("ViewTransNoResults", prefix)+"</td></tr>";
    }
    else
    {
        for(var x=0; x<translations.length; x++)
        {
            tablestr += "<tr>";
            tablestr += "<td>"+translations[x].date+"</td>";
            if(requestor)
                tablestr += "<td>"+translations[x].username+"</td>";
            if(translator)
            {
                var transstr = "";
                if(translations[x].dst_type == "Public")
                    transstr = lang_getHTML("TransHeaderGlobal", prefix);
                else if(translations[x].dst_type == "User")
                    transstr = translations[x].dst_username;
                tablestr += "<td>"+transstr+"</td>";
            }
            tablestr += "<td><a href=\"#\" onclick=\"view_trans_details("+translations[x].request_id+"); return false\">"+translations[x].subject+"</a></td>";
            if(languages)
            {
                tablestr += "<td>"+sys_lang_by_id(translations[x].src_lang_id,"ViewTransResults"+prefix,true)+"</td>";
                tablestr += "<td>"+sys_lang_by_id(translations[x].dst_lang_id,"ViewTransResults"+prefix,true)+"</td>";            
            }
            if(completed)
            {
                var compstr = "";
                if(translations[x].completed.toLowerCase() == "true") compstr = lang_getHTML("TransHeaderCompletedYes",prefix);
                tablestr += "<td>"+compstr+"</td>";
            }
            tablestr += "</tr>";
        }
    }
    tablestr += "</table>";
    
    return tablestr;       
}

function get_trans_req_table(translation)
{
    var tablestr = "<table class=\"transtable\" cellpadding=\"2\" style=\"font-size: 95%;\" ><tr class=\"header\"><td>"+lang_getHTML("TransHeaderDate","Detail")+"</td>";
    tablestr += "<td colspan=\"2\">"+lang_getHTML("TransHeaderSubject","Detail")+"</td></tr>";
    tablestr += "<tr class\"data\">";
    tablestr += "<td>"+translation.date+"</td>";
    tablestr += "<td colspan=\"2\">"+translation.subject+"</td>";
    tablestr += "</tr>";
    
    tablestr += "<tr class=\"header\">";
    tablestr += "<td>"+lang_getHTML("TransHeaderRequestor","Detail")+"</td>";
    tablestr += "<td>"+lang_getHTML("TransHeaderSrcLang","Detail")+"</td>";
    tablestr += "<td>"+lang_getHTML("TransHeaderDstLang","Detail")+"</td></tr>";
    tablestr += "<tr class=\"data\">";
    tablestr += "<td>"+translation.username+"</td>";
    tablestr += "<td>"+sys_lang_by_id(translation.src_lang_id,"TransDetail",true)+"</td>";
    tablestr += "<td>"+sys_lang_by_id(translation.dst_lang_id,"TransDetail",true)+"</td></tr>";  
    tablestr += "<tr class=\"data\"><td colspan=\"3\"><textarea cols=\"40\" rows=\"4\" readonly=\"readonly\" style=\"width:99%\">"+translation.orig_body+"</textarea></td><tr>";
    tablestr += "</table>";    
    
    return tablestr;       
}

function get_trans_ans_table(translations)
{
    var allstr = "";
    for(var x=0; x < translations.length; x++)
    {
    var tablestr = "<table class=\"transtable\" style=\"font-size: 95%;\" cellpadding=\"2\" ><tr class=\"header\"><td>"+lang_getHTML("TransHeaderDate","DetailAns"+x)+"</td>";
    tablestr += "<td>"+lang_getHTML("TransHeaderTranslator","DetailAns"+x)+"</td>";
    tablestr += "<td>"+lang_getHTML("TransHeaderRating","DetailAns"+x)+"</td></tr>";
    tablestr += "<tr class\"data\">";
    tablestr += "<td>"+translations[x].trans_date+"</td>";
    tablestr += "<td>"+translations[x].trans_username+"</td>";
    tablestr += "<td>"+rater_create("TransAns"+x,0,parseInt(translations[x].trans_rating),0)+"</td>";
    tablestr += "</tr>";
    tablestr += "<tr class=\"data\"><td colspan=\"3\"><textarea cols=\"40\" rows=\"4\" readonly=\"readonly\" style=\"width:99%\">"+translations[x].trans_body+"</textarea></td><tr>";
    tablestr += "</table>";
    allstr += tablestr+"<br /><br />"; 
    } 
    
    return allstr;       
}

var view_trans_details_req_ajax = null;
var view_trans_details_req_obj = null;

var view_trans_details_ans_ajax = null;
var view_trans_details_ans_obj = null;

function view_trans_details(id)
{
    trans_details_active_trans_id = id;
    $("transdetailpanel").style.display = '';
    $("transdetailpanel").scrollIntoView();
    
        $("transdetailpanel_submit").style.display = '';
        $("Omni_Localized_TransDetailsTranslateSubmit").style.display = "none";
    
    // Request
    $("transdetailpanel_req").innerHTML=loading_img+" "+lang_getHTML("TransDetailLoading","Req"); 
    if(view_trans_details_req_ajax == null) view_trans_details_req_ajax = new AniScript.Web.Ajax();
    view_trans_details_req_ajax.setHandler(view_trans_details_req_callback);
    view_trans_details_req_ajax.request(hosturl + "handler/translation/requestgetbyidhandler.ashx","reqid="+escape(id));  
    // Answers
    $("transdetailpanel_ans").innerHTML=loading_img+" "+lang_getHTML("TransDetailLoading","Ans"); 
    if(view_trans_details_ans_ajax == null) view_trans_details_ans_ajax = new AniScript.Web.Ajax();
    view_trans_details_ans_ajax.setHandler(view_trans_details_ans_callback);
    view_trans_details_ans_ajax.request(hosturl + "handler/translation/answersgetbyreqidhandler.ashx","reqid="+escape(id));  

}

function view_trans_details_req_callback()
{
    if(!view_trans_details_req_ajax.isDone()) return;
    if(view_trans_details_req_ajax.hasError())
    {
        $("transdetailpanel_req").innerHTML="<span id=\"Omni_Localized_TransDetailStatusError_Req\" style=\"color:#993333;\">"+lang_getText("TransDetailStatusError")+"</span>";
        return;
    }    
    var status = view_trans_details_req_ajax.getJSON().status;
    if(status=="OK")
    {
        var result = view_trans_details_req_ajax.getJSON().result;
        $("transdetailpanel_req").innerHTML=get_trans_req_table(result);
    }
    else
    {
        $("transdetailpanel_req").innerHTML="<span id=\"Omni_Localized_TransDetailStatusError_Req\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
    }
}

function view_trans_details_ans_callback()
{
    if(!view_trans_details_ans_ajax.isDone()) return;
    if(view_trans_details_ans_ajax.hasError())
    {
        $("transdetailpanel_ans").innerHTML="<span id=\"Omni_Localized_TransDetailStatusError_Ans\" style=\"color:#993333;\">"+lang_getText("TransDetailStatusError")+"</span>";
        return;
    }    
    var status = view_trans_details_ans_ajax.getJSON().status;
    if(status=="OK")
    {
        var results = view_trans_details_ans_ajax.getJSON().results;
        $("transdetailpanel_ans").innerHTML=get_trans_ans_table(results);
        for(var x=0;x<results.length;x++)
        {
            if(results[x].trans_user == user_current_id)
            {
                $("transdetailpanel_submit").style.display = "none";
                break;
            }
        }
        $("Omni_Localized_TransDetailsTranslateSubmit").style.display = '';
    }
    else
    {
        $("transdetailpanel_ans").innerHTML="<span id=\"Omni_Localized_TransDetailStatusError_Ans\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
    }
}


var view_trans_active_tab_id = null;
var trans_details_active_trans_id = null;
function view_trans_init()
{
    if(trans_details_active_trans_id == null)
        $("transdetailpanel").style.display = "none";
    else $("transdetailpanel").style.display = '';

    var tabs = $("viewtranstab");
    var tabArray = new Array();
    if(user_is_logged_in())
    {
        tabArray.push("MyTranslations");
        tabArray.push("NeedApproval");
    }
    tabArray.push("AllTranslations");
    
    
    tabs.innerHTML = "";
    if(view_trans_active_tab_id == null)
    {
        if(user_is_logged_in()) view_trans_active_tab_id = "ViewTransTabMyTranslations";
        else view_trans_active_tab_id = "ViewTransTabAllTranslations";
    }
    for(var x=0; x<tabArray.length; x++)
    {
        var link_class = "";
        if(view_trans_active_tab_id!=null && view_trans_active_tab_id.indexOf(tabArray[x])>-1)
            link_class="class=\"select\"";
        tabs.innerHTML += "<a id=\"ViewTransTab"+tabArray[x]+"\" href=\"#\" "+link_class+" onclick=\"view_trans_tab_change('ViewTransTab"+tabArray[x]+"');return false;\">"+lang_getHTML("ViewTransTab"+tabArray[x])+"</a>";
    }
   
    // Logic
    if(view_trans_active_tab_id != null)
    {
        if(view_trans_active_tab_id.indexOf("AllTranslations")>-1)
        {
            view_trans_all_init();
        }
        else if(view_trans_active_tab_id.indexOf("MyTranslations")>-1)
        {
            view_trans_mine_init();
        }
        else if(view_trans_active_tab_id.indexOf("NeedApproval")>-1)
        {
            view_trans_approval_init();
        }
    }
}

var view_trans_approval_ajax = null;
var view_trans_mine_ajax = null;

function view_trans_mine_init()
{
    $("viewtrans_transtable_mine").style.display = '';
    $("viewtrans_transtable_approval").style.display = "none";
    $("viewtrans_transtable_all").style.display = "none";    
    $("viewtranspanel_searchpanel").style.display = "none";
    $("viewtrans_transtable_mine").innerHTML = loading_img+" "+lang_getHTML("ViewTransLoading","Results");    
    if(view_trans_mine_ajax == null) view_trans_mine_ajax = new AniScript.Web.Ajax();
    view_trans_mine_ajax.setHandler(view_trans_mine_callback);
    view_trans_mine_ajax.request(hosturl + "handler/translation/getnonpendingapprovalforuserhandler.ashx");       
}

function view_trans_mine_callback()
{
    if(!view_trans_mine_ajax.isDone()) return;
    if(view_trans_mine_ajax.hasError())
    {
        $("viewtrans_transtable_mine").innerHTML="<span id=\"Omni_Localized_ViewTransStatusError_Results\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
        return;
    }    
    //var status = view_trans_mine_ajax.getJSON().status;
    //if(status=="OK")
    {
        var results = view_trans_mine_ajax.getJSON().results;
        $("viewtrans_transtable_mine").innerHTML=get_trans_table("ViewMine", results, false, true, true, true);
    }
    /*else
    {
        $("viewtrans_transtable_mine").innerHTML="<span id=\"Omni_Localized_ViewTransStatusError_Results\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
    }  */
}

function view_trans_approval_init()
{
    $("viewtrans_transtable_mine").style.display = "none";
    $("viewtrans_transtable_approval").style.display = '';
    $("viewtrans_transtable_all").style.display = "none";  
    $("viewtranspanel_searchpanel").style.display = "none";
    $("viewtrans_transtable_approval").innerHTML = loading_img+" "+lang_getHTML("ViewTransLoading","Results");    
    if(view_trans_approval_ajax == null) view_trans_approval_ajax = new AniScript.Web.Ajax();
    view_trans_approval_ajax.setHandler(view_trans_approval_callback);
    view_trans_approval_ajax.request(hosturl + "handler/translation/getunapprovedforuserhandler.ashx");    
}

function view_trans_approval_callback()
{
    if(!view_trans_approval_ajax.isDone()) return;
    if(view_trans_approval_ajax.hasError())
    {
        $("viewtrans_transtable_approval").innerHTML="<span id=\"Omni_Localized_ViewTransStatusError_Results\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
        return;
    }    
    //var status = view_trans_approval_ajax.getJSON().status;
    //if(status=="OK")
    {
        var results = view_trans_approval_ajax.getJSON().results;
        $("viewtrans_transtable_approval").innerHTML=get_trans_table("ViewApproval", results, false, true, true, false);
    }
    /*else
    {
        $("viewtrans_transtable_approval").innerHTML="<span id=\"Omni_Localized_ViewTransStatusError_Results\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
    }  */
}

function view_trans_all_init()
{
    $("viewtrans_transtable_mine").style.display = "none";
    $("viewtrans_transtable_approval").style.display = "none";
    $("viewtrans_transtable_all").style.display = '';  
    $("viewtranspanel_searchpanel").style.display = '';
    
    if(system_languages.length != 0)
    {
        $("viewtranssearch_searchlang").options.length = system_languages.length;
        $("viewtranssearch_otherlang").options.length = system_languages.length;
        for(var x=0; x<system_languages.length; x++)
        {
            var myOpt = document.createElement("OPTION");
            myOpt.id = "Omni_Localized_LanguageName"+system_languages[x].short_code;
            myOpt.text = sys_lang_by_short_code(system_languages[x].short_code, "ViewTransSearch1");
            myOpt.value = system_languages[x].id;
            $("viewtranssearch_searchlang").options[x] = myOpt;
            myOpt = document.createElement("OPTION");
            myOpt.id = "Omni_Localized_LanguageName"+system_languages[x].short_code;
            myOpt.text = sys_lang_by_short_code(system_languages[x].short_code, "ViewTransSearch2");
            myOpt.value = system_languages[x].id;
            $("viewtranssearch_otherlang").options[x] = myOpt;
        }
    }
}

var view_trans_search_ajax = null;

function view_trans_search()
{
    var selectedIndex1 = $("viewtranssearch_searchlang").selectedIndex;
    var langid1 = $("viewtranssearch_searchlang").options[selectedIndex1].value;
    var selectedIndex2 = $("viewtranssearch_otherlang").selectedIndex;
    var langid2 = $("viewtranssearch_otherlang").options[selectedIndex2].value;
    var keyword = $("viewtrans_searchcriteria").value;
    
    $("viewtrans_transtable_all").innerHTML = loading_img+" "+lang_getHTML("ViewTransLoading","Results");
    
    if(view_trans_search_ajax == null) view_trans_search_ajax = new AniScript.Web.Ajax();
    view_trans_search_ajax.setHandler(view_trans_search_callback);
    view_trans_search_ajax.request(hosturl + "handler/translation/searchhandler.ashx", 
            "srclangid=" + escape(langid1)+"&dstlangid=" + escape(langid2)+"&keyword=" + escape(keyword));
}

function view_trans_search_callback()
{
    if(!view_trans_search_ajax.isDone()) return;
    if(view_trans_search_ajax.hasError())
    {
        $("viewtrans_transtable_all").innerHTML="<span id=\"Omni_Localized_ViewTransStatusError_Results\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
        return;
    }    
    var status = view_trans_search_ajax.getJSON().status;
    if(status=="OK")
    {
        var results = view_trans_search_ajax.getJSON().results;
        $("viewtrans_transtable_all").innerHTML=get_trans_table("ViewSearch", results, false, false, false, false);
    }
    else
    {
        $("viewtrans_transtable_all").innerHTML="<span id=\"Omni_Localized_ViewTransStatusError_Results\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
    }  
}

function view_trans_tab_change(str)
{
    view_trans_active_tab_id = str;
    view_trans_init();
}


// -------------- Perform Translation ---------------
var perform_trans_personal_ajax = null;
var perform_trans_global_ajax = null;

function perform_trans_personal_init()
{
    $("performtrans_personal").innerHTML = loading_img+" "+lang_getHTML("PerformTransLoading","Personal");    
    if(perform_trans_personal_ajax == null) perform_trans_personal_ajax = new AniScript.Web.Ajax();
    perform_trans_personal_ajax.setHandler(perform_trans_personal_callback);
    perform_trans_personal_ajax.request(hosturl + "handler/translation/getrequestsforuserhandler.ashx");    
}

function perform_trans_personal_callback()
{
    if(!perform_trans_personal_ajax.isDone()) return;
    if(perform_trans_personal_ajax.hasError())
    {
        $("performtrans_personal").innerHTML="<span id=\"Omni_Localized_PerformTransStatusError_Personal\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
        return;
    }    
    //var status = perform_trans_personal_ajax.getJSON().status;
    //if(status=="OK")
    {
        var results = perform_trans_personal_ajax.getJSON().results;
        $("performtrans_personal").innerHTML=get_trans_table("PerformPersonal", results, false, true, true, false);
    }
    /*else
    {
        $("performtrans_personal").innerHTML="<span id=\"Omni_Localized_PerformTransStatusError_Personal\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
    }  */
}

function perform_trans_global_init()
{
    $("performtrans_global").innerHTML = loading_img+" "+lang_getHTML("PerformTransLoading","Personal");    
    if(perform_trans_global_ajax == null) perform_trans_global_ajax = new AniScript.Web.Ajax();
    perform_trans_global_ajax.setHandler(perform_trans_global_callback);
    perform_trans_global_ajax.request(hosturl + "handler/translation/findglobalrequestsforuserhandler.ashx");    
}

function perform_trans_global_callback()
{
    if(!perform_trans_global_ajax.isDone()) return;
    if(perform_trans_global_ajax.hasError())
    {
        $("performtrans_global").innerHTML="<span id=\"Omni_Localized_PerformTransStatusError_Global\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
        return;
    }    
    //var status = perform_trans_global_ajax.getJSON().status;
    //if(status=="OK")
    {
        var results = perform_trans_global_ajax.getJSON().results;
        $("performtrans_global").innerHTML=get_trans_table("PerformGlobal", results, false, true, true, false);
    }
    /*else
    {
        $("performtrans_global").innerHTML="<span id=\"Omni_Localized_PerformTransStatusError_Global\" style=\"color:#993333;\">"+lang_getText("ViewTransStatusError")+"</span>";
    }  */
}

function perform_trans_init()
{
    perform_trans_personal_init();
    perform_trans_global_init();
}

// -------------------- Submit Translation -----------------------
var trans_detail_submit_ajax = null;
function trans_details_submit_translation()
{
    if($("transdetailpanel_translatetext").value == "") return;
    if(trans_details_active_trans_id == null || trans_details_active_trans_id <= 0) return;
    var message = $("transdetailpanel_translatetext").value;
    
    if(trans_detail_submit_ajax == null) trans_detail_submit_ajax = new AniScript.Web.Ajax();
    trans_detail_submit_ajax.setHandler(trans_detail_submit_callback);
    trans_detail_submit_ajax.request(hosturl + "handler/translation/answeraddhandler.ashx","reqid="+escape(trans_details_active_trans_id)+"&message="+escape(message));
}

function trans_detail_submit_callback()
{
    if(!trans_detail_submit_ajax.isDone()) return;
    if(trans_detail_submit_ajax.hasError()) return;
    
    view_trans_details(trans_details_active_trans_id);
}