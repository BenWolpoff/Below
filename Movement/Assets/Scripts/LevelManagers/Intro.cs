using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{

    public GameObject player;

    public GameObject goal;

    // Use this for initialization
    void Start()
    {

        player.gameObject.GetComponent<Movement>().level = "Intro";
        goal.GetComponent<WinObject>().level = "Intro";

    }

    // Update is called once per frame
    void Update()
    {

    }
}
