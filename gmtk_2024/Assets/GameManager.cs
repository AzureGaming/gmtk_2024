using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    public static float mousePosX;
    public static float mousePosY;
    public static bool isHurt;
    public static int score;


    [SerializeField]
    public ParticleSystem blood;
    [SerializeField]
    public ParticleSystem scaleParticles;

    private void Start() {
        Cursor.visible = false;

        Scale.onCollect += () => {
            scaleParticles.Play();
        };
    }

    void Update() {
        Vector3 mousePos = Input.mousePosition;
        mousePosX = mousePos.x;
        mousePosY = mousePos.y;

        if (isHurt) {
            blood.Play();
        }
    }
}
