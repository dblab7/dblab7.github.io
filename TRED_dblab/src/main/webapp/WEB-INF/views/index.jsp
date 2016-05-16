<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ page import = "java.sql.Timestamp" %>
<!doctype html>
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="description" content="Showcases a horizontal menu that hides at small window widths, and which scrolls when revealed.">
	<!--  디바이스에 최적화된 크기로 출력됨 -->
	<meta name="viewport" content="width=device-width, inital-scale=1.0">
	<!--  jquery, jquery mobile 라이브러리 사용: CDN방식 -->
	<!-- <link rel="stylesheet" href="http://code.jquery.com/mobile/1.0.1/jquery.mobile-1.0.1.min.css" /> -->
	<!-- <script src="http://code.jquery.com/jquery-1.6.4.min.js"></script> -->
	<!-- <script src="http://code.jquery.com/mobile/1.0.1/jquery.mobile-1.0.1.min.js"></script>
	 -->

    <title>TRED System</title>
    <link rel="stylesheet" href="http://yui.yahooapis.com/pure/0.6.0/pure-min.css">
	<!--[if lte IE 8]>

    <link rel="stylesheet" href="http://yui.yahooapis.com/pure/0.6.0/grids-responsive-old-ie-min.css">

    <![endif]-->
    <!--[if gt IE 8]><!-->

    <link rel="stylesheet" href="http://yui.yahooapis.com/pure/0.6.0/grids-responsive-min.css">

    <!--<![endif]-->
    <!--[if lte IE 8]>
    <link rel="stylesheet" href="css/layouts/pricing-old-ie.css">
    <![endif]-->
    <!--[if gt IE 8]><!-->
    <link rel="stylesheet" href="css/layouts/main.css">
    <!--<![endif]-->
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="jquery.colorbox.js"></script>
    <script src="js/common.js"></script>
    
    <script async defer
    	  src="https://maps.googleapis.com/maps/api/js?KEY=AIzaSyA1rbLn--5tzBKyHNWv875vqlIVV8Gi6q4&callback=initMap">
 			 //AIzaSyCMGYQw968m-CL6QR5-5EZXxQZ_uo41dLQ 평화
	   		 //AIzaSyA1rbLn--5tzBKyHNWv875vqlIVV8Gi6q4 승민
    </script>
    <script type="text/javascript">
    	
    	
    	<%
    	
    	Timestamp date = (Timestamp)request.getAttribute("currentDate"); 
    	//request.setAttribute("currentDate", dto[0].getDate());
    	
    	String localCur = null;
    	String localPre = null;
    	
    	localCur = (String)request.getAttribute("currentLocal");	//최근 지명을 Control에서 가져옴
    	//처음세션이 없을경우 예외처리 필요
    	
    	localPre = (String)session.getAttribute("local");	//세션 가져오기
    	//String dateCur = (String)request.getAttribute("currentDate");;
    	
    	System.out.println("localPre : " + localPre);
    	System.out.println("localCur : " + localCur);
    	
    	String eventCur = (String)request.getAttribute("currentEvent");;
    	String alarm;
    	
		//if(localPre.equals(localCur)==false){
		//    alarm = eventCur + "이 발생했습니다!\n" + "발생지역 : " + localCur;
		//    System.out.println(alarm);
		//}
    
		session.setAttribute("local", localCur);	//세션 저장
		
    	%>
    	
		
		
		
	    //var today = new Date();
	    //var strTime = "<H2>현재 시간은 ";
    	//strTime += today.getHours()+"시 ";
    	//strTime += today.getMinutes()+"분 "
    	//strTime += today.getSeconds()+"초. "
    	//document.write();
    	
    	//document.write(current);

    	
    	//setTimeout("location.reload()",1000);


    	
		function initMap() {
			var myLocation = new google.maps.LatLng(35.8373508, 127.8343106);
			
			var map = new google.maps.Map(document.getElementById('map'), {
				zoom:7,
				center: myLocation
			});
			
			var geocoder = new google.maps.Geocoder();
			geocodeAddress(geocoder, map);
		}
		
		function geocodeAddress(geocoder, resultsMap) {
			
			var myPosition0 = '${list.geoLocation0}';
			var myContent0 = '<div id="content">'+
	          '<div id="siteNotice">'+
	          '</div>'+
	          '<h1 id="firstHeading" class="firstHeading"> 지명 : ${list.geoLocation0} </h1>'+
	          '<div id="bodyContent">'+
	          '<p><b>이벤트 종류</b> : ${list.eventWord0} </p>' +
	          '<p><b>이벤트 발생 시간</b> : ${list.date0} </p>' +
	          '<p><b>트위터 내용</b> : ${list.text0} </p>' +
	          '<p><b>트위터 키워드</b> : ${list.filteredText0} </p>' + 
	          '</div>'+
	          '</div>';
	          
		    var myPosition1 = '${list.geoLocation1}';
			var myContent1 = '<div id="content">'+
	          '<div id="siteNotice">'+
	          '</div>'+
	          '<h1 id="firstHeading" class="firstHeading"> 지명 : ${list.geoLocation1} </h1>'+
	          '<div id="bodyContent">'+
	          '<p><b>이벤트 종류</b> : ${list.eventWord1} </p>' +
	          '<p><b>이벤트 발생 시간</b> : ${list.date1} </p>' +
	          '<p><b>트위터 내용</b> : ${list.text1} </p>' +
	          '<p><b>트위터 키워드</b> : ${list.filteredText1} </p>' + 
	          '</div>'+
	          '</div>';
	          
			var myPosition2 = '${list.geoLocation2}';
			var myContent2 = '<div id="content">'+
	          '<div id="siteNotice">'+
	          '</div>'+
	          '<h1 id="firstHeading" class="firstHeading"> 지명 : ${list.geoLocation2} </h1>'+
	          '<div id="bodyContent">'+
	          '<p><b>이벤트 종류</b> : ${list.eventWord2} </p>' +
	          '<p><b>이벤트 발생 시간</b> : ${list.date2} </p>' +
	          '<p><b>트위터 내용</b> : ${list.text2} </p>' +
	          '<p><b>트위터 키워드</b> : ${list.filteredText2} </p>' + 
	          '</div>'+
	          '</div>';
	          
			var myPosition3 = '${list.geoLocation3}';
			var myContent3 = '<div id="content">'+
	          '<div id="siteNotice">'+
	          '</div>'+
	          '<h1 id="firstHeading" class="firstHeading"> 지명 : ${list.geoLocation3} </h1>'+
	          '<div id="bodyContent">'+
	          '<p><b>이벤트 종류</b> : ${list.eventWord3} </p>' +
		      '<p><b>이벤트 발생 시간</b> : ${list.date3} </p>' +
		      '<p><b>트위터 내용</b> : ${list.text3} </p>' +
	          '<p><b>트위터 키워드</b> : ${list.filteredText3} </p>' + 
       	      '</div>'+
	          '</div>';
	    
			var myPosition4 = '${list.geoLocation4}';
			var myContent4 = '<div id="content">'+
	          '<div id="siteNotice">'+
	          '</div>'+
	          '<h1 id="firstHeading" class="firstHeading"> 지명 : ${list.geoLocation4} </h1>'+
	          '<div id="bodyContent">'+
	          '<p><b>이벤트 종류</b> : ${list.eventWord4} </p>' +
	          '<p><b>이벤트 발생 시간</b> : ${list.date4} </p>' +
	          '<p><b>트위터 내용</b> : ${list.text4} </p>' +
	          '<p><b>트위터 키워드</b> : ${list.filteredText4} </p>' + 
	          '</div>'+
	          '</div>';
	          
			var myPosition5 = '${list.geoLocation5}';
			var myContent5 = '<div id="content">'+
	          '<div id="siteNotice">'+
	          '</div>'+
	          '<h1 id="firstHeading" class="firstHeading"> 지명 : ${list.geoLocation5} </h1>'+
	          '<div id="bodyContent">'+
	          '<p><b>이벤트 종류</b> : ${list.eventWord5} </p>' +
	          '<p><b>이벤트 발생 시간</b> : ${list.date5} </p>' +
	          '<p><b>트위터 내용</b> : ${list.text5} </p>' +
	          '<p><b>트위터 키워드</b> : ${list.filteredText5} </p>' + 
	          '</div>'+
	          '</div>';
	          
			var myPosition6 = '${list.geoLocation6}';
			var myContent6 = '<div id="content">'+
	          '<div id="siteNotice">'+
	          '</div>'+
	          '<h1 id="firstHeading" class="firstHeading"> 지명 : ${list.geoLocation6} </h1>'+
	          '<div id="bodyContent">'+
	          '<p><b>이벤트 종류</b> : ${list.eventWord6} </p>' +
	          '<p><b>이벤트 발생 시간</b> : ${list.date6} </p>' +
	          '<p><b>트위터 내용</b> : ${list.text6} </p>' +
	          '<p><b>트위터 키워드</b> : ${list.filteredText6} </p>' + 
	          '</div>'+
	          '</div>';
	          
			var myPosition7 = '${list.geoLocation7}';
			var myContent7 = '<div id="content">'+
	          '<div id="siteNotice">'+
	          '</div>'+
	          '<h1 id="firstHeading" class="firstHeading"> 지명 : ${list.geoLocation7} </h1>'+
	          '<div id="bodyContent">'+
	          '<p><b>이벤트 종류</b> : ${list.eventWord7} </p>' +
	          '<p><b>이벤트 발생 시간</b> : ${list.date7} </p>' +
	          '<p><b>트위터 내용</b> : ${list.text7} </p>' +
	          '<p><b>트위터 키워드</b> : ${list.filteredText7} </p>' + 
	          '</div>'+
	          '</div>';
	          
			var myPosition8 = '${list.geoLocation8}';
			var myContent8 = '<div id="content">'+
	          '<div id="siteNotice">'+
	          '</div>'+
	          '<h1 id="firstHeading" class="firstHeading"> 지명 : ${list.geoLocation8} </h1>'+
	          '<div id="bodyContent">'+
	          '<p><b>이벤트 종류</b> : ${list.eventWord8} </p>' +
	          '<p><b>이벤트 발생 시간</b> : ${list.date8} </p>' +
	          '<p><b>트위터 내용</b> : ${list.text8} </p>' +
	          '<p><b>트위터 키워드</b> : ${list.filteredText8} </p>' + 
	          '</div>'+
	          '</div>';
	          
			var myPosition9 = '${list.geoLocation9}';
			var myContent9 = '<div id="content">'+
	          '<div id="siteNotice">'+
	          '</div>'+
	          '<h1 id="firstHeading" class="firstHeading"> 지명 : ${list.geoLocation9} </h1>'+
	          '<div id="bodyContent">'+
	          '<p><b>이벤트 종류</b> : ${list.eventWord9} </p>' +
	          '<p><b>이벤트 발생 시간</b> : ${list.date9} </p>' +
	          '<p><b>트위터 내용</b> : ${list.text9} </p>' +
	          '<p><b>트위터 키워드</b> : ${list.filteredText9} </p>' + 
	          '</div>'+
	          '</div>';
		
		
		  geocoder.geocode({'address': myPosition0}, function(results, status) {
		    if (status === google.maps.GeocoderStatus.OK) {
		      //resultsMap.setCenter(results[0].geometry.location);
		      if (results[0].geometry.location.lat != null && results[0].geometry.location.lat != "") {
		      		var marker0 = new google.maps.Marker({
				    	position: results[0].geometry.location,
				    	map: resultsMap,
				  	});
					
					var infowindow0 = new google.maps.InfoWindow({
				    	content: myContent0,
				    	//maxWidth: 70
				  	});
					
					marker0.addListener('click', function() {
				    	infowindow0.open(resultsMap, marker0);
				  	});
				}
		    } else {
		      alert('Geocode was not successful for the following reason: ' + status);
		    }
		  });
		  
		  geocoder.geocode({'address': myPosition1}, function(results, status) {
		    if (status === google.maps.GeocoderStatus.OK) {
		      if (results[0].geometry.location.lat != null && results[0].geometry.location.lat != "") {
					var marker1 = new google.maps.Marker({
				    	position: results[0].geometry.location,
				    	map: resultsMap
				  	});
				
					var infowindow1 = new google.maps.InfoWindow({
				    	content: myContent1,
				  	});
					
					marker1.addListener('click', function() {
				    	infowindow1.open(resultsMap, marker1);
				  	});
				}
		    } else {
		      alert('Geocode was not successful for the following reason: ' + status);
		    }
		  });
		
		  geocoder.geocode({'address': myPosition2}, function(results, status) {
		    if (status === google.maps.GeocoderStatus.OK) {
		      if (results[0].geometry.location.lat != null && results[0].geometry.location.lat != "") {
					var marker2 = new google.maps.Marker({
				    	position: results[0].geometry.location,
				    	map: resultsMap
				  	});
				
					var infowindow2 = new google.maps.InfoWindow({
				    	content: myContent2,
				  	});
					
					marker2.addListener('click', function() {
				    	infowindow2.open(resultsMap, marker2);
				  	});
				}
		    } else {
		      alert('Geocode was not successful for the following reason: ' + status);
		    }
		  });
		  
		  geocoder.geocode({'address': myPosition3}, function(results, status) {
		    if (status === google.maps.GeocoderStatus.OK) {
		      if (results[0].geometry.location.lat != null && results[0].geometry.location.lat != "") {
					var marker3 = new google.maps.Marker({
				    	position: results[0].geometry.location,
				    	map: resultsMap
				  	});
				
					var infowindow3 = new google.maps.InfoWindow({
				    	content: myContent3,
				  	});
					
					marker3.addListener('click', function() {
				    	infowindow3.open(resultsMap, marker3);
				  	});
				}
		    } else {
		      alert('Geocode was not successful for the following reason: ' + status);
		    }
		  });
		  
		  geocoder.geocode({'address': myPosition4}, function(results, status) {
		    if (status === google.maps.GeocoderStatus.OK) {
		      if (results[0].geometry.location.lat != null && results[0].geometry.location.lat != "") {
					var marker4 = new google.maps.Marker({
				    	position: results[0].geometry.location,
				    	map: resultsMap
				  	});
				
					var infowindow4 = new google.maps.InfoWindow({
				    	content: myContent4,
				  	});
					
					marker4.addListener('click', function() {
				    	infowindow4.open(resultsMap, marker4);
				  	});
				}
		    } else {
		      alert('Geocode was not successful for the following reason: ' + status);
		    }
		  });
		  
		  geocoder.geocode({'address': myPosition5}, function(results, status) {
		    if (status === google.maps.GeocoderStatus.OK) {
		      if (results[0].geometry.location.lat != null && results[0].geometry.location.lat != "") {
					var marker5 = new google.maps.Marker({
				    	position: results[0].geometry.location,
				    	map: resultsMap
				  	});
				
					var infowindow5 = new google.maps.InfoWindow({
				    	content: myContent5,
				  	});
					
					marker5.addListener('click', function() {
				    	infowindow5.open(resultsMap, marker5);
				  	});
				}
		    } else {
		      alert('Geocode was not successful for the following reason: ' + status);
		    }
		  });
		  
		  geocoder.geocode({'address': myPosition6}, function(results, status) {
		    if (status === google.maps.GeocoderStatus.OK) {
		      if (results[0].geometry.location.lat != null && results[0].geometry.location.lat != "") {
					var marker6 = new google.maps.Marker({
				    	position: results[0].geometry.location,
				    	map: resultsMap
				  	});
				
					var infowindow6 = new google.maps.InfoWindow({
				    	content: myContent6,
				  	});
					
					marker6.addListener('click', function() {
				    	infowindow6.open(resultsMap, marker6);
				  	});
				}
		    } else {
		      alert('Geocode was not successful for the following reason: ' + status);
		    }
		  });
		  
		  geocoder.geocode({'address': myPosition7}, function(results, status) {
		    if (status === google.maps.GeocoderStatus.OK) {
		      if (results[0].geometry.location.lat != null && results[0].geometry.location.lat != "") {
					var marker7 = new google.maps.Marker({
				    	position: results[0].geometry.location,
				    	map: resultsMap
				  	});
				
					var infowindow7 = new google.maps.InfoWindow({
				    	content: myContent7,
				  	});
					
					marker7.addListener('click', function() {
				    	infowindow7.open(resultsMap, marker7);
				  	});
				}
		    } else {
		      alert('Geocode was not successful for the following reason: ' + status);
		    }
		  });
		  
		  geocoder.geocode({'address': myPosition8}, function(results, status) {
		    if (status === google.maps.GeocoderStatus.OK) {
		      if (results[0].geometry.location.lat != null && results[0].geometry.location.lat != "") {
					var marker8 = new google.maps.Marker({
				    	position: results[0].geometry.location,
				    	map: resultsMap
				  	});
				
					var infowindow8 = new google.maps.InfoWindow({
				    	content: myContent8,
				  	});
					
					marker8.addListener('click', function() {
				    	infowindow8.open(resultsMap, marker8);
				  	});
				}
		    } else {
		      alert('Geocode was not successful for the following reason: ' + status);
		    }
		  });
		  
		  geocoder.geocode({'address': myPosition9}, function(results, status) {
		    if (status === google.maps.GeocoderStatus.OK) {
		      if (results[0].geometry.location.lat != null && results[0].geometry.location.lat != "") {
					var marker9 = new google.maps.Marker({
				    	position: results[0].geometry.location,
				    	map: resultsMap
				  	});
				
					var infowindow9 = new google.maps.InfoWindow({
				    	content: myContent9,
				  	});
					
					marker9.addListener('click', function() {
				    	infowindow9.open(resultsMap, marker9);
				  	});
				}
		    } else {
		      alert('Geocode was not successful for the following reason: ' + status);
		    }
		  });
		}
		
		function test(localPre, localCur, localEvent, localdate) {
    		if(localPre == localCur){
    			
    		}
    		else{
    			var myArr = new Array();
    		      myArr["arr"] = localEvent;
    		      myArr["arr2"] = localCur;
    		      myArr["arr3"] = localdate;
    		      showModalDialog('poptest.html', myArr, 'dialogHeight=170px; dialogWidth=280px;scroll=no; status=yes; help=no; center=yes');
    		      location.reload();
    		}
        }
		
		
		var localdate = '<%= date %>';
		var localPre = '<%= localPre %>';
		var localCur = '<%= localCur %>';
		var localEvent = '<%= eventCur %>';
		
		test(localPre, localCur, localEvent, localdate);
		
	</script>
  </head>
  
  <body>
  <style>
