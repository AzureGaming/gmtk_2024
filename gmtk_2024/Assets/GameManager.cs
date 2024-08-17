using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    public static float mousePosX;
    public static float mousePosY;
    public static bool isHurt;

    [SerializeField]
    public ParticleSystem blood;

    void Update() {
        Vector3 mousePos = Input.mousePosition;
        mousePosX = mousePos.x;
        mousePosY = mousePos.y;

        if (isHurt) {
            blood.Play();
        }
    }
}
