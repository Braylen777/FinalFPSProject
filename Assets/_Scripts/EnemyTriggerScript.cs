using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerScript : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 0.25f;
    private float gunHeat;
    private const float TimeBetweenShots = .25f;  // seconds

    void OnTriggerStay(Collider otherCollider)
    {
        // cool the gun
        if (gunHeat > 0)
        {
            gunHeat -= Time.deltaTime;
        }

        if (gunHeat <= 0)
        {
            gunHeat = TimeBetweenShots;
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0f, 0f, speed));
        }
        
    }


}