$(document).ready(function() {
    var nav_content = "";
    $.each(nav_data.data, function(i, n) {
        var nav_current = "";
        if (n.is_current) {
            nav_current = " class=\"current\" ";
        }
        nav_content += "<li" + nav_current + "><span><a href=\"" + n.href + "\" onfocus=\"blur();\">" + n.title + "</a></span></li>";
    });
    $("#nav").html(nav_content);
});