using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrawFishHP : MonoBehaviour
{
    [SerializeField, Header("�ϋv�l")]
    int                 Health;
    [SerializeField, Header("�ϋv�l�̃e�L�X�g")]
    TextMeshProUGUI     HPText;

    int                 m_number;             // ���ʔԍ�
    int                 m_power = 0;            //�U���́B
    int                 m_feed = 0;
    int                 m_healthMax;         // �ő�l
    const int           HEALTH_MIN = 0;      // �ŏ��l

    List<FishParameter> m_fishParamList;
    List<FishParameter> m_finalFishParamList = new List<FishParameter>();
    Image m_hpImage;


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

    /// <summary>
    /// ���Z�b�g�����B
    /// </summary>
    public void Reset()
    {
        Start();
    }

    /// <summary>
    /// HP���擾�B
    /// </summary>
    /// <returns></returns>
    public int GetHP()
    {
        return Health;
    }

    /// <summary>
    /// �U���͂��擾�B
    /// </summary>
    /// <returns></returns>
    public int GetPower()
    {
        return m_power;
    }

    /// <summary>
    /// �a�̎�ނ�ݒ�B
    /// </summary>
    /// <param name="feed"></param>
    /// <returns></returns>
    public void SetFeed(int feed)
    {
        m_feed = feed;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResourceFishList fishList = FindObjectOfType<ResourceFishList>();
        m_fishParamList = fishList.GetFishList();

        int fishCount = m_fishParamList.Count;

        //���X�g���񂷁B
        for (int i = 0; i < fishCount; i++)
        {
            if((int)m_fishParamList[i].GetFishType() == m_feed)
            {
                m_finalFishParamList.Add(m_fishParamList[i]);
            }
        }

        fishCount = m_finalFishParamList.Count;

        m_number = Random.Range(0, fishCount);

        // �ϋv�l��ݒ�
        m_healthMax = m_finalFishParamList[m_number].GetHealth();
        Health = m_finalFishParamList[m_number].GetHealth();

        //�U���͂�ݒ�B
        m_power = m_finalFishParamList[m_number].GetRank() * 5;

        // �ϋv�l��\��
        HPText.text = (Health + "/" + m_healthMax);

        //HP�摜���擾�B
        m_hpImage = GetComponent<Image>();
    }

    private void Update()
    {

    }

    public void HealthDecrease(int damege)
    {
        // �ϋv�l������������
        Health -= damege;

        // �ϋv�l��\��
        HPText.text = (Health + "/" + m_healthMax);

        //�Q�[�W�������B
        float fill = (float)Health / (float)m_healthMax;
        m_hpImage.fillAmount = fill;
    }

}
