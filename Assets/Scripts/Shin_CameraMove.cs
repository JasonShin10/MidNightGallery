using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shin_CameraMove : MonoBehaviour
{
    public GameObject sound;
    public GameObject destination;
    GameObject logo;
    public bool arrive = false;
    // Start is called before the first frame update
    void Start()
    {
        logo = GameObject.Find("Logo");
        logo.SetActive(false);
    }
    float currentTime = 0;
    float createTime = 3;
    // Update is called once per frame
    void Update()
    {
        if (sound.GetComponent<ChimeSound>().first == true)
        {
            transform.position = Vector3.Lerp(transform.position, destination.transform.position, Time.deltaTime * 0.1f);
        }
        float distance = Vector3.Distance(transform.position, destination.transform.position);
        if (distance < 90f)
        {
            
            arrive = true;
        }
        print(distance);
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            logo.SetActive(true);
            currentTime = 0;
        }
    }
}
