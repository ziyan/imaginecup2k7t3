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
user_rating; // 0 if current user hasn't rated this
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
    if(translations[x].user_rating > 0 || translations[x].trans_user == user_current_id)
        tablestr += "<td>"+lang_getHTML("TransHeaderRating","DetailAns"+x)+"</td></tr>";
    else tablestr += "<td>"+lang_getHTML("TransDetailPleaseRate","DetailAns"+x)+"</td></tr>";
    tablestr += "<tr class\"data\">";
    tablestr += "<td>"+translations[x].trans_date+"</td>";
    tablestr += "<td>"+translations[x].trans_username+"</td>";
    var ratertype = 1;
    if(!user_is_logged_in() || translations[x].trans_user == user_current_id) ratertype = 0;
    tablestr += "<td>"+rater_create("TransAnsRater"+x,ratertype,parseInt(translations[x].trans_rating),translations[x].user_rating)+"</td>";
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
    if(id == undefined || id == null)
    {
        $("transdetailpanel").style.display = 'none';
        return; // For render after page reload
    }

    trans_details_active_trans_id = id;
    $("transdetailpanel").style.display = '';
    $("transdetailpanel").scrollIntoView();
    
    if(user_is_logged_in())
        $("transdetailpanel_submit").style.display = '';
    else $("transdetailpanel_submit").style.display = 'none';
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
        view_trans_details_req_obj = result;
        $("transdetailpanel_req").innerHTML=get_trans_req_table(result);
        if(result.user_id == user_current_id)
            $("transdetailpanel_submit").style.display = 'none';
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
        view_trans_details_ans_obj = results;
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
function view_trans_init(retrieve)
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
            // No retrieve check since they have to search before an ajax request anyway
            view_trans_all_init();
        }
        else if(view_trans_active_tab_id.indexOf("MyTranslations")>-1)
        {
            if(retrieve) view_trans_mine_init();
        }
        else if(view_trans_active_tab_id.indexOf("NeedApproval")>-1)
        {
            if(retrieve) view_trans_approval_init();
        }
    }
}

