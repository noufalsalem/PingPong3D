using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3f;
    public Transform aimTarget;
    bool hitting;
    float force = 8;
    [SerializeField] Rigidbody rb; //added rigidbody

    Animator animator;

    Vector3 aimTargetInittialPosition;

    public Transform ball;

    void Start()
    {
        animator = GetComponent<Animator>();
        aimTargetInittialPosition = aimTarget.position;
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

       /*if (Input.GetKeyDown("space"))
        {
          transform.Translate(Vector3.up * 50 * Time.deltaTime, Space.World);
          }**/ //so far only complicates things 

        //This is for the aim target:
        if (Input.GetKeyDown(KeyCode.F)) //if user is pressing the F key
        {

            hitting = true;
        }
        else if (Input.GetKeyUp(KeyCode.F)) //if user lets go of the F key

            hitting = false;



        if (hitting)
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime);




        if ((h !=0 || v !=0  ) && !hitting) {

            transform.Translate(new Vector3(h , 0 , v) * speed *Time.deltaTime); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball"))
        {
            Vector3  dir = aimTarget.position - transform.position; //directs the player to the target
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3 (0 ,5 ,0) ;

            Vector3 ballDir = ball.position - transform.position; //direction of the ball (+ve or -ve)
            if (ballDir.z >= 0) //z because our world has z as horizontal instead of x 
            {
                animator.Play("forehand");
                
            }
            else
            {
                animator.Play("backhand");
                
            }
        }

        aimTarget.position = aimTargetInittialPosition;


    }


}
