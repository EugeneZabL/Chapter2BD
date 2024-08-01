using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UAASTest : MonoBehaviour
{
    [SerializeField]
    AssetReferenceGameObject assetRef;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Addressables.BuildPath);
        Debug.Log(Addressables.BuildReportPath);
        Debug.Log(Addressables.RuntimePath);
        Debug.Log(Addressables.PlayerBuildDataPath);
        Debug.Log(Addressables.LibraryPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
