package org.apache.lucene.analysis.kr;

import java.sql.*;

public class test {

	static Connection con;
	
	public static void main(String[] args) throws Exception {

		con = getConnection();
		ResultSet rs;
		
//		delete();	//KEYWORD ���̺� �� ������ ����
		drop();
//		rs = select("2013030922");
		
//		rs = selectTab();
		
		int cnt=0;
//		while(rs.next() && cnt<100){		
//			System.out.print(rs.getString("keyword") + "\n");
//			System.out.print(rs.getInt("Count") + "\n");
//			cnt++;
//		}	
		
//		while(rs.next()){
//			System.out.print(rs.getString(1) + "\t");
//			System.out.print(rs.getString(2) + "\n"); 	
//		}
		
		con.close();
		
//		String tableName = "2013030922";
//		AboutDB ab = new AboutDB(tableName);
		
	}

	private static ResultSet selectTab() throws SQLException {
		
		PreparedStatement prestat;
		String sql = "select * from tab";
		
		prestat = con.prepareStatement(sql);
		ResultSet rs = prestat.executeQuery();
		
		return rs;
	}

	private static ResultSet select(String tableName) throws SQLException {
	
		PreparedStatement prestat;
		String sql = "select keyword, count from t" + tableName;
	
		prestat = con.prepareStatement(sql);
		ResultSet rs = prestat.executeQuery();	//���� ����

		return rs;
	}

	public static Connection getConnection() {
		
		Connection conn = null;
		try {
			Class.forName("oracle.jdbc.driver.OracleDriver");
			conn = DriverManager.getConnection("jdbc:oracle:thin:@1.224.172.214:1521:dblab", "twitterrank", "twitterrank");
		} catch (ClassNotFoundException e) {
			System.out.println(e);
		} catch (SQLException se) {
			System.out.println(se);
		}
		return conn;
	}
	
	//Delete �޼ҵ� 
	public static void delete() throws Exception {
		
		PreparedStatement prestat;
//		String sql="delete from k2013030918";	
		String sql = "drop table k2013030921";
		prestat = con.prepareStatement(sql);	//sql���� ������
		
		int r = prestat.executeUpdate();		//���� ����

		if(r>0)
			System.out.println("KEYWORD ���̺� �� ������ ���� �Ϸ�");
		else 
			System.out.println("KEYWORD ���̺� �� ������ ���� ����");
	}
	
	public static void drop() throws SQLException {
		
		PreparedStatement prestat;
		String sql = "drop table k2013030210";
		prestat = con.prepareStatement(sql);
		
		prestat.execute();
		
		System.out.println("drop table");
	}
}
