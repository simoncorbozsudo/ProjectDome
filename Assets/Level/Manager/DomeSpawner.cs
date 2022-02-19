
using System.Collections.Generic;
using UnityEngine;

public class DomeSpawner : MonoBehaviour
{
    public int numberOfNextDomes = 1;

    public int maxNumberOfPreviousDomes = 1;

    public GameObject domePrefab;

    public GameObject currentDome;

    private Queue<GameObject> domes;

    private GameObject lastDomeEnqueued;

    private void Start()
    {
        domes = new Queue<GameObject>();

        domes.Enqueue(currentDome);
        lastDomeEnqueued = currentDome;

        for (int i = 0; i < numberOfNextDomes; i++)
        {
            SpawnAndEnqueueNextDome();
            lastDomeEnqueued.name = "Dome +" + (i + 1);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {

            SpawnAndEnqueueNextDome();

            UpdateCurrentDome();

            UpdateGameObjectNames();
        }
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
        nextDome.transform.Find("Entry Door").gameObject.SetActive(false);
        domes.Enqueue(nextDome);
        lastDomeEnqueued = nextDome;

        doorToOpen.SetActive(false);
    }

    private void UpdateCurrentDome()
    {
        currentDome = domes.ToArray()[GetCurrentDomeIndex()];
    }

    private int GetMaxNumberOfDomes()
    {
        return numberOfNextDomes + maxNumberOfPreviousDomes + 1;
    }

    private int GetCurrentDomeIndex()
    {
        return domes.Count - numberOfNextDomes - 1;
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

}
