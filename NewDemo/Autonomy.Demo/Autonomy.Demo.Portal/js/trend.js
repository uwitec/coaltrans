$(document).ready(function() {     
    get2dMapData("","","");
});

function get2dMapData(l_map_time_id,select_index,date_time)
{
    $.ajax({
        type: "get",
        url: "Handler/GetSGData.ashx",
        data: "map_time_id=" + l_map_time_id + "&select_index=" + select_index + "&date_time=" + date_time,
        beforeSend: function(XMLHttpRequest) {
            $("#hot_image").html("热点数据加载中……");
        },
        success: function(data, textStatus) {
            var map = $("#mapData");
            map.html(data);
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
        },
        complete: function(XMLHttpRequest, textStatus) {
            $("#hot_image").html("舆情热点图<br/>(点击红色方块，可在右侧区域获取文章列表)");
        },
        error: function() {
            //请求出错处理
        }
    });
}