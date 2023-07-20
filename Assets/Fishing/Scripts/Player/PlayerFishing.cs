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

    public GameObject testCube;

    Animator    m_rodAnimator;
    PlayerMove  m_playerMove;
    Vector3     m_fishingPos;

    bool        m_isFishing = false;       //釣り状態かどうか
    float       power = 0.0f;               //ゲージのちから。


    /// <summary>
    /// 釣りの開始処理。
    /// </summary>
    public void StartFishing(float gauge)
    {
        //釣り竿のアニメーションを設定。
        m_rodAnimator.SetBool("FishingFlag", true);

        //力を設定。
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
