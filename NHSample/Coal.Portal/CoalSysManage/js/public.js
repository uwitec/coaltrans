var t;
function Menu()
{
    var Htmlstr=$("#MenuList").html();
    if(Htmlstr!=null)
    {        
        clearInterval(t);
        var DivList=$("#MenuList").children("div");
        $(DivList).each(function(){
            var ChildList=$(this).children("div");
            var obj=this;
            $(this).children("a").each(function(){
                var Len=$(ChildList).length;
                var pid=$(this).attr("pid");
                if(Len==0)
                {
                    if(pid!=null)
                    {
                        $(this).click(function(){
                            parent.document.getElementById("main-frame").src=$(this).attr("pid");
                            DivHide(DivList);
                            SetHeight();
                        });     
                    } 
                    else
                    {
                        $(this).click(function(){                        
                            DivList.children("div").hide(); 
                            DivHide(DivList);
                            SetHeight();
                        }); 
                    }               
                }
                else
                {
                    $(this).click(function(){
                        if($(obj).attr("class")=="Menulist1")
                        {  
                            DivHide(DivList);               
                            ChildList.show();
                            $(obj).attr("class","NoMenulist1");
                            SetHeight();
                        }
                        else
                        {
                            ChildList.hide();
                            $(obj).attr("class","Menulist1");
                            SetHeight();
                        }
                    });
                }
                SetOthers(ChildList);
            });            
        });
    }
}
function SetOthers(ChildList)
{
    var DivList=ChildList;
    ChildList.each(function(){
        var ChildListArr=$(this).children("div");
        var obj=this;
        $(this).children("a").each(function(){
            var Len=$(ChildListArr).length;
            var pid=$(this).attr("pid");
            if(Len==0)
            {
                if(pid!=null)
                {
                    $(this).click(function(){
                        parent.document.getElementById("main-frame").src=$(this).attr("pid");
                        DivHide(DivList);
                        SetHeight();
                    });    
                } 
                else
                {
                    $(this).click(function(){                        
                        DivList.children("div").hide(); 
                        DivHide(DivList);
                        SetHeight();
                    });
                }               
            }
            else
            {
                $(this).click(function(){
                    if($(obj).attr("class")=="Menulist1")
                    {  
                        DivHide(DivList);               
                        ChildListArr.show();
                        $(obj).attr("class","NoMenulist1");
                        SetHeight();
                    }
                    else
                    {
                        ChildListArr.hide();
                        $(obj).attr("class","Menulist1");
                        SetHeight();
                    }
                });
            }
            SetOthers(ChildListArr);
        });
    });
}
function DivHide(obj)
{
    obj.children("div").hide();
    obj.each(function(){
        if($(this).children("div").length>0)
        {
            $(this).attr("class","Menulist1");
        }
        else
        {
            $(this).attr("class","NoMenulist1");
        }
    });  
}

function SetHeight()
{
    if($.browser.mozilla )
    {
        var height=0;
        $("#MenuList").children("div").each(function(){            
            if(!$(this).is(":hidden"))
            {
                SetChildHeight(this);
                height+=parseInt($(this).height());
            }             
        });    
        $("#MenuList").height(height);
    }
}
function SetChildHeight(obj)
{
    var height=parseInt($(obj).height())
    if(parseInt($(obj).height())>20)
    {
        height=20;
    }
    $(obj).children("div").each(function(){
        
        if(!$(this).is(":hidden"))
        {
            SetChildHeight(this);
            height+=parseInt($(this).height());
        }
    });
    $(obj).height(height);
}