using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaBar1 : MonoBehaviour
{

    //public static int playerMana;
    //public int maxPlayerMana = 30;
    public Slider manaBar;

    // Use this for initialization
    void Start()
    {
        manaBar = GetComponent<Slider>();
        GameObject.FindWithTag("ManaBar1").transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

        manaBar.value = InitializeValues.manaPoints;
        if (InitializeValues.manaPoints <= 0)
        {
            GameObject.FindWithTag("ManaBar1").transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public static void HurtPlayer(int damaged)
    {
        InitializeValues.manaPoints -= damaged;
    }
}
