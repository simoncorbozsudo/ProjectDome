using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Boids))]
public class BoidsBehaviorContainer : MonoBehaviour
{
    private Boids boid;
    public float radius;
    public float boundaryForce;
    // Start is called before the first frame update
    void Start()
    {
        boid = GetComponent<Boids>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boid.transform.position.magnitude > radius){
            boid.velocity += this.transform.position.normalized * (radius - boid.transform.position.magnitude) * boundaryForce * Time.deltaTime;
        }
    }
}
