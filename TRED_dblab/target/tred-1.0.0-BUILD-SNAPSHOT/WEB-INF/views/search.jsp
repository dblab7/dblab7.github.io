<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!doctype html>
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Showcases a horizontal menu that hides at small window widths, and which scrolls when revealed.">

    <title>Search Page</title>
    <link rel="stylesheet" href="http://yui.yahooapis.com/pure/0.6.0/pure-min.css">

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
        <a href="/admin/login/" class="pure-menu-heading custom-menu-brand">관리자 페이지</a>
        <a href="#" class="custom-menu-toggle" id="toggle"><s class="bar"></s><s class="bar"></s></a>
    </div>
    <div class="pure-menu pure-menu-horizontal pure-menu-scrollable custom-menu custom-menu-bottom custom-menu-tucked" id="tuckedMenu">
        <div class="custom-menu-screen"></div>
        <ul class="pure-menu-list">
            <li class="pure-menu-item"><a href="/tred/" class="pure-menu-link">회원관리</a></li>
            <li class="pure-menu-item"><a href="/tred/" class="pure-menu-link">책 관리</a></li>
            <li class="pure-menu-item"><a href="/tred/" class="pure-menu-link">분류 관리</a></li>
            <li class="pure-menu-item"><a href="/tred/" class="pure-menu-link">대출 관리</a></li>
            <li class="pure-menu-item"><a href="/tred/" class="pure-menu-link">대출 승인</a></li>
            <li class="pure-menu-item"><a href="/tred/" class="pure-menu-link">로그아웃</a></li>
        </ul>
    </div>
  	</div>
  	
    <div class="pure-menu pure-menu-horizontal">
      <a href="#" class="pure-menu-heading">LIBRARY</a>
      <ul class="pure-menu-list">
        <li class="pure-menu-item"><a href="/main" class="pure-menu-link">홈</a></li>
        <li class="pure-menu-item"><a href="#regist" id="regist_link" class="pure-menu-link">회원가입</a></li>
        <li class="pure-menu-item"><a href="#login" id="login_link" class="pure-menu-link">로그인</a></li>
      </ul>
    </div>

    <div class="banner">
      <br/>
      <br/>
      <br/>
      <form class="pure-form" method="get">
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
    </div>

    <div class="pure-g">
    <div class="pure-u-1 pure-u-md-1-4">
    </div>
      <div class="pure-u-1 pure-u-md-18-24" id="result" style="display:yes">
        <form method="post" action="/check">
        <table width="900" class="pure-table pure-table-horizontal is-center" style="table-layout-fixed;">
          <thead>
            <tr>
              <th>idx</th>
              <th>지명</th>
              <th>이벤트 종류</th>
              <th>이벤트 발생 시간</th>
              <th>트위터 내용</th>
              <th>트위터 키워드</th>
            </tr>
          </thead>
          <c:forEach items="${list}" var="lists">
          <tr>
            <td>${list.geoLocation}</td>
            <td>${list.eventWord}</td>
            <td>${list.date}</td>
            <td>${list.text}</td>
            <td>${list.filteredText}</td>
            <td>
              <button type="submit" class="pure-button">대출신청</button>
              <input type="hidden" name="ischeck" value="1"/>
              <input type="hidden" name="b_num" value="1"/>
            </td>
          </tr>
          </c:forEach>
        </table>
      </form>
      </div>
      <div class="pure-u-1 pure-u-md-1-4">
      </div>
    </div>

    <div class="footer l-box">
      <p>
        Library
      </p>
    </div>
  </body>
</html>

