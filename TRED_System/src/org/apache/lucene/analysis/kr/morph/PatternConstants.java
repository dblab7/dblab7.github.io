package org.apache.lucene.analysis.kr.morph;

import java.util.HashMap;
import java.util.Map;

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

public interface PatternConstants {

	/** Hangul word patterns for KMA
	 */
	public static int PTN_N = 1;  //* ü�� : N/PN/NM/XN/CN/UN/AS/HJ/ET */
	public static int PTN_NJ = 2;  //* ü�� + ���� */
	public static int PTN_NSM = 3;  //* ü�� + ���ȭ���̻� + ��� */
	public static int PTN_NSMJ = 4;  //* ü�� + ���ȭ���̻� + '��/��' + ���� */
	public static int PTN_NSMXM =5;  //* ü�� + ���ȭ���̻� + '��/��' + ������� + ��� */
	public static int PTN_NJCM =  6; //* ü�� + '����/����/��������' + '��' + ��� */

	public static int PTN_VM  =  11;  //* ��� + ��� */
	public static int PTN_VMJ =  12; //* ��� + '��/��' + ���� */
	public static int PTN_VMCM = 13;  //* ��� + '��/��' + '��' + ��� */
	public static int PTN_VMXM = 14;  //* ��� + '��/��' + ������� + ��� */
	public static int PTN_VMXMJ= 15;  //* ��� + '��/��' + ������� + '��/��' + ���� */

	public static int PTN_AID =  21;  //* ���Ͼ� : �λ�, ������, ��ź�� */
	public static int PTN_ADVJ =  22;  //* �λ� + ���� : '������' */

	public static int PTN_NVM =  31;  //* ü�� + ���� + ��� */

	public static int PTN_ZZZ =  35;  //* �����ȣ, KS �ϼ��� ��ȣ��, �ܵ�����/��� */	
	

	/**
	 * Definition of sentence types and parts of speech
	 */
	
	//*         CLASSIFICATION OF SENTENCE PATTERNS              */
	public static char SPTN_DECL = 'D';       //* declarative sentence */
	public static char SPTN_QUES =  'Q';      //* question sentence    */
	public static char SPTN_IMPR =  'I';       //* imperative sentence  */
	public static char SPTN_TITL =  'T';       //* title of a paragraph */

	//*          CLASSIFICATION OF PARTS OF SPEECH               */
	//	3(basic) + 2(special) types of stem for 'pos'
	public static char POS_NPXM  =   'N';       //* noun, pnoun, xn, nume */
	public static char POS_VJXV  =   'V';       //* verb, adj, xverb      */
	public static char POS_AID   =   'Z';       //* adv, det, excl        */

	public static char POS_PUNC  =   'q';       //* punctuation mark:./,/( */
	public static char POS_SYMB  =   'Q';       //* special symbols       */

	//	normal types of stem for 'pos2'.
	//	Only some of following symbols are used.
	public static char POS_NOUN  =   'N';       //* noun                  */
	public static char POS_PNOUN  =  'P';       //* pronoun               */
	public static char POS_XNOUN  =  'U';       //* dependent noun        */
	public static char POS_NUMERAL = 'M';       //* numeral               */

	public static char POS_PROPER  = 'O';       //* proper noun: NOT USED */

	public static char POS_CNOUN  =  'C';       //* compound noun guessed */
	public static char POS_NOUNK  =  'u';       //* guessed as noun       */

	public static char POS_ASCall =  '@';       //* all alphanumeric chars*/
	public static char POS_ASCend =  '$';       //* end with alphanumeric */
	public static char POS_ASCmid =  '*';       //* ..+alphanumeric+Hangul*/

	//* defined for numeral to digit conversion */
	public static char POS_digits =  '1';       //* digit-string */
	public static char POS_digitH  = '2';       //* digit-string + Hangul*/

