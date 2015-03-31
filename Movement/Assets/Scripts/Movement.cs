using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public bool running = false;

    public bool crouching = false;

    public bool faceRight = true;
    public bool faceLeft = false;

    public bool grounded = false;

    
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

        //This may be redundant with the new movement controls:
      //  v = rigidbody2D.velocity.x;

        //Slow down player if they exceed maximum speed
     //   if (rigidbody2D.velocity.x > maxSpeed);
       // {
            //Changing this variable will alter how smoothly the slowdown occurs (.5-.999)
       //     rigidbody2D.velocity *= 0.9f;
       // }



        //Check to see if player is on the ground
        



       
        //Press A to go Left
        if (Input.GetKey("a"))
        {
            //this.gameObject.rigidbody2D.AddForce(Vector3.left * moveSpeed);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            //Play Walk or Run animation depending on running boolean
            if (running == true)
            {
                animation.Play("run");
            }
            else
            {
                animation.Play("walk");
            }

            //If the player is facing right, turn around
            if (faceRight == true)
            {
                
                this.transform.Rotate(0, 180, 0);

                faceRight = false;
                faceLeft = true;
            }

           

        }

        //Press D to go Right
        if (Input.GetKey("d"))
        {
            //this.gameObject.rigidbody2D.AddForce(Vector3.right * moveSpeed);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            //Play Walk or Run animation depending on running boolean
            if (running == true)
            {
                animation.Play("run");
            }
            else
            {
                animation.Play("walk");
            }
            

            //If the player is facing left, turn around
            if (faceLeft == true)
            {
                this.transform.Rotate(0, 180, 0);

                faceRight = true; 
                faceLeft = false;
            }

        }

        //Stop walking animation when the player stops walking or jumping
        if (Input.GetKeyUp("d") || Input.GetKeyUp("a"))
        {
            animation.Play("idle");
        }

        

       

        //Press S to Crouch, reducing height.

        if (Input.GetKeyDown("s"))
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

    //Jump should only be available while Player is on the ground
    void OnCollisionStay2D(Collision2D col)
    {
        //Press Space while on the Ground to Jump
        if (col.gameObject.tag == "Ground" && Input.GetKey("space"))
        {
            this.gameObject.rigidbody2D.AddForce(transform.up * jumpForce);
            
        }
    }
}
