//**********************单纯的继承************************//
//function classA(name) {
//    this.name = name;
//    this.showName = function () { alert(name); }
//}

//function classB(name) {
//    this.newMethod = classA;
//    this.newMethod(name);
//}

//var obj = new classA("hero");
//var objb = new classB("classb");
//obj.showName();
//objb.showName();

//*******************call的继承**************************//
//call1
//function sayName(prefix) {  
//    alert(prefix + this.name);
//}
//var obj = new Object();
//obj.name = "jxh";
//sayName.call(obj, "hello,");//call是将obj对象的属性方法赋予sayName函数

//call2
//function classA(name) {
//    this.name = name;
//    this.showName = function () { alert(name); };
//}
//function classB(name) {
//    classA.call(this, name);
//}
//objb = new classB("蓝色蔷薇");
//objb.showName();//说明classb继承classA的showName方法

//******************apply的继承***********************//

//function sayNameApply(perfix) {
//    alert(perfix + this.name);
//}
//var objApply = new Object();
//objApply.name = "蓝色蔷薇";
//sayNameApply.apply(objApply, new Array("hello,", "hi,"));

//*****************原型链***********************

//function classA() { }
//classA.prototype.name = "蓝色蔷薇";
//classA.prototype.showName = function () { alert(this.name) }
//function classB() { }
//classB.prototype = new classA();
//objb = new classB()
//objb.showName();//print 蓝色蔷薇  说明b继承了a的方法
//***********注意：调用classA的构造函数时,没有给它传递参数,
//***********这是原型链的标准做法,确保函数的构造函数没有任何参数.
//***********并且 子类的所有属性和方法,必须出现在prototype属性被赋值后,应为在它之前赋的值会被删除.
//***********因为对象的prototype属性被替换成了新对象, 添加了新方法的原始对象将被销毁

//****************混合方式************************
function classA(name) {
    this.name = name;
}
classA.prototype.showName = function () { alert(this.name); };

function classB(name) {
    classA.call(this, name);
}
classB.prototype = new classA();
classB.prototype.showName1 = function () { alert(this.name + "classb") };
var obj = new classB("蓝色蔷薇");
obj.showName();
obj.showName1();