	public static char POS_VERB  =   'V';       //* verb                  */
	public static char POS_ADJ   =   'J';       //* adjective             */
	public static char POS_XVERB =   'W';       //* auxiliary verb        */
	public static char POS_XADJ  =   'K';       //* NOT USED YET          */

	public static char POS_ADV   =   'B';       //* adverb                */
	public static char POS_DET   =   'D';       //* determiner            */
	public static char POS_EXCL  =   'L';       //* exclamation           */

	public static char POS_JOSA   =  'j';       //* Korean Josa           */
	public static char POS_COPULA =  'c';       //* copula '-Wi-'         */
	public static char POS_EOMI   =  'e';       //* final Ending          */
	public static char POS_PEOMI  =  'f';       //* prefinal Ending       */
	public static char POS_NEOMI  =  'n';       //* nominalizing Eomi     */

	public static char POS_PREFIX =  'p';       //* prefixes              */
	public static char POS_SFX_N  =  's';       //* noun suffixes: '��/��'*/
	public static char POS_SFX_V  =  't';       //* verb suffixes: '��/��'*/

	public static char POS_ETC   =   'Z';       //* not decided yet       */

	/* ASCII stem may be classified as follows: NOT USED YET    */
	public static char POS_ALPHA  =  'A';       //* English alphabet      */
	public static char POS_NUMBER =  '#';       //* Arabic numbers        */
	public static char POS_SMARK  =  'R';       //* sentence markers      */

	public static char POS_NVERBK  = 'Y';       //* guessed as noun+verb  */

	public static char POS_SQUOTE  = 's';       //* single quotation      */
	public static char POS_DQUOTE  = 'd';       //* double quotation      */
	public static char POS_LPAREN  = 'l';       //* left parenthesis      */
	public static char POS_RPAREN  = 'r';       //* right parenthesis     */
	
	
	/**----------------------  �ұ�Ģ ���� ����  ------------------------ */	
	public static char IRR_TYPE_DI = 'd';  //* �� �ұ�Ģ
	public static char IRR_TYPE_BI = 'b'; //* �� �ұ�Ģ
	public static char IRR_TYPE_SI = 's'; //* �� �ұ�Ģ
	public static char IRR_TYPE_HI = 'h'; //* �� �ұ�Ģ
	public static char IRR_TYPE_RO = 'r'; //* �� �ұ�Ģ
	public static char IRR_TYPE_LO = 'l'; //* �� �ұ�Ģ
	public static char IRR_TYPE_OU = 'o'; // * �� �ұ�Ģ
	public static char IRR_TYPE_GU = 'g'; // *�Ŷ� �ұ�Ģ
	public static char IRR_TYPE_NU = 'n'; // * �ʶ� �ұ�Ģ
	public static char IRR_TYPE_YO = 'y'; // * �� �ұ�Ģ
	public static char IRR_TYPE_LI = 'L'; // * �� Ż��
	public static char IRR_TYPE_UO = 'u'; //�� Ż��
	public static char IRR_TYPE_AH = 'a'; // �� Ż��
	public static char IRR_TYPE_AE = 'e'; // �� ���
	public static char IRR_TYPE_WA = 'w'; // �� ���
	public static char IRR_TYPE_EI = 'e'; // �� ���
	public static char IRR_TYPE_OE = 'O'; // �� ���
		
	
	/**-----------------------  ������ ����ü ����  ------------------------
    *
	*JOSA_VAR_WiAb	-- '��/��', '��/��', '��/��', '��/��', '��/��' ���� ����
	*	'��/��/��/��/��'�� ��쿡 �� ���� set.
	*JOSA_VAR_Wz_tal	-- '��/����' ���� ���� (��) '�б���' --> '�б�'+'����'
	*	'��'�� Ż���Ǿ� ������ ��쿡 �� ���� set.
	*JOSA_VAR_Wi_tal	-- ���� '��'�� '�̰�', '���'�� '�̶��' ���� ����
	*	'��'�� �����Ǿ� ������ ��쿡 �� ���� set.
	*JOSA_VAR_Wg_tal	-- ���� '����'�� '��' ���� ����
	*	'��'�� �����Ǿ� ������ ��쿡 �� ���� set. '�б���' --> '�б�'+'����'
	*
	*JOSA_VAR_nameWi	-- �θ� �ڿ� ������ '��' �߰��Ǵ� ���
	*	'��'�� �м�������� ������ ���. '�½�'+'(��)��'
	*	<����> �� ���� �׻� JOSA_VAR_WiAb ������ �����Ѵ�.
	*JOSA_VAR_preWi	-- ������ ���� '��' �տ� ���簡 ���� ���
	*	(��) '����/����/��������/���' + '��' + '��'
	*JOSA_VAR_preWi2	-- ������ ���� '��' �տ� ���� & '��' Ż���� ���
	*	(��) '�б�����' --> '�б�'+'(��)��'+'(��)'+'��'
	*
	*JOSA_VAR_Ag	-- '����'�� ����ü '��'
	*JOSA_VAR_Bg	-- '����'�� ����ü '��'
	*JOSA_VAR_hbDtg	-- '����'�� ����ü '����'
	*
	*$$$ ����, '�½�������'�� ��쿡 ������ ������� ���� ����.
	*-------------------------  ������ ����ü ����  ------------------------*/

