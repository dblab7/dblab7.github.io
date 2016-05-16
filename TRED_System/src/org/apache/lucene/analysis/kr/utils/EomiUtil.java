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

public class EomiUtil {

	
	public static final String RESULT_FAIL = "0";
	
	public static final String RESULT_SUCCESS = "1";
	
	public static final String[] verbSuffix = {
		  "��","��","��","����","������","��Ű","��","��","��","����","����","�帮","��","��","��"
	};
	
	/**
	 * ���� ���̰� �� ��̸� �и��Ѵ�.
	 * @param term
	 * @return
	 * @throws MorphException
	 */
	public static String[] longestEomi(String term) throws MorphException  {
		
		String[] result = new String[2];
		result[0] = term;
		
		String stem;
		String eomi;
		char[] efeature;
		
		for(int i=term.length();i>0;i--) {
			
			stem = term.substring(0,i);			
		
			if(i!=term.length()) {
				eomi = term.substring(i);
				efeature  = SyllableUtil.getFeature(eomi.charAt(0));				
			} else {
				efeature = SyllableUtil.getFeature(stem.charAt(i-1));
				eomi="";
			}

			if(SyllableUtil.isAlpanumeric(stem.charAt(i-1))) break;
			
			char[] jasos = MorphUtil.decompose(stem.charAt(i-1));
	
			if(!"".equals(eomi)&&!DictionaryUtil.existEomi(eomi)) {
				// do not anything.
			} else if(jasos.length>2&&
					(jasos[2]=='��'||jasos[2]=='��'||jasos[2]=='��'||jasos[2]=='��')&&
					DictionaryUtil.combineAndEomiCheck(jasos[2], eomi)!=null) {
				result[0] = Character.toString(MorphUtil.makeChar(stem.charAt(i-1), 0));
				if(i!=0) result[0] = stem.substring(0,i-1)+result[0];
				result[1] = Character.toString(jasos[2]);
			}else if(i>0&&(stem.endsWith("��")&&"��".equals(eomi))||
					(stem.endsWith("��")&&"�Ŷ�".equals(eomi))||
					(stem.endsWith("��")&&"�ʶ�".equals(eomi))) {
				result[0] = stem;
				result[1] = eomi;			
			}else if(jasos.length==2&&(!stem.endsWith("��")&&!stem.endsWith("��"))&&
					(jasos[1]=='��'||jasos[1]=='��'||jasos[1]=='��'||jasos[1]=='��')&&
					(DictionaryUtil.combineAndEomiCheck('��', eomi)!=null)) {		
				char[] chs = MorphUtil.decompose(stem.charAt(stem.length()-1));				
				result[0] = stem;
				result[1] = "��"+eomi;
			}else if((jasos[1]=='��'||jasos[1]=='��'||jasos[1]=='��'||jasos[1]=='��'||jasos[1]=='��')&&
					(DictionaryUtil.combineAndEomiCheck('��', eomi)!=null)) {				
				String end = "";				
				if(jasos[1]=='��')
					end=MorphUtil.makeChar(stem.charAt(i-1), 8, 0)+"��";	
				else if(jasos[1]=='��')
					end=MorphUtil.makeChar(stem.charAt(i-1), 13, 0)+"��";	
				else if(jasos[1]=='��')
					end=Character.toString(MorphUtil.makeChar(stem.charAt(i-1), 6, 0));
				else if(jasos[1]=='��')
					end=MorphUtil.makeChar(stem.charAt(i-1), 0, 0)+"��";	
				else if(jasos[1]=='��')
					end=MorphUtil.makeChar(stem.charAt(i-1), 20, 0)+"��";										
				
				if(jasos.length==3) {					
					end = end.substring(0,end.length()-1)+MorphUtil.replaceJongsung(end.charAt(end.length()-1),stem.charAt(i-1));
				}
				
				if(stem.length()<2) result[0] = end;
				else result[0] = stem.substring(0,stem.length()-1)+end;
				result[1] = eomi;	
				
			}else if(efeature!=null&&efeature[SyllableUtil.IDX_EOMI1]!='0'&&
				DictionaryUtil.existEomi(eomi)) {
				if(!(((jasos.length==2&&jasos[0]=='��')||(jasos.length==3&&jasos[2]=='��'))&&eomi.equals("��"))) { // �� �ұ�Ģ�� ����
					result[0] = stem;
					result[1] = eomi;
				}
			}

			if(efeature!=null&&efeature[SyllableUtil.IDX_EOMI2]=='0') break;
		}	

		return result;
		
	}	
	
