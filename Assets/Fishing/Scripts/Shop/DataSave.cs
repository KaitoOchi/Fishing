using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    SaveDataManager m_saveManager;    // セーブデータ

    public void Save()
    {
        // セーブ
        m_saveManager.Save();

        // デバッグ用
        Debug.Log("セーブしました！");
    }
}
