using UnityEngine;
using System.Collections;

public class LightBulb : MonoBehaviour {

    public GameObject flash;

    public bool on;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Light switches on and off when Flashlight turns.

        if (flash.gameObject.GetComponent<FlashLight>().on == true)
        {
            light.enabled = true;
        }

        if (flash.gameObject.GetComponent<FlashLight>().on == false)
        {
            light.enabled = false;
        }

       


        
    }

    
}
