// Message functionality

var message_details_active_msg_id = null;
var message_details_ajax = null;
var message_details_obj = null;

function show_message_details(id) // msg id
{
    message_details_active_msg_id = id;
    message_detail_panel_reset();
    
    content_right.appendChild($("messagedetailpanel"));
    pool.appendChild($("composemsgpanel"));
    
    $("messagedetailpanel_details").style.display = "none";
    $("messagedetailpanel_loading").style.display = "";
    $("messagedetailpanel_status").innerHTML = "";
    
    if(message_details_ajax == null) message_details_ajax = new AniScript.Web.Ajax();
    message_details_ajax.setHandler(message_details_callback);
    message_details_ajax.request(hosturl + "handler/message/getbyidhandler.ashx","msgid="+escape(id));    
    
    
    message_mark_as_read(id);   
}

function message_details_callback()
{
    if(!message_details_ajax.isDone()) return;
    $("messagedetailpanel_loading").style.display = "none";
    if(message_details_ajax.hasError())
    {
        $("messagedetailpanel_status").innerHTML="<span id=\"Omni_Localized_MessageDetailsStatusError\" style=\"color:#993333;\">"+lang_getText("MessageDetailsStatusError")+"</span>";
        return;
    }    
    var status = message_details_ajax.getJSON().status;
    if(status=="OK")
    {
        var result = message_details_ajax.getJSON().result;
        message_details_obj = result;
        
        $("messagedetailpanel_date").innerHTML=result.date;
        $("messagedetailpanel_sender").innerHTML=result.src_username;
        $("messagedetailpanel_recipient").innerHTML=result.dst_username;
        $("messagedetailpanel_subject").innerHTML=result.subject;
        $("messagedetailpanel_body").value=result.body;
        $("messagedetailpanel_details").style.display = "";
        
    }
    else
    {
        $("messagedetailpanel_status").innerHTML="<span id=\"Omni_Localized_MessageDetailsStatusError\" style=\"color:#993333;\">"+lang_getText("MessageDetailsStatusError")+"</span>";
    }
}

function message_detail_panel_reset()
{
    if(message_details_active_msg_id == null)
    {
        $("messagedetailpanel").style.display = "none";
    }
    else
    {
        $("messagedetailpanel").style.display = "";
    }   
}

var messages_received_ajax = null;
var messages_received_obj = null;

function message_mark_as_read(id)
{
    if(messages_received_obj == null) return;
    for(var x=0;x<messages_received_obj.length; x++)
    {
        if(messages_received_obj[x].id == id)
        {
            messages_received_obj[x].unread = "False";
            $("messagespanel_received").innerHTML=get_received_messages_table(messages_received_obj);
            break;
        }            
    }
}

function messages_retrieve()
{
    $("messagespanel_received").innerHTML = loading_img+" "+lang_getHTML("MessagesLoading","Received");
    if(messages_received_ajax == null) messages_received_ajax = new AniScript.Web.Ajax();
    messages_received_ajax.setHandler(messages_received_callback);
    messages_received_ajax.request(hosturl + "handler/message/getreceivedforuserhandler.ashx");
    
    $("messagespanel_sent").innerHTML = loading_img+" "+lang_getHTML("MessagesLoading","Sent");
    if(messages_sent_ajax == null) messages_sent_ajax = new AniScript.Web.Ajax();
    messages_sent_ajax.setHandler(messages_sent_callback);
    messages_sent_ajax.request(hosturl + "handler/message/getsentforuserhandler.ashx");    
}

function messages_received_callback()
{
    if(!messages_received_ajax.isDone()) return;
    if(messages_received_ajax.hasError())
    {
        $("messagespanel_received").innerHTML="<span id=\"Omni_Localized_MessagesStatusError_Received\" style=\"color:#993333;\">"+lang_getText("MessagesStatusError")+"</span>";
        return;
    }    
    //var status = messages_received_ajax.getJSON().status;
    //if(status=="OK")
    {
        var results = messages_received_ajax.getJSON().results;
        messages_received_obj = results;
        $("messagespanel_received").innerHTML=get_received_messages_table(results);
    }
    /*else
    {
        $("messagespanel_received").innerHTML="<span id=\"Omni_Localized_MessagesStatusError_Received\" style=\"color:#993333;\">"+lang_getText("MessagesStatusError")+"</span>";
    }   */ 
}

