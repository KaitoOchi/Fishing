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
    [SerializeField, Header("���������̃A�C�R��")]
    Sprite DiscoverImage = null;

    List<FishParameter> m_fishParamList = null;     //�������ȃ��X�g�B

    // Start is called before the first frame update
    void Start()
    {
        ResourceFishList fishList = FindObjectOfType<ResourceFishList>();
        m_fishParamList = fishList.GetFishList();

        Debug.Log("A");

        //�Z�[�u�f�[�^���擾�B
        SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();

        int size = m_fishParamList.Count;

        Debug.Log("B");

        for (int i = 0; i < size; i++)
        {
            //�{�^���𐶐��B
            GameObject prefab = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity, Content.transform);
            prefab.GetComponent<PictureBookButton>().SetNumber(i);

            Debug.Log("C");

            //�������Ȃ�\�����Ȃ��B
            if (saveManager.GetSaveData().saveData.GetNum[i] == 0)
            {
                prefab.GetComponent<PictureBookButton>().SetDiscover();
                prefab.GetComponent<Image>().sprite = DiscoverImage;
            }
            //�����ς݂Ȃ�B
            else
            {
                prefab.GetComponent<PictureBookButton>().SetNumber(i);
                prefab.GetComponent<Image>().sprite = m_fishParamList[i].GetSprite();
            }
        }
    }

    /// <summary>
    /// ������ʂ�ݒ�B
    /// </summary>
    /// <param name="num">�\��������ԍ�</param>
    public void SetExplain(int num)
    {
        //�Z�[�u�f�[�^���擾�B
        SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();

        FishParameter fishParam = m_fishParamList[num];

        PictureBookExplain explain = FindAnyObjectByType<PictureBookExplain>();
        explain.SetExplain(fishParam.GetName(), fishParam.GetSprite(), fishParam.GetExplain(), saveManager.GetSaveData().saveData.GetNum[num], saveManager.GetSaveData().saveData.maxSize[num]);
    }
}
