using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //If the player enters the hazard, they die and the level resets.
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Movement>().Dying();
        }
    }
}
