using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawFishParam : MonoBehaviour
{
    [SerializeField, Header("釣った魚")]
    string          FishName;
    [SerializeField, Header("サイズ")]
    float           FishSize;
    [SerializeField, Header("金額")]
    int             FishMoney;
    [Space]
    [SerializeField, Header("魚の名前のテキスト")]
    TextMeshProUGUI FishNameText;
    [SerializeField, Header("大きさのテキスト")]
    TextMeshProUGUI SizeText;
    [SerializeField, Header("獲得金額のテキスト")]
    TextMeshProUGUI GetMoneyText;
    [SerializeField, Header("New!テキスト")]
    GameObject NewText;
    [SerializeField, Header("HighScore!テキスト")]
    GameObject HighScoreText;

    FishParamList   m_fishParamList;    // おさかなリスト
    SaveDataManager m_saveDataManager;  // セーブデータ

    // Start is called before the first frame update
    void Start()
    {
        m_saveDataManager = FindObjectOfType<SaveDataManager>();

        FishNameText.text = (FishName);
        SizeText.text = ("大きさ     " + FishSize + "センチ");
        GetMoneyText.text = ("獲得金額     ￥ " + FishMoney);

        //// リスト分回す
        //for (int i=0; i < m_fishParamList.GetFishList().Count; i++)
        //{
        //    // 合致しないなら中断

        //    // 獲得していない種類なら
        //    if (m_saveDataManager.GetSaveData().saveData.isGet[i])
        //    {
        //        // テキストを表示
        //        NewText.SetActive(true);
        //    }

        //    // サイズを更新したなら
        //    if (m_saveDataManager.GetSaveData().saveData.maxSize[i] <= FishSize)
        //    {
        //        // テキストを表示
        //        HighScoreText.SetActive(true);
        //    }
        //}
    }
}
