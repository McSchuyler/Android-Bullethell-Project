using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSpinBehaviour : StateMachineBehaviour {

    public float rotationSpeed;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
