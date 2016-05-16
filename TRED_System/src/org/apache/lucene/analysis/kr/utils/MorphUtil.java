package org.apache.lucene.analysis.kr.utils;

/**
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

import java.util.ArrayList;
import java.util.List;

import org.apache.lucene.analysis.kr.morph.AnalysisOutput;
import org.apache.lucene.analysis.kr.morph.MorphException;
import org.apache.lucene.analysis.kr.morph.PatternConstants;
import org.apache.lucene.analysis.kr.morph.WordEntry;

public class MorphUtil {

	private static final char[] CHOSEONG = {
		'��','��','��','��','��','��','��','��','��','��',
		'��','��','��','��','��','��','��','��','��'
	};

	private static final char[] JUNGSEONG = {
		'��','��','��','��','��','��','��','��','��','��',
		'��','��','��','��','��','��','��','��','��','��',
		'��'
	};
	
	private static final char[] JONGSEONG = {
		'\0','��','��','��','��','��','��','��','��','��',
		'��','��','��','��','��','��','��','��','��','��',
		'��','��','��','��','��','��','��','��'
	};
	
	private static final int JUNG_JONG = JUNGSEONG.length * JONGSEONG.length;

	
	/**
	 * �ѱ� �ѱ��ڸ� �ʼ�/�߼�/������ �迭�� ����� ��ȯ�Ѵ�.
	 * @param c
	 * @return
	 */
	public static char[] decompose(char c) {
		char[] result = null;

		if(c>0xD7A3||c<0xAC00) return new char[]{c};
		
		c -= 0xAC00;

		char choseong = CHOSEONG[c/JUNG_JONG];
		c = (char)(c % JUNG_JONG);
		
		char jungseong = JUNGSEONG[c/JONGSEONG.length];
		
		char jongseong = JONGSEONG[c%JONGSEONG.length];
		
		if(jongseong != 0) {
			result = new char[] {choseong, jungseong, jongseong};
		}else {
			result = new char[] {choseong, jungseong};			
		}
		return result;
	}	
	
	public static char compound(int first, int middle, int last) {		
		return (char)(0xAC00 + first* JUNG_JONG + middle * JONGSEONG.length + last);
	}
	

	public static char makeChar(char ch, int mdl, int last) {		
		ch -= 0xAC00;		
		int first = ch/JUNG_JONG;		 
		return compound(first,mdl,last);
	}
	
	public static char makeChar(char ch, int last) {
		ch -= 0xAC00;		
		int first = ch/JUNG_JONG;	
		ch = (char)(ch % JUNG_JONG);
		int middle = ch/JONGSEONG.length;
		
		return compound(first,middle,last);		
	}
	
	public static char replaceJongsung(char dest, char source) {
		source -= 0xAC00;		
		int last = source % JONGSEONG.length;
			
		return makeChar(dest,last);	
	}

	/**
	 * ���¼� ���� ����� ���� ���ڿ��� �����Ѵ�.
	 * @param word
	 * @param type
	 * @return
	 */
	public static String buildTypeString(String word, char type) {
		StringBuffer sb = new StringBuffer();
		sb.append(word);
		sb.append("(");
		sb.append(type);
		sb.append(")");
		
		return sb.toString();
	}
	
	
	public static void buildPtnVM(AnalysisOutput output, List candidates) throws MorphException {
		
		String end = output.getEomi();
		if(output.getPomi()!=null) end = output.getPomi();
		
		output.setPatn(PatternConstants.PTN_VM);
		output.setPos(PatternConstants.POS_VERB);
		
		if(output.getScore()==AnalysisOutput.SCORE_CORRECT) {
			candidates.add(output);
		}else {
			String[] irrs = IrregularUtil.restoreIrregularVerb(output.getStem(),end);
			if(irrs!=null) {
				output.setScore(AnalysisOutput.SCORE_CORRECT);
				output.setStem(irrs[0]);
				candidates.add(output);	
			}
		}
		
	}
	
	/**
	 * ��� + '��/��' + '��' + ���, ü�� + '����/����/��������' + '��' + ���
	 * @param output
	 * @param candidates
	 * @throws MorphException
	 */
	public static void buildPtnCM(AnalysisOutput output, List candidates) throws MorphException {
		
		char ch = output.getStem().charAt(output.getStem().length()-2);
		char[] jasos = MorphUtil.decompose(ch);
		if(jasos.length==3||ch=='��') {
			buildPtnVMCM(output,candidates);			
		} else {
			
		}
	}
	
	private static void buildPtnVMCM(AnalysisOutput output, List candidates) throws MorphException {
		String stem = output.getStem();
	
		output.setPatn(PatternConstants.PTN_VMCM);
		output.setPos(PatternConstants.POS_VERB);
		
		char ch = stem.charAt(stem.length()-2);
		char[] jasos = MorphUtil.decompose(ch);

		if(ch=='��') {
			output.addElist("��");
			output.addElist("��");
			output.setStem(stem.substring(0,stem.length()-2));
			
			if(DictionaryUtil.getVerb(output.getStem())!=null)
				candidates.add(output);
		}else if(jasos[2]=='��') {
			if(stem.length()>1) stem = stem.substring(0,stem.length()-2);
			stem += MorphUtil.makeChar(ch, 0);
			output.addElist("��");
			output.addElist("��");
			output.setStem(stem);

			if(DictionaryUtil.getVerb(stem)!=null) 
				candidates.add(output);
			else {
				String[] morphs = IrregularUtil.restoreIrregularVerb(stem,"��");
				if(morphs!=null) {
					output.setScore(AnalysisOutput.SCORE_CORRECT);
					output.setStem(morphs[0]);
					candidates.add(output);
				}
			}
		}
	}

	public static boolean hasVerbOnly(String input) throws MorphException {
		
		for(int i=input.length()-1;i>=0;i--) {
			char[] feature = SyllableUtil.getFeature(input.charAt(i));
			if(feature[SyllableUtil.IDX_WDSURF]=='1'&&input.length()>i) return true;
		}
		return false;
	}
	
	/**
	 * ���� ����̸��� ���� ��ȯ�Ѵ�.
	 * @param preword  '��' �Ǵ� '��'
	 * @param endword  ���[����̸��� ����]
	 * @return '��' �Ǵ� '��'�� ���� ��ȯ�Ѵ�.
	 */
	public static String makeTesnseEomi(String preword, String endword) {

		if(preword==null||preword.length()==0) return endword;
		if(endword==null||endword.length()==0) return preword;

		if(endword.charAt(0)=='��') {
			return preword.substring(0,preword.length()-1)+
				makeChar(preword.charAt(preword.length()-1),20)+endword.substring(1,endword.length());		
		} else if(endword.charAt(0)=='��') {
			return preword.substring(0,preword.length()-1)+
			makeChar(preword.charAt(preword.length()-1),4)+endword.substring(1,endword.length());
		} else if(endword.charAt(0)=='��') {
			return preword.substring(0,preword.length()-1)+
			makeChar(preword.charAt(preword.length()-1),8)+endword.substring(1,endword.length());	
		} else if(endword.charAt(0)=='��') {
			return preword.substring(0,preword.length()-1)+
			makeChar(preword.charAt(preword.length()-1),16)+endword.substring(1,endword.length());					
		} else if(endword.charAt(0)=='��') {
			return preword.substring(0,preword.length()-1)+
			makeChar(preword.charAt(preword.length()-1),17)+endword.substring(1,endword.length());
		}
		return preword+endword;		
	}
	
	/**
	 * ���ȭ���̻簡 ���յ� �� �ִ��� ���θ� �����Ѵ�.
	 * Ư�� ������ ��ϵ� �Ǵ�, �ϴ��� �� ������ ���������� �����Ѵ�.
	 * @param o
	 * @return
	 */
	public static boolean isValidSuffix(WordEntry entry, AnalysisOutput o) {
		
		return true;
	}
	
}

