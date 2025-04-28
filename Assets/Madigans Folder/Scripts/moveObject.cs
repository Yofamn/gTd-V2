using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void MoveObj(float impact)
    {
        Vector3 right = Camera.main.transform.right;
        Vector3 impactDirection = transform.position - right;
        impactDirection.Normalize();
        rigidbody.AddForce(impactDirection*impact, ForceMode.Impulse);
    }
}
