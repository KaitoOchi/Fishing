using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedText : MonoBehaviour
{
    [SerializeField, Header("�a�̔ԍ�")]
    int FeedNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();

        //�Z�[�u�f�[�^���擾�B
        SaveDataManager saveManager = FindObjectOfType<SaveDataManager>();
        text.text = saveManager.GetSaveData().saveData.feed[FeedNumber].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
