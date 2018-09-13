using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnUpdateName : MonoBehaviour {

    public void onValueChange()
    {
        InitializeValues.heroName = this.transform.parent.GetComponentInChildren<Text>().text;
    }
}
