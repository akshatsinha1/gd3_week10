using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Rigidbody ragdollRB in GetComponentsInChildren<Rigidbody>())
        {
            ragdollRB.isKinematic = true;
        }
    }

    public void triggerRagdoll()
    {
        foreach (Rigidbody ragdollRB in GetComponentsInChildren<Rigidbody>())
        {
            ragdollRB.isKinematic = false;
        }

        GetComponent<Collider>().enabled = false;

    }
}
