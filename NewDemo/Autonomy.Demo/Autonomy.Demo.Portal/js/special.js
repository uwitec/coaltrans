$(document).ready(function(){
    $.post("Handler/getSubjectMenu.ashx",
            null,
            function(data, textStatus) {
                var Content = new StringBuffer();               
                if (data != null) {
                    var i=0;
                    for (var item in data) { 
                        if(i==0)
                        {
                            Content.append("<li class=\"subcurrent\" cateid=\""+data[item]["CategoryId"]+"\">");                                
                            Content.append("<a href=\"\#g\" title=\"点击查看\">"+data[item]["CategoryName"]+"</a></li>");
                            $("#CategoryName").html(data[item]["CategoryName"]);
                            LoadData(data[item]["CategoryId"],2);
                        }                            
                        else
                        {
                            Content.append("<li cateid=\""+data[item]["CategoryId"]+"\">");                                
                            Content.append("<a href=\"\#g\">"+data[item]["CategoryName"]+"</a></li>");
                        }
                        i++;
                    }
                }
                $("#publicTopicList").html(Content.toString());       
                //对publicTopicList的选项点击事件初始化         
                innitpublicTopicList();
            }, "json"); 
});
/* publicTopicList的选项点击事件初始化 */
function innitpublicTopicList()
{
    var li_list=$("#publicTopicList").find("li");
    
    $(li_list).each(function(){    
           
        var search_param=$(this).attr("cateid");
        $(this).click(function(){
           $(li_list).attr("class",""); 
           $(this).attr("class","subcurrent");
           $("#CategoryName").html($(this).children("a").html());           
           LoadData(search_param,2);
        });
    });
}