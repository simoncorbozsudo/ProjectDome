
using UnityEngine;

public class DomeSpawner : MonoBehaviour
{
    public GameObject dome;

    public GameObject currentDome;

    public GameObject previousDome;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {

            int randomNumber = Random.Range(0, 3);

            Transform nextDomeTransform;
            GameObject doorToOpen;
            switch (randomNumber)
            {
                case 0:
                    doorToOpen = currentDome.transform.Find("Door 1").gameObject;
                    nextDomeTransform = currentDome.transform.Find("Next Dome Transform 1");
                    break;
                case 1:
                    doorToOpen = currentDome.transform.Find("Door 2").gameObject;
                    nextDomeTransform = currentDome.transform.Find("Next Dome Transform 2");
                    break;
                case 2:
                    doorToOpen = currentDome.transform.Find("Door 3").gameObject;
                    nextDomeTransform = currentDome.transform.Find("Next Dome Transform 3");
                    break;
                case 3:
                default:
                    doorToOpen = currentDome.transform.Find("Door 4").gameObject;
                    nextDomeTransform = currentDome.transform.Find("Next Dome Transform 4");
                    break;
            }

            doorToOpen.SetActive(false);

            if (previousDome)
            {
                GameObject.Destroy(previousDome);
            }

            previousDome = currentDome;
            previousDome.name = "Previous Dome";
            previousDome.transform.Find("Entry Door").gameObject.SetActive(false);

            currentDome = GameObject.Instantiate(dome, nextDomeTransform.position, nextDomeTransform.rotation);
            currentDome.name = "Current dome";
            currentDome.transform.Find("Entry Door").gameObject.SetActive(false);


            transform.position = nextDomeTransform.position;
            transform.rotation = nextDomeTransform.rotation;
            transform.Rotate(0, -90, 0);
            transform.Translate(0, 0.8f, -10);
        }
    }

}
