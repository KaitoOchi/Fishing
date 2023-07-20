using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawHaveMoney : MonoBehaviour
{
    [SerializeField, Header("�������z�̃e�L�X�g")]
    TextMeshProUGUI HaveMoneyText;
    [SerializeField, Header("�������z")]
    int             HaveMoney;

    SaveDataManager m_saveDataManager;

    // Start is called before the first frame update
    void Start()
    {
        // �������z���Q�Ƃ���
        m_saveDataManager = FindObjectOfType<SaveDataManager>();
        HaveMoney = m_saveDataManager.GetSaveData().saveData.money;

        // �������z��\��
        HaveMoneyText.text = ("�� " + HaveMoney);
    }

    // Update is called once per frame
    void Update()
    {
        // �������z���Q��
        HaveMoney = m_saveDataManager.GetSaveData().saveData.money;
        // �\������
        HaveMoneyText.text = ("�� " + HaveMoney);
    }
}
