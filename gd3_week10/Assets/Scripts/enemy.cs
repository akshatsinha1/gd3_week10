using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{

    Transform player;
    [SerializeField] float followRadius;
    NavMeshAgent agent;

    Vector3 randomTarget;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<shooting>().transform;
        agent = GetComponent<NavMeshAgent>();

        randomTarget = new Vector3(transform.position.x + (Random.Range(-10,10)), transform.position.y, transform.position.z + (Random.Range(-10, 10)));
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) > followRadius)
        {
            search();
        }
        else
        {
            followPlayer();
        }

        if (Vector3.Distance(transform.position, randomTarget) < 1)
        {
            randomTarget = new Vector3(transform.position.x + (Random.Range(-10, 10)), transform.position.y, transform.position.z + (Random.Range(-10, 10)));
        }

        if(Vector3.Distance(player.position,transform.position) < 2)
        {
            attack();
        }
    }

    void followPlayer()
    {
        agent.SetDestination(player.position);
    }

    void search()
    {
        agent.SetDestination(randomTarget);
        
    }

    void attack()
    {

    }

}
