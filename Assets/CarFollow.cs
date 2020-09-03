using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarFollow : MonoBehaviour
{
    public Transform TruckPos;
    public Rigidbody rb;
    private float speed = 0.58f;
    
    

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(TruckPos.position);
        float distance = Vector3.Distance(TruckPos.position, transform.position);
        if(distance>=10f)
        {
            transform.position = Vector3.Lerp(transform.position, TruckPos.position, speed * Time.deltaTime);
        }
    }
}
