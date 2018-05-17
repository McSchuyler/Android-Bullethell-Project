using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    public GameObject[] shooterPoint;
    public string bulletTag;
    public float shootInterval = 0.5f;
    public float nextBurstInterval = 1.5f;

    public enum Type
    {
        Trigger,
        Auto
    };

    public enum State
    {
        AllFire,
        Burst
    };

    public State shooterState = State.AllFire;
    public Type shooterType = Type.Trigger;

    private bool firstEnableTriggered = false;

    private void OnEnable()
    {
        if(shooterType == Type.Auto)
        {
            if (firstEnableTriggered == true)
            {
                if (shooterState == State.AllFire)
                    StartCoroutine(RepeatShooting());
                if (shooterState == State.Burst)
                    StartCoroutine(IntervalShooting());
            }
            firstEnableTriggered = true;
        }
    }

    private void OnDisable()
    {
        StopCoroutine(RepeatShooting());
        StopCoroutine(IntervalShooting());
    }

    IEnumerator RepeatShooting()
    {
        WaitForSeconds waitTime = new WaitForSeconds(shootInterval);

        while (true)
        {
            for (int i = 0; i < shooterPoint.Length; i++)
            {
                ObjectPooler.instance.SpawnFromPool(bulletTag, shooterPoint[i].transform.position, shooterPoint[i].transform.rotation);
            }

            yield return waitTime;
        }
    }

    IEnumerator IntervalShooting()
    {
        while(true)
        {
            WaitForSeconds shotWaitinterval = new WaitForSeconds(shootInterval);
            WaitForSeconds burstWaitInterval = new WaitForSeconds(nextBurstInterval);

            for(int i = 0; i<shooterPoint.Length;i++)
            {
                ObjectPooler.instance.SpawnFromPool(bulletTag, shooterPoint[i].transform.position, shooterPoint[i].transform.rotation);
                yield return shotWaitinterval;
            }
            yield return burstWaitInterval;
        }
    }

    public void TrigerShoot()
    {
        for (int i = 0; i < shooterPoint.Length; i++)
        {
            ObjectPooler.instance.SpawnFromPool(bulletTag, shooterPoint[i].transform.position, shooterPoint[i].transform.rotation);
        }
    }
}
