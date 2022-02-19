using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

[RequireComponent(typeof(Boids))]
public class BoidsBehaviorAlignement : MonoBehaviour
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
       var average = Vector3.zero;
       var found = 0;
       foreach(var boid in boids.Where(b => b != boid)){
           if(boid.isCaptain){

            var diff = boid.transform.position - this.transform.position;
            if(diff.magnitude < radius){
                average += boid.velocity;
                found +=1;
            }
           }
       }
       if(found > 0){
           average = average / found;
           boid.velocity += Vector3.Lerp(boid.velocity, average, Time.deltaTime);
       }
    }
}
