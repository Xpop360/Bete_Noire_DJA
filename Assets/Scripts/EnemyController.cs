using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float seeDist, stopdist;
    float distance;
    public float speed;
    NavMeshPath path;

    public GameObject target;
    NavMeshAgent agent;
    GameObject SoundManager;
    NavMeshPath Newpath;

    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        SoundManager = GameObject.FindGameObjectWithTag("SoundManager");
        Newpath = new NavMeshPath();
    }

    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);
        agent.CalculatePath(target.transform.position, Newpath);

        if (distance <= seeDist && Newpath.status == NavMeshPathStatus.PathComplete)
        {
            agent.isStopped = false;
            agent.SetDestination(target.transform.position);
            GetComponent<AudioSource>().enabled = true;
            animator.SetInteger("Speed", 2);
            if (distance <= stopdist)
            {
                agent.isStopped = true;
                agent.ResetPath();
                //attack
                FaceTarget();
                Debug.Log("I'm here");
                animator.SetInteger("Speed", 0);
            }
        }
        else
        {
            agent.isStopped = false;
            agent.ResetPath();
            GetComponent<AudioSource>().enabled = false;
            animator.SetInteger("Speed", 0);
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
