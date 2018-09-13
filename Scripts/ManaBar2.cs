using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaBar2 : MonoBehaviour
{

    public static int player2Mana;
    //public int maxPlayer2Mana = 20;
    public Slider manaBar2;
    public int enemyMana = 4;

    // Use this for initialization
    void Start()
    {
        manaBar2 = GetComponent<Slider>();
        GameObject.FindWithTag("ManaBar2").transform.localScale = new Vector3(-1, 1, 1);
        player2Mana = enemyMana;
    }

    // Update is called once per frame
    void Update()
    {

        manaBar2.value = player2Mana;
        if (player2Mana <= 0)
        {
            GameObject.FindWithTag("ManaBar2").transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public static void HurtPlayer(int damaged)
    {
        player2Mana -= damaged;
    }
}
