using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {

    public bool on = false;


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
                light.collider.gameObject.GetComponent<BasicAI>().LightShine();
            }

        }


        // F toggles flashlight on and off
       if (Input.GetKeyDown("f"))
       {
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
