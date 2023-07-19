using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Create FishList", fileName = "FishList")]
public class FishParamList : ScriptableObject
{
    [SerializeField, Header("おさかなリスト")]
    List<FishParameter> FishList = null;


    /// <summary>
    /// おさかなリストを取得。
    /// </summary>
    /// <returns></returns>
    public List<FishParameter> GetFishList()
    {
        return FishList;
    }
}
