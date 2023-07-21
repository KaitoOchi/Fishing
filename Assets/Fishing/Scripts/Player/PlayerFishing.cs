using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFishing : MonoBehaviour
{
    [SerializeField, Header("�ނ�ƃI�u�W�F�N�g")]
    GameObject FishingRod;
    [SerializeField, Header("�J����")]
    GameObject GameCamera;
    [SerializeField, Header("��b��")]
    float DefaultPower = 50.0f;
    [SerializeField, Header("�����̍ŏ��l")]
    float RandomMin = 5.0f;
    [SerializeField, Header("�����̍ő�l")]
    float RandomMax = 50.0f;
    [SerializeField, Header("�`���[�W���x(�ŏ��l)")]
    float ChargeSpeedMin = 1.0f;
    [SerializeField, Header("�`���[�W���x(�ő�l)")]
    float ChargeSpeedMax = 1.0f;
    [SerializeField, Header("�G�̍U�����x(�ŏ��l)")]
    float EnemyAttackSpeedMin = 1.0f;
    [SerializeField, Header("�G�̍U�����x(�ő�l)")]
    float EnemyAttackSpeedMax = 1.0f;
    [SerializeField, Header("�_����")]
    GameObject StickFloat;
    [SerializeField, Header("�Q�[��UI")]
    GameObject GameCanvas;
    [SerializeField, Header("�ނ��UI")]
    GameObject FishingCanvas;
    [SerializeField, Header("���U���g��UI")]
    GameObject ResultCanvas;
    [SerializeField, Header("�v���C���[��HP")]
    DrawPlayerStamina PlayerHP;
    [SerializeField, Header("�����Ȃ�HP")]
    DrawFishHP FishHP;
    [SerializeField, Header("���̍U���Q�[�W")]
    Image m_enemyGaugeImage;
    [SerializeField, Header("Fade")]
    GameObject FadeCanvas;

    /// <summary>
    /// �ނ�X�e�[�g�B
    /// </summary>
    enum FishingState
    {
        enState_Throwing,
        enState_Waiting,
        enState_Appear,
        enState_Battle,
        enState_End,
        enState_Idle,
    }


    Animator        m_rodAnimator;
    PlayerMove      m_playerMove;

    GameObject      m_hitImageObject;           //�q�b�g�摜�B
    Image           m_gaugeImage;               //�Q�[�W�摜�B

    Vector3         m_fishingPos;               //�����̍��W�B
    Vector3         m_playerPos;                //�v���C���[�̍��W�B
    Vector3         m_bezierPos;
    Vector3[]       m_lerpPos = new Vector3[2];
    Vector3         m_cameraPos;
    FishingState    m_fishingState = FishingState.enState_Idle;

    bool            m_chargeGauge = false;      //�Q�[�W�����߂邩�ǂ����B
    float           m_power = 0.0f;             //�Q�[�W�̂�����B
    float           m_timer = 0.0f;             //�^�C�}�[�B
    float           m_randTimer = 0.0f;         //�o���܂ł̎��ԁB
    float           m_gauge = 0.01f;            //�`���[�W�B
    float           m_chargeSpeed = 0.0f;       //�`���[�W���x�B
    float           m_enemyAttackTimer = 0.0f;  //�U�����ԁB
    float           m_enemyAttackTimerMax = 0.0f;


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

        //�Q�[��UI��\���B
        GameCanvas.SetActive(false);

        m_randTimer = Random.Range(RandomMin, RandomMax);
    }

    /// <summary>
    /// �ނ�̏I�������B
    /// </summary>
    public void EndFishing()
    {
        ////�A�j���[�V������ҋ@��ԂɑJ�ځB
        //m_rodAnimator.SetBool("FishingFlag", false);

        ////�\����Ԃ𖳌��ɂ���B
        //StickFloat.SetActive(false);

        ////�ҋ@�X�e�[�g�ɑJ�ځB
        //m_fishingState = FishingState.enState_Idle;

        ////HP���ő�ɂ���B
        //PlayerHP.SetMaxHP();

        ////�������Z�b�g�B
        //FishHP.Reset();

        ////�Q�[��UI��\���B
        //GameCanvas.SetActive(true);

        ////�ނ�UI���\���B
        //FishingCanvas.SetActive(false);

        ////�ނ�I����ʒm�B
        //m_playerMove.NotifyEndFishing();

        //�t�F�[�h�I�u�W�F�N�g�𐶐�
        GameObject fadeCanvas = Instantiate(FadeCanvas);
        //�t�F�[�h���J�n
        fadeCanvas.GetComponent<FadeScene>().FadeStart("Game");

        Destroy(this);
    }


    // Start is called before the first frame update
    void Start()
    {
        m_rodAnimator = FishingRod.GetComponent<Animator>();
        m_playerMove = GetComponent<PlayerMove>();

        m_hitImageObject = FishingCanvas.transform.GetChild(2).gameObject;
        m_gaugeImage = FishingCanvas.transform.GetChild(5).GetComponent<Image>();

        //�U�����x��ݒ�B
        m_enemyAttackTimer = Random.Range(EnemyAttackSpeedMin, EnemyAttackSpeedMax);
        m_enemyAttackTimerMax = m_enemyAttackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_fishingState)
        {
            //�����X�e�[�g�Ȃ�B
            case FishingState.enState_Throwing:

                //�x�W�F�Ȑ��𗘗p���ĕ����𓊂���B
                m_lerpPos[0] = Vector3.Lerp(m_playerPos, m_bezierPos, m_timer * 2.0f);
                m_lerpPos[1] = Vector3.Lerp(m_bezierPos, m_fishingPos, m_timer * 2.0f);
                StickFloat.transform.position = Vector3.Lerp(m_lerpPos[0], m_lerpPos[1], m_timer * 2.0f);

                //�J�����̈ړ��Ɖ�]�B
                GameCamera.transform.position = Vector3.Lerp(m_cameraPos, m_fishingPos / 2.0f, m_timer);
                GameCamera.transform.LookAt(m_fishingPos);

                m_timer += Time.deltaTime;

                if (m_timer > 1.0f)
                {
                    m_fishingState = FishingState.enState_Waiting;
                }
                break;

            //�ނ�҂��X�e�[�g�Ȃ�B
            case FishingState.enState_Waiting:

                m_randTimer -= Time.deltaTime;

                //���N���b�N�������ꂽ��B
                if (Input.GetMouseButtonDown(0))
                {
                    //�ނ�I����ʒm�B
                    EndFishing();
                }

                if (m_randTimer < 0.0f)
                {
                    m_fishingState = FishingState.enState_Appear;

                    m_timer = 1.0f;

                    //�������������߂�B
                    Vector3 stickPos = StickFloat.transform.position;
                    stickPos.y -= 0.1f;
                    StickFloat.transform.position = stickPos;
                }
                break;

            //���������X�e�[�g�Ȃ�B
            case FishingState.enState_Appear:

                m_timer -= Time.deltaTime;

                //���N���b�N�������ꂽ��B
                if (Input.GetMouseButtonDown(0))
                {
                    //�퓬�J�n�X�e�[�g�֑J�ځB
                    m_fishingState = FishingState.enState_Battle;

                    FishingCanvas.SetActive(true);
                    Invoke("DisableHitImage", 2.0f);
                }

                if (m_timer < 0.0f)
                {
                    //�ނ�I����ʒm�B
                    EndFishing();
                }

                //�������グ�Ă����B
                Vector3 stickPos2 = StickFloat.transform.position;
                stickPos2.y += m_timer * 0.001f;
                StickFloat.transform.position = stickPos2;
                break;

            //�퓬�X�e�[�g�Ȃ�B
            case FishingState.enState_Battle:

                BattleScene();
                break;

            //�ҋ@�X�e�[�g�Ȃ�B
            case FishingState.enState_Idle:
                break;
        }
    }

    void BattleScene()
    {
        //�`���[�W��ԂȂ�B
        if(m_chargeGauge)
        {
            //���N���b�N�������ꂽ��B
            if (Input.GetMouseButtonUp(0))
            {
                //�`���[�W�I���B
                m_chargeGauge = false;

                //�_���[�W��^����B
                FishHP.HealthDecrease((int)(m_gauge * 10.0f));

                //HP��0�Ȃ�B
                if(FishHP.GetHP() <= 0)
                {
                    //�ނ�UI���\���B
                    FishingCanvas.SetActive(false);

                    //���U���gUI��\���B
                    ResultCanvas.SetActive(true);

                    //�I���X�e�[�g�֑J�ځB
                    m_fishingState = FishingState.enState_End;
                }

                //�l�ƃQ�[�W�����Z�b�g�B
                m_gauge = 0.01f;
                m_gaugeImage.fillAmount = m_gauge;
            }

            m_gauge += Time.deltaTime * m_gauge * m_chargeSpeed;

            if (m_gauge > 1.0f)
            {
                m_gauge = 0.01f;

                //�`���[�W���x���v�Z�B
                m_chargeSpeed = Random.Range(ChargeSpeedMin, ChargeSpeedMax);
            }

            m_gaugeImage.fillAmount = m_gauge;
        }
        else
        {
            //���N���b�N�������ꂽ��B
            if (Input.GetMouseButtonDown(0))
            {
                //�`���[�W�J�n�B
                m_chargeGauge = true;

                //�`���[�W���x���v�Z�B
                m_chargeSpeed = Random.Range(ChargeSpeedMin, ChargeSpeedMax);
            }
        }


        EnemyAttack();
    }

    /// <summary>
    /// �G�̍U�������B
    /// </summary>
    void EnemyAttack()
    {
        m_enemyAttackTimer -= Time.deltaTime;

        if (m_enemyAttackTimer < 0.0f)
        {
            //�U�����x��ݒ�B
            m_enemyAttackTimer = Random.Range(EnemyAttackSpeedMin, EnemyAttackSpeedMax);
            m_enemyAttackTimerMax = m_enemyAttackTimer;

            //�_���[�W���󂯂�B
            if (m_chargeGauge)
            {
                //�`���[�W���Ȃ��{�B
                PlayerHP.StaminaDecrease(FishHP.GetPower() * 2);
            }
            else
            {
                PlayerHP.StaminaDecrease(FishHP.GetPower());
            }

            if(PlayerHP.GetHP() <= 0)
            {
                //�ނ�I����ʒm�B
                EndFishing();
            }
        }

        //�Q�[�W��ݒ�B
        m_enemyGaugeImage.fillAmount = 1.0f - (m_enemyAttackTimer / m_enemyAttackTimerMax);
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
        m_cameraPos = GameCamera.transform.position;
        m_cameraPos.y += 3.0f;

        //�\����Ԃ�L���ɂ���B
        StickFloat.SetActive(true);

        //������X�e�[�g�ɑJ�ځB
        m_fishingState = FishingState.enState_Throwing;
    }

    /// <summary>
    /// �q�b�g�摜�̖��������B
    /// </summary>
    void DisableHitImage()
    {
        m_hitImageObject.SetActive(false);
    }
}
