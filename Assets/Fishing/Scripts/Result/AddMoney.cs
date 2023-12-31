using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    [SerializeField, Header("追加する金額")]
    int Money;
    [SerializeField, Header("DrawFishParam")]
    DrawFishParam FishMoney;

    public void Add()
    {
        // 計算した金額を参照する
        Money = FishMoney.GetMoney();

        // セーブデータ内の金額を参照
        SaveDataManager saveDataManager = FindObjectOfType<SaveDataManager>();
        // 計算した金額を加算
        saveDataManager.GetSaveData().saveData.money += Money;

        saveDataManager.Save();
    }
}
