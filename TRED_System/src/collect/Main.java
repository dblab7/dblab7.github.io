package collect;
import java.io.File;
import java.io.IOException;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

public class Main extends Thread {

	static ArrayList<String> Tweets = new ArrayList<String>();	
	static long tfTerm = 40*60*1000;		//tf占쏙옙占쏙옙 (40 占쏙옙)
	static long dfTerm = 2*24*60*60*1000;		//df占쏙옙占쏙옙 ( 2 占쏙옙)

	public static void main(String[] args) throws IOException, InterruptedException {

		MakeDataSetThread mdst = new MakeDataSetThread();				//트占쏙옙 占쌨곤옙 占쏙옙占승쇽옙 占싻쇽옙 占싹곤옙 占쏙옙占쏙옙占쏙옙 占쏙옙占싶몌옙 占쌔쇽옙 占쏙옙占쏙옙
		UpdateEveryListThread uelt = new UpdateEveryListThread();			//占쏙옙占쏙옙트 占십깍옙화 占쏙옙 占쏙옙占쏙옙漫占� 占쏙옙占쏙옙트占쏙옙 占쏙옙占쏙옙占쏙옙 占쏙옙占쏙옙/占쏙옙占쏙옙

		mdst.start();	
		uelt.start();
	}
}

class MakeDataSetThread extends Thread {
	public void run() {
		GetTweetStreamer.main();
	}
}

class UpdateEveryListThread extends Thread {
	EventLocationDetect detect = new EventLocationDetect();
	String beforeGeoLocation;
	public void run() { 
		while(true){
		try {
			Thread.sleep(1000);
			beforeGeoLocation = detect.main();
		} catch (InterruptedException e) {}
		}
	}
}

