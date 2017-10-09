using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float OffsetZ = 20;
    public float OffsetY = 10;
    public GameObject player;
    
    void Start () {
	}
	
	void Update () {
        transform.position = new Vector3(player.transform.position.x,
            player.transform.position.y + OffsetY, player.transform.position.z - OffsetZ);
        transform.LookAt(player.transform);
	}
}
