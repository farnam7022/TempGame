using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackButton : MonoBehaviour
{

    void remove() {
        string backpack = "";

        for (int i = 0; i < InitializeValues.sizeBackpack; i++)
        {
            backpack += "-" + InitializeValues.backpackObj[i] + "\n";
        }
        this.transform.parent.GetChild(10).GetComponent<Text>().text = backpack;
    }

    void DoStuff(string objName, int index) {
        print("Vado " + index);
        if (objName.Equals("Health Potion (5 hp)\n")) {
            InitializeValues.lifePoints += 5;
            if (InitializeValues.lifePoints > InitializeValues.lifePointsMax) {
                InitializeValues.lifePoints = InitializeValues.lifePointsMax;
            }
            InitializeValues.backpackObj.RemoveAt(index);
            InitializeValues.sizeBackpack--;
            this.transform.parent.GetChild(21).GetComponent<Text>().text = "You used the healing potion.";
            remove();
            this.transform.parent.GetChild(13).GetComponentInChildren<Text>().text = InitializeValues.lifePoints.ToString();


        }
        else if (objName.Equals("Meal\n"))
        {
            this.transform.parent.GetChild(21).GetComponent<Text>().text = "A complete meal, seems delightful. Better save it for later.";

        }
        else if (objName.Equals("Old Amulet\n"))
        {
            
                this.transform.parent.GetChild(21).GetComponent<Text>().text = "An old an mysterious amoulet. Will it be useful?";
            
        }

    }

    public void Onclick1()
    {
        if (InitializeValues.sizeBackpack > 0)
            DoStuff(InitializeValues.backpackObj[0],0);
    }
    public void Onclick2()
    {
        if (InitializeValues.sizeBackpack > 1)
            DoStuff(InitializeValues.backpackObj[1],1);
    }
    public void Onclick3()
    {
        if (InitializeValues.sizeBackpack > 2)
            DoStuff(InitializeValues.backpackObj[2],2);
    }
    public void Onclick4()
    {
        if (InitializeValues.sizeBackpack > 3)
            DoStuff(InitializeValues.backpackObj[3],3);
    }
    public void Onclick5()
    {
        if (InitializeValues.sizeBackpack > 4)
            DoStuff(InitializeValues.backpackObj[4],4);
    }
    public void Onclick6()
    {
        if (InitializeValues.sizeBackpack > 5)
            DoStuff(InitializeValues.backpackObj[5], 5);
    }


}
