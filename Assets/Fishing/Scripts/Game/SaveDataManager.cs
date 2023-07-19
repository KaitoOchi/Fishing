using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField, Header("�������Ȃ̐�")]
    int FishNum = 0;

    [SerializeField, Header("�a�̐�")]
    int FeedNum = 0;

    [SerializeField, Header("�Z�[�u�f�[�^")]
    SaveData NowSaveData;

    string m_filePath;


    /// <summary>
    /// �Z�[�u�f�[�^���擾�B
    /// </summary>
    /// <returns></returns>
    public SaveData GetSaveData()
    {
        return NowSaveData;
    }

    /// <summary>
    /// �Z�[�u����B
    /// </summary>
    public void Save()
    {
        string json = JsonUtility.ToJson(NowSaveData);
        StreamWriter streamWriter = new StreamWriter(m_filePath);
        streamWriter.Write(json);
        streamWriter.Close();
    }

    /// <summary>
    /// ���[�h����B
    /// </summary>
    /// <returns>�����Ȃ�true�A���s�Ȃ�false</returns>
    public bool Load()
    {
        if (File.Exists(m_filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(m_filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            NowSaveData = JsonUtility.FromJson<SaveData>(data);

            //���[�h�ł���
            return true;
        }
        //���[�h�ł��Ȃ�����
        return false;
    }

    /// <summary>
    /// ����������B
    /// </summary>
    public void InitSaveData()
    {
        //�Z�[�u�f�[�^���̃��������m�ہB
        NowSaveData.saveData.feed = new int[FeedNum];
        NowSaveData.saveData.isGet= new bool[FishNum];
        NowSaveData.saveData.maxSize = new float[FishNum];

        NowSaveData.saveData.money = 0;
        NowSaveData.saveData.rodPower = 0;

        for(int i = 0; i < FeedNum; i++)
        {
            NowSaveData.saveData.feed[i] = 0;
        }

        for(int i = 0; i < FishNum; i++)
        {
            NowSaveData.saveData.isGet[i] = false;
            NowSaveData.saveData.maxSize[i] = 0.0f;
        }

        //�Z�[�u����
        Save();
    }


    private void Awake()
    {
        //���g�̓V�[�����܂����ł��폜����Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);

        //�ŏ��ɃZ�[�u�f�[�^��ǂݍ���
        m_filePath = Application.persistentDataPath + "/" + ".savedata.json";
        bool isLoad = Load();

        //���[�h�Ɏ��s�����ꍇ�̓Z�[�u�f�[�^������������
        if (isLoad == false)
        {
            InitSaveData();
        }
    }
}