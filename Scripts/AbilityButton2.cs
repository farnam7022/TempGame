using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AbilityButton2 : MonoBehaviour { 

    int ComputeSumValues()
    {
        return InitializeValues.strenght + InitializeValues.agility + InitializeValues.stamina + InitializeValues.ability1 + InitializeValues.integrity;
    }

    void SubUpdate(int stat, int child, bool onStart)
    {
        

            if (stat < 15 && stat > 6)
            {
                this.transform.GetChild(child).GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(child).GetChild(2).gameObject.SetActive(true);
            }
            if (stat > 14 || ComputeSumValues() > 38)
            {
                this.transform.GetChild(child).GetChild(1).gameObject.SetActive(false);
            if (onStart)
            {
                this.transform.GetChild(child).GetChild(2).gameObject.SetActive(false);
            }

        }
            else if (stat < 7)
            {
                this.transform.GetChild(child).GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(child).GetChild(2).gameObject.SetActive(false);
            }
    }


    void Start()
    {

        InitializeValues.agility = 6;
        this.transform.GetChild(3).GetComponentInChildren<Text>().text = InitializeValues.agility.ToString();

        InitializeValues.ability1 = 6;
        this.transform.GetChild(5).GetComponentInChildren<Text>().text = InitializeValues.ability1.ToString();

        InitializeValues.integrity = 6;
        this.transform.GetChild(6).GetComponentInChildren<Text>().text = InitializeValues.integrity.ToString();

        this.transform.GetChild(2).GetComponentInChildren<Text>().text = InitializeValues.strenght.ToString();

        this.transform.GetChild(4).GetComponentInChildren<Text>().text = InitializeValues.stamina.ToString();

        this.transform.GetChild(7).GetComponentInChildren<Text>().text = InitializeValues.luck.ToString();

        this.transform.GetChild(8).GetComponentInChildren<Text>().text = InitializeValues.speed.ToString();

        this.transform.GetChild(9).GetComponentInChildren<InputField>().text = InitializeValues.notes;

        string backpack = "";
        for (int i = 0; i < InitializeValues.sizeBackpack; i++)
        {
            backpack += "-" + InitializeValues.backpackObj[i] + "\n";
        }

        this.transform.GetChild(10).GetComponent<Text>().text = backpack;

        this.transform.GetChild(11).GetComponentInChildren<InputField>().text = InitializeValues.heroName;

        this.transform.GetChild(12).GetComponentInChildren<Text>().text = InitializeValues.manaPoints.ToString();

        this.transform.GetChild(13).GetComponentInChildren<Text>().text = InitializeValues.lifePoints.ToString();

        this.transform.GetChild(14).GetComponent<Text>().text = "The tower of Angor";
        

        this.transform.GetChild(15).GetComponentInChildren<Text>().text = InitializeValues.saves.ToString();

        string equipped = "";


        for (int i = 0; i < InitializeValues.sizeEquipped; i++)
        {
            if (i == 0)
            {
                equipped += InitializeValues.equippedObj[i] + " = " + InitializeValues.swordValue.ToString() + "\n";
            }
            else
            {
                equipped += InitializeValues.equippedObj[i] + " = " + InitializeValues.shieldValue.ToString() + "\n";

            }
        }

        this.transform.GetChild(16).GetComponent<Text>().text = equipped;

        this.transform.GetChild(17).GetComponentInChildren<Text>().text = InitializeValues.coins.ToString();


        if (ComputeSumValues() > 38)
        {
            this.transform.GetChild(18).GetComponent<Text>().text = "You don't have any point to share between the abilities";
            GameObject.FindWithTag("Arrow").transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            int remAb = 39 - ComputeSumValues();
            this.transform.GetChild(18).GetComponent<Text>().text = "You still have " + remAb.ToString() + " points to share between the abilities";
            GameObject.FindWithTag("Arrow").transform.localScale = new Vector3(0, 0, 0);
            AbilityButton.setUpComplete = false;
        }

        SubUpdate(InitializeValues.agility, 3, true);
        SubUpdate(InitializeValues.ability1, 5, true);
        SubUpdate(InitializeValues.integrity, 6, true);

    }

    void Update()
    {


        SubUpdate(InitializeValues.agility, 3, false);
        SubUpdate(InitializeValues.ability1, 5, false);
        SubUpdate(InitializeValues.integrity, 6, false);
       


        if (ComputeSumValues() == 39)
        {
            AbilityButton.setUpComplete = true;
        }
        else {
            AbilityButton.setUpComplete = false;
        }

       
    }
}