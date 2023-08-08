using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public int floaters;
    public float waterVelocityDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    public Rigidbody body;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;

    private void FixedUpdate()
    {
        float y = transform.position.y;
        float wH = Wave.instance.GetHeight(transform.position.x, transform.position.z);
        body.AddForce((Physics.gravity / floaters));

        if (y<= wH)
        {
            float submersion = Mathf.Clamp01(wH - y) / depthBeforeSubmerged;
            float buoyancy = Mathf.Abs(Physics.gravity.y) * submersion * displacementAmount;
            body.AddForceAtPosition(Vector3.up * buoyancy, transform.position,
                ForceMode.Acceleration);
            body.AddForce(-body.velocity * waterVelocityDrag * Time.fixedDeltaTime,
                ForceMode.VelocityChange);
            body.AddTorque(-body.angularVelocity * waterAngularDrag *
                Time.fixedDeltaTime, ForceMode.VelocityChange); 
        }
    }
}
