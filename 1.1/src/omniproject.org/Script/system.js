// Functions for Users (e.g. Profiles, etc)

/*
Common Objects:

Interests : Array of Interest
Interest : Object
  id
  parent_id
  name
  
Languages : Array of Language
Language : Object
  id
  name
  known     (true / false)
  skill     (int, 1 to 5)
  
*/

// Interests and Languages (full list)
var system_languages_ajax = new AniScript.Web.Ajax(); // Ajax
var system_interests_ajax = new AniScript.Web.Ajax(); // Ajax
var system_languages = null; // Language[]
var system_interests = null; // Interest[]

//load system interests
function system_interests_init()
{
    system_interests_loading = true;
    system_interests_ajax.setHandler(system_interests_callback);
    system_interests_ajax.request("/handler/interest/listhandler.ashx");
}

//callback system interests
function system_interests_callback()
{
    if(!system_interests_ajax.isDone()) return;
    system_interests_loading = false;
    if(system_interests_ajax.hasError())
    {
        server_error = true;
        system_interests = null;
    }
    else
        system_interests = system_interests_ajax.getJSON();
}

// callback from init
/*
function system_languages_callback()
{
    if(!system_languages_ajax.isDone()) return;
    system_languages_loading = false;
    if(system_languages_ajax.hasError())
    {
        if(!user_loading)
            server_error = true;
        system_languages = null;
        if(!user_loading && !system_interests_loading && !system_languages_loading)
            user_state_update(true);        
        return;
    }
    else system_languages = system_languages_ajax.getJSON();
    if(!user_loading && !system_interests_loading && !system_languages_loading)
        user_state_update(true);    
} 
*/




// Accepts array of Interest
// prefix (userprofilepanel, etc). Do not include any "_"'s.
// Returns string (HTML)
// In the output, rows are uniquely identified by the following string
//       prefix_interest_id
// e.g.  userprofilepanel_interest_12
// FIXME: Localize
function system_interests_table(prefix)
{
    if(system_interests==null) return "";
    var output = "<span style=\"line-height: 14px\">";
    output += "<table>";
    // Only works for one level of parents
    for(var i=0; i<system_interests.length; i++)
    {
        var parent = system_interests[i];
        if(parent.parent_id != 0) continue;
        output += "<tr>";
        output += "<td style=\"padding-left:16px\"><span id=\""+prefix+"_interest_"+parent.id+"\"></span>"+lang_getHTML("InterestName"+parent.name,prefix)+"</td>"; 
        output += "</tr>";  
        for(var j=0; j<system_interests.length; j++)
        {
            var child = system_interests[j];
            if(child.parent_id != parent.id) continue;
            output += "<tr>";
            output += "<td style=\"padding-left:16px\"><span id=\""+prefix+"_interest_"+child.id+"\"></span>"+lang_getHTML("InterestName"+child.name,prefix)+"</td>"; 
            output += "</tr>";            
        }
    }
    output += "</table></span>";
    return output;
}