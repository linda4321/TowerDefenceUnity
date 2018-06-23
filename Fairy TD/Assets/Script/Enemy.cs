using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

 //   private static int counter = 0;

    public float speed = 1f;
 //   public GameObject path;
    public float lifeStrength = 5f;
    public float attackStrength = 5f;
    public int priceForDeath = 5;
    public SimpleHealthBar healthBar;

    private Transform[] pathPoints;
    private Vector3 currDestinationPoint;
    private int currPoint = 1;

    private Animator anim;
    private Vector3 deltaPos;

    private bool dead = false;
    private bool deadAnim = false;
    private float currLifeStrength;

    private bool isWalking = false;

    private Rigidbody body;

    public bool Dead { get { return dead; } }

	// Use this for initialization
	void Start () {
   //     pathPoints = path.GetComponentsInChildren<Transform>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        anim.SetBool("walk", true);
        UpdateDestination();
        currLifeStrength = lifeStrength;
        healthBar.UpdateBar(currLifeStrength, lifeStrength);
    }
	
	// Update is called once per frame
	void Update () {
        if (isWalking)
        {
            if (currPoint < pathPoints.Length)
            {
                if (transform.position != currDestinationPoint)
                {
          //          body.AddForce((currDestinationPoint - transform.position), ForceMode.Acceleration);
                     transform.position = Vector3.MoveTowards(transform.position, currDestinationPoint, speed);
                }
                else
                {
                    currPoint++;
                    UpdateDestination();
                }
            }
        }
	}

    public void Launch(Transform[] pathPoints)
    {
        this.pathPoints = pathPoints;
        isWalking = true;
    }

    public void GetDamage(float hurt)
    {
        anim.SetTrigger("damage");
        currLifeStrength -= hurt;

        healthBar.UpdateBar(currLifeStrength, lifeStrength);
        if (currLifeStrength <= 0)
            dead = true;
        StartCoroutine(WaitForDamage());
    }

    private IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        if (currLifeStrength <= 0 && !deadAnim)
            PlayDeadAnim();
    }


    private void PlayDeadAnim()
    {
    //    counter++;
        deadAnim = true;
    //    Debug.Log("Dead " + counter);
        anim.SetTrigger("dead");
        StartCoroutine(WaitForDeath());
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        Destroy(this.gameObject);
        LevelManager.Instance.AddCoins(priceForDeath);
        LevelManager.Instance.KilledEnemies++;
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

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Gate")
        {
            LevelManager.Instance.DamageGate(attackStrength);
            Destroy(this.gameObject);
        }
    }
}
