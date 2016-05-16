package org.apache.lucene.analysis.kr.utils;

import java.util.HashMap;

import java.util.Map;

import org.apache.lucene.analysis.kr.morph.PatternConstants;

/**
 * ������ ������ ������ ó���ϴ� Ŭ����
 * @author smlee
 *
 */
public class ConstraintUtil {

	private static Map hahes = new HashMap(); // "�۷ι�ȭ�� ", "����ȭ��" ó�� ȭ�ؿ� ������ ������ ���
	static {
		hahes.put("����", "Y");hahes.put("����", "Y");hahes.put("����", "Y");
	}
	
	private static Map eomiPnouns = new HashMap(); 
	static {
		eomiPnouns.put("��", "Y");eomiPnouns.put("��", "Y");eomiPnouns.put("��", "Y");
	}
	
	private static Map PTN_MLIST= new HashMap();
	static {
		PTN_MLIST.put(PatternConstants.PTN_NSM, PatternConstants.PTN_NSM);
		PTN_MLIST.put(PatternConstants.PTN_NSMXM, PatternConstants.PTN_NSMXM);
		PTN_MLIST.put(PatternConstants.PTN_NJCM, PatternConstants.PTN_NJCM);
		PTN_MLIST.put(PatternConstants.PTN_VM, PatternConstants.PTN_VM);
		PTN_MLIST.put(PatternConstants.PTN_VMCM, PatternConstants.PTN_VMCM);
		PTN_MLIST.put(PatternConstants.PTN_VMXM, PatternConstants.PTN_VMXM);
		PTN_MLIST.put(PatternConstants.PTN_NVM, PatternConstants.PTN_NVM);
	}
	
	private static Map PTN_JLIST= new HashMap();
	static {
		PTN_JLIST.put(PatternConstants.PTN_NJ, PatternConstants.PTN_NJ);
		PTN_JLIST.put(PatternConstants.PTN_NSMJ, PatternConstants.PTN_NSMJ);
		PTN_JLIST.put(PatternConstants.PTN_VMJ, PatternConstants.PTN_VMJ);
		PTN_JLIST.put(PatternConstants.PTN_VMXMJ, PatternConstants.PTN_VMXMJ);
	}
	
	private static Map WORD_GUKS= new HashMap();
	static {
		WORD_GUKS.put("����", "Y");
		WORD_GUKS.put("���", "Y");
		WORD_GUKS.put("����", "Y");
		WORD_GUKS.put("����", "Y");
		WORD_GUKS.put("Ż��", "Y");
		WORD_GUKS.put("���߰�", "Y");
	}
	
	// ������ �ִ� ������ ����� �� ���� ����
	private static Map JOSA_TWO= new HashMap();
	static {
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
		JOSA_TWO.put("��", "Y");
	}
	
	// ������ ���� ������ ����� �� ���� ����
	private static Map JOSA_THREE= new HashMap();
	static {
		JOSA_THREE.put("��", "Y");
		JOSA_THREE.put("��", "Y");
		JOSA_THREE.put("��", "Y");
		JOSA_THREE.put("��", "Y");
		JOSA_THREE.put("��", "Y");
		JOSA_THREE.put("��", "Y");
	}
	
	public static boolean canHaheCompound(String key) {
		if(hahes.get(key)!=null) return true;
		return false;
	}
		
	/**
	 * ��̰� ��,��,�� ���� �������� �����Ѵ�.
	 * @param eomi
	 * @return
	 */
	public static boolean isNLM(String eomi) {
		
		if(eomi==null || "".equals(eomi)) return false;
		
		if(eomiPnouns.get(eomi)!=null) return true;
		
		char[] chrs = MorphUtil.decompose(eomi.charAt(eomi.length()-1));
		if(chrs.length==3  && eomiPnouns.get(Character.toString(chrs[2]))!=null) return true;
		
		return true;
		
	}
	
	public static boolean isEomiPhrase(int ptn) {
		
		if(PTN_MLIST.get(ptn)!=null) return true;
		
		return false;
		
	}
	
	public static boolean isJosaNounPhrase(int ptn) {
		
		if(PTN_JLIST.get(ptn)!=null) return true;
		
		return false;
		
	}
	
	public static boolean isJosaAdvPhrase(int ptn) {
		
		if(PatternConstants.PTN_ADVJ==ptn) return true;
		
		return false;
		
	}
	
	public static boolean isAdvPhrase(int ptn) {
		
		if(PatternConstants.PTN_ADVJ==ptn || PatternConstants.PTN_AID==ptn) return true;
		
		return false;
		
	}
	
	public static boolean isTwoJosa(String josa) {
		
		return (JOSA_TWO.get(josa)!=null);
		
	}
	public static boolean isThreeJosa(String josa) {
		
		return (JOSA_THREE.get(josa)!=null);
		
	}	
}
