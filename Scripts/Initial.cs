using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Initial : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!Directory.Exists("Saves"))
        {
            GameObject.FindWithTag("LoadGame").transform.localScale = new Vector3(0, 0, 0);
        }
        else {
            GameObject.FindWithTag("LoadGame").transform.localScale = new Vector3(1, 1, 1);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
