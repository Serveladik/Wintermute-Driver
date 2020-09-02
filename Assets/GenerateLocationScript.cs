using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLocationScript : MonoBehaviour
{
    List <GameObject> locationList = new List<GameObject>();
    GameObject genLocation;
    private int genCount=0;
    private Vector3 nextLocation = new Vector3 (0,0,175);
    public GameObject[] locations;
   void OnTriggerEnter(Collider generateTrigger)
   {
       if(generateTrigger.gameObject.tag == "Truck")
       {
           locationList.Add((GameObject) Instantiate(locations[Random.Range(0,1)],gameObject.transform.position+nextLocation,Quaternion.Euler(0,90,0)) as GameObject);
           Destroy(locationList[genCount],10f);
       }
       
   }

   
}
