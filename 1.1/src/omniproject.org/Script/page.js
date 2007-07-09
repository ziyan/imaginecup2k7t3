/*
 * Page control
 */

var pool = null;
var content = null;
var content_left_center_right = null;
var content_big_left_right = null;
var content_left_big_right = null;
var content_big_center = null;

var content_left = null;
var content_center = null;
var content_right = null;

var page_current = "Home";

function page_init()
{
    pool = $("pool");
    content = $("content");
    content_left_center_right=$("content_left_center_right");
    content_big_left_right=$("content_big_left_right");
    content_left_big_right=$("content_left_big_right");
    content_big_center=$("content_big_center");
    content_left=$("content_left");
    content_center=$("content_center");
    content_right=$("content_right");
    var page_name_string = "";
    if(location.href.indexOf("#")>-1)
        page_name_string=location.href.split("#")[1];

    page_goto_home();
}
//AniScript.Loader.add(page_init);

function page_clear()
{
    for(var i=0;i<content_left.childNodes.length;i++)
    {
        pool.appendChild(content_left.childNodes[i]);
    }
    for(var i=0;i<content_center.childNodes.length;i++)
    {
        pool.appendChild(content_center.childNodes[i]);
    }
    for(var i=0;i<content_right.childNodes.length;i++)
    {
        pool.appendChild(content_right.childNodes[i]);
    }
    pool.appendChild(content_left_center_right);
    pool.appendChild(content_big_left_right);
    pool.appendChild(content_left_big_right);
    pool.appendChild(content_big_center);
    pool.appendChild(content_left);
    pool.appendChild(content_center);
    pool.appendChild(content_right);
}

function page_layout_left_center_right()
{
    content.appendChild(content_left_center_right);
    content_left_center_right.appendChild(content_left);
    content_left_center_right.appendChild(content_center);
    content_left_center_right.appendChild(content_right);
}

function page_layout_big_left_right()
{
    content.appendChild(content_big_left_right);
    content_big_left_right.appendChild(content_left);
    //content_big_left_right.appendChild(content_center);
    content_big_left_right.appendChild(content_right);
}

function page_layout_left_big_right()
{
    content.appendChild(content_left_big_right);
    content_left_big_right.appendChild(content_left);
    //content_left_big_right.appendChild(content_center);
    content_left_big_right.appendChild(content_right);
}

function page_layout_big_center()
{
    content.appendChild(content_big_center);
    //content_big_center.appendChild(content_left);
    content_big_center.appendChild(content_center);
    //content_big_center.appendChild(content_right);
}

function page_goto_register()
{
    page_clear();
    page_layout_big_left_right();
    content_right.appendChild($("userpanel"));
    content_left.appendChild($("userregisterpanel"));
}

function page_goto_home()
{
    page_clear();
    page_layout_left_center_right();
    content_right.appendChild($("userpanel"));
    content_center.appendChild($("transautopanel"));
    content_left.appendChild($("pagecontentpanel"));
}
