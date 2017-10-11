using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    static Text tempDebugText;
    void Start () {
        tempDebugText = transform.FindChild("TempDebugText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    static public void SetTempDebugText(string text)
    {
        tempDebugText.text = text;
    }
}
