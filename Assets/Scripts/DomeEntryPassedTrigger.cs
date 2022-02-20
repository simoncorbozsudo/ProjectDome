using UnityEngine;

public class DomeEntryPassedTrigger : MonoBehaviour
{
    public Collider entryDoorCollider;

    private Collider tunnelCollider;

    private void Start()
    {
        tunnelCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Game Manager").GetComponent<DomeSpawner>().OnNextDomeEntryPassed();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tunnelCollider.enabled = false;
        entryDoorCollider.enabled = true;
    }
}
