//一个完整的实例
//定义一个javascript类
function JsClass(privateParam/* */, publicParam) {
    var priMember = privateParam;//私有变量
    this.pubMember = publicParam;//公共变量
    function priMethod() {
        return "priMethod()";
    }
    //定义特权方法
    this.privilegedMethod = function () {
        var str = "这是特权方法，进行调用\n";
        str += "私有变量：" + priMember + "\n";
        str += "私有方法：" + priMethod() + "\n";
        str += "公共变量：" + this.pubMember + "\n";
        str += "公共方法：" + this.pubMethod() + "\n";
        str += "临时变量：" + this.tempParam;
        return str;
    }
}
//添加公共方法,此处不能调用私有变量和方法
JsClass.prototype.pubMethod = function () { return "pubMethod()"; };
JsClass.prototype.tempParam = "tempParam";

//实例
var jsObj = new JsClass("privateMember", "publicMember");
alert(jsObj.privilegedMethod());