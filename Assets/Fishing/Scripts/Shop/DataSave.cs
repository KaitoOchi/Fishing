using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    SaveDataManager m_saveManager;    // �Z�[�u�f�[�^

    public void Save()
    {
        // �Z�[�u
        m_saveManager.Save();

        // �f�o�b�O�p
        Debug.Log("�Z�[�u���܂����I");
    }
}
