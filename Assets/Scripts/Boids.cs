using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{
    public Vector3 velocity;
    public float maxVelocity;
    public bool isCaptain = false;
    List<GameObject> children = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (!isCaptain)
        {
            velocity = this.transform.forward * maxVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCaptain)
        {
            if (velocity.magnitude > maxVelocity)
            {
                velocity = velocity.normalized * maxVelocity;
            }
            this.transform.position += velocity * Time.deltaTime;
            this.transform.rotation = Quaternion.LookRotation(velocity);
        }
    }
}
