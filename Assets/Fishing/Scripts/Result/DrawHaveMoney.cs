using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawHaveMoney : MonoBehaviour
{
    [SerializeField, Header("Š‹àŠz‚ÌƒeƒLƒXƒg")]
    TextMeshProUGUI HaveMoneyText;
    [SerializeField, Header("Š‹àŠz")]
    int             HaveMoney;

    SaveDataManager m_saveDataManager;

    // Start is called before the first frame update
    void Start()
    {
        // Š‹àŠz‚ğQÆ‚·‚é
        m_saveDataManager = FindObjectOfType<SaveDataManager>();
        HaveMoney = m_saveDataManager.GetSaveData().saveData.money;

        // Š‹àŠz‚ğ•\¦
        HaveMoneyText.text = (" " + HaveMoney);
    }

    // Update is called once per frame
    void Update()
    {
        // Š‹àŠz‚ğQÆ
        HaveMoney = m_saveDataManager.GetSaveData().saveData.money;
        // •\¦‚·‚é
        HaveMoneyText.text = (" " + HaveMoney);
    }
}
