
using UnityEngine;

public class BoidVicinityManager : MonoBehaviour
{
    public int Score=0; 
    /*
    ontrigger enter and exit are run sequentially
    */
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer== LayerMask.NameToLayer("BoidLayer")){
            Score++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        if(other.gameObject.layer == LayerMask.NameToLayer ("BoidLayer")){
            Score--;
        }
    }
}
