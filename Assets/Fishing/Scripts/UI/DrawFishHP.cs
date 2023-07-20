using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class DrawFishHP : MonoBehaviour
{
    [SerializeField, Header("耐久値")]
    int                 Health;
    [SerializeField, Header("耐久値のテキスト")]
    TextMeshProUGUI     HPText;

    int                 m_number;             // 識別番号

    int                 m_healthMax;         // 最大値
    const int           HEALTH_MIN = 0;      // 最小値

    bool                m_canFising = false; // 釣れるかどうか

    List<FishParameter> m_fishParamList;

    // 番号を設定
    public void SetNumber(int num)
    {
        m_number = num;
    }
    // 番号を参照する
    public int GetNumber()
    {
        return m_number;
    }

    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Fishing/Parameter/FishList.asset";
        ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

        //おさかなリストを取得。
        FishParamList fishList = obj as FishParamList;
        m_fishParamList = fishList.GetFishList();

        // リスト分回す
        for (int i = 0; i < m_fishParamList.Count; i++)
        {
            // 合致しないなら中断
            if (m_fishParamList[i].GetInternalNum() != m_number)
            {
                continue;
            }

            // 耐久値を設定
            m_healthMax = m_fishParamList[i].GetHealth();
            Health = m_fishParamList[i].GetHealth();

            break;
        }

        // 耐久値を表示
        HPText.text = (Health + "/" + m_healthMax);
    }

    private void Update()
    {
        // 耐久値が 0 のとき
        if (Health <= HEALTH_MIN)
        {
            m_canFising = true;
            return;
        }

        // 耐久値を表示
        HPText.text = (Health + "/" + m_healthMax);
    }

    public void HealthDecrease(int damege)
    {
        // 耐久値を減少させる
        Health -= damege;
    }

}
