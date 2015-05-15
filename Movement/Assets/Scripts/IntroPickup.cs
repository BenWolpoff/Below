using UnityEngine;
using System.Collections;

public class IntroPickup : MonoBehaviour {

    //The flashlight that is attached to the player
    public GameObject flashlight;

    //The flashlight the player sees on the table
    public GameObject fakeFlashlight;

	// Use this for initialization
	void Start () {

        flashlight.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col)
    {
        //When the player presses W over the flashlight, it should disappear off the table and appear on the player character
        if (Input.GetKeyDown("w"))
        {
            fakeFlashlight.SetActive(false);
            flashlight.SetActive(true);

            col.gameObject.GetComponent<PlayerInventory>().canLeave = true;


        }
    }
}
