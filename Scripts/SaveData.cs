using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Collections.Generic;

//TUTORIAL
[Serializable]
public class PlayerStatistics
{
    public int strenghtSave;
    public int agilitySave;
    public int integritySave;
    public int staminaSave;
    public int ability1Save;
    public int luckSave;
    public int speedSave;
    public string notesSave;
    public string heroNameSave;
    public int manaPointsSave;
    public int lifePointsSave;
    public int lifePointsMaxSave;
    public int savesSave;
    public string chapterSave;
    public int coinsSave;

    public int swordValueSave;
    public int shieldValueSave;

    public List<string> backpackObjSave = new List<string>();

    public int sizeBackpackSave;

    public string[] equippedObjSave;
    public int sizeEquippedSave;

    public double pageSave;
    public double mpageSave;

    public string textSave, bt1Save, bt2Save, bt3Save, extSave;

    public PlayerStatistics(int strenghtSave, int agilitySave, int integritySave, int staminaSave, int ability1Save, int luckSave, int speedSave, string notesSave, string heroNameSave, int manaPointsSave, int lifePointsSave, int lifePointsMaxSave, int savesSave, string chapterSave, int coinsSave, int swordValueSave, int shieldValueSave, List<string> backpackObjSave, int sizeBackpackSave, string[] equippedObjSave, int sizeEquippedSave, double pageSave, double mpageSave, string textSave, string bt1Save, string bt2Save, string bt3Save, string extSave)
    {
        this.strenghtSave = strenghtSave;
        this.agilitySave = agilitySave;
        this.integritySave = integritySave;
        this.staminaSave = staminaSave;
        this.ability1Save = ability1Save;
        this.luckSave = luckSave;
        this.speedSave = speedSave;
        this.notesSave = notesSave;
        this.heroNameSave = heroNameSave;
        this.manaPointsSave = manaPointsSave;
        this.lifePointsSave = lifePointsSave;
        this.lifePointsMaxSave = lifePointsMaxSave;
        this.savesSave = savesSave;
        this.chapterSave = chapterSave;
        this.coinsSave = coinsSave;
        this.swordValueSave = swordValueSave;
        this.shieldValueSave = shieldValueSave;

        for (int i = 0; i < sizeBackpackSave; i++)
        {
            this.backpackObjSave.Add(backpackObjSave[i]);
        }

        this.sizeBackpackSave = sizeBackpackSave;
        this.equippedObjSave = equippedObjSave;
        this.sizeEquippedSave = sizeEquippedSave;
        this.pageSave = pageSave;
        this.mpageSave = mpageSave;
        this.textSave = textSave;
        this.bt1Save = bt1Save;
        this.bt2Save = bt2Save;
        this.bt3Save = bt3Save;
        this.extSave = extSave;
    }
}
