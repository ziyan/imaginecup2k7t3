/*
 * Module for rater
 */

function rater_create(id, _type, current_rating, user_rating)
{
    //type = 0      can not rate
    //type = 1      can rate once
    //type = 2      can rate multiple time
    
    var type = _type;
    if(user_rating > 0) type = 0;
    
    var html="";
    html+="<ul id=\""+id+"\" class=\"rater\">";
    html+="<li id=\""+id+"_current_rating\" class=\"current-rating\" style=\"width:"+(current_rating*25)+"px;\">"+current_rating+"</li>";
    html+="<li id=\""+id+"_user_rating\" class=\"user-rating\" style=\"width:"+(user_rating*25)+"px;\">"+user_rating+"</li>";
    html+="<li id=\""+id+"_rating\" style=\"display: none;\">0</li>";
    if(type>0)
    {
        html+="<li><a href=\"#\" id=\""+id+"_star1\" class=\"star-one\" onclick=\"rater_rate('"+id+"',"+type+",1);return false\"></a></li>";
        html+="<li><a href=\"#\" id=\""+id+"_star2\" class=\"star-two\" onclick=\"rater_rate('"+id+"',"+type+",2);return false\"></a></li>";
        html+="<li><a href=\"#\" id=\""+id+"_star3\" class=\"star-three\" onclick=\"rater_rate('"+id+"',"+type+",3);return false\"></a></li>";
        html+="<li><a href=\"#\" id=\""+id+"_star4\" class=\"star-four\" onclick=\"rater_rate('"+id+"',"+type+",4);return false\"></a></li>";
        html+="<li><a href=\"#\" id=\""+id+"_star5\" class=\"star-five\" onclick=\"rater_rate('"+id+"',"+type+",5);return false\"></a></li>";
    }
    html+="</ul>";
    return html;
}

var rate_answer_ajax = null;

function rater_rate(id, type, score)
{
    if(type==0||type==1)
    {
        $(id+"_star1").style.display="none";
        $(id+"_star2").style.display="none";
        $(id+"_star3").style.display="none";
        $(id+"_star4").style.display="none";
        $(id+"_star5").style.display="none";
    }
    if(type==0) return;
    
    if(type==1)
    {
        var rateridx = id.replace("TransAnsRater","");
        if(view_trans_details_ans_obj == null) return;
        var ansobj = view_trans_details_ans_obj[rateridx];
        if(ansobj == undefined || ansobj == null) return;
        var transansid = ansobj.trans_id;
    
        if(rate_answer_ajax == null) rate_answer_ajax = new AniScript.Web.Ajax();
        rate_answer_ajax.setHandler(rate_answer_callback);
        rate_answer_ajax.request(hosturl+"handler/translation/answerratehandler.ashx","transansid="+escape(transansid)+"&rating="+escape(score));
        
        ansobj.user_rating = score;
        $("transdetailpanel_ans").innerHTML=get_trans_ans_table(view_trans_details_ans_obj);    
    
        $(id+"_user_rating").innerHTML = score;
        $(id+"_user_rating").style.width = ""+(score*25)+"px";
    }
    if(type==2)
    {
        $(id+"_user_rating").innerHTML = score;
        $(id+"_user_rating").style.width = "0px";
        $(id+"_current_rating").innerHTML = score;
        $(id+"_current_rating").style.width = ""+(score*25)+"px";
    }
    $(id+"_rating").innerHTML=score;
}

function rate_answer_callback()
{
    // Don't do anything for now
}

function rater_get_rating(id)
{
    return parseInt($(id+"_rating").innerHTML);
    return parseInt($(id+"_current_rating").innerHTML);
}
function rater_get_user_rating(id)
{
    return parseInt($(id+"_user_rating").innerHTML);
}
function rater_get_current_rating(id)
{
    return parseInt($(id+"_current_rating").innerHTML);
}