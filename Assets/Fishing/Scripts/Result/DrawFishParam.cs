using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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

    List<FishParameter> m_fishParamList;    // �������ȃ��X�g
    SaveDataManager     m_saveDataManager;  // �Z�[�u�f�[�^

    GameObject          m_fishModel;        // ���̃��f��

    int                 m_money;              // �ǉ��̋��z
    int                 m_number;             // ���ʔԍ�

    // �ԍ���ݒ�
    public void SetNumber(int num)
    {
        m_number = num;
    }


    // ���z���Q�Ƃ���
    public int GetMoney()
    {
        return m_money;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_saveDataManager = FindObjectOfType<SaveDataManager>();

        string path = "Assets/Fishing/Parameter/FishList.asset";
        ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

        //�������ȃ��X�g���擾�B
        FishParamList fishList = obj as FishParamList;
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
            if (m_saveDataManager.GetSaveData().saveData.isGet[i])
            {
                // �e�L�X�g��\��
                NewText.SetActive(true);
            }

            // �����_���ɃT�C�Y���o��
            float rand = Random.Range(m_fishParamList[i].GetSizeMin(), m_fishParamList[i].GetSizeMax());

            // ���O
            FishNameText.text = (m_fishParamList[i].GetName());
            // �T�C�Y
            SizeText.text = ("�傫��     " + rand.ToString() + "�Z���`");
            // �l�����z
            GetMoneyText.text = ("������z     �� ");
            // ���f��
            GameObject FishModel = Instantiate(m_fishParamList[i].GetModel(), Position.transform.position, Quaternion.identity);
            FishModel.transform.localScale = new Vector3(50.0f, 50.0f, 50.0f);
        }
    }
}
