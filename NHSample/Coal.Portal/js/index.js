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
                content += "<td><a href='SupplyDetail.aspx?ID=" + row.ID + "'>" + row.CategoryName + "</a></td>";
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
                content += "<td><a href='SupplyDetail.aspx?ID=" + row.ID + "'>" + row.CategoryName + "</a></td>";
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
                        content += "<td><a href='SupplyDetail.aspx?ID=" + row.ID + "'>" + row.CategoryName + "</a></td>";
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
                        content += "<td><a href='SupplyDetail.aspx?ID=" + row.ID + "'>" + row.CategoryName + "</a></td>";
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
		  <h1><span>欢迎您</span><a href='#'>meitan@gmail.com</a><em><a id='login_out' href='#'>退出</a></em></h1>\
		  <ul><li><a href='#'>进入功能一</a></li>\
		  <li><a href='#'>进入功能一</a></li>\
		  <li><a href='#'>进入功能一</a></li>\
		  <li><a href='#'>进入功能一</a></li>\
		  </ul><div class='clear'></div>\
		 </div></td></tr>";

    var loginning = "<tr><td><div class='laodinguser'><img src='images/loading01.gif' width='32' height='32' /><br />\
		            正在登录，请稍后......</div></td></tr>";


    $("#login_action").click(function() {
        $.ajax({
            type: "POST",
            url: "Handler/Login.ashx",
            data: "login_name=cheese&password=windows",
            dataType: "json",
            success: function(msg) {
                if (msg.status > 0) {
                    var logon_content = $("#login_container").children("tbody").empty().html(logon);
                    $(".laodinguser").hide();
                    $("#login_out").click(function() {
                        window.location = "http://localhost:2150/Coal.Portal/index.html";
                    });
                }
                else {
                    if (msg.error_code == 1) {
                        $("#login_container").show();
                        $("#login_container").before("用户名密码不正确");
                    }
                }
            },
            beforeSend: function() {
                $("#login_container").children("tbody").empty().html(loginning);
            }
        });
    });


});