var messages_sent_ajax = null;
var messages_sent_obj = null;

function messages_sent_callback()
{
    if(!messages_sent_ajax.isDone()) return;
    if(messages_sent_ajax.hasError())
    {
        $("messagespanel_sent").innerHTML="<span id=\"Omni_Localized_MessagesStatusError_Sent\" style=\"color:#993333;\">"+lang_getText("MessagesStatusError")+"</span>";
        return;
    }    
    //var status = messages_sent_ajax.getJSON().status;
    //if(status=="OK")
    {
        var results = messages_sent_ajax.getJSON().results;
        messages_sent_obj = results;
        $("messagespanel_sent").innerHTML=get_sent_messages_table(results);
    }
    /*else
    {
        $("messagespanel_sent").innerHTML="<span id=\"Omni_Localized_MessagesStatusError_Sent\" style=\"color:#993333;\">"+lang_getText("MessagesStatusError")+"</span>";
    }   */ 
}

function get_received_messages_table(results)
{
    var tablestr = "<table class=\"detailtable\" cellpadding=\"2\"><tr><th>"+lang_getHTML("MessageTableDate","Received")+"</th><th>"+lang_getHTML("MessageTableSender","Received")+"</th><th>"+lang_getHTML("MessageTableSubject","Received")+"</th></tr>";
    
    if(results.length > 0)
    {
        for(var x=0; x<results.length; x++)
        {
            if(!strIsTrue(results[x].unread))
                tablestr += "<tr><td>"+results[x].date+"</td><td>"+results[x].src_username+"</td><td><a href=\"#\" onclick=\"show_message_details("+results[x].id+"); return false\">"+results[x].subject+"</a></td></tr>";
            else tablestr += "<tr><td><b>"+results[x].date+"</b></td><td><b>"+results[x].src_username+"</b></td><td><b><a href=\"#\" onclick=\"show_message_details("+results[x].id+"); return false\">"+results[x].subject+"</a></b></td></tr>";
        }
    }
    else tablestr += "<tr><td colspan=\"3\">"+lang_getHTML("MessageTableNoResults","Received")+"</td></tr>";
    tablestr += "</table>";
    
    return tablestr;
}

function get_sent_messages_table(results)
{
    var tablestr = "<table class=\"detailtable\" cellpadding=\"2\"><tr><th>"+lang_getHTML("MessageTableDate","Sent")+"</th><th>"+lang_getHTML("MessageTableRecipient","Sent")+"</th><th>"+lang_getHTML("MessageTableSubject","Sent")+"</th></tr>";
    
    if(results.length > 0)
    {
        for(var x=0; x<results.length; x++)
        {
            tablestr += "<tr><td>"+results[x].date+"</td><td>"+results[x].dst_username+"</td><td><a href=\"#\" onclick=\"return false;\">"+results[x].subject+"</a></td></tr>";
        }
    }
    else tablestr += "<tr><td colspan=\"3\">"+lang_getHTML("MessageTableNoResults","Sent")+"</td></tr>";
    tablestr += "</table>";
    
    return tablestr;
}



var message_send_ajax = null;

function message_send()
{
    var subject = $("composemsgpanel_subject").value;
    var message = $("composemsgpanel_body").value;
    if(subject == null || subject == "")
    {
        $("composemsgpanel_status").innerHTML="<span id=\"Omni_Localized_ComposeMessageErrorSubjectRequired\" style=\"color:#993333;line-height:20px\">"+lang_getText("ComposeMessageErrorSubjectRequired")+"</span>";
        return;
    }
    
    var dstid = 0;
    if(compose_message_user != null)
        dstid = compose_message_user.id;
    else
    {
        var selIdx = $("composemsgpanel_friendlist").selectedIndex;
        var idx = $("composemsgpanel_friendlist").options[selIdx].value;
        dstid = friends[idx].id;
    }

    $("Omni_Localized_ComposeMessageSubmitButton").disabled = true;
    $("Omni_Localized_ComposeMessageRequestTransButton").disabled = true;

    $("composemsgpanel_status").innerHTML = loading_img+" "+lang_getHTML("ComposeMessageLoading");
    if(message_send_ajax == null) message_send_ajax = new AniScript.Web.Ajax();
    message_send_ajax.setHandler(message_send_callback);
    message_send_ajax.request(hosturl + "handler/message/sendhandler.ashx","dstid="+escape(dstid)+"&subject="+escape(subject)+"&message="+escape(message));
}

