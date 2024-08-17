using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move() {
        Vector2 startPos = transform.position;
        Vector2 midPos = new Vector2(0, 0);
        float elapsedTime = 0f;
        float time = 1f;

        while (elapsedTime < time) {
            transform.position = Vector2.Lerp(startPos, midPos, ( elapsedTime / time ));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0;
        transform.position = midPos;

        yield return new WaitUntil(() => GetComponentsInChildren<Scale>().Length <= 0);

        startPos = transform.position;
        Vector2 endPos = new Vector2(10, 0);
        while (elapsedTime < time) {
            transform.position = Vector2.Lerp(startPos, endPos, ( elapsedTime / time ));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
