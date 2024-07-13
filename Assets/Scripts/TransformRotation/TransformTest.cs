using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
    [Range(0,1)]
    public int TypeOfRotation = 0;

    public float RotateSpeed = 60f;

    void Update()
    {

        switch (TypeOfRotation)
        {
            case 0:
                RotateByQuaternion();
                break;

            case 1:
                RotateByEuler();
                break;
                
            default:
                Debug.LogError("NonType");
                break;

        }
    }

    void RotateByQuaternion()
    {
        Quaternion target = Quaternion.Euler(0,transform.eulerAngles.y + 1 * RotateSpeed * 360f / 60f * Time.deltaTime, 0);

        //Quaternion target = new Quaternion(0,transform.rotation.y + 1 * RotateSpeed * 360f / 60f * Time.deltaTime, 0,0);

        transform.rotation = target;

    }

    Vector3 currentEulerAngles;
    
    void RotateByEuler()
    {
        currentEulerAngles = new Vector3(0, transform.eulerAngles.y + 1 * RotateSpeed * 360f / 60f * Time.deltaTime, 0) ;

        transform.eulerAngles = currentEulerAngles;
    }

}
