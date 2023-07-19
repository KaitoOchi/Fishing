using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{
    [SerializeField, Header("�t�F�[�h�̑��x")]
    float FadeSpeed = 1.0f;

    enum FadeState
    {
        enState_FadeIn,
        enState_FadeOut,
        enState_Idle
    }
    FadeState m_fadeState = FadeState.enState_Idle;

    Image m_image;            //�t�F�[�h�Ɏg�p����摜
    string m_sceneName;        //�J�ڐ�̃V�[����
    float m_alpha = 0.0f;     //�����x

    public void FadeStart(string sceneName)
    {
        //�t�F�[�h���J�n����
        m_fadeState = FadeState.enState_FadeOut;
        m_sceneName = sceneName;

        //���g�̎q�I�u�W�F�N�g�ɃA�^�b�`����Ă���Image���擾
        m_image = transform.GetChild(0).GetComponent<Image>();

        //���g�̓V�[�����܂����ł��폜����Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //�ҋ@��ԂȂ�A�������Ȃ�
        if (m_fadeState == FadeState.enState_Idle)
        {
            return;
        }

        switch (m_fadeState)
        {
            //�t�F�[�h�C���Ȃ�A��ʂ𖾂邭����
            case FadeState.enState_FadeIn:
                m_alpha -= FadeSpeed * Time.deltaTime;

                if (m_alpha < 0.0f)
                {
                    Destroy(gameObject);
                }
                break;

            //�t�F�[�h�A�E�g�Ȃ�A��ʂ��Â�����
            case FadeState.enState_FadeOut:
                m_alpha += FadeSpeed * Time.deltaTime;

                if (m_alpha > 1.0f)
                {
                    SceneManager.LoadScene(m_sceneName);
                    m_fadeState = FadeState.enState_FadeIn;
                }
                break;
        }

        //�摜�̓����x��ݒ�
        Color nowColor = m_image.color;
        nowColor.a = m_alpha;
        m_image.color = nowColor;
    }
}