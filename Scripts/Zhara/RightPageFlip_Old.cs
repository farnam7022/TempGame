/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class RightPageFlip_Old : MonoBehaviour
{

 
    public static int page = 0;
    public static int mpage = 0;
    public Button yourButton;
    static bool picked = false;
    static bool pickedSword = false;


    string page1_yes = "His father got happy and gave him 25 coins for his journey. The boy started his journey and reached to a city and went to a hotel to rest.";

    string page1_no = "The boy slept at that night and dreamed that his brother is in danger. Therefore, in the morning he told his father that" +
        "he wants to go after his brother. The father got happy and gave him 20 coins for his journey."
        + "Next day, the boy started his journey and reached to a city and went to a hotel to rest.";

    string advice = "Next morning the boy went to his friend to ask him how he should go to the city which his brother works in. His friend told him there are 3 ways. He either should pay 10 coins and go with a boat, or" +
      "he should walk alone by himself from the forest without paying any monet. But he should remember to take enough food with himself. There is one more option which he can also go with other people through forest.He should not forget about taking enough food if he choosed this option, too.";

    string shop = "Next morning, he went to a shop to do some shopping for his long journey. Later he went bacl to hotel again to rest and get ready for tomorrow's journey.";

    string trip = "The next morning, the boy woke up and thought a lot about his decision for his journey. After a while he again decided to start his journey by:";

    string boat = "The next morning, he started the rest of his journey. On his way to the boat, he encountered a beast which he had to fight with.";
    string forest = "The next morning, he started the rest of his journey. On his way to the forest, he encountered a beast which he had to fight with.";
    string group = "The next morning, he started the rest of his journey. He went and joined the group and on their way to the forest, they encountered a beast which he could choose whether to fight with it or not" +
        "He could either fight with the beast or do an ability test in order to be able to continue his journey.";








    public static string text = "Once apon a time there was a boy who lived with his father. His brother went to a city to work. A long time passed, but they did not recieve any news from him. The father asked the boy to go after his brother. The boy siad ";
    public static string btw1 = "Yes";
    public static string btw2 = "No";
    public static string btw3 = "";
    public static string extra = "";
    public static string fight = "";
    bool win = false;



    void CoinsFunction(int value)
    {
        //+=
        InitializeValues.coins = value;
        this.transform.parent.GetChild(8).GetComponentInChildren<Text>().text = "Coins: " + InitializeValues.coins.ToString();
        picked = true;
    }



    void SwordFunction(int value, string name, int cost)
    {

        if (InitializeValues.coins >= cost)
        {
            InitializeValues.equippedObj[0] = name;
            InitializeValues.swordValue = value;
            InitializeValues.coins -= cost;
            this.transform.parent.GetChild(8).GetComponentInChildren<Text>().text = InitializeValues.coins.ToString();
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You bought a sword";
            pickedSword = true;
        }
        else { this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You don't have enough money"; }

    }

    void BackpackFunction(string name, int cost)
    {
        if (InitializeValues.coins >= cost)
        {
            InitializeValues.backpackObj.Add(name+"\n");
            InitializeValues.sizeBackpack = InitializeValues.sizeBackpack + 1;
            InitializeValues.coins -= cost;
            this.transform.parent.GetChild(8).GetComponentInChildren<Text>().text = InitializeValues.coins.ToString();
            picked = true;
        }
    }


    private void Start()
    {
        this.transform.parent.GetChild(8).GetComponentInChildren<Text>().text = "Coins: " + InitializeValues.coins.ToString();
        this.transform.parent.GetChild(10).GetComponentInChildren<Text>().text = "Health: " + InitializeValues.lifePoints.ToString();
        change_page(text, btw1, btw2, btw3, extra);

    }

    public void Update()
    {
        // this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
    }

    public void avatar()
    {
        Debug.Log("move to avatar page ");

        if (page < 3)
        {
            SceneManager.LoadScene("MenuCharacter");
        }
        else
        {
            SceneManager.LoadScene("MenuCharacter2");
        }

    }






    int t = 0;


    public void on_Click()
    {

        var cb = EventSystem.current.currentSelectedGameObject;



        if (mpage == 0 && page == 0 && cb.name == "btn_w1")
        {

            text = page1_yes;
            btw1 = "Get 25 coins";
            btw2 = "";
            btw3 = "";
            extra = "next";
            ++page;

            change_page(text, btw1, btw2, btw3, extra);
            return;

        }

        if (mpage == 0 && page == 0 && cb.name == "btn_w2")
        {
            text = page1_no;
            btw1 = "Get 20 coins";
            btw2 = "";
            btw3 = "";
            extra = "next";
            --mpage;
            change_page(text, btw1, btw2, btw3, extra);
            return;

        }

        if (mpage == 0 && page == 1 && cb.name == "btn_w1")
        {
            if (!picked)
            {
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You got 25 coins";
                CoinsFunction(25);

            }
            else { this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You can get it just once."; }
        }

        if (mpage == -1 && page == 0 && cb.name == "btn_w1")
        {
            if (!picked)
            {
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You got 20 coins";

                CoinsFunction(20);

            }
            else { this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You can get it just once."; }

        }

        if (page == 1 && cb.name == "extra" || mpage == -1 && cb.name == "extra")
        {
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            text = advice;
            btw1 = "";
            btw2 = "";
            btw3 = "";
            extra = "next";

            change_page(text, btw1, btw2, btw3, extra);
            if (mpage == -1)
            { page = page + 2; --mpage; }
            if (page == 1)
            { mpage = mpage - 2; ++page; }
            return;

        }



        if (page == 2 && mpage == -2 && cb.name == "extra")
        {
            Debug.Log("check next: " + page + mpage);

            text = shop;
            btw1 = "Wooden Sword: cost:9 atk:2";
            btw2 = "2xMeals: cost:4";
            btw3 = "Health portion: cost:13";
            extra = "Next";
            change_page(text, btw1, btw2, btw3, extra);
            ++page;
            --mpage;

            return;

        }

        if (page == 3 && mpage == -3 && cb.name == "btn_w1")
        {
            if (!pickedSword)
            {
                //this.transform.parent.GetChild(3).GetComponentInChildren<Text>().color = Color.clear;
                SwordFunction(2, "Wooden Sword", 9);
            }

            else { this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You can buy sword only once"; }

            //add sword to backpack
        }

        if (page == 3 && mpage == -3 && cb.name == "btn_w2")
        {
            if (InitializeValues.coins < 4)
            { //this.transform.parent.GetChild(4).GetComponentInChildren<Text>().color = Color.clear; 
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You do not have enough coins to buy it.";
            }
            else
            {
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You bought food";
                BackpackFunction("Meal", 4);
            }


            //add food to backpack
        }

        if (page == 3 && mpage == -3 && cb.name == "btn_w3")
        {
            if (InitializeValues.coins < 13)
            {
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You do not have enough coins to buy it.";
                //this.transform.parent.GetChild(5).GetComponentInChildren<Text>().color = Color.clear; 
            }

            else
            {
                this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You bought health potion";

                BackpackFunction("Health Potion (5 hp)", 13);
                BackpackFunction("Old Amulet", 0);

            }

        }

        if (page == 3 && mpage == -3 && cb.name == "extra")
        {
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "";
            Debug.Log("check next: ");
            text = trip;
            btw1 = "By a boat";
            btw2 = "Alone through forest";
            btw3 = "With the group";
            extra = "";
            change_page(text, btw1, btw2, btw3, extra);
            ++page;
            --mpage;
            return;
        }

        if (page == 4 && mpage == -4 && cb.name == "btn_w1")
        {
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
            text = group;
            btw1 = "Fight";
            btw2 = "Not fight";
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
            //Debug.Log("move to fighting page ");
            InitializeValues.lifeBeforeBattle = InitializeValues.lifePoints;
            InitializeValues.manaBeforeBattle = InitializeValues.manaPoints;

            SceneManager.LoadScene("BattleGuardY");

        }

        if (page == 5 && mpage == -5 && cb.name == "btn_w2" && fight == "NF")
        {

            text = "They walked until reached to a mountation.They had to choose whether climb the mountain or not.";
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
        //Debug.Log("move to ability test ");
        //SceneManager.LoadScene("ability test");
        /* int rngNumber = Random.Range(1, 14);
         if (InitializeValues.ability1 > rngNumber - 1)
         {

             //    SceneManager.LoadScene("End_Ability_Win");
             this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You won ability test and can choose how to proceed.";

         }
         else
         {
             //SceneManager.LoadScene("End_Ability_Lose");
             this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You lost ability test and can not climb the mountain.";
         }*/
        // if win go to contrats scene!
        //if loose go to game over scene!!*/

        /*



        if (page == 6 && mpage == -6 && cb.name == "btn_w1" && fight == "NF")
        {
            ++t;
            if (t == 1)
            {
                int rngNumber = Random.Range(1, 14);
                if (InitializeValues.ability1 > rngNumber - 1)
                {

                    //    SceneManager.LoadScene("End_Ability_Win");
                    this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You won ability test and can climb the mountain.";

                }
                else
                {
                    //SceneManager.LoadScene("End_Ability_Lose");
                    this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You lost ability test and can not climb the mountain.";
                }
            }
            else { this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "You wcan do the ability test just once."; }
        }

        if (page == 6 && mpage == -6 && cb.name == "btn_w2" && fight == "NF")
        {
            Debug.Log("check nccc: " + page + mpage + cb.name);
            this.transform.parent.GetChild(9).GetComponentInChildren<Text>().text = "This is end of the game for now.";
        }


    }

    public void change_page(string text, string bt1, string bt2, string bt3, string ext)
    {
        this.transform.parent.GetChild(2).GetComponentInChildren<Text>().text = text;
        this.transform.parent.GetChild(3).GetComponentInChildren<Text>().text = bt1;
        this.transform.parent.GetChild(4).GetComponentInChildren<Text>().text = bt2;
        this.transform.parent.GetChild(5).GetComponentInChildren<Text>().text = bt3;
        this.transform.parent.GetChild(7).GetComponentInChildren<Text>().text = ext;


    }


}*/