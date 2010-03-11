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

    var today = new Date();
    var month = parseInt(today.getMonth()) + 1;
    $("#user_info").html("您好，<strong>国科安信</strong>，今天是" + today.getFullYear()
    + "年" + month + "月" + today.getDate() + "日，[ <a href=\"#\">退出</a> ]");
});