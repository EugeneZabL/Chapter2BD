using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DistansCalculation : MonoBehaviour
{

    int _bounceCounter;

    [SerializeField]
    Transform Floor;


    [SerializeField]
    TextMeshProUGUI DistantText,BounceCounterText;

    [SerializeField]
    Transform _playerBall;

    void FixedUpdate()
    {
        DistantText.text = Math.Round(transform.position.y - Floor.position.y, 2).ToString();
        BounceCounterText.text = _bounceCounter.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _bounceCounter++;
    }
}
