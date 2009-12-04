// JavaScript Document
	//左侧菜单
	function showSubMenu(ss,ii)
	{
		var menuobjedt=document.getElementById(ss);
		if (menuobjedt)
		{
			if (menuobjedt.style.display=="none") 
			{
				menuobjedt.style.display="";
				document.getElementById(ii).className = "on";
				document.getElementById(ii).title="关闭菜单";
			}
			else
			{
				menuobjedt.style.display="none"; 
				document.getElementById(ii).className = "off";
				document.getElementById(ii).title="展开菜单";
			}
		}
	}
	function reloadpage()
	{
		parent.window_left.location.reload();
	}
