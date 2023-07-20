using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class DrawFishHP : MonoBehaviour
{
    [SerializeField, Header("�ϋv�l")]
    int                 Health;
    [SerializeField, Header("�ϋv�l�̃e�L�X�g")]
    TextMeshProUGUI     HPText;

    int                 m_number;             // ���ʔԍ�

    int                 m_healthMax;         // �ő�l
    const int           HEALTH_MIN = 0;      // �ŏ��l

    bool                m_canFising = false; // �ނ�邩�ǂ���

    List<FishParameter> m_fishParamList;

    // �ԍ���ݒ�
    public void SetNumber(int num)
    {
        m_number = num;
    }
    // �ԍ����Q�Ƃ���
    public int GetNumber()
    {
        return m_number;
    }

    // Start is called before the first frame update
    void Start()
    {
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

            // �ϋv�l��ݒ�
            m_healthMax = m_fishParamList[i].GetHealth();
            Health = m_fishParamList[i].GetHealth();

            break;
        }

        // �ϋv�l��\��
        HPText.text = (Health + "/" + m_healthMax);
    }

    private void Update()
    {
        // �ϋv�l�� 0 �̂Ƃ�
        if (Health <= HEALTH_MIN)
        {
            m_canFising = true;
            return;
        }

        // �ϋv�l��\��
        HPText.text = (Health + "/" + m_healthMax);
    }

    public void HealthDecrease(int damege)
    {
        // �ϋv�l������������
        Health -= damege;
    }

}
