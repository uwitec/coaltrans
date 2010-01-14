<!--页面头部 开始-->
<div class="header">
  <div class="logo">
    <a href="#" title="国家煤炭工业网">国家煤炭工业网</a>
  </div>
  <div class="topNav">
    <a href="index.html">首页</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="in_construction.html">功能地图</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="in_construction.html">日志查询</a>&nbsp;&nbsp;
  </div>
  <ul class="mainNav">
    <li class="current">
      <a href="index.html">首 页</a>
    </li>
    <li class="">
      <a href="coal_list.aspx">供 应</a>
    </li>
    <li class="">
      <a href="coal_list.aspx">采 购</a>
    </li>
    <li class="">
      <a href="in_construction.html">招 标</a>
    </li>
    <li class="">
      <a href="in_construction.html">投 标</a>
    </li>
  </ul>
  <div class="searchBar">
    <div class="searchBody">
      <form name="TheSearchForm" action="Search/SearchList.aspx" method="post">
        <input name="keyword" type="text" class="input_text" value="请输入产品名称或公司名称" onFocus="this.style.color='#000';this.value=''" onBlur="if(this.value==''){this.value='请输入产品名称或公司名称';this.style.color='#a0a0a0'}" />
        <div class="selectBar">
          <div class="selectTitle" id="selectTitle">请选择</div>
          <ul class="selectBody" id="selectSort">
            <li>
              <a href="#">供应</a>
            </li>
            <li>
              <a href="#">采购</a>
            </li>
            <li>
              <a href="#">招标</a>
            </li>
            <li>
              <a href="#">投标</a>
            </li>
          </ul>
        </div>
        <input name="button" type="submit" value="模糊查询" class="input_button" />
        
      </form>
    </div>
    <div class="searchKeyword">
      热门搜索：<a href="#">神华</a> <a href="#">无煤烟</a> <a href="#">焦油</a> <a href="#">神华</a> <a href="#">无煤烟</a> <a href="#">焦油</a>
    </div>
  </div>
</div>
<!--页面头部 结束-->

<script type="text/javascript">
  var div1 = document.getElementById("selectTitle");
  var div2 = document.getElementById("selectSort");
  div1.onmouseover = function(e) {
  div2.style.display = "block";
  }
  div2.onmouseout = function(e) {
  e = e || window.event;
  o = e.relatedTarget || e.toElement;
  while (o.parentNode && o.id != "selectSort") {
  o = o.parentNode;
  }
  if (o.id != "selectSort") {
  div2.style.display = "none";
  }
  }

  var navlist=$("#selectSort").find("a");
  $(navlist).click(function(){
  $("#selectTitle").html($(this).html());
  });


</script>
