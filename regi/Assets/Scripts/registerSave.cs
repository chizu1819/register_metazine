using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//ファイルを扱うときに書き加える
using UnityEngine.UI;

[System.Serializable]
public class SaveData
{
    public string author_name;
    public List<string> TitleTextList = new List<string>();
    public List<string> NameTextList = new List<string>();
    public List<string> NumberTextList = new List<string>();
    public List<string> PriceTextList = new List<string>();

}

public class registerSave : MonoBehaviour
{
    public GameObject panel1,scrollcontent;
    public GameObject OKPanel,NOPanel;

    //①セーブの処理
    public void Save(SaveData saveData)
    {
        StreamWriter writer;
        string jsonstr = JsonUtility.ToJson(saveData);
        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
       
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

    }
    
    //②ロードの処理
    public SaveData Load()//戻り値にSaveData型の値を返すという意味
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
        //もしファイルがなかったら
        SaveData saveData = new SaveData();
        saveData.author_name = "";

        return saveData;
    }

    public void PreSave()
    {
        GameObject ParentObject = GameObject.Find("Content");
        string titleText = ParentObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
        string nameText = ParentObject.transform.GetChild(1).gameObject.GetComponent<Text>().text;
        string numberText = ParentObject.transform.GetChild(2).gameObject.GetComponent<Text>().text;
        string priceText = ParentObject.transform.GetChild(3).gameObject.GetComponent<Text>().text;
        if(titleText == "" || nameText == "" ||  numberText == "" ||  priceText == "" )
        {
            NOPanel.SetActive(true);
        }
        else
        {
            OKPanel.SetActive(true);
        }
    }

    //③セーブボタンを押したときの処理
    public void PushSaveButton()
    {
        
        //SaveData saveData = new SaveData();
        //saveData.author_name = "にしもり";

        GameObject ParentObject = GameObject.Find("Content");
        string titleText = ParentObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
        string nameText = ParentObject.transform.GetChild(1).gameObject.GetComponent<Text>().text;
        string numberText = ParentObject.transform.GetChild(2).gameObject.GetComponent<Text>().text;
        string priceText = ParentObject.transform.GetChild(3).gameObject.GetComponent<Text>().text;

        SaveData saveData = Load();
        List<string> L2List = new List<string>();//とりあえず入れる
        List<string> N2List = new List<string>();//とりあえず入れる
        List<string> Nu2List = new List<string>();//とりあえず入れる
        List<string> P2List = new List<string>();//とりあえず入れる

        if (File.Exists(Application.dataPath + "/savedata.json"))
        {
            for (int i=0; i<saveData.TitleTextList.Count; i++)
            {
                string  L2Text = saveData.TitleTextList[i];
                string  N2Text = saveData.NameTextList[i];
                string  Nu2Text = saveData.NumberTextList[i];
                string  P2Text = saveData.PriceTextList[i];

                L2List.Add(L2Text);
                N2List.Add(N2Text);
                Nu2List.Add(Nu2Text);
                P2List.Add(P2Text);
            }
            
        }
        List<string> DTList = new List<string>(L2List);
        List<string> N22List = new List<string>(N2List);
        List<string> Nu22List = new List<string>(Nu2List);
        List<string> P22List = new List<string>(P2List);
        DTList.Add(titleText);
        N22List.Add(nameText);
        Nu22List.Add(numberText);
        P22List.Add(priceText);

        saveData.TitleTextList = DTList;
        saveData.NameTextList = N22List;
        saveData.NumberTextList = Nu22List;
        saveData.PriceTextList = P22List;
        //saveData.author_name = nameText;

        Save(saveData);

    }

    public void PushSaveButton2(GameObject panel)
    {
        panel.SetActive(true);
    }
     public void PushSaveButton3(GameObject panel)
    {
        panel.SetActive(false);
    }

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
