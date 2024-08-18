using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingTool : MonoBehaviour {
    public static bool isCollecting;

    void Update() {
        isCollecting = Input.GetMouseButton(0);
    }
}
