﻿using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        Debug.Log ("I see: " + other.gameObject.name);

    }
}
