using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawFishParam : MonoBehaviour
{
    [SerializeField, Header("�ނ�����")]
    string          FishName;
    [SerializeField, Header("�T�C�Y")]
    float           FishSize;
    [SerializeField, Header("���z")]
    int             FishMoney;
    [Space]
    [SerializeField, Header("���̖��O�̃e�L�X�g")]
    TextMeshProUGUI FishNameText;
    [SerializeField, Header("�傫���̃e�L�X�g")]
    TextMeshProUGUI SizeText;
    [SerializeField, Header("�l�����z�̃e�L�X�g")]
    TextMeshProUGUI GetMoneyText;
    [SerializeField, Header("New!�e�L�X�g")]
    GameObject NewText;
    [SerializeField, Header("HighScore!�e�L�X�g")]
    GameObject HighScoreText;

    FishParamList   m_fishParamList;    // �������ȃ��X�g
    SaveDataManager m_saveDataManager;  // �Z�[�u�f�[�^

    // Start is called before the first frame update
    void Start()
    {
        m_saveDataManager = FindObjectOfType<SaveDataManager>();

        FishNameText.text = (FishName);
        SizeText.text = ("�傫��     " + FishSize + "�Z���`");
        GetMoneyText.text = ("�l�����z     �� " + FishMoney);

        //// ���X�g����
        //for (int i=0; i < m_fishParamList.GetFishList().Count; i++)
        //{
        //    // ���v���Ȃ��Ȃ璆�f

        //    // �l�����Ă��Ȃ���ނȂ�
        //    if (m_saveDataManager.GetSaveData().saveData.isGet[i])
        //    {
        //        // �e�L�X�g��\��
        //        NewText.SetActive(true);
        //    }

        //    // �T�C�Y���X�V�����Ȃ�
        //    if (m_saveDataManager.GetSaveData().saveData.maxSize[i] <= FishSize)
        //    {
        //        // �e�L�X�g��\��
        //        HighScoreText.SetActive(true);
        //    }
        //}
    }
}
