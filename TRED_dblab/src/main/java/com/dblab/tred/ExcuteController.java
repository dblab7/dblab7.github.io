package com.dblab.tred;

import java.io.UnsupportedEncodingException;
import java.net.URLDecoder;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.text.DateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;

/**
 * Handles requests for the application home page.
 */
@Controller
public class ExcuteController {
	
	private static final Logger logger = LoggerFactory.getLogger(ExcuteController.class);
	
	/**
	 * Simply selects the home view to render by returning its name.
	 * @throws SQLException 
	 * @throws ClassNotFoundException 
	 */
	@RequestMapping(value = "/index.do", method = RequestMethod.GET)
	public String home(Locale locale, Model model, HttpServletRequest request,
			HttpServletResponse response) throws ClassNotFoundException, SQLException{
		
		logger.info("Welcome home! The client locale is {}.", locale);
		
		Date date = new Date();
		DateFormat dateFormat = DateFormat.getDateTimeInstance(DateFormat.LONG, DateFormat.LONG, locale);
		
		String formattedDate = dateFormat.format(date);
		
		model.addAttribute("serverTime", formattedDate );
		
		
		ConnectDB getTweet = new ConnectDB();
		TweetDTO[] dto = getTweet.getSQL();
		
		
		System.out.println("1" + dto[0].getFilterText());
		System.out.println("2" + dto[1].getFilterText());
		System.out.println("3" + dto[2].getFilterText());
		System.out.println("4" + dto[3].getFilterText());
		System.out.println("5" + dto[4].getFilterText());
		System.out.println("6" + dto[5].getFilterText());
		System.out.println("7" + dto[6].getFilterText());
		System.out.println("8" + dto[7].getFilterText());
		System.out.println("9" + dto[8].getFilterText());
		System.out.println("10" + dto[9].getFilterText());
		
		Map<String, Object> resultList = model.asMap();

		for( int i = 0; i <10 ; i++){
			//text에 ''가 들어갈경우 오류 발생
			resultList.put("text"+i, dto[i].getText().replaceAll("\n"," ").replaceAll("'", "_"));
			resultList.put("filteredText"+i, dto[i].getFilterText().replaceAll("'", "_"));
			resultList.put("date"+i, dto[i].getDate());
			resultList.put("geoLocation"+i, dto[i].getGeoLocation());
			resultList.put("eventWord"+i, dto[i].getEventWord());
		}
		model.addAttribute("list", resultList);
		
		request.setAttribute("currentLocal", dto[0].getGeoLocation());
		request.setAttribute("currentEvent", dto[0].getEventWord());
		request.setAttribute("currentDate", dto[0].getDate());
		
		
		return "index";
	}
	
	/*
	@RequestMapping(value = "/search.do")
	public String search(Locale locale, Model model) throws ClassNotFoundException, SQLException{
		ConnectDB getTweet = new ConnectDB();
		TweetDTO[] dto = getTweet.getSQL();
		
		Map<String, Object> resultList = model.asMap();
		ArrayList<String> text = new ArrayList<String>();
		ArrayList<String> filteredText = new ArrayList<String>();
		ArrayList<Timestamp> date = new ArrayList<Timestamp>();
		ArrayList<String> geoLocation = new ArrayList<String>();
		ArrayList<String> eventWord = new ArrayList<String>();
		
		for( int i = 0; i <15 ; i++){
			//text에 ''가 들어갈경우 오류 발생
			text.add(dto[i].getText().replaceAll("\n"," ").replaceAll("'", "_"));
			filteredText.add(dto[i].getFilterText().replaceAll("'", "_"));
			date.add(dto[i].getDate());
			geoLocation.add(dto[i].getGeoLocation());
			eventWord.add(dto[i].getEventWord());
		}
		resultList.put("geoLocation", geoLocation);
		resultList.put("eventWord", eventWord);
		resultList.put("date", date);
		resultList.put("text", text);
		resultList.put("filteredText", filteredText);
		
		model.addAttribute("geoLocation", geoLocation);
		model.addAttribute("eventWord", eventWord);
		model.addAttribute("date", date);
		model.addAttribute("text", text);
		model.addAttribute("filteredText", filteredText);
		model.addAttribute("list", resultList);

		return "search";
	}
	*/
	

