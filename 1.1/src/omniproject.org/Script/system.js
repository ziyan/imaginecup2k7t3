// Omni system stuff : Languages & Interests

/*
Common Objects:

System Interests : Array of Interest
System Interest : Object
  id
  parent_id
  name
User Interests: Array of interest_id's that match
  with loaded System Interests.  
  
System Languages : Array of Language
System Language : Object
  id
  code (i.e. culture code)
User Languages: Structure TBD, but user_lang.id matches with
  a valid system language id
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
    system_interests_ajax.request(hosturl+"handler/interest/listhandler.ashx");
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

//load system languages
function system_languages_init()
{
    system_languages_loading = true;
    system_languages_ajax.setHandler(system_languages_callback);
    system_languages_ajax.request(hosturl+"handler/language/listhandler.ashx");
}

//callback system languages
function system_languages_callback()
{
    if(!system_languages_ajax.isDone()) return;
    system_languages_loading = false;
    if(system_languages_ajax.hasError())
    {
        server_error = true;
        system_languages = null;
    }
    else
    {
        system_languages = system_languages_ajax.getJSON();
        for(var x=0; x<system_languages.length; x++)
        {
            system_languages[x].short_code = sys_lang_upper(system_languages[x].code);
        }
    }
}


// prefix (userprofilepanel, etc). Do not include any "_"'s.
// Returns string (HTML)
// In the output, rows are uniquely identified by the following string
//       prefix_interest_id
// e.g.  userprofilepanel_interest_12
function system_interests_table(prefix)
{
    if(system_interests==null) return "";
    var output = "<span style=\"line-height: 10px\"><table>";
    // Only works for one level of parents
    for(var i=0; i<system_interests.length; i++)
    {
        var parent = system_interests[i];
        if(parent.parent_id != 0) continue;
        output += "<tr>";
        output += "<td style=\"padding-left:0px\"><span id=\""+prefix+"_interest_"+parent.id+"\"></span>"+lang_getHTML("InterestName"+parent.name,prefix)+"</td>"; 
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
    var output = "<span style=\"line-height: 10px\"><table>";
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
                idx = ids[k1];
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
                    idx = ids[k2];
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

// Language stuff
// Localize a language name by ID
// span: true to auto-localize (surrounded by localizable span)
function sys_lang_by_id(id, prefix, span)
{
    if(system_languages == null) return "";
    for(var x = 0; x<system_languages.length;x++)
    {
        if(system_languages[x].id == id)
        {
            return sys_lang_by_short_code(system_languages[x].short_code, prefix, span);
        }
    }
    return "";
}

// Localize a language name by culture code (en-US)
// span: true to auto-localize (surrounded by localizable span)
function sys_lang_by_code(code, prefix, span)
{
    return sys_lang_by_short_code(sys_lang_upper(code), prefix, span);
}

// Localize a language name by shortened code (ENUS)
// span: true to auto-localize (surrounded by localizable span)
function sys_lang_by_short_code(code, prefix, span)
{
    var str = "LanguageName"+code;
    if(span != null && span != undefined && span)
        return lang_getHTML(str);
    else return lang_getText(str);
}

// Convert a lang culture code (en-US) to the shortened form for localization (ENUS)
function sys_lang_upper(code)
{
    return code.replace("-","").toUpperCase();
}
