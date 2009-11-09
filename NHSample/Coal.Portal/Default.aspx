<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>会员中心</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/ui.core.js"></script>
    <script type="text/javascript" src="js/ui.accordion.js"></script>
    <script type="text/javascript" src="js/top.js"></script>
    <script type="text/javascript">
        $(function() {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "Handler/GetFuncList.ashx",
                success: function(j) {
                    if (j.status == -1) {
                        $("#accordion").html("菜单加载异常");
                    }
                    else {
                        var i;
                        var html = "";
                        for (i in j) {
                            var o = j[i];
                            if (o.Parent == -1) {
                                if (html != "") {
                                    html += "</ul>";
                                }
                                html += "<h3 class='menu_b'><a href='" + o.Url + "'>" + o.Name + "</a></h3>";
                                html += "<ul>";
                            }
                            else {
                                html += "<li class='menu_c'><a href='" + o.Url + "'>" + o.Name + "</a></li>";
                            }
                        }

                        $("#accordion").empty();
                        $("#accordion").html(html);
                        $("#accordion").accordion();
                    }
                }
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="userht_all">

        <script type="text/javascript">
            render_top();
        </script>

        <div id="accordion" class="left_all">
        </div>
        <div class="right_all">
            <h1>
                信息首页</h1>
            请完善会员资料
        </div>

        <script type="text/javascript">
            render_bottom();
        </script>

    </div>
    </form>
</body>
</html>
