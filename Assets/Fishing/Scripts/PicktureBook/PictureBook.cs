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
        string path = "Assets/Fishing/Parameter/FishList.asset";
        ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

        if (obj != null)
        {
            //セーブデータを取得。
            SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();

            //おさかなリストを取得。
            FishParamList fishList = obj as FishParamList;
            m_fishParamList = fishList.GetFishList();

            int size = m_fishParamList.Count;

            for (int i = 0; i < size; i++)
            {
                //ボタンを生成。
                GameObject prefab = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity, Content.transform);
                prefab.GetComponent<PictureBookButton>().SetNumber(i);

                //未発見なら表示しない。
                if(saveManager.GetSaveData().saveData.isGet[i] == false)
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
        else
        {
            // ScriptableObjectの取得失敗
            Debug.Log("ScriptableObjectの取得に失敗しました");
        }
    }

    /// <summary>
    /// 説明画面を設定。
    /// </summary>
    /// <param name="num">表示させる番号</param>
    public void SetExplain(int num)
    {
        FishParameter fishParam = m_fishParamList[num];

        PictureBookExplain explain = FindAnyObjectByType<PictureBookExplain>();
        explain.SetExplain(fishParam.GetName(), fishParam.GetSprite(), fishParam.GetExplain(), 99, 50.2f);
    }
}
