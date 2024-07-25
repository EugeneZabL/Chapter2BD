using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConterStatic : MonoBehaviour
{
    ActivatorCheck Cker;
    void Start()
    {
        Cker = GameObject.FindFirstObjectByType<ActivatorCheck>().GetComponent<ActivatorCheck>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Cker.ActivateSomething();
    }
}
