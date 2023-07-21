using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PictureBookExplain : MonoBehaviour
{
    TextMeshProUGUI     m_name;         //���O�B
    Image           m_image;        //�摜�B
    TextMeshProUGUI m_explain;      //�����B
    TextMeshProUGUI m_statistics;    //���v�B


    private void Start()
    {
        m_name = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        m_image = transform.GetChild(1).GetComponent<Image>();
        m_explain = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        m_statistics = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }


    /// <summary>
    /// ������ʂ�ݒ�B
    /// </summary>
    /// <param name="name">���O</param>
    /// <param name="image">�摜</param>
    /// <param name="explain">����</param>
    /// <param name="getNum">�ނ�����</param>
    /// <param name="maxSize">�ő�T�C�Y</param>
    public void SetExplain(string name, Sprite image, string explain, int getNum, float maxSize)
    {
        //���O��ݒ�B
        m_name.text = name;

        //�摜��ݒ�B
        m_image.sprite = image;
        m_image.color = Vector4.one;

        //��������ݒ�B
        m_explain.text = explain;

        maxSize *= 10.0f;
        maxSize = Mathf.Floor(maxSize) / 10.0f;

        //�ނ������ƍő�T�C�Y��ݒ�B
        m_statistics.text = "�ނ�����   ... " + getNum +" �C \n�ő�T�C�Y... " + maxSize + "cm";
    }
}
