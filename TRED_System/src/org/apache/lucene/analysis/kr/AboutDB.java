package org.apache.lucene.analysis.kr;

import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.Date;

public class AboutDB {          //DB 계정연결
	
	static final String id ="twitterrank";
	static final String pwd ="twitterrank";
	static String db_url = "jdbc:oracle:thin:@1.224.172.214:1521:dblab";     //DB 연결
	static String db_driver = "oracle.jdbc.driver.OracleDriver";

	static Connection con;
	static PreparedStatement prestat;     //preparedStatment ===  sql 문장을 가지고 써준다. 
	String tableName;
	
	//디비 연결(생성자)
	public AboutDB(String tableName){				
		
		this.tableName = tableName;
		
		try {
			Class.forName(db_driver);		//오라클 JDBC 드라이버 로딩
			con = DriverManager.getConnection(db_url,id,pwd);	//오라클 데이타베이스 서버 접속
			
			CreateTable(tableName);
			ResultSet rs = Select(tableName);
			
			int cnt=0;
			while(rs.next() && cnt<100){		
				System.out.print(rs.getString("Noun") + "\t");
				System.out.print(rs.getInt("Count") + "\t");
				Insert(rs.getString("Noun"), rs.getInt("Count"), tableName);
				cnt++;
			}	
			
//			delete();
			
		} catch(ClassNotFoundException e) {
			e.printStackTrace();
			System.exit(0);
		} catch(SQLException e) {
			e.printStackTrace();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} finally {
			try {
				prestat.close();
				con.close();
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
		}
	}	
	
	
	//Insert 메소드
	public static void Insert(String Noun, int Count, String TableName) throws Exception {
			
		String sql = "insert into T" + TableName + " values(?, ?)";
		
		prestat = con.prepareStatement(sql);
		
		prestat.setString(1, Noun);
		prestat.setInt(2, Count);
		
		int r = prestat.executeUpdate();

		if(r>0)
			System.out.println("삽입 완료");
		else 
			System.out.println("삽입 실패");
	}
	
	
	//Delete 메소드 
	public static void delete() throws Exception {
		
		String sql="delete from KEYWORD";	
		
		prestat = con.prepareStatement(sql);	//sql쿼리 날리기
				
		int r = prestat.executeUpdate();		//쿼리 실행
		if(r>0)
			System.out.println("KEYWORD 테이블 내 데이터 삭제 완료");
		else 
			System.out.println("KEYWORD 테이블 내 데이터 삭제 실패");
	}

	
	//Sort 메소드
	public static ResultSet Select(String tableName) throws Exception {	
	
		String sql = "select noun, count from k" + tableName + " order by count desc";
		
		prestat = con.prepareStatement(sql);	//sql쿼리 날리기
		
		ResultSet rs = prestat.executeQuery();	//쿼리 실행
		
		return rs;
	}

	
	//CreateTable 메소드
	public static void CreateTable(String tableName) throws Exception {		
		
		Date gettime = new Date();
//		String TableName = new SimpleDateFormat("yyyyMMddHH").format(gettime);	//Date형태인 gettime을 스트링으로 변환
		
		String sql = "Create Table T" + tableName + " (KeyWord VarChar2(50) Primary Key, Count Number(6))";	
		
		prestat = con.prepareStatement(sql);	//sql쿼리 날리기		
		
		prestat.executeQuery();		//쿼리 실행		
		
		System.out.println(gettime + " 테이블 생성.      테이블명 : T" + tableName);
		
	}
	
	
//	public static void main(String[] args) throws Exception {
//		
//		new AboutDB();	//디비 연결
//		
//		String TableName = CreateTable();	//매시간 생성 될 테이블(테이블명 : T연월일시)
//		
//		ResultSet rs = Select();	//KEYWORD 테이블 정렬해서 추출
//		
//		int cnt=0;
//		while(rs.next() && cnt<3){		
//			System.out.print(rs.getString("Noun") + "\t");
//			System.out.print(rs.getInt("Count") + "\t");
//			AboutDB.Insert(rs.getString("Noun"), rs.getInt("Count"), TableName);
//			cnt++;
//		}		
//			
//		delete();	//KEYWORD 테이블 내 데이터 삭제
//	}	
	
}
