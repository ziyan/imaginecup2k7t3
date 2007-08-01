
// ------------------- Hall of Fame -------------------
var hall_of_fame_rating_ajax = new AniScript.Web.Ajax();
var hall_of_fame_quantity_ajax = new AniScript.Web.Ajax();
var hall_of_fame_rating_results = null;
var hall_of_fame_quantity_results = null;
function hall_of_fame_init(retrieve)
{
    if(user_is_logged_in())
    {
        $("halloffamepanel_myrating").innerHTML = user_current_obj.user_rating;
        $("halloffamepanel_myratingtable").style.display = '';
    }
    else
    {
        $("halloffamepanel_myratingtable").style.display = 'none';
    }
    
    $("halloffamepanel_byratingtable").innerHTML = loading_img+" "+lang_getHTML("HallOfFameLoading","HOFRating");
    $("halloffamepanel_byquantitytable").innerHTML = loading_img+" "+lang_getHTML("HallOfFameLoading","HOFQuantity");
    
    // Retrieve (ajax)
    hall_of_fame_rating_ajax.setHandler(hall_of_fame_rating_callback);
    hall_of_fame_rating_ajax.request(hosturl + "handler/halloffame/byratinghandler.ashx");
    hall_of_fame_quantity_ajax.setHandler(hall_of_fame_quantity_callback);
    hall_of_fame_quantity_ajax.request(hosturl + "handler/halloffame/byquantityhandler.ashx");    
}

function get_hall_of_fame_table(results, prefix, resultobj)
{
        var tablestr = "<table class=\"detailtable\" cellpadding=\"2\"><tr><th></th><th>"+lang_getHTML("OmniUserTableUsername",prefix)+"</th><th>"+lang_getHTML("OmniUserTableDisplayName",prefix)+"</th><th>"+lang_getHTML("HallOfFameRank",prefix)+"</th></tr>";
        
        for(var x=0; x<results.length; x++)
        {
            tablestr += "<tr><td>"+(x+1)+"</td><td><a href=\"#\" onclick=\"omni_profile_panel_display("+resultobj+"["+x+"].user); return false\">"+results[x].user.username+"</a></td><td>"+results[x].user.name+"</td><td>"+results[x].rank+"</td></tr>";
        }
        tablestr += "</table>";
        return tablestr;
}

function hall_of_fame_rating_callback()
{
    var table = $("halloffamepanel_byratingtable");

    if(!hall_of_fame_rating_ajax.isDone()) return;
    
    if(hall_of_fame_rating_ajax.hasError())
    {
        table.innerHTML="<span id=\"Omni_Localized_HallOfFameStatusError\" style=\"color:#993333;\">"+lang_getText("HallOfFameStatusError","HOFRating")+"</span>";
        return;
    }
    var results = hall_of_fame_rating_ajax.getJSON();
    hall_of_fame_rating_results = results; 
    table.innerHTML = get_hall_of_fame_table(results, "HOFRating","hall_of_fame_rating_results");
}

function hall_of_fame_quantity_callback()
{
    var table = $("halloffamepanel_byquantitytable");

    if(!hall_of_fame_quantity_ajax.isDone()) return;
    
    if(hall_of_fame_quantity_ajax.hasError())
    {
        table.innerHTML="<span id=\"Omni_Localized_HallOfFameStatusError\" style=\"color:#993333;\">"+lang_getText("HallOfFameStatusError","HOFQuantity")+"</span>";
        return;
    }
    var results = hall_of_fame_quantity_ajax.getJSON();
    hall_of_fame_quantity_results = results; 
    table.innerHTML = get_hall_of_fame_table(results, "HOFQuantity","hall_of_fame_quantity_results");
}