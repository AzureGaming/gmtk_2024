using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Level_State {
    Not_Started,
    In_Progress,
    Done,
}


public class GameManager : MonoBehaviour {
    public static float mousePosX;
    public static float mousePosY;
    public static float roundTimer;
    public static Level_State roundState = Level_State.Not_Started;
    public static int scaleCount;

    [SerializeField]
    public GameObject Level1;

    private void Start() {
        LevelOne();
    }

    void Update() {
        Vector3 mousePos = Input.mousePosition;
        mousePosX = mousePos.x;
        mousePosY = mousePos.y;

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

    void LevelOne() {
        roundState = Level_State.In_Progress;
        roundTimer = 60f;
        Instantiate(Level1, new Vector2(0, 0), Quaternion.identity);
        scaleCount = FindObjectsOfType<Scale>().Length;
    }

    void EndLevel() {
        roundState = Level_State.Done;
        roundTimer = 0f;
    }
}
