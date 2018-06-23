using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour {

    public static SceneManager Instance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchToScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

	public void PlaySound(AudioClip sound)
	{
		AudioSource audio = gameObject.AddComponent<AudioSource>();
		audio.clip = sound;
		audio.Play ();
	}
}
