using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EquipmentScript : MonoBehaviour {

    bool picked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickSword(){

        InitializeValues.equippedObj[0] = this.transform.GetComponentInChildren<Text>().text;
        //InitializeValues.swordValue = this.transform.name; Covert string to int
        InitializeValues.swordValue = 10;
        //this.tranform.gameObject.SetActive(false);
        //call the button as the value
        //int swordValueAttack = GetComponent;

        //string swordName = this.transform.GetComponentInChildren<Text>().text;

    }

    public void onClickShield()
    {

        InitializeValues.equippedObj[1] = this.transform.GetComponentInChildren<Text>().text;
        //InitializeValues.swordValue = this.transform.name; Covert string to int
        InitializeValues.shieldValue = 8;
        //this.tranform.gameObject.SetActive(false);
        //call the button as the value
        //int swordValueAttack = GetComponent;

        //string swordName = this.transform.GetComponentInChildren<Text>().text;

    }

    public void onClickBackpack()
    {
        if (!picked)
        {
            InitializeValues.backpackObj[InitializeValues.sizeBackpack] = this.transform.GetComponentInChildren<Text>().text;
            InitializeValues.sizeBackpack = InitializeValues.sizeBackpack + 1;
            picked = true;
        }
    }

    public void onClickCoin()
    {
        if (!picked)
        {
            //InitializeValues.coins = InitializeValues.coins + this.transform.name; Covert string to int
            InitializeValues.coins = InitializeValues.coins +5;
            picked = true;
        }
    }
}
