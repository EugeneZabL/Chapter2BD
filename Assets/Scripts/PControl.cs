using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PControl : MonoBehaviour
{
    [Range(0, 10)]
    public float RotateSpeed;

    [Range(0,10)]
    public float walkSpeed = 5f, runSpeed = 10f;


    private float _minYAngle = -90.0f; // Минимальный угол наклона камеры (вверх)
    private float _maxYAngle = 90.0f;  // Максимальный угол наклона камеры (вниз)

    private float _currentYRotation = 0.0f;

    private Camera cam;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraControll();
        MoveControll();
    }

    void CameraControll()
    {
        // Получаем текущий угол поворота по вертикали
        float mouseY = -Input.GetAxis("Mouse Y") * RotateSpeed;
        float mouseX = Input.GetAxis("Mouse X") * RotateSpeed;

        // Обновляем текущий угол по вертикали, но ограничиваем его
        _currentYRotation = Mathf.Clamp(_currentYRotation + mouseY, _minYAngle, _maxYAngle);

        // Применяем вращение по вертикали
        Quaternion verticalRotation = Quaternion.Euler(_currentYRotation, 0, 0);
        Quaternion horizontalRotation = Quaternion.Euler(0, mouseX, 0);

        // Обновляем вращение камеры
        cam.transform.localRotation = verticalRotation;
        cam.transform.parent.rotation *= horizontalRotation;
    }

    void MoveControll()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        characterController.Move(move * speed * Time.deltaTime);
    }
}
