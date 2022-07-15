using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numFish = 20;
    public GameObject[] allfish;
    public Vector3 swimlimits = new Vector3(5, 5, 5);
    public Vector3 goalPos;
    public bool Randir = false;

    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;
    void Start()
    {
        allfish = new GameObject[numFish];
        for(int i = 0; i < numFish; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimlimits.x, swimlimits.x),
                                                                Random.Range(-swimlimits.y, swimlimits.y),
                                                                Random.Range(-swimlimits.z, swimlimits.z));
            allfish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
            allfish[i].GetComponent<Flock>().myManager = this;
        }
        goalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Randir == true)
        {
            if (Random.Range(0, 100) < 10)
            {
                goalPos = this.transform.position + new Vector3(Random.Range(-swimlimits.x, swimlimits.x),
                                                                Random.Range(-swimlimits.y, swimlimits.y),
                                                                Random.Range(-swimlimits.z, swimlimits.z));
            }
        }
        else
        {
            goalPos = this.transform.position;
        }
    }
}
