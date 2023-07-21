using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrawFishHP : MonoBehaviour
{
    [SerializeField, Header("耐久値")]
    int                 Health;
    [SerializeField, Header("耐久値のテキスト")]
    TextMeshProUGUI     HPText;

    int                 m_number;             // 識別番号
    int                 m_power = 0;            //攻撃力。
    int                 m_feed = 0;
    int                 m_healthMax;         // 最大値
    const int           HEALTH_MIN = 0;      // 最小値

    List<FishParameter> m_fishParamList;
    List<FishParameter> m_finalFishParamList = new List<FishParameter>();
    Image m_hpImage;


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

    /// <summary>
    /// リセット処理。
    /// </summary>
    public void Reset()
    {
        Start();
    }

    /// <summary>
    /// HPを取得。
    /// </summary>
    /// <returns></returns>
    public int GetHP()
    {
        return Health;
    }

    /// <summary>
    /// 攻撃力を取得。
    /// </summary>
    /// <returns></returns>
    public int GetPower()
    {
        return m_power;
    }

    /// <summary>
    /// 餌の種類を設定。
    /// </summary>
    /// <param name="feed"></param>
    /// <returns></returns>
    public void SetFeed(int feed)
    {
        m_feed = feed;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResourceFishList fishList = FindObjectOfType<ResourceFishList>();
        m_fishParamList = fishList.GetFishList();

        int fishCount = m_fishParamList.Count;

        //リスト分回す。
        for (int i = 0; i < fishCount; i++)
        {
            if((int)m_fishParamList[i].GetFishType() == m_feed)
            {
                m_finalFishParamList.Add(m_fishParamList[i]);
            }
        }

        fishCount = m_finalFishParamList.Count;

        m_number = Random.Range(0, fishCount);

        // 耐久値を設定
        m_healthMax = m_finalFishParamList[m_number].GetHealth();
        Health = m_finalFishParamList[m_number].GetHealth();

        //攻撃力を設定。
        m_power = m_finalFishParamList[m_number].GetRank() * 5;

        // 耐久値を表示
        HPText.text = (Health + "/" + m_healthMax);

        //HP画像を取得。
        m_hpImage = GetComponent<Image>();
    }

    private void Update()
    {

    }

    public void HealthDecrease(int damege)
    {
        // 耐久値を減少させる
        Health -= damege;

        // 耐久値を表示
        HPText.text = (Health + "/" + m_healthMax);

        //ゲージを減少。
        float fill = (float)Health / (float)m_healthMax;
        m_hpImage.fillAmount = fill;
    }

}
