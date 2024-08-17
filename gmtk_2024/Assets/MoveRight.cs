using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    [SerializeField]
    public float speed = 1f;
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.x += 1f;
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
