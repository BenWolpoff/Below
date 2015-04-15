using UnityEngine;
using System.Collections;

public class WinObject : MonoBehaviour {

    public string level; //A string set by the level manager, so that the correct level is loaded when the player wins

    //instantiate audio stuff
    AudioSource audioSource;
    public AudioClip locked;
    public AudioClip open;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col)//If the player presses W at the door, they will attempt to open it. If they can, then the next level is loaded.
    {
        if (Input.GetKeyDown("w"))
        {
            if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<PlayerInventory>().canLeave == true)
            {
                audioSource = this.gameObject.AddComponent<AudioSource>();
                audioSource.clip = open;

                audioSource.PlayOneShot(open);


                Debug.Log("YOU WIN");

                switch (level)//Level variable is set by the level manager
                {
                    case "Level1":


                        Application.LoadLevel(1);

                        break;

                    case "Level2":


                        Application.LoadLevel(0);

                        break;

                    case "Level3":


                        Application.LoadLevel(0);

                        break;




                }
                
            }

            else
            {
                audioSource = this.gameObject.AddComponent<AudioSource>();
                audioSource.clip = locked;

                audioSource.PlayOneShot(locked);
                Debug.Log("The door is stuck!");
            }
        }

        
    }
}
