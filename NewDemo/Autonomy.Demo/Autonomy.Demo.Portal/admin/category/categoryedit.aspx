<%@ Page Language="C#" AutoEventWireup="true" CodeFile="categoryedit.aspx.cs" Inherits="demo_admin_category_categoryedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>分类添加</title>
    <link rel="Stylesheet" type="text/css" href="../css/Style.css" />     
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/util.js"></script>
    <script type="text/javascript" src="../js/Search.js"></script>
    <script type="text/javascript">
        $(document).ready(function(){
            $("#BtnSearch").click(function(){
                var keyword_value=$("#key_words").val();
                LoadData(keyword_value, 3);
                
                $("#choose_all").click(function(){          
                    var article_list=$("input[name=train_article_list]");          
                    if($(this).attr("checked")){
                        $(article_list).each(function(){
                            $(this).attr("checked","true");
                        });
                    }           
                    else
                    {                    
                        $(article_list).each(function(){
                            $(this).attr("checked","");
                        });
                    }  
                });
                $("#save_docs").click(function(){
                    var doc_id_list=[];
                    var article_list=$("input[name=train_article_list]");        
                    $(article_list).each(function(){                          
                        if($(this).attr("checked"))
                        {                            
                            doc_id_list.push($(this).attr("id"));
                        }
                       
                    });
                    var choose_article=new StringBuffer();
                    for(var i in doc_id_list)
                    {
                        choose_article.append("<li style=\"height:15px; line-height:15px;\"><a href=\"#g\">"+doc_id_list[i]+"</a>");
                    }
                    $("#choose_article_list_id").after(choose_article.toString());
                });
            });
            
        });
    </script>
</head>
<body class="MainBody">
    <form id="form1" runat="server">
    <div class="HeadBar">
        <div class="HeadBarNav">后台管理中心&nbsp;<span>--&nbsp;分类添加或修改</span></div>  
        <div class="HeadBarOperate"><div class="Btn_Style1"><a href="categoryList.aspx">返回分类列表</a></div></div>      
    </div>    
    <div class="DealList" style="background:white; height:800px;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">         
          <tr>
            <td  align="right" style="width:100px;">分类ID：</td>
            <td style="width:250px;"><input type="text" id="CategoryID" runat="server" /><span>*</span></td>
            <td align="right" style="width:100px;">分类名称：</td>
            <td><input type="text" id="CategoryName" runat="server" /><span>*</span></td>
            <td align="right" style="width:100px;">库名：</td>
            <td> 
            <select id="DataBase" runat="server">
                <option value="0">---请选择库名---</option>
                <option value="1">新闻</option>
                <option value="2">论坛</option>
                <option value="3">博客</option>               
            </select>
            <span>*</span></td>
          </tr>
          <tr>
            <td align="right" style="width:100px;">分类来源：</td>
            <td><input type="text" id="CateSource" runat="server" /><span>*</span></td>
            <td align="right" style="width:100px;">分类类型：</td>
            <td>
            <select id="CateType" runat="server">
                <option value="0">--请选择分类类型--</option>
                <option value="1">重要领导人</option>
                <option value="2">关注事件</option>
                <option value="3">重大社会事件</option>
                <option value="4">重大案件</option>
            </select>
            <span>*</span></td>
            <td align="right" style="width:100px;">分类路径：</td>
            <td><input type="text" id="CatePath" runat="server" /><span>*</span></td>
          </tr>
          <tr>
            <td  align="right" style="width:100px;">创建人名字：</td>
            <td style="width:250px;"><input type="text" id="CreateBy" runat="server" /><span>*</span></td>
           
            <td align="right" style="width:100px;"></td>
            <td colspan="3"></td>
          </tr>
           <tr>
            <td  align="right" style="width:100px;">分类训练信息：</td>
            <td  colspan="5"><textarea id="CateTrainInfo" rows="3" cols="30" runat="server" ></textarea><span>*</span></td>            
          </tr>
          <tr>
            <td  align="right" style="width:100px;">父级分类：</td>
            <td  colspan="5">
            <select id="ParentCate" runat="server">               
                <option value="0">根目录</option>
            </select>
            <span>*</span></td>            
          </tr>
          <tr>
            <td align="right">&nbsp;</td>
            <td align="center" colspan="3">
               
                <asp:Button ID="BtnSubmit" CssClass="Btn_Style3" 
                    runat="server" Text="确定" onclick="BtnSubmit_Click"  />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="BtnAdd" CssClass="Btn_Style3" 
                    runat="server" Text="继续添加" onclick="BtnAdd_Click"   />
                    </td>
            <td align="right">&nbsp;</td>
            <td align="right">&nbsp;</td>          
          </tr>
          <tr>
            <td align="right"><div style="color:Red;" runat="server" id="message"></div></td>
            <td colspan="5"></td>
          </tr>
          <tr>
            <td align="right">训练文章：</td>
            <td colspan="3"></td>
            <td align="right"><input type="text" id="key_words" /></td>
            <td><a href="#g">&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" id="BtnSearch" value="搜索" /></a></td>            
          </tr>
          
          <tr>
            <td align="right">选中文章：</td>                       
            <td colspan="5"><div class="choose_article">
                <ul id="choose_article_list_id">
                    
                </ul>
            </div></td>
          </tr>
          <tr >                                 
            <td colspan="6" >&nbsp;</td>
          </tr>
          <tr>                                  
            <td align="right" valign="top">文章列表：</td>
            <td colspan="5">
                <div style="width:75%; height:350px; border:1px solid black; overflow:auto;" >
                    <table>
                        <tbody id="SearchResult">
                            <tr>
                                <td />请搜索文章</td>                            
                            </tr> 
                        </tbody>
                    </table>
                    <div class="publicFeelSearchPage" id="PagerList"></div>
                </div>            
            </td>
          </tr> 
          <tr>                                  
            <td align="right" valign="top">全选：<input type="checkbox" id="choose_all" /></td>
            <td colspan="5"><input type="button" value="保存选中文章" id="save_docs" /></td>
          </tr>         
        </table>
    </div>
    </form>
</body>
</html>
