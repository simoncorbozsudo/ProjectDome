using UnityEngine;

public class BirdDeathChecker : MonoBehaviour
{
    private bool toDestroy;

    public BoidVicinityManager boidVicinityManager;
    
    void Start(){
        toDestroy = false;
    }
    
    void OnCollisionEnter(Collision other) {
         if(other.gameObject.layer == LayerMask.NameToLayer("DomeLayer")&&!toDestroy){
            Debug.Log("i died");
            toDestroy = true;
         }
        
    }
    void Update(){
        if(toDestroy) {
            boidVicinityManager.Score--;
            Destroy(this.gameObject);
        }
    }
}
