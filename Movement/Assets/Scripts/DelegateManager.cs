using UnityEngine;
using System.Collections;

public class DelegateManager : MonoBehaviour {

    public delegate void PowerUpHandler(bool isPoweredUp);

    public static event PowerUpHandler onPowerUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(5,5,150,40),"HIT ME"))
        {
            if(onPowerUp != null)
            {
                onPowerUp(true);
            }
        }

        if (GUI.Button(new Rect(5, 50, 150, 40), "UNHIT ME"))
        {
            if (onPowerUp != null)
            {
                onPowerUp(false);
            }
        }
    }
}
