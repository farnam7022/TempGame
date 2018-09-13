using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveChangedValueNotes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onValueChange() {
        InitializeValues.notes = this.transform.parent.parent.GetChild(9).GetComponentInChildren<Text>().text;
        //this.transform.parent.parent.GetChild(10).GetComponent<Text>().text = InitializeValues.notes;
    }
}
