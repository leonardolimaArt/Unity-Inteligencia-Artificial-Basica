using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCylinder : MonoBehaviour
{
    public GameObject Cylinder;
    GameObject[] ai;

    void Start()
    {
        ai = GameObject.FindGameObjectsWithTag("ai");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Vector3 point = new Vector3(hitInfo.point.x, 2, hitInfo.point.z);
                GameObject cyIns = Instantiate(Cylinder, point, Cylinder.transform.rotation) as GameObject;  
                foreach(GameObject a in ai)
                {
                    a.GetComponent<AICrowd>().DetectNewObstacle(hitInfo.point);
                }
                Destroy(cyIns, 2);
            }
        }
        
    }
}
