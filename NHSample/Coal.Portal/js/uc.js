$(document).ready(function() {
    $.ajax({
        type: "POST",
        url: "Handler/GetFuncList.ashx",
        dataType: "json",
        success: function(j) {
            if (j.status == -1) {
                //$("#nav_tree").empty().html("菜单加载异常");
                window.location = j.url;
            }
            else if (j.status == -2) {
                window.location = j.url;
            }
            else {
                var html = "";
                for (var menu_i in j.menus) {
                    var menu = j.menus[menu_i];
                    html += "<h2 id='menu_" + menu.id + "'><a href='#' class='off'>" + menu.name + "</a></h2>";
                    if (menu.children.length > 0) {
                        html += "<ul class='h_treeChild' id='menuList1'  style='display:none;'>";
                        for (var child_i in menu.children) {
                            var child = menu.children[child_i];
                            html += "<li id='menu_" + child.id + "'><a href='" + child.url + "'>" + child.name + "</a></li>";
                        }
                        html += "</ul>";
                    }
                }

                $("#nav_tree").empty().html(html);
                $("#nav_tree h2").each(function() {
                    var child_tree = $(this).next();
                    $(this).click(function() {
                        $("#nav_tree h2 a").removeClass().addClass("off");
                        $("#nav_tree ul").hide();
                        child_tree.show();
                        $(this).children("a").removeClass().addClass("on");
                    });
                });

                var current_menu = $("#current_menu").val();
                if (current_menu != "") {
                    $("#" + current_menu).parent().show();
                    $("#" + current_menu).addClass("current");
                    var parent_menu = $("#parent_menu").val();
                    $("#" + parent_menu).children("a").removeClass().addClass("on");
                }
            }
        },
        beforeSend: function() {
            $("#nav_tree").empty().html("列表加载中……");
        }
    });
});