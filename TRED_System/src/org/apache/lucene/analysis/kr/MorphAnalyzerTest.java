package org.apache.lucene.analysis.kr;

import java.io.File;
import java.io.StringReader;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.commons.io.FileUtils;
import org.apache.lucene.analysis.Token;
import org.apache.lucene.analysis.TokenStream;
import org.apache.lucene.analysis.kr.morph.AnalysisOutput;
import org.apache.lucene.analysis.kr.morph.MorphAnalyzer;
import org.apache.lucene.analysis.kr.morph.MorphAnalyzerManager;
import org.apache.lucene.analysis.kr.morph.WordEntry;
import org.apache.lucene.analysis.kr.utils.DictionaryUtil;
import org.apache.lucene.analysis.kr.utils.FileUtil;
import org.apache.lucene.analysis.tokenattributes.OffsetAttribute;
import org.apache.lucene.analysis.tokenattributes.PositionIncrementAttribute;
import org.apache.lucene.analysis.tokenattributes.TermAttribute;
import org.apache.lucene.util.Version;

import junit.framework.TestCase;

public class MorphAnalyzerTest extends TestCase {


	public void testMorphAnalyzer() throws Exception {
		
		String[] inputs = new String[] {
				//"�����ô���",
				//"�����",
				//"������","�پ������","�޿���Ȱ�ڳ�","�����ڿ�����","��������","���ΰ�������","�¸�����","�����ϰ�",
				//"��󸶰�",
				//"���層��","���Һ�",
				//"����","�ƿ﷯","�޴���ȭ���ó���ο�","�ڹ�Ʈ��",
				"�޶�","ȥ������","���Һ�"
				// ,"������","�����"	// 	��̷� ������ ���� �м��ȴ�.	
				//,"���",
				//"����û������","���ù簰��",
				//"��å��",	"�ø��","�ڸ�����","�����̴�","������",
				//"�����Դϴ�",
				//"���̿��׳�����",
				//"�޶�������",
				//"4.19�ǰŴ�",
				//"��Ʈx��",
				//"�˻����񽺸�",
				//"��ֹ���"
				};
		
		MorphAnalyzer analyzer = new MorphAnalyzer();
		long start = 0;
		for(String input:inputs) {
			List<AnalysisOutput> list = analyzer.analyze(input);
			for(AnalysisOutput o:list) {
				System.out.print(o.toString()+"->");
				for(int i=0;i<o.getCNounList().size();i++){
					System.out.print(o.getCNounList().get(i).getWord()+"/");
				}
				System.out.print(o.getEomi());
				System.out.println("<"+o.getScore()+">");
			}
			if(start==0) start = System.currentTimeMillis();
		}
		System.out.println((System.currentTimeMillis()-start)+"ms");
	}
		
	public void testCloneAnalysisOutput() throws Exception {
		AnalysisOutput output = new AnalysisOutput();
		
		output.setStem("aaaa");
		
		AnalysisOutput clone = output.clone();
		
		assertEquals("aaaa", clone.getStem());
		
		System.out.println(clone.getStem());
	}
	
