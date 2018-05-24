using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerInputEvent : UnityEvent
{

}

public class PlayerInput : MonoBehaviour {

    public PlayerInputEvent holdShootEvent;
    public PlayerInputEvent releaseShootEvent;

    private void Start()
    {
        if(holdShootEvent == null)
            holdShootEvent = new PlayerInputEvent();
        if (releaseShootEvent == null)
            releaseShootEvent = new PlayerInputEvent();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            holdShootEvent.Invoke();
        }
        if(Input.GetKeyUp(KeyCode.Z))
        {
            releaseShootEvent.Invoke();
        }
    }
}
