using System.Collections;
using System.Collections.Generic;
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

    List<GameObject> objPool;
    Vector3 startLocalScale;
    Color startColor;

    private void Awake() {
        objPool = new List<GameObject>();
    }

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
    }

    public void LoadNextLevel() {
        StartCoroutine(LevelOne());
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
        objPool.Add(Instantiate(Level1, Camera.main.ViewportToWorldPoint(new Vector3(-2, 0.5f, 1f)), Quaternion.identity));
        objPool.Add(Instantiate(Level1_2, Camera.main.ViewportToWorldPoint(new Vector3(2, 0.5f, 1f)), Quaternion.identity));
        scaleCount = FindObjectsOfType<Scale>().Length;
        startLocalScale = objPool[0].transform.localScale;
        startColor = objPool[0].GetComponent<SpriteRenderer>().color;

        yield return StartCoroutine(MoveOffRight(5f,objPool[0]));
        yield return StartCoroutine(MoveOffLeft(5f, objPool[1]));
        objPool[0].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(-2, 0.5f, 1f));
        yield return StartCoroutine(MoveOffRight(5f, objPool[0]));

        roundTimer = 0f;
        //yield return StartCoroutine(GoToBackground(Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 0.75f, 1f))));
    }


    void EndLevel() {
        roundState = Level_State.Done;
        roundTimer = 0f;
        ClearPool();
    }

    IEnumerator GoToBackground(Vector2 endPos, GameObject obj) {
        Color newColor = obj.GetComponent<SpriteRenderer>().color;
        newColor.a = 0.5f;
        Vector2 newScale = new Vector2(5f, 5f);
        Vector2 startPos = transform.position;

        float timeElapsed = 0f;
        float time = 1f;
        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            obj.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, newColor, ( timeElapsed / time ));
            obj.transform.localScale = Vector2.Lerp(startLocalScale, newScale, ( timeElapsed / time ));
            obj.transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
    }

    IEnumerator LeftToRight() {
        float timeElapsed = 0f;
        // time should depend ons creen size
        float time = 5f;
        Vector2 startPos = objPool[0].transform.position;
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(2, 0.5f));

        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            objPool[0].transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
        objPool[0].transform.position = endPos;
    }

    IEnumerator MoveOffRight(float time, GameObject obj) {
        float timeElapsed = 0f;
        // time should depend ons creen size
        Vector2 startPos = obj.transform.position;
        Vector2 viewPortPos = Camera.main.WorldToViewportPoint(obj.transform.position);
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(3, viewPortPos.y));

        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            obj.transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
        obj.transform.position = endPos;
    }

    IEnumerator MoveOffLeft(float time, GameObject obj) {
        float timeElapsed = 0f;
        // time should depend ons creen size
        Vector2 startPos = obj.transform.position;
        Vector2 viewPortPos = Camera.main.WorldToViewportPoint(obj.transform.position);
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(-3, viewPortPos.y));

        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            obj.transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
        obj.transform.position = endPos;
    }

    IEnumerator ToMiddle(float time) {
        float timeElapsed = 0f;
        // time should depend ons creen size
        Vector2 startPos = transform.position;
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));

        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            objPool[0].transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
        objPool[0].transform.position = endPos;
    }

    void ClearPool() {
        foreach(GameObject obj in objPool) {
            Destroy(obj);
        }

        objPool.Clear();
    }
}
