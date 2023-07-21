using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OKButton : MonoBehaviour
{
    [SerializeField, Header("リザルト")]
    GameObject Result;
    [SerializeField, Header("プレイヤー")]
    PlayerFishing Player;

    public void ChangeActiveFlag()
    {
        Result.SetActive(false);

        Player.EndFishing();

        SceneManager.LoadScene("Game");
    }
}
