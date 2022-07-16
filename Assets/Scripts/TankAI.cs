using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TankAI : MonoBehaviour
{

    Animator anim;
    NavMeshAgent agent;
    public GameObject Bullet;
    public GameObject turret;
    public GameObject player;
    RaycastHit hit = new RaycastHit();
    public GameObject GetPlayer()
    {
        return player;
    }
    
    void Fire()
    {
        GameObject b = Instantiate(Bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * (Vector3.Distance(transform.position, player.transform.position) * 50));
        b.GetComponent<Rigidbody>().AddTorque(turret.transform.right * 20f);
    }

    public void StartFiring()
    {
   
        InvokeRepeating("Fire", 0.5f, 0.5f);

    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        Debug.DrawRay(this.transform.position, this.transform.position * 10, Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
        
        if (Physics.Raycast(transform.position, transform.forward * 50, out hit))
        {
            if (hit.collider.CompareTag("Player") && anim.GetFloat("distance") < 10)
            {
                Debug.Log("Player");
                anim.SetBool("fire", true);
                agent.speed = 0f;
            }
            else
            {
                anim.SetBool("fire", false);
                agent.speed = 5f;
            }
        }

    }
}

