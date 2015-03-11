using UnityEngine;
using System.Collections;

public class WinObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("YOU WIN");
            Application.LoadLevel(0);
        }
    }
}
