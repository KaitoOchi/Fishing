using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �ǂ̃V�[������J�n���Ă��ŏ��ɌĂ΂��֐�
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        // �Z�[�u�I�u�W�F�N�g�𐶐�
        GameObject saveObject = (GameObject)Resources.Load("SaveObject");
        Instantiate(saveObject);

        // �Z�[�u�I�u�W�F�N�g�𐶐�
        GameObject fishListObject = (GameObject)Resources.Load("ResourceFishList");
        Instantiate(fishListObject);
    }
}
