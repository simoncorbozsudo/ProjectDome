using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Boids))]
public class BoidsVelocitySync : MonoBehaviour
{
    private Boids boid;
    private Rigidbody rb;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        boid = GetComponent<Boids>();
    }

    // Update is called once per frame
    void Update()
    {
        var boids = FindObjectsOfType<Boids>();
        foreach (var boid_n in boids.Where(b => b != boid))
        {
            if (boid_n.isCaptain)
            {
                if (Vector3.Distance(boid_n.transform.position, this.transform.position) < radius)
                {
                    this.boid.velocity = Vector3.Lerp(this.boid.velocity, this.transform.forward.normalized*boid_n.velocity.magnitude, Time.deltaTime );
                    // this.boid.velocity = Vector3.Lerp(this.boid.velocity, boid_n.velocity, Time.deltaTime );
                    // this.boid.velocity += (transform.forward) * (Vector3.Distance(this.boid.transform.position, boid_n.transform.position)-2);
                    Debug.Log("Vitesse adapted");
                }
                else
                {
                    // this.boid.velocity = this.transform.forward * this.boid.maxVelocity;
                }
            }
        }
    }
}
