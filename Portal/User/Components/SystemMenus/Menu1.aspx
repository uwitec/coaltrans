<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/User/Masters/MenuTemplate.Master" CodeFile="Menu1.aspx.cs" Inherits="User_Components_SystemMenus_Menu1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="Guide_back">
            <ul>
                <li id="Guide_top">
                    <div id="Guide_toptext">
                        
    用户中心

                    </div>
                </li>
                <li id="Guide_main">
                    <div id="Guide_box">
                        
    <div class="guideexpand" onclick="Switch(this)">
        用户中心</div>
    <div class="guide">
        <ul>
            <li><a href="temp.htm" target="main_right">用户首页</a></li>
            <li><a href="temp.htm" target="main_right">用户身份</a></li>
            <li><a href="temp.htm" target="main_right">未读信息</a></li>
            <li><a href="temp.htm" target="main_right">更新密码</a></li>
            <li><a href="temp.htm" target="main_right">更新密码保护</a></li>
            <li><a href="temp.htm" target="main_right">更新企业信息</a></li>
            <li><a href="temp.htm" target="main_right">更新联系信息</a></li>            
            
            
        </ul>
    </div>
    
                    </div>
                </li>
                <li id="Guide_bottom"></li>
            </ul>
        </div>
</asp:Content>
