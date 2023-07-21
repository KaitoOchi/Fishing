using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResourceFishList : MonoBehaviour
{
    List<FishParameter> m_fishList;

    /// <summary>
    /// フィッシュリストを取得。
    /// </summary>
    /// <returns></returns>
    public List<FishParameter> GetFishList()
    {
        return m_fishList;
    }

    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Fishing/Parameter/FishList.asset";
        ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

        //おさかなリストを取得。
        FishParamList fishList = obj as FishParamList;
        m_fishList = fishList.GetFishList();
    }

    private void Awake()
    {
        //自身はシーンをまたいでも削除されないようにする
        DontDestroyOnLoad(gameObject);
    }
}
