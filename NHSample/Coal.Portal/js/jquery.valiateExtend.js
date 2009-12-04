
//让firefox支持outerHTML的方法 add by rensq on 2009-3-23
if (typeof (HTMLElement) != "undefined" && !window.opera) {
    HTMLElement.prototype.__defineGetter__("outerHTML", function() {
        var a = this.attributes, str = "<" + this.tagName, i = 0; for (; i < a.length; i++)
            if (a[i].specified)
            str += " " + a[i].name + '="' + a[i].value + '"';
        if (!this.canHaveChildren)
            return str + " />";
        return str + ">" + this.innerHTML + "</" + this.tagName + ">";
    });
    HTMLElement.prototype.__defineSetter__("outerHTML", function(s) {
        var r = this.ownerDocument.createRange();
        r.setStartBefore(this);
        var df = r.createContextualFragment(s);
        this.parentNode.replaceChild(df, this);
        return s;
    });
    HTMLElement.prototype.__defineGetter__("canHaveChildren", function() {
        return !/^(area|base|basefont|col|frame|hr|img|br|input|isindex|link|meta|param)$/.test(this.tagName.toLowerCase());
    });
} 

var _default = {
    success: function(label) {
        label.addClass("valid");
        label.text("验证通过");
    },
    errorPlacement: function(error, element) {
        if (element.is(":checkbox") || element.is(":radio")) {
            var wraper = $("#" + element[0].id.split('_')[0] + "_wraper");
            wraper.after(error[0].outerHTML);
        }
        else {
            element.after(error[0].outerHTML);
        }
    }
};

$(document).ready(function() {
    //自定义验证规则,返回值为bool ---- 验证十七位数字被逗号分隔的字符串    
    jQuery.validator.addMethod("digitalList", function(value, element) {
        return this.optional(element) || /^(\d{17},)*(\d{17}){1}$/.test(value);
    }, "请输入有效的ID列表");

    jQuery.validator.addMethod("userName", function(value, element) {
        return this.optional(element) || /^[\u0391-\uFFE5\w]+$/.test(value);
    }, "请输入有效的姓名");

    //验证科文分类号，形如00.00.00.00.00.00
    jQuery.validator.addMethod("kewenKind", function(value, element) {
        return this.optional(element) || /^(\d{2}.){5}(\d{2}){1}$/.test(value);
    }, "请输入有效的分类号");

    //验证产品串，形如333,333,333
    $.validator.addMethod("productIDs", function(value,element) 
	    {
		 return this.optional(element) || /^((\d+)[,，])*(\d+)$/.test(value);
		 },"请输入有效的产品号");

});
