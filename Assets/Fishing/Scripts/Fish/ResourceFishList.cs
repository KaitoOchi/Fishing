using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResourceFishList : MonoBehaviour
{
    List<FishParameter> m_fishList;

    /// <summary>
    /// �t�B�b�V�����X�g���擾�B
    /// </summary>
    /// <returns></returns>
    public List<FishParameter> GetFishList()
    {
        return m_fishList;
    }

    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Fishing/Parameter/FishList.asset";
        ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

        //�������ȃ��X�g���擾�B
        FishParamList fishList = obj as FishParamList;
        m_fishList = fishList.GetFishList();
    }

    private void Awake()
    {
        //���g�̓V�[�����܂����ł��폜����Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);
    }
}
