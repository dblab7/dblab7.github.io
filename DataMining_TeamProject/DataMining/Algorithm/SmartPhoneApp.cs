using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    public class SmartPhoneApp
    {
        private Dictionary<string, double> snsProbability;
        private Dictionary<string, double> gameProbability;
        private Dictionary<string, double> shoppingProbability;
        private Dictionary<string, double> weatherProbability;
        private Dictionary<string, double> trafficProbability;
        private Dictionary<string, double> newsProbability;
        private Dictionary<string, double> musicProbability;
        private Dictionary<string, double> notUseProbability;

        private string Gender;
        private string Time;
        private string Place;
        private string Holiday;
        private string FreeWifi;
        private string BatteryRemains;
        private string DataRemains;

        public string AppClass { get; set; }
        public string Accuracy { get; set; }
        public string Result { get; set; }

        public SmartPhoneApp(string attr1, string attr2, string attr3, string attr4, string attr5, string attr6, string attr7)
        {
            Gender = attr1;
            Time = attr2;
            Place = attr3;
            Holiday = attr4;
            FreeWifi = attr5;
            BatteryRemains = attr6;
            DataRemains = attr7;

            AppClass = string.Empty;
            Accuracy = string.Empty;
            Result = string.Empty;

            snsProbability = new Dictionary<string, double>();
            gameProbability = new Dictionary<string, double>();
            shoppingProbability = new Dictionary<string, double>();
            weatherProbability = new Dictionary<string, double>();
            trafficProbability = new Dictionary<string, double>();
            newsProbability = new Dictionary<string, double>();
            musicProbability = new Dictionary<string, double>();
            notUseProbability = new Dictionary<string, double>();

            /* SNS */
            snsProbability.Add("AppClass#SNS", 0.46103896);
            snsProbability.Add("Gender#Male", 0.95104895);
            snsProbability.Add("Gender#Female", 0.04895105);
            snsProbability.Add("Time#Evening", 0.36805556);
            snsProbability.Add("Time#Morning", 0.28472222);
            snsProbability.Add("Time#Afternoon", 0.34722222);
            snsProbability.Add("Place#Classroom", 0.14285714);
            snsProbability.Add("Place#Restaurant", 0.21088435);
            snsProbability.Add("Place#Home", 0.16326531);
            snsProbability.Add("Place#Etc", 0.17006803);
            snsProbability.Add("Place#Library", 0.13605442);
            snsProbability.Add("Place#Moving", 0.17687075);
            snsProbability.Add("Holiday#Yes", 0.48951049);
            snsProbability.Add("Holiday#No", 0.51048951);
            snsProbability.Add("FreeWifi#Yes", 0.55944056);
            snsProbability.Add("FreeWifi#No", 0.44055944);
            snsProbability.Add("BatteryRemains#More than 70%", 0.375);
            snsProbability.Add("BatteryRemains#Between 15% and 70%", 0.29861111);
            snsProbability.Add("BatteryRemains#Less than 15%", 0.32638889);
            snsProbability.Add("DataRemains#Less than 30%", 0.26388889);
            snsProbability.Add("DataRemains#More than 70%", 0.40972222);
            snsProbability.Add("DataRemains#Between 30% and 70%", 0.32638889);

            /* Game */
            gameProbability.Add("AppClass#Game", 0.25974026);
            gameProbability.Add("Gender#Male", 0.95061728);
            gameProbability.Add("Gender#Female", 0.04938272);
            gameProbability.Add("Time#Evening", 0.2804878);
            gameProbability.Add("Time#Morning", 0.40243902);
            gameProbability.Add("Time#Afternoon", 0.31707317);
            gameProbability.Add("Place#Classroom", 0.15294118);
            gameProbability.Add("Place#Restaurant", 0.21176471);
            gameProbability.Add("Place#Home", 0.16470588);
            gameProbability.Add("Place#Etc", 0.11764706);
            gameProbability.Add("Place#Library", 0.16470588);
            gameProbability.Add("Place#Moving", 0.18823529);
            gameProbability.Add("Holiday#Yes", 0.50617284);
            gameProbability.Add("Holiday#No", 0.49382716);
            gameProbability.Add("FreeWifi#Yes", 0.59259259);
            gameProbability.Add("FreeWifi#No", 0.40740741);
            gameProbability.Add("BatteryRemains#More than 70%", 0.34146341);
            gameProbability.Add("BatteryRemains#Between 15% and 70%", 0.41463415);
            gameProbability.Add("BatteryRemains#Less than 15%", 0.24390244);
            gameProbability.Add("DataRemains#Less than 30%", 0.35365854);
            gameProbability.Add("DataRemains#More than 70%", 0.29268293);
            gameProbability.Add("DataRemains#Between 30% and 70%", 0.35365854);

            /* Shopping */
            shoppingProbability.Add("AppClass#Shopping", 0.05844156);
            shoppingProbability.Add("Gender#Male", 0.94736842);
            shoppingProbability.Add("Gender#Female", 0.05263158);
            shoppingProbability.Add("Time#Evening", 0.2);
            shoppingProbability.Add("Time#Morning", 0.4);
            shoppingProbability.Add("Time#Afternoon", 0.4);
            shoppingProbability.Add("Place#Classroom", 0.08695652);
            shoppingProbability.Add("Place#Restaurant", 0.13043478);
            shoppingProbability.Add("Place#Home", 0.2173913);
            shoppingProbability.Add("Place#Etc", 0.17391304);
            shoppingProbability.Add("Place#Library", 0.30434783);
            shoppingProbability.Add("Place#Moving", 0.08695652);
            shoppingProbability.Add("Holiday#Yes", 0.73684211);
            shoppingProbability.Add("Holiday#No", 0.26315789);
            shoppingProbability.Add("FreeWifi#Yes", 0.57894737);
            shoppingProbability.Add("FreeWifi#No", 0.42105263);
            shoppingProbability.Add("BatteryRemains#More than 70%", 0.35);
            shoppingProbability.Add("BatteryRemains#Between 15% and 70%", 0.35);
            shoppingProbability.Add("BatteryRemains#Less than 15%", 0.3);
            shoppingProbability.Add("DataRemains#Less than 30%", 0.2);
            shoppingProbability.Add("DataRemains#More than 70%", 0.55);
            shoppingProbability.Add("DataRemains#Between 30% and 70%", 0.25);

            /* Weather */
            weatherProbability.Add("AppClass#Weather", 0.02272727);
            weatherProbability.Add("Gender#Male", 0.75);
            weatherProbability.Add("Gender#Female", 0.25);
            weatherProbability.Add("Time#Evening", 0.44444444);
            weatherProbability.Add("Time#Morning", 0.22222222);
            weatherProbability.Add("Time#Afternoon", 0.33333333);
            weatherProbability.Add("Place#Classroom", 0.25);
            weatherProbability.Add("Place#Restaurant", 0.25);
            weatherProbability.Add("Place#Home", 0.25);
            weatherProbability.Add("Place#Etc", 0.08333333);
            weatherProbability.Add("Place#Library", 0.08333333);
            weatherProbability.Add("Place#Moving", 0.08333333);
            weatherProbability.Add("Holiday#Yes", 0.5);
            weatherProbability.Add("Holiday#No", 0.5);
            weatherProbability.Add("FreeWifi#Yes", 0.25);
            weatherProbability.Add("FreeWifi#No", 0.75);
            weatherProbability.Add("BatteryRemains#More than 70%", 0.44444444);
            weatherProbability.Add("BatteryRemains#Between 15% and 70%", 0.44444444);
            weatherProbability.Add("BatteryRemains#Less than 15%", 0.11111111);
            weatherProbability.Add("DataRemains#Less than 30%", 0.33333333);
            weatherProbability.Add("DataRemains#More than 70%", 0.33333333);
            weatherProbability.Add("DataRemains#Between 30% and 70%", 0.33333333);

            /* Traffic */
            trafficProbability.Add("AppClass#Traffic", 0.02272727);
            trafficProbability.Add("Gender#Male", 0.875);
            trafficProbability.Add("Gender#Female", 0.125);
            trafficProbability.Add("Time#Evening", 0.11111111);
            trafficProbability.Add("Time#Morning", 0.22222222);
            trafficProbability.Add("Time#Afternoon", 0.66666667);
            trafficProbability.Add("Place#Classroom", 0.08333333);
            trafficProbability.Add("Place#Restaurant", 0.25);
            trafficProbability.Add("Place#Home", 0.16666667);
            trafficProbability.Add("Place#Etc", 0.16666667);
            trafficProbability.Add("Place#Library", 0.08333333);
            trafficProbability.Add("Place#Moving", 0.25);
            trafficProbability.Add("Holiday#Yes", 0.375);
            trafficProbability.Add("Holiday#No", 0.625);
            trafficProbability.Add("FreeWifi#Yes", 0.375);
            trafficProbability.Add("FreeWifi#No", 0.625);
            trafficProbability.Add("BatteryRemains#More than 70%", 0.22222222);
            trafficProbability.Add("BatteryRemains#Between 15% and 70%", 0.44444444);
            trafficProbability.Add("BatteryRemains#Less than 15%", 0.33333333);
            trafficProbability.Add("DataRemains#Less than 30%", 0.11111111);
            trafficProbability.Add("DataRemains#More than 70%", 0.55555556);
            trafficProbability.Add("DataRemains#Between 30% and 70%", 0.33333333);

            /* News */
            newsProbability.Add("AppClass#News", 0.05194805);
            newsProbability.Add("Gender#Male", 0.88235294);
            newsProbability.Add("Gender#Female", 0.11764706);
            newsProbability.Add("Time#Evening", 0.44444444);
            newsProbability.Add("Time#Morning", 0.27777778);
            newsProbability.Add("Time#Afternoon", 0.27777778);
            newsProbability.Add("Place#Classroom", 0.28571429);
            newsProbability.Add("Place#Restaurant", 0.0952381);
            newsProbability.Add("Place#Home", 0.04761905);
            newsProbability.Add("Place#Etc", 0.19047619);
            newsProbability.Add("Place#Library", 0.28571429);
            newsProbability.Add("Place#Moving", 0.0952381);
            newsProbability.Add("Holiday#Yes", 0.29411765);
            newsProbability.Add("Holiday#No", 0.70588235);
            newsProbability.Add("FreeWifi#Yes", 0.35294118);
            newsProbability.Add("FreeWifi#No", 0.64705882);
            newsProbability.Add("BatteryRemains#More than 70%", 0.16666667);
            newsProbability.Add("BatteryRemains#Between 15% and 70%", 0.5);
            newsProbability.Add("BatteryRemains#Less than 15%", 0.33333333);
            newsProbability.Add("DataRemains#Less than 30%", 0.38888889);
            newsProbability.Add("DataRemains#More than 70%", 0.27777778);
            newsProbability.Add("DataRemains#Between 30% and 70%", 0.33333333);

            /* Music */
            musicProbability.Add("AppClass#Music", 0.05519481);
            musicProbability.Add("Gender#Male", 0.11111111);
            musicProbability.Add("Gender#Female", 0.88888889);
            musicProbability.Add("Time#Evening", 0.36842105);
            musicProbability.Add("Time#Morning", 0.26315789);
            musicProbability.Add("Time#Afternoon", 0.36842105);
            musicProbability.Add("Place#Classroom", 0.09090909);
            musicProbability.Add("Place#Restaurant", 0.09090909);
            musicProbability.Add("Place#Home", 0.13636364);
            musicProbability.Add("Place#Etc", 0.09090909);
            musicProbability.Add("Place#Library", 0.13636364);
            musicProbability.Add("Place#Moving", 0.45454545);
            musicProbability.Add("Holiday#Yes", 0.33333333);
            musicProbability.Add("Holiday#No", 0.66666667);
            musicProbability.Add("FreeWifi#Yes", 0.27777778);
            musicProbability.Add("FreeWifi#No", 0.72222222);
            musicProbability.Add("BatteryRemains#More than 70%", 0.15789474);
            musicProbability.Add("BatteryRemains#Between 15% and 70%", 0.57894737);
            musicProbability.Add("BatteryRemains#Less than 15%", 0.26315789);
            musicProbability.Add("DataRemains#Less than 30%", 0.26315789);
            musicProbability.Add("DataRemains#More than 70%", 0.36842105);
            musicProbability.Add("DataRemains#Between 30% and 70%", 0.36842105);

            /* Not Use */
            notUseProbability.Add("AppClass#NotUse", 0.06818182);
            notUseProbability.Add("Gender#Male", 0.81818182);
            notUseProbability.Add("Gender#Female", 0.18181818);
            notUseProbability.Add("Time#Evening", 0.30434783);
            notUseProbability.Add("Time#Morning", 0.34782609);
            notUseProbability.Add("Time#Afternoon", 0.34782609);
            notUseProbability.Add("Place#Classroom", 0.23076923);
            notUseProbability.Add("Place#Restaurant", 0.19230769);
            notUseProbability.Add("Place#Home", 0.07692308);
            notUseProbability.Add("Place#Etc", 0.11538462);
            notUseProbability.Add("Place#Library", 0.07692308);
            notUseProbability.Add("Place#Moving", 0.30769231);
            notUseProbability.Add("Holiday#Yes", 0.54545455);
            notUseProbability.Add("Holiday#No", 0.45454545);
            notUseProbability.Add("FreeWifi#Yes", 0.63636364);
            notUseProbability.Add("FreeWifi#No", 0.36363636);
            notUseProbability.Add("BatteryRemains#More than 70%", 0.43478261);
            notUseProbability.Add("BatteryRemains#Between 15% and 70%", 0.2173913);
            notUseProbability.Add("BatteryRemains#Less than 15%", 0.34782609);
            notUseProbability.Add("DataRemains#Less than 30%", 0.30434783);
            notUseProbability.Add("DataRemains#More than 70%", 0.39130435);
            notUseProbability.Add("DataRemains#Between 30% and 70%", 0.30434783);
        }

        public void OneRule()
        {
            string appClass = string.Empty;
            string result = string.Empty;

            if (Gender == "Male")
            {
                appClass = "SNS";
            }
            else if (Gender == "Female")
            {
                appClass = "Music";
            }

            result = $"One Rule에 의해 Gender='{Gender}'이므로 Class='{appClass}'이다.";

            AppClass = appClass; // 추천
            Accuracy = "50%"; // 정확도
            Result = result;
        }

        public void NaiveBayesian()
        {
            string appClass = string.Empty;
            string result = string.Empty;

            double sns = snsProbability["AppClass#SNS"];
            double game = gameProbability["AppClass#Game"];
            double shopping = shoppingProbability["AppClass#Shopping"];
            double weather = weatherProbability["AppClass#Weather"];
            double traffic = trafficProbability["AppClass#Traffic"];
            double news = newsProbability["AppClass#News"];
            double music = musicProbability["AppClass#Music"];
            double notUse = notUseProbability["AppClass#NotUse"];

            double snsNormalization = 0;
            double gameNormalization = 0;
            double shoppingNormalization = 0;
            double weatherNormalization = 0;
            double trafficNormalization = 0;
            double newsNormalization = 0;
            double musicNormalization = 0;
            double notUseNormalization = 0;

            // 선택한 속성 값에 따라 확율 계산
            sns *= snsProbability["Gender#" + Gender];
            sns *= snsProbability["Time#" + Time];
            sns *= snsProbability["Place#" + Place];
            sns *= snsProbability["FreeWifi#" + FreeWifi];
            sns *= snsProbability["Holiday#" + Holiday];
            sns *= snsProbability["BatteryRemains#" + BatteryRemains];
            sns *= snsProbability["DataRemains#" + DataRemains];

            game *= gameProbability["Gender#" + Gender];
            game *= gameProbability["Time#" + Time];
            game *= gameProbability["Place#" + Place];
            game *= gameProbability["FreeWifi#" + FreeWifi];
            game *= gameProbability["Holiday#" + Holiday];
            game *= gameProbability["BatteryRemains#" + BatteryRemains];
            game *= gameProbability["DataRemains#" + DataRemains];

            shopping *= shoppingProbability["Gender#" + Gender];
            shopping *= shoppingProbability["Time#" + Time];
            shopping *= shoppingProbability["Place#" + Place];
            shopping *= shoppingProbability["FreeWifi#" + FreeWifi];
            shopping *= shoppingProbability["Holiday#" + Holiday];
            shopping *= shoppingProbability["BatteryRemains#" + BatteryRemains];
            shopping *= shoppingProbability["DataRemains#" + DataRemains];

            weather *= weatherProbability["Gender#" + Gender];
            weather *= weatherProbability["Time#" + Time];
            weather *= weatherProbability["Place#" + Place];
            weather *= weatherProbability["FreeWifi#" + FreeWifi];
            weather *= weatherProbability["Holiday#" + Holiday];
            weather *= weatherProbability["BatteryRemains#" + BatteryRemains];
            weather *= weatherProbability["DataRemains#" + DataRemains];

            traffic *= trafficProbability["Gender#" + Gender];
            traffic *= trafficProbability["Time#" + Time];
            traffic *= trafficProbability["Place#" + Place];
            traffic *= trafficProbability["FreeWifi#" + FreeWifi];
            traffic *= trafficProbability["Holiday#" + Holiday];
            traffic *= trafficProbability["BatteryRemains#" + BatteryRemains];
            traffic *= trafficProbability["DataRemains#" + DataRemains];

            news *= newsProbability["Gender#" + Gender];
            news *= newsProbability["Time#" + Time];
            news *= newsProbability["Place#" + Place];
            news *= newsProbability["FreeWifi#" + FreeWifi];
            news *= newsProbability["Holiday#" + Holiday];
            news *= newsProbability["BatteryRemains#" + BatteryRemains];
            news *= newsProbability["DataRemains#" + DataRemains];

            music *= musicProbability["Gender#" + Gender];
            music *= musicProbability["Time#" + Time];
            music *= musicProbability["Place#" + Place];
            music *= musicProbability["FreeWifi#" + FreeWifi];
            music *= musicProbability["Holiday#" + Holiday];
            music *= musicProbability["BatteryRemains#" + BatteryRemains];
            music *= musicProbability["DataRemains#" + DataRemains];

            notUse *= notUseProbability["Gender#" + Gender];
            notUse *= notUseProbability["Time#" + Time];
            notUse *= notUseProbability["Place#" + Place];
            notUse *= notUseProbability["FreeWifi#" + FreeWifi];
            notUse *= notUseProbability["Holiday#" + Holiday];
            notUse *= notUseProbability["BatteryRemains#" + BatteryRemains];
            notUse *= notUseProbability["DataRemains#" + DataRemains];

            double sumClass = sns + game + shopping + weather + traffic + news + music + notUse;
            snsNormalization = Math.Round((sns / sumClass) * 100, 2);
            gameNormalization = Math.Round((game / sumClass) * 100, 2);
            shoppingNormalization = Math.Round((shopping / sumClass) * 100, 2);
            weatherNormalization = Math.Round((weather / sumClass) * 100, 2);
            trafficNormalization = Math.Round((traffic / sumClass) * 100, 2);
            newsNormalization = Math.Round((news / sumClass) * 100, 2);
            musicNormalization = Math.Round((music / sumClass) * 100, 2);

            double sumNormalization = snsNormalization + gameNormalization + shoppingNormalization + weatherNormalization + trafficNormalization + newsNormalization + musicNormalization;
            notUseNormalization = 100 - sumNormalization;

            // 가장 높은 확률의 AppClass를 결정
            SortedList<double, string> sortedList = new SortedList<double, string>();

            sortedList.Add(snsNormalization, "SNS");
            sortedList.Add(gameNormalization, "Game");
            sortedList.Add(shoppingNormalization, "Shopping");
            sortedList.Add(weatherNormalization, "Weather");
            sortedList.Add(trafficNormalization, "Traffic");
            sortedList.Add(newsNormalization, "News");
            sortedList.Add(musicNormalization, "Music");
            sortedList.Add(notUseNormalization, "Not Use");

            appClass = sortedList.Values[7];
            result = $"Naive Bayesian에 의해 Class='{appClass}'이다. ({sortedList.Keys[7]}%)";

            AppClass = appClass; // 추천
            Accuracy = "51.6%"; // 정확도
            Result = result;
        }

        public void DecisionTree()
        {
            string appClass = string.Empty;
            string result = string.Empty;

            if (Gender == "Male")
            {
                appClass = "SNS";
            }
            else if (Gender == "Female")
            {
                appClass = "Music";
            }

            result = $"Decision Tree에 Gender='{Gender}'이므로 Class='{appClass}'이다.";

            AppClass = appClass; // 추천
            Accuracy = "50%"; // 정확도
            Result = result;
        }

        public void CoveringAlgorithm()
        {
            string appClass = string.Empty;
            string result = string.Empty;

            appClass = GetAppClass();
            result = $"Covering Algorithm에 의해 위와 같은 조건이므로 Class='{appClass}'이다.";

            AppClass = appClass; // 추천
            Accuracy = "93.6%"; // 정확도
            Result = result;
        }

        private string GetAppClass()
        {
            string appClass = string.Empty;

            if (Place == "Restaurant" && Gender == "Female") appClass = "SNS";
            else if (Place == "Etc" && BatteryRemains == "Less than 15%" && DataRemains == "Less than 15%") appClass = "SNS";
            else if (Time == "Evening" && Place == "Classroom" && BatteryRemains == "More than 70%") appClass = "SNS";
            else if (Place == "Restaurant" && DataRemains == "More than 70%" && Time == "Evening") appClass = "SNS";
            else if (Place == "Etc" && Time == "Afternoon" && Gender == "Female") appClass = "SNS";
            else if (Place == "Home" && BatteryRemains == "Between 15% and 70%" && FreeWifi == "Yes" && Time == "Morning") appClass = "SNS";
            else if (Time == "Afternoon" && Place == "Library" && Holiday == "Yes") appClass = "SNS";
            else if (Place == "Etc" && BatteryRemains == "Less than 15%" && FreeWifi == "Yes" && Time == "Evening") appClass = "SNS";
            else if (Place == "Home" && DataRemains == "Between 30% and 70%" && Time == "Morning") appClass = "SNS";
            else if (Place == "Home" && BatteryRemains == "Between 15% and 70%" && FreeWifi == "Yes" && Time == "Afternoon") appClass = "SNS";
            else if (BatteryRemains == "Less than 15%" && Place == "Moving" && DataRemains == "More than 70%" && Holiday == "Yes") appClass = "SNS";
            else if (Time == "Afternoon" && Place == "Classroom" && DataRemains == "Less than 15%") appClass = "SNS";
            else if (Place == "Restaurant" && BatteryRemains == "Between 15% and 70%" && DataRemains == "More than 70%") appClass = "SNS";
            else if (BatteryRemains == "More than 70%" && Place == "Etc" && Time == "Evening" && Holiday == "No") appClass = "SNS";
            else if (Place == "Home" && Holiday == "No" && DataRemains == "More than 70%" && Time == "Morning") appClass = "SNS";
            else if (BatteryRemains == "More than 70%" && Place == "Moving" && DataRemains == "Between 30% and 70%" && Holiday == "No") appClass = "SNS";
            else if (Time == "Afternoon" && Place == "Etc" && DataRemains == "Between 30% and 70%" && Holiday == "No") appClass = "SNS";
            else if (Place == "Home" && Holiday == "No" && BatteryRemains == "Between 15% and 70%" && DataRemains == "More than 70%") appClass = "SNS";
            else if (BatteryRemains == "More than 70%" && Place == "Classroom" && Time == "Afternoon" && FreeWifi == "Yes") appClass = "SNS";
            else if (Place == "Restaurant" && BatteryRemains == "Between 15% and 70%" && FreeWifi == "No" && Time == "Afternoon") appClass = "SNS";
            else if (Time == "Evening" && Place == "Moving" && FreeWifi == "No" && BatteryRemains == "More than 70%") appClass = "SNS";
            else if (Place == "Home" && Holiday == "No" && BatteryRemains == "More than 70%" && DataRemains == "More than 70%" && FreeWifi == "Yes") appClass = "SNS";
            else if (Time == "Evening" && BatteryRemains == "Between 15% and 70%" && DataRemains == "Between 30% and 70%" && FreeWifi == "No") appClass = "SNS";
            else if (BatteryRemains == "Less than 15%" && Holiday == "No" && Place == "Moving" && Time == "Evening") appClass = "SNS";
            else if (BatteryRemains == "More than 70%" && Place == "Etc" && Holiday == "Yes" && Time == "Afternoon" && Gender == "Male" && FreeWifi == "No" && DataRemains == "More than 70%") appClass = "SNS";
            else if (Place == "Home" && BatteryRemains == "Between 15% and 70%" && Time == "Evening" && DataRemains == "Between 30% and 70%" && Holiday == "Yes") appClass = "SNS";
            else if (BatteryRemains == "Less than 15%" && DataRemains == "More than 70%" && Place == "Moving" && Time == "Morning") appClass = "SNS";
            else if (Place == "Classroom" && DataRemains == "More than 70%" && Time == "Afternoon") appClass = "SNS";
            else if (Place == "Restaurant" && DataRemains == "More than 70%" && Time == "Afternoon" && FreeWifi == "No") appClass = "SNS";
            else if (BatteryRemains == "More than 70%" && DataRemains == "Less than 15%" && Place == "Library" && FreeWifi == "Yes") appClass = "SNS";
            else if (Place == "Home" && DataRemains == "Less than 15%" && Time == "Afternoon" && FreeWifi == "No") appClass = "SNS";
            else if (Place == "Classroom" && DataRemains == "More than 70%" && FreeWifi == "No" && Holiday == "No") appClass = "SNS";
            else if (Place == "Restaurant" && BatteryRemains == "Between 15% and 70%" && Time == "Evening" && Holiday == "Yes") appClass = "SNS";
            else if (Time == "Afternoon" && BatteryRemains == "Less than 15%" && Place == "Restaurant" && DataRemains == "Less than 15%") appClass = "SNS";
            else if (Time == "Afternoon" && BatteryRemains == "Less than 15%" && Place == "Restaurant" && Gender == "Male" && Holiday == "Yes" && FreeWifi == "Yes" && DataRemains == "More than 70%") appClass = "SNS";
            else if (BatteryRemains == "More than 70%" && Place == "Etc" && DataRemains == "Less than 15%" && Time == "Evening") appClass = "SNS";
            else if (Place == "Home" && Holiday == "No" && BatteryRemains == "Between 15% and 70%" && Time == "Evening" && Gender == "Male" && FreeWifi == "Yes" && DataRemains == "Between 30% and 70%") appClass = "SNS";
            else if (Time == "Afternoon" && BatteryRemains == "More than 70%" && Place == "Classroom" && DataRemains == "More than 70%") appClass = "SNS";
            else if (Time == "Afternoon" && BatteryRemains == "Less than 15%" && Place == "Moving" && Holiday == "No" && FreeWifi == "No") appClass = "SNS";
            else if (BatteryRemains == "More than 70%" && Place == "Moving" && FreeWifi == "Yes" && Time == "Afternoon") appClass = "SNS";
            else if (Place == "Etc" && Time == "Morning" && DataRemains == "More than 70%" && Holiday == "Yes") appClass = "SNS";
            else if (Time == "Afternoon" && Place == "Etc" && DataRemains == "Less than 15%" && Gender == "Male" && Holiday == "No" && FreeWifi == "Yes" && BatteryRemains == "More than 70%") appClass = "SNS";
            else if (BatteryRemains == "Less than 15%" && Place == "Etc" && Time == "Morning" && DataRemains == "More than 70%") appClass = "SNS";
            else if (Time == "Afternoon" && Place == "Home" && DataRemains == "Less than 15%" && Holiday == "Yes" && Gender == "Male" && FreeWifi == "Yes" && BatteryRemains == "Less than 15%") appClass = "SNS";
            else if (DataRemains == "Between 30% and 70%" && Place == "Library" && Time == "Afternoon") appClass = "SNS";
            else if (Place == "Moving" && BatteryRemains == "More than 70%" && FreeWifi == "Yes" && Holiday == "Yes" && Gender == "Male") appClass = "SNS";
            else if (DataRemains == "Between 30% and 70%" && Place == "Library" && FreeWifi == "Yes" && Holiday == "No") appClass = "SNS";
            else if (Time == "Afternoon" && Place == "Etc" && Holiday == "No" && FreeWifi == "Yes") appClass = "SNS";
            else if (Place == "Restaurant" && Time == "Morning" && BatteryRemains == "More than 70%" && DataRemains == "Less than 15%") appClass = "SNS";
            else if (Place == "Classroom" && DataRemains == "Less than 15%" && FreeWifi == "Yes" && Holiday == "No") appClass = "SNS";
            else if (Time == "Afternoon" && BatteryRemains == "More than 70%" && Place == "Home" && Gender == "Male" && Holiday == "No" && FreeWifi == "Yes" && DataRemains == "Less than 15%") appClass = "SNS";
            else if (Time == "Afternoon" && DataRemains == "Between 30% and 70%" && Holiday == "Yes" && Place == "Classroom" && BatteryRemains == "Between 15% and 70%" && Gender == "Male" && FreeWifi == "No") appClass = "SNS";
            else if (Place == "Moving" && Time == "Afternoon" && BatteryRemains == "Less than 15%" && DataRemains == "Between 30% and 70%" && FreeWifi == "Yes") appClass = "SNS";
            else if (Place == "Restaurant" && DataRemains == "Between 30% and 70%" && Time == "Morning" && Holiday == "No") appClass = "SNS";
            else if (Place == "Moving" && DataRemains == "More than 70%" && Time == "Evening" && FreeWifi == "Yes" && BatteryRemains == "Between 15% and 70%") appClass = "SNS";
            else if (Place == "Home" && DataRemains == "Less than 15%" && BatteryRemains == "Less than 15%" && Time == "Morning") appClass = "SNS";
            else if (Time == "Afternoon" && BatteryRemains == "More than 70%" && DataRemains == "Less than 15%" && Place == "Moving" && Gender == "Male" && Holiday == "No" && FreeWifi == "No") appClass = "SNS";
            else if (Place == "Restaurant" && Time == "Afternoon" && DataRemains == "Between 30% and 70%" && Holiday == "Yes" && Gender == "Male" && FreeWifi == "No" && BatteryRemains == "More than 70%") appClass = "SNS";
            else if (Place == "Library" && DataRemains == "Between 30% and 70%" && Holiday == "Yes" && FreeWifi == "No" && Gender == "Male" && Time == "Morning" && BatteryRemains == "Between 15% and 70%") appClass = "SNS";
            else if (Place == "Moving" && DataRemains == "More than 70%" && Holiday == "Yes" && BatteryRemains == "Between 15% and 70%" && Gender == "Male" && Time == "Afternoon" && FreeWifi == "No") appClass = "SNS";
            else if (Time == "Morning" && Place == "Classroom" && DataRemains == "Between 30% and 70%" && FreeWifi == "No") appClass = "Game";
            else if (Time == "Morning" && Holiday == "Yes" && Place == "Classroom" && FreeWifi == "Yes") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Place == "Moving" && BatteryRemains == "Between 15% and 70%") appClass = "Game";
            else if (Time == "Morning" && FreeWifi == "No" && BatteryRemains == "Between 15% and 70%" && Place == "Home") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Place == "Home" && Time == "Evening") appClass = "Game";
            else if (Time == "Morning" && FreeWifi == "No" && Place == "Library" && DataRemains == "Less than 15%" && Gender == "Male") appClass = "Game";
            else if (Time == "Morning" && Place == "Etc" && Holiday == "Yes" && BatteryRemains == "Between 15% and 70%") appClass = "Game";
            else if (Time == "Morning" && Place == "Restaurant" && BatteryRemains == "Less than 15%" && FreeWifi == "Yes") appClass = "Game";
            else if (Place == "Library" && Gender == "Female" && BatteryRemains == "More than 70%") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Place == "Moving" && Time == "Afternoon" && Holiday == "Yes") appClass = "Game";
            else if (Time == "Morning" && FreeWifi == "No" && Place == "Moving" && BatteryRemains == "More than 70%") appClass = "Game";
            else if (Place == "Library" && Gender == "Female" && BatteryRemains == "Less than 15%") appClass = "Game";
            else if (Place == "Restaurant" && DataRemains == "Between 30% and 70%" && BatteryRemains == "Less than 15%") appClass = "Game";
            else if (Time == "Morning" && FreeWifi == "No" && BatteryRemains == "Between 15% and 70%" && Gender == "Male" && Place == "Moving") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Time == "Afternoon" && Place == "Moving" && Gender == "Male" && Holiday == "No" && FreeWifi == "No" && BatteryRemains == "More than 70%") appClass = "Game";
            else if (Place == "Restaurant" && DataRemains == "Between 30% and 70%" && Holiday == "No" && Time == "Afternoon") appClass = "Game";
            else if (Place == "Library" && DataRemains == "More than 70%" && Time == "Evening" && BatteryRemains == "More than 70%") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Time == "Afternoon" && Place == "Restaurant" && FreeWifi == "Yes" && BatteryRemains == "Between 15% and 70%") appClass = "Game";
            else if (Time == "Morning" && BatteryRemains == "More than 70%" && Place == "Etc" && Holiday == "No") appClass = "Game";
            else if (Place == "Home" && Time == "Evening" && BatteryRemains == "Less than 15%") appClass = "Game";
            else if (Time == "Morning" && Place == "Restaurant" && BatteryRemains == "Less than 15%" && DataRemains == "More than 70%") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Place == "Home" && FreeWifi == "Yes" && BatteryRemains == "More than 70%" && Time == "Morning") appClass = "Game";
            else if (Place == "Library" && BatteryRemains == "Between 15% and 70%" && DataRemains == "More than 70%" && FreeWifi == "No") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Place == "Library" && Time == "Evening") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Time == "Afternoon" && BatteryRemains == "More than 70%" && Place == "Restaurant" && Holiday == "No") appClass = "Game";
            else if (DataRemains == "Between 30% and 70%" && Place == "Restaurant" && FreeWifi == "Yes" && Time == "Morning") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Place == "Home" && Time == "Afternoon" && Holiday == "Yes" && Gender == "Male" && FreeWifi == "Yes" && BatteryRemains == "Less than 15%") appClass = "Game";
            else if (Place == "Etc" && BatteryRemains == "Between 15% and 70%" && Holiday == "Yes") appClass = "Game";
            else if (DataRemains == "Between 30% and 70%" && Place == "Classroom" && BatteryRemains == "Between 15% and 70%" && Time == "Morning") appClass = "Game";
            else if (BatteryRemains == "More than 70%" && Place == "Etc" && Time == "Morning" && DataRemains == "Less than 15%") appClass = "Game";
            else if (Place == "Moving" && BatteryRemains == "Less than 15%" && Time == "Afternoon" && Gender == "Male" && Holiday == "Yes" && FreeWifi == "No") appClass = "Game";
            else if (BatteryRemains == "More than 70%" && Place == "Restaurant" && FreeWifi == "No" && Holiday == "No" && DataRemains == "More than 70%") appClass = "Game";
            else if (Holiday == "No" && Place == "Moving" && BatteryRemains == "More than 70%" && Time == "Evening") appClass = "Game";
            else if (DataRemains == "Between 30% and 70%" && Place == "Restaurant" && Holiday == "No" && BatteryRemains == "Between 15% and 70%") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Place == "Library" && Gender == "Female" && FreeWifi == "Yes") appClass = "Game";
            else if (Place == "Classroom" && BatteryRemains == "Between 15% and 70%" && DataRemains == "Between 30% and 70%" && Gender == "Male" && Time == "Afternoon" && Holiday == "Yes" && FreeWifi == "No") appClass = "Game";
            else if (BatteryRemains == "More than 70%" && Place == "Etc" && Time == "Evening" && DataRemains == "Between 30% and 70%") appClass = "Game";
            else if (Holiday == "No" && Place == "Moving" && FreeWifi == "Yes" && BatteryRemains == "Less than 15%" && Time == "Afternoon") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Place == "Moving" && Gender == "Male" && Holiday == "Yes" && BatteryRemains == "Less than 15%") appClass = "Game";
            else if (Place == "Home" && FreeWifi == "No" && Time == "Evening") appClass = "Game";
            else if (Holiday == "No" && Place == "Moving" && Time == "Morning" && BatteryRemains == "Less than 15%" && DataRemains == "Between 30% and 70%") appClass = "Game";
            else if (DataRemains == "Less than 15%" && Time == "Afternoon" && Place == "Library" && BatteryRemains == "Less than 15%") appClass = "Game";
            else if (Place == "Classroom" && Time == "Morning" && BatteryRemains == "More than 70%" && FreeWifi == "Yes") appClass = "Game";
            else if (BatteryRemains == "Between 15% and 70%" && Place == "Etc" && DataRemains == "Between 30% and 70%" && Time == "Evening") appClass = "Game";
            else if (BatteryRemains == "More than 70%" && Place == "Restaurant" && FreeWifi == "No" && DataRemains == "Less than 15%" && Time == "Evening") appClass = "Game";
            else if (Place == "Home" && FreeWifi == "No" && DataRemains == "Between 30% and 70%" && Holiday == "No") appClass = "Game";
            else if (BatteryRemains == "More than 70%" && Place == "Etc" && FreeWifi == "Yes" && Time == "Evening" && Holiday == "Yes") appClass = "Game";
            else if (Place == "Classroom" && BatteryRemains == "Between 15% and 70%" && Time == "Morning" && DataRemains == "Less than 15%" && Gender == "Male" && Holiday == "No" && FreeWifi == "No") appClass = "Game";
            else if (Time == "Afternoon" && DataRemains == "Less than 15%" && BatteryRemains == "More than 70%" && Place == "Etc" && Gender == "Male" && Holiday == "No" && FreeWifi == "Yes") appClass = "Game";
            else if (Place == "Library" && BatteryRemains == "Between 15% and 70%" && Time == "Afternoon" && Holiday == "No" && DataRemains == "More than 70%") appClass = "Game";
            else if (DataRemains == "Between 30% and 70%" && Place == "Restaurant" && Time == "Afternoon" && BatteryRemains == "More than 70%" && Gender == "Male" && Holiday == "Yes" && FreeWifi == "No") appClass = "Game";
            else if (Place == "Moving" && Time == "Morning" && BatteryRemains == "More than 70%" && DataRemains == "More than 70%" && Holiday == "No") appClass = "Game";
            else if (Place == "Home" && DataRemains == "Less than 15%" && Time == "Afternoon" && FreeWifi == "Yes" && Gender == "Male" && Holiday == "No" && BatteryRemains == "More than 70%") appClass = "Game";
            else if (Place == "Classroom" && Holiday == "Yes" && BatteryRemains == "Less than 15%" && FreeWifi == "Yes") appClass = "Game";
            else if (DataRemains == "Between 30% and 70%" && Time == "Morning" && BatteryRemains == "Between 15% and 70%" && Holiday == "Yes" && Gender == "Male" && Place == "Library" && FreeWifi == "No") appClass = "Game";
            else if (Place == "Moving" && DataRemains == "Between 30% and 70%" && Time == "Evening" && FreeWifi == "Yes" && Gender == "Male" && BatteryRemains == "Between 15% and 70%") appClass = "Game";
            else if (Place == "Library" && Time == "Morning" && BatteryRemains == "More than 70%" && DataRemains == "More than 70%") appClass = "Shopping";
            else if (Place == "Library" && Time == "Morning" && FreeWifi == "Yes" && DataRemains == "More than 70%") appClass = "Shopping";
            else if (Place == "Home" && DataRemains == "More than 70%" && Holiday == "Yes" && FreeWifi == "Yes") appClass = "Shopping";
            else if (Place == "Etc" && Time == "Afternoon" && Holiday == "Yes" && BatteryRemains == "Less than 15%") appClass = "Shopping";
            else if (Place == "Library" && BatteryRemains == "More than 70%" && Time == "Morning" && DataRemains == "Between 30% and 70%") appClass = "Shopping";
            else if (Time == "Afternoon" && Place == "Etc" && FreeWifi == "No" && BatteryRemains == "Less than 15%" && DataRemains == "More than 70%") appClass = "Shopping";
            else if (Place == "Library" && Time == "Afternoon" && Holiday == "No" && BatteryRemains == "More than 70%" && DataRemains == "More than 70%") appClass = "Shopping";
            else if (BatteryRemains == "Between 15% and 70%" && Place == "Classroom" && Time == "Afternoon" && FreeWifi == "Yes" && Holiday == "Yes") appClass = "Shopping";
            else if (BatteryRemains == "Between 15% and 70%" && Place == "Home" && Time == "Evening" && Holiday == "No" && Gender == "Male" && FreeWifi == "Yes" && DataRemains == "Between 30% and 70%") appClass = "Shopping";
            else if (DataRemains == "Less than 15%" && Place == "Library" && BatteryRemains == "Between 15% and 70%" && Gender == "Male" && Time == "Morning") appClass = "Shopping";
            else if (Place == "Etc" && Holiday == "Yes" && Time == "Afternoon" && Gender == "Male" && FreeWifi == "No" && BatteryRemains == "More than 70%" && DataRemains == "More than 70%") appClass = "Shopping";
            else if (Place == "Restaurant" && DataRemains == "Less than 15%" && BatteryRemains == "More than 70%" && Time == "Afternoon" && Holiday == "Yes") appClass = "Shopping";
            else if (Place == "Moving" && Time == "Evening" && BatteryRemains == "Between 15% and 70%" && DataRemains == "More than 70%" && FreeWifi == "No") appClass = "Shopping";
            else if (BatteryRemains == "More than 70%" && Place == "Home" && Time == "Afternoon" && FreeWifi == "Yes" && DataRemains == "Less than 15%" && Gender == "Male" && Holiday == "No") appClass = "Weather";
            else if (Place == "Classroom" && Holiday == "Yes" && Time == "Morning" && FreeWifi == "No") appClass = "Weather";
            else if (Place == "Restaurant" && DataRemains == "Between 30% and 70%" && Time == "Evening" && FreeWifi == "No" && BatteryRemains == "More than 70%") appClass = "Weather";
            else if (Time == "Afternoon" && Place == "Moving" && BatteryRemains == "Between 15% and 70%" && DataRemains == "More than 70%" && Gender == "Male" && Holiday == "No") appClass = "Traffic";
            else if (Time == "Afternoon" && Place == "Home" && BatteryRemains == "Less than 15%" && Holiday == "No") appClass = "Traffic";
            else if (Place == "Etc" && BatteryRemains == "Between 15% and 70%" && Time == "Morning" && Holiday == "No") appClass = "Traffic";
            else if (Place == "Restaurant" && DataRemains == "Between 30% and 70%" && Time == "Afternoon" && Holiday == "Yes" && BatteryRemains == "More than 70%" && Gender == "Male" && FreeWifi == "No") appClass = "Traffic";
            else if (Place == "Moving" && BatteryRemains == "Between 15% and 70%" && Holiday == "Yes" && FreeWifi == "No" && Gender == "Male" && Time == "Afternoon" && DataRemains == "More than 70%") appClass = "Traffic";
            else if (Place == "Library" && BatteryRemains == "Less than 15%" && Time == "Evening") appClass = "News";
            else if (Place == "Library" && Time == "Evening" && Gender == "Male" && FreeWifi == "Yes" && BatteryRemains == "Between 15% and 70%") appClass = "News";
            else if (Place == "Classroom" && BatteryRemains == "Between 15% and 70%" && Time == "Evening") appClass = "News";
            else if (Place == "Etc" && Gender == "Female" && BatteryRemains == "Between 15% and 70%") appClass = "News";
            else if (Place == "Library" && BatteryRemains == "Less than 15%" && DataRemains == "More than 70%") appClass = "News";
            else if (Place == "Classroom" && FreeWifi == "No" && DataRemains == "Less than 15%" && Time == "Morning" && Gender == "Male" && Holiday == "No" && BatteryRemains == "Between 15% and 70%") appClass = "News";
            else if (Place == "Etc" && BatteryRemains == "Less than 15%" && FreeWifi == "No" && DataRemains == "Between 30% and 70%") appClass = "News";
            else if (Place == "Library" && Holiday == "No" && DataRemains == "Less than 15%" && Time == "Afternoon" && FreeWifi == "Yes") appClass = "News";
            else if (DataRemains == "Between 30% and 70%" && Place == "Classroom" && Time == "Afternoon" && BatteryRemains == "More than 70%" && FreeWifi == "No") appClass = "News";
            else if (BatteryRemains == "Less than 15%" && Place == "Restaurant" && Time == "Morning" && DataRemains == "Less than 15%") appClass = "News";
            else if (Place == "Etc" && Time == "Evening" && FreeWifi == "No" && BatteryRemains == "Less than 15%" && Gender == "Male") appClass = "News";
            else if (Place == "Library" && Time == "Evening" && BatteryRemains == "More than 70%" && FreeWifi == "No") appClass = "News";
            else if (Place == "Moving" && DataRemains == "Between 30% and 70%" && Time == "Afternoon" && Holiday == "Yes" && BatteryRemains == "Between 15% and 70%" && Gender == "Male" && FreeWifi == "Yes") appClass = "News";
            else if (Gender == "Female" && Place == "Classroom") appClass = "Music";
            else if (Gender == "Female" && Place == "Moving" && BatteryRemains == "Between 15% and 70%") appClass = "Music";
            else if (Gender == "Female" && Place == "Moving" && Time == "Evening") appClass = "Music";
            else if (Gender == "Female" && FreeWifi == "No" && BatteryRemains == "Between 15% and 70%") appClass = "Music";
            else if (Gender == "Female" && Place == "Moving" && Time == "Afternoon" && Holiday == "Yes" && FreeWifi == "No" && BatteryRemains == "More than 70%" && DataRemains == "More than 70%") appClass = "Music";
            else if (Gender == "Female" && BatteryRemains == "Less than 15%" && Time == "Evening" && FreeWifi == "No") appClass = "Music";
            else if (Place == "Moving" && DataRemains == "Between 30% and 70%" && Time == "Afternoon" && Holiday == "No") appClass = "Music";
            else if (Gender == "Female" && Place == "Home") appClass = "Not use";
            else if (Place == "Moving" && Gender == "Female" && Time == "Morning" && Holiday == "Yes") appClass = "Not use";
            else if (Place == "Classroom" && BatteryRemains == "Less than 15%" && Time == "Evening" && DataRemains == "Less than 15%") appClass = "Not use";
            else if (Place == "Moving" && Time == "Afternoon" && BatteryRemains == "More than 70%" && DataRemains == "More than 70%" && Holiday == "No") appClass = "Not use";
            else if (Place == "Classroom" && FreeWifi == "Yes" && DataRemains == "More than 70%" && Holiday == "No" && Time == "Afternoon") appClass = "Not use";
            else if (Place == "Moving" && Time == "Afternoon" && BatteryRemains == "More than 70%" && Holiday == "Yes" && FreeWifi == "No" && Gender == "Male") appClass = "Not use";
            else if (BatteryRemains == "Less than 15%" && Place == "Classroom" && DataRemains == "Between 30% and 70%" && Gender == "Male") appClass = "Not use";
            else if (Place == "Restaurant" && BatteryRemains == "Less than 15%" && FreeWifi == "Yes" && Time == "Evening" && Holiday == "Yes") appClass = "Not use";
            else if (Place == "Moving" && Gender == "Female" && BatteryRemains == "More than 70%" && Time == "Afternoon" && Holiday == "Yes" && FreeWifi == "No" && DataRemains == "More than 70%") appClass = "Not use";
            else if (FreeWifi == "Yes" && Place == "Restaurant" && BatteryRemains == "Less than 15%" && Time == "Afternoon" && DataRemains == "More than 70%" && Gender == "Male" && Holiday == "Yes") appClass = "Not use";
            else if (Place == "Etc" && BatteryRemains == "Between 15% and 70%" && DataRemains == "Less than 15%" && Gender == "Male") appClass = "Not use";
            else if (Place == "Moving" && BatteryRemains == "Between 15% and 70%" && Time == "Morning" && FreeWifi == "Yes" && Holiday == "No") appClass = "Not use";
            else if (FreeWifi == "Yes" && Place == "Classroom" && DataRemains == "More than 70%" && Holiday == "No" && BatteryRemains == "Less than 15%") appClass = "Not use";
            else if (Place == "Etc" && FreeWifi == "No" && Time == "Afternoon" && Holiday == "No" && BatteryRemains == "More than 70%" && Gender == "Male") appClass = "Not use";
            else if (DataRemains == "Between 30% and 70%" && Place == "Restaurant" && Holiday == "No" && Time == "Evening" && BatteryRemains == "More than 70%") appClass = "Not use";
            else if (Place == "Library" && BatteryRemains == "Less than 15%" && FreeWifi == "Yes" && Time == "Morning") appClass = "Not use";
            else if (Place == "Moving" && DataRemains == "Between 30% and 70%" && Holiday == "Yes" && BatteryRemains == "Between 15% and 70%" && Gender == "Male" && Time == "Afternoon" && FreeWifi == "Yes") appClass = "Not use";
            else appClass = "-";

            return appClass;
        }
    }
}