.custom-menu-wrapper {
    background-color: #808080;
    margin-bottom: 2.5em;
    white-space: nowrap;
    position: relative;
}

.custom-menu {
    display: inline-block;
    width: auto;
    vertical-align: middle;
    -webkit-font-smoothing: antialiased;
}

.custom-menu .pure-menu-link,
.custom-menu .pure-menu-heading {
    color: white;
}

.custom-menu .pure-menu-link:hover,
.custom-menu .pure-menu-heading:hover {
    background-color: transparent;
}

.custom-menu-top {
    position: relative;
    padding-top: .5em;
    padding-bottom: .5em;
}

.custom-menu-brand {
    display: block;
    text-align: center;
    position: relative;
}

.custom-menu-toggle {
    width: 44px;
    height: 44px;
    display: block;
    position: absolute;
    top: 3px;
    right: 0;
    display: none;
}

.custom-menu-toggle .bar {
    background-color: white;
    display: block;
    width: 20px;
    height: 2px;
    border-radius: 100px;
    position: absolute;
    top: 22px;
    right: 12px;
    -webkit-transition: all 0.5s;
    -moz-transition: all 0.5s;
    -ms-transition: all 0.5s;
    transition: all 0.5s;
}

.custom-menu-toggle .bar:first-child {
    -webkit-transform: translateY(-6px);
    -moz-transform: translateY(-6px);
    -ms-transform: translateY(-6px);
    transform: translateY(-6px);
}

