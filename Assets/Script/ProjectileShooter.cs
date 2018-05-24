using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    public enum ShootMode
    {
        AllAtOnce,
        OneByOne,
        RandomNoRepeat,
        RandomRepeat
    };
    public enum TriggerType
    {
        Event,
        Auto
    };

    public ShootMode shooterState = ShootMode.AllAtOnce;

    [Header("Shooter Attribute")]
    public GameObject[] shooterPoint;

    [Space]
    public string bulletTag;

    [Tooltip("Time wait when fire bullet one by one")]
    public float shootInterval = 0.5f;

    [Tooltip("Time wait to second round. Use at Auto Trigger")]
    public float nextBurstInterval = 1.5f;

    public TriggerType triggerType = TriggerType.Event;

    private bool firstEnableTriggered = false;

    private void OnEnable()
    {
        if(triggerType == TriggerType.Auto)
        {
            if (firstEnableTriggered == true)
            {
                if (shooterState == ShootMode.AllAtOnce)
                    StartCoroutine(RepeatShooting());
                if (shooterState == ShootMode.OneByOne)
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
