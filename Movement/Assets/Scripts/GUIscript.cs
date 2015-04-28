using UnityEngine;
using System.Collections;

public class GUIscript : MonoBehaviour {

    public string words;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
	
	}

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2, 10, 1000, 20), words);
    }

    public void Say(string text)
    {
        words = text;

        Invoke("Unsay", 2);
    }

    void Unsay()
    {
        words = "";
    }

   
}
