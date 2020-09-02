using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollow : MonoBehaviour
{
    public Transform TruckPos;
    public float carSpeed = 40f;
    const float dist = 5f;
    

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(TruckPos.position);
        if((transform.position - TruckPos.position).magnitude > dist)
        {
            transform.Translate(0f,0f,carSpeed*Time.deltaTime);
        }
    }
}
