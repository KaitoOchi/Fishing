using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyGoods : MonoBehaviour
{
    [SerializeField, Header("購入に必要な金額")]
    int             Money;
    [SerializeField, Header("所持金額")]
    TextMeshProUGUI HaveMoneyText;
    [SerializeField, Header("購入テキスト")]
    TextMeshProUGUI BuyText;

    SaveDataManager m_saveManager;  // セーブデータ  
    AudioSource m_audio;
    int             m_haveMoney;    // 現在所持している金額
    
    private void Start()
    {
        // 現在の金額を参照
        m_saveManager = FindObjectOfType<SaveDataManager>();
        m_haveMoney = m_saveManager.GetSaveData().saveData.money;

        // デバッグ用
        //m_haveMoney = 1000;

        HaveMoneyText.text = "￥ " + m_haveMoney;
        BuyText.text = "購入 (￥ " + Money + ")";

        m_audio = GetComponent<AudioSource>();

        // 所持している金額が 0 以下なら中断
        if (m_haveMoney <= 0 || m_haveMoney < Money)
        {
            // 所持していないので押せないようにする
            GetComponent<Button>().interactable = false;
            return;
        }
    }

    private void Update()
    {

    }

    // Start is called before the first frame update
    public void Buy()
    {
        m_audio.Play();

        m_saveManager.GetSaveData().saveData.money -= Money;
        HaveMoneyText.text = "￥ " + m_saveManager.GetSaveData().saveData.money;

        // 金額が 0 以下なら中断
        if (m_saveManager.GetSaveData().saveData.money <= 0 || m_saveManager.GetSaveData().saveData.money < Money)
        {
            GetComponent<Button>().interactable = false;
            return;
        }
    }
}
