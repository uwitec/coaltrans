<%@ Page Language="C#" AutoEventWireup="true" CodeFile="coal_detail.aspx.cs" Inherits="Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>国家煤炭工业供需网</title>
    <link href="css/style_css.css" rel="stylesheet" type="text/css" />
    <link href="css/index.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/public.js"></script>
    <script type="text/javascript"> 
    
    $(document).ready(function(){
    
        //用户留言
        $("#BtnMessage").click(function(){
            var Data=$("#UserId").val();            
            openWin("Message.aspx?ID="+Data);
        });
        
        //举报信息
        $("#BtnReport").click(function(){
            alert("举报该信息！");
        });
        
        //诚信评论
        $("#BtnReview").click(function(){
            alert("诚信评论！");
        });
        
    });
    
    
    
    
    
    
    </script>

</head>
<body>
    <form id="form2" runat="server">
    <!--#include File="top.inc"-->
    <table width="950" border="0" align="center" cellpadding="0" cellspacing="0" class="content_bar">
        <tr>
            <td valign="top" class="content_bar_left">
                <div class="bars">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="14%" align="center" class="login_title">
                                <img src="images/gxxx_ico.gif" width="19" height="31" />
                            </td>
                            <td class="login_title">
                                最新会员供应信息
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="linkf12_grey">
                                    <tr>
                                        <td width="23%" height="28" align="center" class="bor_b">
                                            [<a href="#">供应</a>]
                                        </td>
                                        <td width="77%" align="left" class="bor_b">
                                            <a href="#">防爆电子皮带秤</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="23%" height="28" align="center" class="bor_b">
                                            [<a href="#">供应</a>]
                                        </td>
                                        <td width="77%" align="left" class="bor_b">
                                            <a href="#">临县主焦煤供应 </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="23%" height="28" align="center" class="bor_b">
                                            [<a href="#">供应</a>]
                                        </td>
                                        <td width="77%" align="left" class="bor_b">
                                            <a href="#">出售神木店塔附近的电煤</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="23%" height="28" align="center" class="bor_b">
                                            [<a href="#">供应</a>]
                                        </td>
                                        <td width="77%" align="left" class="bor_b">
                                            <a href="#">木煤矿股东代办神</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="23%" height="28" align="center" class="bor_b">
                                            [<a href="#">供应</a>]
                                        </td>
                                        <td width="77%" align="left" class="bor_b">
                                            <a href="#">神木煤矿股东代办神</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="23%" height="28" align="center" class="bor_b">
                                            [<a href="#">供应</a>]
                                        </td>
                                        <td width="77%" align="left" class="bor_b">
                                            <a href="#">盐雾试验报告/中性盐雾</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="23%" height="28" align="center" class="bor_b">
                                            [<a href="#">供应</a>]
                                        </td>
                                        <td width="77%" align="left" class="bor_b">
                                            <a href="#">内蒙出售3500卡以上块煤及4</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="23%" height="28" align="center" class="bor_b">
                                            [<a href="#">供应</a>]
                                        </td>
                                        <td width="77%" align="left" class="bor_b">
                                            <a href="#">供应各种规格无烟块煤</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="23%" height="28" align="center" class="bor_b">
                                            [<a href="#">供应</a>]
                                        </td>
                                        <td width="77%" align="left" class="bor_b">
                                            <a href="#">供应2-4公分无烟块煤</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="23%" height="28" align="center" class="bor_b">
                                            [<a href="#">供应</a>]
                                        </td>
                                        <td width="77%" align="left" class="bor_b">
                                            <a href="#">陕西省榆林市神木县 </a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="bars pad_tb text_align">
                    <a href="#">
                        <img src="images/left_ad_1.gif" /></a></div>
                <div class="bars pad_tb text_align">
                    <a href="#">
                        <img src="images/left_ad_2.gif" /></a></div>
                <div class="bars pad_tb text_align">
                    <a href="#">
                        <img src="images/left_ad_3.gif" /></a></div>
            </td>
            <td align="right" valign="top">
                <table width="712" border="0" cellspacing="0" cellpadding="0" class="mar_t16">
                    <tr>
                        <td height="300" align="left" valign="top">
                            <table width="712" border="0" cellspacing="0" cellpadding="0" class="gongxu_bars">
                                <tr>
                                    <td width="47" align="center" class="f12b_grey">
                                        <img src="images/locatioin.gif" width="26" height="23" />
                                    </td>
                                    <td width="595" class="pad_t4 f12_grey_3 linkf12_grey">
                                        <strong>当前位置：</strong><a href="index.html">首页</a> &gt; 煤炭供需信息 &gt; 供应信息
                                    </td>
                                    <td width="70" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table width="712" border="0" cellspacing="0" cellpadding="0" class="mar_t4">
                                <tr>
                                    <td height="60" align="center" valign="top" class="bor_all">
                                        <table width="700" border="0" align="center" cellpadding="0" cellspacing="0" class="mar_t16">
                                        </table>
                                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="bor_b">
                                            <tr>
                                                <td width="35%" height="50" align="left" class="f12_grey_3">
                                                    发布日期：<asp:Label ID="lblFaBuRiQi" CssClass="lblCss" runat="server"></asp:Label><input
                                                        type="text" id="UserId" runat="server" style="display: none;" /><br>
                                                    截止日期：<asp:Label ID="lblXinXiYouXiaoQi" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td width="65%" align="right">
                                                    <input type="button" name="BtnMessage" id="BtnMessage" value="留言给该公司" class="content_btn" />&nbsp;&nbsp;<input
                                                        type="button" name="BtnReport" id="BtnReport" value="举报此信息" class="content_btn" />&nbsp;&nbsp;<input
                                                            type="button" name="BtnReview" id="BtnReview" value="对该公司发表诚信评论" class="content_btn" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="mar_t10 bor_all mar_b10">
                                            <tr>
                                                <td colspan="4">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="content_title">
                                                        <tr>
                                                            <td width="12%" class="content_title_on f12b_grey">
                                                                基本信息
                                                            </td>
                                                            <td width="88%">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="35" align="center" class="f12b_grey c_r c_b">
                                                    供需：
                                                </td>
                                                <td width="15%" align="center" class="c_r c_b">
                                                    <asp:Label ID="lblGongXu" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td width="17%" align="center" class="f12b_grey c_r c_b">
                                                    被浏览次数：
                                                </td>
                                                <td width="13%" align="center" class="c_r c_b">
                                                    <asp:Label ID="lblDianJiLiang" CssClass="lblCss" runat="server"></asp:Label>次
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_b c_r">
                                                    煤种：
                                                </td>
                                                <td align="center" class="c_r c_b">
                                                    <asp:Label ID="lblMeiZhong" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td align="center" class="f12b_grey c_r c_b">
                                                    产地：
                                                </td>
                                                <td align="center" class="c_r c_b">
                                                    <asp:Label ID="lblTHSheng" CssClass="lblCss" runat="server"></asp:Label><asp:Label
                                                        ID="lblTHShi" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_b c_r">
                                                    品种：
                                                </td>
                                                <td align="center" class="c_r c_b">
                                                    <asp:Label ID="lblPinZhong" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    提货地：
                                                </td>
                                                <td align="center" class="c_r c_b">
                                                    <asp:Label ID="lblJHSheng" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_b c_r">
                                                    数量：
                                                </td>
                                                <td align="center" class="c_r c_b">
                                                    <asp:Label ID="lblShuLiang" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    报价方式：
                                                </td>
                                                <td align="center" class="c_r c_b">
                                                    <asp:Label ID="lblBaoJiaFangShi" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_b c_r">
                                                    价格：
                                                </td>
                                                <td align="center" class="c_r c_b">
                                                    <asp:Label ID="lblJiaGe" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    结算方式：
                                                </td>
                                                <td align="center" class="c_r c_b">
                                                    <asp:Label ID="lblJieSuanFangShi" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="mar_t10 bor_all mar_b10">
                                            <tr>
                                                <td colspan="6">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="content_title">
                                                        <tr>
                                                            <td width="12%" class="content_title_on f12b_grey">
                                                                指标信息
                                                            </td>
                                                            <td width="88%">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="35" align="center" class="f12b_grey c_r c_b">
                                                    发热量：
                                                </td>
                                                <td width="15%" align="center" class="c_r c_b">
                                                    <asp:Label ID="lblFaReLiang" CssClass="lblCss" runat="server"></asp:Label>KJ
                                                </td>
                                                <td width="17%" align="center" class="f12b_grey c_r c_b">
                                                    粒度：
                                                </td>
                                                <td width="13%" align="center" class="c_r c_b">
                                                    <asp:Label ID="lblLiDu" CssClass="lblCss" runat="server"></asp:Label>CM
                                                </td>
                                                <td width="18%" align="center" class="f12b_grey c_r c_b">
                                                    含硫量：
                                                </td>
                                                <td width="22%" align="center" class="c_b c_r">
                                                    <asp:Label ID="lblHanLiuLiang" CssClass="lblCss" runat="server"></asp:Label>%
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_r c_b">
                                                    水分：
                                                </td>
                                                <td align="center" class="c_r c_b">
                                                    <asp:Label ID="lblShuiFen" CssClass="lblCss" runat="server"></asp:Label>%
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    挥发：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblHuiFa" CssClass="lblCss" runat="server"></asp:Label>%
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    灰分：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblHuiFen" CssClass="lblCss" runat="server"></asp:Label>%
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_r c_b">
                                                    固定碳：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblGuDingTan" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    机械强度：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblJiXieQiangDu" CssClass="lblCss" runat="server"></asp:Label>%
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    规格：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblGuiGe" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_b c_r">
                                                    耐磨强度：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblLaiMoQianDu" CssClass="lblCss" runat="server"></asp:Label>%
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    反应性：
                                                </td>
                                                <td align="center" class="c_r c_b">
                                                    <asp:Label ID="lblFanYingXing" CssClass="lblCss" runat="server"></asp:Label>℃
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    抗碎强度：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblKangSuiQiangDu" CssClass="lblCss" runat="server"></asp:Label>%
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_b c_r">
                                                    气孔率：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblQiKongLv" CssClass="lblCss" runat="server"></asp:Label>%
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    焦沫含量：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblJiaoMoHanLiang" CssClass="lblCss" runat="server"></asp:Label>%
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    沾结指数：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblLianJieZhiShu" CssClass="lblCss" runat="server"></asp:Label>%
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_b c_r">
                                                    灰熔融性：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblHuiRongRongXing" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    可磨性：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblKeMoXing" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    热稳定性：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblReWenDingXing" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="mar_t10 bor_all mar_b10">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="content_title">
                                                        <tr>
                                                            <td width="12%" class="content_title_on f12b_grey">
                                                                详细说明
                                                            </td>
                                                            <td width="88%" class=' td1234'>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="f12b_grey c_r c_b">
                                                    <asp:Label ID="lblXiangXiLeiRong" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="mar_t10 bor_all mar_b10">
                                            <tr>
                                                <td colspan="4">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="content_title">
                                                        <tr>
                                                            <td width="12%" class="content_title_on f12b_grey">
                                                                运输信息
                                                            </td>
                                                            <td width="88%">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="35" align="center" class="f12b_grey c_r c_b">
                                                    是否提供运输：
                                                </td>
                                                <td width="15%" align="center" class="c_r c_b">
                                                    <asp:Label ID="lblIsTiGongYunShu" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td width="17%" align="center" class="f12b_grey c_r c_b">
                                                    运输方式：
                                                </td>
                                                <td width="13%" align="center" class="c_r c_b">
                                                    <asp:Label ID="lblYunshuFangShi" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_b c_r">
                                                    运输说明：
                                                </td>
                                                <td colspan="3" align="center" class="c_r c_b">
                                                    <asp:Label ID="lblYunShuShuoMing" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="mar_t10 bor_all mar_b10">
                                            <tr>
                                                <td colspan="6">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="content_title">
                                                        <tr>
                                                            <td width="12%" class="content_title_on f12b_grey">
                                                                联系方式
                                                            </td>
                                                            <td width="88%">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="35" align="center" class="f12b_grey c_r c_b">
                                                    联系人：
                                                </td>
                                                <td width="15%" align="center" class="c_r c_b">
                                                    <asp:Label ID="lblLianXiRen" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td width="17%" align="center" class="f12b_grey c_r c_b">
                                                    联系电话：
                                                </td>
                                                <td width="13%" align="center" class="c_r c_b">
                                                    <asp:Label ID="lblPhone" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td width="18%" align="center" class="f12b_grey c_r c_b">
                                                    手机 ：
                                                </td>
                                                <td width="22%" align="center" class="c_b c_r">
                                                    <asp:Label ID="lblMobile" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_r c_b">
                                                    传真：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblFax" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td align="center" class="c_b f12b_grey c_r">
                                                    E-Mail：
                                                </td>
                                                <td colspan="3" align="center" class="c_b c_r">
                                                    <asp:Label ID="lblMail" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="35" align="center" class="f12b_grey c_b c_r">
                                                    邮编：
                                                </td>
                                                <td align="center" class="c_b c_r">
                                                    <asp:Label ID="lblPostCode" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                                <td align="center" class="f12b_grey c_b c_r">
                                                    详细地址：
                                                </td>
                                                <td colspan="3" align="center" class="c_b c_r">
                                                    <asp:Label ID="lblProvince" CssClass="lblCss" runat="server"></asp:Label>-
                                                    <asp:Label ID="lblCity" CssClass="lblCss" runat="server"></asp:Label>-<asp:Label
                                                        ID="lblAddress" CssClass="lblCss" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="950" border="0" align="center" cellpadding="0" cellspacing="0" class="mar_t12">
        <tr>
            <td class="footer f12_white linkf12_white">
                <a href="#">网站地图</a> | <a href="#">版权声明</a> | <a href="#">设为首页</a> | <a href="#">关于我们</a>
            </td>
        </tr>
        <tr>
            <td height="120" align="center" class="f12_grey_3 line_h36">
                Copyright © 2009 国家煤炭工业网<br />
                主办:中国煤炭工业协会 技术支持:北京中煤易通科技有限公司<br />
                (浏览本站主页,建议将电脑显示器分辨率调整为:1024*768)
            </td>
        </tr>
    </table>
    <map name="Map" id="Map">
        <area shape="rect" coords="1,0,42,28" href="#" alt="登录" />
        <area shape="rect" coords="41,0,86,28" href="#" alt="注册" />
        <area shape="rect" coords="85,0,153,28" href="#" alt="忘记密码" />
    </map>
    </form>
</body>
</html>
