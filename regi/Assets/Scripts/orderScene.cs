using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;//ファイルを扱うときに書き加える

public class orderScene : MonoBehaviour
{
    public GameObject scrollcontent2;

    public Text allPriceT;
    public Text allPriceT2;
    public Text allNumberT;

    public int value1;
    public int price;

    //日付を代入する変数（DateTime構造体）
    DateTime dt;
    public Text timeT;

    void Start()
    {
        PushLoadButton();

        allPriceT = allPriceT.GetComponent<Text> ();
        allPriceT2 = allPriceT2.GetComponent<Text> ();
        allNumberT = allNumberT.GetComponent<Text> ();
        timeT = timeT.GetComponent<Text> ();

    }

    void Update()
    {
        //value1 = scrollcontent2.transform.childCount;
        //allNumberT.text = value1.ToString();
        //Debug.Log(value1);

        //現在日時を代入
        dt = DateTime.Now;
        timeT.text = 
        dt.Year.ToString() + "." 
        + dt.Month.ToString() + "/"
        + dt.Day.ToString() + "　"
        + dt.Hour.ToString() + ":"
        + dt.Minute.ToString();
   
    }
    public void OnToggleChanged()
    {
        int AllPrice = 0;

        GameObject[] DetailChild;
        DetailChild = new GameObject[scrollcontent2.transform.childCount];
        for (int i=0; i<scrollcontent2.transform.childCount; i++)
        {
            DetailChild[i] = scrollcontent2.transform.GetChild(i).gameObject;
        }
        for(int q=0; q<DetailChild.Length; q++)
        {
            //個数のdropdown
            int Score1 =  int.Parse(DetailChild[q].transform.GetChild(4).gameObject.GetComponent<Text>().text);

            AllPrice += Score1;
        }
        //Debug.Log(AllPrice);

        allPriceT.text = AllPrice.ToString();
        allPriceT2.text = allPriceT.text;
    }


    //商品一覧のscrollviewに、prefab生成のためのコード↓
    public void Save(SaveData saveData)
    {
        StreamWriter writer;
        string jsonstr = JsonUtility.ToJson(saveData);
        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
       
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

    }
    public SaveData Load()
    {
        if (File.Exists(Application.dataPath + "/savedata.json"))
        {
            string datastr = "";
            StreamReader reader;
            reader = new StreamReader(Application.dataPath + "/savedata.json");
            datastr = reader.ReadToEnd();
            reader.Close();
           
            return JsonUtility.FromJson<SaveData>(datastr);
        }
        SaveData saveData = new SaveData();
        return saveData;
    }

    public GameObject panel1,scrollcontent;
    public void PushLoadButton()
    {
        SaveData saveData = Load();
        Debug.Log(saveData.author_name);
        for (int i=0; i<saveData.TitleTextList.Count; i++)
        {
            GameObject prefab = (GameObject)Instantiate (panel1);
            prefab.transform.SetParent (scrollcontent.transform, false); 
            GameObject toggle = prefab.transform.GetChild(0).gameObject;
            
            //作品名
            toggle.transform.GetChild(1).gameObject.GetComponent<Text>().text=saveData.TitleTextList[i];
            //作家名
            prefab.transform.GetChild(1).gameObject.GetComponent<Text>().text=saveData.NameTextList[i];
            //値段
            prefab.transform.GetChild(2).gameObject.GetComponent<Text>().text=saveData.PriceTextList[i];

        }
    }


    
}
