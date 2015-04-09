//typeof 和instanceof的使用
var d = 7.5;
alert(typeof d);//类型为number类型
alert(typeof d2);//类型为undifind
alert(typeof new Object());//类型为object
alert(typeof Object);//类型为function

var o = new String("b");
alert(o instanceof String);//返回的是true
alert(o instanceof Number);//false
alert(o instanceof Object);//true
