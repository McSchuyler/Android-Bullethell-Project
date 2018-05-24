using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    public ProjectileSpawner mainShooter;
    public ProjectileSpawner secondaryShooter;

    private PlayerInput playerInput;

    public void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        playerInput.holdShootEvent.AddListener(mainShooter.StartAuto);
        playerInput.releaseShootEvent.AddListener(mainShooter.StopAuto);
    }

    public void ToggleShooter(PlayerState.State state)
    {
        if(state == PlayerState.State.normal)
        {
            mainShooter.gameObject.SetActive(true);
            secondaryShooter.gameObject.SetActive(false);
            AssignInputListener(mainShooter, secondaryShooter);
            //swap from focus to main if holding z while swapping
            if(Input.GetKey(KeyCode.Z))
            {
                mainShooter.StartAuto();
            }
        }
        else if(state == PlayerState.State.focus)
        {
            mainShooter.gameObject.SetActive(false);
            secondaryShooter.gameObject.SetActive(true);
            AssignInputListener(secondaryShooter, mainShooter);
            //swap from main to focus if holding z while swapping
            if (Input.GetKey(KeyCode.Z))
            {
                secondaryShooter.StartAuto();
            }
        }
    }

    private void AssignInputListener(ProjectileSpawner add, ProjectileSpawner remove)
    {
        //remove "remove" from input evnet listner
        playerInput.holdShootEvent.RemoveListener(remove.StartAuto);
        playerInput.releaseShootEvent.RemoveListener(remove.StopAuto);
        //add "add" from input event listner
        playerInput.holdShootEvent.AddListener(add.StartAuto);
        playerInput.releaseShootEvent.AddListener(add.StopAuto);
    }
}