	//	Values for 'jomi.josa'.
	public static int JOSA_VAR_WiAb	=1;
	public static int JOSA_VAR_Wz_tal	=2;
	public static int JOSA_VAR_Wi_tal	=3;
	public static int JOSA_VAR_Wg_tal	=4;

	public static int JOSA_VAR_nameWi	=5;
	public static int JOSA_VAR_preWi	=6;
	public static int JOSA_VAR_preWi2	=7;

	//Values for 'jomi.josaAgBg'.
	public static int JOSA_VAR_Ag	=1;
	public static int JOSA_VAR_Bg	=2;
	public static int JOSA_VAR_hbDtg	=3;

/**---------------------  ������ ����ü ����  ----------------------
 	*
	*EOMI_VAR_Wb	-- '��'
	*EOMI_VAR_Wf	-- '��'
	*EOMI_VAR_Wj	-- '��' : '��/��/��/��/��'
	*EOMI_VAR_Wb_tal	-- '��' Ż��
	*EOMI_VAR_Wf_tal	-- '��' Ż��
	*EOMI_VAR_b	-- '��'
	*EOMI_VAR_f	-- '��'
	*EOMI_VAR_j	-- '��'
	*EOMI_VAR_c	-- '��'	---> '�ؼ�', '��ż�/�Ͼ꼭' �� ��-�ұ�Ģ
	*EOMI_VAR_lc	-- '��'	---> '�Ǵ�'���� ����
	*EOMI_VAR_If, Ib -- '��' �ұ�Ģ�� ���
	*
	*EOMI_VAR_Wz_tal	-- ���� '��/��/��/��' �� �ʼ� '��/��'���� ���۵Ǵ� ��̿��� '��' Ż��
	*	<����> '��/��/��'�� ���۵Ǵ� ��̵��� '��' Ż������ �������� ����
	*EOMI_VAR_Uz_tal	-- '���ϴ�'���� '��' Ż��
	*
	*EOMI_VAR_xv_Wf	-- ������� �տ� ���� ��̰� '��/��'
	*EOMI_VAR_xv_Al	-- ������� �տ� ���� ��̰� '��'
	*EOMI_VAR_xv_Ag	-- ������� �տ� ���� ��̰� '��'
	*
	*EOMI_VAR_Wi_tal	-- ������ ��� �ڿ��� ������ ���� '��' ����
	*
	*$$$ '��/��'�� ���� ����ü�� ������� �տ� ���� '��/��'���� �����.
	*
	*-----------------------  ������ ����ü ����  ----------------------*/

