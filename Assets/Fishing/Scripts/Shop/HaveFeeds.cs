using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HaveFeeds : MonoBehaviour
{
    [SerializeField, Header("所持数表示テキスト")]
    TextMeshProUGUI HaveFeedText;
    [SerializeField, Header("参照する配列")]
    int ArrayNumber;

    int m_haveFeed;

    SaveDataManager m_saveDataManager;

    // Start is called before the first frame update
    void Start()
    {
        // 個数を参照する
        m_saveDataManager = FindObjectOfType<SaveDataManager>();
        m_haveFeed = m_saveDataManager.GetSaveData().saveData.feed[ArrayNumber];

        string haveFeed = m_haveFeed.ToString("00");
        HaveFeedText.text = "(" + haveFeed + ")";
    }

    // Update is called once per frame
    void Update()
    {
        // 追加で購入された個数を参照する
        m_haveFeed = m_saveDataManager.GetSaveData().saveData.feed[ArrayNumber];

        string haveFeed = m_haveFeed.ToString("00");
        HaveFeedText.text = "(" + haveFeed + ")";
    }
}
