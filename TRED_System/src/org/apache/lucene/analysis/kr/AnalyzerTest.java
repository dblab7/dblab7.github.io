package org.apache.lucene.analysis.kr;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.StringReader;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.apache.lucene.analysis.TokenStream;
import org.apache.lucene.analysis.kr.morph.AnalysisOutput;
import org.apache.lucene.analysis.kr.morph.MorphAnalyzer;
import org.apache.lucene.analysis.kr.morph.MorphException;
import org.apache.lucene.analysis.tokenattributes.OffsetAttribute;
import org.apache.lucene.analysis.tokenattributes.PositionIncrementAttribute;
import org.apache.lucene.analysis.tokenattributes.TermAttribute;
import org.apache.lucene.util.Version;


public class AnalyzerTest {
	
	static Connection con;
	static String fileName = "";
	static int count_empty = 0;
	static int count_db = 0;
	static BufferedWriter error;
	
	static AboutDB db;
	
	public static void main(String[] args) throws Exception {
		
		System.out.println("start ******************");
		
		long time = System.currentTimeMillis();
		String initSource = null;
		String source = null;
		int recusive = Integer.parseInt(args[1]);
		
		SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHH");
		fileName = sdf.format(new Date(time));
		fileName = "2013031201";
		fileName = args[0];
		
		long fileTime = sdf.parse(fileName).getTime();
		System.out.println(fileTime);
		System.out.println(sdf.format(new Date(fileTime)));
		
		for(int re=0; re<recusive; re++){

			fileName = sdf.format(new Date(fileTime));
			
			con = getConnection();
				
			CreateTable(fileName);
			BufferedReader br = new BufferedReader(new FileReader(fileName+".txt"));
			
			while((source=br.readLine())!=null){
				try {
					initSource = source.split("#.#")[0];
					System.out.println("text : " + initSource);
					source = textProcessing(initSource);
					System.out.println("source_final = "+ source);
					
					testMorphAnalyzer(testKoreanAnalyzer(source));
		
				} catch (Exception e) {
					error = new BufferedWriter(new FileWriter("IndexError.txt",true));
					System.out.println(e);
					System.out.println("StringIndexError");
					error.write(fileName+ "///" + "error: " + e +"///");
					error.write(initSource+"\n");
					error.close();
				}
			} // end-while

			System.out.println("count_empty = " + count_empty);
			System.out.println("count_db = " + count_db);
			System.out.println("Perfomance Time is "+(System.currentTimeMillis()-time)+"ms");
				
			fileTime = fileTime + 60*60*1000;
			System.out.println(fileTime);
			System.out.println(sdf.format(new Date(fileTime)));

		} // end-for
	}
	
