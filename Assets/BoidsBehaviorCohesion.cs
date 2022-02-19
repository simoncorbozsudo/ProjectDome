using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Boids))]
public class BoidsBehaviorCohesion : MonoBehaviour
{
    private Boids boid; 
    public float radius;
    public float captainRatio = 10;
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
           var diff = boid.transform.position - this.transform.position;
           if(diff.magnitude < radius){
               
               average += boid.isCaptain ? diff*captainRatio : Vector3.zero;
               found +=1;
           }
       }
       if(found > 0){
           average = average / found;
           boid.velocity += Vector3.Lerp(Vector3.zero, average, average.magnitude / radius);
       }
    }
}
