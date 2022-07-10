using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshWay : MonoBehaviour
{
    public GameObject wpManager;
    GameObject[] wps;
    UnityEngine.AI.NavMeshAgent agente;

    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        agente = this.GetComponent<UnityEngine.AI.NavMeshAgent>();        
    }

    public void GoToHeli()
    {
        agente.SetDestination(wps[4].transform.position);
    }

    public void GoToRuin()
    {
        agente.SetDestination(wps[0].transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GoToHeli();
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GoToRuin();
        }
    }
}
