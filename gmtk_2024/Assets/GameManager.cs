using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float mousePosX;
    public static float mousePosY;
    public static bool canCollect;


    void Update()
    {
        canCollect = Input.GetMouseButton(0);

        Vector3 mousePos = Input.mousePosition;
        mousePosX = mousePos.x;
        mousePosY = mousePos.y;
    }
}
