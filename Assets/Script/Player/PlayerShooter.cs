using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    public GameObject mainShooter;
    public GameObject secondaryShooter;

    public void ToggleShooter(PlayerState.State state)
    {
        if(state == PlayerState.State.normal)
        {
            mainShooter.SetActive(true);
            secondaryShooter.SetActive(false);
        }
        else if(state == PlayerState.State.focus)
        {
            mainShooter.SetActive(false);
            secondaryShooter.SetActive(true);
        }
    }
}
