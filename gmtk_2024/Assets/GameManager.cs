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
    public static bool canCollect;
    public static float roundTimer;
    public static Level_State roundState = Level_State.Not_Started;

    private void Start() {
        LevelOne();
    }

    void Update() {
        canCollect = Input.GetMouseButton(0);

        Vector3 mousePos = Input.mousePosition;
        mousePosX = mousePos.x;
        mousePosY = mousePos.y;

        if (roundState == Level_State.In_Progress) {
            if (roundTimer > 0f) {
                roundTimer -= Time.deltaTime;
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
        roundTimer = 5f;
    }

    void EndLevel() {
        roundTimer = 0f;
        roundState = Level_State.Done;
    }
}
