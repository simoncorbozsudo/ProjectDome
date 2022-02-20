using UnityEngine;

public class DomeEntryPassedTrigger : MonoBehaviour
{
    public Collider entryDoorCollider;

    private Collider tunnelCollider;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        tunnelCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.Play();
            GameObject.Find("Game Manager").GetComponent<DomeSpawner>().OnNextDomeEntryPassed();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tunnelCollider.enabled = false;
        Debug.Log(other.gameObject.name);
        entryDoorCollider.enabled = true;
    }
}
