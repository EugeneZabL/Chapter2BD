using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRayType : MonoBehaviour
{
    [Range(0, 5)]
    public int TypeButton;
    public void RayCasted()
    {
        switch(TypeButton)
        {
            case 0:
                GameObject.FindObjectOfType<PlayerRayCast>().GetComponent<PlayerRayCast>().TypeOfRay = 0 ;
                Debug.Log("Case 0");
                break;

            case 1:
                GameObject.FindObjectOfType<PlayerRayCast>().GetComponent<PlayerRayCast>().TypeOfRay = 1;
                Debug.Log("Case 1");
                break;

            case 2:
                GameObject.FindObjectOfType<PlayerRayCast>().GetComponent<PlayerRayCast>().TypeOfRay = 2;
                Debug.Log("Case 2");
                break;

            case 3:
                ChangeColor();
                break;

            case 4:
                break;

            case 5:
                break;

            default:
                break;

        }
    }

    void ChangeColor()
    {
        GetComponent<Renderer>().material.color =  new Color(
            Random.Range(0f, 1f), // R
            Random.Range(0f, 1f), // G
            Random.Range(0f, 1f)  // B
        );
    }
}
