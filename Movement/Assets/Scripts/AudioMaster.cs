using UnityEngine;
using System.Collections;

public class AudioMaster : MonoBehaviour {


    AudioSource audioSource;
    public AudioClip audioClip;
	// Use this for initialization
	void Start () 
    {
        //audioSource = new AudioSource();
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

        audioSource.PlayOneShot(audioClip);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
