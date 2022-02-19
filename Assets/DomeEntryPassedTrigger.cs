using UnityEngine;

public class DomeEntryPassedTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Game Manager").GetComponent<DomeSpawner>().OnNextDomeEntryPassed();
        }
    }
}
