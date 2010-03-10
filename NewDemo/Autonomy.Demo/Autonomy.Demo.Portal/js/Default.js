
$(document).ready(function() {
    //设置该页面为当前导航
    nav_data.data[0].is_current = true;
    GetLeaderInfo(0);
    GetLeaderInfo(1);
    GetLeaderInfo(2);
    GetEventInfo();
    GetSocietyInfo("Society","Society");
    GetSocietyInfo("LegalCase","LegalCase");
    GetSocietyInfo("LegalCaseSpeed","LegalCaseSpeed");
    GetSocietyInfo("SocietySpeed","SocietySpeed");    
});
 
 /* 获取领导人信息 */
 function GetLeaderInfo(code)
 {
    $.post("Handler/GetInfo.ashx",
            {"type":"Leader"},
            function(data, textStatus){            
                var Content=new StringBuffer();
                if(data!=null)
                {                    
                    for(var one in data)
                    {
                        var Row=data[one];
                        Content.append("<li><a href=\"javascript:void(null);\">");
                        Content.append(Row["Name"]);
                        Content.append("</a>(");
                        if(code==0)
                        {
                            Content.append(Row["TotalDocNums"]);
                        }
                        else if(code==1)
                        {
                            Content.append(Row["PositiveNums"]);
                        }
                        else if(code==2)
                        {
                            Content.append(Row["NegativeNums"]);
                        }
                        Content.append(")</li>");
                    }
                }
                else
                {
                    content.append("对不起，没有数据！");                     
                }
                $("#columnTab1_Content"+code).html(Content.toString());
            },
            "json");
 }
 /* 获取关注事件信息 */
 function GetEventInfo()
 {
    $.post("Handler/GetInfo.ashx",
            {"type":"Event"},
            function(data, textStatus){            
                var Content=new StringBuffer();
                
                if(data!=null)
                {                 
                    var i=1;   
                    for(var one in data)
                    {
                        var Row=data[one];
                        Content.append("<tr>");   
                        Content.append("<td class=\"");
                        if(i==1)
                        { 
                            Content.append("pd_left pd_top");
                        }
                        else
                        {
                            Content.append("pd_left");
                        }
                        Content.append("\"><a href=\"javascript:void(null);\">");
                        Content.append(Row["CateDisplay"]);
                        Content.append("</a></td><td>");
                        var Trend = Row["TodayHitCount"] - Row["YestodayHitCount"];
                        if(Trend>0)
                        {
                            Content.append("<span class=\"trend_up\">上升</span>");
                        }   
                        else if(Trend<0)
                        {
                            Content.append("<span class=\"trend_down\">下降</span>");
                        }             
                        else
                        {
                            Content.append("<span class=\"trend_steady\">平稳</span>");
                        }  
                        Content.append("</td><td><a href=\"javascript:void(null);\">");
                        Content.append(Row["TotalHitCount"]);
                        Content.append("条</a></td>");
                        Content.append("</tr>");
                        i++;
                    }
                }
                else
                {
                    content.append("对不起，没有数据！");                     
                }
                $("#Event").html(Content.toString());
            },
            "json");
 }
 /* 获取重大社会事件信息 */
 function GetSocietyInfo(obj,type)
 {
    $.post("Handler/GetInfo.ashx",
            {"type":type},
            function(data, textStatus){            
                var Content=new StringBuffer();
                if(data!=null)
                {             
                    var i=1;       
                    for(var one in data)
                    {
                        var Row=data[one];                         
                        Content.append("<tr><td width=\"5%\"><em class=\"num0"+i+"\">"+i+"</em></td>");
                        Content.append("<td><a href=\"javascript:void(null);\">");                       
                        Content.append(Row["CateDisplay"]);
                        Content.append("</a></td><td width=\"12%\">");
                        var Trend = Row["TodayHitCount"] - Row["YestodayHitCount"];
                        if(Trend>0)
                        {
                            Content.append("<span class=\"trend_up\">上升</span>");
                        }   
                        else if(Trend<0)
                        {
                            Content.append("<span class=\"trend_down\">下降</span>");
                        }             
                        else
                        {
                            Content.append("<span class=\"trend_steady\">平稳</span>");
                        }  
                        Content.append("</td><td><a href=\"javascript:void(null);\">");
                        Content.append(Row["TotalHitCount"]);
                        Content.append("条</a></td>");
                        Content.append("</tr>");
                        i++;
                    }
                }
                else
                {
                    content.append("对不起，没有数据！");                     
                }
                $("#"+obj).html(Content.toString());
            },
            "json");
 }