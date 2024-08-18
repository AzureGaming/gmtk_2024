using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField]
    public GameObject description;
    [SerializeField]
    public Button tryAgainButton;

    private void Start() {
        //description.SetActive(false);
        //tryAgainButton.gameObject.SetActive(false);
    }
}
