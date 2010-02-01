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