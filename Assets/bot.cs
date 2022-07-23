using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    //mostly the same as player but automatic/no controls
    float speed = 50;
    Animator animator;
    public Transform ball;
    public Transform aimTarget;
    float force = 10;

    Vector3 targetPosition;


    void Start()
    {
        targetPosition = transform.position;
        animator = GetComponent<Animator>(); 
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        targetPosition.z = ball.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball"))
        {
            Vector3 dir = aimTarget.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 3, 0);

            Vector3 ballDir = ball.position - transform.position;
            if (ballDir.z >= 0) //z because the world has z as horizontal instead of x 
            {
                animator.Play("forehand");

            }
            else
            {
                animator.Play("backhand");

            }
        }




    }
}