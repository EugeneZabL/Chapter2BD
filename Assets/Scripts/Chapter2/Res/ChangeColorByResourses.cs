using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorByResourses : MonoBehaviour
{
    Renderer Color;

    // Start is called before the first frame update
    void Start()
    {
        Color = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Color.material = Resources.Load("ColorON") as Material;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            Color.material = Resources.Load("ColorOFF") as Material;
        }
    }
}
