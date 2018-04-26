using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float seeDist, stopdist;
    float distance;
    public float speed;

    public GameObject target;
    NavMeshAgent agent;
    GameObject SoundManager;
    NavMeshPath path;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        SoundManager = GameObject.FindGameObjectWithTag("SoundManager");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);
        agent.CalculatePath(target.transform.position, agent.path);

        if (distance <= seeDist && agent.path.status == NavMeshPathStatus.PathComplete)
        {
            SoundManager.GetComponent<SoundController>().Stop("Theme1");
            SoundManager.GetComponent<SoundController>().Stop("Thunder");
            agent.SetDestination(target.transform.position);
            GetComponent<AudioSource>().enabled = true;
            if (distance <= stopdist)
            {
                //attack
                //face target when attacking
                agent.isStopped = true;
                FaceTarget();
                Debug.Log("I'm here");
            }
        }
        else
        {
            agent.isStopped = false;
            agent.ResetPath();
            GetComponent<AudioSource>().enabled = false;
            SoundManager.GetComponent<SoundController>().Play("Thunder");
            SoundManager.GetComponent<SoundController>().Play("Theme1");
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
