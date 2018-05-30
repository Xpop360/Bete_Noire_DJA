using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius;
    public GameObject player;
    [HideInInspector]
    public bool inRadius;
    float distance;

    void Start()
    {
        inRadius = false;
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < radius)
        {
            inRadius = true;
        }
        else
        {
            inRadius = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
