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
                Content+="<table style='width:100%;'>";
                Content+="<tr><td colspan='4'><b>基本信息</b></td></tr>";
                Content+="<tr><td align='right' style='width:15%;'>求购标题：</td><td colspan='3'>"+row["DemandTitle"]+"</td></tr>";
                Content+="<td align='right'>煤种：</td><td style='width:35%;'>"+row["CoalType"]+"</td><td align='right' style='width:15%;'>需求量：</td><td style='width:35%;'>"+row["DemandQuantity"]+"</td></tr>";
                Content+="<tr><td colspan='4'><b>指标信息</b></td></tr>";
                Content+="<td align='right'>发热量：</td><td style='width:35%;'>"+row["CalorificPower"]+"</td><td align='right' style='width:15%;'>粒度：</td><td style='width:35%;'>"+row["Granularity"]+"</td></tr>";
                Content+="<td align='right'>灰分：</td><td style='width:35%;'>"+row["Ash"]+"</td><td align='right' style='width:15%;'>硫份：</td><td style='width:35%;'>"+row["Sulphur"]+"</td></tr>";
                Content+="<td align='right'>水分：</td><td style='width:35%;'>"+row["Water"]+"</td><td align='right' style='width:15%;'>热稳定性：</td><td style='width:35%;'>"+row["HotStability"]+"</td></tr>";
                Content+="<td align='right'>灰熔融性：</td><td style='width:35%;'>"+row["AshFusing"]+"</td><td align='right' style='width:15%;'>可磨性：</td><td style='width:35%;'>"+row["Wearproof"]+"</td></tr>";
                Content+="<td align='right'>固定碳含量：</td><td style='width:35%;'>"+row["Carbon"]+"</td><td align='right' style='width:15%;'>机械强度：</td><td style='width:35%;'>"+row["MaStrength"]+"</td></tr>";
                Content+="<td align='right'>粘结指数：</td><td style='width:35%;'>"+row["BinderMark"]+"</td><td align='right' style='width:15%;'>挥发份：</td><td style='width:35%;'>"+row["Volatilize"]+"</td></tr>";
                Content+="<tr><td colspan='4'><b>其他信息</b></td></tr>";               
                Content+="<td align='right'>是否需要运输：</td><td style='width:35%;'>"+row["IsTransport"]+"</td><td align='right' style='width:15%;'>价格：</td><td style='width:35%;'>"+row["TransportPrice"]+"</td></tr>";
                Content+="<tr><td align='right' style='width:15%;'>结算方法：</td><td colspan='3'>"+row["EstimateStyle"]+"</td></tr>";
                Content+="<tr><td colspan='4'><b>联系信息</b></td></tr>";               
                Content+="<td align='right'>联系人：</td><td style='width:35%;'>"+row["TrueName"]+"</td><td align='right' style='width:15%;'>联系电话：</td><td style='width:35%;'>"+row["FixedTel"]+"</td></tr>";
                Content+="<td align='right'>手机：</td><td style='width:35%;'>"+row["MobileTel"]+"</td><td align='right' style='width:15%;'>传真：</td><td style='width:35%;'>"+row["Fax"]+"</td></tr>";
                Content+="<td align='right'>E-Mail：</td><td style='width:35%;'>"+row["BizEmail"]+"</td><td align='right' style='width:15%;'>邮编：</td><td style='width:35%;'></td></tr>";
                Content+="<td align='right'>详细地址：</td><td colspan='3'></td></tr>";
                Content+="</table>";
                break;
            case "InviteInfoList":
                Content+="<table style='width:100%;'>";  
                Content+="<tr><td colspan='4'><b>招标信息</b></td></tr>";              
                Content+="<tr><td align='right' style='width:15%;'>招标标题：</td><td colspan='3'>"+row["InviteTitle"]+"</td></tr>";                
                Content+="<td align='right'>起始时间：</td><td style='width:35%;'>"+row["StartTime"]+"</td><td align='right' style='width:15%;'>结束时间：</td><td style='width:35%;'>"+row["EndTime"]+"</td></tr>";                
                Content+="<tr><td align='right' style='width:15%;'>附件地址：</td><td colspan='3'><a href='"+row["AdjunctUrl"]+"' title='点击下载附件'>"+row["AdjunctUrl"]+"</a></td></tr>";   
                Content+="<tr><td align='right' style='width:15%;' valign='top'>详细信息：</td><td cols='3' >"+row["Details"]+"</td></tr>";
                Content+="<tr><td colspan='4'><b>联系信息</b></td></tr>"; 
                Content+="<td align='right'>联系人：</td><td style='width:35%;'>"+row["TrueName"]+"</td><td align='right' style='width:15%;'>联系电话：</td><td style='width:35%;'>"+row["FixedTel"]+"</td></tr>";
                Content+="<td align='right'>手机：</td><td style='width:35%;'>"+row["MobileTel"]+"</td><td align='right' style='width:15%;'>传真：</td><td style='width:35%;'>"+row["Fax"]+"</td></tr>";
                Content+="<td align='right'>E-Mail：</td><td style='width:35%;'>"+row["BizEmail"]+"</td><td align='right' style='width:15%;'>邮编：</td><td style='width:35%;'></td></tr>";
                Content+="<td align='right'>详细地址：</td><td colspan='3'></td></tr>";
                Content+="</table>";
                break;
            case "TenderInfoList":
                Content+="<table style='width:100%;'>";  
                Content+="<tr><td colspan='4'><b>投标信息</b></td></tr>";              
                Content+="<tr><td align='right' style='width:15%;'>投标标题：</td><td colspan='3'>"+row["TenderTitle"]+"</td></tr>";                
                Content+="<td align='right'>起始时间：</td><td style='width:35%;'>"+row["StartTime"]+"</td><td align='right' style='width:15%;'>结束时间：</td><td style='width:35%;'>"+row["EndTime"]+"</td></tr>";                
                Content+="<tr><td align='right' style='width:15%;'>附件地址：</td><td colspan='3'><a href='"+row["AdjunctUrl"]+"' title='点击下载附件'>"+row["AdjunctUrl"]+"</a></td></tr>";   
                Content+="<tr><td align='right' style='width:15%;' valign='top'>详细信息：</td><td cols='3' >"+row["Details"]+"</td></tr>";
                Content+="<tr><td colspan='4'><b>联系信息</b></td></tr>"; 
                Content+="<td align='right'>联系人：</td><td style='width:35%;'>"+row["TrueName"]+"</td><td align='right' style='width:15%;'>联系电话：</td><td style='width:35%;'>"+row["FixedTel"]+"</td></tr>";
                Content+="<td align='right'>手机：</td><td style='width:35%;'>"+row["MobileTel"]+"</td><td align='right' style='width:15%;'>传真：</td><td style='width:35%;'>"+row["Fax"]+"</td></tr>";
                Content+="<td align='right'>E-Mail：</td><td style='width:35%;'>"+row["BizEmail"]+"</td><td align='right' style='width:15%;'>邮编：</td><td style='width:35%;'></td></tr>";
                Content+="<td align='right'>详细地址：</td><td colspan='3'></td></tr>";
                Content+="</table>";
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


var drag_=false
var D=new Function('obj','return document.getElementById(obj);')
var oevent=new Function('e','if (!e) e = window.event;return e')
function Move_obj(obj){
	var x,y;
	D(obj).onmousedown=function(e){
		drag_=true;
		with(this){
			style.position="absolute";var temp1=offsetLeft;var temp2=offsetTop;
			x=oevent(e).clientX;y=oevent(e).clientY;
			document.onmousemove=function(e){
				if(!drag_)return false;
				with(this){
					style.left=temp1+oevent(e).clientX-x+"px";
					style.top=temp2+oevent(e).clientY-y+"px";
				}
			}
		}
		document.onmouseup=new Function("drag_=false");
	}
}