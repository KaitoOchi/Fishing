using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Create FishList", fileName = "FishList")]
public class FishParamList : ScriptableObject
{
    [SerializeField, Header("�������ȃ��X�g")]
    List<FishParameter> FishList = null;


    /// <summary>
    /// �������ȃ��X�g���擾�B
    /// </summary>
    /// <returns></returns>
    public List<FishParameter> GetFishList()
    {
        return FishList;
    }
}
