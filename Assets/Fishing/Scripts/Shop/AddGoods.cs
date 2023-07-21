using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddGoods : MonoBehaviour
{
    [SerializeField, Header("�i�[����z��̔ԍ�")]
    int             ArrayNumber;
    [SerializeField, Header("������")]
    int             HaveFeed;
    [SerializeField, Header("�w���e�L�X�g")]
    TextMeshProUGUI BuyText;

    const int       HAVEFEED_MAX = 99;  // �ő�l

    SaveDataManager m_saveDataManager;  // �Z�[�u�f�[�^

    // Start is called before the first frame update
    void Start()
    {
        // �����Q�Ƃ���
        m_saveDataManager = FindObjectOfType<SaveDataManager>();
        HaveFeed = m_saveDataManager.GetSaveData().saveData.feed[ArrayNumber];

        if (HaveFeed>= HAVEFEED_MAX)
        {
            // �{�^���������Ȃ��悤�ɂ���
            GetComponent<Button>().interactable = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HaveFeed >= HAVEFEED_MAX)
        {
            // �{�^���������Ȃ��悤�ɂ���
            GetComponent<Button>().interactable = false;
            BuyText.text = ("�������ĂȂ���I");
            return;
        }
    }

    public void BuyGoods()
    {
        m_saveDataManager.GetSaveData().saveData.feed[ArrayNumber] = ++HaveFeed;
    }
}
