
 $(document).ready(function(){
    nav_data.data[0].is_current = true;
    GetLeaderInfo();
    GetEventInfo();
    GetSocietyInfo("Society");
    GetSocietyInfo("LegalCase");
 });
 
 /* 获取领导人信息 */
 function GetLeaderInfo()
 {
    $.post("Handler/GetInfo.ashx",
            {"type":"Leader"},
            function(data, textStatus){
                var content_total=new StringBuffer();
                var content_positive=new StringBuffer();
                var content_negative=new StringBuffer();                
                if(data!=null)
                {                    
                    for(var one in data)
                    {
                        var Row=data[one];                        
                        content_total.append("<li><a href=\"javascript:void(null);\">"+Row["Name"]+"</a>("+Row["TotalDocNums"]+")</li>");
                        content_positive.append("<li><a href=\"javascript:void(null);\">"+Row["Name"]+"</a>("+Row["PositiveNums"]+")</li>");
                        content_negative.append("<li><a href=\"javascript:void(null);\">"+Row["Name"]+"</a>("+Row["NegativeNums"]+")</li>")                        
                    }
                }
                else
                {
                    content.append("对不起，没有数据！");                     
                }                
                $("#columnTab1_Content0").html(content_total.toString());
                $("#columnTab1_Content1").html(content_positive.toString());
                $("#columnTab1_Content2").html(content_negative.toString());                
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
                        Content.append("<tr><td class=\"");
                        if(i==1)
                        { 
                            Content.append("pd_left pd_top");
                        }
                        else
                        {
                            Content.append("pd_left");
                        }
                        Content.append("\"><a href=\"search.html?query_type=2&keyword=" +Row["MainCateID"]+ "_&cate_type="+Row["CateType"]+"\" target=\"_blank\">");
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
                        Content.append("</td><td>");
                        Content.append(Row["TotalHitCount"]);
                        Content.append("条</td></tr>");
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
 function GetSocietyInfo(type)
 {
     $.post("Handler/GetInfo.ashx",
            { "type": type },
            function(data, textStatus) {
                var Content = new StringBuffer();
                if (data != null) {
                    for (var item in data) {
                        var Content = new StringBuffer();
                        var Row = data[item];
                        for (var i = 0; i < Row.length; i++) {
                            var Index = i + 1;
                            Content.append("<tr><td width=\"5%\"><em class=\"num0" + Index + "\">" + Index + "</em></td>");
                            Content.append("<td><a target=\"blank\" href=\"search.html?query_type=2&keyword=" + Row[i]["MainCateID"] + "_&cate_type="+Row[i]["CateType"]+"\">");
                            Content.append(Row[i]["CateDisplay"]);
                            Content.append("</a></td><td width=\"12%\">");
                            var Trend = Row[i]["TodayHitCount"] - Row[i]["YestodayHitCount"];
                            if (Trend > 0) {
                                Content.append("<span class=\"trend_up\">上升</span>");
                            }
                            else if (Trend < 0) {
                                Content.append("<span class=\"trend_down\">下降</span>");
                            }
                            else {
                                Content.append("<span class=\"trend_steady\">平稳</span>");
                            }
                            Content.append("</td><td>");
                            Content.append(Row[i]["TotalHitCount"]);
                            Content.append("条</td></tr>");
                        }
                        $("#" + item).html(Content.toString());
                    }
                }
            }, "json");
 }