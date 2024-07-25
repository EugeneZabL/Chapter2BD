using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;


[Serializable]
public class Response
{
    public Dictionary<string, string> args;
    public string data;
    public Dictionary<string, string> files;
    public Dictionary<string, string> form;
    public Headers headers;
    public object json;
    public string method;
    public string origin;
    public string url;
}

[Serializable]
public class Headers
{
    public string Accept;
    [JsonProperty("Accept-Encoding")]
    public string AcceptEncoding;
    [JsonProperty("Content-Length")]
    public string ContentLength;
    [JsonProperty("Content-Type")]
    public string ContentType;
    public string Host;
    [JsonProperty("User-Agent")]
    public string UserAgent;
    [JsonProperty("X-Amzn-Trace-Id")]
    public string XAmznTraceId;
    [JsonProperty("X-Unity-Version")]
    public string XUnityVersion;
}