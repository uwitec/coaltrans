$(document).ready(function() {
    //load列表初始数据
    $.ajax({
        type: "POST",
        url: "Handler/LatestList.ashx",
        data: "coal_type=1&tran_type=1",
        dataType: "json",
        success: function(msg) {
            var content = "<table width='100%' border='0' cellspacing='0' cellpadding='0' class='tb_bg'>\
                                          <tr><th>煤种</th><th>发热量</th><th>价格(元)</th><th>提货地</th><th>日期</th></tr>";
            $.each(msg.rows, function(i, row) {
                content += "<tr>";
                content += "<td><a href='coal_detail.aspx?ID=" + row.ID + "'>" + row.CategoryName + "</a></td>";
                content += "<td>" + row.CalorificPower + "大卡</td>";
                content += "<td>" + row.Price + "</td>";
                content += "<td>" + row.CityName + "</td>";
                content += "<td>" + row.CreatedOn + "</td>";
                content += "</tr>";
            });
            content += "<table>";
            $("#supply_list").html(content);
        }
    });

    //load列表初始数据
    $.ajax({
        type: "POST",
        url: "Handler/LatestList.ashx",
        data: "coal_type=1&tran_type=2",
        dataType: "json",
        success: function(msg) {
            var content = "<table width='100%' border='0' cellspacing='0' cellpadding='0' class='tb_bg'>\
                                          <tr><th>煤种</th><th>发热量</th><th>价格(元)</th><th>报价方式</th><th>日期</th></tr>";
            $.each(msg.rows, function(i, row) {
                content += "<tr>";
                content += "<td><a href='coal_detail.aspx?ID=" + row.ID + "'>" + row.CategoryName + "</a></td>";
                content += "<td>" + row.CalorificPower + "大卡</td>";
                content += "<td>" + row.Price + "</td>";
                content += "<td>平仓价</td>";
                content += "<td>" + row.CreatedOn + "</td>";
                content += "</tr>";
            });
            content += "<table>";
            $("#demand_list").html(content);
        }
    });

    //图片轮转
    $(".triggers").children().each(function() {
        $(this).mouseover(function() {
            var index = $(this).html() - 1;
            $("#img_container li").each(function() {
                $(this).hide();
            });
            $("#img_container li").eq(index).show();

            $("#slide_trigger li").each(function() {
                $(this).removeClass();
            });
            $(this).addClass("current");
        });
    });
    //供应导航
    $("#supply_nav a").each(function() {
        $(this).click(function() {
            $("#supply_nav a").each(function() {
                $(this).removeClass().addClass("bq02");
            });
            $(this).removeClass().addClass("bq01");
            //载入数据
            var type_id = $(this).attr("id");
            var request_date = "tran_type=1&coal_type=" + type_id;
            $.ajax({
                type: "POST",
                url: "Handler/LatestList.ashx",
                data: request_date,
                dataType: "json",
                success: function(msg) {
                    var content = "<table width='100%' border='0' cellspacing='0' cellpadding='0' class='tb_bg'>\
                                      <tr><th>煤种</th><th>发热量</th><th>价格(元)</th><th>提货地</th><th>日期</th></tr>";
                    $.each(msg.rows, function(i, row) {
                        content += "<tr>";
                        content += "<td><a href='coal_detail.aspx?ID=" + row.ID + "'>" + row.CategoryName + "</a></td>";
                        content += "<td>" + row.CalorificPower + "大卡</td>";
                        content += "<td>" + row.Price + "</td>";
                        content += "<td>" + row.CityName + "</td>";
                        content += "<td>" + row.CreatedOn + "</td>";
                        content += "</tr>";
                    });
                    content += "<table>";
                    $("#supply_list").html(content);
                }
            });
        });
    });

    //需求导航
    $("#demand_nav a").each(function() {
        $(this).click(function() {
            $("#demand_nav a").each(function() {
                $(this).removeClass().addClass("bq02");
            });
            $(this).removeClass().addClass("bq01");
            //载入数据
            var type_id = $(this).attr("id");
            var request_date = "tran_type=2&coal_type=" + type_id;
            $.ajax({
                type: "POST",
                url: "Handler/LatestList.ashx",
                data: request_date,
                dataType: "json",
                success: function(msg) {
                    var content = "<table width='100%' border='0' cellspacing='0' cellpadding='0' class='tb_bg'>\
                                      <tr><th>煤种</th><th>发热量</th><th>价格(元)</th><th>报价方式</th><th>日期</th></tr>";
                    $.each(msg.rows, function(i, row) {
                        content += "<tr>";
                        content += "<td><a href='coal_detail.aspx?ID=" + row.ID + "'>" + row.CategoryName + "</a></td>";
                        content += "<td>" + row.CalorificPower + "大卡</td>";
                        content += "<td>" + row.Price + "</td>";
                        content += "<td>平仓价</td>";
                        content += "<td>" + row.CreatedOn + "</td>";
                        content += "</tr>";
                    });
                    content += "<table>";
                    $("#demand_list").html(content);
                }
            });
        });
    });

    var logon = "<tr><td><div class='loginend'>\
		  <h1><span>欢迎您</span><a id='nick_name' href='#'>meitan@gmail.com</a><em><a id='login_out' href='#'>退出</a></em></h1>\
		  <ul><li><a href='uc_index.aspx'>进入用户中心首页</a></li>\
		  <li><a href='#'>进入功能一</a></li>\
		  <li><a href='#'>进入功能一</a></li>\
		  <li><a href='#'>进入功能一</a></li>\
		  </ul><div class='clear'></div>\
		 </div></td></tr>";

    $.ajax({
        type: "POST",
        url: "Handler/Login.ashx",
        success: function(msg) {
            if (msg.status > 0) {
                var logon_content = $("#login_container").children("tbody").empty().html(logon);
                $("#nick_name").html(msg.nick_name);
                $(".laodinguser").hide();
                $("#login_msg").hide();
                $("#login_out").click(function() {
                    window.location = "http://localhost:2150/Coal.Portal/index.html";
                });
            }
        }
    });

    $("#login_action").click(function() {
        var password = $("#password").val();
        var email = $("#email").val();
        var login_data = { e: email, p: password };
        var tbody = $("#login_container").children("tbody");
        $.ajax({
            type: "POST",
            url: "Handler/Login.ashx",
            data: login_data,
            dataType: "json",
            success: function(msg) {
                if (msg.status > 0) {
                    var logon_content = $("#login_container").children("tbody").empty().html(logon);
                    $("#nick_name").html(msg.nick_name);
                    $(".laodinguser").hide();
                    $("#login_msg").hide();
                    $("#login_out").click(function() {
                        window.location = "http://localhost:2150/Coal.Portal/index.html";
                    });
                }
                else {
                    if (msg.error_code == 1) {
                        tbody.children(".login_init").show();
                        tbody.children(".login_load").hide();
                        $("#login_msg").show();
                    }
                }
            },
            beforeSend: function() {
                tbody.children(".login_init").hide();
                tbody.children(".login_load").show();
            }
        });
    });
});