using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarFollow : MonoBehaviour
{
    public Transform TruckPos;
    public NavMeshAgent navMesh;
    

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(TruckPos.position);
    }
}
