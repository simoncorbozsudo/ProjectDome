using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBirdPlaySound : MonoBehaviour
{
    public AudioSource death;
    public AudioSource fly;
    // Start is called before the first frame update
    public void playDeath()
    {
        death.Play();
    }
    public void stopFly()
    {
        fly.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
