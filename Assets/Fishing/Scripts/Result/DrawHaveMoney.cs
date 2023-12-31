using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawHaveMoney : MonoBehaviour
{
    [SerializeField, Header("所持金額のテキスト")]
    TextMeshProUGUI HaveMoneyText;
    [SerializeField, Header("所持金額")]
    int             HaveMoney;

    SaveDataManager m_saveDataManager;

    // Start is called before the first frame update
    void Start()
    {
        // 所持金額を参照する
        m_saveDataManager = FindObjectOfType<SaveDataManager>();
        HaveMoney = m_saveDataManager.GetSaveData().saveData.money;

        // 所持金額を表示
        HaveMoneyText.text = ("￥ " + HaveMoney);
    }

    // Update is called once per frame
    void Update()
    {
        // 所持金額を参照
        HaveMoney = m_saveDataManager.GetSaveData().saveData.money;
        // 表示する
        HaveMoneyText.text = ("￥ " + HaveMoney);
    }
}
