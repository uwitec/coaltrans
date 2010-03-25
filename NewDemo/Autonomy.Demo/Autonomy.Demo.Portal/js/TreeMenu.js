/* 设置菜单列表的点击事件 */
function  setMenu(div_list)
{
    div_list.each(function(){
        var child_list_array=$(this).children("div");
        var current_obj=this;
        $(this).children("a").each(function(){
            var Len=$(child_list_array).length;            
            if(Len==0)
            {
                $(this).click(function(){  
                    var category_id=$(this).attr("pid");
                    //alert(category_id);                                            
                });                     
            }
            else
            {
                $(this).click(function(){
                    if($(current_obj).attr("class")=="Menulist1")
                    {                                         
                        child_list_array.show();
                        $(current_obj).attr("class","NoMenulist1");
                        SetHeight();
                    }
                    else
                    {
                        child_list_array.hide();
                        $(current_obj).attr("class","Menulist1");
                        SetHeight();
                    }
                });
                setMenu(child_list_array);
            }            
        });
    });
}
/* 火狐兼容性 */
/* 设置父级栏目高度 */
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
/* 设置子级栏目高度 */
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