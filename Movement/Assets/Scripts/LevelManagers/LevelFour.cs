using UnityEngine;
using System.Collections;

public class LevelFour : MonoBehaviour
{
    public GameObject player;

    public GameObject goal;

    // Use this for initialization
    void Start()
    {

        player.gameObject.GetComponent<Movement>().level = "Level4";
        goal.GetComponent<WinObject>().level = "Level4";

    }

    // Update is called once per frame
    void Update()
    {

    }
}
