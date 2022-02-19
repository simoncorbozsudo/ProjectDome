using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//used for small scale 
//seed is the position in the room
//returning in an ancient room will respawn the room and ennemy
//monolithic entity which decide when 
//to open door and spawn new rooms
//this game uses a procedural system to create rooms
//There is no need to save rooms in memory -> doors will be closed behind a playe
// pas de tunnel dans le systeme
public class LevelManager : MonoBehaviour
{
    public float minDistanceFromDoor;
    private int nbRooms;
    //set by dev -> max number of rooms
    public int maxNbRooms;
    //set by dev -> min number of rooms
    public int minNbRooms;
    //center of the boid
    public GameObject Player;
    private GameObject currRoomPrefab;
    //next room to be spawned in
    private GameObject nextRoomPrefab;
    private bool isAnExitDoorOpen;
    private bool isDefinitelyInTunnel;
    private GameObject actualExit;
    //startPositions
    // Start is called before the first frame update
    void Start()
    {   //init numberOfRooms
        this.isAnExitDoorOpen = false;
        this.isDefinitelyInTunnel = false;
        this.nbRooms = Random.Range(minNbRooms, maxNbRooms);
        Instantiate(currRoomPrefab, new Vector3(0, 0, 0), Quaternion.identity);//always instantiate at center room
    }
    // Update is called once per frame
    void Update()
    {
        //first get the position
        Vector3 playerPos = Player.transform.position;
        //check each exit of the actual room
        if(!isAnExitDoorOpen){
            Dome dome = currRoomPrefab.GetComponent<Dome>();
            foreach(GameObject exit in dome.Exits)
            {
                //is the flock of bird looking at the door?
                Vector3 dir = (playerPos.position - exit.transform.position).normalized;
                float delta = Vector3.Dot(dir, exit.forward);
                float distance = Vector3.Distance(playerPos.position, exit.transform.position);
                if(delta >=0.8f && distance < minDistanceFromDoor){
                    //flock is looking directly at the door and is in range from the object
                    //set bool to true
                    isAnExitDoorOpen=true;
                    //save the current exit for easier computing
                    actualExit = exit;
                    //-----TODO-----
                    //TRIGGER OPENING
                    //PRELOAD THE ROOM
                    //-----TODO-----
                    break;
                }
            }
        }else{
            //the door is opened 
            float delta = Vector3.Dot(dir, exit.forward);
            float distance = Vector3.Distance(playerPos.position, exit.transform.position);
            //did i pass the door?
            if(delta <= 0.0f && distance < minDistanceFromDoor){
                //TODO 
                //SWAP GAMEOBJECTS
                //UNINSTANTIATE NEXTROOM
            }else if(delta < 0.0f && distance >= minDistanceFromDoor){
                this.actualExit = null;
                this.isAnExitDoorOpen = false;
                Destroy(this.nextRoomPrefab);
            }
        }
        


        Vector3 dir = (playerPos - transform.position).normalized;
         
            //check player pos in active room
        //if close to exit of active room 
            // -> spawn a tunnel
        
            //-> load the next room
    }

}
