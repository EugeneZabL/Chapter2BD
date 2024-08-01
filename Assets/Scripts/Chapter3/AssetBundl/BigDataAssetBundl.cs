using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class BigDataAssetBundl : MonoBehaviour
{
    public string bundleUrl = "https://drive.google.com/uc?export=download&id=1pJjRlqSgscqSKMZZ5zFTHdHe2O9RzS_B";
    public Slider progressBar;
    public TextMeshProUGUI progressText;
    public Transform pointDragon;
    public AudioSource audioSourse;
    public VideoPlayer videoPlayer;

    private AssetBundle BigAsset;
    public void StartDownload()
    {
        StartCoroutine(DownloadAndLoadAssetBundle(bundleUrl));
    }

    private IEnumerator DownloadAndLoadAssetBundle(string url)
    {
        // Скачивание AssetBundle
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            uwr.SendWebRequest();

            while (!uwr.isDone)
            {
                UpdateProgressBar(uwr.downloadProgress);
                yield return null;
            }

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to download AssetBundle: " + uwr.error);
                yield break;
            }

            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
            if (bundle != null)
            {
                BigAsset = bundle;

                yield return StartCoroutine(SpawnDragon());
                UpdateProgressBar(0.33f);

                yield return StartCoroutine(OnAudio());
                UpdateProgressBar(0.67f);

                yield return StartCoroutine(OnVideo());

                Debug.Log("AssetBundle loaded successfully!");
                UpdateProgressBar(1f);

                BigAsset.Unload(false);

                yield return new WaitForSeconds(5);

                progressBar.gameObject.SetActive(false);
                progressText.gameObject.SetActive(false);

            }
            else
            {
                Debug.LogError("Failed to load AssetBundle.");
            }
        }
    }

    IEnumerator SpawnDragon()
    {
        AssetBundleRequest request = BigAsset.LoadAssetAsync<GameObject>("dragonprefab.prefab");
        yield return request;

        string[] assetNames = BigAsset.GetAllAssetNames();
        foreach (string assetName in assetNames)
        {
            Debug.Log("Asset in bundle: " + assetName);
        }

        if (request.asset != null)
        {
            GameObject ObjDragon = Instantiate(request.asset as GameObject);
            ObjDragon.transform.position = pointDragon.position;
            ObjDragon.transform.rotation = pointDragon.rotation;
            ObjDragon.transform.localScale = pointDragon.localScale;
        }
        else
        {
            Debug.LogError("Failed to load Dragon from AssetBundle.");
        }
    }

    IEnumerator OnVideo()
    {
        AssetBundleRequest request = BigAsset.LoadAssetAsync<VideoClip>("VideoTest");
        yield return request;

        if (request.asset != null)
        {
            videoPlayer.clip = request.asset as VideoClip;
            videoPlayer.audioOutputMode = 0;
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("Failed to load VideoClip.");
        }
    }

    IEnumerator OnAudio()
    {
        AssetBundleRequest request = BigAsset.LoadAssetAsync<AudioClip>("AudioTest");
        yield return request;

        if (request.asset != null)
        {
            audioSourse.clip = request.asset as AudioClip;
            audioSourse.Play();
        }
        else
        {
            Debug.LogError("Failed to load AudioClip.");
        }
    }


    private void UpdateProgressBar(float progress)
    {
        progressBar.value = progress;
        progressText.text = Mathf.CeilToInt(progress * 100) + "%";
    }
}
