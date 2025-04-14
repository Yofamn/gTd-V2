using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileWithRigidbody : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 15f;   //make sure to test this value
                                                    //I don't know why 500f worked fine on my laptop
                                                    //acccording to the video,
                                                    //but it is too high on my desktop

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Impulse();
    }

    private void Impulse()
    {
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
    }
        //https://www.youtube.com/watch?app=desktop&v=iuamtM_VJgQ

}
