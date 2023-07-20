using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyGoods : MonoBehaviour
{
    [SerializeField, Header("�w���ɕK�v�ȋ��z")]
    int             Money;
    [SerializeField, Header("�������z")]
    TextMeshProUGUI HaveMoneyText;
    [SerializeField, Header("�w���e�L�X�g")]
    TextMeshProUGUI BuyText;

    SaveDataManager m_saveManager;  // �Z�[�u�f�[�^  
    int             m_haveMoney;    // ���ݏ������Ă�����z
    
    private void Start()
    {
        // ���݂̋��z���Q��
        m_saveManager = FindObjectOfType<SaveDataManager>();
        //m_haveMoney = m_saveManager.GetSaveData().saveData.money;

        // �f�o�b�O�p
        m_haveMoney = 1000;

        HaveMoneyText.text = "�� " + m_haveMoney;
        BuyText.text = "�w�� (�� " + Money + ")";

        // �������Ă�����z�� 0 �ȉ��Ȃ璆�f
        if (m_haveMoney <= 0 || m_haveMoney < Money)
        {
            // �������Ă��Ȃ��̂ŉ����Ȃ��悤�ɂ���
            GetComponent<Button>().interactable = false;
            return;
        }
    }

    private void Update()
    {
        //m_haveMoney = m_saveManager.GetSaveData().saveData.money;

        // ���z�� 0 �ȉ��Ȃ璆�f
        if (m_haveMoney <= 0 || m_haveMoney < Money)
        {
            GetComponent<Button>().interactable = false;
            return;
        }
    }

    // Start is called before the first frame update
    public void Buy()
    {
        m_haveMoney -= Money;
        HaveMoneyText.text = "�� " + m_haveMoney;
    }
}