using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.x += 0.001f;
        transform.position = newPos; 
    }
}
