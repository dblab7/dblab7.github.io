package org.apache.lucene.analysis.kr;

import org.apache.lucene.analysis.kr.utils.StringUtil;
import org.apache.lucene.analysis.kr.utils.VerbUtil;

import junit.framework.TestCase;

public class UtilitiesTest extends TestCase {

	public void testEndsWithVerbSuffix() throws Exception {
		String str = "����";
		int i = VerbUtil.endsWithVerbSuffix(str);
		if(i==-1) return;
		assertEquals("��", str.substring(i));
		System.out.println(i+":"+str.substring(i));
	}
	
	public void testEndsWithXVerb() throws Exception {
		String str = "�Ǿ����";
		int i = VerbUtil.endsWithXVerb(str);
		if(i==-1) return;
		assertEquals("����", str.substring(i));
		System.out.println(i+":"+str.substring(i));
	}	
	
}
