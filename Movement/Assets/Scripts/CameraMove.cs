using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public float cameraSpeed = 1f;

    //Put all camera positions here
    public GameObject pos1;
    public GameObject pos2;

    //This is the position the camera should currently be at
    public GameObject goal;
    

	// Use this for initialization
	void Start () {

        
        goal = pos1;
	
	}
	
	// Update is called once per frame
	void Update () {

        //Camera should always move towards goal

       transform.position = Vector3.MoveTowards(transform.position, goal.gameObject.transform.position, cameraSpeed);
       
	}
}
