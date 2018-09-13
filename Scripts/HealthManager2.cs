using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager2 : MonoBehaviour
{

    public static int enemyHealth;
    //public int maxEnemyHealth = 20;
    public Slider enemyHealthBar;
    public int enemyHp = 4;


    // Use this for initialization
    void Start()
    {
        enemyHealthBar = GetComponent<Slider>();
        GameObject.FindWithTag("HealthBar2").transform.localScale = new Vector3(-1, 1, 1);
        enemyHealth = enemyHp;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.value = enemyHealth;
        if (enemyHealth <= 0)
        {
            GameObject.FindWithTag("HealthBar2").transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine("Death");

        }
    }

    public static void HurtPlayer(int damaged)
    {
        enemyHealth -= damaged;
    }




    IEnumerator Death()
    {
        yield return new WaitForSeconds(3f);
        //TODO: Load scene Death in Battle

        if (RightPageFlip.btn == 1)
        {
            RightPageFlip.btre = true;
            SceneManager.LoadScene("Book");
        }

        if (RightPageFlip.btn2 == 1)
        {
            RightPageFlip.btre2 = true;
            Debug.Log(RightPageFlip.btn2);
            SceneManager.LoadScene("Book");
        }

        if (RightPageFlip.btn3 == 1)
        {
            RightPageFlip.btre3 = true;
            SceneManager.LoadScene("Book");
        }
    }
}