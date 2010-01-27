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
                            ChildList.hide();
                        });    
                    } 
                    else
                    {
                        $(this).click(function(){
                            ChildList.hide();
                        }); 
                    }               
                }
                else
                {
                    $(this).click(function(){
                        if($(obj).attr("class")=="Menulist1")
                        {  
                            DivList.children("div").hide();
                            DivList.each(function(){$(this).attr("class","Menulist1");});                 
                            ChildList.show();
                            $(obj).attr("class","NoMenulist1");
                        }
                        else
                        {
                            ChildList.hide();
                            $(obj).attr("class","Menulist1");
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
                        DivList.children("div").hide(); 
                    });    
                } 
                else
                {
                    $(this).click(function(){                        
                        DivList.children("div").hide(); 
                    });
                }               
            }
            else
            {
                $(this).click(function(){
                    var Display=$(obj).attr("Lid");
                    if(Display==null||Display=="display")
                    {
                        DivList.children("div").hide();                                       
                        ChildListArr.show();
                        $(obj).attr("Lid","Nodisplay");
                    }
                    else
                    {
                        ChildListArr.hide();
                        $(obj).attr("Lid","display");
                    }
                });
            }
            SetOthers(ChildListArr);
        });
    });
}