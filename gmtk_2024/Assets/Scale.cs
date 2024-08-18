using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {
    public delegate void OnCollect();
    public static event OnCollect onCollect;

    bool isTriggered;
    int health = 1;
    int currentHealth;
    SpriteRenderer spriteR;

    private void Awake() {
        spriteR = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        currentHealth = health;
    }

    private void Update() {
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }

        if (isTriggered && ScalingTool.isCollecting) {
            currentHealth -= 1;
            onCollect.Invoke();
        }

        Color startColor = spriteR.color;
        startColor.g = currentHealth / health;
        spriteR.color = startColor;
    }

    private void OnDestroy() {
        LevelManager.scaleCount -= 1;
        GameManager.score += 10;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isTriggered = false;
    }
}
