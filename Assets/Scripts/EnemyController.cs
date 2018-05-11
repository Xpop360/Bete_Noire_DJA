using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyController : MonoBehaviour
{

    public float seeDist, stopdist, speed;
    float distance;
    public float chaseSpeed, normalSpeed;
    bool chasing = false;
    NavMeshPath path;

    public GameObject target;
    NavMeshAgent agent;
    GameObject SoundManager;
    NavMeshPath Newpath;
    int i = 0;

    public Animator animator;

    [HideInInspector]
    public GameObject[] intPoints;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed;
        SoundManager = GameObject.FindGameObjectWithTag("SoundManager");
        Newpath = new NavMeshPath();
        //gets all by alphabetical order
        intPoints = GameObject.FindGameObjectsWithTag("intPoint").OrderBy(go => go.name).ToArray();
    }

    void Update()
    {
        ChaseTestandChase();
        if(chasing)
        {
            agent.speed = chaseSpeed;
        }
        else
        {
            agent.speed = normalSpeed;
            FollowPath();
        }
    }

    void ChaseTestandChase()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);
        agent.CalculatePath(target.transform.position, Newpath);

        if (distance <= seeDist && Newpath.status == NavMeshPathStatus.PathComplete)
        {
            chasing = true;
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
            chasing = false;
            agent.isStopped = false;
            agent.ResetPath();
            GetComponent<AudioSource>().enabled = false;
            animator.SetInteger("Speed", 0);
        }
    }

    void FollowPath()
    {
        if (Vector3.Distance(intPoints[i].transform.position, transform.position) <= agent.stoppingDistance)
        {
            animator.SetInteger("Speed", 0);
            if (i == intPoints.Length - 1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }
        animator.SetInteger("Speed", 1);
        agent.SetDestination(intPoints[i].transform.position);
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
