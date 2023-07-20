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
    [SerializeField, Header("�_����")]
    GameObject StickFloat;

    enum FishingState
    {
        enState_Throwing,
        enState_Idle,
    }


    Animator        m_rodAnimator;
    PlayerMove      m_playerMove;
    Vector3         m_fishingPos;               //�����̍��W�B
    Vector3         m_playerPos;                //�v���C���[�̍��W�B
    Vector3         m_bezierPos;
    Vector3[]       m_lerpPos = new Vector3[2];
    Vector3[]       m_cameraPos = new Vector3[2];
    FishingState    m_fishingState = FishingState.enState_Idle;

    float           m_power = 0.0f;             //�Q�[�W�̂�����B
    float           m_timer = 0.0f;             //�^�C�}�[�B


    /// <summary>
    /// �ނ�̊J�n�����B
    /// </summary>
    public void StartFishing(float gauge, Vector3 playerPos)
    {
        //�ނ�Ƃ̃A�j���[�V������ݒ�B
        m_rodAnimator.SetBool("FishingFlag", true);

        //�͂�ݒ�B
        m_power = gauge;

        //�v���C���[�̍��W��ݒ�B
        m_playerPos = playerPos;

        //���Ԃ��������B
        m_timer = 0.0f;

        Debug.Log(m_power);
        Invoke("EndFishing", 5.0f);
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
        switch (m_fishingState)
        {
            case FishingState.enState_Throwing:

                //�x�W�F�Ȑ��𗘗p���ĕ����𓊂���B
                m_lerpPos[0] = Vector3.Lerp(m_playerPos, m_bezierPos, m_timer);
                m_lerpPos[1] = Vector3.Lerp(m_bezierPos, m_fishingPos, m_timer);
                StickFloat.transform.position = Vector3.Lerp(m_lerpPos[0], m_lerpPos[1], m_timer);

                //�J�������ړ��B
                GameCamera.transform.position = Vector3.Lerp(m_cameraPos, m_fishingPos, m_timer);

                m_timer += Time.deltaTime * 2.0f;
                break;

            case FishingState.enState_Idle:
                break;
        }
    }

    /// <summary>
    /// �ނ�̏I�������B
    /// </summary>
    void EndFishing()
    {
        //�A�j���[�V������ҋ@��ԂɑJ�ځB
        m_rodAnimator.SetBool("FishingFlag", false);

        //�\����Ԃ𖳌��ɂ���B
        StickFloat.SetActive(false);

        //�ҋ@�X�e�[�g�ɑJ�ځB
        m_fishingState = FishingState.enState_Idle;

        //�ނ�I����ʒm�B
        m_playerMove.NotifyEndFishing();
    }

    /// <summary>
    /// �����𓊂��鏈���B
    /// </summary>
    void ThrowStickFloat()
    {
        //�����̍��W��ݒ�B
        m_fishingPos = transform.forward * m_power * DefaultPower;
        //�v���C���[�ƕ����̊Ԃ̍��W��ݒ�B
        m_bezierPos = (m_fishingPos - m_playerPos) / 2.0f;
        //������ɂ���B
        m_bezierPos.y += 3.0f;

        //�J�������W��ݒ�B
        m_cameraPos[0] = GameCamera.transform.position;
        m_cameraPos[1] = m_fishingPos;


        //�\����Ԃ�L���ɂ���B
        StickFloat.SetActive(true);

        //������X�e�[�g�ɑJ�ځB
        m_fishingState = FishingState.enState_Throwing;
    }
}
