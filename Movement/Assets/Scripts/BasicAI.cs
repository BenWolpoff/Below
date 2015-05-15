using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

    //Empty gameobjects will be used to set these locations, setting themselves as target
    public GameObject pointA;
    public GameObject pointB;
    public GameObject player;

    //A bool for disabiling noise
    public bool canMakeNoise = true;

    //the space that the monster will travel to
    public Transform target;

    //A place for the sight raycast to start, making it a gameobject makes it easily adjustable
    public GameObject eyes;

    //An integer to keep track of how long the monster will remain disabled by bright light
    public int lightStun;

    //instantiate audio stuff
    AudioSource audioSource;
    public AudioClip warCry;
    public AudioClip screech;

    //Booleans for directional facing
    public bool faceRight = true;
    public bool faceLeft = false;

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
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);

                //Play Walk animation
                animation.Play("walk");

                //When pointB is reached, pointA is targeted, and vice versa
                //Enemy should turn around as well.
                if (this.gameObject.transform.position.x <= pointA.transform.position.x + 1)
                {
                    target = pointB.transform;
                    
                }
                if (this.gameObject.transform.position.x >= pointB.transform.position.x - 1)
                {
                    target = pointA.transform;
                    
                }

                //Always be facing the target
                if (target.transform.position.x < transform.position.x && faceRight == true)
                {
                    this.transform.Rotate(0, 180, 0);
                    faceLeft = !faceLeft;
                    faceRight = !faceRight;
                }

                if (target.transform.position.x > transform.position.x && faceRight == false)
                {
                    this.transform.Rotate(0, 180, 0);
                    faceLeft = !faceLeft;
                    faceRight = !faceRight;
                }

                break;

            case "active":
                //Always be facing the player
                if (player.transform.position.x < transform.position.x && faceRight == true)
                {
                    this.transform.Rotate(0, 180, 0);
                    faceLeft = !faceLeft;
                    faceRight = !faceRight;
                }

                if (player.transform.position.x > transform.position.x && faceRight == false)
                {
                    this.transform.Rotate(0, 180, 0);
                    faceLeft = !faceLeft;
                    faceRight = !faceRight;
                }

                //Active behavior here, moves toward plDfayer very quickly

                float dash = chaseSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, dash);
                animation.Play("run");
                break;

            case "light":

                //Special behavior when the flashlight shines on them

                //lightStun counts down, and when it is finished, the enemy returns to normal.
                //If light constantly shines on the enemy, the lightStun int is constantly set to 25
                lightStun--;

                if (lightStun <= 0)
                {
                    BecomeIdle();
                    canMakeNoise = true;
                }

                break;

        }

       
       


        //A "vision" raycast which will let the enemy see the player
        //If the player is seen, state will change to Active

        RaycastHit2D hit = Physics2D.Raycast(eyes.transform.position, transform.forward, 4.7f);

        if (hit)
        {
            if (hit.collider.gameObject.tag == "Player" && status != "active")
            {
                //Debug.Log("See You!");
                BecomeActive();
            }



        }

        Debug.DrawRay(eyes.transform.position, transform.forward, Color.red);

       

        
        

	}
    //A function that changes status to active, makes an angry sound
   public void BecomeActive()
    {
       
            audioSource = this.gameObject.AddComponent<AudioSource>();
            audioSource.clip = warCry;

            audioSource.PlayOneShot(warCry);
        
        status = "active";
    }

    //A function that changes the satus to idle
    public void BecomeIdle()
    {
        status = "idle";
    }
    //A function called when the light hits the monster
    public void LightShine()
    {
        if (canMakeNoise == true)
        {
            audioSource = this.gameObject.AddComponent<AudioSource>();
            audioSource.clip = warCry;

            audioSource.PlayOneShot(screech);
            canMakeNoise = false;
        }
        status = "light";
        animation.Play("damage");
        lightStun = 25;
    }

   
}
