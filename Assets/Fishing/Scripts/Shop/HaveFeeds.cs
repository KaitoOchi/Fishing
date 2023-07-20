using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HaveFeeds : MonoBehaviour
{
    [SerializeField, Header("�������\���e�L�X�g")]
    TextMeshProUGUI HaveFeedText;
    [SerializeField, Header("�Q�Ƃ���z��")]
    int ArrayNumber;

    int m_haveFeed;

    SaveDataManager m_saveDataManager;

    // Start is called before the first frame update
    void Start()
    {
        // �����Q�Ƃ���
        m_saveDataManager = FindObjectOfType<SaveDataManager>();
        m_haveFeed = m_saveDataManager.GetSaveData().saveData.feed[ArrayNumber];

        string haveFeed = m_haveFeed.ToString("00");
        HaveFeedText.text = "(" + haveFeed + ")";
    }

    // Update is called once per frame
    void Update()
    {
        // �ǉ��ōw�����ꂽ�����Q�Ƃ���
        m_haveFeed = m_saveDataManager.GetSaveData().saveData.feed[ArrayNumber];

        string haveFeed = m_haveFeed.ToString("00");
        HaveFeedText.text = "(" + haveFeed + ")";
    }
}
