package collect;

public class EventFilter {
	static String[] event = {"���", "�糭", "����", "�ر�", "���", "����", "���", "�λ�", "����", "����", "����", "�Ÿ�", "����", "�ر�", "����", "����", "�糭", "����", "�տ�", "ȭ��", "�߶�", "�ν�", "�浹", "Ż��", "������", "��������", "��ȭ", "����", "�׷�", "�Ѱ�", "����", "���", "�⸧����", "�ռ�", "����", "����", "�ν�", "��ũȦ", "ħ��", "������", "��ǳ", "����", "����", "��ź", "����", "����"}; //�糭 ���� ��� Ű����
	

	public static String main(String tweet) {		//�糪��� �����Ѱ͸� ���͸�

		//boolean flag = false;
		String eventWord = null;
		
		for(int e=0; e<event.length; e++) {
			if(tweet.contains(event[e])) {
				eventWord = event[e];
			}
		}
		
		return eventWord;

	}
}
