using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetValues : MonoBehaviour
{

    void Start()
    {
        this.transform.GetChild(2).GetComponentInChildren<Text>().text = InitializeValues.strenght.ToString();
        this.transform.GetChild(3).GetComponentInChildren<Text>().text = InitializeValues.agility.ToString();
        this.transform.GetChild(4).GetComponentInChildren<Text>().text = InitializeValues.stamina.ToString();
        this.transform.GetChild(5).GetComponentInChildren<Text>().text = InitializeValues.ability1.ToString();
        this.transform.GetChild(6).GetComponentInChildren<Text>().text = InitializeValues.integrity.ToString();
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
        this.transform.GetChild(14).GetComponent<Text>().text = InitializeValues.chapter;
        this.transform.GetChild(15).GetComponentInChildren<Text>().text = InitializeValues.saves.ToString();

        string equipped = "";
        for (int i = 0; i < InitializeValues.sizeEquipped; i++)
        {
            equipped += InitializeValues.equippedObj[i] + " = ";

            //if is 0 sword value or defense
            if (i == 0)
            {
                equipped += InitializeValues.swordValue + "\n";
            }
            else if (i == 1) {
                equipped += InitializeValues.shieldValue + "\n";

            }
        }
        this.transform.GetChild(16).GetComponent<Text>().text = equipped;
        this.transform.GetChild(17).GetComponentInChildren<Text>().text = InitializeValues.coins.ToString();



    }

}
