using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;//ファイルを扱うときに書き加える

public class LogScene2 : MonoBehaviour
{
    public Dropdown dropDownTitle;
    public Text result1;

    private void Start() 
    {
        PushLoadButton();
        PushLoadButton2();
    }

    //作家別のscrollviewに入れるためのコード↓
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
    public void PushLoadButton()
    {
        SaveData saveData = Load();
        
        if (dropDownTitle) 
        {
            dropDownTitle.ClearOptions();    //現在の要素をクリアする
            List<string> list = new List<string>();
            for(int i=0; i<saveData.TitleTextList.Count; i++) {
                if (i == 0) {
                    list.Add ("全て");
                } else {
                    list.Add (saveData.TitleTextList[i]);
                }
            }
            dropDownTitle.AddOptions(list);  //新しく要素のリストを設定する
            dropDownTitle.value = 0;         //デフォルトを設定(0～n-1)
        }
    }


    public void OnClick()
    {
        Dropdown ddtmp;
        Dropdown year1,year2;
        Dropdown month1,month2;
        Dropdown day1,day2;
        //「Dropdown」というGameObjectのDropDownコンポーネントを操作するために取得
        ddtmp = GameObject.Find("product").GetComponent<Dropdown>();
        year1 = GameObject.Find("year1").GetComponent<Dropdown>();
        year2 = GameObject.Find("year2").GetComponent<Dropdown>();
        month1 = GameObject.Find("month1").GetComponent<Dropdown>();
        month2 = GameObject.Find("month2").GetComponent<Dropdown>();
        day1 = GameObject.Find("day1").GetComponent<Dropdown>();
        day2 = GameObject.Find("day2").GetComponent<Dropdown>();
        //DropDownコンポーネントのoptionsから選択されてているvalueをindexで指定し、
        //選択されている文字を樹徳
        string selectedvalue = ddtmp.options[ddtmp.value].text;
        string selected_year1_value = year1.options[year1.value].text;
        string selected_month1_value= month1.options[month1.value].text;
        string selected_day1_value = day1.options[day1.value].text;
        string selected_year2_value = year2.options[year2.value].text;
        string selected_month2_value= month2.options[month2.value].text;
        string selected_day2_value = day2.options[day2.value].text;
    }


    //ログscrollviewに入れるためのコード↓
    public GameObject salespanel,scrollcontent2;

