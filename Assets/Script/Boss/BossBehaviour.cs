using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BossAttackEvent : UnityEvent
{
}

public class BossBehaviour : MonoBehaviour {

    public float movementSpeed = 2f;
    public float minTreshold = 0.5f;
    public float attackTime = 1.0f;
    public GameObject[] targets;

    public BossAttackEvent attackEvent;

    private int lastSelectedPoint = -1;
    private Vector3 currentTargetLocation;

    private void Start()
    {
        if (attackEvent == null)
            attackEvent = new BossAttackEvent();

        StartCoroutine(GoToPoint(targets[RandomSelectPoint()].transform.position));
    }

    IEnumerator GoToPoint(Vector3 point)
    {
        Vector3 dir = point - transform.position;
        float dist = Vector3.Distance(point, transform.position);
        while(dist > minTreshold)
        {
            transform.Translate(dir * Time.deltaTime * movementSpeed);
            dist = Vector3.Distance(point, transform.position);
            yield return null;
        }
        //trigger attack event when reach point
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        attackEvent.Invoke();
        yield return new WaitForSeconds(attackTime);
        StartCoroutine(GoToPoint(targets[RandomSelectPoint()].transform.position));
    }

    private int RandomSelectPoint()
    {
        int randIndex = Random.Range(0, targets.Length);
        //random again until int not same as last pick
        while(lastSelectedPoint == randIndex)
        {
            randIndex = Random.Range(0, targets.Length);
        }
        lastSelectedPoint = randIndex;
        return randIndex;
    }
}
