using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Level_State {
    Not_Started,
    In_Progress,
    Done,
}


public class LevelManager : MonoBehaviour {
    public static Level_State roundState = Level_State.Not_Started;
    public static float roundTimer;
    public static int scaleCount;
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

    GameObject spawnedObj;
    Vector3 startLocalScale;
    Color startColor;

    // Start is called before the first frame update
    void Start() {
        if (enableTutorial) {
            StartCoroutine(Tutorial());
        } else {
            StartCoroutine(LevelOne());
        }
    }

    // Update is called once per frame
    void Update() {

        if (roundState == Level_State.In_Progress) {
            if (roundTimer > 0f) {
                roundTimer -= Time.deltaTime;
                if (scaleCount == 0) {
                    EndLevel();
                }
            } else {
                EndLevel();
            }
        }

        if (roundState == Level_State.Done) {
            if (Input.GetMouseButtonDown(0)) {
                LevelOne();
            }
        }

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

    IEnumerator LevelOne() {
        roundState = Level_State.In_Progress;
        roundTimer = 60f;

        // todo: gt accurate dimensions
        spawnedObj = Instantiate(Level1, Camera.main.ViewportToWorldPoint(new Vector3(-2, 0.5f, 1f)), Quaternion.identity);
        scaleCount = FindObjectsOfType<Scale>().Length;
        startLocalScale = spawnedObj.transform.localScale;
        startColor = spawnedObj.GetComponent<SpriteRenderer>().color;

        yield return StartCoroutine(ToMiddle(2f));
        yield return StartCoroutine(GoToBackground(Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 0.75f, 1f))));
        yield return StartCoroutine(MoveOffRight(2));

        GameObject temp = Instantiate(Level1_2, Camera.main.ViewportToWorldPoint(new Vector3(3, 0.5f, 1f)), Quaternion.identity);
        Destroy(spawnedObj);
        spawnedObj = temp;

        yield return StartCoroutine(ToMiddle(2f));
    }


    void EndLevel() {
        roundState = Level_State.Done;
        roundTimer = 0f;
    }

    IEnumerator GoToBackground(Vector2 endPos) {
        Color newColor = spawnedObj.GetComponent<SpriteRenderer>().color;
        newColor.a = 0.5f;
        Vector2 newScale = new Vector2(5f, 5f);
        Vector2 startPos = transform.position;

        float timeElapsed = 0f;
        float time = 1f;
        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            spawnedObj.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, newColor, ( timeElapsed / time ));
            spawnedObj.transform.localScale = Vector2.Lerp(startLocalScale, newScale, ( timeElapsed / time ));
            spawnedObj.transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
    }

    IEnumerator LeftToRight() {
        float timeElapsed = 0f;
        // time should depend ons creen size
        float time = 5f;
        Vector2 startPos = spawnedObj.transform.position;
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(2, 0.5f));

        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            spawnedObj.transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
        spawnedObj.transform.position = endPos;
    }

    IEnumerator MoveOffRight(float time) {
        float timeElapsed = 0f;
        // time should depend ons creen size
        Vector2 startPos = spawnedObj.transform.position;
        Vector2 viewPortPos = Camera.main.WorldToViewportPoint(spawnedObj.transform.position);
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(3, viewPortPos.y));

        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            spawnedObj.transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
        spawnedObj.transform.position = endPos;
    }

    IEnumerator ToMiddle(float time) {
        float timeElapsed = 0f;
        // time should depend ons creen size
        Vector2 startPos = transform.position;
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));

        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            spawnedObj.transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
        spawnedObj.transform.position = endPos;
    }
}
