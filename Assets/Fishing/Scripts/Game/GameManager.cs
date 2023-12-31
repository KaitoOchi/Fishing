using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("SaveObject")]
    GameObject SaveDataObject;
    [SerializeField, Header("ResourceFishList")]
    GameObject ResourceFishList;

    void Awake()
    {
        //自身はシーンをまたいでも削除されないようにする
        DontDestroyOnLoad(gameObject);

        Instantiate(SaveDataObject);
        Instantiate(ResourceFishList);
    }
}
