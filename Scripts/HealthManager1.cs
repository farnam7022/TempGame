using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager1 : MonoBehaviour {

    //public int maxPlayerHealth = 40;
    public Slider healthBar;

	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Slider>();
        GameObject.FindWithTag("HealthBar1").transform.localScale = new Vector3(1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        
        healthBar.value = InitializeValues.lifePoints;
        if (InitializeValues.lifePoints <= 0) {
            GameObject.FindWithTag("HealthBar1").transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine("Death");
        }
    }

    public static void HurtPlayer(int damaged)
    {
        InitializeValues.lifePoints -= damaged;
    }


    IEnumerator Death()
    {
        yield return new WaitForSeconds(3f);
        //TODO: Load scene Death in Battle

        InitializeValues.saves++;

        /*InitializeValues.lifePoints = InitializeValues.lifeBeforeBattle + 2;
        InitializeValues.manaPoints = InitializeValues.manaBeforeBattle + 2;

        if(InitializeValues.lifePoints > InitializeValues.lifePointsMax)
            InitializeValues.lifePoints = InitializeValues.lifePointsMax;
        if (InitializeValues.manaPoints > (50 - InitializeValues.lifePointsMax))
            InitializeValues.manaPoints = (50 - InitializeValues.lifePointsMax);*/
        InitializeValues.manaPoints = 20;
        InitializeValues.lifePoints = 20;



        SceneManager.LoadScene("Book");

    }
}

