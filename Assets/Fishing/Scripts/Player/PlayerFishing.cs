using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{
    [SerializeField, Header("釣り竿オブジェクト")]
    GameObject FishingRod;
    [SerializeField, Header("カメラ")]
    GameObject GameCamera;
    [SerializeField, Header("基礎力")]
    float DefaultPower = 50.0f;
    [SerializeField, Header("棒浮き")]
    GameObject StickFloat;

    enum FishingState
    {
        enState_Throwing,
        enState_Idle,
    }


    Animator        m_rodAnimator;
    PlayerMove      m_playerMove;
    Vector3         m_fishingPos;               //浮きの座標。
    Vector3         m_playerPos;                //プレイヤーの座標。
    Vector3         m_bezierPos;
    Vector3[]       m_lerpPos = new Vector3[2];
    Vector3[]       m_cameraPos = new Vector3[2];
    FishingState    m_fishingState = FishingState.enState_Idle;

    float           m_power = 0.0f;             //ゲージのちから。
    float           m_timer = 0.0f;             //タイマー。


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

                //ベジェ曲線を利用して浮きを投げる。
                m_lerpPos[0] = Vector3.Lerp(m_playerPos, m_bezierPos, m_timer);
                m_lerpPos[1] = Vector3.Lerp(m_bezierPos, m_fishingPos, m_timer);
                StickFloat.transform.position = Vector3.Lerp(m_lerpPos[0], m_lerpPos[1], m_timer);

                //カメラを移動。
                GameCamera.transform.position = Vector3.Lerp(m_cameraPos, m_fishingPos, m_timer);

                m_timer += Time.deltaTime * 2.0f;
                break;

            case FishingState.enState_Idle:
                break;
        }
    }

    /// <summary>
    /// 釣りの終了処理。
    /// </summary>
    void EndFishing()
    {
        //アニメーションを待機状態に遷移。
        m_rodAnimator.SetBool("FishingFlag", false);

        //表示状態を無効にする。
        StickFloat.SetActive(false);

        //待機ステートに遷移。
        m_fishingState = FishingState.enState_Idle;

        //釣り終了を通知。
        m_playerMove.NotifyEndFishing();
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
        m_cameraPos[0] = GameCamera.transform.position;
        m_cameraPos[1] = m_fishingPos;


        //表示状態を有効にする。
        StickFloat.SetActive(true);

        //投げるステートに遷移。
        m_fishingState = FishingState.enState_Throwing;
    }
}
