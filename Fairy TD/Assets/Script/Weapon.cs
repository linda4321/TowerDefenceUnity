using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Enemy target;
    public float pauseToDisappear = 2f;
    public float strength = 5f;

    public float speed = 10f;

    private bool isGrounded;

    private bool launch;
    private Vector3 targetPoint;
    private Rigidbody body;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    void FixedUpdate()
    {
        if (launch && !isGrounded)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
          //  body.AddForce((targetPoint - transform.position), ForceMode.Impulse);
        }
    }

    public void Launch(Enemy target)
    {
        transform.LookAt(target.transform.position);
        targetPoint = target.transform.position; //+ new Vector3(0, target.GetComponent<Collider>().bounds.size.y / 2, 0);
        body = GetComponent<Rigidbody>();
        launch = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Destroy(this.gameObject, pauseToDisappear);
        }
        else if (col.gameObject.tag == "Enemy" && !isGrounded)
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            Debug.Log("Collision");
            enemy.GetDamage(strength);
            Destroy(this.gameObject);
        }

        OnCollision();
    }

    //protected virtual void DestroyOnGroundCollision()
    //{
    //    Destroy(this.gameObject, pauseToDisappear);
    //}

    //protected virtual void DestroyOnEnemyCollision()
    //{

    //    Destroy(this.gameObject);
    //}

    protected virtual void OnCollision()
    {
    }

}
