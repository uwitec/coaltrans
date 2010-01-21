 
 /*//* *
 * AJAX分页类
 *
 * @version : v1.1
 */
 /*初始化参数*/
 var reqData = { page_size: 10, page_index: 1, page_count: 1, cur_page: 1};
 var TotalParamet;
 var Display;
 var OutPut;
 var OutStr;
 var AshxUrl;
 var IsDisTotal;
 var IsDisSearch;
 var jsonStr=null;
 /*初始化分页类*/
 var Pager=function(OutPutId,OutPutStr,Url,DisplayId,PageSize,DisTotal,DisSearch,json)
 {
    Display=DisplayId;
    reqData.page_size=PageSize;
    OutPut=OutPutId;
    OutStr=OutPutStr;
    AshxUrl=Url;
    IsDisSearch=DisSearch;
    IsDisTotal=DisTotal;
    OutStr="content+="+OutPutStr;
    TotalParamet=eval(CreateJson(reqData,json));
    this.innit=function()
    {
        DataBind(true);
    } 
 }
 
  /*//* *
 * 构造StringBuffer类
 *
 * @version : v1.1
 */
 function StringBuffer()   
 {   
     this._strings = [];   
     if(arguments.length==1)   
     {   
         this._strings.push(arguments[0]);   
     }   
 }   
   
 StringBuffer.prototype.append = function(str)   
 {   
     this._strings.push(str);   
     return this;   
 }   
   
 StringBuffer.prototype.toString = function()   
 {   
     return this._strings.join("");   
 }   
   
 /* 返回长度 */  
 StringBuffer.prototype.length = function()   
 {   
     var str = this._strings.join("");   
     return str.length;   
 }   
   
 /* 删除后几位字符 */  
 StringBuffer.prototype.del = function(num)   
 {   
     var len = this.length();   
     var str = this.toString();   
     str     = str.slice(0,len-num);   
     this._strings = [];   
     this._strings.push(str);   
 }  
 
/*//* *
* 构造Pager类的相关函数
*
* @version : v1.1
*/
/*对页数指示进行初始化*/ 
function InnitDes(obj)
{
    if(IsDisTotal)
    {
        $("#"+obj).append("<div class=\"TotalPageCount\">共"+reqData.page_count+"页，当前第"+reqData.cur_page+"页</div>");   
    }             
}

function SetPre(obj)
{          
    if(reqData.cur_page==1)
    {
        $("#"+obj).append("<div class=\"StylePageCount\">上一页</div>");
        $("#"+obj).append("<div class=\"firstpage\">首页</div>");
    }
    else
    {
        $("#"+obj).append("<div class=\"StylePageCount\"><a href=\"javascript:void(null);\" style=\"text-decoration:none; color:blue;\" title=\"上一页\" id=\"\pre\">上一页</a></div>");
        $("#"+obj).append("<div class=\"firstpage\"><a href=\"javascript:void(null);\" style=\"text-decoration:none; color:blue;\" title=\"首页\" id=\"\PageFirst\">首页</a></div>");
        var pre_Page=parseInt(reqData.cur_page)-1;
        $("#pre").bind("click",{ cur_id: pre_Page},paging);
        $("#PageFirst").bind("click",{ cur_id:1},paging);
    }
}

function SetNext(obj)
{      
            
    if(reqData.cur_page==reqData.page_count)
    {
        $("#"+obj).append("<div class=\"firstpage\">末页</div>");
        $("#"+obj).append("<div class=\"StylePageCount\">下一页</div>");        
    }
    else
    {
        $("#"+obj).append("<div class=\"firstpage\"><a href=\"javascript:void(null);\" style=\"text-decoration:none; color:blue;\" title=\"末页\" id=\"\PageLast\">末页</a></div>");
        $("#"+obj).append("<div class=\"StylePageCount\"><a href=\"javascript:void(null);\" style=\"text-decoration:none; color:blue;\" title=\"下一页\" id=\"next\">下一页</a></div>");        
        var next_Page=parseInt(reqData.cur_page)+1;
        $("#next").bind("click",{ cur_id: next_Page},paging);
        $("#PageLast").bind("click",{ cur_id: reqData.page_count},paging);
    }
    if(IsDisSearch)
    {
        $("#"+obj).append("<div class=\"SearchPage\">第<input type=\"text\" style=\"width:25px; height:11px;\"  id=\"PageSelect\" />页<span style=\"margin-left:5px;\"><a href=\"javascript:void(null);\" id=\"SelPage\">GO</a></span>");
        $("#SelPage").click(function(){  
            var pages=parseInt( $("#PageSelect").val());          
            $("#"+Display).empty();
            reqData.cur_page=pages;
            reqData.page_index=pages;  
            if(TotalParamet!=null)
            {
                TotalParamet.cur_page=pages;
                TotalParamet.page_index=pages;
            }     
            DataBind(false);
            innitPager();    
        });
    }
}

