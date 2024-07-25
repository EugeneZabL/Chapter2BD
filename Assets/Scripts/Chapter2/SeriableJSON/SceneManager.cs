using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SceneManager : MonoBehaviour
{

    [SerializeField]
    Slider RSlider, GSlider, BSlider;

    [SerializeField]
    GameObject Cube;

    SettingSeria SettingSeri;

    string filePath;


    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "Seri.json");

        SettingSeri = new SettingSeria();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Cube.GetComponent<Renderer>().material.color = new Color(
        RSlider.value, // R
        GSlider.value, // G
        BSlider.value  // B
        );
    }

    public void ButtonSave()
    {
        SettingSeri.SetColor(RSlider, GSlider, BSlider);
        
        string json = JsonUtility.ToJson(SettingSeri, true);

        File.WriteAllText(filePath, json);
    }

    public void ButtonLoad()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            SettingSeri = JsonUtility.FromJson<SettingSeria>(json);

            Debug.Log(SettingSeri.RColor);

            SettingSeri.ChangeColorAndSlider(ref RSlider, ref GSlider, ref BSlider, ref Cube);
        }
        else
            Debug.LogError("Немає файлу!");


        
    }

}
