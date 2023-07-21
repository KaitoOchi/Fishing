using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PictureBook : MonoBehaviour
{
    [SerializeField, Header("ボタン")]
    GameObject ButtonPrefab;
    [SerializeField, Header("ボタンを配置する場所")]
    GameObject Content;
    [SerializeField, Header("未発見時のアイコン")]
    Sprite DiscoverImage = null;

    List<FishParameter> m_fishParamList = null;     //おさかなリスト。

    // Start is called before the first frame update
    void Start()
    {
        ResourceFishList fishList = FindObjectOfType<ResourceFishList>();
        m_fishParamList = fishList.GetFishList();

        Debug.Log("A");

        //セーブデータを取得。
        SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();

        int size = m_fishParamList.Count;

        Debug.Log("B");

        for (int i = 0; i < size; i++)
        {
            //ボタンを生成。
            GameObject prefab = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity, Content.transform);
            prefab.GetComponent<PictureBookButton>().SetNumber(i);

            Debug.Log("C");

            //未発見なら表示しない。
            if (saveManager.GetSaveData().saveData.GetNum[i] == 0)
            {
                prefab.GetComponent<PictureBookButton>().SetDiscover();
                prefab.GetComponent<Image>().sprite = DiscoverImage;
            }
            //発見済みなら。
            else
            {
                prefab.GetComponent<PictureBookButton>().SetNumber(i);
                prefab.GetComponent<Image>().sprite = m_fishParamList[i].GetSprite();
            }
        }
    }

    /// <summary>
    /// 説明画面を設定。
    /// </summary>
    /// <param name="num">表示させる番号</param>
    public void SetExplain(int num)
    {
        //セーブデータを取得。
        SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();

        FishParameter fishParam = m_fishParamList[num];

        PictureBookExplain explain = FindAnyObjectByType<PictureBookExplain>();
        explain.SetExplain(fishParam.GetName(), fishParam.GetSprite(), fishParam.GetExplain(), saveManager.GetSaveData().saveData.GetNum[num], saveManager.GetSaveData().saveData.maxSize[num]);
    }
}
