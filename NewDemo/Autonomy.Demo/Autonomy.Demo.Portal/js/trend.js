$(document).ready(function() {
    get2dMapData("", "", "");
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
            
            $(".node").each(function(n) {
                $(this).mouseover(function() {
                    var num = $(this).attr("id").split("_")[1];
                    $("#clustertitle_" + num).show();
                    $(this).css("border-left","2px solid rgb(255, 255, 255)").css("border-right","2px solid rgb(255, 255, 255)");
                });

                $(this).mouseout(function() {
                    var num = $(this).attr("id").split("_")[1];
                    $("#clustertitle_" + num).hide();
                    $(this).css("border-left", "").css("border-right", "");
                });

                $(this).click(function() {
                    var info_list = $(this).attr("pid").split("※");
                    getSGDataResults(info_list[0], info_list[1], info_list[2]);
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
function getSGDataResults(point_id,from_time_id,end_time_id)
{
    $.get("Handler/GetSGDataResults.ashx", { 'point_id': point_id,"from_time_id":from_time_id,"end_time_id": end_time_id},
        function(data) {
            $("#hot_prompt").empty();
            $("#doc_list").empty().html(data);            
        }
    );
}