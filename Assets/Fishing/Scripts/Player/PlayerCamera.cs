using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField, Header("感度")]
    float sensitivity = 3.0f;
    [SerializeField, Header("プレイヤー")]
    PlayerMove PlayerMove;


    GameObject  m_parentObject;     //親オブジェクト。
    Quaternion  m_cameraRot;        //カメラの回転。


    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクトを取得。
        m_parentObject = transform.parent.gameObject;

        //カメラの初期回転を取得。
        m_cameraRot = m_parentObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerMove.GetCursorLock())
        {
            return;
        }

        if(!PlayerMove.GetCanMove())
        {
            return;
        }

        //注視点をプレイヤーに合わせる。
        m_parentObject.transform.position = PlayerMove.transform.position;

        //マウスの入力。
        float xRot = Input.GetAxis("Mouse X") * sensitivity;

        //オイラー角を使用して角度を設定。
        m_cameraRot *= Quaternion.Euler(0, xRot, 0);

        m_parentObject.transform.localRotation = m_cameraRot;
    }
}
