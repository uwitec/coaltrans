// JavaScript Document

function openVessel(strId)
{
	document.getElementById(strId).style.display = "block";
}
function closeVessel(strId)
{
	document.getElementById(strId).style.display = "none";
}

var backgroundC={
		$:function(id){return document.getElementById(id);}
		,dElement:function(){
			return	document.documentElement || document.body;
		}
		,style:function(o){	//获取全局样式表、内嵌样式（不能设置）
			return o.currentStyle || document.defaultView.getComputedStyle(o,null);
		}
		,alpha:function(o,num){//设置透明度	
			o.style.filter='alpha(opacity='+num+')';
			o.style.opacity=num/100;
		}
		,load:function(showId,bgId){
			var obj=this.$(bgId);
			obj.style.width=this.dElement().clientWidth+'px';
			obj.style.height=(this.dElement().scrollHeight>this.dElement().clientHeight?this.dElement().scrollHeight:this.dElement().clientHeight)+'px';
			obj.style.display='block';
			this.alpha(obj,50)
			var showObj=this.$(showId)
			showObj.style.display='block';
			showObj.style.left=(this.dElement().clientWidth-parseInt(this.style(showObj).width))/2+'px';
			showObj.style.top=((this.dElement().clientHeight-showObj.clientHeight)/2+this.dElement().scrollTop)+'px';
		}
		,close:function(showId,bgId){
			this.$(showId).style.display='none';
			this.$(bgId).style.display='none';
		}
	}