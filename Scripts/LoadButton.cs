using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public PlayerStatistics LocalCopyOfData;

    public void LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);

        LocalCopyOfData = (PlayerStatistics)formatter.Deserialize(saveFile);

        InitializeValues.strenght = LocalCopyOfData.strenghtSave;
        InitializeValues.agility = LocalCopyOfData.agilitySave;
        InitializeValues.integrity = LocalCopyOfData.integritySave;
        InitializeValues.stamina = LocalCopyOfData.staminaSave;
        InitializeValues.ability1 = LocalCopyOfData.ability1Save;
        InitializeValues.luck = LocalCopyOfData.luckSave;
        InitializeValues.speed = LocalCopyOfData.speedSave;
        InitializeValues.notes = LocalCopyOfData.notesSave;
        InitializeValues.heroName = LocalCopyOfData.heroNameSave;
        InitializeValues.manaPoints = LocalCopyOfData.manaPointsSave;
        InitializeValues.lifePoints = LocalCopyOfData.lifePointsSave;
        InitializeValues.saves = LocalCopyOfData.savesSave;
        InitializeValues.chapter = LocalCopyOfData.chapterSave;
        InitializeValues.coins = LocalCopyOfData.coinsSave;
        InitializeValues.swordValue = LocalCopyOfData.swordValueSave;
        InitializeValues.shieldValue = LocalCopyOfData.shieldValueSave;

        for (int i = 0; i < LocalCopyOfData.sizeBackpackSave; i++)
        {
            InitializeValues.backpackObj.Add(LocalCopyOfData.backpackObjSave[i]);
        }

        InitializeValues.sizeBackpack = LocalCopyOfData.sizeBackpackSave;
        InitializeValues.equippedObj = LocalCopyOfData.equippedObjSave;
        InitializeValues.sizeEquipped = LocalCopyOfData.sizeEquippedSave;
        RightPageFlip.page = LocalCopyOfData.pageSave;
        RightPageFlip.mpage = LocalCopyOfData.mpageSave;

        RightPageFlip.text = LocalCopyOfData.textSave;

        RightPageFlip.btw1 = LocalCopyOfData.bt1Save;
        RightPageFlip.btw2 = LocalCopyOfData.bt2Save;
        RightPageFlip.btw3 = LocalCopyOfData.bt3Save;
        RightPageFlip.extra = LocalCopyOfData.extSave;

        saveFile.Close();

        SceneManager.LoadScene("Book");
    }
}
