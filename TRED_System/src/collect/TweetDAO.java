package collect;


import java.sql.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.apache.tomcat.dbcp.dbcp.BasicDataSource;


public class TweetDAO {
	private static BasicDataSource ds;
	
	public TweetDAO(){
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
	}
	
	public static Date NowDate(){
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyyMMddHH");
		Date currentTime = new Date( );
		return currentTime;
	}
	
	public void updateTweet(TweetDTO getTweet){
		Connection conn = null;
		PreparedStatement stmt = null;
		//EventLocationDetect event = new EventLocationDetect();
		try{
			TweetDTO dto = getTweet;
			String tweet = String.valueOf(dto);	
			String eventFilteredTweet = EventFilter.main(tweet);
			String analyzed = TweetMorphAnalyzer.main(tweet);
			String filteredTweet = LocationFilter.main(analyzed);
			String[] geoLocation = filteredTweet.split("/");
			
			if(filteredTweet.charAt(0) != '/') {
				conn = ds.getConnection();

				stmt = conn.prepareStatement(
						"insert into tweet(filteredText, text, geoLocation, date)"
								+ " values(?, ?, ?, now())");
		
			
				System.out.println(filteredTweet); //占쏙옙占쏙옙占쏙옙 占쏙옙占싶몌옙 트占쏙옙
				
				stmt.setString(1, filteredTweet);
				stmt.setString(2, dto.getText());
				stmt.setString(3, geoLocation[0]);
				stmt.executeUpdate();
				
			//EventLocationDetect.main(geoLocation[0]);
			}
				
			
			if(eventFilteredTweet!=null) { //占싱븝옙트 키占쏙옙占썲가 占쏙옙占쏙옙占쏙옙 占쏙옙占�
				stmt = conn.prepareStatement(
						"insert into event_tweet(filteredText, text, geoLocation, date, eventWord)"
								+ " values(?, ?, ?, now(), ?)");
				stmt.setString(1, filteredTweet);
				stmt.setString(2, dto.getText());
				stmt.setString(3, geoLocation[0]);
				stmt.setString(4, eventFilteredTweet);
				stmt.executeUpdate();
			}
		} catch (SQLException | ArrayIndexOutOfBoundsException e) {
			e.printStackTrace();
		} catch (ParseException e) {
			// TODO 占쌘듸옙 占쏙옙占쏙옙占쏙옙 catch 占쏙옙占�
			e.printStackTrace();
		}finally {
			try {if (stmt != null) stmt.close();} catch(Exception e) {}
			try {if (conn != null) conn.close();} catch(Exception e) {}
		}
	}
}
/*
public TweetDTO loginCheck (String id, String pwd) throws SQLException{
	Connection conn = null;
	PreparedStatement stmt = null;
	ResultSet rs = null;
	TweetDTO dto = null;
	try{
	conn = ds.getConnection();
	stmt = conn.prepareStatement(
			"SELECT id, passwd from user"
			+ " WHERE ID=? AND PASSWD=password(?)");
	stmt.setString(1, id);
	stmt.setString(2, pwd);
		
	rs = stmt.executeQuery();
	
	if(rs.next()){
		dto = new TweetDTO(rs.getString("id"), rs.getString("passwd"));
    }
	}finally{
        if(rs!=null) rs.close();
        if(stmt!=null) stmt.close();
        if(conn!=null) conn.close();
    }
	return dto;
}
*/

/*
public void updateTweet1(TweetDTO getTweet){
	Connection conn = null;
	PreparedStatement stmt = null;
	TweetDTO dto = l;
	
	try{
	conn = ds.getConnection();

	stmt = conn.prepareStatement(
			"insert into user(id, name, passwd, mail)"
			+ " values(?, ?, password(?), ?)");
	stmt.setString(1, id);
	stmt.setString(2, name);
	stmt.setString(3, passwd);
	stmt.setString(4, mail);
	stmt.executeUpdate();
	} catch (SQLException e) {
		e.printStackTrace();
	}
}
}
*/