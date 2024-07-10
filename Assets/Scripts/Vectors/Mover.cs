using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveCatSpeed = 1f;  
    public float movePointSpeed = 2f;

    [SerializeField]
    private Transform _point;


    void Update()
    {
        PointControl();
        Vector2 move = new Vector2(_point.position.x, _point.position.y) - new Vector2(transform.position.x,transform.position.y);
        transform.Translate(move.normalized * moveCatSpeed * Time.deltaTime);
    }

    void PointControl()
    {
        float VecX = Input.GetAxis("Horizontal") * movePointSpeed;
        float VexY = Input.GetAxis("Vertical") * movePointSpeed;

        _point.transform.Translate(new Vector2(VecX,VexY) * moveCatSpeed * Time.deltaTime);
    }
}
