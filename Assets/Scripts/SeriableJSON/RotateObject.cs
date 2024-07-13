using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10f; // �������� �������� �� ��� Y

    void Update()
    {
        // �������� ������� ���� �������� �� ��� Y
        float yRotation = transform.eulerAngles.y + rotationSpeed * Time.deltaTime;

        // ������������� ����� ������� �������
        transform.eulerAngles = new Vector3(-15, yRotation, -15);
    }
}
