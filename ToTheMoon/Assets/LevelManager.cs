using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject Player;
    public int MaxEntityCount = 20;
    public float SectionHeightRange = 20f;
    public float SectionWidthRange = 40f;
    public GameObject CloudPrefab;

    float currentSectionStart = 0.0f;
    List<GameObject> prePrevEntities;
    List<GameObject> prevEntities;
    List<GameObject> currentEntities;
    List<GameObject> nextEntities;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void FixedUpdate()
    {
        Vector3 playerPos = transform.position;
        float nextSectionStart = currentSectionStart + SectionHeightRange;
        if(playerPos.y >= nextSectionStart)
        {
            currentSectionStart = nextSectionStart;
            // Move all sections down
            foreach (GameObject obj in prePrevEntities)
                Destroy(obj);
            prePrevEntities = prevEntities;
            prevEntities = currentEntities;
            currentEntities = nextEntities;
            nextEntities = null;
        }
        if (nextEntities == null)
        {
            nextEntities = new List<GameObject>();
            for(int i = 0; i < MaxEntityCount; i++)
            {
                float x = Random.Range(playerPos.x - SectionWidthRange, playerPos.x + SectionWidthRange);
                float y = Random.Range(nextSectionStart, nextSectionStart + SectionHeightRange);
                nextEntities.Add(Instantiate(CloudPrefab, new Vector3(x, y, 0.0f), new Quaternion()));
            }
        }
    }
}
