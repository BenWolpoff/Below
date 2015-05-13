using UnityEngine;
using System.Collections;

public class IntroPickup : MonoBehaviour {

    public GameObject flashlight;

    public GameObject fakeFlashlight;

	// Use this for initialization
	void Start () {

        flashlight.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col)//If the player presses W at the door, they will attempt to open it. If they can, then the next level is loaded.
    {
        if (Input.GetKeyDown("w"))
        {
            fakeFlashlight.SetActive(false);
            flashlight.SetActive(true);

            col.gameObject.GetComponent<PlayerInventory>().canLeave = true;


        }
    }
}
