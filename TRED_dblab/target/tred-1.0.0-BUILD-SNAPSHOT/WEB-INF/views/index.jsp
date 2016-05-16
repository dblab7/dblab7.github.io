<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<!--  디바이스에 최적화된 크기로 출력됨 -->
	<meta name="viewport" content="width=device-width, inital-scale=1.0">
	<!--  jquery, jquery mobile 라이브러리 사용: CDN방식 -->
	<link rel="stylesheet" href="http://code.jquery.com/mobile/1.0.1/jquery.mobile-1.0.1.min.css" />
	<script src="http://code.jquery.com/jquery-1.6.4.min.js"></script>
	<script src="http://code.jquery.com/mobile/1.0.1/jquery.mobile-1.0.1.min.js"></script>
 <script async defer
      src="https://maps.googleapis.com/maps/api/js?KEY=AIzaSyA1rbLn--5tzBKyHNWv875vqlIVV8Gi6q4&callback=initMap">
 //AIzaSyCMGYQw968m-CL6QR5-5EZXxQZ_uo41dLQ 평화
 //AIzaSyA1rbLn--5tzBKyHNWv875vqlIVV8Gi6q4 승민
    </script>
	<script type="text/javascript">
		
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
		
	</script>
	<title>TRED System</title>
</head>

<body>
	<form action="home">
		<section data-role="page" id="mainPage">
			<header data-role="header" data-theme="b">
				<!-- 헤더 타이틀 -->
				<h1>Event Detect (${list.date9} ~ ${list.date0})<!-- <a data-role="button">--><!-- </a>--></h1>
			</header>
			
			<div id="map" style="width: 100%; height: 900px;"></div>
			
			<footer data-role="footer" data-theme="a" data-position="fixed">
				<h3>	Copyright ⓒ dblab</h3>
				<input data-role="button" data-inline="true" type="button" value="검색" onClick="location.replace('/tred/')"> 
				<h3>Catholic University of Korea</h3>
			</footer>
		</section>
	</form>
</body>
</html>