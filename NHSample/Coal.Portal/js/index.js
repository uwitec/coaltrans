$(document).ready(function() {

    LoadAd('A1',1);
    LoadAd('A2',5);
    LoadAd('A3',6);
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
    
    //load招标信息列表
    $.ajax({
        type: "POST",
        url: "Handler/InfoList.ashx",
        data: {"top": 7,"TableName":"InviteInfo","StrWhere":"IsAudit=1","OrderBy":" RankNum, CreateTime DESC"},
        dataType: "json",
        success: function(msg) {  
            var content="";          
            $.each(msg.rows, function(i, row) {
                content += "<li>";
                content += "<a href='javascript:void(null);' title='"+row.InviteTitle+"'>" + row.InviteTitle.substring(0,20)+ "...</a></td>";               
                content += "</li>";
            });
            $("#InviteNav").html(content);
        }
    });
    
    //load投标信息列表
    $.ajax({
        type: "POST",
        url: "Handler/InfoList.ashx",
        data: {"top": 7,"TableName":"TenderInfo","StrWhere":"IsAudit=1","OrderBy":" RankNum, CreateTime DESC"},
        dataType: "json",
        success: function(msg) {  
            var content="";          
            $.each(msg.rows, function(i, row) {
                content += "<li>";
                content += "<a href='javascript:void(null);' title='"+row.TenderTitle+"'>" + row.TenderTitle.substring(0,20)+ "...</a></td>";               
                content += "</li>";
            });
            $("#TenderNav").html(content);
        }
    });
    
    //load友情链接列表
    $.ajax({
        type: "POST",
        url: "Handler/InfoList.ashx",
        data: {"top": 10,"TableName":"FriendLink","StrWhere":"CategoryId=1","OrderBy":" ShowOrder"},
        dataType: "json",
        success: function(msg) {  
            var content="";          
            $.each(msg.rows, function(i, row) {
                var Url= (row.LinkUrl==""? "javascript:void(null);": "http://"+row.LinkUrl);
                var Img=(row.LinkLogo==""? row.LinkName : "<img src='"+row.LinkLogo+"' border='0' width='70px' height='25px'/>");
                content += "<li>";
                content += "<a href='"+Url+"' title='"+row.LinkName+"' target='_blanl'>" +Img + "<a></td>";               
                content += "</li>";
            });
            $("#LinkNav").html(content);
        }
    });
    
    function LoadAd(obj,PositionId)
    {
         //load友情链接列表
        $.ajax({
            type: "POST",
            url: "Handler/AdManage.ashx",
            data: {"action":"Search","PositionId":PositionId},
            dataType: "json",
            success: function(msg) {  
                var content="<ul>";          
                $.each(msg.rows, function(i, row) {        
                    if(row.AdType=="1")
                    {            
                        content += "<li>";
                        content += "<a href='http://"+row.AdLink+"' title='"+row.AdName+"' target='_blank'><img src='"+row.AdUrl+"' width='"+row.AdWidth+"' height='"+row.AdHeight+"' border='0' ><a></li>";             
                        content += "</li>";
                    }
                });
                content+="</ul>";                
                $("#"+obj).html(content);                
            }
        });
    }
    
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

    //登录
    var logon = "<tr><td><div class='loginend'>\
		  <h1><span>欢迎您</span><a id='nick_name' href='#'>meitan@gmail.com</a><em><a id='login_out' href='log_out.aspx'>退出</a></em></h1>\
		  <ul><li><a href='uc_index.aspx'>进入用户中心首页</a></li>\
		  <li><a href='#'>进入功能一</a></li>\
		  <li><a href='#'>进入功能一</a></li>\
		  <li><a href='#'>进入功能一</a></li>\
		  </ul><div class='clear'></div>\
		 </div></td></tr>";

    $.ajax({
        type: "POST",
        url: "Handler/GetFuncList.ashx",
        dataType: "json",
        success: function(j) {
            if (j.status == -1) {
            }
            else if (j.status == -2) {
            }
            else {
                var logon_content = $("#login_container").children("tbody").empty().html(logon);
                $("#nick_name").html(j.nick_name);
                $(".laodinguser").hide();
                $("#login_msg").hide();
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
    
    var navlist=$("#selectSort").find("a");
    $(navlist).click(function(){
        $("#selectTitle").html($(this).html());
    });
    
});