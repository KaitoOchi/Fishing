using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    [SerializeField, Header("’Ç‰Á‚·‚é‹àŠz")]
    int Money;
    [SerializeField, Header("DrawFishParam")]
    DrawFishParam FishMoney;

    public void Add()
    {
        // ŒvZ‚µ‚½‹àŠz‚ğQÆ‚·‚é
        Money = FishMoney.GetMoney();

        // ƒZ[ƒuƒf[ƒ^“à‚Ì‹àŠz‚ğQÆ
        SaveDataManager saveDataManager = FindObjectOfType<SaveDataManager>();
        // ŒvZ‚µ‚½‹àŠz‚ğ‰ÁZ
        saveDataManager.GetSaveData().saveData.money += Money;

        saveDataManager.Save();
    }
}