    public void Save2(SaveData2 saveData2)
    {
        StreamWriter writer;
        string jsonstr = JsonUtility.ToJson(saveData2);
        writer = new StreamWriter(Application.dataPath + "/savedata2.json", false);
       
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }
    public SaveData2 Load2()
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
        SaveData2 saveData2 = new SaveData2();
        return saveData2;
    }
    public void PushLoadButton2()
    {
        SaveData2 saveData2 = Load2();

        for (int i=0; i<saveData2.TitleTextList.Count; i++)
        {
            GameObject prefab2 = (GameObject)Instantiate (salespanel);
            prefab2.transform.SetParent (scrollcontent2.transform, false); 
            //日程
            prefab2.transform.GetChild(0).gameObject.GetComponent<Text>().text
            =saveData2.YearTextList[i] +"." + saveData2.MonthTextList[i] + "/" + saveData2.DayTextList[i];
            //作品名
            prefab2.transform.GetChild(1).gameObject.GetComponent<Text>().text=saveData2.TitleTextList[i];
            //作家名
            prefab2.transform.GetChild(2).gameObject.GetComponent<Text>().text=saveData2.NameTextList[i];
            //売れた個数
            prefab2.transform.GetChild(3).gameObject.GetComponent<Text>().text=saveData2.NumberTextList[i];
            //金額
            prefab2.transform.GetChild(4).gameObject.GetComponent<Text>().text=saveData2.PriceTextList[i];

            //全部の値段
            int Number_1 = int.Parse(prefab2.transform.GetChild(3).gameObject.GetComponent<Text>().text=saveData2.NumberTextList[i]);
            int Price_1 =  int.Parse(prefab2.transform.GetChild(4).gameObject.GetComponent<Text>().text=saveData2.PriceTextList[i]);
            int All_Price = Number_1 * Price_1;
            prefab2.transform.GetChild(5).gameObject.GetComponent<Text>().text = All_Price.ToString();;

            prefab2.transform.GetChild(6).gameObject.GetComponent<Text>().text=saveData2.YearTextList[i];
            prefab2.transform.GetChild(7).gameObject.GetComponent<Text>().text=saveData2.MonthTextList[i];
            prefab2.transform.GetChild(8).gameObject.GetComponent<Text>().text=saveData2.DayTextList[i];
        }
    }

    //作家名のdropdownを選択した時の処理
    public void OnClick2()
    {
        Dropdown ddtmp;
        Dropdown year1,year2;
        Dropdown month1,month2;
        Dropdown day1,day2;
        //「Dropdown」というGameObjectのDropDownコンポーネントを操作するために取得
        ddtmp = GameObject.Find("product").GetComponent<Dropdown>();
        year1 = GameObject.Find("year1").GetComponent<Dropdown>();
        year2 = GameObject.Find("year2").GetComponent<Dropdown>();
        month1 = GameObject.Find("month1").GetComponent<Dropdown>();
        month2 = GameObject.Find("month2").GetComponent<Dropdown>();
        day1 = GameObject.Find("day1").GetComponent<Dropdown>();
        day2 = GameObject.Find("day2").GetComponent<Dropdown>();
        //DropDownコンポーネントのoptionsから選択されてているvalueをindexで指定し、
        //選択されている文字を樹徳
        string selectedvalue = ddtmp.options[ddtmp.value].text;
        string selected_year1_value = year1.options[year1.value].text;
        string selected_month1_value= month1.options[month1.value].text;
        string selected_day1_value = day1.options[day1.value].text;
        string selected_year2_value = year2.options[year2.value].text;
        string selected_month2_value= month2.options[month2.value].text;
        string selected_day2_value = day2.options[day2.value].text;

        result1.text = "期間：" + selected_year1_value +"." + selected_month1_value +"." +selected_day1_value
        + "~" + selected_year2_value +"." + selected_month2_value +"." +selected_day2_value
        + "　作家名：" + selectedvalue + "　の検索結果";

        GameObject[] ChildObject;
        ChildObject = new GameObject[scrollcontent2.transform.childCount];
        for (int i = 0; i < scrollcontent2.transform.childCount; i++)
        {
            ChildObject[i] = scrollcontent2.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i<ChildObject.Length; i++)
        {
            int intyear1 = int.Parse(selected_year1_value);
            int intyear2 = int.Parse(selected_year2_value);
            int intmonth1 = int.Parse(selected_month1_value);
            int intmonth2 = int.Parse(selected_month2_value);
            int intday1 = int.Parse(selected_day1_value);
            int intday2 = int.Parse(selected_day2_value);
            int realyear = int.Parse(ChildObject[i].transform.GetChild(6).gameObject.GetComponent<Text>().text);
            int realmonth = int.Parse(ChildObject[i].transform.GetChild(7).gameObject.GetComponent<Text>().text);
            int realday = int.Parse(ChildObject[i].transform.GetChild(8).gameObject.GetComponent<Text>().text);

            if(realday > intday1)  // 2022.8.19 (2022.8.22)
            {
                if(intday2 > realday)  // 2022.8.22 - 2022.8.23　(2022.8.22)
                {
                    Debug.Log("10あり");
                    if(ChildObject[i].transform.GetChild(1).gameObject.GetComponent<Text>().text != selectedvalue && selectedvalue != "全て")
                    {
                        ChildObject[i].SetActive(false);
                    }
                    else if(selectedvalue == "全て")
                    {
                        ChildObject[i].SetActive(true);
                    }
                    else if (ChildObject[i].transform.GetChild(1).gameObject.GetComponent<Text>().text == selectedvalue)
                    {
                        ChildObject[i].SetActive(true);
                    }
                }
                else if (intday2 == realday)  // 2022.8.22 - 2022.8.22 (2022.8.22)
                {
                    Debug.Log("10あり_2");
                    if(ChildObject[i].transform.GetChild(1).gameObject.GetComponent<Text>().text != selectedvalue && selectedvalue != "全て")
                    {
                        ChildObject[i].SetActive(false);
                    }
                    else if(selectedvalue == "全て")
                    {
                        ChildObject[i].SetActive(true);
                    }
                    else if (ChildObject[i].transform.GetChild(1).gameObject.GetComponent<Text>().text == selectedvalue)
                    {
                        ChildObject[i].SetActive(true);
                    }
                }
                else if(intday2 < realday)  // 2022.8.22 - 2022.8.20 (2022.8.22)
                {
                    Debug.Log("11なし");
                    ChildObject[i].SetActive(false);
                }
            }
            else if(realday == intday1)  // 2022.8.22 (2022.8.22)
            {
                if(intday2 > realday)  // 2022.8.22 - 2022.8.23　(2022.8.22)
                {
                    Debug.Log("10あり");
                    if(ChildObject[i].transform.GetChild(1).gameObject.GetComponent<Text>().text != selectedvalue && selectedvalue != "全て")
                    {
                        ChildObject[i].SetActive(false);
                    }
                    else if(selectedvalue == "全て")
                    {
                        ChildObject[i].SetActive(true);
                    }
                    else if (ChildObject[i].transform.GetChild(1).gameObject.GetComponent<Text>().text == selectedvalue)
                    {
                        ChildObject[i].SetActive(true);
                    }
                }
                else if (intday2 == realday)  // 2022.8.22 - 2022.8.22 (2022.8.22)
                {
                    Debug.Log("10あり_2");
                    if(ChildObject[i].transform.GetChild(1).gameObject.GetComponent<Text>().text != selectedvalue && selectedvalue != "全て")
                    {
                        ChildObject[i].SetActive(false);
                    }
                    else if(selectedvalue == "全て")
                    {
                        ChildObject[i].SetActive(true);
                    }
                    else if (ChildObject[i].transform.GetChild(1).gameObject.GetComponent<Text>().text == selectedvalue)
                    {
                        ChildObject[i].SetActive(true);
                    }
                }
                else if(intday2 < realday)  // 2022.8.22 - 2022.8.20 (2022.8.22)
                {
                    Debug.Log("11なし");
                }
            }
            else if(realday < intday1) // 2022.8.23 (2022.8.22)
            {
                Debug.Log("11なし_2");
                ChildObject[i].SetActive(false);
            }

        }
        
    }
}