	/**
	 * �����̸� �м��Ѵ�.
	 * @param stem
	 * @return
	 */
	public static String[] splitPomi(String stem) throws MorphException  {

		//	 results[0]:����(1)/����(0), results[1]: ���, results[2]: ������
		String[] results = new String[2];  
		results[0] = stem;

		if(stem==null||stem.length()==0||"��".equals(stem)) return results;
	
		char[] chrs = stem.toCharArray();
		int len = chrs.length;
		String pomi = "";
		int index = len-1;
	
		char[] jaso = MorphUtil.decompose(chrs[index]);
		if(chrs[index]!='��'&&chrs[index]!='��'&&jaso[jaso.length-1]!='��') return results;  // �����̰� �߰ߵ��� �ʾҴ�
		
		if(chrs[index]=='��') {
			pomi = "��";
			setPomiResult(results,stem.substring(0,index),pomi);		
			if(--index<=0||
					(chrs[index]!='��'&&chrs[index]!='��'&&jaso[jaso.length-1]!='��')) 
				return results; // �����̰ų� �����̰� ���ٸ�...
			jaso = MorphUtil.decompose(chrs[index]);
		}

		if(chrs[index]=='��') { // �þ�, ����, ��
			pomi = chrs[index]+pomi;	
			setPomiResult(results,stem.substring(0,index),pomi);		
			if(--index<=0||
					(chrs[index]!='��'&&chrs[index]!='��'&&jaso[jaso.length-1]!='��')) 
				return results; // �����̰ų� �����̰� ���ٸ�...				
			jaso = MorphUtil.decompose(chrs[index]);
		}

		if(chrs[index]=='��'){
			pomi = MorphUtil.replaceJongsung('��',chrs[index])+pomi;	
			if(index>0&&chrs[index-1]=='��') 
				stem = stem.substring(0,index);	
			else
				 stem = stem.substring(0,index)+"��";
			setPomiResult(results,stem,pomi);	
		}else if(chrs[index]=='��'){
				pomi = MorphUtil.replaceJongsung('��',chrs[index])+pomi;	
				stem = stem.substring(0,index);		
				setPomiResult(results,stem,"��"+pomi);				
		}else if(chrs[index]=='��'||chrs[index]=='��') {
			pomi = chrs[index]+pomi;	
			setPomiResult(results,stem.substring(0,index),pomi);		
			if(--index<=0||
					(chrs[index]!='��'&&chrs[index]!='��')) return results; // �����̰ų� �����̰� ���ٸ�...				
			jaso = MorphUtil.decompose(chrs[index]);		
		}else if(jaso.length==3&&jaso[2]=='��') {
		
			 if(jaso[0]=='��'&&jaso[1]=='��') {			 
				pomi = MorphUtil.replaceJongsung('��',chrs[index])+pomi;	
				stem = stem.substring(0,index)+"��";	
			}else if(jaso[0]!='��'&&(jaso[1]=='��'||jaso[1]=='��'||jaso[1]=='��'||jaso[1]=='��')) {		
				pomi = "��"+pomi;
				stem = stem.substring(0,index)+MorphUtil.makeChar(chrs[index], 0);				
			}else if(jaso[0]!='��'&&(jaso[1]=='��')) {
				pomi = "��"+pomi;
				stem = stem.substring(0,index)+MorphUtil.makeChar(chrs[index],11, 0);				
			} else if(jaso[1]=='��') {			
				pomi = MorphUtil.replaceJongsung('��',chrs[index])+pomi;	
				stem = stem.substring(0,index)+MorphUtil.makeChar(chrs[index],8, 0);
			} else if(jaso[1]=='��') {
				pomi = MorphUtil.replaceJongsung('��',chrs[index])+pomi;	
				stem = stem.substring(0,index)+MorphUtil.makeChar(chrs[index],13, 0);
			} else if(jaso[1]=='��') {					
				pomi = MorphUtil.replaceJongsung('��',chrs[index])+pomi;				
				stem = stem.substring(0,index)+MorphUtil.makeChar(chrs[index],20, 0);					
			} else if(jaso[1]=='��') {
				pomi = MorphUtil.replaceJongsung('��',chrs[index])+pomi;
				stem = stem.substring(0,index);
			} else if(jaso[1]=='��') {
				pomi = MorphUtil.replaceJongsung('��',chrs[index])+pomi;	
				stem = stem.substring(0,index);
			} else {
				pomi = "��"+pomi;
			}
			setPomiResult(results,stem,pomi);				
			if(chrs[index]!='��'&&chrs[index]!='��') return results; // �����̰ų� �����̰� ���ٸ�...				
			jaso = MorphUtil.decompose(chrs[index]);				
		}

		char[] nChrs = null;
		if(index>0) nChrs = MorphUtil.decompose(chrs[index-1]);
		else nChrs = new char[2];

		if(nChrs.length==2&&chrs[index]=='��'&&(chrs.length<=index+1||
				(chrs.length>index+1&&chrs[index+1]!='��'))) {
			if(DictionaryUtil.getWord(results[0])!=null) return results;  //'��'�� ���Ե� �ܾ �ִ�. �����ô�/���ô�/�龥�ô� 
			pomi = chrs[index]+pomi;	
			setPomiResult(results,stem.substring(0,index),pomi);			
			if(--index==0||chrs[index]!='��') return results; // �����̰ų� �����̰� ���ٸ�...				
			jaso = MorphUtil.decompose(chrs[index]);
		}
		
		if(index>0) nChrs = MorphUtil.decompose(chrs[index-1]);
		else nChrs = new char[2];
		if(chrs.length>index+1&&nChrs.length==3&&(chrs[index+1]=='��'||chrs[index+1]=='��')&&chrs[index]=='��') {
			pomi = chrs[index]+pomi;	
			setPomiResult(results,stem.substring(0,index),pomi);		
		}
	
		return results;
	}
	
