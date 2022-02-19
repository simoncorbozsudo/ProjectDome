using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float radius;
    public int number_of_boids;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< number_of_boids; i++){
            Instantiate(prefab, this.transform.position + (Random.insideUnitSphere * radius), Random.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
