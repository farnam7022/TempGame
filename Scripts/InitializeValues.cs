using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;



public class InitializeValues : MonoBehaviour {

    public static int strenght;
    public static int agility;
    public static int integrity;
    public static int stamina;
    public static int ability1;
    public static int luck;
    public static int speed;
    public static string notes;
    string backpack;
    public static string heroName;
    public static int manaPoints;
    public static int lifePoints;

    public static int lifePointsMax;


    public static int saves;
    public static string chapter;
    string equipped;
    public static int coins;



    public static int swordValue;
    public static int shieldValue;

    

    public static List<string> backpackObj = new List<string>();
    public static int sizeBackpack;


    public static string[] equippedObj;
    public static int sizeEquipped = 2;



    public static int lifeBeforeBattle;
    public static int manaBeforeBattle;


    // Use this for initialization
    void Start () {
        strenght = 6;
        this.transform.GetChild(2).GetComponentInChildren<Text>().text = strenght.ToString();

        agility = 6;
        this.transform.GetChild(3).GetComponentInChildren<Text>().text = agility.ToString();

        stamina = 6;
        this.transform.GetChild(4).GetComponentInChildren<Text>().text = stamina.ToString();

        ability1 = 6;
        this.transform.GetChild(5).GetComponentInChildren<Text>().text = ability1.ToString();

        integrity = 6;
        this.transform.GetChild(6).GetComponentInChildren<Text>().text = integrity.ToString();

        luck = 3;
        this.transform.GetChild(7).GetComponentInChildren<Text>().text = luck.ToString();

        speed = (agility + luck) / 2;
        this.transform.GetChild(8).GetComponentInChildren<Text>().text = speed.ToString();

        notes = "Here YOU can write your notes. You have limited space though.\nExample:\n\nTHIS GAME IS BRILLIANT";
        this.transform.GetChild(9).GetComponentInChildren<InputField>().text = notes;

        sizeBackpack = 0;
        backpack = "";

        this.transform.GetChild(10).GetComponent<Text>().text = "";

        heroName = "Sam";
        this.transform.GetChild(11).GetComponentInChildren<Text>().text = heroName;

        manaPoints = 20;
        this.transform.GetChild(12).GetComponentInChildren<Text>().text = manaPoints.ToString();

        lifePoints = 20;
        lifePointsMax = 20;
        this.transform.GetChild(13).GetComponentInChildren<Text>().text = lifePoints.ToString();

        chapter = "The forest and the darkness.";
        this.transform.GetChild(14).GetComponent<Text>().text = chapter;

        saves = 0;
        this.transform.GetChild(15).GetComponentInChildren<Text>().text = saves.ToString();

        equipped = "";
        equippedObj = new string[2];
        equippedObj[0] = "Basic-Sword";
        equippedObj[1] = "Basic-Shield";

        for (int i = 0; i < sizeEquipped; i++)
        {
            if (i == 0)
            {
                equipped += equippedObj[i] + " = " + InitializeValues.swordValue.ToString() + "\n";
            }
            else {
                equipped += equippedObj[i] + " = " + InitializeValues.shieldValue.ToString() + "\n";

            }
        }

        this.transform.GetChild(16).GetComponent<Text>().text = equipped;

        coins = 0;
        this.transform.GetChild(17).GetComponentInChildren<Text>().text = coins.ToString();

        RightPageFlip.page = 0;
        RightPageFlip.mpage = 0;

        GameObject.FindWithTag("Arrow").transform.localScale = new Vector3(0, 0, 0);


    }
}
