using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PictureBook : MonoBehaviour
{
    [SerializeField, Header("�{�^��")]
    GameObject ButtonPrefab;
    [SerializeField, Header("�{�^����z�u����ꏊ")]
    GameObject Content;

    List<FishParameter> m_fishParamList = null;     //�������ȃ��X�g�B

    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Fishing/Parameter/FishList.asset";
        ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

        if (obj != null)
        {
            //�������ȃ��X�g���擾�B
            FishParamList fishList = obj as FishParamList;
            m_fishParamList = fishList.GetFishList();

            int size = m_fishParamList.Count;

            for (int i = 0; i < size; i++)
            {
                //�{�^���𐶐��B
                GameObject prefab = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity, Content.transform);
                prefab.GetComponent<Image>().sprite = m_fishParamList[i].GetSprite();
                prefab.GetComponent<PictureBookButton>().SetNumber(i);
            }
        }
        else
        {
            // ScriptableObject�̎擾���s
            Debug.Log("ScriptableObject�̎擾�Ɏ��s���܂���");
        }
    }

    /// <summary>
    /// ������ʂ�ݒ�B
    /// </summary>
    /// <param name="num">�\��������ԍ�</param>
    public void SetExplain(int num)
    {
        FishParameter fishParam = m_fishParamList[num];

        PictureBookExplain explain = FindAnyObjectByType<PictureBookExplain>();
        explain.SetExplain(fishParam.GetName(), fishParam.GetSprite(), fishParam.GetExplain(), 99, 50.2f);
    }
}
