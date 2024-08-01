using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalLoader : MonoBehaviour
{
    public string mainTextureAndMaterialBundlePath = "animal/maintextureandmaterial";
    public string deerBundlePath = "animal/deer";
    public string wolfBundlePath = "animal/dog";
    public string chickenBundlePath = "animal/chicken";

    private AssetBundle bundleMaterial;

    public Transform Pos1, Pos2, Pos3;

    private List<GameObject> objects = new List<GameObject>();

    private Material commonMaterial;

    public void LoadMaterialAndTexture()
    {
        StartCoroutine(LoadMainTextureAndMaterialBundle());
    }

    public void SpawnModelDog()
    {
        StartCoroutine(LoadAnimalBundle(wolfBundlePath, "Dog_001",Pos2));
    }
    public void SpawnModelChicken()
    {
        StartCoroutine(LoadAnimalBundle(chickenBundlePath, "Chicken_001",Pos3));
    }
    public void SpawnModelDeer()
    {
        StartCoroutine(LoadAnimalBundle(deerBundlePath, "Deer_001",Pos1));
    }

    public void ClearAllAssetBundls()
    {
        foreach (GameObject go in objects)
        {
            Destroy(go);
        }

        Resources.UnloadUnusedAssets();
    }

    public void ClearMaterial()
    {
        if(bundleMaterial!=null)
        {
            bundleMaterial.Unload(true);
        }
    }

    IEnumerator LoadMainTextureAndMaterialBundle()
    {
        if (commonMaterial==null)
        {
            string fullPath = System.IO.Path.Combine(Application.streamingAssetsPath, mainTextureAndMaterialBundlePath);
            AssetBundleCreateRequest bundleRequest = AssetBundle.LoadFromFileAsync(fullPath);
            yield return bundleRequest;

            AssetBundle bundle = bundleRequest.assetBundle;
            if (bundle != null)
            {
                Material[] materials = bundle.LoadAllAssets<Material>();
                if (materials.Length > 0)
                {
                    commonMaterial = materials[0];
                }
                Debug.Log("Material is load");
                bundleMaterial = bundle;
            }
            else
            {
                Debug.LogError("Failed to load main texture and material bundle!");
            }
        }
    }

    IEnumerator LoadAnimalBundle(string bundlePath, string prefabName, Transform transformPos)
    {
            string fullPath = System.IO.Path.Combine(Application.streamingAssetsPath, bundlePath);
            AssetBundleCreateRequest bundleRequest = AssetBundle.LoadFromFileAsync(fullPath);
            yield return bundleRequest;

            AssetBundle bundle = bundleRequest.assetBundle;
            if (bundle != null)
            {
                GameObject prefab = bundle.LoadAsset<GameObject>(prefabName);
                if (prefab != null)
                {
                    GameObject inits = Instantiate(prefab);
                    inits.transform.position = transformPos.position;
                    inits.transform.rotation = transformPos.rotation;
                    objects.Add(inits);
                }
            bundle.Unload(false);
            }
            else
            {
                Debug.LogError("Failed to load animal bundle: " + bundlePath);
            }
    }

    void ApplyCommonMaterial(GameObject animal)
    {
        Renderer[] renderers = animal.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.sharedMaterial = commonMaterial;
        }
    }
}
