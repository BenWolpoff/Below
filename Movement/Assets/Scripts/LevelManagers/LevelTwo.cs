using UnityEngine;
using System.Collections;

public class LevelTwo : MonoBehaviour
{

    public GameObject player;

    public GameObject goal;

    // Use this for initialization
    void Start()
    {

        player.gameObject.GetComponent<Movement>().level = "Level2";
        goal.GetComponent<WinObject>().level = "Level2";

    }

    // Update is called once per frame
    void Update()
    {

    }
}
