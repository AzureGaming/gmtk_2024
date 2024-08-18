using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    [SerializeField]
    public TMP_Text timer;
    [SerializeField]
    public GameObject scoreScreen;
    [SerializeField]
    public GameObject loseScreen;
    [SerializeField]
    public TMP_Text scaleCount;

    void Update() {
        timer.text = LevelManager.roundTimer.ToString();
        scaleCount.text = LevelManager.scaleCount.ToString();

        if (LevelManager.roundState == Level_State.Done) {
            scoreScreen.SetActive(true);
        } else if (LevelManager.roundState == Level_State.Game_Over) {
            loseScreen.SetActive(true);
        } else {
            scoreScreen.SetActive(false);
            loseScreen.SetActive(false);
        }
    }
}
