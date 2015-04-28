using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour {

    public string words = "Put Text Here!";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //When player touches it, it sends off it's message and deletes itself
    void OnTriggerEnter2D(Collider2D col)
    {
        

        if (col.gameObject.tag == "Player")
        {
            
            col.gameObject.GetComponent<GUIscript>().Say(words);

            Destroy(this.gameObject);

        }

    }
}
