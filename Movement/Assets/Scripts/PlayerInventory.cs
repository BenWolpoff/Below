using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {


    //Until list can be implemented, just use a boolean instead
   public bool canLeave = false;

    
	// Use this for initialization
	void Start () {
        canLeave = false;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //Pick up objects tagged "item" and tell the player what they found
        if (col.gameObject.tag == "Item")
        {
            canLeave = true;

            gameObject.GetComponent<GUIscript>().Say("I found a " + col.gameObject.name);
            Destroy(col.gameObject);
        }
    }
}
