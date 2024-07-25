using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorCheck : MonoBehaviour
{

    [SerializeField]
    AudioSource AudioS;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y >= -500)
            transform.position+= new Vector3(0,-2,0);
    }

    public void ActivateSomething()
    {
        transform.localPosition = new Vector3(450, -150, 0);
        AudioS.Play();
    }
}
