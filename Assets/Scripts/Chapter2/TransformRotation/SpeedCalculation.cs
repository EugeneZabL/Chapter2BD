using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SpeedCalculation : MonoBehaviour
{
    [SerializeField]
    Transform _obj;

    [SerializeField]
    TextMeshProUGUI _counterField, _speedField;

    float _tempRot;
    int _counter;
    float _currentYRotation;
    float _speed;

    private float lastTime; // время последнего обновления

    // Start is called before the first frame update
    void Start()
    {
        _tempRot = ConvertTo360();

        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        _currentYRotation = ConvertTo360();


        if (_tempRot > _currentYRotation)
        {
            _counter++;
            _speedField.text = CountSpeed();
        }
        _tempRot = _currentYRotation;

        _counterField.text = _counter.ToString();

    }

    string CountSpeed()
    {
        float deltaTime = Mathf.Round((1/(Time.time - lastTime))*60);

        lastTime = Time.time;

        return deltaTime.ToString();
    }

    float ConvertTo360()
    {
        float T = _obj.transform.eulerAngles.y;

        if (T < 0)
            return 360 + T;
        return T;
    }
}
