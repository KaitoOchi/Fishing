using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrawPlayerStamina : MonoBehaviour
{
    [SerializeField, Header("���݂̃X�^�~�i")]
    int Stamina;
    const int STAMINA_MIN = 0;      // �X�^�~�i�ŏ��l
    const int STAMINA_MAX = 100;    // �X�^�~�i�ő�l

    [SerializeField, Header("�X�^�~�i�̃e�L�X�g")]
    TextMeshProUGUI StaminaText;

    Image m_hpImage;

    /// <summary>
    /// �v���C���[��HP���擾�B
    /// </summary>
    public int GetHP()
    {
        return Stamina;
    }

    /// <summary>
    /// �v���C���[��HP�ő�ɐݒ�
    /// </summary>
    public void SetMaxHP()
    {
        Stamina = STAMINA_MAX;

        // �e�L�X�g��ݒ�
        StaminaText.text = (Stamina + " / " + STAMINA_MAX);

        //�Q�[�W�������B
        float fill = (float)Stamina / (float)STAMINA_MAX;
        m_hpImage.fillAmount = fill;
    }


    // Start is called before the first frame update
    void Start()
    {
        // �e�L�X�g��ݒ�
        StaminaText.text = (Stamina + " / " + STAMINA_MAX);

        //HP�摜���擾�B
        m_hpImage = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �X�^�~�i����
    public void StaminaDecrease(int pow)
    {
        Stamina -= pow;

        // �e�L�X�g��ݒ�
        StaminaText.text = (Stamina + " / " + STAMINA_MAX);

        //�Q�[�W�������B
        float fill = (float)Stamina / (float)STAMINA_MAX;
        m_hpImage.fillAmount = fill;
    }

    // �X�^�~�i����
    public void StaminaIncrease()
    {

    }
}
