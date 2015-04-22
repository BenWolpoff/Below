using UnityEngine;
using System.Collections;

public class StatueMonsterAI : MonoBehaviour
{

    //Empty gameobjects will be used to set these locations, setting themselves as target
    
    public GameObject player;

    public GameObject body;

    public Renderer rend;

    public Transform target;

	public float rust;

   //Shaking variables
    Vector2 originalPos;
    public float shakeAmount = 0.01f;
    

    
    public int countdown = 400;


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
    void Start()
    {
        originalPos = this.transform.position;

        countdown = countdown;

        rend = body.GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("CaveWorm");

        rend.material.shader = Shader.Find("Bumped Specular");



    }

    // Update is called once per frame
    void Update()
    {

        //The enemy will do different things when the status variable changes
        switch (status)
        {
            

            case "idle":

                //In stone form, the statue monster does not move
                //If the countdown variable reaches zero, it becomes active

                if (countdown <= 0)
                {

                    BecomeActive();

                }
          
                break;

            case "active":

                //Play walk animation
                animation.Play("Walk");

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

                break;

            case "light":

                //Does Not Apply


                break;

        }


		
    }

    public void BecomeActive()
    {

        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = warCry;

        audioSource.PlayOneShot(warCry);

        status = "active";
    }

    public void BecomeIdle()
    {
        status = "idle";
    }

    public void LightShine()
    {
        if (shakeAmount < .1)
            shakeAmount = shakeAmount + .0008f;



        countdown--;



        if (countdown > 1)
        {

            this.transform.localPosition = originalPos + Random.insideUnitCircle * shakeAmount;
        }

       
		//rust = rend.material.GetFloat ("Rust");
        //rend.Rust = 0;

       // ProceduralMaterial mat = new ProceduralMaterial();
        // float rustVal = mat.GetProceduralFloat("Rust");
    }


}