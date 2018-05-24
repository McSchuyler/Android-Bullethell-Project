using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAllSpawner : ProjectileSpawner
{
    public void Start()
    {
        autoCoroutine = AutoSpawnWaves();
    }

    public override void TriggerSpawn()
    {
        SpawnWaves();
    }

    public override void StartAuto()
    {
        StartCoroutine(autoCoroutine);
    }

    public override void StopAuto()
    {
        StopCoroutine(autoCoroutine);
    }

    public void SpawnWaves()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            SpawnProjectile(spawnPoint[i].transform.position, spawnPoint[i].transform.rotation);
        }
    }

    IEnumerator AutoSpawnWaves()
    {
        WaitForSeconds waitTime = new WaitForSeconds(nextBurstInterval);

        while(true)
        {
            SpawnWaves();
            yield return waitTime;
        }
    }
}
