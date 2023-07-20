using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawPlayerStamina : MonoBehaviour
{
    [SerializeField, Header("現在のスタミナ")]
    int Stamina;
    const int STAMINA_MIN = 0;      // スタミナ最小値
    const int STAMINA_MAX = 100;    // スタミナ最大値

    [SerializeField, Header("スタミナのテキスト")]
    TextMeshProUGUI StaminaText;

    // Start is called before the first frame update
    void Start()
    {
        // テキストを設定
        StaminaText.text = (Stamina + " / " + STAMINA_MAX);
    }

    // Update is called once per frame
    void Update()
    {
        // テキストを設定
        StaminaText.text = (Stamina + " / " + STAMINA_MAX);
    }

    // スタミナ減少
    public void StaminaDecrease()
    {

    }

    // スタミナ増加
    public void StaminaIncrease()
    {

    }
}
