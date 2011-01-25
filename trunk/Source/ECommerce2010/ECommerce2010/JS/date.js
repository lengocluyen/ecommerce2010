function Rundate()
{
var now=new Date()
var hrs=now.getHours()
var min=now.getMinutes()
var sec=now.getSeconds()
var day =now.getDate();
var ngay=now.getDay();
var month = now.getMonth()+1;
var year = now.getFullYear();
var strDate = "";
var don="AM"
if (hrs>=12){ don="PM" }
if (hrs>12) { hrs-=12 }
if (hrs==0) { hrs=12 }
if (hrs<10) { hrs="0"+hrs }
if (min<10) { min="0"+min }
if (sec<10) { sec="0"+sec }
switch(ngay)
{
case 0: strDate = "Chủ Nhật, ";break;case 1:strDate = "Thứ Hai, ";break;case 2:strDate = "Thứ Ba, ";break;case 3:strDate = "Thứ Tư, ";break;case 4:strDate = "Thứ Năm, ";break;case 5:strDate = "Thứ Sáu, ";break;case 6:strDate = "Thứ Bảy, ";
}
document.getElementById('todaydate').innerHTML= strDate + day+"/"+month+"/"+year + " - " + hrs + ":" + min + ":" + sec + " " + don;
setTimeout("Rundate()",1000);
}
