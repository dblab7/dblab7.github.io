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

import org.apache.lucene.analysis.kr.morph.MorphException;
import org.apache.lucene.analysis.kr.morph.WordEntry;

/**
 * 
 * ������ �ұ�Ģ ������ ó���ϴ� Utility Class
 * 
 * @author S.M.Lee
 *
 */
public class IrregularUtil {
	
	// �� �ұ�Ģ
	public static final char IRR_TYPE_BIUP = 'B';
	
	// �� �ұ�Ģ
	public static final char IRR_TYPE_HIOOT = 'H';
	
	// �� �ұ�Ģ
	public static final char IRR_TYPE_LIUL = 'U';
	
	// �� �ұ�Ģ
	public static final char IRR_TYPE_LOO = 'L';

	// �� �ұ�Ģ
	public static final char IRR_TYPE_SIUT = 'S';
	
	// �� �ұ�Ģ
	public static final char IRR_TYPE_DI = 'D';
	
	// �� �ұ�Ģ
	public static final char IRR_TYPE_RU = 'R';
	
	// �� Ż��
	public static final char IRR_TYPE_UI = 'X';	
	
	// ��Ģ��
	public static final char IRR_TYPE_REGULAR = 'X';
	
	public static String[] restoreIrregularVerb(String start, String end) throws MorphException {

		if(end==null) end="";
		char[] jasos = new char[0];		

		if(end.length()>0) jasos = MorphUtil.decompose(end.charAt(0));

		if(end.startsWith("��")) {			
			String[] irrs = restoreBIrregular(start,end);
			if(irrs!=null) return irrs;	
			irrs = restoreHIrregular(start,end);
			if(irrs!=null) return irrs;	
			irrs = restoreELIrregular(start,end);
			if(irrs!=null) return irrs;				
		}else if(end.startsWith("��")) {			
			String[] irrs = restoreBIrregular(start,end);
			if(irrs!=null) return irrs;	
			irrs = restoreHIrregular(start,end);
			if(irrs!=null) return irrs;	
			irrs = restoreELIrregular(start,end);
			if(irrs!=null) return irrs;			
		}else if(end.startsWith("��")) {			
			String[] irrs = restoreBIrregular(start,end);
			if(irrs!=null) return irrs;
			irrs = restoreHIrregular(start,end);
			if(irrs!=null) return irrs;				
		}else if(end.startsWith("��")) {			
			String[] irrs = restoreBIrregular(start,end);
			if(irrs!=null) return irrs;	
			irrs = restoreHIrregular(start,end);
			if(irrs!=null) return irrs;	
			irrs = restoreELIrregular(start,end);
			if(irrs!=null) return irrs;					
		}else if(start.endsWith("��")||start.endsWith("��")) {			
			String[] irrs = restoreBIrregular(start,end);
			if(irrs!=null) return irrs;				
		}else if(end.startsWith("��")) {			
			String[] irrs = restoreBIrregular(start,end);
			if(irrs!=null) return irrs;	
		}else if(end.startsWith("��")) {
			String[] irrs = restoreBIrregular(start,end);
			if(irrs!=null) return irrs;	
			irrs = restoreELIrregular(start,end);
			if(irrs!=null) return irrs;				
		}else if(end.startsWith("��")) {			
			String[] irrs = restoreBIrregular(start,end);
			if(irrs!=null) return irrs;				
		}else if(jasos.length>1&&jasos[0]=='��'&&(jasos[1]=='��'||jasos[1]=='��')) {			
			String[] irrs = restoreDIrregular(start,end);
			if(irrs!=null) return irrs;	
			irrs = restoreSIrregular(start,end);
			if(irrs!=null) return irrs;	
			irrs = restoreLIrregular(start,end);
			if(irrs!=null) return irrs;		
			irrs = restoreHIrregular(start,end);
			if(irrs!=null) return irrs;	
			irrs = restoreUIrregular(start,end);
			if(irrs!=null) return irrs;		
			irrs = restoreRUIrregular(start,end);
			if(irrs!=null) return irrs;						
		}else if(jasos.length>1&&jasos[0]=='��'&&jasos[1]=='��') {			
			String[] irrs = restoreDIrregular(start,end);
			if(irrs!=null) return irrs;		
			irrs = restoreSIrregular(start,end);
			if(irrs!=null) return irrs;				
		}else if(("��".equals(start)&&"�Ŷ�".equals(end))||
				("��".equals(start)&&"�ʶ�".equals(end))) {			
			return new String[]{start,end};
		}
		
		return null;
		
	}
	
