using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;

public class GetPost : MonoBehaviour
{

    [SerializeField]
    Image[] _image;

    [SerializeField]
    SpriteRenderer _spriteRenderer;

    Response _responseGet;
    Response _responsePost;

    [SerializeField]
    TextMeshProUGUI _textGet, _textPost;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://httpbin.org/anything"));

        StartCoroutine(PostRequest("https://httpbin.org/anything", "Hello World!"));

        StartCoroutine(LoadImageGetTexture("https://i1.sndcdn.com/artworks-D4tA2gefvGQHFwjH-oR0vvQ-t500x500.jpg"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Отправка запроса и ожидание ответа
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                _responseGet = JsonConvert.DeserializeObject<Response>(webRequest.downloadHandler.text);;
            }
        }


        _textGet.text = "Data: " + _responseGet.data + "\n"
                      + "Method: " + _responseGet.method + "\n"
                      + "Origin: " + _responseGet.origin + "\n"
                      + "User-Agent: " + _responseGet.headers.UserAgent + "\n"
                      + "Host: " + _responseGet.headers.Host + "\n"
                      + "X-Unity-Version: " + _responseGet.headers.XUnityVersion + "\n"
                      + "Url: " + _responseGet.url + "\n";
    }

    private IEnumerator PostRequest(string uri, string jsonData)
    {
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);

        using (UnityWebRequest webRequest = new UnityWebRequest(uri, "POST"))
        {
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            // Отправка запроса и ожидание ответа
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            { 
                _responsePost = JsonConvert.DeserializeObject<Response>(webRequest.downloadHandler.text);
            }
        }

        _textPost.text = "Data: " + _responsePost.data + "\n"
              + "Method: " + _responsePost.method + "\n"
              + "Origin: " + _responsePost.origin + "\n"
              + "User-Agent: " + _responsePost.headers.UserAgent + "\n"
              + "Host: " + _responsePost.headers.Host + "\n"
              + "X-Unity-Version: " + _responsePost.headers.XUnityVersion + "\n"
              + "Url: " + _responsePost.url + "\n";

    }


    private IEnumerator LoadImageGetTexture(string url)
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
        yield return webRequest.SendWebRequest();

        if(webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(webRequest.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
            
            foreach(Image a in _image)
            {
                a.sprite = sprite;
            }
            _spriteRenderer.sprite = sprite;
        }
    }
}
