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
    public ParticleSystem ParticleSystem;

    Rigidbody rigidBody;
    float forceMultiplier = 1.0f;
    float maxForceMultiplier = 8f;
    float minForceMultiplier = 1.0f;
    float maxRotation = 60;
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

        bool canAddMoreForce = true;
        float rotation = transform.rotation.eulerAngles.z;
        if (side == SideEnum.Left)
        {
            powerKey = KeyCode.LeftArrow;
            if (rotation > 180 && rotation < 360 - maxRotation)
                canAddMoreForce = false;
        }
        else if (side == SideEnum.Right)
        {
            powerKey = KeyCode.RightArrow;
            if (rotation < 180 && maxRotation < rotation)
                canAddMoreForce = false;
        }

        canAddMoreForce = true;
        
        if (Input.GetKey(powerKey) && canAddMoreForce)
        {
            float maxForce = (PlayerStats.RocketPower * 500 * forceMultiplier);

            // calculating a multiplier that gets zero at the maxRotation and is one at zero rotation
            // f(x) = - ax² + 1
            bool rocketRotationToLeft = true;
            float normalizedRotation = rotation;
            if (normalizedRotation > 180)
            {
                rocketRotationToLeft = false;
                normalizedRotation = 360 - normalizedRotation;
            }
            float a = 1 / (maxRotation * maxRotation);
            float forceMultiplicator = -(a * Mathf.Pow(normalizedRotation, 2)) + 1;
            if (forceMultiplicator < 0)
                forceMultiplicator = 0;
            float force = maxForce;

            if(side == SideEnum.Right && rocketRotationToLeft ||
                side == SideEnum.Left && !rocketRotationToLeft)
            {
                // damping of rocket force only when the rocket rotates to the opposite side of this engine
                force *= forceMultiplicator;
            }

            GUIManager.SetTempDebugText(rotation.ToString());
            rigidBody.AddRelativeForce(new Vector3(0, force, 0));
            forceMultiplier += 0.1f;
            ParticleSystem.Play();
        }
        else
        {
            forceMultiplier -= 0.1f;
        }

        forceMultiplier = Mathf.Min(forceMultiplier, maxForceMultiplier);
        forceMultiplier = Mathf.Max(forceMultiplier, minForceMultiplier);

    }
}
