using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BaseUAASTest : MonoBehaviour
{
    public AssetReferenceGameObject dog, chicken, deer, Dragon;

    public Transform Pos1, Pos2, Pos3, Pos4;

    private GameObject GOdog, GOchicken, GOdeer, GODragon;

    public void SpawnModelDog()
    {
        if(GOdog==null)
            dog.InstantiateAsync(Pos2.position,Pos2.rotation).Completed += (AsyncOperationHandle<GameObject> obj) =>  GOdog = obj.Result;
    }

    public void SpawnModelChicken()
    {
        if (GOchicken == null)
            chicken.InstantiateAsync(Pos3.position, Pos3.rotation).Completed += (AsyncOperationHandle<GameObject> obj) => GOchicken = obj.Result;
    }
    public void SpawnModelDeer()
    {
        if (GOdeer == null)
            deer.InstantiateAsync(Pos1.position, Pos1.rotation).Completed += (AsyncOperationHandle<GameObject> obj) => GOdeer = obj.Result;
    }

    public void SpawnModelDragon()
    {
        if (GODragon == null)
            Dragon.InstantiateAsync(Pos4.position, Pos4.rotation).Completed += (AsyncOperationHandle<GameObject> obj) => { GODragon = obj.Result; obj.Result.transform.localScale = Pos4.localScale; };
    }

    public void ClearAllAssetBundls()
    {
        if (GOdog != null)
        {
            dog.ReleaseInstance(GOdog);
            GOdog = null;
        }
        if (GOchicken != null)
        {
            chicken.ReleaseInstance(GOchicken);
            GOchicken = null;
        }
        if (GOdeer != null)
        {
            deer.ReleaseInstance(GOdeer);
            GOdeer = null;
        }
        if (GODragon != null)
        {
            Dragon.ReleaseInstance(GODragon);
            GODragon = null;
        }

        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
}
