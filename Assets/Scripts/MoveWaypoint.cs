using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class MoveWaypoint : MonoBehaviour {

    public UnityStandardAssets.Utility.WaypointCircuit circuit;
    
    int currentWP = 0;
    [SerializeField]
    private float velocidade = 1f;
    [SerializeField]
    private float magntde = 0.01f;
    [SerializeField]
    private float rotVeloc = 0.4f;

    void Start() {

        //waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

    }
    void LateUpdate(){
        if (circuit.Waypoints.Length == 0) return;

        Vector3 LookAtGoal = new Vector3(circuit.Waypoints[currentWP].transform.position.x, this.transform.position.y, circuit.Waypoints[currentWP].transform.position.z);
        Vector3 rotLookAt = LookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(rotLookAt), Time.deltaTime * rotVeloc);

        if(rotLookAt.magnitude < magntde)
        {
            currentWP++;
            if(currentWP >= circuit.Waypoints.Length){
                currentWP = 0;
            }
        }
        this.transform.Translate(0,0, velocidade * Time.deltaTime);
        
    }
}
