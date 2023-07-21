using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddGoods : MonoBehaviour
{
    [SerializeField, Header("格納する配列の番号")]
    int             ArrayNumber;
    [SerializeField, Header("所持数")]
    int             HaveFeed;
    [SerializeField, Header("購入テキスト")]
    TextMeshProUGUI BuyText;

    const int       HAVEFEED_MAX = 99;  // 最大値

    SaveDataManager m_saveDataManager;  // セーブデータ

    // Start is called before the first frame update
    void Start()
    {
        // 個数を参照する
        m_saveDataManager = FindObjectOfType<SaveDataManager>();
        HaveFeed = m_saveDataManager.GetSaveData().saveData.feed[ArrayNumber];

        if (HaveFeed>= HAVEFEED_MAX)
        {
            // ボタンを押せないようにする
            GetComponent<Button>().interactable = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HaveFeed >= HAVEFEED_MAX)
        {
            // ボタンを押せないようにする
            GetComponent<Button>().interactable = false;
            BuyText.text = ("もう持てないよ！");
            return;
        }
    }

    public void BuyGoods()
    {
        m_saveDataManager.GetSaveData().saveData.feed[ArrayNumber] = ++HaveFeed;
    }
}
