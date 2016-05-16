<?xml version="1.0" encoding="UTF-8" ?>
<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!doctype html>
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="description" content="Showcases a horizontal menu that hides at small window widths, and which scrolls when revealed.">
	<meta name="viewport" content="width=device-width, inital-scale=1.0">
    <title>Search Page</title>
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
            <li class="pure-menu-item"><a href="/tred/search.do" class="pure-menu-link">이벤트 검색</a></li>
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
 
    <div style="width: 95%; margin: auto;">
      <form class="pure-form" action="search.do" method="get">
        <fieldset>
          <select id="option" name="s_option" class="pure-input-1-5">
            <option value="1">제목</option>
            <option value="2">저자</option>
            <option value="3">출판사</option>
          </select>
          <input type="text" name="s_content" class="pure-input-2-3" />
          <input type="hidden" name="s_display" value="1" />
          <button type="submit" class="pure-button pure-button-primary">Search</button>
        </fieldset>
      </form>
      <table width="100%" class="pure-table pure-table-horizontal is-center" style="table-layout-fixed;">
          <thead>
            <tr>
              <th>트위터 내용 [${content}]</th>
            </tr>
          </thead>
          <c:forEach items="${text}" var="lists">
          <tr>
            <td>${lists}</td>
          </tr>
          </c:forEach>
        </table>
    </div>
	<br>
    <div class="footer l-box">
      <p>
        Copyright ⓒ dblab <br/>
		Catholic University of Korea
      </p>
    </div>
  </body>
</html>

