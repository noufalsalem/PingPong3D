using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 initialPos;
    void Start()
    {
        initialPos = transform.position;
    }

    //Ball has physics of bounce, so does the ground


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall")) //if it hits the wall (or the net) it returns to its initial pos
        {

            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initialPos;
        }
    }

}
