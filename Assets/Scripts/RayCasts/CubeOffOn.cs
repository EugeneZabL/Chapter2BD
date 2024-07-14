using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOffOn : MonoBehaviour
{

    Renderer Color;

    // Start is called before the first frame update
    void Start()
    {
        Color = GetComponent<Renderer>();
    }

    public void ActivateTexture()
    {
        StartCoroutine(CalculateTimeForOn());
    }

    IEnumerator CalculateTimeForOn()
    {
        Color.material = Resources.Load("ColorON") as Material;

        yield return new WaitForSeconds(2);

        Color.material = Resources.Load("ColorOFF") as Material;
    }
}
