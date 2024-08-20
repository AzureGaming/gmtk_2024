using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : LevelManager
{
    Creature creature;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(RunLevel());
    }

    // Update is called once per frame
    void Update() {
        if (roundState == Level_State.In_Progress) {
            if (roundTimer > 0f) {
                roundTimer -= Time.deltaTime;
                if (scaleCount == 0) {
                    CompleteLevel();
                }
            } else {
                GameOver();
            }
        }
    }


    void CompleteLevel() {
        roundState = Level_State.Done;
        roundTimer = 0f;
    }

    void GameOver() {
        roundState = Level_State.Game_Over;
        roundTimer = 0f;
    }


    IEnumerator RunLevel() {
        roundTimer = 60f;
        creature = FindObjectOfType<Creature>();
        roundState = Level_State.In_Progress;

        yield return StartCoroutine(creature.MoveOffLeft(2f));
        creature.SetPosTopMiddle();
        yield return StartCoroutine(creature.MoveOffMiddleBottom(2f));
        //roundTimer = 0f;
    }
}
