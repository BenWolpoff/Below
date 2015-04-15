using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {

    public bool on = false;

    AudioSource audioSource;
    public AudioClip click;


	// Use this for initialization
	void Start () {

        on = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        //Debug ray line for the flashlight
        Debug.DrawRay(transform.position, transform.right, Color.red);


        //A raycast which travels from the flashlight, effecting enemies that it hits
        RaycastHit2D light = Physics2D.Raycast(transform.position, transform.right, 10f);

        if (light && on == true) // Only triggers if the flashlight is on
        {

            //When triggered, it sets an enemy's AI to "light"
            if (light.collider.gameObject.tag == "Enemy")
            {
                if (light.collider.gameObject.GetComponent("BasicAI") != null)
                light.collider.gameObject.GetComponent<BasicAI>().LightShine();

                if (light.collider.gameObject.GetComponent("StatueMonsterAI") != null)
                    light.collider.gameObject.GetComponent<StatueMonsterAI>().LightShine();
            }

        }


        // F toggles flashlight on and off
       if (Input.GetKeyDown("f"))
       {
           audioSource = this.gameObject.AddComponent<AudioSource>();
           audioSource.clip = click;

           audioSource.PlayOneShot(click);
           
           on = !on;
       }

       // Getting E down will tilt flashlight up
       if (Input.GetKeyDown("e"))
       {
           this.transform.Rotate(0, 0, 30);
       }


       // Getting E up will return it to normal

       if (Input.GetKeyUp("e"))
       {
           this.transform.Rotate(0, 0, -30);
       }

       // Getting C down will tilt flashlight down
       if (Input.GetKeyDown("c"))
       {
           this.transform.Rotate(0, 0, -30);
       }


       // Getting E up will return it to normal

       if (Input.GetKeyUp("c"))
       {
           this.transform.Rotate(0, 0, 30);
       }
	
	}
}
