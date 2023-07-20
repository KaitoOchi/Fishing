using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    [SerializeField, Header("�ǉ�������z")]
    int Money;

    public void Add()
    {
        // �v�Z�������z���Q�Ƃ���
        Money = GetComponent<DrawFishParam>().GetMoney();

        // �Z�[�u�f�[�^���̋��z���Q��
        SaveDataManager saveDataManager = FindObjectOfType<SaveDataManager>();
        // �v�Z�������z�����Z
        saveDataManager.GetSaveData().saveData.money += Money;
    }
}
