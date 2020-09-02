using System.Collections;
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
    //[HideInInspector]
    public float defaultSpeed;
    public float sensitivity;
    private Rigidbody rb;
    private Touch touch;
    private Quaternion rotationY;
    public GameObject gameOverAnim;
    public GameObject finishAnim;
    
    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void Update()
    {
        TruckControl();
        CheckSnow();
    }
    void TruckControl()
    {
        truck.transform.Translate(Vector3.forward*speed/100);
        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(0f,touch.deltaPosition.x * sensitivity/300,0f);
                transform.rotation = rotationY * transform.rotation;
            }
        }
    }
    void CheckSnow()
    {
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
        if(truck.gameObject.tag == "Dead")
        {
            gameOverAnim.SetActive(true);
            speed=0f;
           // Debug.Log("DEAD");
        }
        if(truck.gameObject.tag == "finish")
        {
            finishAnim.SetActive(true);
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
