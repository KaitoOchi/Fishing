using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyGoods : MonoBehaviour
{
    [SerializeField, Header("w“ü‚É•K—v‚È‹àŠz")]
    int             Money;
    [SerializeField, Header("Š‹àŠz")]
    TextMeshProUGUI HaveMoneyText;
    [SerializeField, Header("w“üƒeƒLƒXƒg")]
    TextMeshProUGUI BuyText;

    SaveDataManager m_saveManager;  // ƒZ[ƒuƒf[ƒ^  
    AudioSource m_audio;
    int             m_haveMoney;    // Œ»İŠ‚µ‚Ä‚¢‚é‹àŠz
    
    private void Start()
    {
        // Œ»İ‚Ì‹àŠz‚ğQÆ
        m_saveManager = FindObjectOfType<SaveDataManager>();
        m_haveMoney = m_saveManager.GetSaveData().saveData.money;

        // ƒfƒoƒbƒO—p
        //m_haveMoney = 1000;

        HaveMoneyText.text = " " + m_haveMoney;
        BuyText.text = "w“ü ( " + Money + ")";

        m_audio = GetComponent<AudioSource>();

        // Š‚µ‚Ä‚¢‚é‹àŠz‚ª 0 ˆÈ‰º‚È‚ç’†’f
        if (m_haveMoney <= 0 || m_haveMoney < Money)
        {
            // Š‚µ‚Ä‚¢‚È‚¢‚Ì‚Å‰Ÿ‚¹‚È‚¢‚æ‚¤‚É‚·‚é
            GetComponent<Button>().interactable = false;
            return;
        }
    }

    private void Update()
    {

    }

    // Start is called before the first frame update
    public void Buy()
    {
        m_audio.Play();

        m_saveManager.GetSaveData().saveData.money -= Money;
        HaveMoneyText.text = " " + m_saveManager.GetSaveData().saveData.money;

        // ‹àŠz‚ª 0 ˆÈ‰º‚È‚ç’†’f
        if (m_saveManager.GetSaveData().saveData.money <= 0 || m_saveManager.GetSaveData().saveData.money < Money)
        {
            GetComponent<Button>().interactable = false;
            return;
        }
    }
}
