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
    [SerializeField]
    public GameObject Level1;
    [SerializeField]
    public GameObject Level1_2;
    [SerializeField]
    public GameObject tutorialFish1;
    [SerializeField]
    public Transform tutorialStartPos;

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
        roundTimer = 30f;

        // todo: gt accurate dimensions
        creature = Instantiate(Level1, Camera.main.ViewportToWorldPoint(new Vector3(-0.5f, 0.5f, 1f)), Quaternion.identity).GetComponent<Creature>();

        yield return StartCoroutine(creature.MoveOffRight(10f));
        creature.Flip();
        creature.LoadStage(1);
        yield return StartCoroutine(creature.MoveOffLeft(10f));
        creature.Flip();
        creature.LoadStage(0);
        yield return StartCoroutine(creature.MoveOffRight(10f));

        //roundTimer = 0f;
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

    //IEnumerator GoToForeground(float time, GameObject obj) {
    //    Color newColor = obj.GetComponent<SpriteRenderer>().color;
    //    newColor.a = 1f;
    //    Color currentColor = obj.GetComponent<SpriteRenderer>().color;
    //    Vector2 startPos = transform.position;
    //    Vector2 startScale = transform.localScale;
    //    Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));

    //    objPool[0].GetComponent<Animator>().SetFloat("movementY", -1);

    //    float timeElapsed = 0f;
    //    while (timeElapsed < time) {
    //        timeElapsed += Time.deltaTime;
    //        obj.GetComponent<SpriteRenderer>().color = Color.Lerp(currentColor, newColor, ( timeElapsed / time ));
    //        obj.transform.localScale = Vector2.Lerp(startScale, startLocalScale, ( timeElapsed / time ));
    //        obj.transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
    //        yield return null;
    //    }

    //    objPool[0].GetComponent<Animator>().SetFloat("movementY", 0);
    //}


}
