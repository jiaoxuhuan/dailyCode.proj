// 内部函数可以访问外部函数的变量，这个就是闭包，如下实例
//简单定义一个函数A，它的内部函数B可以访问A内定义的变量，即使A函数已经终止
//window.onload = function () {
//    var i = 1;
//    window.onunload = function () {
//        alert(i);
//    }
//}

var name = 'jiaoxuhuan';
function echo() {
    alert(name);
    var name = 'lanse';
    alert(name);
    alert(age);
}
//arguments表示任意参数，可变参数
function sum() {
    var s = 0;
    alert(arguments.length);
    for (i = 0; i < arguments.length; i++) {
        s += arguments[i];
    }
    alert("参数之和为：" + s);
}
//动态函数:最后的参数必须是这个动态函数的功能程序代码。
var dynamicFun = new Function("var total=0;for(var i=0;i<arguments.length;i++){total+=arguments[i]};alert(\"参数之和：\"+total)");


var b1 = { v: "this is b1" };
var b2 = { v: "this is b2" };
function b(d) {
    alert(this.v);
}
b();//输出
//可以使用call及apply来动态改变函数执行的作用域
window.b();//输出
b.call(b1);//输出
b.apply(b2);//输出 