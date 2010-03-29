function StringBuffer() {
    this._strings = [];
    if (arguments.length == 1) {
        this._strings.push(arguments[0]);
    }
}

StringBuffer.prototype.append = function(str) {
    this._strings.push(str);
    return this;
}

StringBuffer.prototype.toString = function() {
    return this._strings.join("");
}

/* 返回长度 */
StringBuffer.prototype.length = function() {
    var str = this._strings.join("");
    return str.length;
}

/* 删除后几位字符 */
StringBuffer.prototype.del = function(num) {
    var len = this.length();
    var str = this.toString();
    str = str.slice(0, len - num);
    this._strings = [];
    this._strings.push(str);
}

/*导航栏目数据*/
var nav_data = { data: [{ href: "index.html", title: "首页"}
               , { href: "special.html", title: "舆论专题"}
               , { href: "hot.html", title: "热点分布" }
               , { href: "trend.html", title: "舆情趋势" }
               , { href: "sensitive.html", title: "敏感信息" }
               , { href: "statistic.html", title: "统计分析" }
               , { href: "index.html", title: "舆情报告" }
               , { href: "training.html", title: "分类训练"}]
};

/* 验证用户是否登录 */
$(document).ready(function() {
    if (GetCookie("user_login") == null)
        location.href = "Login.html";
});

/* 获取名称为name的cookie值 */
function GetCookie (name) {  
    var arg = name + "=";    
    var alen = arg.length;    
    var clen = document.cookie.length;    
    var i = 0;    
    while (i < clen) {      
    var j = i + alen;      
    if (document.cookie.substring(i, j) == arg)        
            return getCookieVal (j);      
            i = document.cookie.indexOf(" ", i) + 1;      
            if (i == 0) break;     
    }    
    return null;
}

/* 取得项名称为offset的cookie值   */
function getCookieVal (offset) {      
    var endstr = document.cookie.indexOf (";", offset);    
    if (endstr == -1)  
        endstr = document.cookie.length;    
        return unescape(document.cookie.substring(offset, endstr));  
} 

