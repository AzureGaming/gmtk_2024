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

    void Update() {
        timer.text = GameManager.roundTimer.ToString();

        if (GameManager.roundState == Level_State.Done) {
            levelEnded.gameObject.SetActive(true);
        } else {
            levelEnded.gameObject.SetActive(false);
        }
    }

}
