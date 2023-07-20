using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    float Speed = 1.0f;
    [SerializeField, Header("一度にする回転量")]
    float RotateStep = 1.0f;
    [SerializeField, Header("カメラ")]
    GameObject GameCamera;


    /// <summary>
    /// プレイヤーステート。
    /// </summary>
    enum PlayerState
    {
        enState_Idle,
        enState_Walk,
        enState_Fishing,
    }

    Rigidbody       m_rigidbody;            //Rigidbody。
    Animator        m_animator;             //Animator。

    Vector3         m_moveSpeed;            //移動速度。
    PlayerState     m_playerState;          //プレイヤーステート。
    bool            m_cursorLock = false;   //カーソルのロック状態。


    /// <summary>
    /// カーソルのロック状態を取得。
    /// </summary>
    /// <returns></returns>
    public bool GetCursorLock()
    {
        return m_cursorLock;
    }

    /// <summary>
    /// 動ける状態かどうかを取得。
    /// </summary>
    /// <returns></returns>
    public bool GetCanMove()
    {
        return m_playerState != PlayerState.enState_Fishing;
    }


    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();

        //カーソルをロック状態にする。
        Cursor.lockState = CursorLockMode.Locked;
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
    /// 移動処理。
    /// </summary>
    void Move()
    {
        if (!GetCanMove())
        {
            return;
        }

        //移動速度と方向を初期化。
        m_moveSpeed = Vector3.zero;
        Vector3 moveDirection = Vector3.zero;

        //移動方向を入力。
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        //カメラを考慮した移動。
        Vector3 forward = GameCamera.transform.forward;
        Vector3 right = GameCamera.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        forward *= moveDirection.z;
        right *= moveDirection.x;

        //移動速度に上記で計算したベクトルを合わせる。
        m_moveSpeed += forward + right;
        //正規化する。
        m_moveSpeed.Normalize();

        //移動方向と移動速度を合わせる。
        m_moveSpeed *= Speed;

        //移動方向に力を加える。
        m_rigidbody.AddForce(m_moveSpeed, ForceMode.Acceleration);
    }

    /// <summary>
    /// 回転処理。
    /// </summary>
    void Rotation()
    {
        if (!GetCanMove())
        {
            return;
        }

        //入力があったなら。
        if (m_moveSpeed.sqrMagnitude > 0.0f)
        {
            //プレイヤーの方向へ回転する。
            Quaternion rot = Quaternion.LookRotation(m_moveSpeed);

            //回転を徐々に与える。
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, RotateStep);
        }
    }

    /// <summary>
    /// 入力処理。
    /// </summary>
    void InputKey()
    {
        //左クリックが入力されたら。
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("A");

            //釣りステートに遷移。
            m_playerState = PlayerState.enState_Fishing;
        }
    }

    /// <summary>
    /// ステート処理。
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
    /// ステートの共通処理。
    /// </summary>
    void ProcessCommonState()
    {
        if(m_playerState == PlayerState.enState_Idle)
        {
            if (m_moveSpeed.sqrMagnitude > 0.0f)
            {
                //移動状態にする。
                m_animator.SetBool("MoveFlag", true);
                m_playerState = PlayerState.enState_Walk;
            }
        }
        else if(m_playerState == PlayerState.enState_Walk)
        {
            if (m_moveSpeed.sqrMagnitude == 0.0f)
            {
                //待機状態にする。
                m_animator.SetBool("MoveFlag", false);
                m_playerState = PlayerState.enState_Idle;
            }
        }
    }

    /// <summary>
    /// 釣りステートの遷移処理。
    /// </summary>
    void ProcessFishingStateTransition()
    {
        //ProcessCommonState();
    }

    /// <summary>
    /// カーソルの固定処理。
    /// </summary>
    void UpdateCursorLock()
    {
        if (m_cursorLock)
        {
            //Escが押されたらロック解除。
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                m_cursorLock = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            //マウスの入力でロック。
            if (Input.GetMouseButton(0))
            {
                m_cursorLock = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
