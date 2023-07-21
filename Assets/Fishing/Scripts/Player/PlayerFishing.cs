using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFishing : MonoBehaviour
{
    [SerializeField, Header("釣り竿オブジェクト")]
    GameObject FishingRod;
    [SerializeField, Header("カメラ")]
    GameObject GameCamera;
    [SerializeField, Header("基礎力")]
    float DefaultPower = 50.0f;
    [SerializeField, Header("乱数の最小値")]
    float RandomMin = 5.0f;
    [SerializeField, Header("乱数の最大値")]
    float RandomMax = 50.0f;
    [SerializeField, Header("チャージ速度(最小値)")]
    float ChargeSpeedMin = 1.0f;
    [SerializeField, Header("チャージ速度(最大値)")]
    float ChargeSpeedMax = 1.0f;
    [SerializeField, Header("敵の攻撃速度(最小値)")]
    float EnemyAttackSpeedMin = 1.0f;
    [SerializeField, Header("敵の攻撃速度(最大値)")]
    float EnemyAttackSpeedMax = 1.0f;
    [SerializeField, Header("棒浮き")]
    GameObject StickFloat;
    [SerializeField, Header("ゲームUI")]
    GameObject GameCanvas;
    [SerializeField, Header("釣りのUI")]
    GameObject FishingCanvas;
    [SerializeField, Header("リザルトのUI")]
    GameObject ResultCanvas;
    [SerializeField, Header("プレイヤーのHP")]
    DrawPlayerStamina PlayerHP;
    [SerializeField, Header("さかなのHP")]
    DrawFishHP FishHP;
    [SerializeField, Header("魚の攻撃ゲージ")]
    Image m_enemyGaugeImage;
    [SerializeField, Header("Fade")]
    GameObject FadeCanvas;

    /// <summary>
    /// 釣りステート。
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

    GameObject      m_hitImageObject;           //ヒット画像。
    Image           m_gaugeImage;               //ゲージ画像。

    Vector3         m_fishingPos;               //浮きの座標。
    Vector3         m_playerPos;                //プレイヤーの座標。
    Vector3         m_bezierPos;
    Vector3[]       m_lerpPos = new Vector3[2];
    Vector3         m_cameraPos;
    FishingState    m_fishingState = FishingState.enState_Idle;

    bool            m_chargeGauge = false;      //ゲージをためるかどうか。
    float           m_power = 0.0f;             //ゲージのちから。
    float           m_timer = 0.0f;             //タイマー。
    float           m_randTimer = 0.0f;         //出現までの時間。
    float           m_gauge = 0.01f;            //チャージ。
    float           m_chargeSpeed = 0.0f;       //チャージ速度。
    float           m_enemyAttackTimer = 0.0f;  //攻撃時間。
    float           m_enemyAttackTimerMax = 0.0f;


    /// <summary>
    /// 釣りの開始処理。
    /// </summary>
    public void StartFishing(float gauge, Vector3 playerPos)
    {
        //釣り竿のアニメーションを設定。
        m_rodAnimator.SetBool("FishingFlag", true);

        //力を設定。
        m_power = gauge;

        //プレイヤーの座標を設定。
        m_playerPos = playerPos;

        //時間を初期化。
        m_timer = 0.0f;

        //ゲームUIを表示。
        GameCanvas.SetActive(false);

        m_randTimer = Random.Range(RandomMin, RandomMax);
    }

    /// <summary>
    /// 釣りの終了処理。
    /// </summary>
    public void EndFishing()
    {
        ////アニメーションを待機状態に遷移。
        //m_rodAnimator.SetBool("FishingFlag", false);

        ////表示状態を無効にする。
        //StickFloat.SetActive(false);

        ////待機ステートに遷移。
        //m_fishingState = FishingState.enState_Idle;

        ////HPを最大にする。
        //PlayerHP.SetMaxHP();

        ////魚をリセット。
        //FishHP.Reset();

        ////ゲームUIを表示。
        //GameCanvas.SetActive(true);

        ////釣りUIを非表示。
        //FishingCanvas.SetActive(false);

        ////釣り終了を通知。
        //m_playerMove.NotifyEndFishing();

        //フェードオブジェクトを生成
        GameObject fadeCanvas = Instantiate(FadeCanvas);
        //フェードを開始
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

        //攻撃速度を設定。
        m_enemyAttackTimer = Random.Range(EnemyAttackSpeedMin, EnemyAttackSpeedMax);
        m_enemyAttackTimerMax = m_enemyAttackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_fishingState)
        {
            //投げステートなら。
            case FishingState.enState_Throwing:

                //ベジェ曲線を利用して浮きを投げる。
                m_lerpPos[0] = Vector3.Lerp(m_playerPos, m_bezierPos, m_timer * 2.0f);
                m_lerpPos[1] = Vector3.Lerp(m_bezierPos, m_fishingPos, m_timer * 2.0f);
                StickFloat.transform.position = Vector3.Lerp(m_lerpPos[0], m_lerpPos[1], m_timer * 2.0f);

                //カメラの移動と回転。
                GameCamera.transform.position = Vector3.Lerp(m_cameraPos, m_fishingPos / 2.0f, m_timer);
                GameCamera.transform.LookAt(m_fishingPos);

                m_timer += Time.deltaTime;

                if (m_timer > 1.0f)
                {
                    m_fishingState = FishingState.enState_Waiting;
                }
                break;

            //釣り待ちステートなら。
            case FishingState.enState_Waiting:

                m_randTimer -= Time.deltaTime;

                //左クリックが押されたら。
                if (Input.GetMouseButtonDown(0))
                {
                    //釣り終了を通知。
                    EndFishing();
                }

                if (m_randTimer < 0.0f)
                {
                    m_fishingState = FishingState.enState_Appear;

                    m_timer = 1.0f;

                    //浮きを少し沈める。
                    Vector3 stickPos = StickFloat.transform.position;
                    stickPos.y -= 0.1f;
                    StickFloat.transform.position = stickPos;
                }
                break;

            //かかったステートなら。
            case FishingState.enState_Appear:

                m_timer -= Time.deltaTime;

                //左クリックが押されたら。
                if (Input.GetMouseButtonDown(0))
                {
                    //戦闘開始ステートへ遷移。
                    m_fishingState = FishingState.enState_Battle;

                    FishingCanvas.SetActive(true);
                    Invoke("DisableHitImage", 2.0f);
                }

                if (m_timer < 0.0f)
                {
                    //釣り終了を通知。
                    EndFishing();
                }

                //浮きを上げていく。
                Vector3 stickPos2 = StickFloat.transform.position;
                stickPos2.y += m_timer * 0.001f;
                StickFloat.transform.position = stickPos2;
                break;

            //戦闘ステートなら。
            case FishingState.enState_Battle:

                BattleScene();
                break;

            //待機ステートなら。
            case FishingState.enState_Idle:
                break;
        }
    }

    void BattleScene()
    {
        //チャージ状態なら。
        if(m_chargeGauge)
        {
            //左クリックが離されたら。
            if (Input.GetMouseButtonUp(0))
            {
                //チャージ終了。
                m_chargeGauge = false;

                //ダメージを与える。
                FishHP.HealthDecrease((int)(m_gauge * 10.0f));

                //HPが0なら。
                if(FishHP.GetHP() <= 0)
                {
                    //釣りUIを非表示。
                    FishingCanvas.SetActive(false);

                    //リザルトUIを表示。
                    ResultCanvas.SetActive(true);

                    //終了ステートへ遷移。
                    m_fishingState = FishingState.enState_End;
                }

                //値とゲージをリセット。
                m_gauge = 0.01f;
                m_gaugeImage.fillAmount = m_gauge;
            }

            m_gauge += Time.deltaTime * m_gauge * m_chargeSpeed;

            if (m_gauge > 1.0f)
            {
                m_gauge = 0.01f;

                //チャージ速度を計算。
                m_chargeSpeed = Random.Range(ChargeSpeedMin, ChargeSpeedMax);
            }

            m_gaugeImage.fillAmount = m_gauge;
        }
        else
        {
            //左クリックが押されたら。
            if (Input.GetMouseButtonDown(0))
            {
                //チャージ開始。
                m_chargeGauge = true;

                //チャージ速度を計算。
                m_chargeSpeed = Random.Range(ChargeSpeedMin, ChargeSpeedMax);
            }
        }


        EnemyAttack();
    }

    /// <summary>
    /// 敵の攻撃処理。
    /// </summary>
    void EnemyAttack()
    {
        m_enemyAttackTimer -= Time.deltaTime;

        if (m_enemyAttackTimer < 0.0f)
        {
            //攻撃速度を設定。
            m_enemyAttackTimer = Random.Range(EnemyAttackSpeedMin, EnemyAttackSpeedMax);
            m_enemyAttackTimerMax = m_enemyAttackTimer;

            //ダメージを受ける。
            if (m_chargeGauge)
            {
                //チャージ中なら二倍。
                PlayerHP.StaminaDecrease(FishHP.GetPower() * 2);
            }
            else
            {
                PlayerHP.StaminaDecrease(FishHP.GetPower());
            }

            if(PlayerHP.GetHP() <= 0)
            {
                //釣り終了を通知。
                EndFishing();
            }
        }

        //ゲージを設定。
        m_enemyGaugeImage.fillAmount = 1.0f - (m_enemyAttackTimer / m_enemyAttackTimerMax);
    }

    /// <summary>
    /// 浮きを投げる処理。
    /// </summary>
    void ThrowStickFloat()
    {
        //浮きの座標を設定。
        m_fishingPos = transform.forward * m_power * DefaultPower;
        //プレイヤーと浮きの間の座標を設定。
        m_bezierPos = (m_fishingPos - m_playerPos) / 2.0f;
        //少し上にする。
        m_bezierPos.y += 3.0f;

        //カメラ座標を設定。
        m_cameraPos = GameCamera.transform.position;
        m_cameraPos.y += 3.0f;

        //表示状態を有効にする。
        StickFloat.SetActive(true);

        //投げるステートに遷移。
        m_fishingState = FishingState.enState_Throwing;
    }

    /// <summary>
    /// ヒット画像の無効処理。
    /// </summary>
    void DisableHitImage()
    {
        m_hitImageObject.SetActive(false);
    }
}
