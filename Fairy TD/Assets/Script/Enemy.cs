using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 1f;
    public GameObject path;
    public float lifeStrength = 5f;

    private Transform[] pathPoints;

    private Vector3 currDestinationPoint;
    private int currPoint = 1;

    private Animator anim;
    private Vector3 deltaPos;

    private bool dead = false;

    public bool Dead { get { return dead; } }

	// Use this for initialization
	void Start () {
        pathPoints = path.GetComponentsInChildren<Transform>();
        anim = GetComponent<Animator>();
        anim.SetBool("move", true);
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

    public void GetDamage(float hurt)
    {
        anim.SetTrigger("damage");
        lifeStrength -= hurt;

        StartCoroutine(WaitForDamage());
    }

    private IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        if (lifeStrength <= 0)
            Die();
    }

    private void Die()
    {
        speed = 0;
        dead = true;
        anim.SetTrigger("dead");
        StartCoroutine(WaitForDeath());    
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        Destroy(this.gameObject);
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
