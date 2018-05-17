using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageEvent : MonoBehaviour
{
    [System.Serializable]
    public class Phase
    {
        public GameObject[] gameObjects;
    }

    public Phase[] phases;

    public void StartPhase(int phaseIndex)
    {
        for(int i =0; i<phases[phaseIndex].gameObjects.Length; i++)
        {
            phases[phaseIndex].gameObjects[i].SetActive(true);
        }
    }

}
