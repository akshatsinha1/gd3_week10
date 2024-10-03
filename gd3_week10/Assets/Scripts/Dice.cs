using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int diceOutput;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raycast(transform.forward, 1, Color.red);
        raycast(-transform.forward, 6,Color.blue);
        raycast(transform.up, 2, Color.green);
        raycast(-transform.up, 5,Color.yellow);
        raycast(transform.right, 3,Color.magenta);
        raycast(-transform.right, 4,Color.cyan);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddTorque(Random.Range(-15, 15), Random.Range(-15, 15), Random.Range(-15, 15), ForceMode.Impulse);

            //GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.Impulse);
        }
    }

    void raycast(Vector3 direction, int output,Color rayColour)
    {
        if (Physics.Raycast(transform.position, direction,0.6f, groundMask))
        {
            diceOutput = output;
        }

        Debug.DrawRay(transform.position, direction * 0.6f, rayColour);
    }
}
