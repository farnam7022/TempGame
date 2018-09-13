using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AbilityButton : MonoBehaviour { 

    public static bool setUpComplete;

    int ComputeSumValues()
    {
        return InitializeValues.strenght + InitializeValues.agility + InitializeValues.stamina + InitializeValues.ability1 + InitializeValues.integrity;
    }

    int ComputeSumLifeMana()
    {
        return InitializeValues.lifePoints + InitializeValues.manaPoints;
    }

    void SubUpdate(int stat, int child)
    {
        if (stat < 15 && stat > 6)
        {
            this.transform.GetChild(child).GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(child).GetChild(2).gameObject.SetActive(true);
        }
        if (stat > 14 || ComputeSumValues() > 38)
        {
            this.transform.GetChild(child).GetChild(1).gameObject.SetActive(false);

        }
        else if (stat < 7)
        {
            this.transform.GetChild(child).GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(child).GetChild(2).gameObject.SetActive(false);
        }
    }

    void SubUpdateLM(int stat, int child)
    {
        if (stat < 30 && stat > 20)
        {
            this.transform.GetChild(child).GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(child).GetChild(2).gameObject.SetActive(true);
        }
        if (stat > 29 || ComputeSumLifeMana() > 49)
        {
            this.transform.GetChild(child).GetChild(1).gameObject.SetActive(false);

        }
        else if (stat < 21)
        {
            this.transform.GetChild(child).GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(child).GetChild(2).gameObject.SetActive(false);
        }
    }

    void Update()
    {

        SubUpdate(InitializeValues.strenght, 2);
        SubUpdate(InitializeValues.agility, 3);
        SubUpdate(InitializeValues.stamina, 4);
        SubUpdate(InitializeValues.ability1, 5);
        SubUpdate(InitializeValues.integrity, 6);
        SubUpdateLM(InitializeValues.manaPoints, 12);
        SubUpdateLM(InitializeValues.lifePoints, 13);


        if (ComputeSumLifeMana() == 50 && ComputeSumValues() == 39)
        {
            setUpComplete = true;
            InitializeValues.lifePointsMax = InitializeValues.lifePoints;
        }
        else {
            setUpComplete = false;
        }

       
    }
}