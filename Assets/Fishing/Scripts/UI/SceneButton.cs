using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    [SerializeField, Header("�t�F�[�h")]
    GameObject FadeCanvas;

    private void Start()
    {

    }

    /// <summary>
    /// �{�^���������ꂽ��Ă΂��֐��B
    /// </summary>
    /// <param name="sceneName"></param>
    public void SceneChange(string sceneName)
    {
        //���O���󔒂Ȃ�A���݂̃V�[���̖��O���g��
        if (sceneName == "")
        {
            sceneName = SceneManager.GetActiveScene().name;
        }

        //�t�F�[�h�I�u�W�F�N�g�𐶐�
        GameObject fadeCanvas = Instantiate(FadeCanvas);

        //�t�F�[�h���J�n
        fadeCanvas.GetComponent<FadeScene>().FadeStart(sceneName);
    }
}