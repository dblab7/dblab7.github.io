package collect;
import java.io.IOException;
import java.io.StringReader;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

import org.apache.lucene.analysis.TokenStream;
import org.apache.lucene.analysis.kr.KoreanAnalyzer;
import org.apache.lucene.analysis.kr.morph.AnalysisOutput;
import org.apache.lucene.analysis.kr.morph.MorphAnalyzer;
import org.apache.lucene.analysis.kr.morph.MorphException;
import org.apache.lucene.analysis.tokenattributes.OffsetAttribute;
import org.apache.lucene.analysis.tokenattributes.PositionIncrementAttribute;
import org.apache.lucene.analysis.tokenattributes.TermAttribute;
import org.apache.lucene.util.Version;


public class TweetMorphAnalyzer {
	static String twtDate;
	static String twt;

	public static String main(String tweet) throws ParseException, ArrayIndexOutOfBoundsException{

		String analyzedResult = null;

		twtDate = getTweetDate(tweet);
		twt = textProcessing(tweet);

		
		//형태소 분석 후 결과 반환
		analyzedResult = saveResult(testMorphAnalyzer(testKoreanAnalyzer(twt))); 

		return analyzedResult;
	}

	// 명사(N)태그를 포함하는 단어들만 받아와 String 형태의 결과로 반환   
	private static String saveResult(List<String> nouns) {

		String analyzedTweet = "";

		if(!nouns.isEmpty()){
			analyzedTweet += twtDate+"/";
			for(String noun:nouns){
				//0x3131=ㄱ, 0x314E=ㅎ, 0x314F=ㅏ, 0x3163=l
				if(noun.charAt(0)>=0x3131 && noun.charAt(0)<=0x3163){ 
					noun = noun.replace("(N)", "");
					for(int c=0; c<noun.length(); c++){
						char ch = noun.charAt(c);
						if(ch>=0x3131 && ch<=0x3163){
							noun = noun.replace(String.valueOf(ch), "");
						}
					}
					//					System.out.println(noun);
					if(noun.length()!=0){
						analyzedTweet += noun+"/";
					}
				}
				else{
					noun = noun.replace("(N)", "");
					if(noun.length()!=0){
						analyzedTweet += noun+"/";
					}
				}

			}
		}
		return analyzedTweet;
	}


	//분석하려는 트윗에서 시간정보 추출 및 포맷 변환후 반환
	public static String getTweetDate(String tweet) throws ParseException{

		String readDate = tweet.split("#.#")[1];
		SimpleDateFormat inputFormat = new SimpleDateFormat("EEE MMM dd HH:mm:ss z yyyy" , Locale.ENGLISH);
		SimpleDateFormat outputFormat = new SimpleDateFormat("yyyyMMddHHmmss");

		if(readDate.length()>28){
			readDate = readDate.replace(".#", "");
		}
		readDate = outputFormat.format(inputFormat.parse(readDate));
		return readDate;
	}


	// 트윗의 텍스트 추출 및 선처리 과정 수행후 반환
	public static String textProcessing(String source){
		source = source.split("#.#")[0];
		if(source.contains("RT ")){
			source = source.replaceAll("RT ", "");
		} if(source.contains("(")){
			source = source.replaceAll("\\(", "");
		} if(source.contains(")")){
			source = source.replaceAll("\\)", "");
		} if(source.contains("]")){
			source = source.replaceAll("\\]", "");
		} if(source.contains("[")){
			source = source.replaceAll("\\[", "");
		} if(source.contains("?")){
			source =  source.replaceAll("\\?", "");
		} if(source.contains("*")){
			source = source.replaceAll("\\*", "");
		} if(source.contains("&")){
			source = source.replaceAll("\\&", "");
		} if(source.contains("\\")){
			source = source.replaceAll("\\\\", "");
		} if(source.contains("@")){
			String[] words_m = null;
			words_m = source.split(" ");
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


	// 형태소 분석전 한국어 분석기 실행하여 단어 단위로 분리 - 결과를 형태소 분석기로 넘겨줌 
	public static List<String> testKoreanAnalyzer(String source) throws  ArrayIndexOutOfBoundsException {	

		List<String> inputs = new ArrayList<String>();
		List<AnalysisInputFactors> inputs_temp = new ArrayList<AnalysisInputFactors>();

		StringReader reader = new StringReader(source);

		@SuppressWarnings("resource")
		KoreanAnalyzer analyzer = new KoreanAnalyzer(Version.LUCENE_30);
		analyzer.setBigrammable(false);
		TokenStream ts = analyzer.tokenStream("k", reader);

		try {

			while(ts.incrementToken()) {
				TermAttribute termAtt = ts.getAttribute(TermAttribute.class);
				PositionIncrementAttribute  posIncrAtt = ts.getAttribute(PositionIncrementAttribute.class);
				OffsetAttribute offsetAtt = ts.getAttribute(OffsetAttribute.class);

				int positionIncre = posIncrAtt.getPositionIncrement();
				int startOffset = offsetAtt.startOffset();
				int endOffset = offsetAtt.endOffset();
				String term = termAtt.term();


				AnalysisInputFactors ai = new AnalysisInputFactors(positionIncre, startOffset, endOffset, term);
				//			    System.out.println(positionIncre+":"+startOffset+":"+endOffset+":"+term);

				//				inputs.add(termAtt.term().toString());
				inputs_temp.add(ai);
			}
		} catch (ArrayIndexOutOfBoundsException aoobe) {
			// TODO: handle exception
			System.out.println(aoobe.getStackTrace());
			System.out.println("ArrayIndexOutOfBoundsException Occured!!!!!!!");
		} catch (IOException e) {
			System.out.println(e);
		}

		//		System.out.println();
		//		for(AnalysisInputs input : inputs_temp){
		//			System.out.println("###"+input.positionIncre+":"+input.startOffset+":"+input.endOffset+":"+input.term+"###");
		//		}
		//		System.out.println();
		//		

		for(int i=0; i<inputs_temp.size(); i++){
			AnalysisInputFactors temp = inputs_temp.get(i);
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

		return inputs;
	}


	// 넘겨받은 단어들에 대해 형태소 분석(품사 태깅) 실행 - 그중 명사태그를 포함하는 단어만 추출
	@SuppressWarnings("unchecked")
	public static List<String> testMorphAnalyzer(List<String> inputs) {

		MorphAnalyzer analyzer = new MorphAnalyzer();
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
							//						System.out.println(result[cnt]);
							if(!nouns.contains(result[cnt])){
								nouns.add(result[cnt]);
							}
						}
					}
					//				System.out.print("=========="+o.toString()+"->");
					for(int i=0;i<o.getCNounList().size();i++){
						//					System.out.print(o.getCNounList().get(i).getWord()+"/");
					}
					//				System.out.print(o.getEomi());
					//				System.out.println("<"+o.getScore()+">");
				}
			} catch (MorphException e) {
				System.out.println(e);
				System.exit(0);
			}
		}
		return nouns;
	}

}


class AnalysisInputFactors{

	int positionIncre, startOffset, endOffset;
	String term;

	AnalysisInputFactors(int positionIncre, int startOffset, int endOffset, String term){
		this.positionIncre = positionIncre;
		this.startOffset = startOffset;
		this.endOffset = endOffset;
		this.term = term;
	}
}