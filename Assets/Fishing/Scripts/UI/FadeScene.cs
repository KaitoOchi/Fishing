using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{
    [SerializeField, Header("フェードの速度")]
    float FadeSpeed = 1.0f;

    enum FadeState
    {
        enState_FadeIn,
        enState_FadeOut,
        enState_Idle
    }
    FadeState m_fadeState = FadeState.enState_Idle;

    Image m_image;            //フェードに使用する画像
    string m_sceneName;        //遷移先のシーン名
    float m_alpha = 0.0f;     //透明度

    public void FadeStart(string sceneName)
    {
        //フェードを開始する
        m_fadeState = FadeState.enState_FadeOut;
        m_sceneName = sceneName;

        //自身の子オブジェクトにアタッチされているImageを取得
        m_image = transform.GetChild(0).GetComponent<Image>();

        //自身はシーンをまたいでも削除されないようにする
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //待機状態なら、何もしない
        if (m_fadeState == FadeState.enState_Idle)
        {
            return;
        }

        switch (m_fadeState)
        {
            //フェードインなら、画面を明るくする
            case FadeState.enState_FadeIn:
                m_alpha -= FadeSpeed * Time.deltaTime;

                if (m_alpha < 0.0f)
                {
                    Destroy(gameObject);
                }
                break;

            //フェードアウトなら、画面を暗くする
            case FadeState.enState_FadeOut:
                m_alpha += FadeSpeed * Time.deltaTime;

                if (m_alpha > 1.0f)
                {
                    SceneManager.LoadScene(m_sceneName);
                    m_fadeState = FadeState.enState_FadeIn;
                }
                break;
        }

        //画像の透明度を設定
        Color nowColor = m_image.color;
        nowColor.a = m_alpha;
        m_image.color = nowColor;
    }
}