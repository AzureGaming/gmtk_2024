using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {
    bool isTriggered;
    int health = 100;
    SpriteRenderer spriteR;

    private void Awake() {
        spriteR = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (health <= 0) {
            Destroy(gameObject);
        }

        if (isTriggered && ScalingTool.isCollecting) {
            health -= 1;
        }
    }

    private void OnDestroy() {
        GameManager.scaleCount -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isTriggered = false;
    }
}
