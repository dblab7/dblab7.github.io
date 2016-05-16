package org.apache.lucene.analysis.kr;

import java.io.StringReader;

import org.apache.lucene.analysis.Analyzer;
import org.apache.lucene.analysis.Token;
import org.apache.lucene.analysis.TokenStream;
import org.apache.lucene.analysis.standard.StandardAnalyzer;
import org.apache.lucene.analysis.tokenattributes.OffsetAttribute;
import org.apache.lucene.analysis.tokenattributes.PositionIncrementAttribute;
import org.apache.lucene.analysis.tokenattributes.TermAttribute;
import org.apache.lucene.util.Version;

import junit.framework.TestCase;

public class KoreanAnalyzerTest extends TestCase {

	/**
	 * t.getPositionIncrement() 는 같은 단어에서 추출되었는지, 다른 단어에서 추출되었는지를 알려준다.
	 * 즉 1이면 현재의 색인어는 새로운 단어에서 추출된 것이고
	 * 0 이면 이전 색인어와 같은 단어에서 추출된 것이다.
	 * 이 값은 검색 랭킹에 영향을 미친다.  즉 값이 작으면 검색랭킹이 올라가서 검색시 상위에 올라오게 된다.
	 * @throws Exception
	 */
	public void testKoreanAnalyzer() throws Exception {
		
		String source = "우리나라라면에서부터 일본라면이 파생되었잖니?";
		source = "너는 다시 내게 돌아 올거야";
//		source = "과소비";
		source = "내 여자친구는 구미호";
		source = "노트북쓰다데스크탑쓰니까키보드의그터치파드가없어서자꾸헛손질해";
//		source = "신경안쓴다는데";
//		source = "나 이번에 반에서 5등안에들면 아빠가 20만원준다는데";
//		source = "20만원준다는데";
//		source = "친절하게 가르쳐준다";
		
		long start = System.currentTimeMillis();

		System.out.println(source.length());
		System.out.println("testKoreanAnalyzer()["+source+"] start!!");

		KoreanAnalyzer analyzer = new KoreanAnalyzer(Version.LUCENE_30);
//		Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);
//		analyzer = new KoreanAnalyzer(Version.LUCENE_30);
		TokenStream ts = analyzer.tokenStream("k", new StringReader(source));
		
		while(ts.incrementToken()) {
		    TermAttribute termAtt = ts.getAttribute(TermAttribute.class);
		    PositionIncrementAttribute  posIncrAtt = ts.getAttribute(PositionIncrementAttribute.class);
		    OffsetAttribute offsetAtt = ts.getAttribute(OffsetAttribute.class);

			System.out.println(posIncrAtt.getPositionIncrement()+":"
					+offsetAtt.startOffset()+":"+offsetAtt.endOffset()+":"+termAtt.term());
			
		}
		System.out.println((System.currentTimeMillis()-start)+"ms");
	}
	
}