function set_view_trans_tab(tab_param)
{
    if(tab_param != undefined && tab_param != null)
    {
        view_trans_active_tab_id = tab_param;
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
    view_trans_init(true);
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
        $("performtrans_personal").innerHTML=get_trans_table("PerformPersonal", results, false, true, true, true);
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

// ------------- Request Translation ---------------
var request_trans_user = null;
function request_trans_init(param)
{
    if(param != null && param != undefined)
    {
        $("requesttranspanel_nonfixeddst").style.display = 'none';
        $("requesttranspanel_fixeddst").style.display = '';
        $("requesttranspanel_fixeddst").innerHTML = param.name+" ("+param.username+")";
    }
    else
    {
        request_trans_user = null;
        $("requesttranspanel_nonfixeddst").style.display = '';
        $("requesttranspanel_fixeddst").style.display = 'none';
    }

    $("requesttranspanel_status").innerHTML = "";
    
    $("requesttranspanel_subject").value = "";
    $("requesttranspanel_message").value = "";

    if(user_current_obj_lang!= null && user_current_obj_lang.length != 0)
    {
        $("requesttranspanel_srclang").options.length = user_current_obj_lang.length;
        $("requesttranspanel_dstlang").options.length = user_current_obj_lang.length;
        for(var x=0; x<user_current_obj_lang.length; x++)
        {
            var syslang = sys_lang_obj_by_id(user_current_obj_lang[x]);        
            var myOpt = document.createElement("OPTION");
            myOpt.id = "Omni_Localized_LanguageName"+syslang.short_code;
            myOpt.text = sys_lang_by_short_code(syslang.short_code, "RequestTransSrc");
            myOpt.value = syslang.id;
            $("requesttranspanel_srclang").options[x] = myOpt;
            myOpt = document.createElement("OPTION");
            myOpt.id = "Omni_Localized_LanguageName"+syslang.short_code;
            myOpt.text = sys_lang_by_short_code(syslang.short_code, "RequestTransDst");
            myOpt.value = syslang.id;
            $("requesttranspanel_dstlang").options[x] = myOpt;
        }
    }    

    friends_list_retrieve_silent(request_trans_friends_callback);
}

function request_trans_friends_callback()
{
    var str = "<select id=\"requesttranspanel_friendlist\">";
    for(var x=0;x<friends.length;x++)
    {
        str += "<option value=\""+x+"\">"+friends[x].name+" ("+friends[x].username+")"+"</option>";
    }    
    str += "</select>";    
    $("requesttranspanel_friends").innerHTML = str;
}

var request_trans_submit_ajax = null;

function request_trans_submit()
{
    if(!request_trans_validate_lang()) return;
    var subject = $("requesttranspanel_subject").value;
    var message = $("requesttranspanel_message").value;
    if(subject == null || subject == "" || message == null || message == "")
    {
        $("requesttranspanel_status").innerHTML="<span id=\"Omni_Localized_RequestTransErrorMissingFields\" style=\"color:#993333;line-height:20px\">"+lang_getText("RequestTransErrorMissingFields")+"</span>";
        return;
    }
    var srclangid = $("requesttranspanel_srclang").options[$("requesttranspanel_srclang").selectedIndex].value;
    var dstlangid = $("requesttranspanel_dstlang").options[$("requesttranspanel_dstlang").selectedIndex].value;
    var dsttype = $("requesttranspanel_dsttype").options[$("requesttranspanel_dsttype").selectedIndex].value;
    
    var dstid = 0;
    if(dsttype == 1) // Specific User
    {
        var idx = $("requesttranspanel_friends").options[$("requesttranspanel_friends").selectedIndex].value;
        dstid = friends[idx].id;
    }
    
    if(request_trans_submit_ajax == null) request_trans_submit_ajax = new AniScript.Web.Ajax();
    request_trans_submit_ajax.setHandler(request_trans_submit_callback);
    request_trans_submit_ajax.request(hosturl + "handler/translation/requestaddhandler.ashx","srclangid="+escape(srclangid)+"&dstlangid="+escape(dstlangid)+"&subject="+escape(subject)+"&message="+escape(message)+"&dstid="+escape(dstid)+"&dsttype="+escape(dsttype));
}

function request_trans_submit_callback()
{
    if(!request_trans_submit_ajax.isDone()) return;
    if(request_trans_submit_ajax.hasError())
    {
        $("requesttranspanel_status").innerHTML="<span id=\"Omni_Localized_RequestTransStatusError\" style=\"color:#993333;\">"+lang_getText("RequestTransStatusError")+"</span>";
        return;
    }
    var myJson = request_trans_submit_ajax.getJSON();
    var status = myJson.status;
    if(status=="OK")
    {
        set_view_trans_tab("ViewTransTabMyTranslations");
        page_change("ViewTrans");
        view_trans_details(myJson.reqid);
    }
    else
    {
        $("requesttranspanel_status").innerHTML="<span id=\"Omni_Localized_RequestTransStatusError\" style=\"color:#993333;\">"+lang_getText("RequestTransStatusError")+"</span>";
    }
}

// 1 if diff pairs selected
function request_trans_validate_lang()
{
    if($("requesttranspanel_srclang").selectedIndex == $("requesttranspanel_dstlang").selectedIndex)
    {
        $("requesttranspanel_srclang_status").innerHTML = error_img;
        $("requesttranspanel_dstlang_status").innerHTML = error_img;
        $("requesttranspanel_dstlang").focus();
        $("Omni_Localized_RequestTransSubmit").disabled = true;
        return 0;
    }
    else
    {
        $("requesttranspanel_srclang_status").innerHTML = "";
        $("requesttranspanel_dstlang_status").innerHTML = "";
        $("Omni_Localized_RequestTransSubmit").disabled = false;
        return 1;
    }
}