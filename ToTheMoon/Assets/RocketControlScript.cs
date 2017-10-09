using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControlScript : MonoBehaviour {

    public enum SideEnum
    {
        Left,
        Right
    }

    public SideEnum side;
    public ParticleSystem particleSystem;

    Rigidbody rigidBody;
    float forceMultiplier = 1.0f;
    float maxForceMultiplier = 8f;
    float minForceMultiplier = 1.0f;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        KeyCode powerKey = KeyCode.Space;
        if (side == SideEnum.Left)
            powerKey = KeyCode.LeftArrow;
        else if (side == SideEnum.Right)
            powerKey = KeyCode.RightArrow;

        if (Input.GetKey(powerKey))
        {
            float rotation = transform.rotation.eulerAngles.z;
            rigidBody.AddRelativeForce(new Vector3(0, (PlayerStats.RocketPower * 500 * forceMultiplier) - rotation, 0));
            forceMultiplier += 0.1f;
            particleSystem.Play();
        }
        else
        {
            forceMultiplier -= 0.1f;
        }

        forceMultiplier = Mathf.Min(forceMultiplier, maxForceMultiplier);
        forceMultiplier = Mathf.Max(forceMultiplier, minForceMultiplier);

    }
}
