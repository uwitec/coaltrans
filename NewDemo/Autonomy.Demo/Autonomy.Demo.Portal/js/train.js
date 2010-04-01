/* 页面初始化加载程序 */
nav_data.data[7].is_current = true;  
$(document).ready(function(){ 
    /* 加载左边菜单 */    
    $.post("Handler/getCategoryMenu.ashx",
        function(data,textstatus){                    
            $("#MenuList").html(data);
            var div_list=$("#MenuList").children("div");
            setMenu(div_list);
            var a_list=$("#MenuList").find("a");
            $(a_list).each(function(n){
                var edit_area=new StringBuffer();
                var category_id=$(this).attr("id").split('_')[1];                
                edit_area.append("<span>&nbsp;<a href=\"#g\"><img src=\"images/no.gif\" title=\"删除\"  id=\"btn_remove_"+n+"\"/></a>&nbsp;");
                edit_area.append("<a href=\"#g\"><img src=\"images/icon_edit.gif\" title=\"编辑\" id=\"btn_edit_"+n+"\"  /></a>&nbsp;");
                edit_area.append("<a href=\"#g\"><img src=\"images/icon_add.gif\" title=\"增加\" id=\"btn_add_"+n+"\"/></a></span>");
                $(this).after(edit_area.toString());  
                /* 图片按钮初始化 */              
                InnitBtn(n,category_id);
            });
        }
    );
    /*表单数据初始化*/
    FormInnit();
    /* 父级栏目初始化 */
    InnitParentSelect("0");
    /* 提交按钮初始化 */
    btnSubmit_innit();
    /* 初始化新增分类按钮 */
    $("#add_new_catagory").click(function(){
        FormInnit();
        $("#ParentCate").val("0");
    });
    /*文章训练内容初始化*/
    tranArticleInnit();
});
/* 初始化按钮 */
function InnitBtn(n,category_id)
{    
    $("#btn_remove_"+n).click(function(){
        if(confirm("此操作不可恢复，您确定要删除此分类么？"))
        {
            PostDemand("remove",category_id,this);
        }
    });
    $("#btn_edit_"+n).click(function(){
        PostDemand("innit_edit",category_id,this);
    });
    $("#btn_add_"+n).click(function(){
        FormInnit();
        $("#ParentCate").val(category_id);               
    });
}
/* 发送处理请求 */
function PostDemand(act,category_id,btn_obj)
{
    $.post("Handler/TrainEdit.ashx",
        {"act":act,"category_id":category_id},
        function(data,textstatus){                    
           if(data!=null)
           {
                if(data["act"]=="remove")
                {
                    $(btn_obj).parent().parent().parent().remove();
                }
                else
                {
                    $("#markLable").html("分类编辑");
                    $("#CategoryName").val(data["CategoryName"]);
                    $("#categoryId").val(data["ID"]);
                    $("#CatePath").val(data["CatePath"]);
                    $("#CateTrainInfo").val(data["CateTrainInfo"]);                    
                    $("#ParentCate").val(data["ParentCate"]);
                    $("#btnSubmit").attr("pid","edit");                    
                }
           }
        },
        "json"
    );
}
/* 获取栏目下拉选项框 */
function InnitParentSelect(value_id)
{
    $.post("Handler/GetTrainMenu.ashx",       
        function(data,textstatus){                    
          $("#ParentCate").html(data);
          $("#ParentCate").val(value_id);
        }
    );
}
/* 为确定按钮初始化事件 */
function btnSubmit_innit()
{
    $("#btnSubmit").click(function(){
       manageData();
    });
}
/* 修改和增加数据 */
function manageData()
{
    var act=$("#btnSubmit").attr("pid");
    var category_id=$("#categoryId").val();
    var category_name=$("#CategoryName").val();
    var cate_path=$("#CatePath").val();
    var cate_train_info=$("#CateTrainInfo").val();
    var parent_cate=$("#ParentCate").val();
    $.post("Handler/TrainEdit.ashx",
        {"act":act,"category_id":category_id,"category_name":category_name,"cate_path":cate_path,"cate_train_info":cate_train_info,"parent_cate":parent_cate},
        function(data,textstatus){                    
           if(data!=null)
           {
                if(data["errorCode"]=="0")
                {
                    $("#Message").empty().html("操作成功！");
                    if(data["act"]=="add")
                        location.reload();
                }
           }
        },
        "json"
    );
}
/* 表单初始化 */
function FormInnit()
{
    $("#markLable").html("增加分类");
    $("#CategoryName").val("");
    $("#categoryId").val("");
    $("#CatePath").val("");
    $("#CateTrainInfo").val("");     
    $("#btnSubmit").attr("pid","add");
}


/**/
function tranArticleInnit()
{
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
                choose_article.append("<li style=\"height:15px; line-height:15px;\"><a href=\"#g\">"+doc_id_list[i]+"</a></li>");
            }
            $("#choose_article_list_id").after(choose_article.toString());
        });
    });
}