	/**
	 * �� �ұ�Ģ ������ �����Ѵ�. (����, ����)
	 * @param start
	 * @param end
	 * @return
	 * @throws MorphException
	 */
	private static String[] restoreBIrregular(String start, String end) throws MorphException {

		if(start==null||"".equals(start)||end==null) return null;
	    
	    if(start.length()<2) return null;
	    
	    if(!(start.endsWith("��")||start.endsWith("��"))) return null;
	    
	    char convEnd = MorphUtil.makeChar(end.charAt(0), 0);
		if("��".equals(end)||"��".equals(end)||"��".equals(end)||
				convEnd=='��'||convEnd=='��') { // ����(��), ���(��), ������(����) ������ �����ǹǷ� �ݵ�� 2�� �̻���
			
			char ch = start.charAt(start.length()-2);
			ch = MorphUtil.makeChar(ch, 17);
		
			if(start.length()>2) 
				start = Utilities.arrayToString(new String[]{start.substring(0,start.length()-2),Character.toString(ch)});
			else
				start = Character.toString(ch);		

			WordEntry entry = DictionaryUtil.getVerb(start);
			if(entry!=null&&entry.getFeature(WordEntry.IDX_REGURA)==IRR_TYPE_BIUP)
				return new String[]{start,end};			
		}
			

		return null; 		
	}
	
	/**
	 * �� �ұ�Ģ ������ �����Ѵ�. (���ݴ�, ����)
	 * @param start
	 * @param end
	 * @return
	 * @throws MorphException
	 */
	private static String[] restoreDIrregular(String start, String end) throws MorphException {
		if(start==null||"".equals(start)) return null;
		
		char ch = start.charAt(start.length()-1);
		char[] jasos = MorphUtil.decompose(ch);
		if(jasos.length!=3||jasos[2]!='��') return null;
		
		ch = MorphUtil.makeChar(ch, 7);
		if(start.length()>1) 
			start = Utilities.arrayToString(new String[]{start.substring(0,start.length()-1),Character.toString(ch)});
		else
			start = Character.toString(ch);
		
		WordEntry entry = DictionaryUtil.getVerb(start);
		if(entry!=null&&entry.getFeature(WordEntry.IDX_REGURA)==IRR_TYPE_DI)
			return new String[]{start,end};
		
		return null;
	}
	
	/**
	 * �� �ұ�Ģ ������ �����Ѵ�. (�ߴ�--�׾�)
	 * @param start
	 * @param end
	 * @return
	 * @throws MorphException
	 */
	private static String[] restoreSIrregular(String start, String end) throws MorphException {
		if(start==null||"".equals(start)) return null;
		
		char ch = start.charAt(start.length()-1);
		char[] jasos = MorphUtil.decompose(ch);
		if(jasos.length!=2) return null;
		
		ch = MorphUtil.makeChar(ch, 19);
		if(start.length()>1) 
			start = start.substring(0,start.length()-1)+ch;
		else
			start = Character.toString(ch);
		
		WordEntry entry = DictionaryUtil.getVerb(start);
		if(entry!=null&&entry.getFeature(WordEntry.IDX_REGURA)==IRR_TYPE_SIUT)
			return new String[]{start,end};

		return null;
	}

	/**
	 * �� �ұ�Ģ ������ �����Ѵ�. (�帣��-->�귯)
	 * "������"�� ���ұ�Ģ�� �ƴ�����.. �� ��ó�� ó���Ѵ�.
	 * @param start
	 * @param end
	 * @return
	 * @throws MorphException
	 */
	private static String[] restoreLIrregular(String start, String end) throws MorphException {

		if(start.length()<2) return null;
		
		char ch1 = start.charAt(start.length()-2);
		char ch2 = start.charAt(start.length()-1);
		
		char[] jasos1 = MorphUtil.decompose(ch1);
		

		if(((jasos1.length==3&&jasos1[2]=='��')||jasos1.length==2)&&(ch2=='��'||ch2=='��')) {
	
			StringBuffer sb = new StringBuffer();
			
			ch1 = MorphUtil.makeChar(ch1, 0);
			if(start.length()>2) 
				sb.append(start.substring(0,start.length()-2)).append(ch1).append("��");
			else
				sb.append(Character.toString(ch1)).append("��");

			WordEntry entry = DictionaryUtil.getVerb(sb.toString());
			if(entry!=null&&entry.getFeature(WordEntry.IDX_REGURA)==IRR_TYPE_LOO)
				return new String[]{sb.toString(),end};		
			
		}
		
		return null;
	}
	
