using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;//ファイルを扱うときに書き加える

public class LogScene2_2 : MonoBehaviour
{
    public Text firstNumText,leftNumText,soldNumText;

    //在庫数管理用
    void Start()
    {
        
    }

    public void Save(SaveData saveData)
    {
        StreamWriter writer;
        string jsonstr = JsonUtility.ToJson(saveData);
        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
       
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

    }
    
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

    public void LoadTitle()
    {
        int index = 0;
        Dropdown ddtmp;
        ddtmp = GameObject.Find("product").GetComponent<Dropdown>();
        string selectedvalue = ddtmp.options[ddtmp.value].text;

        SaveData saveData = Load();
        for (int i=0; i<saveData.TitleTextList.Count; i++)
        {
            if(selectedvalue == saveData.TitleTextList[i])
            {
                index = i;
                Debug.Log(index);

                firstNumText.text = saveData.NumberTextList[index];
            }
            
        }
        int left = int.Parse(firstNumText.text) - int.Parse(soldNumText.text);
        leftNumText.text = left.ToString();
       
    }
}
