using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusButton : MonoBehaviour
{

    int ComputeSumValues()
    {
        return InitializeValues.strenght + InitializeValues.agility + InitializeValues.stamina + InitializeValues.ability1 + InitializeValues.integrity;
    }

    int ComputeSumLifeMana()
    {
        return InitializeValues.lifePoints + InitializeValues.manaPoints;
    }

    int computeSumValues() {
        return InitializeValues.strenght + InitializeValues.agility + InitializeValues.stamina + InitializeValues.ability1 + InitializeValues.integrity;
    }

    int computeSumLifeMana()
    {
        return InitializeValues.lifePoints + InitializeValues.manaPoints;
    }

    public void onClick()
    {

        string value = this.transform.parent.name;
        if (value.Equals("Str")) {

            if (InitializeValues.strenght < 15 && computeSumValues() < 39)
            {
                InitializeValues.strenght += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.strenght.ToString();
            }
        }
        else if (value.Equals("Agi"))
        {

            if (InitializeValues.agility < 15 && computeSumValues() < 39)
            {
                InitializeValues.agility += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.agility.ToString();
                InitializeValues.speed = ((InitializeValues.agility + InitializeValues.luck) /2);
                this.transform.parent.parent.GetChild(8).GetComponentInChildren<Text>().text = InitializeValues.speed.ToString();
            }
        }
        else if (value.Equals("Sta"))
        {

            if (InitializeValues.stamina < 15 && computeSumValues() < 39)
            {
                InitializeValues.stamina += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.stamina.ToString();
            }
        }
        else if (value.Equals("Per"))
        {

            if (InitializeValues.ability1 < 15 && computeSumValues() < 39)
            {
                InitializeValues.ability1 += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.ability1.ToString();
            }
        }
        else if(value.Equals("Int"))
        {

            if (InitializeValues.integrity < 15 && computeSumValues() < 39)
            {
                InitializeValues.integrity += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.integrity.ToString();
            }
        }
        /*else if (value.Equals("Spe"))
        {

            if (InitializeValues.speed < 6)
            {
                InitializeValues.speed += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.speed.ToString();
            }
        }*/
        else if (value.Equals("ManaPoints"))
        {

            if (InitializeValues.manaPoints < 30 && computeSumLifeMana() < 50)
            {
                InitializeValues.manaPoints += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.manaPoints.ToString();
            }
        }
        else if (value.Equals("LifePoints"))
        {

            if (InitializeValues.lifePoints < 30 && computeSumLifeMana() < 50)
            {
                InitializeValues.lifePoints += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.lifePoints.ToString();
            }
        }



        if (ComputeSumValues() > 38)
        {
            this.transform.parent.parent.GetChild(19).GetComponent<Text>().text = "You don't have any point to share between the abilities";

        }
        else
        {
            int remAb = 39 - ComputeSumValues();
            this.transform.parent.parent.GetChild(19).GetComponent<Text>().text = "You still have " + remAb.ToString() + " points to share between the abilities";

        }

        if (ComputeSumLifeMana() > 49)
        {
            this.transform.parent.parent.GetChild(18).GetComponent<Text>().text = "You don't have any point to share between HP and MANA";

        }
        else
        {
            int remHp = 50 - ComputeSumLifeMana();
            this.transform.parent.parent.GetChild(18).GetComponent<Text>().text = "You still have " + remHp.ToString() + " points to share between HP and MANA";
            GameObject.FindWithTag("Arrow").transform.localScale = new Vector3(0, 0, 0);

        }

        if (ComputeSumValues() > 38 && ComputeSumLifeMana() > 49)
        {
            GameObject.FindWithTag("Arrow").transform.localScale = new Vector3(1, 1, 1);

        }
        else {
            GameObject.FindWithTag("Arrow").transform.localScale = new Vector3(0, 0, 0);
        }

    }


    public void onClick2()
    {

        string value = this.transform.parent.name;

        if (value.Equals("Agi"))
        {

            if (InitializeValues.agility < 15 && computeSumValues() < 39)
            {
                InitializeValues.agility += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.agility.ToString();
                InitializeValues.speed = ((InitializeValues.agility + InitializeValues.luck) / 2);
                this.transform.parent.parent.GetChild(8).GetComponentInChildren<Text>().text = InitializeValues.speed.ToString();
            }
        }
        else if (value.Equals("Per"))
        {

            if (InitializeValues.ability1 < 15 && computeSumValues() < 39)
            {
                InitializeValues.ability1 += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.ability1.ToString();
            }
        }
        else if (value.Equals("Int"))
        {

            if (InitializeValues.integrity < 15 && computeSumValues() < 39)
            {
                InitializeValues.integrity += 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.integrity.ToString();
            }
        }

        if (ComputeSumValues() > 38)
        {
            this.transform.parent.parent.GetChild(18).GetComponent<Text>().text = "You don't have any point to share between the abilities";
            GameObject.FindWithTag("Arrow").transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            int remAb = 39 - ComputeSumValues();
            this.transform.parent.parent.GetChild(18).GetComponent<Text>().text = "You still have " + remAb.ToString() + " points to share between the abilities";
            GameObject.FindWithTag("Arrow").transform.localScale = new Vector3(0, 0, 0);
        }

    }
}
