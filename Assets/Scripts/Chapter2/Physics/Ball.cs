using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    Rigidbody _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(PhizikMove());
    }

    IEnumerator PhizikMove()
    {
        while(true)
        {
            _rb.AddForce(new Vector3(Random.Range(-10,10), Random.Range(-10, 10), Random.Range(-10, 10)), ForceMode.Impulse);
            yield return new WaitForSeconds(4);
        }
        
    }
}
