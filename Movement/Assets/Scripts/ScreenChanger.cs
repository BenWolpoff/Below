using UnityEngine;
using System.Collections;

public class ScreenChanger : MonoBehaviour {

    public GameObject camera;

    public GameObject myPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //If the player enters the area, the camera is sent to the next screen, unless the camera is already in position.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && camera.gameObject.transform.position != myPos.gameObject.transform.position)
        {
            

            camera.gameObject.GetComponent<CameraMove>().goal = myPos;

            
                    
        }
    }
}
