using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstLocAutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,22f);
    }
}
