using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesSound : MonoBehaviour {

	public AudioClip sound;
	private AudioSource source;

	void OnTriggerEnter(Collider collider)
	{
		source.Play ();
	}

	// Use this for initialization
	void Start () {
		source = gameObject.AddComponent<AudioSource> ();
		source.clip = sound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
