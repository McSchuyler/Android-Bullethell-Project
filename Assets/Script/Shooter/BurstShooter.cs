using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstShooter : MonoBehaviour {

    public float numberOfBurst;
    public string bulletTag;
    public float shootInterval = 1.0f;

    private void Start()
    {
        InvokeRepeating("Shoot", 1.0f, shootInterval);
    }

    void Shoot()
    {
        for (int i = 0; i < numberOfBurst; i++)
        {
            ObjectPooler.instance.SpawnFromPool(bulletTag, transform.position, transform.rotation);
        }
    }

    void SetBulletInterval()
    {

    }
}
