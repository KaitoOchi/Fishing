using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpGradeRod : MonoBehaviour
{
    [SerializeField,Header("現在のグレード")]
    int             RodGrade;
    [SerializeField, Header("購入テキスト")]
    TextMeshProUGUI BuyText;

    const int       MAX_GRADE = 2;          // グレードの最大値

    SaveDataManager m_saveDataManager;      // セーブデータ

    // Start is called before the first frame update
    void Start()
    {
        // 現在のグレードを参照する
        m_saveDataManager = FindObjectOfType<SaveDataManager>();
        RodGrade = m_saveDataManager.GetSaveData().saveData.rodPower;

        if (RodGrade >= MAX_GRADE)
        {
            // ボタンを押せないようにする
            GetComponent<Button>().interactable = false;
            return;
        }
    }
    private void Update()
    {
        // アップグレードが最大のとき
        if (RodGrade >= MAX_GRADE)
        {
            // ボタンを押せないようにする
            GetComponent<Button>().interactable = false;

            BuyText.text = ("強化完了！");

            return;
        }
    }

    public void UpGrade()
    {
        // グレードを上げる
        m_saveDataManager.GetSaveData().saveData.rodPower = RodGrade++;

        // デバッグ用
        //Debug.Log(m_saveDataManager.GetSaveData().saveData.rodPower);
    }
}
