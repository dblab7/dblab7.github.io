$(document).ready(function(e){
	// top button
	var top;
	top = $(".btn_top");
	top.on("click",onslidetop);
	function onslidetop(){
		$("body,html").stop();
		$("body,html").animate({scrollTop:0});
	}
	// left
	var scrt,winw;
	$(window).scroll(function(){
		//console.log($(window).scrollTop());
		scrt = $(window).scrollTop();
		if ( scrt >= 0 && scrt < 1500 ){
			$(".left.blk").fadeOut(100);
			$(".left.wht").fadeIn(200);
		}
		else if ( scrt >= 1500 && scrt < 2100 ){
			$(".left.wht").fadeOut(100);
			$(".left.blk").fadeIn(200);
		}
		else if ( scrt >= 2100 ){
			$(".left.blk").fadeOut(100);
			$(".left.wht").fadeIn(200);
		}
	})

	winw = $(window).width();
	if (winw < 1080){
		$(".left").addClass("down");
	}
	else {
		$(".left").removeClass("down");
	}
	$(window).resize(function(){
		winw = $(window).width();
		if (winw < 1080){
			$(".left").addClass("down");
		}
		else {
			$(".left").removeClass("down");
		}
	})
	$(".btn_menu").click(function(){
		var menu_w;
		if ($(window).width() > 600){
			menu_w = "80%";
		}
		else {
			menu_w = "50%";
		}
		$(window).resize(function(){
			if ($(window).width() > 600){
				menu_w = "80%";
			}
			else {
				menu_w = "50%";
			}
		})
		if ($(this).parent().attr("class") == "left wht down" ){
			$(this).parent(".left.wht").animate({"left":menu_w},300)
			$(".left.wht").addClass("open");
		}
		else if ($(this).parent().attr("class") == "left wht down open" ){
			$(this).parent(".left.wht").animate({"left":"100%"},300)
			$(".left.wht").removeClass("open");
		}
	})
});
