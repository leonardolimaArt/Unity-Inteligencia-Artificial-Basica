using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICrowd : MonoBehaviour
{

    public GameObject[] waypoint;
    public GameObject[] obstacle;
    Animator anim;
    NavMeshAgent agent;
    float detectionRadius = 10;
    float fleeRadius = 15;

    void ResetAgent()
    {
        anim.SetTrigger("isWalking");
        agent.speed = 1;
        agent.angularSpeed = 120;
        agent.ResetPath();
    }

    public void DetectNewObstacle(Vector3 position)
    {
        if(Vector3.Distance(position, this.transform.position) < detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - position).normalized;
            Vector3 newgoal = this.transform.position + fleeDirection * fleeRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newgoal, path);

            if(path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                anim.SetTrigger("isRunning");
                agent.speed = 5;
                agent.angularSpeed = 500;
            }
        }
    }

    void Start()
    {
        waypoint = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        anim.SetFloat("ofset", Random.Range(0, 1f));
        agent.SetDestination(waypoint[Random.Range(0, waypoint.Length)].transform.position);
        ResetAgent();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 1)
        {
            ResetAgent();
            agent.SetDestination(waypoint[Random.Range(0, waypoint.Length)].transform.position);
        }
    }
}
