using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show(GameObject parent)
    {
        SetUpWindow();
        DisplayWindow(parent);
    }

    protected virtual void DisplayWindow(GameObject parent)
    {
        GameObject dialog = Instantiate(this.gameObject) as GameObject;
        dialog.transform.SetParent(parent.transform, false);
        PauseWorld();
    }

    protected virtual void SetUpWindow()
    {
    }

    public virtual void PauseWorld()
    {
        Time.timeScale = 0;
    }

    public virtual void PlayWorld()
    {
        Time.timeScale = 1;
    }
}
