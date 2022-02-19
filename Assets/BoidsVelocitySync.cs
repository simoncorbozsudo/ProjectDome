using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Boids))]
public class BoidsVelocitySync : MonoBehaviour
{
    private Boids boid;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
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
                    this.boid.velocity = this.transform.forward * 20f;
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
