using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DoneButton : MonoBehaviour {

    private void Update()
    {
        if (AbilityButton.setUpComplete)
        {
            this.transform.GetComponentInChildren<Text>().text = "Ready To Go";
        }
        else {
            this.transform.GetComponentInChildren<Text>().text = "You still have points";
        }
    }

    public void onClick()
    {
        if (AbilityButton.setUpComplete)
        {
            //SceneManager.LoadScene("Battle");
           SceneManager.LoadScene("Book");

        }

    }

    public void onClick2()
    {
        if (AbilityButton.setUpComplete)
        {
                RightPageFlip.donere = true;
                SceneManager.LoadScene("Book");
        }

    }

    public void onGameClick()
    {
        SceneManager.LoadScene("Book");
    }
}
