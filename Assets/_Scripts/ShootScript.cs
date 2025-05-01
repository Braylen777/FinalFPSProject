using UnityEngine;
using System.Collections;
using System.Drawing;

public class Shoot : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 0.2f;
    private float gunHeat;
    private const float TimeBetweenShots = 0.25f;  // seconds
  
    void Update()
    {
        // cool the gun
        if (gunHeat > 0)
        {
            gunHeat -= Time.deltaTime;
        }

        // is the player asking to shoot?
        if (Input.GetMouseButton(0))
        {
            // can we shoot yet?
            if (gunHeat <= 0)
            {
                // heat the gun up so we have to wait a bit before shooting again
                gunHeat = TimeBetweenShots;

                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0f, 0f, speed));
            }
        }
    }


}