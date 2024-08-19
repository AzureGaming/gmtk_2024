using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {
    [SerializeField]
    List<GameObject> stages;

    Animator anim;
    SpriteRenderer spriteR;

    int currentStage = 0;
    Vector2 startScale;
    Color startColor;

    private void Awake() {
        anim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        LevelManager.scaleCount = GetComponentsInChildren<Scale>(true).Length;

        startScale = transform.localScale;
        startColor = spriteR.color;

    }

    public void LoadNextStage() {
        currentStage++;
        stages[currentStage].gameObject.SetActive(true);
    }

    public void LoadStage(int stage) {
        for (int i = 0; i < stages.Count; i++) {
            stages[i].SetActive(i == stage);
        }
    }

    public void Flip() {
        spriteR.flipX = !spriteR.flipX;
    }

    public IEnumerator MoveOffLeft(float time) {
        float timeElapsed = 0f;
        Vector2 startPos = transform.position;
        Vector2 viewPortPos = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(-1.5f, viewPortPos.y));

        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
        transform.position = endPos;
    }


    public IEnumerator MoveOffRight(float time) {
        float timeElapsed = 0f;
        // time should depend ons creen size
        Vector2 startPos = transform.position;
        Vector2 viewPortPos = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(1.5f, viewPortPos.y));

        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
        transform.position = endPos;
    }

    public IEnumerator SmokeBreak(float time) {
        float timeElapsed = 0f;
        anim.SetBool("isSmoking", true);
        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        anim.SetBool("isSmoking", false);
    }



   public IEnumerator ToMiddle(float time) {
        float timeElapsed = 0f;
        // time should depend ons creen size
        Vector2 startPos = transform.position;
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));

        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }
        transform.position = endPos;
    }


    public IEnumerator GoToBackground(float time) {
        Color newColor = spriteR.color;
        newColor.a = 0.5f;
        Vector2 newScale = new Vector2(5f, 5f);
        Vector2 startPos = transform.position;
        Vector2 viewPortPos = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(viewPortPos.x, 0.75f));

        anim.SetBool("isMovingBack", true);

        float timeElapsed = 0f;
        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            spriteR.color = Color.Lerp(startColor, newColor, ( timeElapsed / time ));
            transform.localScale = Vector2.Lerp(startScale, newScale, ( timeElapsed / time ));
            transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }

        anim.SetBool("isMovingBack", false);
    }

    public IEnumerator GoToForeground(float time) {
        Color newColor = spriteR.color;
        newColor.a = 1f;
        Vector2 currentScale = transform.localScale;
        Vector2 startPos = transform.position;
        Vector2 endPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));

        anim.SetBool("isMovingForward", true);

        float timeElapsed = 0f;
        while (timeElapsed < time) {
            timeElapsed += Time.deltaTime;
            spriteR.color = Color.Lerp(startColor, newColor, ( timeElapsed / time ));
            transform.localScale = Vector2.Lerp(currentScale, startScale, ( timeElapsed / time ));
            transform.position = Vector2.Lerp(startPos, endPos, ( timeElapsed / time ));
            yield return null;
        }

        anim.SetBool("isMovingForward", false);
    }
}
