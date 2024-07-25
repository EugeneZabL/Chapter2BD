using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSceneManager : MonoBehaviour
{
    public delegate void MyDelegate();

    public event MyDelegate OnNotify;

    public MyDelegate? del;

    public UnityEvent m_MyEvent;

    [SerializeField]
    List<CubeOffOn> _listOfCubeDel;

    [SerializeField]
    List<CubeOffOn> _listOfCubeEven;
    // Start is called before the first frame update
    void Start()
    {
        foreach (CubeOffOn cube in _listOfCubeDel)
        {
            del += new MyDelegate(cube.ActivateTexture);
            
        }

        foreach (CubeOffOn cube in _listOfCubeEven)
        {
            OnNotify += new MyDelegate(cube.ActivateTexture);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            del.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnNotify.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_MyEvent.Invoke();
        }
    }
}

