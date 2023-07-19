using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "MyGame/Create FishParameterTable", fileName = "FishParameterTable")]
public class FishParameter : ScriptableObject
{
    public enum EnFishType
    {
        enFish_A,
        enFish_B,
        enFish_C,
    }


    [SerializeField, Header("内部番号")]
    int InternalNum = 0;

    [SerializeField, Header("名前")]
    string Name = "";

    [SerializeField, Header("モデル")]
    Mesh Model = null;

    [SerializeField, Header("属性")]
    EnFishType FishType = EnFishType.enFish_A;

    [SerializeField, Header("星の数")]
    int Rank = 0;

    [SerializeField, Header("最小サイズ(cm)")]
    float SizeMin = 0.0f;

    [SerializeField, Header("最大サイズ(cm)")]
    float SizeMax = 0.0f;


    /// <summary>
    /// 内部番号を取得。
    /// </summary>
    /// <returns></returns>
    public int GetInternalNum()
    {
        return InternalNum;
    }

    /// <summary>
    /// 名前を取得。
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return Name;
    }

    /// <summary>
    /// モデルを取得。
    /// </summary>
    /// <returns></returns>
    public Mesh GetModel()
    {
        return Model;
    }

    /// <summary>
    /// 魚の種類を取得。
    /// </summary>
    /// <returns></returns>
    public EnFishType GetFishType()
    {
        return FishType;
    }

    /// <summary>
    /// 星の数を取得。
    /// </summary>
    /// <returns></returns>
    public int GetRank()
    {
        return Rank;
    }

    /// <summary>
    /// 最小サイズを取得。
    /// </summary>
    /// <returns></returns>
    public float GetSizeMin()
    {
        return SizeMin;
    }

    /// <summary>
    /// 最大サイズを取得。
    /// </summary>
    /// <returns></returns>
    public float GetSizeMax()
    {
        return SizeMax;
    }
}
