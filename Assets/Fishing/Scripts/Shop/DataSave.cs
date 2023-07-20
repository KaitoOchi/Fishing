using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    public void Save()
    {
        SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();
        saveManager.Save();

        Debug.Log("セーブしました！");
    }
}
