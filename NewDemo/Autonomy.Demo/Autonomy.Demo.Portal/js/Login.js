$(document).ready(function(){
   $("#username").val("在此输入用户名"); 
   $("#username").focus(function(){
        $("#username").val("");
   });   
   
   $("#loginButton").click(function(){
        Btnclick();
   });
   $(document).keydown(function(event){
        if(event.keyCode==13) {
            Btnclick();
        }
   }); 
});
function UserInfoCheck(UserName,PassWord)
{
    var Flag=true;
    
    if(UserName=="")
    {
        $("#username").next("div").show();
        Flag=false;
    }   
    else
    {
        $("#username").next("div").hide();
    } 
    if(PassWord=="")
    { 
        $("#pwd").next("div").show();
        Flag=false;
    }    
    else
    {
        $("#pwd").next("div").hide();
    }
    return Flag;
}

function Btnclick()
{
   var UserName=$("#username").val();
   var PassWord=$("#pwd").val();
   if(UserInfoCheck(UserName,PassWord))
   {
        $.post("Handler/User.ashx",
            {'User_Name':UserName,'Pass_Word':PassWord},
            function(Data,textStatus){                    
                if(Data.SuccessCode==1)
                {                        
                    location.href="index.html";
                }
                else
                {
                    $("#pwd").next("div").show();
                    $("#pwd").next("div").html("用户信息出错，请您认真审核！");
                }                   
            },"json");
   }
}