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
	 * t.getPositionIncrement() �� ���� �ܾ�� ����Ǿ�����, �ٸ� �ܾ�� ����Ǿ������� �˷��ش�.
	 * �� 1�̸� ������ ���ξ�� ���ο� �ܾ�� ����� ���̰�
	 * 0 �̸� ���� ���ξ�� ���� �ܾ�� ����� ���̴�.
	 * �� ���� �˻� ��ŷ�� ������ ��ģ��.  �� ���� ������ �˻���ŷ�� �ö󰡼� �˻��� ������ �ö���� �ȴ�.
	 * @throws Exception
	 */
	public void testKoreanAnalyzer() throws Exception {
		
		String source = "�츮�����鿡������ �Ϻ������ �Ļ��Ǿ��ݴ�?";
		source = "�ʴ� �ٽ� ���� ���� �ðž�";
//		source = "���Һ�";
		source = "�� ����ģ���� ����ȣ";
		source = "��Ʈ�Ͼ��ٵ���ũž���ϱ�Ű�����Ǳ���ġ�ĵ尡����ڲ��������";
//		source = "�Ű�Ⱦ��ٴµ�";
//		source = "�� �̹��� �ݿ��� 5��ȿ���� �ƺ��� 20�����شٴµ�";
//		source = "20�����شٴµ�";
//		source = "ģ���ϰ� �������ش�";
		
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
