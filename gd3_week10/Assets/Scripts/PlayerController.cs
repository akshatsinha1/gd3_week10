using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Transform target1;
    NavMeshAgent agent;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.SetDestination(target1.position);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray pointerRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(pointerRay,out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