	private static String textProcessing(String source) {
		
		if(source.contains("RT ")){
			source = source.replaceAll("RT ", "");
		}
		if(source.contains("(")){
			source = source.replaceAll("\\(", "");
		}
		if(source.contains(")")){
			source = source.replaceAll("\\)", "");
		}
		//			if(source.contains(".")){
		//				source = source.replaceAll("\\.", "");
		//			}
		if(source.contains("]")){
			source = source.replaceAll("\\]", "");
		}
		if(source.contains("[")){
			source = source.replaceAll("\\[", "");
		}
		if(source.contains("?")){
			source =  source.replaceAll("\\?", "");
		}
		if(source.contains("*")){
			source = source.replaceAll("\\*", "");
		}
		if(source.contains("&")){
			source = source.replaceAll("\\&", "");
		}
		if(source.contains("@")){
			String[] words_m = null;
			words_m = source.split(" ");
			//				if(words_m.length!=0){
			for(int i=0; i<words_m.length; i++){
				if((words_m[i]).startsWith("@")){
					if(words_m[i].contains(":")){
						source = source.replaceAll(words_m[i].split(":")[0], "");
					}
					else {
						source = source.replaceAll(words_m[i], "");
					}
				}
			}
			//				}
		}
		if(source.contains("http:") || source.contains("https:")){
			String[] words_u = null;
			words_u = source.split(" ");
			for(int j=0; j<words_u.length; j++){
				if(words_u[j].startsWith("http:")){
					source = source.replaceAll(words_u[j], "");
				} 
				else if(words_u[j].startsWith("https:")){
					source = source.replaceAll(words_u[j], "");
				}
			}
		}
		return source;
	}

//	public static List<String> testKoreanAnalyzer(String source) throws SQLException{
	public static List<String> testKoreanAnalyzer(String source) throws SQLException, ArrayIndexOutOfBoundsException {	
		
		long start = System.currentTimeMillis();
		System.out.println("testKoreanAnalyzer()["+source+"] start!!");

		List<String> inputs = new ArrayList<String>();
		List<AnalysisInputs> inputs_temp = new ArrayList<AnalysisInputs>();
		
		StringReader reader = new StringReader(source);

		KoreanAnalyzer analyzer = new KoreanAnalyzer(Version.LUCENE_30);
		analyzer.setBigrammable(false);
		TokenStream ts = analyzer.tokenStream("k", reader);
		
//		TokenStream result = null;
//		KoreanTokenizer kt = new KoreanTokenizer(Version.LUCENE_30, reader);
//		result = new KoreanFilter(kt);

		try {
			
			while(ts.incrementToken()) {
			    TermAttribute termAtt = ts.getAttribute(TermAttribute.class);
			    PositionIncrementAttribute  posIncrAtt = ts.getAttribute(PositionIncrementAttribute.class);
			    OffsetAttribute offsetAtt = ts.getAttribute(OffsetAttribute.class);
			    
			    int positionIncre = posIncrAtt.getPositionIncrement();
			    int startOffset = offsetAtt.startOffset();
			    int endOffset = offsetAtt.endOffset();
			    String term = termAtt.term();
			    	
			    
			    AnalysisInputs ai = new AnalysisInputs(positionIncre, startOffset, endOffset, term);
//			    System.out.println(positionIncre+":"+startOffset+":"+endOffset+":"+term);
				
//				inputs.add(termAtt.term().toString());
				inputs_temp.add(ai);
			}
		} catch (IOException e) {
			con.close();
			System.out.println(fileName);
			System.out.println(e);
		} catch (ArrayIndexOutOfBoundsException aoobe) {
			// TODO: handle exception
			System.out.println(aoobe.getStackTrace());
			System.out.println("ArrayIndexOutOfBoundsException Occured!!!!!!!");
			con.close();
		}
		
//		System.out.println((System.currentTimeMillis()-start)+"ms");
	
//		System.out.println();
//		for(AnalysisInputs input : inputs_temp){
//			System.out.println("###"+input.positionIncre+":"+input.startOffset+":"+input.endOffset+":"+input.term+"###");
//		}
//		System.out.println();
//		
		
		for(int i=0; i<inputs_temp.size(); i++){
			AnalysisInputs temp = inputs_temp.get(i);
			if(temp.positionIncre>=1 && i==inputs_temp.size()-1){
				inputs.add(temp.term);
//				System.out.println("***term"+i+":"+temp.term);
				break;
			}
			else if(temp.positionIncre>=1 && inputs_temp.get(i+1).positionIncre>=1){
				inputs.add(temp.term);
//				System.out.println("***term"+i+":"+temp.term);

			}
			else if(temp.positionIncre>=1 && inputs_temp.get(i+1).positionIncre<1){
				int index = i;
				while(inputs_temp.get(i+1).positionIncre<1){
					if(inputs_temp.get(index).term.contains(inputs_temp.get(i+1).term)){
					}
					else if(inputs_temp.get(i+1).term.contains(inputs_temp.get(index).term)){
						index = i+1;
					}
					else{
						index = i;
					}
					i++;
					if(i==inputs_temp.size()-1){
						break;
					}
				}
				inputs.add(inputs_temp.get(index).term);
//				System.out.println("***term"+index+":"+inputs_temp.get(index).term);
			}
		}
		
//		System.out.println(inputs_temp.size());
//		System.out.println(inputs.size());
		
		for(String input : inputs)
		{
			System.out.print(input+"/");
		}
		System.out.println();
		return inputs;
	}
	
	public static void testMorphAnalyzer(List<String> inputs) {
		
		MorphAnalyzer analyzer = new MorphAnalyzer();
		long start = 0;
		start = System.currentTimeMillis();
		List<String> nouns = new ArrayList<String>();
		
		for(String input:inputs) {
			try {
				List<AnalysisOutput> list;
				list = analyzer.analyze(input);
			
				for(AnalysisOutput o:list) {
	//				System.out.println(o.getStem());
					String[] result;
					result = o.toString().split(",");
					
					for(int cnt=0; cnt<result.length; cnt++){
						if(result[cnt].contains("(N)")){
//							System.out.println(result[cnt]);
							if(!nouns.contains(result[cnt])){
								nouns.add(result[cnt]);
							}
						}
					}
//					System.out.print("=========="+o.toString()+"->");
					for(int i=0;i<o.getCNounList().size();i++){
//						System.out.print(o.getCNounList().get(i).getWord()+"/");
					}
//					System.out.print(o.getEomi());
//					System.out.println("<"+o.getScore()+">");
				}
//				if(start==0) start = System.currentTimeMillis();
			} catch (MorphException e) {
				System.out.println(e);
				System.out.println(fileName);
				System.exit(0);
			}
		}
		for(String noun:nouns){
			System.out.print(noun+"//");
		}
		insertNouns(nouns);
//		System.out.println((System.currentTimeMillis()-start)+"ms");
		System.out.println();
		
	}
	
