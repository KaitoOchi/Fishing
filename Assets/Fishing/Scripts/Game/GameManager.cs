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
        //���g�̓V�[�����܂����ł��폜����Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);

        Instantiate(SaveDataObject);
        Instantiate(ResourceFishList);
    }
}
