using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalesScrollView : MonoBehaviour
{
    public GameObject salesscrollcontent;
    public Text allNumberT,allPriceT;
    public Text soldNumText,leftNumText,firstNumText;
    void Start()
    {
        OnClick();
    }

    void Update()
    {
       
    }

    public void OnClick()
    {
        int AllNumber = 0;
        int AllPrice = 0;

        GameObject[] DetailChild;
        DetailChild = new GameObject[salesscrollcontent.transform.childCount];
        for (int i=0; i<salesscrollcontent.transform.childCount; i++)
        {
            DetailChild[i] = salesscrollcontent.transform.GetChild(i).gameObject;
        }
        for(int q=0; q<DetailChild.Length; q++)
        {
            if(DetailChild[q].activeSelf)//objectがアクティブか非アクティブか判定
            {
                //個数
                int Number1 =  int.Parse(DetailChild[q].transform.GetChild(3).gameObject.GetComponent<Text>().text);
                AllNumber += Number1;

                //値段
                int Price1 =  int.Parse(DetailChild[q].transform.GetChild(5).gameObject.GetComponent<Text>().text);
                AllPrice +=  Price1;

            }
           
        }
        Debug.Log(AllPrice);

        allNumberT.text = AllNumber.ToString() + "個";
        allPriceT.text = "￥" + AllPrice.ToString();
    }

    public void OnClick2()
    {
        int AllNumber = 0;
        int AllPrice = 0;

        GameObject[] DetailChild;
        DetailChild = new GameObject[salesscrollcontent.transform.childCount];
        for (int i=0; i<salesscrollcontent.transform.childCount; i++)
        {
            DetailChild[i] = salesscrollcontent.transform.GetChild(i).gameObject;
        }
        for(int q=0; q<DetailChild.Length; q++)
        {
            if(DetailChild[q].activeSelf)//objectがアクティブか非アクティブか判定
            {
                //個数
                int Number1 =  int.Parse(DetailChild[q].transform.GetChild(3).gameObject.GetComponent<Text>().text);
                AllNumber += Number1;

                //値段
                int Price1 =  int.Parse(DetailChild[q].transform.GetChild(5).gameObject.GetComponent<Text>().text);
                AllPrice +=  Price1;

            }
           
        }

        allNumberT.text = AllNumber.ToString() + "個";
        allPriceT.text = "￥" + AllPrice.ToString();

        soldNumText.text =  AllNumber.ToString();
    }


    public void OnClick3()
    {
        Dropdown ddtmp;
        ddtmp = GameObject.Find("product").GetComponent<Dropdown>();
        string selectedvalue = ddtmp.options[ddtmp.value].text;

        if(selectedvalue == "全て")
        {
            soldNumText.GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f, 0.0f);
            leftNumText.GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f, 0.0f);
            firstNumText.GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f, 0.0f);
        }
        else
        {
            soldNumText.GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            leftNumText.GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            firstNumText.GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
       
    }
}
