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