	/**
	 * ���ұ�Ģ ������ �����Ѵ�. (���-->��, �˴�-->��)
	 * ��� ���Ҹ��� �������� ������, ������, ������, ������, ���á� �տ��� Ż���ϴ� Ȱ���� ����
	 * @param start
	 * @param end
	 * @return
	 * @throws MorphException
	 */
	private static String[] restoreELIrregular(String start, String end) throws MorphException {

		if(start==null || start.length()==0 || end==null||end.length()==0) return null;
	        
	    if(!(end.charAt(0)=='��'||end.charAt(0)=='��'||end.charAt(0)=='��'||end.charAt(0)=='��'||end.charAt(0)=='��')) return null;
	    
	    char convEnd = MorphUtil.makeChar(start.charAt(start.length()-1), 8);
	    start = start.substring(0,start.length()-1)+convEnd;

		WordEntry entry = DictionaryUtil.getVerb(start);
		if(entry!=null)
			return new String[]{start,end};	
		
		return null;
	}
	
	/**
	 * �� �ұ�Ģ ������ �����Ѵ�. (�̸���->�̸���, Ǫ����->Ǫ����)
	 * @param start
	 * @param end
	 * @return
	 * @throws MorphException
	 */
	private static String[] restoreRUIrregular(String start, String end) throws MorphException {

		if(start.length()<2) return null;
		
		char ch1 = start.charAt(start.length()-1);
		char ch2 = start.charAt(start.length()-2);
		
		char[] jasos1 = MorphUtil.decompose(ch1);
		char[] jasos2 = MorphUtil.decompose(ch2);
		if(jasos1[0]!='��'||jasos2[0]!='��') return null;
		
		ch2 = MorphUtil.makeChar(ch2, 0);
		if(start.length()>2) 
			start = start.substring(0,start.length()-1);
		else
			start = Character.toString(ch2);

		WordEntry entry = DictionaryUtil.getVerb(start);
		if(entry!=null&&entry.getFeature(WordEntry.IDX_REGURA)==IRR_TYPE_RU)
			return new String[]{start,end};
		
		return null;
	}
	
	/**
	 * �� Ż�� ������ �����Ѵ�. (��Ĵ�-->�,��ż�)
	 * @param start
	 * @param end
	 * @return
	 * @throws MorphException
	 */
	private static String[] restoreHIrregular(String start, String end) throws MorphException {
		if(start==null||"".equals(start)||end==null||"".equals(end)) return null;
		char ch1 = end.charAt(0);
		char ch2 = start.charAt(start.length()-1);
		
		char[] jasos1 = MorphUtil.decompose(ch1);
		char[] jasos2 = MorphUtil.decompose(ch2);
		
		if(jasos1.length==1) {
			ch2 = MorphUtil.makeChar(ch2, 27);
		}else {
			if(jasos2.length!=2||jasos2[1]!='��') return null;
			ch2 = MorphUtil.makeChar(ch2, 0, 27);
		}
						
		if(start.length()>1) 
			start = start.substring(0,start.length()-1)+ch2;
		else
			start = Character.toString(ch2);

		WordEntry entry = DictionaryUtil.getVerb(start);
		if(entry!=null&&entry.getFeature(WordEntry.IDX_REGURA)==IRR_TYPE_HIOOT)
			return new String[]{start,end};
		
		return null;
	}	

	/**
	 * �� Ż�� ������ �����Ѵ�. (�ߴ�->��, ũ��-Ŀ)
	 * @param start
	 * @param end
	 * @return
	 * @throws MorphException
	 */
	private static String[] restoreUIrregular(String start, String end) throws MorphException {
		if(start==null||"".equals(start)) return null;
		char ch = start.charAt(start.length()-1);		
		char[] jasos = MorphUtil.decompose(ch);
		if(!(jasos.length==2&&jasos[1]=='��')) return null;
		
		ch = MorphUtil.makeChar(ch, 18,0);

		if(start.length()>1) 
			start = start.substring(0,start.length()-1)+ch;
		else
			start = Character.toString(ch);

		WordEntry entry = DictionaryUtil.getVerb(start);
		if(entry!=null)	return new String[]{start,end};
	
		return null;
	}	
	
}
