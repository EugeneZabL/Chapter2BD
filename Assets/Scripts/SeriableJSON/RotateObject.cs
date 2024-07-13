using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10f; // Скорость вращения по оси Y

    void Update()
    {
        // Получаем текущий угол вращения по оси Y
        float yRotation = transform.eulerAngles.y + rotationSpeed * Time.deltaTime;

        // Устанавливаем новый поворот объекта
        transform.eulerAngles = new Vector3(-15, yRotation, -15);
    }
}
