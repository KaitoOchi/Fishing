using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PictureBookExplain : MonoBehaviour
{
    TextMeshProUGUI     m_name;         //名前。
    Image           m_image;        //画像。
    TextMeshProUGUI m_explain;      //説明。
    TextMeshProUGUI m_statistics;    //統計。


    private void Start()
    {
        m_name = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        m_image = transform.GetChild(1).GetComponent<Image>();
        m_explain = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        m_statistics = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }


    /// <summary>
    /// 説明画面を設定。
    /// </summary>
    /// <param name="name">名前</param>
    /// <param name="image">画像</param>
    /// <param name="explain">説明</param>
    /// <param name="getNum">釣った数</param>
    /// <param name="maxSize">最大サイズ</param>
    public void SetExplain(string name, Sprite image, string explain, int getNum, float maxSize)
    {
        //名前を設定。
        m_name.text = name;

        //画像を設定。
        m_image.sprite = image;
        m_image.color = Vector4.one;

        //説明文を設定。
        m_explain.text = explain;

        maxSize *= 10.0f;
        maxSize = Mathf.Floor(maxSize) / 10.0f;

        //釣った数と最大サイズを設定。
        m_statistics.text = "釣った数   ... " + getNum +" 匹 \n最大サイズ... " + maxSize + "cm";
    }
}
