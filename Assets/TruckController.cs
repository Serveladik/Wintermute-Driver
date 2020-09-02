using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    private bool snowing=true;
    public GameObject truck;
    public GameObject snow;
    public GameObject leftKovsh;
    public GameObject rightKovsh;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        TruckControl();
    }
    void TruckControl()
    {
        truck.transform.Translate(Vector3.forward*speed/100);
    }
    void OnTriggerEnter(Collider truck)
    {
        if(truck.tag == "Snow")
        {
            snowing=true;
            while(snowing == true)
            {
                StartCoroutine("snowSpawn");
            }
        }
    }
    void OnTriggerExit(Collider truck)
    {
        if(truck.tag == "Snow")
        {
            StopCoroutine("snowSpawn");
        }
    }
    IEnumerator snowSpawn()
    {
        Instantiate(snow,leftKovsh.transform.position,Quaternion.identity);
        Instantiate(snow,rightKovsh.transform.position,Quaternion.identity);
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
