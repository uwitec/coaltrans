function ConverList()
{
    var List= SelByClass("ListTableBody","tr");
    for(var i=0;i<List.length;i++)
    {
        List[i].onmouseover=on;
        List[i].onmouseout=out;
    }        
}
function on()
{
    this.className="LinkListTableBody";
}
function out()
{
    this.className="ListTableBody";
}
function Sel(obj)
{
   var Value=obj.checked;
   var CheckBoxList=SelInput("checkbox","input");
   if(Value)
   {
        for(var i=0;i<CheckBoxList.length;i++)
        {
            CheckBoxList[i].checked=true;
        }
   }
   else
   {
        for(var i=0;i<CheckBoxList.length;i++)
        {
            CheckBoxList[i].checked=false;
        }
   }
}
function SelInput(value,type)
{
    var r=[];
    var list=document.getElementsByTagName(type);
    for(var i=0;i<list.length;i++)
    {
        if(list[i].type==value)
            r.push(list[i])
    }
    return r;
}
function SelByClass(value,type)
{
    var r=[];
    var list=document.getElementsByTagName(type);
    for(var i=0;i<list.length;i++)
    {
        if(list[i].className==value)
            r.push(list[i])
    }
    return r;
}

function Display(obj,TabelName1,TabelName2,Key,foreignkey,value,type)
{   
    var Content=""; 
    var Lobj=document.getElementById(obj);
    Lobj.style.display="block";
    var Data = Ajax.call("../Handler/GetInfo.ashx", "TableName1="+TabelName1+"&TableName2="+TabelName2+"&PrimaryKey=" + Key + "&foreignkey="+foreignkey+"&value=" +value, null, "POST", "JSON", false);
    
    Data=eval("("+Data+")");
    if(Data.rows!=null)
    {        
        var row=Data.rows[0];
        switch(type)
        {
            case "AdPositionDis":
                Content+="名称："+row["PositionName"]+"<p/>";
                Content+="宽度："+row["AdWidth"]+"像素<p/>";
                Content+="高度："+row["AdHeight"]+"像素<p/>";
                Content+="详细："+row["AdDetails"]+"<p/>";
                Content+="类型："+row["AdType"];                    
                break;
            case "AdListDis":
                Content+="广告名称："+row["AdName"]+"<p/>";
                Content+="所属位置："+row["PositionName"]+"<p/>";
                Content+="广告链接："+row["AdLink"]+"<p/>";
                Content+="广告简介："+row["AdDesc"]+"<p/>";
                Content+="开启时间："+row["StartTime"]+"<p/>";
                Content+="结束时间："+row["EndTime"]+"<p/>";
                Content+="是否开启："+row["IsOpen"]+"<p/>";
                Content+="联系人："+row["LinkMan"]+"<p/>";
                Content+="联系电话："+row["LinkPhone"]+"<p/>";
                Content+="联系Email："+row["LinkEmail"]+"<p/>";
                Content+="点击次数："+row["ClickNum"]+"<p/>";    
                break;
            case "DemandInfoList":
                Content+="求购标题："+row["DemandTitle"];
                break;
            default:
                break;
        }
    }
    var CloseWidth=Lobj.style.width;
    Lobj.innerHTML=Content+"<span style='position:absolute;right:15px;top:5px;'><a href='javascript:void(null);' onclick='Lclose(\""+obj+"\")'>关闭</a></span>"; 
    var LWidth=document.body.scrollWidth/4;
    var Lheigh=document.body.scrollHeight/3;
    Lobj.style.left=LWidth+"px"; 
    Lobj.style.top=Lheigh+"px";    
}
function Lclose(obj)
{
    document.getElementById(obj).style.display="none";
}