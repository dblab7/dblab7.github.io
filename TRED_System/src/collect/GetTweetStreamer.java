package collect;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.apache.tomcat.dbcp.dbcp.BasicDataSource;

import twitter4j.Status;
import twitter4j.FilterQuery;
import twitter4j.GeoLocation;
import twitter4j.StallWarning;
import twitter4j.StatusDeletionNotice;
import twitter4j.StatusListener;
import twitter4j.TwitterStream;
import twitter4j.TwitterStreamFactory;
import twitter4j.conf.ConfigurationBuilder;

public class GetTweetStreamer{
	private static BasicDataSource ds;
	static String beginDate = NowDate();
	static String currentDate = null;

	public static String NowDate(){
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyyMMddHH");
		Date currentTime = new Date( );
		String dTime = dateFormat.format ( currentTime );
		return dTime;
	}

	public static void recordTweet(String text, Date date, long tweetId, long userId, GeoLocation geoLocation, boolean rt, String beginDate){
		TweetDTO dto = new TweetDTO(text, date, tweetId, userId, geoLocation, rt, beginDate);
		TweetDAO dao = new TweetDAO();
		dao.updateTweet(dto);
		//EventLocationDetect.main();
	}
	
	private static String[] readKeyword(String keywordFileName){
		String keywordset[] = new String[140];
		int count = 0;
		String keyword = null;
		try{
			FileReader fr = new FileReader(keywordFileName);
			BufferedReader br = new BufferedReader(fr);
			
			while((keyword = br.readLine())!=null){
				keywordset[count++] = keyword;
				System.out.println(keyword);
			}
			fr.close();
			}catch(Exception e){
				System.out.println(e);
		}return keywordset;
	}
	
	public static void main(){
		StatusListener listener = new StatusListener(){
			public void onException(Exception arg0) {
				// TODO Auto-generated method stub	
			}
			public void onDeletionNotice(StatusDeletionNotice arg0) {
				// TODO Auto-generated method stub
			}
			public void onScrubGeo(long arg0, long arg1) {
				// TODO Auto-generated method stub				
			}

			public void onStatus(Status status){
				currentDate = NowDate();
				if(Integer.parseInt(currentDate)>Integer.parseInt(beginDate)){
					beginDate = currentDate;
					try {
						Thread.sleep(1000*10);						
					} catch (Exception e) {
						// TODO: handle exception
						System.out.println(e);
					}
				}
			
					recordTweet(status.getText(), status.getCreatedAt(), status.getId(), status.getUser().getId(), status.getGeoLocation(), status.isRetweet(), beginDate);

			}
			public void onTrackLimitationNotice(int arg0){
				
			}
//			@SuppressWarnings("unused")
			public void onStallWarning(StallWarning arg0) {
				// TODO Auto-generated method stub	
			}			
		};
		
		ConfigurationBuilder cb = new ConfigurationBuilder();
		cb.setDebugEnabled(true)
		.setOAuthConsumerKey("rLftGEuZibthzKPkg0MRZYTRw")		//simter424
		.setOAuthConsumerSecret("6Kw1RWoMGbb4CFhqiiGWRxzazXW1pURVRnvwzLiwKLjAkIQFFo")
		.setOAuthAccessToken("2846442193-iRotDqRJeid96Jt1o1CHMNwOomXh2ofxJbxZtXu")
		.setOAuthAccessTokenSecret("bZ5GaRgBUrrdvnDeZchHYIXOFmB13UvCEkdSFJFZyARNA");

		TwitterStreamFactory tf = new TwitterStreamFactory(cb.build());
		TwitterStream twitterStream = tf.getInstance();
		
		

//		Configuration configuration = builder.setUser("dblab01").setPassword("dasol424").build();
//		TwitterStream twitterStream = new TwitterStreamFactory(configuration).getInstance();
		twitterStream.addListener(listener);
		FilterQuery filterQuery = new FilterQuery();
		filterQuery.track(readKeyword("keyword.txt"));
		twitterStream.filter(filterQuery);
	}
}