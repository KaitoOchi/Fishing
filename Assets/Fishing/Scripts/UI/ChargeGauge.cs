using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeGauge : MonoBehaviour
{
    [SerializeField, Header("ゲージ速度")]
    float ChargeSpeed = 10.0f;

    Image       m_image;                //画像。
    PlayerMove  m_playerMove;           //PlayerMove。
    bool        m_isReverse = false;    //反転するかどうか。
    bool        m_isStop = false;       //停止状態か。
    float       m_gauge = 0.01f;        //ゲージ。

    /// <summary>
    /// PlayerMoveを設定。
    /// </summary>
    /// <param name="playerMove"></param>
    public void SetPlayerMove(PlayerMove playerMove)
    {
        m_playerMove = playerMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_image = transform.GetChild(1).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isStop)
        {
            return;
        }

        if(m_isReverse)
        {
            m_gauge -= Time.deltaTime * ChargeSpeed * m_gauge;
        }
        else
        {
            m_gauge += Time.deltaTime * ChargeSpeed * m_gauge;
        }

        //一定範囲を超えたら。
        if (m_gauge < 0.01f || m_gauge > 1.0f)
        {
            m_isReverse = !m_isReverse;

            m_gauge = Mathf.Clamp(m_gauge, 0.01f, 1.0f);
        }

        //画像を設定。
        m_image.fillAmount = m_gauge;

        if(Input.GetMouseButtonUp(1))
        {
            //釣りの開始を通知。
            //gaugeを1.0～2.0の間にする。
            m_playerMove.NotifyStartFishing(m_gauge + 1.0f);

            //一定時間後に削除する。
            Invoke("DeleteThisObject", 1.75f);

            m_isStop = true;
        }
    }

    void DeleteThisObject()
    {
        Destroy(gameObject);
    }
}
