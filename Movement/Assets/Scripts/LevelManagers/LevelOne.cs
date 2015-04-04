using UnityEngine;
using System.Collections;

public class LevelOne : MonoBehaviour
{

    public GameObject player;

    public GameObject goal;

	// Use this for initialization
	void Start ()
	{

	    player.gameObject.GetComponent<Movement>().level = "Level1";
	    goal.GetComponent<WinObject>().level = "Level1";

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
