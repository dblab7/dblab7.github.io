<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!doctype html>
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="A layout example that shows off a responsive pricing table.">

    <title>Library Main</title>
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
    <script>
      $(document).ready(function () {
        $('#login_link').colorbox({
          inline:true,
          width:550,
        });
        $('#regist_link').colorbox({
          inline:true,
          width:550,
        });
      });
    </script>
  </head>
  <body>
  
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
        <table width="700" class="pure-table pure-table-horizontal is-center" style="table-layout-fixed;">
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
          <tr>
            <td>${list.geoLocation0}</td>
            <td>${list.eventWord0}</td>
            <td>${list.date0}</td>
            <td>${list.text0}</td>
            <td>${list.filteredText0}</td>
            <td>
              <button type="submit" class="pure-button">대출신청</button>
              <input type="hidden" name="ischeck" value="1"/>
              <input type="hidden" name="b_num" value="1"/>
            </td>
          </tr>
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

