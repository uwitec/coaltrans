<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {

            $("#result").hide();

            $("#btnSearch").click(function() {
                var keyword = $("#keywords").val();
                $.get("Handler/Handler.ashx", { 'keyword': keyword },
                    function(data) {
                        $("#result").html(data);
                        $("#result").show(800);
                    }
                );
            });

            $("#sanqiang").click(function() {
                $.get("Handler/Handler.ashx", { 'category': '959745164408552732' },
                    function(data) {
                        $("#result").html(data);
                        $("#result").show(800);
                    }
                );
            });

            $("#feiwen").click(function() {
                $.get("Handler/Handler.ashx", { 'category': '140332856652885721' },
                    function(data) {
                        $("#result").html(data);
                        $("#result").show(800);
                    }
                );
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="text" id="keywords" name="keywords" /><input type="button" id="btnSearch" name="btnSearch" value="搜索" />
    <br/>
    <a id="feiwen" name="feiwen" href="javascript:void(0);">绯闻</a>&nbsp;&nbsp;<a id="sanqiang" name="sanqiang" href="javascript:void(0);">三枪</a>
    <div id="result">
        </div>
    </div>
    </form>
</body>
</html>
