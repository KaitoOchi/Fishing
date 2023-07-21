using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrawPlayerStamina : MonoBehaviour
{
    [SerializeField, Header("現在のスタミナ")]
    int Stamina;
    const int STAMINA_MIN = 0;      // スタミナ最小値
    const int STAMINA_MAX = 100;    // スタミナ最大値

    [SerializeField, Header("スタミナのテキスト")]
    TextMeshProUGUI StaminaText;

    Image m_hpImage;

    /// <summary>
    /// プレイヤーのHPを取得。
    /// </summary>
    public int GetHP()
    {
        return Stamina;
    }

    /// <summary>
    /// プレイヤーのHP最大に設定
    /// </summary>
    public void SetMaxHP()
    {
        Stamina = STAMINA_MAX;

        // テキストを設定
        StaminaText.text = (Stamina + " / " + STAMINA_MAX);

        //ゲージを減少。
        float fill = (float)Stamina / (float)STAMINA_MAX;
        m_hpImage.fillAmount = fill;
    }


    // Start is called before the first frame update
    void Start()
    {
        // テキストを設定
        StaminaText.text = (Stamina + " / " + STAMINA_MAX);

        //HP画像を取得。
        m_hpImage = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // スタミナ減少
    public void StaminaDecrease(int pow)
    {
        Stamina -= pow;

        // テキストを設定
        StaminaText.text = (Stamina + " / " + STAMINA_MAX);

        //ゲージを減少。
        float fill = (float)Stamina / (float)STAMINA_MAX;
        m_hpImage.fillAmount = fill;
    }

    // スタミナ増加
    public void StaminaIncrease()
    {

    }
}
