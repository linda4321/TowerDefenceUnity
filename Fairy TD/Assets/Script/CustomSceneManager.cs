using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour {

    public static CustomSceneManager Instance;

    private AudioSource source;

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
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
        Instance.source.PlayOneShot(sound);
    }
}
