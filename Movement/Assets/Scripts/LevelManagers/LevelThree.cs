using UnityEngine;
using System.Collections;

public class LevelThree : MonoBehaviour
{
    public GameObject player;

    public GameObject goal;

    // Use this for initialization
    void Start()
    {

        player.gameObject.GetComponent<Movement>().level = "Level3";
        goal.GetComponent<WinObject>().level = "Level3";

    }

    // Update is called once per frame
    void Update()
    {

    }
}
