using UnityEngine;
using System.Collections;

public class WinObject : MonoBehaviour {

    public string level; //A string set by the level manager, so that the correct level is loaded when the player wins

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
                Debug.Log("The door is stuck!");
            }
        }

        
    }
}
