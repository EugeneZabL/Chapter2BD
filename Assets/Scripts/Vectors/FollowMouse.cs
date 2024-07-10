using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    Transform MiniCat;

    
    private Vector3 ScreenCorrector;

    [HideInInspector]
    public Vector3 MousePositionScreen;


    float _normalizeDistance = 1;

    void Update()
    {
        CheckInput();
        ScreenCorrector = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        MousePositionScreen = Input.mousePosition - ScreenCorrector;

        MiniCat.position = MousePositionScreen.normalized * _normalizeDistance;
    }

    void CheckInput()
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta > 0f)
        {
            _normalizeDistance += 0.1f;
        }
        else if (scrollDelta < 0f)
        {
            _normalizeDistance -= 0.1f;
        }
    }
}
