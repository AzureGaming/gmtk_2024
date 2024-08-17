using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public TMP_Text timer; 
    [SerializeField]
    public TMP_Text levelEnded;
    [SerializeField]
    public TMP_Text scaleCount;

    void Update() {
        timer.text = LevelManager.roundTimer.ToString();
        scaleCount.text = LevelManager.scaleCount.ToString();

        if (LevelManager.roundState == Level_State.Done) {
            levelEnded.gameObject.SetActive(true);
        } else {
            levelEnded.gameObject.SetActive(false);
        }
    }

}
