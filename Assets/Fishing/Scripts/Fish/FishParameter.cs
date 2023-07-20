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
        enFish_Human,
    }


    [SerializeField, Header("内部番号")]
    int InternalNum = 0;

    [SerializeField, Header("名前")]
    string Name = "";

    [SerializeField, Header("モデル")]
    GameObject Model = null;

    [SerializeField, Header("画像")]
    Sprite ExplainSprite = null;

    [SerializeField, Header("説明文")]
    string ExplainString = "";

    [SerializeField, Header("属性")]
    EnFishType FishType = EnFishType.enFish_A;

    [SerializeField, Header("星の数")]
    int Rank = 0;

    [SerializeField, Header("最小サイズ(cm)")]
    float SizeMin = 0.0f;

    [SerializeField, Header("最大サイズ(cm)")]
    float SizeMax = 0.0f;

    [SerializeField, Header("入手金額")]
    int Money = 0;

    [SerializeField, Header("耐久値")]
    int Health = 0;


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
    public GameObject GetModel()
    {
        return Model;
    }

    /// <summary>
    /// 画像を取得。
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite()
    {
        return ExplainSprite;
    }

    /// <summary>
    /// 説明文を取得。
    /// </summary>
    /// <returns></returns>
    public string GetExplain()
    {
        return ExplainString;
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


    /// <summary>
    /// 金額を取得。
    /// </summary>
    /// <returns></returns>
    public int GetMoney()
    {
        return Money;
    }

    /// <summary>
    /// 耐久値を取得。
    /// </summary>
    /// <returns></returns>
    public int GetHealth()
    {
        return Health;
    }
}
