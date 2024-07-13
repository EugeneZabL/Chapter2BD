using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SettingSeria
{

   public float RColor, GColor, BColor;

    public void SetColor(Slider R, Slider G, Slider B)
    {
        RColor = R.value;
        GColor = G.value;
        BColor = B.value;

        Debug.Log("Save as - "+RColor + " // " + GColor + " // " + BColor);

    }

    public void ChangeColorAndSlider(ref Slider R, ref Slider G, ref Slider B, ref GameObject SomeObj)
    {
            R.value = RColor;
            G.value = GColor;
            B.value = BColor;

            Debug.Log("Load as - "+RColor+" // "+ GColor +" // "+ BColor);

            SomeObj.GetComponent<Renderer>().material.color = new Color(RColor, GColor, BColor) ;
    }
}
