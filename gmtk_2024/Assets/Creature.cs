using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField]
    List<GameObject> stages;

    int currentStage = 0; 

    public void LoadNextStage() {
        currentStage++;
        stages[currentStage].gameObject.SetActive(true);
    }
}
