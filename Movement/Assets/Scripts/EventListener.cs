using UnityEngine;
using System.Collections;

public class EventListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        DelegateManager.onPowerUp += PoweredUp;

    }

    void OnDisable()
    {
        DelegateManager.onPowerUp -= PoweredUp;
    }

    void PoweredUp(bool isPoweredUp)
    {
        //ACTUAL STUFF goes here. This is just a print line so that it's not doing nothing.
        Debug.Log(isPoweredUp);
    }
}
