using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawFishParam : MonoBehaviour
{
    [SerializeField, Header("���f�����o�͂�����W")]
    GameObject      Position;
    [SerializeField, Header("���̖��O�̃e�L�X�g")]
    TextMeshProUGUI FishNameText;
    [SerializeField, Header("�傫���̃e�L�X�g")]
    TextMeshProUGUI SizeText;
    [SerializeField, Header("�l�����z�̃e�L�X�g")]
    TextMeshProUGUI GetMoneyText;
    [SerializeField, Header("New!�e�L�X�g")]
    GameObject      NewText;
    [SerializeField, Header("DrawFishHP")]
    DrawFishHP FishNumber;

    List<FishParameter> m_fishParamList;    // �������ȃ��X�g
    SaveDataManager     m_saveDataManager;  // �Z�[�u�f�[�^

    GameObject          m_fishModel;        // ���̃��f��

    int                 m_money;              // �ǉ��̋��z
    int                 m_number;             // ���ʔԍ�

    // ���z���Q�Ƃ���
    public int GetMoney()
    {
        return m_money;
    }

    // Start is called before the first frame update
    void Start()
    {
        //�J�[�\���̃��b�N�������B
        Cursor.lockState = CursorLockMode.None;

        // �ԍ����Q�Ƃ���
        m_number = FishNumber.GetNumber();

        m_saveDataManager = FindObjectOfType<SaveDataManager>();

        ResourceFishList fishList = FindObjectOfType<ResourceFishList>();
        m_fishParamList = fishList.GetFishList();

        // ���X�g����
        for (int i = 0; i < m_fishParamList.Count; i++)
        {
            // ���v���Ȃ��Ȃ璆�f
            if (m_fishParamList[i].GetInternalNum() != m_number)
            {
                continue;
            }

            // �l�����Ă��Ȃ���ނȂ�
            if (m_saveDataManager.GetSaveData().saveData.GetNum[i] == 0)
            {
                // �e�L�X�g��\��
                NewText.SetActive(true);
            }

            // �����_���ɃT�C�Y���o��
            float rand = Random.Range(m_fishParamList[i].GetSizeMin(), m_fishParamList[i].GetSizeMax());

            // ���O
            FishNameText.text = (m_fishParamList[i].GetName());
            // �T�C�Y
            SizeText.text = ("�傫��     " + rand.ToString() + "cm");
            // �l�����z
            GetMoneyText.text = ("������z     �� " + m_fishParamList[i].GetMoney());
            m_money = m_fishParamList[i].GetMoney();
            // ���f��
            GameObject FishModel = Instantiate(m_fishParamList[i].GetModel(), Position.transform.position, Quaternion.identity);
            FishModel.transform.localScale = new Vector3(50.0f, 50.0f, 50.0f);


            //�Z�[�u�f�[�^���擾�B
            SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();
            //�߂܂������𑝉��B
            saveManager.GetSaveData().saveData.GetNum[i]++;
            //�ő�T�C�Y���X�V�B
            if (saveManager.GetSaveData().saveData.maxSize[i] < rand)
            {
                saveManager.GetSaveData().saveData.maxSize[i] = rand;
            }
        }
    }
}
