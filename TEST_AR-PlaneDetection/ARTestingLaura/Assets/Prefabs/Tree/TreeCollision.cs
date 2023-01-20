using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "Tree";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
       
       Debug.Log("The Tree collided with " + collision.gameObject + "!");

    }
}