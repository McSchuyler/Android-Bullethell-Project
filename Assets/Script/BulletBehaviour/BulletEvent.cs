using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventForBullet : UnityEvent<Vector3,Quaternion>
{
}



public class BulletEvent : MonoBehaviour {

    public EventForBullet startEvent;
    public EventForBullet endEvent;

    public bool triggerOnCreated = false;
    private bool firstTimeTriggered = false;

    private void Awake()
    {
        if(startEvent == null)
        {
            startEvent = new EventForBullet();
        }

        if(endEvent == null)
        {
            endEvent = new EventForBullet();
        }
    }

    private void OnEnable()
    {
        if(triggerOnCreated == true)
            startEvent.Invoke(transform.position, transform.rotation);
        else if(firstTimeTriggered == true)
            startEvent.Invoke(transform.position, transform.rotation);
    }

    private void OnDisable()
    {
        if(triggerOnCreated == true)
            endEvent.Invoke(transform.position,transform.rotation);
        else if(firstTimeTriggered == true)
            endEvent.Invoke(transform.position, transform.rotation);

        firstTimeTriggered = true;
    }
}
