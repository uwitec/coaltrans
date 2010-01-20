<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pager.aspx.cs" Inherits="pager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" rel="Stylesheet" href="css/pager.css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/Pager.js"></script>
    <script type="text/javascript">
    $(document).ready(function(){
        var parameterList={"city":"101"};        
        var outStr="'<div><td>'+row['ID']+'</td><td>'+row['ID']+'</td><td>'+row['ID']+'</td><td>'+row['ID']+'</td></div>'";
	    IntPager=new Pager("DisplayList",outStr,"Handler/TranList.ashx","Pager",20,true,true,parameterList);
		IntPager.innit();   
	});
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="DisplayList">        
    </div>
    <div id="Pager" class="Pager_display">
        
    </div>
    </form>
</body>
</html>
