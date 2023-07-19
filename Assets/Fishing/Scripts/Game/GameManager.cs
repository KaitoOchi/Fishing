using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // どのシーンから開始しても最初に呼ばれる関数
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        // セーブオブジェクトを生成
        GameObject saveObject = (GameObject)Resources.Load("SaveObject");
        Instantiate(saveObject);
    }
}
