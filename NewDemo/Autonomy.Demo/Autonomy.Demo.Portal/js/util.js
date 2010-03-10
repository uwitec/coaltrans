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
<<<<<<< .mine

var nav_data = { data: [{ href: "index.html", title: "首页"}
               , { href: "special.html", title: "舆论专题"}
               , { href: "hot.html", title: "热点分布" }
               , { href: "trend.html", title: "舆情趋势" }
               , { href: "sensitive.html", title: "敏感信息" }
               , { href: "statistic.html", title: "统计分析" }
               , { href: "statistic.html", title: "舆情报告" }
               , { href: "index.html", title: "系统设置"}]
};
=======

var nav_data = { data: [{ href: "index.html", title: "首页" }
               , { href: "special.html", title: "舆论专题" }
               , { href: "hot.html", title: "热点分布" }
               , { href: "trend.html", title: "舆情趋势" }
               , { href: "sensitive.html", title: "敏感信息" }
               , { href: "statistic.html", title: "统计分析" }
               , { href: "statistic.html", title: "舆情报告" }
               , { href: "index.html", title: "系统设置"}]
};

>>>>>>> .r83
