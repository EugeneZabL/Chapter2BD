using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
    [Range(0,4)]
    public int TypeOfRotation = 0;

    public float RotateSpeed = 60f;

    void FixedUpdate()
    {

        switch (TypeOfRotation)
        {
            case 0:
                YRotateByQuaternion();
                break;

            case 1:
                FullRotateByQuaternion();
                break;

            case 2:
                YRotateByEuler();
                break;

            case 3:
                FullRotateByEuler();
                break;
                
            default:
                Debug.LogError("NonType");
                break;

        }
    }

    void YRotateByQuaternion()
    {
        Quaternion target = Quaternion.Euler(0,transform.eulerAngles.y + 1 * RotateSpeed * 360f / 60f * Time.deltaTime, 0);

        //Quaternion target = new Quaternion(0,transform.rotation.y + 1 * RotateSpeed * 360f / 60f * Time.deltaTime, 0,0);

        transform.rotation = target;

    }

    void FullRotateByQuaternion()
    {
        // Вычисляем угол вращения на основе скорости и deltaTime
        float rotatio = 0.000000001f  * Time.deltaTime;

        // Создаем кватернион вращения
        Quaternion rotation = new Quaternion(rotatio, rotatio, rotatio, 0.000000001f);

        // Применяем вращение к текущему повороту объекта
        transform.rotation *= rotation;
    }


    Vector3 currentEulerAngles;
    
    void YRotateByEuler()
    {
        currentEulerAngles = new Vector3(0, transform.eulerAngles.y + 1 * RotateSpeed * 360f / 60f * Time.deltaTime, 0) ;

        transform.eulerAngles = currentEulerAngles;
    }

    void FullRotateByEuler()
    {
        // Вычисляем угол вращения на основе скорости и deltaTime
        float rot = RotateSpeed * Time.deltaTime;

        // Применяем вращение к объекту по осям X, Y и Z
        transform.Rotate(rot, rot, rot);
    }

}
