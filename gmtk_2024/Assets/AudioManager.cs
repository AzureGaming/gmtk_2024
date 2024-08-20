using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField]
    public List<AudioSource> scaling;

    float minTimeBetweenScale = 0.1f;
    float maxTimeBetweenScale = 0.3f;
    float timeSinceLastScale;

    public void PlayScaling() {
        int rand = Random.Range(0, scaling.Count);
        if (Time.time - timeSinceLastScale >= Random.Range(minTimeBetweenScale, maxTimeBetweenScale)) {
            scaling[rand].Play();
            timeSinceLastScale = Time.time;
        }
    }
}
