using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

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
    private float currLifeStrength;

    private bool isWalking = false;

    public bool Dead { get { return dead; } }

	// Use this for initialization
	void Start () {
   //     pathPoints = path.GetComponentsInChildren<Transform>();
        anim = GetComponent<Animator>();
        anim.SetBool("walk", true);
        UpdateDestination();
        currLifeStrength = lifeStrength;
        healthBar.UpdateBar(currLifeStrength, lifeStrength);
        Debug.Log(pathPoints.Length);
    }
	
	// Update is called once per frame
	void Update () {
        if (isWalking)
        {
            if (currPoint < pathPoints.Length)
            {
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

        StartCoroutine(WaitForDamage());
    }

    private IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        if (currLifeStrength <= 0)
            Die();
    }

    private void Die()
    {
        dead = true;
        anim.SetTrigger("dead");
        StartCoroutine(WaitForDeath());    
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        Destroy(this.gameObject);
        LevelManager.Instance.AddCoins(priceForDeath);
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
        Debug.Log("Coll with gate");
        if(col.gameObject.tag == "Gate")
        {
            LevelManager.Instance.DamageGate(attackStrength);
            Destroy(this.gameObject);
        }
    }
}
