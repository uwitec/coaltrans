var user_group = { "1": "普通用户", "2": "认证用户", "3": "会员" };

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
                    var menu_url = menu.url == "" ? "#" : menu.url;
                    html += "<h2 id='menu_" + menu.id + "'><a href='" + menu_url + "' class='off'>" + menu.name + "</a></h2>";
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
                    if (parent_menu != -1) {
                        $("#" + parent_menu).children("a").removeClass().addClass("on");
                    }
                }

                $("#welcome").prepend("欢迎 " + j.nick_name + " 登录系统 ");
                $("#user_type").empty().html("您目前是" + user_group[j.user_group]);

                if (j.user_group == "3") {
                    $("#oprate_prompt").next("p").hide();
                    $("#oprate_prompt").hide();
                }
                else if (j.user_group == "2") {
                    $("#valid_user").hide();
                }
                else if (j.user_group == "1") {
                    $("#join_member").hide();
                }
            }
        },
        beforeSend: function() {
            $("#nav_tree").empty().html("列表加载中……");
        }
    });
});