using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    static public float RocketPower
    {
        get
        {
            return PlayerPrefs.GetFloat("RocketPower", 1.0f);
        }
        set
        {
            PlayerPrefs.SetFloat("RocketPower", value);
        }
    }

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
