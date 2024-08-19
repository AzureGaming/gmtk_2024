using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtArea : MonoBehaviour {
    [SerializeField]
    public SpriteRenderer spriteR;
    SpriteRenderer selfSpriteR;
    bool isTriggered;
    Color startColor;
    Color selfStartColor;

    private void Awake() {
        selfSpriteR = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        startColor = spriteR.color;
        selfStartColor = selfSpriteR.color;
    }

    private void Update() {
        if (isTriggered && ScalingTool.isCollecting) {
            GameManager.isHurt = true;
            FindObjectOfType<Creature>().GetComponent<Animator>().SetBool("isHurt", true);
            spriteR.color = Color.red;
            selfSpriteR.color = Color.red;
        } else {
            GameManager.isHurt = false;
            spriteR.color = startColor;
            selfSpriteR.color = selfStartColor;
            FindObjectOfType<Creature>().GetComponent<Animator>().SetBool("isHurt", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isTriggered = false;
    }
}
