<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IntegrityList.aspx.cs" Inherits="IntegrityList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司诚信评论信息列表</title>
    <link type="text/css" rel="Stylesheet" href="css/pager.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript" src="js/Pager.js"></script>

    <script type="text/javascript">
        $(document).ready(function(){
            var Url=self.location.toString();
            var outStr="\"<div class='DisplayItem'><dl><dt><span>诚信分值：</span>\"+row['Integritynumber']+\"<dd><span>评论时间：</span>\"+row['CreateTime']+\"</dd></dt><dd><span>评论内容：</span></dd><dd>\"+row['Content']+\"</dd></dl></div>\"";
            IntPager=new Pager("DisplayList",outStr,Url,"Pager",10,true,true,null);
		    IntPager.innit();              
        });
    </script>

</head>
<body>
    <form id="form1" name="form1" runat="server">
    <div class="userht_all">
        <div class="topban">
        </div>
        <div class="h_menu">
            服务热线:010-88888888</div>
        <div>
            <div class="login_bz">
                <ul>
                    <li class="bz_a">公司诚信评论信息列表</li>
                </ul>
            </div>
            <div class="clear">
            </div>
            <div style=" width:100%;height:auto; margin-top:15px;" id="DisplayList">
            
            </div>
            <div class="Pager_display" id="Pager" style="margin-left:70px;"></div>
            <div class="clear">
            </div>
        </div>
        <div class="d_menu">
            Copyright &copy; 2009 国家煤炭工业网</div>
        <div class="endpage" >
            <p>
                主办:中国煤炭工业协会 技术支持:北京中煤易通科技有限公司
            </p>
            <p>
                (浏览本站主页,建议将电脑显示器分辨率调整为:1024*768)</p>
        </div>
    </div>
    </form>
</body>
</html>
