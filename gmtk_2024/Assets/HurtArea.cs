using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtArea : MonoBehaviour {
    bool isTriggered;

    private void Update() {
        if (isTriggered && ScalingTool.isCollecting) {
            GameManager.isHurt = true;
        } else {
            GameManager.isHurt = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isTriggered = false;
    }
}
