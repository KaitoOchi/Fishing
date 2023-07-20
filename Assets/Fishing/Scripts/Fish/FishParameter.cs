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


    [SerializeField, Header("�����ԍ�")]
    int InternalNum = 0;

    [SerializeField, Header("���O")]
    string Name = "";

    [SerializeField, Header("���f��")]
    GameObject Model = null;

    [SerializeField, Header("�摜")]
    Sprite ExplainSprite = null;

    [SerializeField, Header("������")]
    string ExplainString = "";

    [SerializeField, Header("����")]
    EnFishType FishType = EnFishType.enFish_A;

    [SerializeField, Header("���̐�")]
    int Rank = 0;

    [SerializeField, Header("�ŏ��T�C�Y(cm)")]
    float SizeMin = 0.0f;

    [SerializeField, Header("�ő�T�C�Y(cm)")]
    float SizeMax = 0.0f;

    [SerializeField, Header("������z")]
    int Money = 0;

    [SerializeField, Header("�ϋv�l")]
    int Health = 0;


    /// <summary>
    /// �����ԍ����擾�B
    /// </summary>
    /// <returns></returns>
    public int GetInternalNum()
    {
        return InternalNum;
    }

    /// <summary>
    /// ���O���擾�B
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return Name;
    }

    /// <summary>
    /// ���f�����擾�B
    /// </summary>
    /// <returns></returns>
    public GameObject GetModel()
    {
        return Model;
    }

    /// <summary>
    /// �摜���擾�B
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite()
    {
        return ExplainSprite;
    }

    /// <summary>
    /// ���������擾�B
    /// </summary>
    /// <returns></returns>
    public string GetExplain()
    {
        return ExplainString;
    }

    /// <summary>
    /// ���̎�ނ��擾�B
    /// </summary>
    /// <returns></returns>
    public EnFishType GetFishType()
    {
        return FishType;
    }

    /// <summary>
    /// ���̐����擾�B
    /// </summary>
    /// <returns></returns>
    public int GetRank()
    {
        return Rank;
    }

    /// <summary>
    /// �ŏ��T�C�Y���擾�B
    /// </summary>
    /// <returns></returns>
    public float GetSizeMin()
    {
        return SizeMin;
    }

    /// <summary>
    /// �ő�T�C�Y���擾�B
    /// </summary>
    /// <returns></returns>
    public float GetSizeMax()
    {
        return SizeMax;
    }


    /// <summary>
    /// ���z���擾�B
    /// </summary>
    /// <returns></returns>
    public int GetMoney()
    {
        return Money;
    }

    /// <summary>
    /// �ϋv�l���擾�B
    /// </summary>
    /// <returns></returns>
    public int GetHealth()
    {
        return Health;
    }
}
