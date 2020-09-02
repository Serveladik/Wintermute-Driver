﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public float snowingTime;

    public float defaultSnowTime;
    private bool snowing=false;
    public GameObject truck;
    //public List<GameObject> snowList = new List <GameObject>();
    public GameObject[] snow;
    public GameObject leftKovsh;
    public GameObject rightKovsh;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        TruckControl();
        //Debug.Log(snowing);
    }
    void TruckControl()
    {
        truck.transform.Translate(Vector3.forward*speed/100);
        if(snowing == true)
        {
            snowingTime-=Time.deltaTime;
            if(snowingTime<=0)
            {
                snowSpawn();
                snowingTime=defaultSnowTime;
            }
            
        }
    }
    void OnTriggerEnter(Collider truck)
    {
        if(truck.gameObject.tag == "Snow")
        {
            snowing=true;
        }
        
    }
    void OnTriggerExit(Collider truck)
    {
        if(truck.gameObject.tag == "Snow")
        {
            snowing=false;
            
        }
    }
    void snowSpawn()
    {
        GameObject snowLeft = Instantiate(snow[Random.Range(0,3)],leftKovsh.transform.position,Quaternion.identity) as GameObject;
        GameObject snowRight = Instantiate(snow[Random.Range(0,3)],rightKovsh.transform.position,Quaternion.identity) as GameObject;

        Destroy(snowLeft,2f);
        Destroy(snowRight,2f);
    }
}