	//Values for 'jomi.eomi' or 'jomi.xomi'.
	public static int EOMI_VAR_Wb	=1;
	public static int EOMI_VAR_Wf	=2;
	public static int EOMI_VAR_Wj	=3;
	public static int EOMI_VAR_Wb_tal	=4;
	public static int EOMI_VAR_Wf_tal	=5;
	public static int EOMI_VAR_b	=6;
	public static int EOMI_VAR_f	=7;
	public static int EOMI_VAR_j	=8;
	public static int EOMI_VAR_c	=9;
	public static int EOMI_VAR_lc	=10;
	public static int EOMI_VAR_If	=11;
	public static int EOMI_VAR_Ib	=12;

	public static int EOMI_VAR_Wz_tal	=13;
	public static int EOMI_VAR_Uz_tal	=14;

	public static int EOMI_VAR_Wi_tal	=15;

	//Values for 'jomi.xomitype'.
	public static int EOMI_VAR_xv_Wf	=0; // ��/��
	public static int EOMI_VAR_xv_Al	=1; // ��
	public static int EOMI_VAR_xv_Ag	=2;  // ��
	public static int EOMI_VAR_xv_Xi	=11; // ��

/**---------------------  �������� ����ü ����  ----------------------
*
*	�������� ����ü ���� --- �� ���� ������ ǥ��
*
*		1. '��' �տ� ������ '��'�� ���� ���
*		2. '��/��'�� ����ü ����
*
*	POMI_VAR_WbV	-- '��'
*	POMI_VAR_WfV	-- '��'
*	POMI_VAR_WjV	-- '��'
*	POMI_VAR_V	-- '��'
*	POMI_VAR_bV	-- '����'
*	POMI_VAR_fV	-- '�ä�'
*	POMI_VAR_jV	-- '�Ť�'
*	POMI_VAR_cV	-- '����'	---> '�ߴ�'���� �����
*	POMI_VAR_lcV	-- '�ɤ�'	---> '�ƴ�'���� �����
*	POMI_VAR_IfV	-- '��' ---> '��' �ұ�Ģ�� ���
*	POMI_VAR_WzUi	-- '����' & '��'
*	POMI_VAR_WzUjV	-- '����' & '�Ť�', �� '����'
*
*-----------------------  �������� ����ü ����  ----------------------*/

	//	Values for 'jomi.pomi'.
	public static int POMI_VAR_WbV	=1;
	public static int POMI_VAR_WfV	=2;
	public static int POMI_VAR_WjV	=3;
	public static int POMI_VAR_V	=4;
	public static int POMI_VAR_bV	=5;
	public static int POMI_VAR_fV	=6;
	public static int POMI_VAR_jV	=7;
	public static int POMI_VAR_cV	=8;
	public static int POMI_VAR_lcV	=9;
	public static int POMI_VAR_IfV	=10;
	public static int POMI_VAR_WzUi	=11;
	public static int POMI_VAR_WzUjV	=12;

/**---------------------  ����/��� �� ��Ÿ ���� ----------------------
*
*	RMA_RESULT --- the result is got from 'hangul.rma'
*	GUESS_ABBR --- verb stem is guessed as abbr. 'ki/kg/Zi/...'
*
*	GUESS_CNOUN -- stem is guessed as noun + noun + ...
*	GUESS_PNOUN	-- proper noun with Jongsong: articulative 'Wi' dropped.
*
*	GUESS_NPREF -- noun stem is guessed as prefix 'Gc/Ul' + noun
*	GUESS_VPREF -- verb stem is guessed as prefix 'WbD/QlU' + verb
*	GUESS_NVERB -- verb stem is guessed as noun + verb + ...
*
*-----------------------  ����/��� �� ��Ÿ ���� ----------------------*/

	//	Values for 'jomi.zzz'.
	public static int RMA_RESULT	=1;
	public static int GUESS_ABBR	=2;

	public static int GUESS_CNOUN	=3;
	public static int GUESS_PNOUN	=4;

	public static int GUESS_NPREF	=5;
	public static int GUESS_VPREF	=6;
	public static int GUESS_NVERB	=7;
}
