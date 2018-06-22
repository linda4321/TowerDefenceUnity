using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform startPosition;
    public Transform[] cameraPositions;

    public float speed = 3f;

    private int currPos;
	// Use this for initialization
	void Start () {
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
        currPos = 0;
	}
	
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
			MoveToLeft();
        }
               
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
			MoveToRight ();
        }

    }

	public void MoveToLeft()
	{
		if (currPos > 0)
			currPos--;
		else
			currPos = cameraPositions.Length - 1;

		MoveToPoint(cameraPositions[currPos]);
	}

	public void MoveToRight()
	{
		if (currPos < cameraPositions.Length - 1)
			currPos++;
		else
			currPos = 0;

		MoveToPoint(cameraPositions[currPos]);
	}

    private void MoveToPoint(Transform transform)
    {
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
    }
}
