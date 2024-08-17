using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    bool isTriggered;

    private void Update() {
        if (isTriggered && GameManager.canCollect) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isTriggered = false;
    }
}
