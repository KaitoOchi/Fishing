using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    [SerializeField, Header("フェード")]
    GameObject FadeCanvas;

    AudioSource m_audio;


    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// ボタンが押されたら呼ばれる関数。
    /// </summary>
    /// <param name="sceneName"></param>
    public void SceneChange(string sceneName)
    {
        m_audio.Play();

        //名前が空白なら、現在のシーンの名前を使う
        if (sceneName == "")
        {
            sceneName = SceneManager.GetActiveScene().name;
        }

        //フェードオブジェクトを生成
        GameObject fadeCanvas = Instantiate(FadeCanvas);

        //フェードを開始
        fadeCanvas.GetComponent<FadeScene>().FadeStart(sceneName);
    }
}
