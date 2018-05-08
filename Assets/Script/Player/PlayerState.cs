using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class playerStatEvent : UnityEvent<PlayerState.State>
{
}

public class PlayerState : MonoBehaviour {

    public playerStatEvent stateEvent;

	public enum State
    {
        normal,
        focus
    };

    private void Start()
    {
        if (stateEvent == null)
            stateEvent = new playerStatEvent();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleState(State.focus);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            ToggleState(State.normal);
        }
    }

    public void ToggleState(State state)
    {
        stateEvent.Invoke(state);
    }
}
