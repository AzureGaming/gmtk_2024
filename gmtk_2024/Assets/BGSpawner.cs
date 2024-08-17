using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject comet;
    [SerializeField]
    public GameObject fog1;
    [SerializeField]
    public GameObject fog2;
    [SerializeField]
    public GameObject fog3;

    public void Spawn() {
        Instantiate(GetPrefab(), transform.position, Quaternion.identity);
    }

    GameObject GetPrefab() {
        int randInt = Random.Range(0, 5);
        switch (randInt) {
            case 1: {
                return comet;
            }
            case 2: {
                return fog1;
            }
            case 3: {
                return fog2;
            }
            case 4: {
                return fog3;
            }
            default: {
                return comet;
            }
        }
    }
}
