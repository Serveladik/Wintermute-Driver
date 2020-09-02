using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeTime : MonoBehaviour
{
    // Start is called before the first frame update

    public TruckController truckSpeed;
    public GameObject startBtn;
    void Start()
    {
       Time.timeScale=0f; 
       truckSpeed.speed = 0;

    }

    public void UnFreeze()
    {
        
        Time.timeScale=1f;
        startBtn.SetActive(false);
        truckSpeed.speed = truckSpeed.defaultSpeed;
    }
    
}
