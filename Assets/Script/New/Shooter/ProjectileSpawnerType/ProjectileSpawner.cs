using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ProjectileSpawner : MonoBehaviour {

    public enum TriggerType
    {
        Event,
        Auto
    };
    public GameObject[] spawnPoint;

    [Space]
    public string projectileTag;

    [Tooltip("Time wait when fire bullet one by one")]
    public float nextProjectileInterval = 0.5f;

    [Tooltip("Time wait to second round. Use at Auto Trigger")]
    public float nextBurstInterval = 1.5f;

    public TriggerType triggerType = TriggerType.Event;

    [Header("Random Rotation")]
    public bool isRandomRotation = false;
    [Tooltip("If random degree is 30 degree, spawn from -15 degree to +15 degree of the rotation")]
    public float randomDegree = 0;
    [Space]
    public bool useByProjectile = false;

    public IEnumerator autoCoroutine;

    abstract public void TriggerSpawn();
    abstract public void StartAuto();
    abstract public void StopAuto();

    public void SpawnProjectile(Vector3 pos, Quaternion rot)
    {
        if(!isRandomRotation)
        {
            ObjectPooler.instance.SpawnFromPool(projectileTag, pos, rot);
        }
        else
        {
            float randZ = Random.Range(-randomDegree / 2, randomDegree / 2);
            Vector3 randRot = new Vector3(0, 0, randZ);
            rot *= Quaternion.Euler(randRot);

            ObjectPooler.instance.SpawnFromPool(projectileTag, pos, rot);
        }
    }

    IEnumerator SpawnProjectileWaves()
    {
        WaitForSeconds burstInterval = new WaitForSeconds(nextBurstInterval);

        for(int i=0; i<spawnPoint.Length; i++)
        {
            SpawnProjectile(spawnPoint[i].transform.position, spawnPoint[i].transform.rotation);

            yield return burstInterval;
        }
    }
}