	@RequestMapping(value = "/search.do", method = RequestMethod.GET)
	public String searchPage(HttpServletRequest request, Locale locale, Model model, @RequestParam("s_option") String option, @RequestParam(value="s_content", required=false) String pre_content) throws ClassNotFoundException, SQLException, UnsupportedEncodingException{
		
		//request.setCharacterEncoding("utf-8");
		byte[] in = pre_content.getBytes("iso-8859-1");
		String content = new String(in,"UTF-8");
		
		//System.out.println("s_option = " + option);
		System.out.println("1.s_content = " + content);
		ConnectDB getTweet = new ConnectDB();
		TweetDTO[] dto = getTweet.getSearchedSQL(content);
		TweetDTO[] filterDto = null;
		
		int row = dto.length;
		
		Map<String, Object> resultList = model.asMap();
		ArrayList<String> text = new ArrayList<String>();
		ArrayList<String> filteredText = new ArrayList<String>();
		ArrayList<Timestamp> date = new ArrayList<Timestamp>();
		ArrayList<String> geoLocation = new ArrayList<String>();
		ArrayList<String> eventWord = new ArrayList<String>();
		
		/*
		String[] geoArray = new String[row];
		
		for(int j=0; j<geoArray.length; j++)
			geoArray[j] = new String();
		int filterCount=0;
		int count = 20;
		while(count>0){//?
			if(filterCount==0){	
				filterDto[filterCount] = dto[filterCount];
				System.out.println("first: "+filterDto[filterCount]);
				geoArray[filterCount] = dto[filterCount].getGeoLocation();
				filterCount++;
			}
			else{	
				Boolean flag = true;	
				for(int k=0; k<filterCount; k++){
					String s1 = dto[filterCount].getGeoLocation();
					String s2 = geoArray[k];
					if(s1.equals(s2)){
						flag = false;
					}
				}
				if(flag){
					filterDto[filterCount] = dto[filterCount];
					geoArray[filterCount] = dto[filterCount].getGeoLocation();
					//System.out.println(dto[i].getFilterText());
					//System.out.println(dto[i].getEventWord());
					//System.out.println(dto[i].getGeoLocation());
					//System.out.println(dto[i].getDate());
					//System.out.println(dto[i].getText());
					filterCount++;
					//if(rs.getString(3).indexOf("�뿰湲�") < 0){
					//out.println(rs.getInt(1) + "|");
					//out.println(rs.getString(2) + "|");
					//out.println(rs.getString(3) + "|");
					//out.println(rs.getString(4) + "<br/>");
					//}
				}	
			}
			count --;
		}
		
		*/
		
		
		for( int i = 0; i <row ; i++){
			//text에 ''가 들어갈경우 오류 발생
			text.add(dto[i].getText().replaceAll("\n"," ").replaceAll("'", "_"));
			filteredText.add(dto[i].getFilterText().replaceAll("'", "_"));
			date.add(dto[i].getDate());
			geoLocation.add(dto[i].getGeoLocation());
			eventWord.add(dto[i].getEventWord());
		}
		resultList.put("geoLocation", geoLocation);
		resultList.put("eventWord", eventWord);
		resultList.put("date", date);
		resultList.put("text", text);
		resultList.put("filteredText", filteredText);
		
		model.addAttribute("geoLocation", geoLocation);
		model.addAttribute("eventWord", eventWord);
		model.addAttribute("date", date);
		model.addAttribute("text", text);
		model.addAttribute("filteredText", filteredText);
		model.addAttribute("list", resultList);
		model.addAttribute("content", content);
		return "search";
	}
	/*
	@RequestMapping(value = "/search.jsp", method = RequestMethod.POST)
	public String searchButton(@RequestParam Map<String, Object> paramMap, Locale locale, Model model) throws ClassNotFoundException, SQLException{
		
		//System.out.println("s_content = " + paramMap.get("s_option"));
		//System.out.println("s_content = " + paramMap.get("s_content"));
		
		//int s_option = (Integer) paramMap.get("s_option");
		String s_content = (String) paramMap.get("s_option");
		
		
		ConnectDB getTweet = new ConnectDB();
		TweetDTO[] dto = getTweet.getSearchedSQL(s_content);
		
		
		//System.out.println("1" + dto[0].getFilterText());
		//System.out.println("2" + dto[1].getFilterText());
		//System.out.println("3" + dto[2].getFilterText());
		//System.out.println("4" + dto[3].getFilterText());
		//System.out.println("5" + dto[4].getFilterText());
		//System.out.println("6" + dto[5].getFilterText());
		//System.out.println("7" + dto[6].getFilterText());
		//System.out.println("8" + dto[7].getFilterText());
		//System.out.println("9" + dto[8].getFilterText());
		//System.out.println("10" + dto[9].getFilterText());
		
		
		Map<String, Object> resultList = model.asMap();
		ArrayList<String> text = new ArrayList<String>();
		ArrayList<String> filteredText = new ArrayList<String>();
		ArrayList<Timestamp> date = new ArrayList<Timestamp>();
		ArrayList<String> geoLocation = new ArrayList<String>();
		ArrayList<String> eventWord = new ArrayList<String>();
		
		for( int i = 0; i <15 ; i++){
			//text에 ''가 들어갈경우 오류 발생
			text.add(dto[i].getText().replaceAll("\n"," ").replaceAll("'", "_"));
			filteredText.add(dto[i].getFilterText().replaceAll("'", "_"));
			date.add(dto[i].getDate());
			geoLocation.add(dto[i].getGeoLocation());
			eventWord.add(dto[i].getEventWord());
		}
		resultList.put("geoLocation", geoLocation);
		resultList.put("eventWord", eventWord);
		resultList.put("date", date);
		resultList.put("text", text);
		resultList.put("filteredText", filteredText);
		
		model.addAttribute("geoLocation", geoLocation);
		model.addAttribute("eventWord", eventWord);
		model.addAttribute("date", date);
		model.addAttribute("text", text);
		model.addAttribute("filteredText", filteredText);
		model.addAttribute("list", resultList);
		model.addAttribute("test", "ㅎㅎㅎㄴㅇㅎㄶㅇ");

		return "search.jsp";
	}
	*/
}
