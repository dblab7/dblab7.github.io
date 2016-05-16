package org.apache.lucene.analysis.kr;

import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.Date;

public class AboutDB {          //DB ��������
	
	static final String id ="twitterrank";
	static final String pwd ="twitterrank";
	static String db_url = "jdbc:oracle:thin:@1.224.172.214:1521:dblab";     //DB ����
	static String db_driver = "oracle.jdbc.driver.OracleDriver";

	static Connection con;
	static PreparedStatement prestat;     //preparedStatment ===  sql ������ ������ ���ش�. 
	String tableName;
	
	//��� ����(������)
	public AboutDB(String tableName){				
		
		this.tableName = tableName;
		
		try {
			Class.forName(db_driver);		//����Ŭ JDBC ����̹� �ε�
			con = DriverManager.getConnection(db_url,id,pwd);	//����Ŭ ����Ÿ���̽� ���� ����
			
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
	
	
	//Insert �޼ҵ�
	public static void Insert(String Noun, int Count, String TableName) throws Exception {
			
		String sql = "insert into T" + TableName + " values(?, ?)";
		
		prestat = con.prepareStatement(sql);
		
		prestat.setString(1, Noun);
		prestat.setInt(2, Count);
		
		int r = prestat.executeUpdate();

		if(r>0)
			System.out.println("���� �Ϸ�");
		else 
			System.out.println("���� ����");
	}
	
	
	//Delete �޼ҵ� 
	public static void delete() throws Exception {
		
		String sql="delete from KEYWORD";	
		
		prestat = con.prepareStatement(sql);	//sql���� ������
				
		int r = prestat.executeUpdate();		//���� ����
		if(r>0)
			System.out.println("KEYWORD ���̺� �� ������ ���� �Ϸ�");
		else 
			System.out.println("KEYWORD ���̺� �� ������ ���� ����");
	}

	
	//Sort �޼ҵ�
	public static ResultSet Select(String tableName) throws Exception {	
	
		String sql = "select noun, count from k" + tableName + " order by count desc";
		
		prestat = con.prepareStatement(sql);	//sql���� ������
		
		ResultSet rs = prestat.executeQuery();	//���� ����
		
		return rs;
	}

	
	//CreateTable �޼ҵ�
	public static void CreateTable(String tableName) throws Exception {		
		
		Date gettime = new Date();
//		String TableName = new SimpleDateFormat("yyyyMMddHH").format(gettime);	//Date������ gettime�� ��Ʈ������ ��ȯ
		
		String sql = "Create Table T" + tableName + " (KeyWord VarChar2(50) Primary Key, Count Number(6))";	
		
		prestat = con.prepareStatement(sql);	//sql���� ������		
		
		prestat.executeQuery();		//���� ����		
		
		System.out.println(gettime + " ���̺� ����.      ���̺�� : T" + tableName);
		
	}
	
	
//	public static void main(String[] args) throws Exception {
//		
//		new AboutDB();	//��� ����
//		
//		String TableName = CreateTable();	//�Žð� ���� �� ���̺�(���̺�� : T�����Ͻ�)
//		
//		ResultSet rs = Select();	//KEYWORD ���̺� �����ؼ� ����
//		
//		int cnt=0;
//		while(rs.next() && cnt<3){		
//			System.out.print(rs.getString("Noun") + "\t");
//			System.out.print(rs.getInt("Count") + "\t");
//			AboutDB.Insert(rs.getString("Noun"), rs.getInt("Count"), TableName);
//			cnt++;
//		}		
//			
//		delete();	//KEYWORD ���̺� �� ������ ����
//	}	
	
}
