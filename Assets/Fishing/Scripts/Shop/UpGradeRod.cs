using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpGradeRod : MonoBehaviour
{
    [SerializeField,Header("���݂̃O���[�h")]
    int             RodGrade;
    [SerializeField, Header("�w���e�L�X�g")]
    TextMeshProUGUI BuyText;

    const int       MAX_GRADE = 2;          // �O���[�h�̍ő�l

    SaveDataManager m_saveDataManager;      // �Z�[�u�f�[�^

    // Start is called before the first frame update
    void Start()
    {
        // ���݂̃O���[�h���Q�Ƃ���
        m_saveDataManager = FindObjectOfType<SaveDataManager>();
        RodGrade = m_saveDataManager.GetSaveData().saveData.rodPower;

        if (RodGrade >= MAX_GRADE)
        {
            // �{�^���������Ȃ��悤�ɂ���
            GetComponent<Button>().interactable = false;
            return;
        }
    }
    private void Update()
    {
        // �A�b�v�O���[�h���ő�̂Ƃ�
        if (RodGrade >= MAX_GRADE)
        {
            // �{�^���������Ȃ��悤�ɂ���
            GetComponent<Button>().interactable = false;

            BuyText.text = ("���������I");

            return;
        }
    }

    public void UpGrade()
    {
        // �O���[�h���グ��
        m_saveDataManager.GetSaveData().saveData.rodPower = RodGrade++;

        // �f�o�b�O�p
        //Debug.Log(m_saveDataManager.GetSaveData().saveData.rodPower);
    }
}
