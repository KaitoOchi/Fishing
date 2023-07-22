using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceFishList : MonoBehaviour
{
    [SerializeField, Header("さかなリスト")]
    FishParamList FishList;

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
        //おさかなリストを取得。
        m_fishList = FishList.GetFishList();
    }

    private void Awake()
    {
        //自身はシーンをまたいでも削除されないようにする
        DontDestroyOnLoad(gameObject);
    }
}
