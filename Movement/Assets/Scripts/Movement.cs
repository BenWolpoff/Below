using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    //Audio variables, clips, and a boolean for tracking whether footsteps are sounding.
    AudioSource audioSource;
    public AudioClip walking;
    public AudioClip die;
    public bool stepSounds;

    //bools for running, crouching, and directional facing states
    public bool running = false;

    

    public bool crouching = false;

    public bool faceRight = true;
    public bool faceLeft = false;

    //Variables for turning commands.
    public bool canLeft = false;
    public bool canRight = false;
    public int countdownLeft = 0;
    public int countdownRight = 0;
    public int countdownDefault = 100;


    public bool grounded = false;

    public bool canMove = true; // A bool that can stop the player from moving
    public string level; //A string set by the level manager, so that the correct level is reloaded on death

    
    //A variable to detirmine how quickly the player moves
    public float moveSpeed = 5f;

    //A variable to detirmine how high and fast the player jumps
    public float jumpForce = 100f;

    //Detirmines how fast the player is moving.
    public float maxSpeed = 15f;


    //Variables for the player's normal and crouching speed and height.
    public float normalHeight;

    public float crouchHeight;

    public float normalSpeed;

    public float crouchSpeed;


    // Variables for running
    public float normalJump;

    public float runJump;

    public float runSpeed;


    public float v;
    

	// Use this for initialization
	void Start () {

        canMove = true;

        //Start the player facing right (If Necessary)
        //this.transform.Rotate(0, 90, 0);



        //Set normal and crouch heights and speeds
        Vector3 scale = transform.localScale;

        normalHeight = scale.y;

        normalSpeed = moveSpeed;

        normalJump = jumpForce;

        //When crouching, the player's height and speed are halved

        crouchHeight = normalHeight / 2;

        crouchSpeed = normalSpeed * .75f;

        
        //When running, the player moves faster and jumps higher

        runJump = normalJump * 1.2f;

        runSpeed = normalSpeed * 1.75f;

	
	}
	
	// Update is called once per frame
	void Update () {

        //Always countdown the Left and Right variables.
        //When they hit zero, the turn enablers turn off.
        //Releasing directional keys temporarily reset the countdon, enabling turning.

        if (countdownLeft > 0)
        {
            countdownLeft--;
            canLeft = true;
        }
        else
        {
            canLeft = false;
        }

        if (countdownRight > 0)
        {
            countdownRight--;
            canRight = true;
        }
        else
        {
            canRight = false;
        }

        //Check to see if player is on the ground
        RaycastHit2D down = Physics2D.Raycast(transform.position, -transform.up, .7f);

        if (down)
        {
            if (down.collider.gameObject.tag == "Ground")
            {
                grounded = true;
            }

            else
            {
                grounded = false;
            }

        }

        else
        {
            grounded = false;
        }

        Debug.DrawRay(transform.position, -transform.up, Color.green);

        //Press Space while on the Ground to Jump
        if (grounded == true && Input.GetKeyDown("space"))
        {
            this.gameObject.rigidbody2D.AddForce(transform.up * jumpForce);

        }
        


        //Play sounds when keys are pressed

        if (Input.GetKey("a") || Input.GetKey("d") )
        {
            if (grounded == true && stepSounds == false)
            {
                stepSounds = true;
                audioSource = this.gameObject.AddComponent<AudioSource>();
                audioSource.clip = walking;
                audioSource.loop = true;

                audioSource.Play();

                

            }
        }
       


        //Press A to go Left
        if (Input.GetKey("a") && canMove == true)
        {
           //Move Player forward or backward, depending on facing
            if (faceLeft == true)
            {

                //Play Walk or Run animation forward depending on running boolean
                if (running == true)
                {
                    animation["run"].speed = 1.0f;
                    animation.Play("run");
                }
                else
                {
                    animation["walk"].speed = 1.0f;
                    animation.Play("walk");
                }

                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }

            if (faceLeft == false)
            {
                //Play Walk or Run animation in reverse depending on running boolean
               if(running == false)
                {
                   //Doesn't quite work yet, causes animation to freeze
                    //animation["walk"].speed = -1.0f;
                    animation.Play("walk");
                }

                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }

          

            //If the player is facing right, turn around- ADD CONITIONAL so that turning won't happen unless key is pressed twice, or running
            if (faceRight == true)
            {
                if (running == true || canLeft == true){
                
                this.transform.Rotate(0, 180, 0);

                faceRight = false;
                faceLeft = true;
                }
            }

           

        }

        //Press D to go Right
        if (Input.GetKey("d") && canMove == true)
        {
            //this.gameObject.rigidbody2D.AddForce(Vector3.right * moveSpeed);
            if (faceRight == true)
            {
                //Play Walk or Run animation forward depending on running boolean
                if (running == true)
                {
                    animation["run"].speed = 1.0f;
                    animation.Play("run");
                }
                else
                {
                    animation["walk"].speed = 1.0f;
                    animation.Play("walk");
                }

                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }

            if (faceRight == false)
            {

                //Play Walk animation in reverse depending on running boolean
                if(running == false)
                {
                    animation.Play("walk");
                }

                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }
            
            

            //If the player is facing left, turn around
            if (faceLeft == true)
            {
                if (running == true || canRight == true)
                {

                    this.transform.Rotate(0, 180, 0);

                    faceRight = true;
                    faceLeft = false;
                }
            }

        }

        //Stop walking animation when the player stops walking or jumping
        if (Input.GetKeyUp("d") || Input.GetKeyUp("a"))
        {
            animation.Play("idle");
            stepSounds = false;
            audioSource.loop = false;
        }

        //Reset countdowns when player releases directional keys.
        if (Input.GetKeyUp("d"))
            countdownRight = countdownDefault;
        if (Input.GetKeyUp("a"))
            countdownLeft = countdownDefault;
        

       

        //Press S to Crouch, reducing height.

        if (Input.GetKeyDown("s") && canMove == true)
        {
            Vector3 size = transform.localScale;
            size.y = crouchHeight;

            transform.localScale = size;
            moveSpeed = crouchSpeed;
            crouching = true;
        }


        //Release S to Stand after Crouching, returning height to normal.

        if (Input.GetKeyUp("s"))
        {
            Vector3 size = transform.localScale;
            size.y = normalHeight;

            transform.localScale = size;

            maxSpeed = normalSpeed;

            crouching = false;
        }

        //Press LeftShift to Run
        if (Input.GetKeyDown(KeyCode.LeftShift) && crouching == false)
        {
            running = true;
            moveSpeed = runSpeed;
            jumpForce = runJump;
        }

        //Release LeftShift to stop Runnning

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
            moveSpeed = normalSpeed;
            jumpForce = normalJump;
        }


        //Movement Stops when either a or d key is released
        if ((Input.GetKeyUp("a")) || (Input.GetKeyUp("d")))
        {
            this.gameObject.rigidbody2D.velocity = new Vector3(0, rigidbody2D.velocity.y);
        }
	
	}

    //When they player dies, they should first run a death animation and then load the current level
    public void Dying()
    {
        canMove = false;


        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = die;

        audioSource.PlayOneShot(die);

        animation.Play("death");
        Invoke("Death", .5f);
    }

    void Death() //Loads a level based on a variable set by the level manager
    {
        switch (level)
        {
            case "Level1":

                
            Application.LoadLevel(1);

                break;

            case "Level2":

               
            Application.LoadLevel(2);

            break;

            case "Level3" :

               
            Application.LoadLevel(3);

            break;

            case "Level4":


            Application.LoadLevel(4);

            break;




        }
    }

   
}
