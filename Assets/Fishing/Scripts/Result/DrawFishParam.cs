using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawFishParam : MonoBehaviour
{
    [SerializeField, Header("モデルを出力する座標")]
    GameObject      Position;
    [SerializeField, Header("魚の名前のテキスト")]
    TextMeshProUGUI FishNameText;
    [SerializeField, Header("大きさのテキスト")]
    TextMeshProUGUI SizeText;
    [SerializeField, Header("獲得金額のテキスト")]
    TextMeshProUGUI GetMoneyText;
    [SerializeField, Header("New!テキスト")]
    GameObject      NewText;
    [SerializeField, Header("DrawFishHP")]
    DrawFishHP FishNumber;

    List<FishParameter> m_fishParamList;    // おさかなリスト
    SaveDataManager     m_saveDataManager;  // セーブデータ

    GameObject          m_fishModel;        // 魚のモデル

    int                 m_money;              // 追加の金額
    int                 m_number;             // 識別番号

    // 金額を参照する
    public int GetMoney()
    {
        return m_money;
    }

    // Start is called before the first frame update
    void Start()
    {
        //カーソルのロックを解除。
        Cursor.lockState = CursorLockMode.None;

        // 番号を参照する
        m_number = FishNumber.GetNumber();

        m_saveDataManager = FindObjectOfType<SaveDataManager>();

        ResourceFishList fishList = FindObjectOfType<ResourceFishList>();
        m_fishParamList = fishList.GetFishList();

        // リスト分回す
        for (int i = 0; i < m_fishParamList.Count; i++)
        {
            // 合致しないなら中断
            if (m_fishParamList[i].GetInternalNum() != m_number)
            {
                continue;
            }

            // 獲得していない種類なら
            if (m_saveDataManager.GetSaveData().saveData.GetNum[i] == 0)
            {
                // テキストを表示
                NewText.SetActive(true);
            }

            // ランダムにサイズを出力
            float rand = Random.Range(m_fishParamList[i].GetSizeMin(), m_fishParamList[i].GetSizeMax());

            // 名前
            FishNameText.text = (m_fishParamList[i].GetName());
            // サイズ
            SizeText.text = ("大きさ     " + rand.ToString() + "cm");
            // 獲得金額
            GetMoneyText.text = ("入手金額     ￥ " + m_fishParamList[i].GetMoney());
            m_money = m_fishParamList[i].GetMoney();
            // モデル
            GameObject FishModel = Instantiate(m_fishParamList[i].GetModel(), Position.transform.position, Quaternion.identity);
            FishModel.transform.localScale = new Vector3(50.0f, 50.0f, 50.0f);


            //セーブデータを取得。
            SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();
            //捕まえた数を増加。
            saveManager.GetSaveData().saveData.GetNum[i]++;
            //最大サイズを更新。
            if (saveManager.GetSaveData().saveData.maxSize[i] < rand)
            {
                saveManager.GetSaveData().saveData.maxSize[i] = rand;
            }
        }
    }
}
