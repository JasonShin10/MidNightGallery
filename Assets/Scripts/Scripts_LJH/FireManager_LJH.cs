using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager_LJH : MonoBehaviour
{
    public int fireCount = 3;
    public GameObject fireSparkPrefab;
    public GameObject firePrefab;

    int currFireCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currFireCount >= 3)
            {


                // Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.5f));
                // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                //  mousePos.z += 10;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    GameObject fire = Instantiate(firePrefab);
                    fire.transform.position = hit.point;
                    fire.transform.position += hit.normal * 0.1f;
                }
                currFireCount = 0;
            }
            else
            {
                //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                //mousePos.z += 10f;
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3f));

                GameObject spark = Instantiate(fireSparkPrefab);
                spark.transform.position = mousePos;
                currFireCount += 1;
            }
        }
    }
}