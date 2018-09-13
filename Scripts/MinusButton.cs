using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinusButton : MonoBehaviour
{

    int ComputeSumValues()
    {
        return InitializeValues.strenght + InitializeValues.agility + InitializeValues.stamina + InitializeValues.ability1 + InitializeValues.integrity;
    }

    int ComputeSumLifeMana()
    {
        return InitializeValues.lifePoints + InitializeValues.manaPoints;
    }

    public void onClick()
    {

        string value = this.transform.parent.name;
        if (value.Equals("Str"))
        {
            if (InitializeValues.strenght > 6)
            {
                InitializeValues.strenght -= 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.strenght.ToString();
            }
        }
        else if (value.Equals("Agi"))
        {

            if (InitializeValues.agility > 6)
            {
                InitializeValues.agility -= 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.agility.ToString();
            }
        }
        else if (value.Equals("Sta"))
        {

            if (InitializeValues.stamina > 6)
            {
                InitializeValues.stamina -= 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.stamina.ToString();
            }
        }
        else if (value.Equals("Per"))
        {

            if (InitializeValues.ability1 > 6)
            {
                InitializeValues.ability1 -= 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.ability1.ToString();
            }
        }
        else if (value.Equals("Int"))
        {

            if (InitializeValues.integrity > 6)
            {
                InitializeValues.integrity -= 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.integrity.ToString();
            }
        }
        else if (value.Equals("Spe"))
        {

            if (InitializeValues.speed > 6)
            {
                InitializeValues.speed -= 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.speed.ToString();
            }
        }
        else if (value.Equals("ManaPoints"))
        {

            if (InitializeValues.manaPoints > 20)
            {
                InitializeValues.manaPoints -= 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.manaPoints.ToString();
            }
        }
        else if (value.Equals("LifePoints"))
        {

            if (InitializeValues.lifePoints > 20)
            {
                InitializeValues.lifePoints -= 1;
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
        }

        GameObject.FindWithTag("Arrow").transform.localScale = new Vector3(0, 0, 0);
    }

    public void onClick2()
    {

        string value = this.transform.parent.name;
        if (value.Equals("Agi"))
        {

            if (InitializeValues.agility > 6)
            {
                InitializeValues.agility -= 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.agility.ToString();
            }
        }

        else if (value.Equals("Per"))
        {

            if (InitializeValues.ability1 > 6)
            {
                InitializeValues.ability1 -= 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.ability1.ToString();
            }
        }
        else if (value.Equals("Int"))
        {

            if (InitializeValues.integrity > 6)
            {
                InitializeValues.integrity -= 1;
                this.transform.parent.GetComponentInChildren<Text>().text = InitializeValues.integrity.ToString();
            }
        }

        if (ComputeSumValues() > 38)
        {
            this.transform.parent.parent.GetChild(18).GetComponent<Text>().text = "You don't have any point to share between the abilities";
        }
        else
        {
            int remAb = 39 - ComputeSumValues();
            this.transform.parent.parent.GetChild(18).GetComponent<Text>().text = "You still have " + remAb.ToString() + " points to share between the abilities";

        }
       

        GameObject.FindWithTag("Arrow").transform.localScale = new Vector3(0, 0, 0);

    }
}
