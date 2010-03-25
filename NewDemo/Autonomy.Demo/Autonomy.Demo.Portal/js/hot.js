
nav_data.data[2].is_current = true;
var map_time_id;
$(document).ready(function() {     
    get2dMapData("","","");
    $("a[name=BtnClickList]").each(function(){
        $(this).click(function(){
            get2dMapData(map_time_id,$(this).attr("pid"),$("#input_data").val());
        });
    });
});
function get2dMapData(l_map_time_id,select_index,date_time)
{
    $.ajax({
        type: "get",
        url: "Handler/GetMapData.ashx",
        data: "map_time_id=" + l_map_time_id + "&select_index=" + select_index + "&date_time=" + date_time,
        beforeSend: function(XMLHttpRequest) {
            $("#hot_image").html("热点数据加载中……");
        },
        success: function(data, textStatus) {
            var data_list = data.split('※');
            $("#input_data").val(data_list[2]);

            if (data_list[0] != "") {
                var map = $("#mapData");
                map_time_id = data_list[1];
                map.html(data_list[0]);
                //隐藏文字说明
                $(".node_text").each(function() {
                    $(this).hide();
                });

                $(".node").each(function() {
                    $(this).mouseover(function() {
                        var num = $(this).attr("id").split("_")[1];
                        $("#clustertitle_" + num).show();
                    });

                    $(this).mouseout(function() {
                        var num = $(this).attr("id").split("_")[1];
                        $("#clustertitle_" + num).hide();
                    });

                    $(this).click(function() {
                        var point_id = $(this).attr("id").split("_")[1];
                        $.get("Handler/GetClusterResults.ashx", { 'point_id': point_id },
                                    function(data) {
                                        $("#hot_prompt").empty();
                                        $("#whats_hot").empty().html(data);
                                        $("#whats_hot").show();
                                    }
                                );
                    });
                }); //each end
            }
            else {
                alert("已经到达最后一页");
                //get2dMapData(data_list[1], "self", date_time);
            }
            $("#hot_img").attr("src", "http://121.101.220.143:8081/2DMap/" + data_list[1] + ".jpeg");
        },
        complete: function(XMLHttpRequest, textStatus) {
            $("#hot_image").html("舆情热点图<br/>(点击红色方块，可在右侧区域获取文章列表)");
        },
        error: function() {
            //请求出错处理
        }
    });
}