	public static void insertNouns(List<String> nouns) {

		try {

			String file = fileName+"_noun.txt";
			BufferedWriter bw = new BufferedWriter(new FileWriter(file, true));

			if(!nouns.isEmpty()){
				for(String noun:nouns){
					//0x3131=¤¡, 0x314E=¤¾, 0x314F=¤¿, 0x3163=l
					if(noun.charAt(0)>=0x3131 && noun.charAt(0)<=0x3163){ 
						noun = noun.replace("(N)", "");
						for(int c=0; c<noun.length(); c++){
							char ch = noun.charAt(c);
							if(ch>=0x3131 && ch<=0x3163){
								noun = noun.replace(String.valueOf(ch), "");
							}
						}
//						System.out.println(noun);
						if(noun.length()!=0){
							bw.write(noun+"/");
						}
					}
					else{
						noun = noun.replace("(N)", "");
						if(noun.length()!=0){
							bw.write(noun+"/");
						}
					}
					
					if(noun.length()!=0 && noun.length()<=25){
						if(isExistNoun(noun)==false){
							insertDB(noun);
						}
					}
				}
				bw.write("\n");
			}
			else{
				count_empty++;
			}
			bw.close();
			System.out.println();
		} catch (Exception e) {
			System.out.println(fileName);
			System.out.println(e);
		} 
	}
	
	private static void CreateTable(String tableName) throws SQLException {
		
		PreparedStatement pstmt = null;
		String query = "create table K" + tableName + " (noun varchar2(50) primary key, count number(6))";

		if(con != null) {
			try {
				pstmt = con.prepareStatement(query);
				pstmt.executeQuery();
			} catch (SQLException e) {
				System.out.println("create table error");
				System.out.println(e);
				System.out.println(tableName);
				System.exit(0);
			} finally {
				if(pstmt != null) {
					pstmt.close();
				}
			}
		} else {
			System.out.println("--- DB CONNECTION FAILED");
		}
	}

	private static boolean isExistNoun(String noun) throws SQLException {
		
		boolean isExist = false;
		PreparedStatement pstmt = null;
		ResultSet rs = null;
		int count = 0;
		String query = "select noun, count from k" + fileName + " where noun=?";
		
		if(con != null) {
			try {
				pstmt = con.prepareStatement(query);
				pstmt.setString(1, noun);
				rs = pstmt.executeQuery();
				isExist = rs.next();

				if(isExist == true){
					count = rs.getInt("count");
					updateNounCount(noun, count);
				}
//				System.out.println("isExist : "+isExist);
			} catch (SQLException e) {
				System.out.println("select error");
				System.out.println(e);
				System.out.println(fileName);
				System.exit(0);
			} finally {
				if(rs != null){
					rs.close();
				}
				if(pstmt != null){
					pstmt.close();
				}
			}
		} else {
			System.out.println("--- DB CONNECTION FAILED");
		}
		return isExist;
	}

	private static void insertDB(String noun) throws SQLException {

		PreparedStatement pstmt = null;
		String query = "insert into k" + fileName + " values(?, 1)";
		
		if(con != null) {
			try {
				pstmt =  con.prepareStatement(query);
				pstmt.setString(1, noun);
				pstmt.executeUpdate();
				count_db++;
				
			} catch (Exception e) {
				System.out.println("insert error");
				System.out.println(e);
				System.out.println(fileName);
				System.exit(0);
			} finally {
				if(pstmt != null){
					pstmt.close();
				}
			}
		} else {
			System.out.println("--- DB CONNECTION FAILED");
		}
	}
	
	private static void updateNounCount(String noun, int count) throws SQLException {
		
		count++;
		PreparedStatement pstmt = null;
		String query = "update k" + fileName + " set count = ? where noun = ?";

		if(con != null) {
			try {
				pstmt = con.prepareStatement(query);
				pstmt.setInt(1, count);
				pstmt.setString(2, noun);
				pstmt.executeUpdate();
				count_db++;
			} catch (SQLException e) {
				System.out.println("update error");
				System.out.println(e);
				System.out.println(fileName);
				System.exit(0);
			} finally {
				if(pstmt != null){
					pstmt.close();
				}
			}
		} else {
			System.out.println("--- DB CONNECTION FAILED");
		}
		
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
			System.exit(0);
		}
		return conn;
	}
}

class AnalysisInputs{
	
	int positionIncre, startOffset, endOffset;
	String term;

	AnalysisInputs(int positionIncre, int startOffset, int endOffset, String term){
		this.positionIncre = positionIncre;
		this.startOffset = startOffset;
		this.endOffset = endOffset;
		this.term = term;
	}
}
