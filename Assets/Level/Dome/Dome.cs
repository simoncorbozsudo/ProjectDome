using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//no need 
public class Dome
{
    public int nbBiomes  = 2;
    public const int maxNbExits  = 5;
    public GameObject DomeModel3D;
    public BiomesConfig biomeConfig;
    public Mesh DomeMesh;
    private int nbExits;
    
   
    private List<GameObject> exits;//exit have tunne
    Dome(){
        int biomeIndex = Random.Range(0,nbBiomes-1);
        this.nbExits = Random.Range(1,nbExits);
        //now iterate trough exits and randomly set them active 50 50 chance 
    }
    
    public List<GameObject> Exits
    {
        get { return exits; }
    }
}