function SetPageer(obj)
{ 
    if((reqData.page_count<=10)&&(reqData.cur_page<=10))
    {
        for(var page=1;page<=reqData.page_count;page++)
        {
            if(page==reqData.cur_page)
            {
                $("#"+obj).append("<div class=\"OnLinkPage\">"+page+"</div>");
            }
            else
            {
                $("#"+obj).append("<a href=\"javascript:void(null);\" class=\"Pager_Count\" pid=\""+page+"\" title=\"第"+page+"页\"><div class=\"LinkPage\">"+page+"</div></a>");                           
            }
        } 
    }
    else if((reqData.page_count>10)&&(reqData.cur_page>(reqData.page_count-9)))
    {
        for(var page=reqData.page_count-9;page<=reqData.page_count;page++)
        {
            if(page==reqData.cur_page)
            {
                $("#"+obj).append("<div class=\"OnLinkPage\">"+page+"</div>");
            }
            else
            {
                $("#"+obj).append("<a href=\"javascript:void(null);\" class=\"Pager_Count\" pid=\""+page+"\" title=\"第"+page+"页\"><div class=\"LinkPage\">"+page+"</div></a>");                           
                                        
            }
        } 
    }
    else if((reqData.page_count>10)&&(reqData.cur_page<=(reqData.page_count-9)))
    {
        if(reqData.cur_page<=5)
        {
            var toplimit=10;
            for(var page=1;page<=toplimit;page++)
            {
                if(page==reqData.cur_page)
                {
                    $("#"+obj).append("<div class=\"OnLinkPage\">"+page+"</div>");
                }
                else
                {
                    $("#"+obj).append("<a href=\"javascript:void(null);\" class=\"Pager_Count\" pid=\""+page+"\" title=\"第"+page+"页\"><div class=\"LinkPage\">"+page+"</div></a>");                           
                }
            } 
        }
        else if(reqData.cur_page>=reqData.page_count-5)
        {
            var toplimit=reqData.page_count;
            for(var page=reqData.cur_page;page<=toplimit;page++)
            {
                if(page==reqData.cur_page)
                {
                    $("#"+obj).append("<div class=\"OnLinkPage\">"+page+"</div>");
                }
                else
                {
                    $("#"+obj).append("<a href=\"javascript:void(null);\" class=\"Pager_Count\" pid=\""+page+"\" title=\"第"+page+"页\"><div class=\"LinkPage\">"+page+"</div></a>");                          
                }
            } 
        }
        else
        {
            var lowerlimit=parseInt(reqData.cur_page)-5;
            var toplimit=parseInt(reqData.cur_page)+5; 
            for(var page=lowerlimit;page<=toplimit;page++)
            {
                if(page==reqData.cur_page)
                {
                    $("#"+obj).append("<div class=\"OnLinkPage\">"+page+"</div>");
                }
                else
                {
                   $("#"+obj).append("<a href=\"javascript:void(null);\" class=\"Pager_Count\" pid=\""+page+"\" title=\"第"+page+"页\"><div class=\"LinkPage\">"+page+"</div></a>");                          
                }
            } 
        }
    }
    
    
    $(".Pager_Count").each(function(){
        var id=$(this).attr("pid");
        $(this).bind("click",{ cur_id: id},paging);
    });
}
function paging(event)
{
    $("#"+Display).empty();
    var pages=event.data.cur_id;
    reqData.cur_page=pages;
    reqData.page_index=pages;
    if(TotalParamet!=null)
    {
        TotalParamet.cur_page=pages;
        TotalParamet.page_index=pages;
    }    
    DataBind(false);
    innitPager();
}
function DataBind(isInit)
{
   $.post(AshxUrl,
   TotalParamet,
   function(data,textStatus) {    
       if(data.rows!=null)
       {
          reqData.page_count = data.pageCount;       
          var content ="";
          
          for(var one in data.rows)
          {
            var row=data.rows[one];            
            eval(OutStr);  
                      
          }
          $("#"+OutPut).html("");
          $("#"+OutPut).html(content);
          $(".LookContent").each(function(){
            var Info=$(this).attr("id");
            $(this).bind("click",{ MsgInfo : Info},deal);
          });
          $(".DeleteInfo").each(function(){
            var Info=$(this).attr("id");
            $(this).bind("click",{ MsgInfo : Info},deal);
          });
          $("#Total").html(data.MsgTotalCount);
          $("#Issee").html(data.MsgIsSeeCount);
          $("#Nosee").html(data.MsgNoSeeCount);
          var List=$("#"+OutPut).children();
          List.hover(on,out);
          if(isInit)
          {
            innitPager();
          }
       }
       else
       {
            var content = new StringBuffer();
            content.append("<div>");
            content.append("对不起，没有数据！</div>"); 
            $("#"+OutPut).html("");
            $("#"+OutPut).html(content.toString());
       }
  },
  "json");
  
}
function innitPager()
{
    InnitDes(Display);
    SetPre(Display);
    SetPageer(Display);
    SetNext(Display);
}
function on()
{
    $(this).css({"background-color":"#999"});   
}
function out()
{
    $(this).css({"background-color":"white"});
}
function CreateJson(Data1,Data2)
{
    var Str="({";
    for(var one in Data1)
    {
        Str+="'"+one+"':'"+Data1[one]+"',";
    }
    if(Data2!=null)
    {        
        for(var one in Data2)
        {
            Str+="'"+one+"':'"+Data2[one]+"',";
        }
    }
    Str+="'action':'search'})";
    return Str;
}
function deal(event)
{
    var Str=event.data.MsgInfo;
    var StrArry=Str.split('_');
    switch(StrArry[0])
    {
        case "Look":
            window.open("MessageDisplay.aspx?ID="+StrArry[1],"newwindow","width=400,height=300,scrollbars=yes");
            if(StrArry[2]=="0")
            {
                TotalParamet["IsSee"]=0;   
                $("#"+Display).html("");             
                DataBind(true);
            }            
            break;
        case "Delete":
            if(confirm("您确定要删除该记录么？"))
            {
                TotalParamet["action"]="delete";
                $.post("Handler/MessageList.ashx?ID="+StrArry[1],TotalParamet,function(data){
                    if(data=="1")
                    {
                        TotalParamet["action"]="search";
                        TotalParamet["IsSee"]=StrArry[2];   
                        $("#"+Display).html("");             
                        DataBind(true); 
                    }
                });
            }
            break;
        default:
            break;    
            
    }
}