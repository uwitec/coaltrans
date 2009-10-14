<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="User_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户中心</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">

    <script language="javascript" src="Includes/jquery.pack.js" type="text/javascript"></script>
    <script language="javascript" src="Includes/AdminIndex.js" type="text/javascript"></script>
    <script language="javascript" src="Includes/FrameTab.js" type="text/javascript"></script>

    <link href="Includes/Guide.css" type="text/css" rel="stylesheet" />
    <link href="Includes/index.css" type="text/css" rel="stylesheet" />
    <link href="Includes/MasterPage.css" type="text/css" rel="stylesheet" />
</head>
<body id="Indexbody" onload="onload();">
    <form id="myform" name="myform" method="post" runat="server">
    <table cellspacing="0" cellpadding="0" border="0">
        <tbody>
            <tr>
                <td colspan="3">
                    <div id="content">
                        <ul id="ChannelMenuItems" style="padding-left: 230px;">
                            
                            <li id="Menu1"
                            onclick="ShowHideLayer('ChannelMenu_Menu1')">
                            <a id="AChannelMenu_Menu1" href="Components/SystemMenus/menu1.aspx" target="left">
                            <span id="SpanChannelMenu_Menu1">1、用户中心</span></a> 
                            </li>
                            <li id="Menu2"
                            onclick="ShowHideLayer('ChannelMenu_Menu2')">
                            <a id="AChannelMenu_Menu2" href="Components/SystemMenus/menu2.aspx" target="left">
                            <span id="SpanChannelMenu_Menu2">2、煤炭供需</span></a> 
                            </li>
                            <li id="Menu3"
                            onclick="ShowHideLayer('ChannelMenu_Menu3')">
                            <a id="AChannelMenu_Menu3" href="Components/SystemMenus/menu3.aspx" target="left">
                            <span id="SpanChannelMenu_Menu3">3、机械设备</span></a> 
                            </li>
                            <li id="Menu4"
                            onclick="ShowHideLayer('ChannelMenu_Menu4')">
                            <a id="AChannelMenu_Menu4" href="Components/SystemMenus/menu4.aspx" target="left">
                            <span id="SpanChannelMenu_Menu4">4、物流</span></a> 
                            </li>
                            <li id="Menu5"
                            onclick="ShowHideLayer('ChannelMenu_Menu5')">
                            <a id="AChannelMenu_Menu5" href="Components/SystemMenus/menu5.aspx" target="left">
                            <span id="SpanChannelMenu_Menu5">5、招商</span></a> 
                            </li>
                            <li id="Menu6"
                            onclick="ShowHideLayer('ChannelMenu_Menu6')">
                            <a id="AChannelMenu_Menu6" href="Components/SystemMenus/menu6.aspx" target="left">
                            <span id="SpanChannelMenu_Menu6">6、招标</span></a> 
                            </li>
                            <li id="Menu7"
                            onclick="ShowHideLayer('ChannelMenu_Menu7')">
                            <a id="AChannelMenu_Menu7" href="Components/SystemMenus/menu7.aspx" target="left">
                            <span id="SpanChannelMenu_Menu7">7、项目</span></a> 
                            <li id="Menu8"
                            onclick="ShowHideLayer('ChannelMenu_Menu8')">
                            <a id="AChannelMenu_Menu8"  target="left">
                            <span id="SpanChannelMenu_Menu8">帮助</span></a> 
                            </li>
                            </li>
                            
                        </ul>
                        <div id="SubMenu">
                            <div id="ChannelMenu_" style="width: 100%">
                                <ul>
                                    <li>管理员：<span class="AdminName"><strong>admin</strong></span>，欢迎您！&nbsp;&nbsp; </li>
                                    
                                    <li><a href="#"><span class="SignOut">安全退出</span></a> </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr style="vertical-align: top">
                <td id="frmTitle">
                    <iframe id="left" style="z-index: 2; visibility: inherit; width: 195px; height: 800px"
                        name="left" src="Components/SystemMenus/menu1.aspx" frameborder="0" tabid="1"></iframe>
                </td>
                <td class="but" onclick="switchSysBar();">
                    <img id="switchPoint" style="border-right: 0px; border-top: 0px; border-left: 0px;
                        width: 12px; border-bottom: 0px" alt="关闭左栏" src="images/butClose.gif" />
                </td>
                <td>
                    <div id="FrameTabs" style="overflow: hidden">
                        <div class="tab-right" onmouseover="this.className='tab-right tab-right-over'" onmouseout="this.className='tab-right tab-right-disabled'">
                        </div>
                        <div class="tab-left" onmouseover="this.className='tab-left tab-left-over'" onmouseout="this.className='tab-left tab-left-disabled'">
                        </div>
                        <div class="tab-strip-wrap" style="width: 8000px">
                            <ul class="tab-strip" style="float: left">
                                <li class="current" id="iFrameTab1"><a href="javascript:"><span id="frameTabTitle">我的工作台</span></a><a
                                    class="closeTab"><img src="images/tab-close.gif" border="0"></a></A> </li>
                                <li id="newFrameTab"><a title="新建标签页" href="javascript:"></a></li>
                            </ul>
                        </div>
                    </div>
                    <!-- 书签结束 -->
                    <div id="main_right_frame">
                        <iframe id="main_right" style="z-index: 2; visibility: inherit; overflow-x: hidden;
                            width: 1280px; height: 800px" name="main_right" src="MyWorktable.htm" frameborder="0"
                            scrolling="yes" onload="SetTabTitle(this)" tabid="1"></iframe>
                        <div class="clearbox2">
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <div id="iframeGuideTemplate" style="display: none">
        <iframe style="z-index: 2; visibility: inherit; width: 195px; height: 800px" src="about:blank"
            frameborder="0" tabid="0"></iframe>
    </div>
    <div id="iframeMainTemplate" style="display: none">
        <iframe style="z-index: 2; visibility: inherit; overflow-x: hidden; width: 1280px;
            height: 800px" src="about:blank" frameborder="0" scrolling="yes" onload="SetTabTitle(this)"
            tabid="0"></iframe>
    </div>
    </form>
</body>
</html>
