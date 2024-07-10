using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DistansCalculation : MonoBehaviour
{
    [SerializeField]
    Transform Floor;


    [SerializeField]
    TextMeshProUGUI DistantText;

    [SerializeField]
    Transform _playerBall;

    void FixedUpdate()
    {
        DistantText.text = Math.Round(transform.position.y - Floor.position.y, 2).ToString();
    }
}
