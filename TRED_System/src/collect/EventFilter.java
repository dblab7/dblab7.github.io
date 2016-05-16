package collect;

public class EventFilter {
	static String[] event = {"사고", "재난", "폭발", "붕괴", "사건", "재해", "사망", "부상", "참사", "구조", "구출", "매몰", "전소", "붕괴", "안전", "위험", "재난", "피해", "균열", "화재", "추락", "부실", "충돌", "탈선", "기기결함", "가스누출", "방화", "누전", "테러", "총격", "살인", "산불", "기름유출", "합선", "전복", "질식", "부실", "싱크홀", "침하", "전염병", "태풍", "낙하", "과열", "폭탄", "전소", "누전"}; //재난 재해 명사 키워드
	

	public static String main(String tweet) {		//재나명사 포함한것만 필터링

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
