using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    public GameObject[] shooterPoint;
    public GameObject projectile;
    public float time = 3f;
    public float shootInterval = 0.5f;

    private void OnEnable()
    {
        StartCoroutine(Shooting());
    }

    private void Shoot(int index)
    {
        Destroy(Instantiate(projectile, shooterPoint[index].transform.position, shooterPoint[index].transform.rotation), time);
    }

    IEnumerator Shooting()
    {
        while(true)
        {
            for(int i=0;i<shooterPoint.Length;i++)
            {
                Shoot(i);
            }
            yield return new WaitForSeconds(shootInterval);
        }
    }
}
