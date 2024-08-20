using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Level_State {
    Not_Started,
    In_Progress,
    Done,
    Game_Over
}

public enum Level {
    Zero,
    One,
    Two,
}


public class Level1Manager: LevelManager {
    [SerializeField]
    public bool enableTutorial;

    Creature creature;

    // Start is called before the first frame update
    void Start() {
        if (enableTutorial) {
            StartCoroutine(Tutorial());
        } else {
            StartCoroutine(RunLevel());
        }
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
        SceneManager.LoadScene("Level2");
    }

    IEnumerator Tutorial() {
        Vector2 startPos = transform.position;
        Vector2 midPos = new Vector2(0, 0);
        float elapsedTime = 0f;
        float time = 1f;

        while (elapsedTime < time) {
            transform.position = Vector2.Lerp(startPos, midPos, ( elapsedTime / time ));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0;
        transform.position = midPos;

        yield return new WaitUntil(() => GetComponentsInChildren<Scale>().Length <= 0);

        startPos = transform.position;
        Vector2 endPos = new Vector2(10, 0);
        while (elapsedTime < time) {
            transform.position = Vector2.Lerp(startPos, endPos, ( elapsedTime / time ));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator RunLevel() {
        roundState = Level_State.In_Progress;
        roundTimer = 60f;

        // todo: gt accurate dimensions
        creature = FindObjectOfType<Creature>();

        yield return StartCoroutine(creature.ToMiddle(5f));
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(creature.MoveOffRight(5f));
        creature.Flip();
        creature.LoadStage(1);
        yield return StartCoroutine(creature.ToMiddle(5f));
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(creature.MoveOffLeft(5f));

        roundTimer = 0f;
    }


    void CompleteLevel() {
        roundState = Level_State.Done;
        roundTimer = 0f;
    }

    void GameOver() {
        roundState = Level_State.Game_Over;
        roundTimer = 0f;
    }
}
