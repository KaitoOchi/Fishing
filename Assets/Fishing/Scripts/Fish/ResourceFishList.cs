using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceFishList : MonoBehaviour
{
    [SerializeField, Header("�����ȃ��X�g")]
    FishParamList FishList;

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
        //�������ȃ��X�g���擾�B
        m_fishList = FishList.GetFishList();
    }

    private void Awake()
    {
        //���g�̓V�[�����܂����ł��폜����Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);
    }
}
