package com.dblab.tred;

import java.util.Date;
import java.sql.Timestamp;

public class TweetDTO {
	private String filterText;
    private String text;
    private Timestamp date;
    private String geoLocation;
    private String eventWord;
    
    public TweetDTO(){
    	super();
    }
    
    public TweetDTO(String text, String filterText, Timestamp date,
			String geoLocation, String eventWord) {
		this.filterText = filterText;
		this.text = text;
		this.date = date;
		this.geoLocation = geoLocation;
		this.eventWord = eventWord;
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
	public Timestamp getDate() {
		return date;
	}
	public void setDate(Timestamp date) {
		this.date = date;
	}
	public void setGeoLocation(String geoLocation) {
		this.geoLocation = geoLocation;
	}
	public String getGeoLocation() {
		return geoLocation;
	}
	public void setEventWord(String eventWord) {
		this.eventWord = eventWord;
	}
	public String getEventWord() {
		return eventWord;
	}
	
    public String toString() {
    	String sb;
    	sb = text.replaceAll("\n"," ");
		sb += "#.#";			sb += date;
		sb += "#.#";			sb += geoLocation;
		sb += "#.#";			
        return sb;
    }


}