	/**
	 * �ұ�Ģ ����� ������ ���Ѵ�.
	 * @param output
	 * @return
	 * @throws MorphException
	 */
	public static List irregular(AnalysisOutput output) throws MorphException {
		
		List results = new ArrayList();
	
		if(output.getStem()==null||output.getStem().length()==0) 
			return results;		
		
		String ending = output.getEomi();
		if(output.getPomi()!=null) ending = output.getPomi();
		
		List<String[]> irrs = new ArrayList();
		
		irregularStem(irrs,output.getStem(),ending);
		irregularEnding(irrs,output.getStem(),ending);
		irregularAO(irrs,output.getStem(),ending);

		try {
			for(String[] irr: irrs) {
				AnalysisOutput result = output.clone();
				result.setStem(irr[0]);
				if(output.getPatn()==PatternConstants.PTN_VM) {
					if(output.getPomi()==null) result.setEomi(irr[1]);
					else result.setPomi(irr[1]);
				}	
				results.add(result);
			}				
		} catch (CloneNotSupportedException e) {
			throw new MorphException(e.getMessage(),e);
		}
				
		return results;
		
	}
	
	/**
	 * ��� ���ϴ� ���
	 * @param results
	 * @param stem
	 * @param ending
	 */
	private static void irregularStem(List results, String stem, String ending) {	

		char feCh = ending.charAt(0);
		char[] fechJaso =  MorphUtil.decompose(feCh);
		char ls = stem.charAt(stem.length()-1);
		char[] lsJaso = MorphUtil.decompose(ls);
	
		if(feCh=='��'||feCh=='��'||feCh=='��') {
			if(lsJaso[lsJaso.length-1]=='��') { // �� �ұ�Ģ
				results.add(
						new String[]{stem.substring(0,stem.length()-1)+
								MorphUtil.makeChar(stem.charAt(stem.length()-1),7)
								,ending
								,String.valueOf(PatternConstants.IRR_TYPE_DI)});
			} else if(lsJaso.length==2) { // �� �ұ�Ģ
				results.add(
						new String[]{stem.substring(0,stem.length()-1)+
								MorphUtil.makeChar(stem.charAt(stem.length()-1),19)
								,ending
								,String.valueOf(PatternConstants.IRR_TYPE_SI)});				
			}			
		}
		
		if((fechJaso[0]=='��'||fechJaso[0]=='��'||fechJaso[0]=='��'||	feCh=='��'||feCh=='��')
				&&(ls=='��')) { // �� �ұ�Ģ
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
							MorphUtil.makeChar(stem.charAt(stem.length()-1),17)
							,ending
							,String.valueOf(PatternConstants.IRR_TYPE_BI)});				
		}
		
		if((fechJaso[0]=='��'||fechJaso[0]=='��'||fechJaso[0]=='��'||	feCh=='��')
				&&(lsJaso.length==2)) { // �� Ż��

			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
							MorphUtil.makeChar(stem.charAt(stem.length()-1),8)
							,ending
							,String.valueOf(PatternConstants.IRR_TYPE_LI)});			
		}
		
		if(lsJaso.length==2
				&&(fechJaso[0]=='��'||fechJaso[0]=='��'||fechJaso[0]=='��'||fechJaso[0]=='��'||
					lsJaso[1]=='��'||lsJaso[1]=='��'||lsJaso[1]=='��'||lsJaso[1]=='��')
					&&!"��".equals(stem)) { // �� �ұ�Ģ, �׷��� [����]�� �� �ұ�Ģ�� �ƴϴ�.
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
							MorphUtil.makeChar(stem.charAt(stem.length()-1),27)
							,ending
							,String.valueOf(PatternConstants.IRR_TYPE_HI)});			
		}		
	}
	
	/**
	 * ��̸� ���ϴ� ���
	 * @param results
	 * @param stem
	 * @param ending
	 */
	private static void irregularEnding(List results, String stem, String ending) {
		if(ending.startsWith("��")) return;
		
		char feCh = ending.charAt(0);
		char ls = stem.charAt(stem.length()-1);

		if(feCh=='��'&&ls=='��') { // '��' �ұ�Ģ
			results.add(
					new String[]{stem
							,"��"+ending.substring(1)
							,String.valueOf(PatternConstants.IRR_TYPE_RO)});				
		} else if("��".equals(ending)&&"����".equals(stem)) { // '�Ŷ�' �ұ�Ģ
			results.add( 
					new String[]{stem.substring(0,stem.length()-1)
							,"���"
							,String.valueOf(PatternConstants.IRR_TYPE_GU)});							
		} else if("��".equals(ending)&&"����".equals(stem)) { // '�ʶ�' �ұ�Ģ
			results.add(
					new String[]{stem.substring(0,stem.length()-1)
							,"���"
							,String.valueOf(PatternConstants.IRR_TYPE_NU)});			
		}
		
		if("��".equals(ending)&&ls=='��') { // '��' �ұ�Ģ
			results.add(
					new String[]{stem
							,"��"
							,String.valueOf(PatternConstants.IRR_TYPE_NU)});				
		}
	}
	
	/**
	 * ��� ��̰� ��� ���ϴ� ���
	 * @param results
	 * @param stem
	 * @param ending
	 */
	private static void irregularAO(List results, String stem, String ending) {
		
		char ls = stem.charAt(stem.length()-1);
		char[] lsJaso = MorphUtil.decompose(ls);
		
		if(lsJaso.length<2) return;
		
		if(lsJaso[1]=='��') {
			if(stem.endsWith("����")||stem.endsWith("���")) { // '����', '����'�� '��' �ұ�Ģ
				results.add(
						new String[]{stem.substring(0,stem.length()-2)+
								MorphUtil.makeChar(stem.charAt(stem.length()-2),17) // + '��'
								,makeTesnseEomi("��",ending)
								,String.valueOf(PatternConstants.IRR_TYPE_BI)});					
			}else { // '��' ���
				results.add(
						new String[]{stem.substring(0,stem.length()-1)+
								MorphUtil.makeChar(stem.charAt(stem.length()-1),8,0) // ���� + �� 
								,makeTesnseEomi("��",ending)
								,String.valueOf(PatternConstants.IRR_TYPE_WA)});				
			}
		} else if(stem.endsWith("��")) {
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
							MorphUtil.makeChar(stem.charAt(stem.length()-1),18,0) // ���� + - 
							,makeTesnseEomi("��",ending)
							,String.valueOf(PatternConstants.IRR_TYPE_WA)});	
		} else if(lsJaso[1]=='��') {
			if(stem.length()>=2) // '��' �ұ�Ģ
				results.add(
					new String[]{stem.substring(0,stem.length()-2)+
						MorphUtil.makeChar(stem.charAt(stem.length()-2),17) // + '��'
					   ,makeTesnseEomi("��",ending)
					   ,String.valueOf(PatternConstants.IRR_TYPE_BI)});	

			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
							MorphUtil.makeChar(stem.charAt(stem.length()-1),13,0) // ���� + �� 
							,makeTesnseEomi("��",ending)
							,String.valueOf(PatternConstants.IRR_TYPE_WA)});	
		} else if(stem.length()>=2&&ls=='��') {
			char[] ns = MorphUtil.decompose(stem.charAt(stem.length()-2));
			if(ns.length==3&&ns[2]=='��') { // �� �ұ�Ģ
				results.add(
						new String[]{stem.substring(0,stem.length()-2)+
							MorphUtil.makeChar(stem.charAt(stem.length()-2),0) + "��"
						   ,makeTesnseEomi("��",ending)
						   ,String.valueOf(PatternConstants.IRR_TYPE_RO)});					
			}			
		} else if(stem.length()>=2&&ls=='��') {
			char[] ns = MorphUtil.decompose(stem.charAt(stem.length()-2));
			if(stem.charAt(stem.length()-2)=='��') { // �� �ұ�Ģ
				results.add(
						new String[]{stem.substring(0,stem.length()-1)
						   ,makeTesnseEomi("��",ending)
						   ,String.valueOf(PatternConstants.IRR_TYPE_LO)});	
			} else if(ns.length==3&&ns[2]=='��') { // �� �ұ�Ģ
				results.add(
						new String[]{stem.substring(0,stem.length()-2)+
							MorphUtil.makeChar(stem.charAt(stem.length()-2),0) + "��"
						   ,makeTesnseEomi("��",ending)
						   ,String.valueOf(PatternConstants.IRR_TYPE_RO)});	
			}
		} else if(stem.endsWith("��")||stem.endsWith("��")) {
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
						MorphUtil.makeChar(stem.charAt(stem.length()-1),20,0)
					   ,makeTesnseEomi("��",ending)
					   ,String.valueOf(PatternConstants.IRR_TYPE_EI)});	
		} else if(stem.endsWith("��")) {
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
						MorphUtil.makeChar(stem.charAt(stem.length()-1),0,0)
					   ,makeTesnseEomi("��",ending)
					   ,String.valueOf(PatternConstants.IRR_TYPE_EI)});				
		} else if(lsJaso.length==2&&lsJaso[1]=='��') {
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
						MorphUtil.makeChar(stem.charAt(stem.length()-1),18,0)
					   ,makeTesnseEomi("��",ending)
					   ,String.valueOf(PatternConstants.IRR_TYPE_UO)});	
		} else if(lsJaso.length==2&&lsJaso[1]=='��') {
			// �� Ż��
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
						MorphUtil.makeChar(stem.charAt(stem.length()-1),18,0)
					   ,makeTesnseEomi("��",ending)
					   ,String.valueOf(PatternConstants.IRR_TYPE_UO)});	
			//	 �� �ұ�Ģ
			results.add(
					new String[]{stem
					   ,makeTesnseEomi("��",ending)
					   ,String.valueOf(PatternConstants.IRR_TYPE_AH)});	
		} else if(lsJaso[1]=='��') {
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
						MorphUtil.makeChar(stem.charAt(stem.length()-1),20,0)
					   ,makeTesnseEomi("��",ending)
					   ,String.valueOf(PatternConstants.IRR_TYPE_EI)});	
		} else if(lsJaso[1]=='��') {
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
						MorphUtil.makeChar(stem.charAt(stem.length()-1),11,0)
					   ,makeTesnseEomi("��",ending)
					   ,String.valueOf(PatternConstants.IRR_TYPE_OE)});	
		} else if(lsJaso[1]=='��') {
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
						MorphUtil.makeChar(stem.charAt(stem.length()-1),0,27)
					   ,makeTesnseEomi("��",ending)
					   ,String.valueOf(PatternConstants.IRR_TYPE_HI)});
		} else if(lsJaso[1]=='��') {
			results.add(
					new String[]{stem.substring(0,stem.length()-1)+
						MorphUtil.makeChar(stem.charAt(stem.length()-1),2,27)
					   ,makeTesnseEomi("��",ending)
					   ,String.valueOf(PatternConstants.IRR_TYPE_HI)});							
		}
		
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
				MorphUtil.makeChar(preword.charAt(preword.length()-1),20)+endword.substring(1,endword.length());		
		} else if(endword.charAt(0)=='��') {
			return preword.substring(0,preword.length()-1)+
			MorphUtil.makeChar(preword.charAt(preword.length()-1),4)+endword.substring(1,endword.length());
		} else if(endword.charAt(0)=='��') {
			return preword.substring(0,preword.length()-1)+
			MorphUtil.makeChar(preword.charAt(preword.length()-1),8)+endword.substring(1,endword.length());	
		} else if(endword.charAt(0)=='��') {
			return preword.substring(0,preword.length()-1)+
			MorphUtil.makeChar(preword.charAt(preword.length()-1),16)+endword.substring(1,endword.length());					
		} else if(endword.charAt(0)=='��') {
			return preword.substring(0,preword.length()-1)+
			MorphUtil.makeChar(preword.charAt(preword.length()-1),17)+endword.substring(1,endword.length());
		}
		return preword+endword;		
	}
	
	
 
   /**
    * '��/��' + '��' + ���, '����/����/��������' + '��' + ��� ���� �����Ѵ�.
    * @param stem
    * @return
    */
   public static boolean endsWithEEomi(String stem) {
	   int len = stem.length();
	   if(len<2||!stem.endsWith("��")) return false;
	  
	   char[] jasos = MorphUtil.decompose(stem.charAt(len-2));
	   if(jasos.length==3&&jasos[2]=='��')
		   return true;
	   else {
		   int index = stem.lastIndexOf("��");
		   if(index==-1) index = stem.lastIndexOf("����");
		   if(index==-1) index = stem.lastIndexOf("����");
		   if(index==-1) return false;
		   return true;
	   }
   }
   
	private static void setPomiResult(String[] results,String stem, String pomi ) {
		results[0] = stem;
		results[1] = pomi;
	}	
	
	/**
	 * 
	 * @param ch
	 * @return
	 */
	public static boolean IsNLMBSyl(char ech, char lch) throws MorphException {
	
		char[] features = SyllableUtil.getFeature(ech);

		switch(lch) {

			case '��' :
				return (features[SyllableUtil.IDX_YNPNA]=='1' || features[SyllableUtil.IDX_YNPLN]=='1');				
			case '��' :
				return (features[SyllableUtil.IDX_YNPLA]=='1');
			case '��' :
				return (features[SyllableUtil.IDX_YNPMA]=='1');		
			case '��' :
				return (features[SyllableUtil.IDX_YNPBA]=='1');					
		}
	
		return false;
	}
	
	/**
	 * ��̸� �и��Ѵ�.
	 * 
	 * 1. ��Ģ���� ��� �ٲ�� �ұ�Ģ ���
	 * 2. ��̰� ���� '��/��/��/��'���� ���۵Ǵ� ����
	 * 3. '��/�Ŷ�/�ʶ�'�� �ұ�Ģ ����
	 * 4. ��� '��/��'�� Ż���Ǵ� ����
	 * 5. '��/��'�� ����ü �и�
	 * 
	 * @param stem
	 * @param end
	 * @return
	 * @throws MorphException
	 */
	public static String[] splitEomi(String stem, String end) throws MorphException {

		String[] strs = new String[2];
		int strlen = stem.length();
		if(strlen==0) return strs;

		char estem = stem.charAt(strlen-1);
		char[] chrs = MorphUtil.decompose(estem);
		if(chrs.length==1) return strs; // �ѱ��� �ƴ϶��...

		if((chrs.length==3)&&(chrs[2]=='��'||chrs[2]=='��'||chrs[2]=='��'||chrs[2]=='��')&&
				EomiUtil.IsNLMBSyl(estem,chrs[2])&&
				DictionaryUtil.combineAndEomiCheck(chrs[2], end)!=null) {		
			strs[1] = Character.toString(chrs[2]);
			if(end.length()>0) strs[1] += end;
			strs[0] = stem.substring(0,strlen-1) + MorphUtil.makeChar(estem, 0);	
		} else if(estem=='��'&&DictionaryUtil.existEomi("��"+end)) {			
			strs[0] = stem.substring(0,strlen-1)+"��";
			strs[1] = "��"+end;	
		} else if(estem=='��'&&DictionaryUtil.existEomi("��"+end)) {			
			strs[0] = stem.substring(0,strlen-1)+"��";
			strs[1] = "��"+end;				
		} else if(chrs[0]!='��'&&
				(chrs[1]=='��'||chrs[1]=='��'||chrs[1]=='��'||chrs[1]=='��')&&
				(chrs.length==2 || SyllableUtil.getFeature(estem)[SyllableUtil.IDX_YNPAH]=='1')&&
				(DictionaryUtil.combineAndEomiCheck('��', end)!=null)) {		
		
			strs[0] = stem;
			if(chrs.length==2) strs[1] = "��"+end;	
			else strs[1] = end;	
		} else if(stem.endsWith("��")&&"��".equals(end)) {			
			strs[0] = stem;
			strs[1] = "��";	
		}else if((chrs.length==2)&&(chrs[1]=='��'||chrs[1]=='��'||chrs[1]=='��'||chrs[1]=='��'||chrs[1]=='��'||chrs[1]=='��')&&
				(DictionaryUtil.combineAndEomiCheck('��', end)!=null)) {		
	
			StringBuffer sb = new StringBuffer();
			
			if(strlen>1) sb.append(stem.substring(0,strlen-1));
			
			if(chrs[1]=='��')
				sb.append(MorphUtil.makeChar(estem, 8, 0)).append(MorphUtil.replaceJongsung('��',estem));	
			else if(chrs[1]=='��')
				sb.append(MorphUtil.makeChar(estem, 13, 0)).append(MorphUtil.replaceJongsung('��',estem));	
			else if(chrs[1]=='��')
				sb.append(MorphUtil.makeChar(estem, 11, 0)).append(MorphUtil.replaceJongsung('��',estem));				
			else if(chrs[1]=='��')
				sb.append(Character.toString(MorphUtil.makeChar(estem, 20, 0))).append(MorphUtil.replaceJongsung('��',estem));
			else if(chrs[1]=='��')
				sb.append(MorphUtil.makeChar(estem, 0, 0)).append(MorphUtil.replaceJongsung('��',estem));
			else if(chrs[1]=='��')
				sb.append(MorphUtil.makeChar(estem, 20, 0)).append(MorphUtil.replaceJongsung('��',estem));	
			
		
			strs[0] = sb.toString();
		
			end = strs[0].substring(strs[0].length()-1)+end;				
			strs[0] = strs[0].substring(0,strs[0].length()-1);
			
			strs[1] = end;		

		}else if(!"".equals(end)&&DictionaryUtil.existEomi(end)) {		
			strs = new String[]{stem, end};
		}

		return strs;
	}
}
