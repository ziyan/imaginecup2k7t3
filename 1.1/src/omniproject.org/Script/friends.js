﻿// Friends related stuff


// Render interests w/ tree structure, but only for interest ids
//   passed in
// ids : Array of interest ids as ints
// prefix (userprofilepanel, etc). Do not include any "_"'s.
// Returns string (HTML)
// In the output, rows are uniquely identified by the following string
//       prefix_interest_id
// e.g.  userprofilepanel_interest_12
function profile_interests_table(ids, prefix)
{
    if(system_interests==null) return "";
    if(ids == null || ids == undefined || ids.length == 0) return "";
    var output = "<span style=\"line-height: 16px\"><table>";
    // Only works for one level of parents
    for(var i=0; i<system_interests.length; i++)
    {
        var parent = system_interests[i];
        if(parent.parent_id != 0) continue;
        
        var idx1 = -1;
        for(var k1=0;k1<ids.length;k1++)
        {
            if(ids[k1] == parent.id)
            {
                idx1 = ids[k1];
                break;
            }
        }
        if(idx1 == -1) continue;
        
        output += "<tr>";
        output += "<td style=\"padding-left:0px\">"+lang_getHTML("InterestName"+parent.name,prefix)+"</td>"; 
        output += "</tr>";  
        for(var j=0; j<system_interests.length; j++)
        {
            var child = system_interests[j];
            if(child.parent_id != parent.id) continue;
            
            var idx2 = -1;
            for(var k2=0;k2<ids.length;k2++)
            {
                if(ids[k2] == child.id)
                {
                    idx2 = ids[k2];
                    break;
                }
            }
            if(idx2 == -1) continue;            
            
            output += "<tr>";
            output += "<td style=\"padding-left:16px\">"+lang_getHTML("InterestName"+child.name,prefix)+"</td>"; 
            output += "</tr>";            
        }
    }
    output += "</table></span>";
    return output;
}

// Omni Profile Panel
function omni_profile_panel_reset()
{
    $("omniprofilepanel_content_empty").style.display = "block";
    $("omniprofilepanel_content").style.display = "none";
}

var omni_profile_panel_user = null;
var omni_profile_interests_ajax = null;

function omni_profile_panel_display(user)
{
    omni_profile_panel_user = user;

    $("omniprofilepanel_username").innerHTML = user.username;
    $("omniprofilepanel_name").innerHTML = user.name;
    $("omniprofilepanel_email").innerHTML = user.email;
    //$("omniprofilepanel_description").value = user.description;
    $("omniprofilepanel_description").innerHTML = user.description;
    $("omniprofilepanel_network").innerHTML = user.sn_network;
    $("omniprofilepanel_screenname").innerHTML = user.sn_screenname;
    // Contact info visibility
    if(user.email == "")
    {
        $("omniprofilepanel_emailrow").style.display = "none";
        $("omniprofilepanel_imrow1").style.display = "none";
        $("omniprofilepanel_imrow2").style.display = "none";
        $("omniprofilepanel_imrow3").style.display = "none";        
    }
    else
    {
        $("omniprofilepanel_emailrow").style.display = null;
        $("omniprofilepanel_imrow1").style.display = null;
        $("omniprofilepanel_imrow2").style.display = null;
        $("omniprofilepanel_imrow3").style.display = null;        
    }
    
    // Get Interests
    if(omni_profile_interests_ajax == null)
        omni_profile_interests_ajax = new AniScript.Web.Ajax();
    omni_profile_interests_ajax.setHandler(omni_profile_interests_callback);
    $("omniprofilepanel_interests").innerHTML = loading_img+" "+lang_getHTML("OmniProfileLoading","Interest");
    omni_profile_interests_ajax.request(hosturl+"handler/user/interestshandler.ashx","user_id="+escape(user.id));

    $("omniprofilepanel_content_empty").style.display = "none";
    $("omniprofilepanel_content").style.display = "block";
}

function omni_profile_interests_callback()
{
    if(!omni_profile_interests_ajax.isDone()) return;
    if(omni_profile_interests_ajax.hasError())
    {
        $("omniprofilepanel_interests").innerHTML="<span id=\"Omni_Localized_OmniProfileStatusError_Int\" style=\"color:#993333;\">"+lang_getText("OmniProfileStatusError")+"</span>";
        return;
    }    
    var status = omni_profile_interests_ajax.getJSON().status;
    if(status=="OK")
    {
        var interests = omni_profile_interests_ajax.getJSON().interests;
        $("omniprofilepanel_interests").innerHTML = profile_interests_table(interests, "omniprofilepanel");
    }
    else
    {
        $("omniprofilepanel_interests").innerHTML="<span id=\"Omni_Localized_OmniProfileStatusError_Int\" style=\"color:#993333;\">"+lang_getText("OmniProfileStatusError")+"</span>";
    }    
}

// Friends List
var friends_list_ajax = null;
var friends = null;
function friends_list_retrieve()
{
    if(friends_list_ajax == null)
        friends_list_ajax = new AniScript.Web.Ajax();
    friends_list_ajax.setHandler(friends_list_retrieve_callback);
    friends_list_ajax.request(hosturl + "handler/friends/ListHandler.ashx");
}

