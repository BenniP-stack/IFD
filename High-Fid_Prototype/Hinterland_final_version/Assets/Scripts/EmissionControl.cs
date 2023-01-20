
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionControl : MonoBehaviour
{
    public Transform player; 
    public float range = 10f;
    new ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > range)
        {
            particleSystem.Stop();
        }
        else
        {
            particleSystem.Play();
        }
    }
}