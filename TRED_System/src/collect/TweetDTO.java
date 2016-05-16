package collect;


import java.sql.Timestamp;
import java.util.Date;

import twitter4j.GeoLocation;

public class TweetDTO {
	private String filterText;
    private String text;
    private Date date;
    private long tweetID;
    private long userID;
    private GeoLocation geoLocation;
    private boolean rt;
    private String beginDate;
    
    public TweetDTO(){
    	super();
    }
    
    //형태소분석 포함
    public TweetDTO(String filterText, String text, Date date, long tweetID, long userID,
			GeoLocation geoLocation, boolean rt, String beginDate) {
		super();
		this.filterText = filterText;
		this.text = text;
		this.date = date;
		this.tweetID = tweetID;
		this.userID = userID;
		this.geoLocation = geoLocation;
		this.rt = rt;
		this.beginDate = beginDate;
	}
    //이벤트 탐지 입력
    public TweetDTO(String filterText, String text, Date date, GeoLocation geoLocation) {
		super();
		this.filterText = filterText;
		this.text = text;
		this.date = date;
		this.geoLocation = geoLocation;
	}
    //형태소 분석 미포
    public TweetDTO(String text, Date date, long tweetID, long userID,
			GeoLocation geoLocation, boolean rt, String beginDate) {
		super();
		this.text = text;
		this.date = date;
		this.tweetID = tweetID;
		this.userID = userID;
		this.geoLocation = geoLocation;
		this.rt = rt;
		this.beginDate = beginDate;
	}
	
    public TweetDTO(String text, Date date, GeoLocation geoLocation) {
		super();
		this.text = text;
		this.date = date;
		this.geoLocation = geoLocation;
	}
    
    public String getFilterText() {
		return filterText;
	}
    public void setFilterText(String filterText) {
		this.text = filterText;
	}
    public String getText() {
		return text;
	}
	public void setText(String text) {
		this.text = text;
	}
	public Date getDate() {
		return date;
	}
	public void setDate(Date date) {
		this.date = date;
	}
	public long getTweetID() {
		return tweetID;
	}
	public void setTweetID(long tweetID) {
		this.tweetID = tweetID;
	}
	public long getUserID() {
		return userID;
	}
	public void setUserID(long userID) {
		this.userID = userID;
	}
	public GeoLocation getGeoLocation() {
		return geoLocation;
	}
	public void setGeoLocation(GeoLocation geoLocation) {
		this.geoLocation = geoLocation;
	}
	public boolean isRt() {
		return rt;
	}
	public void setRt(boolean rt) {
		this.rt = rt;
	}
	public String getBeginDate() {
		return beginDate;
	}
	public void setBeginDate(String beginDate) {
		this.beginDate = beginDate;
	}
	
    public String toString() {
    	String sb;
    	sb = text.replaceAll("\n"," ");
		sb += "#.#";			sb += date;
		sb += "#.#";			sb += getTweetID();
		sb += "#.#";			sb += getUserID();
		sb += "#.#";			sb += geoLocation;
		sb += "#.#";			if(rt==true) sb += 1;			else sb += 0;
        return sb;
    }


}
