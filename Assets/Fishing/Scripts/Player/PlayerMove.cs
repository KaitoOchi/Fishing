using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Header("�ړ����x")]
    float Speed = 1.0f;
    [SerializeField, Header("��x�ɂ����]��")]
    float RotateStep = 1.0f;
    [SerializeField, Header("�J����")]
    GameObject GameCamera;
    [SerializeField, Header("�`���[�W�摜")]
    GameObject ChargeCanvas;
    [SerializeField, Header("Fade")]
    GameObject FadeCanvas;

    [SerializeField, Header("�a�摜")]
    Image FeedImage1;
    [SerializeField, Header("�a�摜")]
    Image FeedImage2;
    [SerializeField, Header("�a�摜")]
    Image FeedImage3;


    /// <summary>
    /// �v���C���[�X�e�[�g�B
    /// </summary>
    enum PlayerState
    {
        enState_Idle,
        enState_Walk,
        enState_Fishing,
    }

    Rigidbody       m_rigidbody;            //Rigidbody�B
    Animator        m_animator;             //Animator�B
    PlayerFishing   m_playerFishing;

    Vector3         m_moveSpeed;            //�ړ����x�B
    PlayerState     m_playerState;          //�v���C���[�X�e�[�g�B
    bool            m_cursorLock = true;    //�J�[�\���̃��b�N��ԁB
    int             m_feed = 0;             //�g�p����a�B
    int[]           m_feedNum = new int[3];


    /// <summary>
    /// �J�[�\���̃��b�N��Ԃ��擾�B
    /// </summary>
    /// <returns></returns>
    public bool GetCursorLock()
    {
        return m_cursorLock;
    }

    /// <summary>
    /// �������Ԃ��ǂ������擾�B
    /// </summary>
    /// <returns></returns>
    public bool GetCanMove()
    {
        return m_playerState != PlayerState.enState_Fishing;
    }

    /// <summary>
    /// �ނ�̊J�n��ʒm�B
    /// </summary>
    public void NotifyStartFishing(float gauge)
    {
        //�ނ�J�n��Ԃɂ���B
        m_animator.SetBool("FishingFlag", true);

        m_playerFishing.StartFishing(gauge, transform.position);
    }

    /// <summary>
    /// �ނ�̏I����ʒm�B
    /// </summary>
    public void NotifyEndFishing()
    {
        //�ҋ@��Ԃ֑J�ځB
        m_playerState = PlayerState.enState_Idle;

        //�ނ�I����Ԃɂ���B
        m_animator.SetBool("FishingFlag", false);
        //�ҋ@��Ԃɂ���B
        m_animator.SetBool("MoveFlag", false);
    }


    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();

        m_playerFishing = GetComponent<PlayerFishing>();

        //�J�[�\�������b�N��Ԃɂ���B
        Cursor.lockState = CursorLockMode.Locked;

        //�Z�[�u�f�[�^���擾�B
        SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();

        for(int i = 0; i < 3; i++)
        {
            m_feedNum[i] = saveManager.GetSaveData().saveData.feed[i];
        }
    }

    private void FixedUpdate()
    {
        if (!GetCursorLock())
        {
            return;
        }

        Move();

        Rotation();

        State();
    }

    private void Update()
    {
        UpdateCursorLock();

        InputKey();
    }

    /// <summary>
    /// �ړ������B
    /// </summary>
    void Move()
    {
        if (!GetCanMove())
        {
            return;
        }

        //�ړ����x�ƕ������������B
        m_moveSpeed = Vector3.zero;
        Vector3 moveDirection = Vector3.zero;

        //�ړ���������́B
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        //�J�������l�������ړ��B
        Vector3 forward = GameCamera.transform.forward;
        Vector3 right = GameCamera.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        forward *= moveDirection.z;
        right *= moveDirection.x;

        //�ړ����x�ɏ�L�Ōv�Z�����x�N�g�������킹��B
        m_moveSpeed += forward + right;
        //���K������B
        m_moveSpeed.Normalize();

        //�ړ������ƈړ����x�����킹��B
        m_moveSpeed *= Speed;

        //�ړ������ɗ͂�������B
        m_rigidbody.AddForce(m_moveSpeed, ForceMode.Acceleration);
    }

    /// <summary>
    /// ��]�����B
    /// </summary>
    void Rotation()
    {
        if (!GetCanMove())
        {
            return;
        }

        //���͂��������Ȃ�B
        if (m_moveSpeed.sqrMagnitude > 0.0f)
        {
            //�v���C���[�̕����։�]����B
            Quaternion rot = Quaternion.LookRotation(m_moveSpeed);

            //��]�����X�ɗ^����B
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, RotateStep);
        }
    }

    /// <summary>
    /// ���͏����B
    /// </summary>
    void InputKey()
    {
        if(!GetCanMove())
        {
            return;
        }

        //���N���b�N�����͂��ꂽ��B
        if(Input.GetMouseButtonDown(1))
        {
            if(m_feedNum[m_feed] <= 0)
            {
                return;
            }

            SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();
            m_feedNum[m_feed]--;
            saveManager.GetSaveData().saveData.feed[m_feed] = m_feedNum[m_feed];

            //�ނ�X�e�[�g�֑J�ځB
            m_playerState = PlayerState.enState_Fishing;

            GameObject obj = Instantiate(ChargeCanvas);
            obj.GetComponent<ChargeGauge>().SetPlayerMove(this);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //�t�F�[�h�I�u�W�F�N�g�𐶐�
            GameObject fadeCanvas = Instantiate(FadeCanvas);

            //�t�F�[�h���J�n
            fadeCanvas.GetComponent<FadeScene>().FadeStart("MainMenu");
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            FeedImage1.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            FeedImage2.color = new Vector4(1.0f, 1.0f, 1.0f, 0.2f);
            FeedImage3.color = new Vector4(1.0f, 1.0f, 1.0f, 0.2f);
            m_feed = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FeedImage1.color = new Vector4(1.0f, 1.0f, 1.0f, 0.2f);
            FeedImage2.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            FeedImage3.color = new Vector4(1.0f, 1.0f, 1.0f, 0.2f);
            m_feed = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FeedImage1.color = new Vector4(1.0f, 1.0f, 1.0f, 0.2f);
            FeedImage2.color = new Vector4(1.0f, 1.0f, 1.0f, 0.2f);
            FeedImage3.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            m_feed = 2;
        }
    }

    /// <summary>
    /// �X�e�[�g�����B
    /// </summary>
    void State()
    {
        switch (m_playerState)
        {
        case PlayerState.enState_Idle:
                ProcessCommonState();
            break;

        case PlayerState.enState_Walk:
                ProcessCommonState();
            break;

        case PlayerState.enState_Fishing:
                ProcessFishingStateTransition();
            break;
        }

    }

    /// <summary>
    /// �X�e�[�g�̋��ʏ����B
    /// </summary>
    void ProcessCommonState()
    {
        switch (m_playerState)
        {
            case PlayerState.enState_Idle:

                if (m_moveSpeed.sqrMagnitude > 0.0f)
                {
                    //�ړ���Ԃɂ���B
                    m_animator.SetBool("MoveFlag", true);
                    m_playerState = PlayerState.enState_Walk;
                }
                break;

            case PlayerState.enState_Walk:

                if (m_moveSpeed.sqrMagnitude == 0.0f)
                {
                    //�ҋ@��Ԃɂ���B
                    m_animator.SetBool("MoveFlag", false);
                    m_playerState = PlayerState.enState_Idle;
                }
                break;

            case PlayerState.enState_Fishing:

                break;
        }
    }

    /// <summary>
    /// �ނ�X�e�[�g�̑J�ڏ����B
    /// </summary>
    void ProcessFishingStateTransition()
    {
    }

    /// <summary>
    /// �J�[�\���̌Œ菈���B
    /// </summary>
    void UpdateCursorLock()
    {
        if (m_cursorLock)
        {
            //Esc�������ꂽ�烍�b�N�����B
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                m_cursorLock = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            //�}�E�X�̓��͂Ń��b�N�B
            if (Input.GetMouseButton(0))
            {
                m_cursorLock = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
