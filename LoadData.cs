using System.Collections;
using System.Collections.Generic;
using System.IO;//File. 所需
using UnityEngine;
using UnityEngine.Networking;//UnityWebRequest需要

public class LoadData : MonoBehaviour
{
    //Application.dataPath是绝对路径（盘符/工程目录/Assets）
  
    string path = "Assets/AssetBundles/cube";
   
    void Start()
    {
        //方式  1 & 1.1
        StartCoroutine(LoadFromMemoryAsync(path));
        //LoadFromMemory();

        //方式2  &2.1
        //StartCoroutine(LoadFromFile()); 
        //LoadFromFile();


        //方式三
        //StartCoroutine(LoadFromCacheOrDownload());


        //方式四
        //StartCoroutine(UnityWebRequest());


    }
    //方式1）通过本地内存异步加载ab包资源
    IEnumerator LoadFromMemoryAsync(string path)
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        //AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));
        yield return request;
        AssetBundle bundle = request.assetBundle;
        var prefab = bundle.LoadAsset<GameObject>("Cube");
        Instantiate(prefab);
    }
    //方式1.1）同步加载内存中ab包资源                   同步，不需要协程
    void LoadFromMemory()
    {
        AssetBundle bundle = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));       
        var prefab = bundle.LoadAsset<GameObject>("Cube");
        Instantiate(prefab);
    }



    ////方式2）通过本地文件夹异步加载
    //IEnumerator LoadFromFile()
    //{
    //    //                                                       不同点
    //    AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
    //    yield return request;
    //    AssetBundle bundle = request.assetBundle;
    //    var prefab = bundle.LoadAsset<GameObject>("Cube");
    //    Instantiate(prefab);
    //}
    //方式2.1）通过本地文件夹同步加载
    //void LoadFromFile()
    //{
    //    var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "myassetBundle"));
    //    if (myLoadedAssetBundle == null)
    //    {
    //        Debug.Log("Failed to load AssetBundle!");
    //        return;
    //    }
    //    var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("Cube");
    //    Instantiate(prefab);
    //}


    //方式3)通过WWW.LoadFromCacheOrDownload服务器加载 已过时 即将被；
    //IEnumerator LoadFromCacheOrDownload()
    //{
    //    while (!Caching.ready)
    //        yield return null;

    //    //WWW www = WWW.LoadFromCacheOrDownload(@"file:///G:\Unity\AB_demo\Assets\AssetBundles\cube",1);
    //    WWW www = WWW.LoadFromCacheOrDownload(@"http://localhost/AssetBundles/cube", 1);

    //    yield return www;
    //    Debug.Log(www.ToString());
    //    if (!string.IsNullOrEmpty(www.error))
    //    {
    //        Debug.Log(www.error);
    //        yield break;
    //    }
    //    AssetBundle bundle = www.assetBundle;
    //    var prefab = bundle.LoadAsset<GameObject>("Cube");
    //    Instantiate(prefab);
    //}


    ////方式4）方式4UnityWebRequest
    //IEnumerator UnityWebRequest()
    //{
    //    string uri = @"http://localhost/AssetBundles/cube";
    //    //UnityEngine.Networking.前缀加或不加都可以
    //    UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.GetAssetBundle(uri, 0);
    //    yield return request.SendWebRequest();
    //    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
    //    var prefab = bundle.LoadAsset<GameObject>("Cube");
    //    Instantiate(prefab);
    //}   
}
