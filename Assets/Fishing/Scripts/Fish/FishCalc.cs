using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCalc : MonoBehaviour
{

    float SizeMin;
    float SizeMax;

    int RodGrade;

    float Size;

    SaveDataManager m_saveDataManager;      // �Z�[�u�f�[�^
    FishParameter fishParam;

    // Start is called before the first frame update
    void Start()
    {   

        fishParam=gameObject.GetComponent<FishParameter>();

        m_saveDataManager = FindObjectOfType<SaveDataManager>();
        RodGrade = m_saveDataManager.GetSaveData().saveData.rodPower;
    }

    public void Decide_Fish() //�ނ�Ƃɉ����Ēނꂽ���������_���Ō��߂�H
    {

        if (RodGrade==1) {
        
        }


        else if (RodGrade == 2){

        }


        else if (RodGrade == 3){

        }
    }

    public void Decide_Size() //�T�C�Y�����߂�
    {
        SizeMin = fishParam.GetSizeMin();
        SizeMax = fishParam.GetSizeMax();

        Size = Random.Range(SizeMin, SizeMax);

    }

    public float GetFishSize()
    {
        return Size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
