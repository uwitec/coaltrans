function initialize()
{
    
}
function GetPager(PageCount,keyword)
{
    
    if(PageCount>10)
    {
        var  PagerContent=new StringBuffer();
        PagerContent.append("<span>上一页</span>");
        for(var i=1;i<=PageCount;i++)
        {
            if(i==1)
            {
                PagerContent.append("<span class=\"current\" id=\"Pager"+i+"\" style=\"margin-left:10px;\" onclick=\"GetFocus('Pager',"+i+","+PageCount+",'"+keyword+"')\" >"+i+"</span>");
            }
            else
            {
                PagerContent.append("<span id=\"Pager"+i+"\" style=\"margin-left:10px;\" onclick=\"GetFocus('Pager',"+i+","+PageCount+",'"+keyword+"')\"><a href=\"javascript:void(null);\" >["+i+"]</a></span>");
            }                        
        }
        PagerContent.append("<span><a href=\"javascript:void(null);\">下一页</a></span>");
        $("#PagerList").html(PagerContent.toString());
    }
    if(PageCount<=10)
    {
        var  PagerContent=new StringBuffer();
        for(var i=1;i<=PageCount;i++)
        {
            if(i==1)
            {
                PagerContent.append("<span class=\"current\" id=\"Pager"+i+"\" style=\"margin-left:10px;\" onclick=\"GetFocus('Pager',"+i+","+PageCount+",'"+keyword+"')\" >"+i+"</span>");
            }
            else
            {
                PagerContent.append("<span id=\"Pager"+i+"\" style=\"margin-left:10px;\" onclick=\"GetFocus('Pager',"+i+","+PageCount+",'"+keyword+"')\"><a href=\"javascript:void(null);\" >["+i+"]</a></span>");
            }
            $("#PagerList").html(PagerContent.toString());
            
        }
    }
}
function GetFocus(obj,PagerIndex,Pagecout,keyword)
{
    $.get("Handler/SearchResult.ashx", { 'keyword': keyword.toString(),'Start':(PagerIndex-1)*10+1},
        function(data) {
            var Ldata=data.split('※');     
                              
            $("#SearchResult").html(Ldata[0]);   
        });
    for(var one=1;one<=Pagecout;one++)
    {
        if(one==PagerIndex)
        {
            $("#"+obj+one).html(PagerIndex);
            $("#"+obj+one).attr("class","current");
            
        }
        else
        {
            $("#"+obj+one).html("<a href=\"javascript:void(null);\" >["+one+"]</a>");
            $("#"+obj+one).attr("class","");
        }
    }
    
}