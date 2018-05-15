using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    public GameObject[] shooterPoint;
    public string bulletTag;
    public float time = 3f;
    public float shootInterval = 0.5f;

    private void Start()
    {
        InvokeRepeating("Shoot", 0f, shootInterval);
    }

    private void Shoot()
    {
        for (int i = 0; i < shooterPoint.Length; i++)
        {
            ObjectPooler.instance.SpawnFromPool(bulletTag, shooterPoint[i].transform.position, shooterPoint[i].transform.rotation);
        }
    }
}
