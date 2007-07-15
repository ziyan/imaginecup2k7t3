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


// Accepts array of Interest
// prefix (userprofilepanel, etc). Do not include any "_"'s.
// Returns string (HTML)
// In the output, rows are uniquely identified by the following string
//       prefix_interest_id
// e.g.  userprofilepanel_interest_12
// FIXME: Localize
function users_interests_table(interests, prefix)
{
    var output = "<span style=\"line-height: 14px\">";
    output += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
    // Only works for one level of parents
    for(var i=0; i<interests.length; i++)
    {
        var parent = interests[i];
        if(parent.parent_id != 0) continue;
        
        output += "<tr>";
        output += "<td style=\"width:0px\"></td>"; //no indent
        output += "<td id=\""+prefix+"_interest_"+parent.id+"\"></td>"; //panels can add checkboxes if needed here
        output += "<td>"+parent.name+"</td>";        
        output += "</tr>";  
        output += "<tr><td colspan=\"3\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";/*<tr><td>";*/
        for(var j=0; j<interests.length; j++)
        {
            var child = interests[j];
            if(child.parent_id != parent.id) continue;
            output += "<tr>";
            output += "<td style=\"width:16px\"></td>"; //indent
            output += "<td id=\""+prefix+"_interest_"+child.id+"\"></td>"; //panels can add checkboxes if needed here
            output += "<td>"+child.name+"</td>";            
            output += "</tr>";            
        }
        output += "</table></td></tr>";
    }
    output += "</table></span>";
    return output;
}