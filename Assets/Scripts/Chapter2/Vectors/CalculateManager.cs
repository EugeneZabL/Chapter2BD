using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalculateManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _mainVec, _miniCatVec, _distantVec,_mouseVec;

    [SerializeField]
    private Transform _main, _miniCat;

    private FollowMouse FMScript;
    // Start is called before the first frame update
    void Start()
    {
        FMScript = GameObject.FindFirstObjectByType<FollowMouse>().GetComponent<FollowMouse>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _mainVec.text = _main.position.ToString();
        _miniCatVec.text = _miniCat.position.ToString();
        _distantVec.text = Vector3.Distance(_main.position,_miniCat.position).ToString();
        _mouseVec.text = FMScript.MousePositionScreen.ToString();
    }
}
