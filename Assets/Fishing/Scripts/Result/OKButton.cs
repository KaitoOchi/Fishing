using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OKButton : MonoBehaviour
{
    [SerializeField, Header("���U���g")]
    GameObject Result;
    [SerializeField, Header("�v���C���[")]
    PlayerFishing Player;

    public void ChangeActiveFlag()
    {
        Result.SetActive(false);

        Player.EndFishing();

        SceneManager.LoadScene("Game");
    }
}
