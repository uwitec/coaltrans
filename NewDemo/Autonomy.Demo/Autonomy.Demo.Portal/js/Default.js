
 $(document).ready(function(){
    GetLeaderInfo(0);
    GetLeaderInfo(1);
    GetLeaderInfo(2);
});
 
 /* 获取领导人信息 */
 function GetLeaderInfo(code)
 {
    $.post("Handler/GetInfo.ashx",
            null,
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