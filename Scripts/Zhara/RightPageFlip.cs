using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class RightPageFlip : MonoBehaviour

{
    public int sound = 1;
    public static double page=0;
    public static double mpage = 0;
    public Button yourButton;
    static bool picked = false;
    static bool pickedSword = false;

    static bool p1 = true;
    static bool p2 = true;
    static bool p3 = true;
    static bool ex = true;

    public AudioSource btnaudio;
    public AudioClip money; //set this in ispector with audiofile
    public AudioClip click2; //set this in ispector with audiofile
    public AudioClip foodSound;
    
    public void Awake()
    {
        btnaudio = GetComponent<AudioSource>();
        
        
    }

    public void play()
    {
       
            Debug.Log("coindsoundplay");
            btnaudio.clip = click2;
         
           
        btnaudio.Play();
    }

    public void playm()
    {
        btnaudio.clip = money;
        btnaudio.Play();
    }

    public void playeat()
    {
        btnaudio.clip = foodSound;
        btnaudio.Play();
    }
    string page1_yes = "Sam's father got happy and gave him 25 coins for his journey. The Next morning, Sam started his journey. After several hours of walking he reached to a city and went to a hotel to rest.";

    string page1_no = "Sam slept at that night and dreamed that his brother is in danger. Therefore, in the morning he told his father that" +
        "he wants to go after his brother. The father got happy and gave him 20 coins for his journey."
        + "The next day, Sam started his journey and reached to a city and went to a hotel to rest.";

    string advice = "Next morning Sam went to his friend to ask him how he should go to the city in which his brother works. His friend told Sam there are 3 ways. He either should pay 10 coins and go with a boat, or" +
      "he should walk alone by himself from the forest without paying any money. But he should remember to take enough food with himself. There is one more option which he can also go with other people through forest.He should not forget about taking enough food if he choosed this option, too.";

    string shop = "The next morning, Sam went to a shop to do some shopping for his long journey. Later he went back to the hotel again to rest and get ready for tomorrow's journey.";

    string trip = "On his way back to the hotel, Sam thought a lot about his decision for his journey. After a while he decided to start his journey by:";

    string boat = "The next morning, Sam started the rest of his journey. On his way to the boat, he encountered a beast. He scared to death, but decided to fight with the beast. ";
    string forest = "The next morning, he started the rest of his journey. On his way to the forest, he encountered a beast. He scared to death, but decided to fight with the beast.";
    string group = "The next morning, he started the rest of his journey. He went and joined the group and on their way to the forest, they encountered a beast. He wondered with himself whether to help others and fight with the beast or run away.";




   



    public static string text = " At the first chapter of the story, Sam will have lots of battling adventures. " +
" Therefore, he has to be strong enough to be able to make it to the city in which his brother is missed. " +
       " Abilities such as strength and attacking abilities will help him a lot. " +
    "    The stort starts from the day Sam's father asks him to go after his brother. " +
"Then Sam's journey starts. The first chapter will end when Sam reached to the city in which his brother is missed.";
    public static string btw1 = "";
    public static string btw2 = "";
    public static string btw3 = "";
    public static string extra = "Next";
  
    public static string fight = "";
    bool win = false;
    bool btl = false;
    bool food = false;
    public static int btn = 0;
    public static int done = 0;
    public static int btn2 = 0;
    public static int btn3 = 0;
    public static int btn4 = 0;
    public static int btn5 = 0;
    int t = 0;
    public static bool btre = false;
    public static bool donere = false;
    public static bool btre2 = false;
    public static bool btre3 = false;
    public static bool btre4 = false;
    public static bool btre5 = false;

    static string cbname = "";
    

    void CoinsFunction(int value)
    {
        //+=
        InitializeValues.coins += value;
        this.transform.parent.GetChild(10).GetComponentInChildren<Text>().text = "Coins: " + InitializeValues.coins.ToString();
        picked = true;
    }

    void CoinsmFunction(int value)
    {
        //+=
        InitializeValues.coins = InitializeValues.coins- value;
        this.transform.parent.GetChild(10).GetComponentInChildren<Text>().text = "Coins: " + InitializeValues.coins.ToString();
        
    }

    bool bought = false;

    void SwordFunction(int value, string name, int cost)
    {

        if (InitializeValues.coins >= cost)
        {
            InitializeValues.equippedObj[0] = name;
            InitializeValues.swordValue = value;
            InitializeValues.coins -= cost;
            this.transform.parent.GetChild(10).GetComponentInChildren<Text>().text = "Coins: " + InitializeValues.coins.ToString();
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam bought a sword";
            pickedSword = true;
            bought = true;
            if(bought==true)
            { }
        }
        else { this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam doesn't have enough money"; }

    }

    void BackpackFunction(string name, int cost)
    {
        if (InitializeValues.coins >= cost)
        {
            InitializeValues.backpackObj.Add(name+"\n");
            InitializeValues.sizeBackpack = InitializeValues.sizeBackpack + 1;
            InitializeValues.coins -= cost;
            this.transform.parent.GetChild(10).GetComponentInChildren<Text>().text = "Coins: " + InitializeValues.coins.ToString();
            picked = true;
        }
    }

  

    private void Start()
    {

       
        if (btre == false && btre2==btre3==donere==false) { 
        this.transform.parent.GetChild(10).GetComponentInChildren<Text>().text = "Coins: " + InitializeValues.coins.ToString();
        this.transform.parent.GetChild(11).GetComponentInChildren<Text>().text = "HP: " + InitializeValues.lifePoints.ToString();
        
            change_page(text, btw1, btw2, btw3, extra);
            if (p1 == false) { GameObject.Find("btn_w1").GetComponent<Button>().interactable = false; }
            else { GameObject.Find("btn_w1").GetComponent<Button>().interactable = true; }

            if (p2 == false) { GameObject.Find("btn_w2").GetComponent<Button>().interactable = false; }
            else { GameObject.Find("btn_w2").GetComponent<Button>().interactable = true; }



            if (p3 == false) { GameObject.Find("btn_w3").GetComponent<Button>().interactable = false; }
            else { GameObject.Find("btn_w3").GetComponent<Button>().interactable = true; }

            if (ex == false) { GameObject.Find("extra").GetComponent<Button>().interactable = false; }
            else { GameObject.Find("extra").GetComponent<Button>().interactable = true; }
            }
        
            if(btre==true)
        {
            Debug.Log("here we are");

            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = true;
            GameObject.Find("extra").GetComponent<Button>().interactable = true;
            p1 = true;
            p2 = true;
            p3 = true;
            ex = true;


            text = "Sam walked a lot till he finally reached to a house. in front of the house" +
"there were two guards which did not seem to be really honorable but on" +
"the other hand, they looked pretty strong. Sam wondered if he can convince the gaurdians to let him in or if he is lucky enough to bribe them. He wondered he may have to fight with them."
            + "If none of them, he thought with himself that he can take the long route behind the house.";
            btw1 = "Talk with guardians";
            btw2 = "Bribe guardians";
            btw3 = "Fight with them";
            extra = "Next";

            change_page(text, btw1, btw2, btw3, extra);
            btre = false;
            page = 9;
            mpage = -9;
            btn = 0;
            return;

        }

        if (btre2 == true)
        {
            

            GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = true;
            p1 = false;
            p2 = false;
            p3 = false;
            ex = true;
           
            text ="He entered the castle which seemed so creepy. Sam saw some shadows and wondered if it is his brother's shadow? He got so happy and yelled: 'Brother, is that you?'"+
                " A voice came: 'Yes, Sam. Sam got so happy when he heard his brother's voice. Every where was dark and Sam could not see anywhere. He tried to understand the direction of the voice and started running toward it.";
                btw1 = "";
            Debug.Log("here we are btre2eeeeeeeeeeeeee");
            btw2 = "";
            btw3 = "";
            extra = "Next";
            
            change_page(text, btw1, btw2, btw3, extra);
            Debug.Log(text);
            page = 15;
            mpage = -15;
            btre2 = false;
            btn2 = 0;
            return;

        }

        if (btre3 == true)
        {
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = true;
            p1 = false;
            p2 = false;
            p3 = false;
            ex = true;

            text = "The two brothers got so happy seeing each another and huged each another. They came out of castle and went back to their father."+
                " He came all this way and now he is brother is with him. He realized happiness was so close to their family and finally it came to all of them. Sam and his brother started their journey to going back their father. Can they reach to their father, soon? [Coming back soon :)] ";
            btw1 = "";
            btw2 = "";
            btw3 = "";
            extra = "Next";
            Debug.Log("btre3  "+text);
            change_page(text, btw1, btw2, btw3, extra);
            page = 18;
            mpage = -18;
            btre3 = false;
            btn3 = 0;
            return;
        }

        if (donere == true)
        {
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = true;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = true;
            p3 = true;
            ex = false;

            text = " Finally Sam reached the well-know north door of ANGOR. The door" +
" was supervised by two guards that did not seem to be really honorable but on " +
"the other hand they looked pretty strong. Sam thought with himself to find a hidden way, " +
 "or beg them or fight with them.";
            btw1 = "Beg";
            btw2 = "Fight";
            btw3 = "Find a hidden way";
            extra = "";
            Debug.Log("___StartFunction___");
            change_page(text, btw1, btw2, btw3, extra);
            page=12;
            mpage=-12;
            donere = false;
            return;


        }




    }

    public void Update()
    {
        
    }

    public void avatar()
    {

        if (page < 11)
        {
            SceneManager.LoadScene("MenuCharacter");
        }
        else
        {
            SceneManager.LoadScene("MenuCharacter2");
        }


    }








    public void on_Click()
    {


        Debug.Log("here we are in on click");
        Debug.Log(page);
        var cb = EventSystem.current.currentSelectedGameObject;

        if(page==0 && mpage==0  )
        {
            Debug.Log("here we are in first page" + page + mpage);
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = true;
            p3 = false; ;
            ex = false;
            text = "Once apon a time there was a boy whose name was Sam. Sam lived with his father. " +
      "  His brother went to a city to work. A long time passed, but they did not recieve any news from him. " +
        "    The father asked Sam to go after his brother. Sam answered: ";
            btw1 = "Ok, I will";
            btw2 = "No, I can't";
            btw3 = "";
            extra = "";
            change_page(text, btw1, btw2, btw3, extra);
            page=0.1;
            mpage=-0.1;

            return;
           
        }

        if (mpage == -0.1 && page == 0.1 && cb.name == "btn_w1")
        {
            play();
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            p2 = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            p3 = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = true;
            ex = true;
            text = page1_yes;
            btw1 = "Accept 25 coins";
            btw2 = "";
            btw3 = "";
            extra = "next";
            page=1;

            change_page(text, btw1, btw2, btw3, extra);
            return;

        }

        if (mpage == -0.1 && page == 0.1 && cb.name == "btn_w2")
        {
            play();
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            p2 = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            p3 = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = true;
            ex = true;
            text = page1_no;
            btw1 = "Accept 20 coins";
            btw2 = "";
            btw3 = "";
            extra = "next";
            mpage=-1;
            change_page(text, btw1, btw2, btw3, extra);
            return;

        }

        if (mpage == -0.1 && page == 1 && cb.name == "btn_w1")
        {

            playm();
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam has 25 coins";
            CoinsFunction(25);
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
            p1 = false;

        }

        if (mpage == -1 && page == 0.1 && cb.name == "btn_w1")
        {
            playm();
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam has 20 coins";

            CoinsFunction(20);
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
            p1 = false;
        }

        if (page == 1 && cb.name == "extra" || mpage == -1 && cb.name == "extra")
        {

            GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            p1 = false;
            p2 = false;
            p3 = false;

            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            text = advice;
            btw1 = "";
            btw2 = "";
            btw3 = "";
            extra = "next";

            change_page(text, btw1, btw2, btw3, extra);
            if (mpage == -1)
            { page = 2; --mpage; }
            if (page == 1)
            { mpage = - 2; ++page; }
            return;

        }



        if (page == 2 && mpage == -2 && cb.name == "extra")
        {
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = true;
            p1 = true;
            p2 = true;
            p3 = true; ;
            text = shop;
            btw1 = "Wooden Sword: cost:9 atk:2";
            btw2 = "Meal: cost:4";
            btw3 = "Health portion: cost:13";
            extra = "Next";
            change_page(text, btw1, btw2, btw3, extra);
            ++page;
            --mpage;

            return;

        }


        if (page == 3 && mpage == -3 && cb.name == "btn_w1")
        {
            playm();
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
            p1 = false;

            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam bought a sword";

            SwordFunction(2, "Wooden Sword", 9);


        }

        if (page == 3 && mpage == -3 && cb.name == "btn_w2")
        {
            playm();
            if (InitializeValues.coins < 4)
            {
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;

                p2 = false;

                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam does not have enough coins to buy more meals.";
            }
            else
            {
                playm();
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam bought meal";
                BackpackFunction("Meal", 4);
            }



        }

        if (page == 3 && mpage == -3 && cb.name == "btn_w3")
        {
            playm();
            if (InitializeValues.coins < 13)
            {
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam do not have enough coins to buy more health portions.";
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;

                p3 = false;
            }

            else
            {
                playm();
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam bought a health potion";

                BackpackFunction("Health Potion (5 hp)", 13);
                //BackpackFunction("Old Amulet", 0);

            }

        }

        if (page == 3 && mpage == -3 && cb.name == "extra")
        {
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = true;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = true;
            p3 = true;
            ex = false;
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            Debug.Log("check next: ");
            text = trip;
            btw1 = "By a boat: pay 5 coins";
            btw2 = "Alone through forest";
            btw3 = "With the group";
            extra = "";

            if (InitializeValues.coins < 6)
            {
                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam does not have enough coins to travel by boat.";
            }



            change_page(text, btw1, btw2, btw3, extra);
            ++page;
            --mpage;

            return;
        }

        if (page == 4 && mpage == -4 && cb.name == "btn_w1")
        {

            CoinsmFunction(5);
            play();
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;

            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;

            p1 = true;
            p2 = false;
            p3 = false;

            BackpackFunction("boat", 5);
            text = boat;
            btw1 = "Fight";
            btw2 = "";
            btw3 = "";
            extra = "";

            change_page(text, btw1, btw2, btw3, extra);
            ++page;
            --mpage;
            return;
        }

        if (page == 4 && mpage == -4 && cb.name == "btn_w2")
        {
            play();
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;

            p1 = true;
            p2 = false;
            p3 = false;

            text = forest;
            btw1 = "Fight";
            btw2 = "";
            btw3 = "";
            extra = "";

            change_page(text, btw1, btw2, btw3, extra);
            ++page;
            --mpage;
            return;
        }

        if (page == 4 && mpage == -4 && cb.name == "btn_w3")
        {

            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;

            p1 = true;
            p2 = true;
            p3 = false;

            play();
            text = group;
            btw1 = "Fight";
            btw2 = "Run away";
            btw3 = "";
            extra = "";
            fight = "NF";
            change_page(text, btw1, btw2, btw3, extra);
            ++page;
            --mpage;

            return;
        }

        if (page == 5 && mpage == -5 && cb.name == "btn_w1")
        {

            play();
            if (btre == false)
            {
                ++btn;
                InitializeValues.lifeBeforeBattle = InitializeValues.lifePoints;
                InitializeValues.manaBeforeBattle = InitializeValues.manaPoints;
                SceneManager.LoadScene("BattleBeast");
            }
            //what happens when he comes back from battle?



        }

        if (page == 5 && mpage == -5 && cb.name == "btn_w2" && fight == "NF")
        {
            play();
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;

            p2 = true;
            p3 = false;
            text = "He ran as fast as he could until he reached to a mountation.Sam wondered with himself to climb the mountain or not.";
            btw1 = "Climb";
            btw2 = "Not climb";
            btw3 = "";
            extra = "";
            fight = "NF";
            change_page(text, btw1, btw2, btw3, extra);

            ++page;
            --mpage;
            return;
        }



        if (page == 6 && mpage == -6 && cb.name == "btn_w1" && fight == "NF")
        {

            play();
            ++t;

            int rngNumber = Random.Range(1, 14);
            if (InitializeValues.agility > rngNumber - 1)
            {


                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam won agility test and he could climb the mountain.";

                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
                GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = true;
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                p1 = true;
                p2 = true;
                p3 = true;
                ex = true;


                text = "Sam walked a lot till he finally reached to a house. in front of the house" +
    "there were two guards which did not seem to be really honorable but on" +
    "the other hand, they looked pretty strong. Sam wondered if he can convince the gaurdians to let him in or if he is lucky enough to bribe them. He wondered he may have to fight with them."
                + "If none of them, he thought with himself that he can take the long route behind the house.";
                btw1 = "Talk with guardians";
                btw2 = "Bribe guardians";
                btw3 = "Fight with them";
                extra = "Next";

                change_page(text, btw1, btw2, btw3, extra);

                ++page;
                --mpage;
                return;

            }
            else
            {

                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam lost agility test and he could not climb the mountain.";
                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                p1 = false;

            }
            return;


        }

        if (page == 6 && mpage == -6 && cb.name == "btn_w2" && fight == "NF")
        {
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = false;
            p3 = false;

            play();
            text = "The weather was getting darker and darker. Sam had to reach to a safe place to rest. He had walked a lot, so he decided to eat something.";
            btw1 = "eat food";
            btw2 = "";
            btw3 = "";
            extra = "Next";

            change_page(text, btw1, btw2, btw3, extra);
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            ++page;
            --mpage;
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Give Sam some food so he can continue.";
        }
        if (page == 7 && mpage == -7 && cb.name == "btn_w1")
        {
            food = false;
            int foodindex = 0;
            for (int i = 0; i < InitializeValues.sizeBackpack; i++)
            {
                if (InitializeValues.backpackObj[i].Equals("Meal\n"))
                {

                    food = true;
                    foodindex = i;
                }
            }

            if (food)
            {
                playeat();
                InitializeValues.backpackObj.RemoveAt(foodindex);
                InitializeValues.sizeBackpack--;
                ++page;
                --mpage;
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam ate food and is ready to proceed.";
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                p1 = false;
                ex = true;

            }

            else
            {
                play();
                InitializeValues.lifePoints -= 2;
                ++page;
                --mpage;
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam did not have enough food so his life point reduced.";
                this.transform.parent.GetChild(11).GetComponentInChildren<Text>().text = "HP: " + InitializeValues.lifePoints.ToString();
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                p1 = false;
                ex = true;

            }
        }






        if (page == 8 && mpage == -8 && cb.name == "extra")
        {
            Debug.Log("here we are");
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = true;
            GameObject.Find("extra").GetComponent<Button>().interactable = true;
            p1 = true;
            p2 = true;
            p3 = true;
            ex = true;


            text = "Sam walked a lot till he finally reached to a house. in front of the house" +
"there were two guards which did not seem to be really honorable but on" +
"the other hand, they looked pretty strong. Sam wondered if he can convince the gaurdians to let him in or if he is lucky enough to bribe them. He wondered he may have to fight with them."
            + "If none of them, he thought with himself that he can take the long route behind the house.";
            btw1 = "Talk with guardians";
            btw2 = "Bribe guardians";
            btw3 = "Fight with them";
            extra = "Next";

            change_page(text, btw1, btw2, btw3, extra);
            btre = false;
            ++page;
            --mpage;
            return;

        }

        if (page == 9 && mpage == -9 && cb.name == "btn_w1")
        {
            play();


            int rngNumber = Random.Range(1, 14);
            if (InitializeValues.ability1 > rngNumber - 1)
            {


                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam won intelligence test and could convince the guardians to enter the house.";

                Debug.Log("here we won, the page number is" + page);
                Debug.Log(this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text);

                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                p1 = false;
                p2 = false;
                p3 = false;
                ex = true;

                text = "After reaching the house, Sam realized it is the " +
" entrance walls of ANGOR the city of the sorcerers. The next part of his adventure " +
"will require attention and caution to communicate with people " +
"not ght monsters, Sam still be aware of the dangers that someone encounters. Sharpness, stealth, kindness and" +
" social abilities will be the keys to gather information to rescue his brother." +
" But he has to remember this city is full of dark and powerful magic.";
                btw1 = "";
                btw2 = "";
                btw3 = "";
                extra = "Next";

                change_page(text, btw1, btw2, btw3, extra);
                page = 11;
                mpage = -11;
                return;

            }
            else
            {

                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam lost intelligence test and could not convince the guardians to enter the house.";
                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                Debug.Log("here we lost, the page number is" + page);
                Debug.Log(this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text);
                p1 = false;

            }


        }

        if (page == 9 && mpage == -9 && cb.name == "btn_w2")
        {
            play();


            int rngNumber = Random.Range(1, 14);
            if (InitializeValues.luck > rngNumber - 1)
            {


                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam won luck test and could bribe the guardians to enter the house.";

                Debug.Log(this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text);

                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                p1 = false;
                p2 = false;
                p3 = false;
                ex = true;

                text = "After reaching the house, Sam realized it is the " +
" entrance walls of ANGOR the city of the sorcerers. The next part of his adventure " +
"will require attention and caution to communicate with people " +
"not ght monsters, Sam still be aware of the dangers that someone encounters. Sharpness, stealth, kindness and" +
" social abilities will be the keys to gather information to rescue his brother." +
" But he has to remember this city is full of dark and powerful magic.";
                btw1 = "";
                btw2 = "";
                btw3 = "";
                extra = "Next";

                change_page(text, btw1, btw2, btw3, extra);
                page = 11;
                mpage = -11;
                return;
            }
            else
            {

                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam lost luck test and could not bribe the guardians to enter the house.";
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
                p2 = false;
                Debug.Log(this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text);

            }


        }

        if (page == 9 && mpage == -9 && cb.name == "btn_w3")
        {
            play();


            int rngNumber = Random.Range(1, 14);
            if (InitializeValues.strenght > rngNumber - 1)
            {


                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam won strength test and could defeat guardians to enter the house.";

                Debug.Log(this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text);

                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                p1 = false;
                p2 = false;
                p3 = false;
                ex = true;

                text = "After reaching the house, Sam realized it is the " +
" entrance walls of ANGOR the city of the sorcerers. The next part of his adventure " +
"will require attention and caution to communicate with people " +
"not ght monsters, Sam still be aware of the dangers that someone encounters. Sharpness, stealth, kindness and" +
" social abilities will be the keys to gather information to rescue his brother." +
" But he has to remember this city is full of dark and powerful magic.";
                btw1 = "";
                btw2 = "";
                btw3 = "";
                extra = "Next";

                change_page(text, btw1, btw2, btw3, extra);
                page = 11;
                mpage = -11;
                return;
            }
            else
            {

                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam lost strength test and could not defeat guardians to enter the house.";
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
                Debug.Log(this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text);
                p3 = false;
            }


        }

        if (page == 9 && mpage == -9 && cb.name == "extra")
        {
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = true;
            p3 = false;
            ex = false;
            text = "If none of them, he thought with himself that he can take the long route behind the house." +
                "Or, if he can not stand walking the long route, he can pay a horse rider to give him a ride. ";
            btw1 = "Take the long route";
            btw2 = "Go with horse rider: 5 coins";
            btw3 = "";
            extra = "";

            change_page(text, btw1, btw2, btw3, extra);

            ++page;
            --mpage;
            return;

        }

        if (page == 10 && mpage == -10 && cb.name == "btn_w1")
        {
            play();


            int rngNumber = Random.Range(1, 14);
            if (InitializeValues.stamina > rngNumber - 1)
            {


                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam won stamina test and was strong enough to take the long route.";

                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                p1 = false;
                p2 = false;
                p3 = false;
                ex = true;

                text = "After reaching the house, Sam realized it is the " +
" entrance walls of ANGOR the city of the sorcerers. The next part of his adventure " +
"will require attention and caution to communicate with people " +
"not ght monsters, Sam still be aware of the dangers that someone encounters. Sharpness, stealth, kindness and" +
" social abilities will be the keys to gather information to rescue his brother." +
" But he has to remember this city is full of dark and powerful magic.";
                btw1 = "";
                btw2 = "";
                btw3 = "";
                extra = "Next";

                change_page(text, btw1, btw2, btw3, extra);
                page = 11;
                mpage = -11;
                return;

            }
            else
            {

                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam did not win stamina test and was not strong enough to take the long route.";
                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                p1 = false;

            }
        }
        if (page == 10 && mpage == -10 && cb.name == "btn_w2")
        {
            play();

            if (InitializeValues.coins >= 5)
            {
                CoinsmFunction(5);
                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                p1 = false;
                p2 = false;
                p3 = false;
                ex = true;

                text = "After reaching the house, Sam realized it is the " +
" entrance walls of ANGOR the city of the sorcerers. The next part of his adventure " +
"will require attention and caution to communicate with people " +
"not ght monsters, Sam still be aware of the dangers that someone encounters. Sharpness, stealth, kindness and" +
" social abilities will be the keys to gather information to rescue his brother." +
" But he has to remember this city is full of dark and powerful magic.";
                btw1 = "";
                btw2 = "";
                btw3 = "";
                extra = "Next";

                change_page(text, btw1, btw2, btw3, extra);
                page = 11;
                mpage = -11;
                return;
            }
            else if (InitializeValues.coins < 5)

            {


                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "The horse rider man was so kind and let Sam go without paying money.";

                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                p1 = false;
                p2 = false;
                p3 = false;
                ex = true;

                text = "After reaching the house, Sam realized it is the " +
" entrance walls of ANGOR the city of the sorcerers. The next part of his adventure " +
"will require attention and caution to communicate with people " +
"not ght monsters, Sam still be aware of the dangers that someone encounters. Sharpness, stealth, kindness and" +
" social abilities will be the keys to gather information to rescue his brother." +
" But he has to remember this city is full of dark and powerful magic.";
                btw1 = "";
                btw2 = "";
                btw3 = "";
                extra = "Next";

                change_page(text, btw1, btw2, btw3, extra);
                page = 11;
                mpage = -11;
                return;

            }

        }




        if (page == 11 && mpage == -11)
        {
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "The introduction of Chapter two:";

            GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = true;
            p1 = false;
            p2 = false;
            p3 = false;
            ex = true;

            text = "After the long journey in the forest Sam sees, in the distance, the tall"+
" walls of ANGOR the city of unknowns. The next part of his adventure "+
" will require attention and caution, because in this city there are"+
" dangers that he encounters while"+
" investigating the city. Sharpness, stealth, kindness and"+
" social abilities will be the keys to gather information to his your brother."+
" But he has to remember this city is full of dark and powerful magic. Now "+
" get ready for your next adventure.";
            btw1 = "";
            btw2 = "";
            btw3 = "";
            extra = "Next";

            change_page(text, btw1, btw2, btw3, extra);
            page = 11.5;
            mpage = -11.5;
            return;
        }
            if(page==11.5 && mpage==-11.5)
            { 
            RightPageFlip.donere = true;
            
            SceneManager.LoadScene("CharacterCreation2");

        }


        /*********************************************************************/



        if (page == 12 && mpage == -12 && cb.name == "btn_w1")
        {

            play();


            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = true;
            p3 = false;
            ex = false;
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            text = "Sam thought with himself to beg the guardians to let him. He thought himself although I never begged for anything but I will do anything for my dearest brother. He again said to himself should not I look for another way to get in? He finally decided to: ";
            btw1 = "Beg";
            btw2 = "Not beg";
            btw3 = "";
            extra = "";

            change_page(text, btw1, btw2, btw3, extra);
            page = 13;
            mpage = -13;
            return;
        }

        if (page == 13 && mpage == -13 && cb.name == "btn_w1")
        {
            play();


            int rngNumber = Random.Range(1, 14);
            if (InitializeValues.integrity > rngNumber - 1)
            {


                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam won empathy test and was successful to enter the city.";

                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                p1 = false;
                p2 = false;
                p3 = false;
                ex = true;

                text = "He entered the castle which seemed so creepy. Sam saw some shadows and wondered if it is his brother's shadow? He got so happy and yelled: 'Brother, is that you?'" +
                " A voice came: 'Yes, Sam. Sam got so happy when he heard his brother's voice. Every where was dark and Sam could not see anywhere. He tried to understand the direction of the voice and started running toward it.";
                btw1 = "";
                btw2 = "";
                btw3 = "";
                extra = "Next";

                change_page(text, btw1, btw2, btw3, extra);
                page = 15;
                mpage = -15;
                return;

            }
            else
            {

                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam did not win empathy test and was not successful to enter the castle.";
                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                p1 = false;


            }

        }

        if (page == 13 && mpage == -13 && cb.name == "btn_w2")
        {
            play();

            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = false;
            p3 = false;
            ex = false;
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            text = "decided to fight instead of beging. He had so much difficultied from the start of his journey but never begged for anything. 'Why should I do this, now?', he thought with himself. Therefore, he attacked them: ";
            btw1 = "Fight";
            btw2 = "";
            btw3 = "";
            extra = "";

            change_page(text, btw1, btw2, btw3, extra);
            page = 14;
            mpage = -14;
            return;

        }

        if (page == 12 && mpage == -12 && cb.name == "btn_w2")
        {
            play();
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = false;
            p3 = false;
            ex = false;

            text = "Sam decided to fight with guardians in order to enter the city. He said himself although this is difficult, but I want to find my brother and I have to strong. So he realized he is reacy to attack:";
            btw1 = "Fight";
            btw2 = "";
            btw3 = "";
            extra = "";

            change_page(text, btw1, btw2, btw3, extra);
            page = 14;
            mpage = -14;
            return;
        }




        if (page == 12 && mpage == -12 && cb.name == "btn_w3")
        {
            play();


            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = true;
            p3 = false;
            ex = false;

            text = "Sam thought with himself to find a hidden way. He said to himself that there is always a way to my goal and I should not get dissapointed. I can find a way if I want. He thought himself if he should put time to find a hidden way or should not. Finally he decided: ";
            btw1 = "Find way";
            btw2 = "Not find way";
            btw3 = "";
            extra = "";

            change_page(text, btw1, btw2, btw3, extra);
            page = 16;
            mpage = -16;
            return;
        }

        if (page == 16 && mpage == -16 && cb.name == "btn_w1")
        {

            play();


            int rngNumber = Random.Range(1, 14);
            if (InitializeValues.agility > rngNumber - 1)
            {


                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam won stealth test and was successful to find a hidden way.";

                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
                GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
                GameObject.Find("extra").GetComponent<Button>().interactable = true;
                p1 = false;
                p2 = false;
                p3 = false;
                ex = true;

                text = "He entered the castle which seemed so creepy. Sam saw some shadows and wondered if it is his brother's shadow? He got so happy and yelled: 'Brother, is that you?'" +
                " A voice came: 'Yes, Sam. Sam got so happy when he heard his brother's voice. Every where was dark and Sam could not see anywhere. He tried to understand the direction of the voice and started running toward it.";
                btw1 = "";
                btw2 = "";
                btw3 = "";
                extra = "Next";

                change_page(text, btw1, btw2, btw3, extra);
                page = 15;
                mpage = -15;
                return;

            }
            else
            {

                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "Sam did not win stealth test and was not successful to find a hidden way.";
                GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
                p1 = false;




            }
        }

        if (page == 16 && mpage == -16 && cb.name == "btn_w2")
        {


            play();
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = false;
            p3 = false;
            ex = false;

            text = "Sam could not find a hidden way and decided to fight to enter the castle. He was a little bit scared, but he remembered his brother and father. Always whenhe thought of them he got energy. He said to himsself: 'No matter what. I will find my brother' and attacked them.";
            btw1 = "Fight";
            btw2 = "";
            btw3 = "";
            extra = "";

            change_page(text, btw1, btw2, btw3, extra);
            page = 14;
            mpage = -14;
            return;

        }


        if (page == 14 && mpage == -14)
        {
            play();
            if (btre2 == false)
            {
                InitializeValues.lifeBeforeBattle = InitializeValues.lifePoints;
                InitializeValues.manaBeforeBattle = InitializeValues.manaPoints;
                ++btn2;
                SceneManager.LoadScene("BattleGuardO");
            }
        }

        if(page==15 && mpage==-15)
        {
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = true;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = true;
            p2 = false;
            p3 = false;
            ex = false;
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            text = "Sam got happy when he saw his brother. He started running to him. "+
                "Suddenly a creepy creature appeared. His brother yelled: 'Sam, run. Save yourself.' "+
                " But, Sam wanted to save his brother. He yelled back: 'Brother, I have come a long way to save you. We will go back to our father Either together or none of us.'"+
                "   He yelled at the creature and attacked it.";
            btw1 = "Fight";
            btw2 = "";
            btw3 = "";
            extra = "";

            change_page(text, btw1, btw2, btw3, extra);
            page = 17;
            mpage = -17;
            return;
        }

        if(page==17 && mpage==-17)
        {
            play();
            if (btre3 == false)
            {
                ++btn3;
                InitializeValues.lifeBeforeBattle = InitializeValues.lifePoints;
                InitializeValues.manaBeforeBattle = InitializeValues.manaPoints;
                SceneManager.LoadScene("BattleStatue");
            }

        }

        if (page == 18 && mpage == -18)
        {
            GameObject.Find("btn_w1").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w2").GetComponent<Button>().interactable = false;
            GameObject.Find("btn_w3").GetComponent<Button>().interactable = false;
            GameObject.Find("extra").GetComponent<Button>().interactable = false;
            p1 = false;
            p2 = false;
            p3 = false;
            ex = false;
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            text = "Congrats, you finished the game. You helped Sam to find his loved brother and feel happy again. You gave back happiness to their family again. We are so proud of you! We hope you have had a good time playing it. And, we hope to see you soon again with a new version of the story, new characters and features. ";
            btw1 = "";
            btw2 = "";
            btw3 = "";
            extra = "";

            change_page(text, btw1, btw2, btw3, extra);
            
            return;

        }


    }

   /**************************************/

    public void change_page(string text, string bt1, string bt2, string bt3, string ext)
    {
        this.transform.parent.GetChild(2).GetComponentInChildren<Text>().text = text;
        this.transform.parent.GetChild(3).GetComponentInChildren<Text>().text = bt1;
        this.transform.parent.GetChild(4).GetComponentInChildren<Text>().text = bt2;
        this.transform.parent.GetChild(5).GetComponentInChildren<Text>().text = bt3;
        this.transform.parent.GetChild(7).GetComponentInChildren<Text>().text = ext;


    }


}