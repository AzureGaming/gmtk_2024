using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    public static float mousePosX;
    public static float mousePosY;
    public static bool isHurt;
    public static int score;


     ParticleSystem blood;
     ParticleSystem scaleParticles;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        Cursor.visible = false;
        blood = GameObject.FindGameObjectWithTag("blood").GetComponent<ParticleSystem>();
        scaleParticles = GameObject.FindGameObjectWithTag("scaleParticles").GetComponent<ParticleSystem>();

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
