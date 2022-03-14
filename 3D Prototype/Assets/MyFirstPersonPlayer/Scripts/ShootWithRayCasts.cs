/*
* (Conner Ogle)
* (3D Prototype)
* (Uses raycasts to allow the player to shoot)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRayCasts : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public ParticleSystem muzzleFlash;

    public float hitForce = 10f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            muzzleFlash.Play();
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        //if we hit something with our ray....
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);


            //get the target script off the hit object
            Target target = hitInfo.transform.gameObject.GetComponent<Target>();
            //if the target script was found, make the target take damage
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }

        }
    }
}
