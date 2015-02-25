using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

    //Empty gameobjects will be used to set these locations, setting themselves as target
    public GameObject pointA;
    public GameObject pointB;

    public GameObject player;

    public Transform target;



    //Variables to determine how quickly the enemy moves
    public float speed = 1;

    public float chaseSpeed = 3;
    //A variable for the status switch
    public string status = "idle";

	// Use this for initialization
	void Start () {

        //Set point B as Target
        target = pointB.gameObject.transform;
	
	}
	
	// Update is called once per frame
	void Update () {

        

       

        //The enemy will do different things when the status variable changes
        switch (status)
        {
            case "idle":

                //Idle behavior here, pacing from one spot to another
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);

                break;

            case "active":

                //Active behavior here, moves toward plDfayer very quickly

                float dash = chaseSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, dash);

                break;

            case "light":

                //NOT ALL ENEMIES WILL HAVE THIS- special behavior when the flashlight shines on them

                break;

        }

        //When pointB is reached, pointA is targeted, and vice versa
        //Enemy should turn around as well.
        if (this.gameObject.transform.position == pointA.transform.position)
        {
            target = pointB.transform;
        }
        if (this.gameObject.transform.position == pointB.transform.position)
        {
            target = pointA.transform;
        }

        if (Input.GetKey(KeyCode.P))
        {
            status = "active";
        }


        //A "vision" raycast which will let the enemy see the player
        //If the player is seen, state will change to Active

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("I see something!");

	}

   
}
