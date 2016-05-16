package com.dblab.tred;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Date;

class ConnectDB {
	Connection conn;
	
	public ConnectDB() throws ClassNotFoundException, SQLException{
			Class.forName("com.mysql.jdbc.Driver");	
			this.conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/tred", "root", "apmsetup");
	}
	
	public TweetDTO[] getSQL() throws SQLException, ClassNotFoundException{
		Statement stmt = conn.createStatement();
		TweetDTO[] dto = new TweetDTO[20];
		ResultSet rs = stmt.executeQuery("select idx, filteredText, text, date, geoLocation, eventWord from tweet_result order by idx desc limit 0, 1000");
		
		//ResultSet rs = stmt.executeQuery("select distinct geoLocation from tweet_result order by idx desc limit 0, 10");
		//ResultSet rs = stmt.executeQuery("select a.* from (select distinct geoLocation from tweet_result order by idx desc limit 0, 10) b join tweet_result a on b.geoLocation = a.geoLocation");
		int i=0;
		String[] geoArray = new String[20];
		
		for(int j=0; j<geoArray.length; j++)
			geoArray[j] = new String();
		
		while(rs.next()){
			if(i==0){	
				dto[i] = new TweetDTO(rs.getString("text"), rs.getString("filteredText"), rs.getTimestamp("date"), rs.getString("geoLocation"), rs.getString("eventWord"));
				geoArray[i] = rs.getString("geoLocation");
				i++;
			}
			else{	
				Boolean flag = true;	
				for(int k=0; k<i; k++){
					String s1 = rs.getString("geoLocation");
					String s2 = geoArray[k];
					if(s1.equals(s2)){
						flag = false;
					}
				}
				if(flag){
					dto[i] = new TweetDTO(rs.getString("text"), rs.getString("filteredText"), rs.getTimestamp("date"), rs.getString("geoLocation"), rs.getString("eventWord"));
					geoArray[i] = rs.getString("geoLocation");
					//System.out.println(dto[i].getFilterText());
					//System.out.println(dto[i].getEventWord());
					//System.out.println(dto[i].getGeoLocation());
					//System.out.println(dto[i].getDate());
					//System.out.println(dto[i].getText());
					i++;
					//if(rs.getString(3).indexOf("�뿰湲�") < 0){
					//out.println(rs.getInt(1) + "|");
					//out.println(rs.getString(2) + "|");
					//out.println(rs.getString(3) + "|");
					//out.println(rs.getString(4) + "<br/>");
					//}
				}	
			}
			if(i==20) break;
		}
		
		System.out.println(geoArray[0] + geoArray[1] + geoArray[2] + geoArray[3] + geoArray[4] + geoArray[5] + geoArray[6] + geoArray[7] + geoArray[8] + geoArray[9]);
		rs.close();
		stmt.close();
		conn.close();
		
		return dto;
	}
	
	public int getRows(ResultSet res){
	    int totalRows = 0;
	    try {
	        res.last();
	        totalRows = res.getRow();
	        res.beforeFirst();
	    } 
	    catch(Exception ex)  {
	        return 0;
	    }
	    return totalRows ;    
	}
	
	public TweetDTO[] getSearchedSQL(String s_content) throws SQLException, ClassNotFoundException{
		s_content = s_content
				.replace("!", "!!")
				.replace("%", "%%")
				.replace("_", "!_")
				.replace("[", "![");
		
		PreparedStatement stmt = conn.prepareStatement("select idx, filteredText, text, date, geoLocation, eventWord from tweet_result where text like ? order by idx desc limit 0, 10000");
		stmt.setString(1, "%" + s_content + "%");
		//System.out.println("s_option = " + option);
		System.out.println("2.s_content = " + s_content);
		ResultSet rs = stmt.executeQuery();
		
		
		
		int row = 0;
		if(getRows(rs) > 15)
			row = 15;
		else
			row = getRows(rs);
		
		System.out.println("1: "+row);
		
		//ResultSet rs = null;
		TweetDTO[] dto = new TweetDTO[row];
		
		int i = 0;
		while(rs.next()){
			dto[i] = new TweetDTO(rs.getString("text"), rs.getString("filteredText"), rs.getTimestamp("date"), rs.getString("geoLocation"), rs.getString("eventWord"));
			i++;
			if(i==row)	break;
		}
		/*
		int i=0;
		String[] geoArray = new String[row];
		
		for(int j=0; j<geoArray.length; j++)
			geoArray[j] = new String();
		
		while(rs.next()){
			if(i==0){	
				dto[i] = new TweetDTO(rs.getString("text"), rs.getString("filteredText"), rs.getTimestamp("date"), rs.getString("geoLocation"), rs.getString("eventWord"));
				geoArray[i] = rs.getString("geoLocation");
				i++;
			}
			else{	
				Boolean flag = true;	
				for(int k=0; k<i; k++){
					String s1 = rs.getString("geoLocation");
					String s2 = geoArray[k];
					if(s1.equals(s2)){
						flag = false;
					}
				}
				if(flag){
					dto[i] = new TweetDTO(rs.getString("text"), rs.getString("filteredText"), rs.getTimestamp("date"), rs.getString("geoLocation"), rs.getString("eventWord"));
					geoArray[i] = rs.getString("geoLocation");
					//System.out.println(dto[i].getFilterText());
					//System.out.println(dto[i].getEventWord());
					//System.out.println(dto[i].getGeoLocation());
					//System.out.println(dto[i].getDate());
					//System.out.println(dto[i].getText());
					i++;
					//if(rs.getString(3).indexOf("�뿰湲�") < 0){
					//out.println(rs.getInt(1) + "|");
					//out.println(rs.getString(2) + "|");
					//out.println(rs.getString(3) + "|");
					//out.println(rs.getString(4) + "<br/>");
					//}
				}	
			}
			if(i==row) {
				break;
			}
		}
		*/
		
		//System.out.println(geoArray[0] + geoArray[1] + geoArray[2] + geoArray[3] + geoArray[4] + geoArray[5] + geoArray[6] + geoArray[7] + geoArray[8] + geoArray[9]);
		rs.close();
		stmt.close();
		conn.close();
		
		return dto;
	}
}
