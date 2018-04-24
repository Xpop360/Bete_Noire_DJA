using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float seeDist, stopdist;
    float distance;

    public GameObject target;
    NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance <= seeDist && distance >= stopdist)
        {
            agent.SetDestination(target.transform.position);
            if (distance <= agent.stoppingDistance)
            {
                //attack
                //face target when attacking
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected() //just draws stuff for us to see
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seeDist);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stopdist);
    }
}
