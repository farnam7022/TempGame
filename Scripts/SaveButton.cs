using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick() {

        
            if (!Directory.Exists("Saves"))
                Directory.CreateDirectory("Saves");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream saveFile = File.Create("Saves/save.binary");

            PlayerStatistics playerStatistics = new PlayerStatistics(InitializeValues.strenght, InitializeValues.agility, InitializeValues.integrity, InitializeValues.stamina,
                                                                     InitializeValues.ability1, InitializeValues.luck, InitializeValues.speed, InitializeValues.notes,
                                                                     InitializeValues.heroName, InitializeValues.manaPoints, InitializeValues.lifePoints, InitializeValues.lifePointsMax, InitializeValues.saves,
                                                                     InitializeValues.chapter, InitializeValues.coins, InitializeValues.swordValue, InitializeValues.shieldValue, 
                                                                     InitializeValues.backpackObj, InitializeValues.sizeBackpack, InitializeValues.equippedObj,
                                                                     InitializeValues.sizeEquipped, RightPageFlip.page, RightPageFlip.mpage, RightPageFlip.text, RightPageFlip.btw1,
                                                                     RightPageFlip.btw2, RightPageFlip.btw3, RightPageFlip.extra);

            formatter.Serialize(saveFile, playerStatistics);

            saveFile.Close();
        
    }

 
}
