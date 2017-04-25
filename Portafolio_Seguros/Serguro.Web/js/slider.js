
$(document).ready(function(){
	$(".slider #1").fadeIn(2000);
  	$(".slider #1").delay(700).fadeOut(2000);
  
  	var sc = $(".slider img").length;
  	var count = 2;
  
  	setInterval(function(){
   	$(".slider #"+count).fadeIn(2000);
   	$(".slider #"+count).delay(700).fadeOut(2000);

		count = (count == sc) ? 1 : count + 1;
	},5000);
})