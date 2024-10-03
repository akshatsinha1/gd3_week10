using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class shooting : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = 0.5f;
    public float fireRange = 50f;
    public float hitForce = 15f;
    public Transform gunEnd;
    public float waitTime;

    Camera fpsCam;
    AudioSource _as;
    LineRenderer _lr;
    float nextFire;

    GameObject cannonB;


    // Start is called before the first frame update
    void Start()
    {
        fpsCam = Camera.main;
        _as = GetComponent<AudioSource>();
        _lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        Debug.DrawRay(rayOrigin, fpsCam.transform.forward * fireRange, Color.red);

        _lr.SetPosition(0, gunEnd.position);

        if (Input.GetMouseButtonDown(0) && Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(shootingEffect());

            //raycast stuff
            RaycastHit hit;
            

            if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, fireRange))
            {
                _lr.SetPosition(1, hit.point);

                ShootableBox targetBox = hit.transform.GetComponent<ShootableBox>();

                if(targetBox != null)
                {
                    targetBox.Damage(gunDamage);
                }

                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce((hit.point - rayOrigin).normalized * hitForce, ForceMode.Impulse);
                }

                ragdollTrigger _ragdollTrigger = hit.transform.GetComponent<ragdollTrigger>();
                if(_ragdollTrigger != null)
                {
                    _ragdollTrigger.triggerRagdoll();
                    hit.transform.GetComponent<NavMeshAgent>().enabled = false;
                }
            }
            else
            {
                _lr.SetPosition(1, fpsCam.transform.forward * 99999999);
            }
        }
    }

    

    IEnumerator shootingEffect()
    {
        _as.Play();
        _lr.enabled = true;
        yield return new WaitForSeconds(waitTime);
        _lr.enabled = false;
    }
}