function friends_list_retrieve_callback()
{
    if(!friends_list_ajax.isDone()) return;
    
    if(friends_list_ajax.hasError())
    {
        $("friendspanel_friendstable").innerHTML="<span id=\"Omni_Localized_FriendsStatusError_Friends\" style=\"color:#993333;\">"+lang_getText("FriendsStatusError")+"</span>";
        return;
    }
    
    var table = $("friendspanel_friendstable");
    var tablestr = "<table class=\"detailtable\" cellpadding=\"2\" width=\"370\"><tr><th>"+lang_getHTML("OmniUserTableUsername","Friends")+"</th><th>"+lang_getHTML("OmniUserTableDisplayName","Friends")+"</th></tr>";
    friends = friends_list_ajax.getJSON();
    
    for(var x=0; x<friends.length; x++)
    {
        tablestr += "<tr><td><a href=\"#\" onclick=\"omni_profile_panel_display(friends["+x+"]); return false\">"+friends[x].username+"</a></td><td>"+friends[x].name+"</td></tr>";
    }
    tablestr += "</table>";
    table.innerHTML = tablestr;
}

// Search for a User (Friends Panel)
var friends_search_user_ajax = null;
var friends_search_results_users = null;
function friends_search_user()
{
    if(friends_search_user_ajax == null)
        friends_search_user_ajax = new AniScript.Web.Ajax();
        
    var search = $("friendspanel_searchcriteria").value;
        
    friends_search_user_ajax.setHandler(friends_search_user_callback);
    friends_search_user_ajax.request(hosturl + "handler/friends/searchusershandler.ashx","search="+escape(search));
}

function friends_search_user_callback()
{
    if(!friends_search_user_ajax.isDone()) return;
    
    if(friends_search_user_ajax.hasError())
    {
        $("friendspanel_searchresultstable").innerHTML="<span id=\"Omni_Localized_FriendsStatusError_Search\" style=\"color:#993333;\">"+lang_getText("FriendsStatusError")+"</span>";
        return;
    }
    
    var table = $("friendspanel_searchresultstable");
    results = friends_search_user_ajax.getJSON();
    friends_search_results_users = results; 
    if(results.length > 0)
    {
        var tablestr = "<table class=\"detailtable\" cellpadding=\"2\" width=\"370\"><tr><th>"+lang_getHTML("OmniUserTableUsername","FriendsSearch")+"</th><th>"+lang_getHTML("OmniUserTableDisplayName","FriendsSearch")+"</th></tr>";
        
        for(var x=0; x<results.length; x++)
        {
            tablestr += "<tr><td><a href=\"#\" onclick=\"omni_profile_panel_display(friends_search_results_users["+x+"]); return false\">"+results[x].username+"</a></td><td>"+results[x].name+"</td></tr>";
        }
        tablestr += "</table>";
        table.innerHTML = tablestr;
    }
    else table.innerHTML = "<span id=\"Omni_Localized_FriendsSearchNoResults\" style=\"color:green;\">"+lang_getText("FriendsSearchNoResults")+"</span>";
}

function friends_toggle_search_panel()
{
    var panel = $("friendspanel_searchpanel");
    if(panel.style.display != null && panel.style.display == "none")
        panel.style.display = "block";
    else panel.style.display = "none";
}


// -----------------------------------------------
//                 getIntroduced functions
// -----------------------------------------------

var get_introduced_ajax = new AniScript.Web.Ajax();

function get_introduced_retrieve()
{
    // FIXME : Displays all system languages. Should probably only
    // display those that the user has selected in their profile, but user languages
    // aren't implemented yet.
    if(user_current_obj != null  && system_languages.length != 0)
    {
        $("get_introduced_lang").options.length = system_languages.length;
        for(var x=0; x<system_languages.length; x++)
        {
            var myOpt = document.createElement("OPTION");
            myOpt.id = "Omni_Localized_LanguageName"+system_languages[x].short_code;
            myOpt.text = sys_lang_by_short_code(system_languages[x].short_code, "GetIntroduced");
            myOpt.value = system_languages[x].id;
            $("get_introduced_lang").options[x] = myOpt;
        }
    }
}

function get_introduced()
{
    $("get_introduced_status").innerHTML="";
    
    var selectedIndex = $("get_introduced_lang").selectedIndex;
    var language = $("get_introduced_lang").options[selectedIndex];
    $("get_introduced_lang").disabled = true;
    $("Omni_Localized_GetIntroducedIntroduceButton").disabled = true;
    
    get_introduced_ajax.setHandler(get_introduced_callback);
    get_introduced_ajax.request(hosturl + "handler/friends/GetIntroducedHandler.ashx", 
            "language=" + escape(language));
}

function get_introduced_callback()
{
    if(!get_introduced_ajax.isDone()) return;
    
    $("get_introduced_lang").disabled = false;
    $("Omni_Localized_GetIntroducedIntroduceButton").disabled = false;
    
    if(get_introduced_ajax.hasError())
    {
        $("get_introduced_status").innerHTML="<span id=\"Omni_Localized_GetIntroducedStatusError\" style=\"color:#993333;\">"+lang_getText("GetIntroducedStatusError")+"</span>";
        return;
    }
    
    var status = get_introduced_ajax.getJSON().status;
    if(status=="No Match")
    {
        $("get_introduced_status").innerHTML="<span id=\"Omni_Localized_GetIntroducedNoMatch\" style=\"color:green;\">"+lang_getText("GetIntroducedNoMatch")+"</span>";
    }
}