function message_send_callback()
{
    if(!message_send_ajax.isDone()) return;
    $("Omni_Localized_ComposeMessageSubmitButton").disabled = false;
    $("Omni_Localized_ComposeMessageRequestTransButton").disabled = false;
    $("composemsgpanel_status").innerHTML = "";
    if(message_send_ajax.hasError())
    {
        $("composemsgpanel_status").innerHTML="<span id=\"Omni_Localized_ComposeMessageStatusError\" style=\"color:#993333;\">"+lang_getText("ComposeMessageStatusError")+"</span>";
        return;
    }
    var myJson = message_send_ajax.getJSON();
    var status = myJson.status;
    if(status=="OK")
    {
        $("composemsgpanel_subject").value = "";
        $("composemsgpanel_body").value = "";
    
        if(page_current != "Messages") page_change("Messages");
        else messages_retrieve();
    }
    else
    {
        $("composemsgpanel_status").innerHTML="<span id=\"Omni_Localized_ComposeMessageStatusError\" style=\"color:#993333;\">"+lang_getText("ComposeMessageStatusError")+"</span>";
    }
}


function messages_compose()
{
    pool.appendChild($("messagedetailpanel"));
    content_right.appendChild($("composemsgpanel"));
    
    $("composemsgpanel_nonfixeddst").style.display = '';
    $("composemsgpanel_fixeddst").style.display = 'none';
    
    compose_message_user = null;
    
    $("composemsgpanel_friends").innerHTML = loading_img;
    friends_list_retrieve_silent(compose_message_friends_callback);
}

function compose_message_friends_callback()
{
    var str = "<select id=\"composemsgpanel_friendlist\">";
    for(var x=0;x<friends.length;x++)
    {
        str += "<option value=\""+x+"\">"+friends[x].name+" ("+friends[x].username+")"+"</option>";
    }    
    str += "</select>";    
    $("composemsgpanel_friends").innerHTML = str;
}    

var compose_message_user = null;

function compose_message_reply()
{
    if(message_details_obj == null) return;
    
    pool.appendChild($("messagedetailpanel"));
    content_right.appendChild($("composemsgpanel"));
    
    compose_message_user = new Object();
    compose_message_user.username = message_details_obj.src_username;
    compose_message_user.id = message_details_obj.src_id;
    
    $("composemsgpanel_subject").value = message_details_obj.subject;
    $("composemsgpanel_body").value = message_details_obj.body;
    
    $("composemsgpanel_nonfixeddst").style.display = 'none';
    $("composemsgpanel_fixeddst").style.display = '';
    if(compose_message_user.name != "" && compose_message_user.name != undefined)
        $("composemsgpanel_fixeddst").innerHTML = compose_message_user.name+" ("+compose_message_user.username+")";
    else $("composemsgpanel_fixeddst").innerHTML = compose_message_user.username;
    
    //$("composemsgpanel_friends").innerHTML = loading_img;
    //friends_list_retrieve_silent(compose_message_friends_callback);
}

function compose_message_from_profile()
{
    if(omni_profile_panel_user == null) return;

    for(var i=0;i<content_left.childNodes.length;i++)
    {
        pool.appendChild(content_left.childNodes[i]);
    }

    content_left.appendChild($("omniprofilepanel"));
    content_right.appendChild($("composemsgpanel"));
    
    compose_message_user = omni_profile_panel_user;
    
    $("composemsgpanel_nonfixeddst").style.display = 'none';
    $("composemsgpanel_fixeddst").style.display = '';
    if(compose_message_user.name != "" && compose_message_user.name != undefined)
        $("composemsgpanel_fixeddst").innerHTML = compose_message_user.name+" ("+compose_message_user.username+")";
    else $("composemsgpanel_fixeddst").innerHTML = compose_message_user.username;
    
    //$("composemsgpanel_friends").innerHTML = loading_img;
    //friends_list_retrieve_silent(compose_message_friends_callback);
}
