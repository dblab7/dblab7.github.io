package collect;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;

import org.apache.tomcat.dbcp.dbcp.BasicDataSource;


public class EventLocationDetect {		
	private static BasicDataSource ds;
	private Connection conn = null;
	
	private String geoLocation = null;
	private String beforeGeoLocation;
	private String filteredText = null;
	private String text = null;
	private Timestamp date = null;
	private String eventWord = null;
	
	private PreparedStatement stGeoLocation = null;
	private PreparedStatement stmtTF = null;
	private PreparedStatement stmtDA = null;
	private PreparedStatement stmtVT = null;
	private PreparedStatement stmtResult = null;
	
	ResultSet rsGeoLocation = null;
	ResultSet rsTF = null;
	ResultSet rsDA = null;
	ResultSet rsVT = null;
	
	public EventLocationDetect(){
			ds = new BasicDataSource(); 

			ds.setDriverClassName("org.gjt.mm.mysql.Driver");
			ds.setUrl("jdbc:mysql://localhost/tred?useUnicode=true&amp;characterEncoding=UTF-8");
			ds.setUsername("root");
			ds.setPassword("apmsetup");
			
			// Connection Pool
	        ds.setInitialSize(1);
	        ds.setMaxActive(10);    
	        ds.setMaxIdle(3);   
	        ds.setMinIdle(1);    	
	        
	        this.beforeGeoLocation = null;
	}
	
	public static Date NowDate(){
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyyMMddHH");
		Date currentTime = new Date( );
		return currentTime;
	}
	
	static long tfTerm = Main.tfTerm;
	static long dfTerm = Main.dfTerm;

	public String main(){
			try{
			//TweetDTO dto = new TweetDTO();
			
				conn = ds.getConnection();
				
				stGeoLocation = conn.prepareStatement(
						"SELECT * from event_tweet"
						+ " order by idx desc limit 1");
				rsGeoLocation = stGeoLocation.executeQuery();
				
				if(rsGeoLocation.next()){
					geoLocation = rsGeoLocation.getString("geoLocation");
					filteredText = rsGeoLocation.getString("filteredText");
					text = rsGeoLocation.getString("text");
					date = rsGeoLocation.getTimestamp("date");
					eventWord = rsGeoLocation.getString("eventWord");
					
					//System.out.println(geoLocation);	//이벤트 트윗의 마지막행 지역명
					
					stmtTF = conn.prepareStatement(
							"SELECT count(*) as cnt from tweet"
							+ " WHERE geoLocation=? AND date >= date_add(now(), interval - 40 minute)");
					stmtTF.setString(1, geoLocation);
					rsTF = stmtTF.executeQuery();
					
					stmtDA = conn.prepareStatement(
							"SELECT count(*) as cnt from tweet"
							+ " WHERE geoLocation=? AND date >= date_add(now(), interval - 2 day)");
					stmtDA.setString(1, geoLocation);
					rsDA = stmtDA.executeQuery();
					
					stmtVT = conn.prepareStatement(
							"SELECT count(distinct SUBSTRING_INDEX(filteredText, '/', 3)) as cnt from tweet"
							+ " WHERE geoLocation=? AND date >= date_add(now(), interval - 40 minute)");
					stmtVT.setString(1, geoLocation);
					rsVT = stmtVT.executeQuery();
					//System.out.println("2" + geoLocation + "//before : " + beforeGeoLocation + "//geo : " + geoLocation);
					if(rsTF.next() && rsDA.next() && rsVT.next()){
						//System.out.println("3" + geoLocation + "/" + rsTF.getDouble("cnt") + "/" + rsDA.getDouble("cnt")/72 + "/" + rsVT.getDouble("cnt"));
						
						if((rsTF.getDouble("cnt") - rsDA.getDouble("cnt")/72 >= 10) && (rsVT.getDouble("cnt") - rsDA.getDouble("cnt")/72 >= 0)){
							//System.out.println("4" + geoLocation);
							if((geoLocation.equals(beforeGeoLocation) == false ) || (beforeGeoLocation == null)){
								System.out.println(rsTF.getDouble("cnt") + "/" + rsDA.getDouble("cnt")/72 
										+ "/" + rsVT.getDouble("cnt") + "//before : " + beforeGeoLocation + "//geo : " + geoLocation);
								stmtResult = conn.prepareStatement(
										"insert into tweet_result(filteredText, text, geoLocation, date, eventWord)"
												+ " values(?, ?, ?, ?, ?)");

								
								//System.out.println(filteredText); //占쏙옙占쏙옙占쏙옙 占쏙옙占싶몌옙 트占쏙옙
								
								stmtResult.setString(1, filteredText);
								stmtResult.setString(2, text);
								stmtResult.setString(3, geoLocation);
								stmtResult.setTimestamp(4, date);
								stmtResult.setString(5, eventWord);
								stmtResult.executeUpdate();
								beforeGeoLocation = geoLocation; //占쌕뤄옙占쏙옙占쏙옙 占쌩삼옙占쏙옙 트占쏙옙 占쏙옙占쏙옙 占쏙옙占쏙옙
							}
						}
					}
				}
				
			} catch (SQLException | ArrayIndexOutOfBoundsException e) {
				e.printStackTrace();
			}finally {
				try {if (rsTF != null) rsTF.close();} catch(Exception e) {}
				try {if (stmtTF != null) stmtTF.close();} catch(Exception e) {}
				try {if (rsDA != null) rsDA.close();} catch(Exception e) {}
				try {if (stmtDA != null) stmtDA.close();} catch(Exception e) {}
				try {if (rsVT != null) rsVT.close();} catch(Exception e) {}
				try {if (stmtVT != null) stmtVT.close();} catch(Exception e) {}
				try {if (stGeoLocation != null) stGeoLocation.close();} catch(Exception e) {}
				try {if (rsGeoLocation != null) rsGeoLocation.close();} catch(Exception e) {}
				try {if (conn != null) conn.close();} catch(Exception e) {}
			}
			return beforeGeoLocation;
	}
}
		