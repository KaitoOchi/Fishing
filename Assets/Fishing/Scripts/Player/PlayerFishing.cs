using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{
    [SerializeField, Header("�ނ�ƃI�u�W�F�N�g")]
    GameObject FishingRod;
    [SerializeField, Header("�J����")]
    GameObject GameCamera;
    [SerializeField, Header("��b��")]
    float DefaultPower = 50.0f;

    public GameObject testCube;

    Animator    m_rodAnimator;
    PlayerMove  m_playerMove;
    Vector3     m_fishingPos;

    bool        m_isFishing = false;       //�ނ��Ԃ��ǂ���
    float       power = 0.0f;               //�Q�[�W�̂�����B


    /// <summary>
    /// �ނ�̊J�n�����B
    /// </summary>
    public void StartFishing(float gauge)
    {
        //�ނ�Ƃ̃A�j���[�V������ݒ�B
        m_rodAnimator.SetBool("FishingFlag", true);

        //�͂�ݒ�B
        power = gauge;

        Debug.Log(power);


        Invoke("EndFishing", 5.0f);

        m_fishingPos = transform.forward * power * DefaultPower;
        testCube.transform.position = m_fishingPos;
    }


    // Start is called before the first frame update
    void Start()
    {
        m_rodAnimator = FishingRod.GetComponent<Animator>();

        m_playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_isFishing)
        {
            return;
        }
    }

    void EndFishing()
    {
        Debug.Log("END");

        m_rodAnimator.SetBool("FishingFlag", false);

        m_playerMove.NotifyEndFishing();
    }
}
