using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2Manager : LevelManager {
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

    public void LoadNextLevel() {
        SceneManager.LoadScene("Level3");
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
        yield return StartCoroutine(creature.ToMiddleSlerpUp(3f, 10f));
        yield return StartCoroutine(creature.IdleJiggle(5f));
        yield return StartCoroutine(creature.MoveOffMiddleBottom(1f));
        creature.SetPosTopMiddle();
        yield return StartCoroutine(creature.ToMiddle(1f));
        yield return StartCoroutine(creature.IdleJiggle(2f));
        creature.LoadStage(2);
        yield return StartCoroutine(creature.TurnLeft());
        creature.LoadStage(1);
        yield return StartCoroutine(creature.IdleJiggle(2f));
        yield return StartCoroutine(creature.MoveOffLeft(5f));
        creature.SetPosRightMiddle();
        yield return StartCoroutine(creature.ToMiddle(5f));

        roundTimer = 0f;
    }
}
