using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField, Header("おさかなの数")]
    int FishNum = 0;

    [SerializeField, Header("餌の数")]
    int FeedNum = 0;

    [SerializeField, Header("セーブデータ")]
    SaveData NowSaveData;

    string m_filePath;


    /// <summary>
    /// セーブデータを取得。
    /// </summary>
    /// <returns></returns>
    public SaveData GetSaveData()
    {
        return NowSaveData;
    }

    /// <summary>
    /// セーブする。
    /// </summary>
    public void Save()
    {
        string json = JsonUtility.ToJson(NowSaveData);
        StreamWriter streamWriter = new StreamWriter(m_filePath);
        streamWriter.Write(json);
        streamWriter.Close();
    }

    /// <summary>
    /// ロードする。
    /// </summary>
    /// <returns>成功ならtrue、失敗ならfalse</returns>
    public bool Load()
    {
        if (File.Exists(m_filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(m_filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            NowSaveData = JsonUtility.FromJson<SaveData>(data);

            //ロードできた
            return true;
        }
        //ロードできなかった
        return false;
    }

    /// <summary>
    /// 初期化する。
    /// </summary>
    public void InitSaveData()
    {
        //セーブデータ分のメモリを確保。
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

        //セーブする
        Save();
    }


    private void Awake()
    {
        //自身はシーンをまたいでも削除されないようにする
        DontDestroyOnLoad(gameObject);

        //最初にセーブデータを読み込む
        m_filePath = Application.persistentDataPath + "/" + ".savedata.json";
        bool isLoad = Load();

        //ロードに失敗した場合はセーブデータを初期化する
        if (isLoad == false)
        {
            InitSaveData();
        }
    }
}