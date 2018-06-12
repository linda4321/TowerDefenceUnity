using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 1f;
    public GameObject path;

    private Transform[] pathPoints;

    private Vector3 currDestinationPoint;
    private int currPoint = 1;

    private Vector3 deltaPos;

    private bool dead = false;

    public bool Dead { get { return dead; } }

	// Use this for initialization
	void Start () {
        pathPoints = path.GetComponentsInChildren<Transform>();
        UpdateDestination();
        Debug.Log(pathPoints.Length);
    }
	
	// Update is called once per frame
	void Update () {
        if(currPoint < pathPoints.Length){
            if (transform.position != currDestinationPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, currDestinationPoint, speed);
            }
            else
            {
                currPoint++;
                UpdateDestination();
            }
        }   

	}

    private void UpdateDestination()
    {
        if(currPoint < pathPoints.Length)
        {
            currDestinationPoint = pathPoints[currPoint].position;  
            transform.LookAt(pathPoints[currPoint]);
            deltaPos = currDestinationPoint - transform.position;
        }
        
    }
}
