using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    [HideInInspector]
    public int TypeOfRay = 0;

    [SerializeField]
    private Camera _camera;

    private LineRenderer _laserLine;
    // Start is called before the first frame update
    void Start()
    {
        _laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MDrawRayDebug();
        _laserLine.SetPosition(0, transform.position);
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_laserLine.enabled)
        {
            _laserLine.SetPosition(1, _camera.transform.position + (_camera.transform.forward * 10f));
            StartCoroutine(ShotEffect());
            MRayCast();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            MShapeCast();
        }
    }

    void MShapeCast()
    {
        RaycastHit[] hit = Physics.SphereCastAll(_camera.transform.position,2f,_camera.transform.forward,3f);
        int countOfBox = 0;
        foreach(RaycastHit hittble in hit)
        {
            if(hittble.transform.GetComponent<CubeOffOn>() != null)
            {
                hittble.transform.GetComponent<CubeOffOn>().ActivateTexture();
                countOfBox++;
            }
        }
        Debug.Log("Box in ray  " + countOfBox);
    }

    void MRayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 10f))
        {
            if(hit.transform.GetComponent<ButtonRayType>() != null)
                hit.transform.GetComponent<ButtonRayType>().RayCasted();
            _laserLine.SetPosition(1, _camera.transform.position + (_camera.transform.forward * hit.distance));
        }
    }

    void MDrawRayDebug()
    {
        switch(TypeOfRay)
        {
            case 1:
                Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 10f, Color.green);
                break;

            case 2:
                Debug.DrawLine(_camera.transform.position, _camera.transform.position + _camera.transform.forward * 10, Color.red);
                break;

            default:
                break;
        }

         
    }


    private IEnumerator ShotEffect()
    {
        // Turn on our line renderer
        _laserLine.enabled = true;

        //Wait for .07 seconds
        yield return new WaitForSeconds(0.1f) ;

        _laserLine.enabled = false;
    }
}
