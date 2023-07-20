using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeGauge : MonoBehaviour
{

    Image       m_image;            //�摜�B
    PlayerMove  m_playerMove;       //PlayerMove�B
    bool        m_isReverse;        //���]���邩�ǂ����B
    float       m_gauge = 0.0f;     //�Q�[�W�B

    /// <summary>
    /// PlayerMove��ݒ�B
    /// </summary>
    /// <param name="playerMove"></param>
    public void SetPlayerMove(PlayerMove playerMove)
    {
        m_playerMove = playerMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_image = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isReverse)
        {
            m_gauge -= Time.deltaTime;
        }
        else
        {
            m_gauge += Time.deltaTime;
        }

        //���͈͂𒴂�����B
        if (m_gauge < 0.0f || m_gauge > 1.0f)
        {
            m_isReverse = !m_isReverse;
        }

        //�摜��ݒ�B
        m_image.fillAmount = m_gauge;

        if(Input.GetMouseButtonUp(1))
        {
            //�ނ�̊J�n��ʒm�B
            m_playerMove.NotifyStartFishing(m_gauge);

            Destroy(gameObject);
        }
    }
}
