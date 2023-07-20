using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawPlayerStamina : MonoBehaviour
{
    [SerializeField, Header("���݂̃X�^�~�i")]
    int Stamina;
    const int STAMINA_MIN = 0;      // �X�^�~�i�ŏ��l
    const int STAMINA_MAX = 100;    // �X�^�~�i�ő�l

    [SerializeField, Header("�X�^�~�i�̃e�L�X�g")]
    TextMeshProUGUI StaminaText;

    // Start is called before the first frame update
    void Start()
    {
        // �e�L�X�g��ݒ�
        StaminaText.text = (Stamina + " / " + STAMINA_MAX);
    }

    // Update is called once per frame
    void Update()
    {
        // �e�L�X�g��ݒ�
        StaminaText.text = (Stamina + " / " + STAMINA_MAX);
    }

    // �X�^�~�i����
    public void StaminaDecrease()
    {

    }

    // �X�^�~�i����
    public void StaminaIncrease()
    {

    }
}
