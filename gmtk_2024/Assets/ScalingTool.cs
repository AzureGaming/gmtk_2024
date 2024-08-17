using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingTool : MonoBehaviour {
    public static bool isCollecting;


    [SerializeField]
    public GameObject spriteMask;

    void Start() {

    }

    void Update() {
        isCollecting = Input.GetMouseButton(0);

        if (isCollecting) {
            Vector3 newPos = Input.mousePosition;
            newPos.z = 10f;
            //Instantiate(spriteMask, Camera.main.ScreenToWorldPoint(newPos), Quaternion.identity, GameObject.FindGameObjectWithTag("Creature").transform);
        }
    }
}
