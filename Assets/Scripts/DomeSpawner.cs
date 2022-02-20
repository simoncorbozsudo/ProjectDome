
using System.Collections.Generic;
using UnityEngine;

public class DomeSpawner : MonoBehaviour
{
    public const int NUMBER_OF_NEXT_DOMES = 1;

    public const int MAX_NUMBER_OF_PREVIOUS_DOMES = 1;

    public GameObject domePrefab;

    private GameObject currentDome;

    private Queue<GameObject> domes;

    private GameObject lastDomeEnqueued;

    private void Start()
    {
        domes = new Queue<GameObject>();

        domes.Enqueue(currentDome);
        lastDomeEnqueued = currentDome;

        SpawnAndEnqueueInitialDome();

        for (int i = 0; i < NUMBER_OF_NEXT_DOMES; i++)
        {
            SpawnAndEnqueueNextDome();
            lastDomeEnqueued.name = "Dome +" + (i + 1);
        }
    }

    public void OnNextDomeEntryPassed()
    {
        Debug.Log("Door passed!");

        SpawnAndEnqueueNextDome();

        // Update current dome
        currentDome = domes.ToArray()[GetCurrentDomeIndex()];

        UpdateGameObjectNames();
    }

    private void SpawnAndEnqueueInitialDome()
    {
        GameObject initialDome = Instantiate(domePrefab, Vector3.zero, Quaternion.identity);
        initialDome.transform.Find("Entry Tunnel").GetComponent<Collider>().enabled = false;
        initialDome.transform.Find("Entry Door").GetChild(0).GetComponent<Collider>().enabled = true;
        initialDome.name = "Current Dome";
        domes.Enqueue(initialDome);
        lastDomeEnqueued = initialDome;
    }

    private void SpawnAndEnqueueNextDome()
    {
        Transform nextDomeTransform;
        GameObject doorToOpen;

        switch (Random.Range(0, 3))
        {
            case 0:
                doorToOpen = lastDomeEnqueued.transform.Find("Door 1").gameObject;
                nextDomeTransform = lastDomeEnqueued.transform.Find("Next Dome Transform 1");
                break;
            case 1:
                doorToOpen = lastDomeEnqueued.transform.Find("Door 2").gameObject;
                nextDomeTransform = lastDomeEnqueued.transform.Find("Next Dome Transform 2");
                break;
            case 2:
                doorToOpen = lastDomeEnqueued.transform.Find("Door 3").gameObject;
                nextDomeTransform = lastDomeEnqueued.transform.Find("Next Dome Transform 3");
                break;
            case 3:
            default:
                doorToOpen = lastDomeEnqueued.transform.Find("Door 4").gameObject;
                nextDomeTransform = lastDomeEnqueued.transform.Find("Next Dome Transform 4");
                break;
        }

        if (domes.Count == GetMaxNumberOfDomes())
        {
            GameObject domeToDestroy = domes.Dequeue();
            Destroy(domeToDestroy);
        }

        GameObject nextDome = Instantiate(domePrefab, nextDomeTransform.position, nextDomeTransform.rotation);
        domes.Enqueue(nextDome);
        lastDomeEnqueued = nextDome;

        doorToOpen.SetActive(false);
    }

    private void UpdateGameObjectNames()
    {
        int currentDomeIndex = GetCurrentDomeIndex();

        int index = 0;
        foreach (GameObject dome in domes)
        {
            if (index < currentDomeIndex)
            {
                dome.name = "Dome -" + (currentDomeIndex - index);
            }
            else if (index > currentDomeIndex)
            {
                dome.name = "Dome +" + (index - currentDomeIndex);
            }
            else
            {
                dome.name = "Current Dome";
            }

            index++;
        }
    }

    private int GetMaxNumberOfDomes()
    {
        return NUMBER_OF_NEXT_DOMES + MAX_NUMBER_OF_PREVIOUS_DOMES + 1;
    }

    private int GetCurrentDomeIndex()
    {
        return domes.Count - NUMBER_OF_NEXT_DOMES - 1;
    }

}