.custom-menu-toggle.x .bar {
    -webkit-transform: rotate(45deg);
    -moz-transform: rotate(45deg);
    -ms-transform: rotate(45deg);
    transform: rotate(45deg);
}

.custom-menu-toggle.x .bar:first-child {
    -webkit-transform: rotate(-45deg);
    -moz-transform: rotate(-45deg);
    -ms-transform: rotate(-45deg);
    transform: rotate(-45deg);
}

.custom-menu-screen {
    background-color: rgba(0, 0, 0, 0.5);
    -webkit-transition: all 0.5s;
    -moz-transition: all 0.5s;
    -ms-transition: all 0.5s;
    transition: all 0.5s;
    height: 3em;
    width: 70em;
    position: absolute;
    top: 0;
    z-index: -1;
}

.custom-menu-tucked .custom-menu-screen {
    -webkit-transform: translateY(-44px);
    -moz-transform: translateY(-44px);
    -ms-transform: translateY(-44px);
    transform: translateY(-44px);
}

@media (max-width: 62em) {

    .custom-menu {
        display: block;
    }

    .custom-menu-toggle {
        display: block;
        display: none\9;
    }

    .custom-menu-bottom {
        position: absolute;
        width: 100%;
        border-top: 1px solid #eee;
        background-color: #808080\9;
        z-index: 100;
    }

    .custom-menu-bottom .pure-menu-link {
        opacity: 1;
        -webkit-transform: translateX(0);
        -moz-transform: translateX(0);
        -ms-transform: translateX(0);
        transform: translateX(0);
        -webkit-transition: all 0.5s;
        -moz-transition: all 0.5s;
        -ms-transition: all 0.5s;
        transition: all 0.5s;
    }

    .custom-menu-bottom.custom-menu-tucked .pure-menu-link {
        -webkit-transform: translateX(-140px);
        -moz-transform: translateX(-140px);
        -ms-transform: translateX(-140px);
        transform: translateX(-140px);
        opacity: 0;
        opacity: 1\9;
    }

    .pure-menu-horizontal.custom-menu-tucked {
        z-index: -1;
        top: 45px;
        position: absolute;
        overflow: hidden;
    }

}
</style>

	


  	<div class="custom-menu-wrapper">
    <div class="pure-menu custom-menu custom-menu-top">
        <a href="#" class="pure-menu-heading custom-menu-brand">TRED SYSTEM</a>
        <a href="#" class="custom-menu-toggle" id="toggle"><s class="bar"></s><s class="bar"></s></a>
    </div>
    <div class="pure-menu pure-menu-horizontal pure-menu-scrollable custom-menu custom-menu-bottom custom-menu-tucked" id="tuckedMenu">
        <div class="custom-menu-screen"></div>
        <ul class="pure-menu-list">
            <li class="pure-menu-item"><a href="/tred/index.do" class="pure-menu-link">실시간 이벤트 탐지</a></li>
            <li class="pure-menu-item"><a href="/tred/search.do?s_option=&s_content=&s_display=" class="pure-menu-link">이벤트 검색</a></li>
        </ul>
    </div>
  	</div>
  	<script>
	(function (window, document) {
		 document.getElementById('toggle').addEventListener('click', function (e) {
   		 document.getElementById('tuckedMenu').classList.toggle('custom-menu-tucked');
   		 document.getElementById('toggle').classList.toggle('x');
	});	
	})(this, this.document);
	</script>
    
	<div id="map" style="width: 95%; height: 450px; margin: auto;"></div>
	<!-- 
		<section data-role="page" id="mainPage">
		
			<header data-role="header" data-theme="b">
				<h1>Event Detect (${list.date9} ~ ${list.date0})</h1>
			</header>
			<div id="map" style="width: 100%; height: 900px;"></div>
			<footer data-role="footer" data-theme="a" data-position="fixed">
				<h3>	Copyright ⓒ dblab</h3> 
				<h3>Catholic University of Korea</h3>
			</footer>
		</section>
		 -->
		 <br>
    <div class="footer l-box">
      <p>
        Copyright ⓒ dblab <br/>
		Catholic University of Korea
      </p>
    </div>
  </body>
</html>

