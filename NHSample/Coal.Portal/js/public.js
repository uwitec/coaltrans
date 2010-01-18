function openWin(htmUrl)

{

var url=htmUrl; //要打开的窗口

var winName="newWin"; //给打开的窗口命名


   // screen.availWidth 获得屏幕宽度

// screen.availHeight 获得屏幕高度

// 居中的算法是：

   // 左右居中： (屏幕宽度-窗口宽度)/2

// 上下居中： (屏幕高度-窗口高度)/2

var awidth=screen.availWidth/7*2; //窗口宽度,需要设置

var aheight=screen.availHeight/6*2; //窗口高度,需要设置 

var atop=(screen.availHeight - aheight)/2; //窗口顶部位置,一般不需要改

var aleft=(screen.availWidth - awidth)/2; //窗口放中央,一般不需要改

var param0="scrollbars=0,status=0,menubar=0,resizable=2,location=0"; //新窗口的参数

//新窗口的左部位置，顶部位置，宽度，高度

var params="top=" + atop + ",left=" + aleft + ",width=" + awidth + ",height=" + aheight + "," + param0 ;


win=window.open(url,winName,params); //打开新窗口

win.focus(); //新窗口获得焦点

}

