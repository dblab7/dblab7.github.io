package org.apache.lucene.analysis.kr;

import java.util.Iterator;
import java.util.List;

import junit.framework.TestCase;

import org.apache.lucene.analysis.kr.morph.AnalysisOutput;
import org.apache.lucene.analysis.kr.morph.MorphAnalyzer;
import org.apache.lucene.analysis.kr.morph.MorphException;
import org.apache.lucene.analysis.kr.morph.WSAOutput;
import org.apache.lucene.analysis.kr.morph.WordSpaceAnalyzer;
import org.apache.lucene.analysis.kr.utils.DictionaryUtil;
import org.apache.lucene.analysis.kr.utils.SyllableUtil;

public class SyllableTest extends TestCase {

	public void testWordSpace() throws Exception {
		
		String[] strs = new String[]{
				"������Ǫ���������ǽŰ�ȭ������30�⵿�����������κ�ȣ�ϰ��п��簥�������ô��������սǸ��˴¾������ε������ް��ִ�", //0
				"����ũ�����������´��̳������ʰ���������������̴�", //1
				"���ټ���õ¡������������", //2
				"���ټ���õ¡������", //3
				"���ý������ڵ�������ⵥ���Դϴ�", //4
				"�Ľ�������ȸ������ȭ��", //5
				"�����ػ米�������̿�Ÿ���񽺾�������", //6
				"�ڹ��ѱ����¼Һм��ⵥ��", //7
				"���������̹����ϱ�", //8
				"����ѱۺм�����¼ҽ�������Ʈ", //9
				"��������", //10
				"�����ڿ������������ΰ����մϴ�", //11
				"����������԰��ϴ�", //12
				"����̷������������ִ°��Դϱ�", //13
				"��������������", // 14
				"2���������������å�޹���", // 15
				"����ؿܻ��ü����������", // 16
				"�ȳ��ϼ�������Ȳ�ƿ��Դϴ�",//17
				"�����ڶ��������±ر�տ������������ǹ����ѿ�Ȳ�����Ͽ����������������漺�����Ұ������Դ����մϴ�", //18
				"�����س���������", // 19
				"�����Ͱ������ǽ�����", //20
				"�����������",//21
				"���ĳ����ٴ°���" //22
		};

		WordSpaceAnalyzer wsAnal = new WordSpaceAnalyzer();
		
//		for(String str:strs) {
//			List<AnalysisOutput> list = wsAnal.analyze(str);
//
//			for(AnalysisOutput o: list) {
////				System.out.println(o.getSource()+"<"+o+"("+o.getScore()+")> ");
//				System.out.print(o.getSource()+" ");
//			}
//			System.out.println("");
//		}


		List<AnalysisOutput> list = wsAnal.analyze(strs[22]);

		for(AnalysisOutput o: list) {
			System.out.println(o.getSource()+"<"+o+"("+o.getScore()+")> ");
//			System.out.print(o.getSource()+" ");
		}
		System.out.println("");


	}
	
	public void testSplitWord() throws Exception {
		
		String str = "����ũ�����������´��̳������ʰ���������������̴�";
		char[] chrs = str.toCharArray();
		
		
		StringBuffer word = new StringBuffer();
		for(int ws=0, es=1, ee=0; es<chrs.length; ) {
			char[] f = SyllableUtil.getFeature(chrs[es]);
			if(f[SyllableUtil.IDX_JOSA1]=='1') {

				ee = guessJosa(str, chrs, ws, es);
				if(es!=ee) {
					System.out.println(str.substring(ws,ee));					
					ws=ee;es=ee+1;					
					continue;
				}
			}
			
			if(f[SyllableUtil.IDX_EOGAN]=='1') {			
				ee = guessEomi(str, chrs, ws,es);
				if(es!=ee) {
					System.out.println(str.substring(ws,ee));					
					ws=ee;es=ee+1;
					continue;
				}
			}
				
			es += 1;
		}		
	}
	
	private int guessJosa(String str, char[] chrs, int ws, int es) throws MorphException {

		int ne = es;
		
		if(DictionaryUtil.existJosa(str.substring(es,es+1))) ne++;
		for(int i=ne;i<str.length();i++) {
			char[] f = SyllableUtil.getFeature(chrs[i]);
			if(f[SyllableUtil.IDX_JOSA2]!='1') break; 
			if(DictionaryUtil.existJosa(str.substring(es,i+1))) ne = i+1;
		}
		return ne;
	}
	
	private int guessEomi(String str, char[] chrs, int ws, int es)throws MorphException {
		 System.out.println("guessEomi->"+str.substring(ws,es));		
		int ne = es+1;		
		
		for(int i=ne;i<str.length();i++) {
			char[] f = SyllableUtil.getFeature(chrs[i]);
			if(f[SyllableUtil.IDX_EOGAN]!='1') break;
			ne++;
		}
		
		for(int i=ne-1;i>ws;i--) {
			
		}
		
		return ne;
	}
	

}