	public void testKoreanAnalyzer() throws Exception {
		
//		String source = FileUtil.readFileToString(new File("input.txt"), "UTF-8");
		//source="�����籹�� ������ ��ǥŰ�� �� ����� ���� ������å�� � ������ ��� �� ������ �������� �ִ�.��â�� ������ ���������� 7�� ������ ����ȸ�� �ֳθ���Ʈ���� ����ȸ�� ���� �� ����ȸ�߿��� �������� �ֽĽ��� ������å �� ������ ������ ��ǥ�� �͡��̶�� ���ؿ����ð� �޶������� ���� ���ô� �����ϰ� �־� ���ΰ� �μ�Ƽ�긦 �����ϸ� ȿ���� ���� �͡��̶�� ���ߴ�.";
		//source="���� ũ������������ ���� ������ �ʰ� ���� ������ �����̴� ABC";
		//source = "new Integer(1)";
		String source = "���װŷ��� ������ �ϴ�";
		
		long start = System.currentTimeMillis();
		
		KoreanAnalyzer analyzer = new KoreanAnalyzer(Version.LUCENE_30);
		
		TokenStream ts = analyzer.tokenStream("k", new StringReader(source));
		while(ts.incrementToken()) {
		    TermAttribute termAtt 					= ts.getAttribute(TermAttribute.class);
		    PositionIncrementAttribute  posIncrAtt = ts.getAttribute(PositionIncrementAttribute.class);
		    OffsetAttribute offsetAtt = ts.getAttribute(OffsetAttribute.class);

			System.out.println(posIncrAtt.getPositionIncrement()+":"
					+offsetAtt.startOffset()+":"+offsetAtt.endOffset()+":"+termAtt.term());
		}
		
		System.out.println((System.currentTimeMillis()-start)+"ms");
	}
	
	public void testMorphAnalyzerManager() throws Exception {
		String input = "���� �б��� �����ϴ�";

		MorphAnalyzerManager manager = new MorphAnalyzerManager();
		manager.analyze(input);
	}
	
	public void testAlphaNumeric() throws Exception {
		String str = "0123456789azAZ";
		for(int i=0;i<str.length();i++) {
			System.out.println(str.charAt(i)+":"+(str.charAt(i)-0));
		}
	}
	
	public void testGetWordEntry() throws Exception {
		String s = "���ϴ�";
		WordEntry we = DictionaryUtil.getNoun(s);
		System.out.println(we.getWord());
	}
	
	/**
	 * ������������ �ϴٿ� �Ǵ��� ���縦 ü��� �����ϱ� ���� ����� �׽�Ʈ���̽�
	 * 
	 * @throws Exception
	 */
	public void testYongonAnalysis() throws Exception {
		
		String fname = "data/���_��.txt";
		
		List<String> list = FileUtils.readLines(new File(fname));
		Map<String, String> younons = new HashMap();
		
		MorphAnalyzer analyzer = new MorphAnalyzer();
		long start = 0;
		List youngOutputs = new ArrayList();
		for(String input:list) {
			
			if(!input.endsWith("�ϴ�")&&!input.endsWith("�Ǵ�")) {
				youngOutputs.add(input);
				continue;			
			}
			String eogan = input.substring(0,input.length()-2);
			
			List<AnalysisOutput> outputs = analyzer.analyze(input);
			AnalysisOutput o = outputs.get(0);
			String result = o.toString()+"->";
			for(int i=0;i<o.getCNounList().size();i++){
				result += o.getCNounList().get(i).getWord()+"/";
			}
			result += "<"+o.getScore()+">";

			String tmp = younons.get(eogan);
			if(tmp==null) {
				younons.put(eogan, result);
			} else {
				younons.put(eogan, tmp+"| "+result);
			}
		}
		
		fname = "data/ü��_��.txt";		
		String cheonOutfile = "data/cheon.txt";
		String youngOutfile = "data/youngon.txt";
		
		List<String> cheons = FileUtils.readLines(new File(fname));	
		List<String> outputs = new ArrayList();
		System.out.println(younons.size());		
		for(String cheon : cheons) {
			String str = younons.remove(cheon);
			if(str!=null) {
				cheon += "=> "+str;
//				younons.remove(cheon);
			}
			outputs.add(cheon);
		}

		Iterator<String> iter = younons.keySet().iterator();
		while(iter.hasNext()) {
			String key = iter.next();
			outputs.add(key+"=> " + younons.get(key));
		}
		
		Collections.sort(outputs);
		Collections.sort(youngOutputs);
		
		FileUtils.writeLines(new File(cheonOutfile), outputs);
		FileUtils.writeLines(new File(youngOutfile), youngOutputs);
		
		outputs.addAll(youngOutputs);
		Collections.sort(outputs);
		FileUtils.writeLines(new File( "data/all.txt"), outputs);
	}
}

