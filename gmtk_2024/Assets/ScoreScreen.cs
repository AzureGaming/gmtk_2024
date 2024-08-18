using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField]
    TMP_Text title;
    [SerializeField]
    TMP_Text scoreTitle;
    [SerializeField]
    TMP_Text scoreValue;
    [SerializeField]
    Button nextButton;

    // Start is called before the first frame update
    void Start()
    {
        title.gameObject.SetActive(false);
        scoreTitle.gameObject.SetActive(false);
        scoreValue.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        StartCoroutine(DisplayRoutine());
    }

    IEnumerator DisplayRoutine() {
        title.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        scoreTitle.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        scoreValue.text = GameManager.score.ToString();
        scoreValue.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
    }
}
