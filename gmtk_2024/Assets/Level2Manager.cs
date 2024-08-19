using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level2Manager : LevelManager {

    [SerializeField]
    public GameObject Level1;
    bool afterStart;

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
        //StopAllCoroutines();
        //Destroy(creature.gameObject);
        roundState = Level_State.Done;
        roundTimer = 0f;
    }

    void GameOver() {

        //StopAllCoroutines();
        //Destroy(creature.gameObject);
        roundState = Level_State.Game_Over;
        roundTimer = 0f;
    }


    IEnumerator RunLevel() {
        roundTimer = 30f;
        creature = FindObjectOfType<Creature>();
        roundState = Level_State.In_Progress;
        yield return StartCoroutine(creature.ToMiddle(5f));
    }
}
