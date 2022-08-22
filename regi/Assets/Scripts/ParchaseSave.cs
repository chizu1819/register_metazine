using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//ファイルを扱うときに書き加える
using UnityEngine.UI;

[System.Serializable]
public class SaveData2
{
    public List<string> TitleTextList = new List<string>();//作品名
    public List<string> NameTextList = new List<string>();//作家名
    public List<string> NumberTextList = new List<string>();//個数
    public List<string> PriceTextList = new List<string>();//値段

    public List<string>  YearTextList = new List<string>();//売れた年
    public List<string>  MonthTextList = new List<string>();//売れた月
    public List<string> DayTextList = new List<string>();//売れた日
}

public class ParchaseSave : MonoBehaviour
{
    public Text yearT,monthT,dayT;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //①セーブの処理
    public void Save(SaveData2 saveData2)
    {
        StreamWriter writer;
        string jsonstr = JsonUtility.ToJson(saveData2);
        writer = new StreamWriter(Application.dataPath + "/savedata2.json", false);
       
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    //②ロードの処理
    public SaveData2 Load()//戻り値にSaveData型の値を返すという意味
    {
        if (File.Exists(Application.dataPath + "/savedata2.json"))
        {
            string datastr = "";
            StreamReader reader;
            reader = new StreamReader(Application.dataPath + "/savedata2.json");
            datastr = reader.ReadToEnd();
            reader.Close();
           
            return JsonUtility.FromJson<SaveData2>(datastr);
        }
        //もしファイルがなかったら
        SaveData2 saveData2 = new SaveData2();

        return saveData2;
    }

    public void PushSaveButton()
    {
        
        GameObject ParentObject = GameObject.Find("Content2");
        GameObject[] ChildObject;
        ChildObject = new GameObject[ParentObject.transform.childCount];
        for (int i = 0; i < ParentObject.transform.childCount; i++)
        {
            ChildObject[i] = ParentObject.transform.GetChild(i).gameObject;
        }
        List<string> DTList = new List<string>();
        List<string> DTList2 = new List<string>();
        List<string> DTList3 = new List<string>();
        List<string> DTList4 = new List<string>();

        List<string> YList = new List<string>();
        List<string> MList = new List<string>();
        List<string> DList = new List<string>();

        if (File.Exists(Application.dataPath + "/savedata2.json"))//もしもうデータがあったら
        {
            SaveData2 saveData2 = Load();//一回もともとあるやつをload

            List<string> DTList_2 = new List<string>();
            List<string> DTList2_2 = new List<string>();
            List<string> DTList3_2 = new List<string>();
            List<string> DTList4_2 = new List<string>();

            List<string> YList_2 = new List<string>();
            List<string> MList_2 = new List<string>();
            List<string> DList_2 = new List<string>();

            for (int i=0; i<saveData2.TitleTextList.Count; i++)
            {
                string TitleText2 = saveData2.TitleTextList[i];
                string PriceText2 = saveData2.PriceTextList[i];
                string NameText2 = saveData2.NameTextList[i];
                string NumText2 = saveData2.NumberTextList[i];

                string YearText2 = saveData2.YearTextList[i];
                string MonthText2 = saveData2.MonthTextList[i];
                string DayText2 = saveData2.DayTextList[i];

                DTList_2.Add(TitleText2);
                DTList2_2.Add(PriceText2);
                DTList3_2.Add(NumText2);
                DTList4_2.Add(NameText2);

                 YList_2.Add(YearText2);
                 MList_2.Add(MonthText2);
                 DList_2.Add(DayText2);
            }

            List<string> DTList_22 = new List<string>(DTList_2);//初期化時に既存のリスト内容を渡す
            List<string> DTList2_22 = new List<string>(DTList2_2);
            List<string> DTList3_22 = new List<string>(DTList3_2);
            List<string> DTList4_22 = new List<string>(DTList4_2);

            List<string> YList_22 = new List<string>(YList_2);
            List<string> MList_22 = new List<string>(MList_2);
            List<string> DList_22 = new List<string>(DList_2);

            for (int i = 0; i<ChildObject.Length; i++)
            {
                string TitleText = ChildObject[i].transform.GetChild(0).gameObject.GetComponent<Text>().text;
                string PriceText = ChildObject[i].transform.GetChild(1).gameObject.GetComponent<Text>().text;
                string NameText = ChildObject[i].transform.GetChild(5).gameObject.GetComponent<Text>().text;
                int Num = ChildObject[i].transform.GetChild(2).gameObject.GetComponent<Dropdown>().value +1;
                string NumText = Num.ToString();

                string YearText = yearT.text;
                string MonthText = monthT.text;
                string DayText = dayT.text;

                DTList_22.Add(TitleText);
                DTList2_22.Add(PriceText);
                DTList3_22.Add(NumText);
                DTList4_22.Add(NameText);

                YList_22.Add(YearText);
                MList_22.Add(MonthText);
                DList_22.Add(DayText);

                saveData2.TitleTextList = DTList_22;
                saveData2.PriceTextList = DTList2_22;
                saveData2.NumberTextList = DTList3_22;
                saveData2.NameTextList = DTList4_22;

                saveData2.YearTextList = YList_22;
                saveData2.MonthTextList = MList_22;
                saveData2.DayTextList = DList_22;
            }

            Save(saveData2);
        }

        else
        {
            SaveData2 saveData2 = new SaveData2();
            for (int i = 0; i<ChildObject.Length; i++)
            {
                string TitleText = ChildObject[i].transform.GetChild(0).gameObject.GetComponent<Text>().text;
                string PriceText = ChildObject[i].transform.GetChild(1).gameObject.GetComponent<Text>().text;
                string NameText = ChildObject[i].transform.GetChild(5).gameObject.GetComponent<Text>().text;
                int Num = ChildObject[i].transform.GetChild(2).gameObject.GetComponent<Dropdown>().value +1;
                string NumText = Num.ToString();

                string YearText = yearT.text;
                string MonthText = monthT.text;
                string DayText = dayT.text;

                if(TitleText== "")
                {
                    continue;
                }
                else
                {
                    DTList.Add(TitleText);
                    DTList2.Add(PriceText);
                    DTList3.Add(NumText);
                    DTList4.Add(NameText);

                    YList.Add(YearText);
                    MList.Add(MonthText);
                    DList.Add(DayText);
                }

                saveData2.TitleTextList = DTList;
                saveData2.PriceTextList = DTList2;
                saveData2.NumberTextList = DTList3;
                saveData2.NameTextList = DTList4;

                saveData2.YearTextList = YList;
                saveData2.MonthTextList = MList;
                saveData2.DayTextList = DList;
            }
           Save(saveData2); 
        }
        
    }
}
