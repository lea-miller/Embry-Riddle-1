﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MarkerCSVReader : MonoBehaviour
{

    private List<List<string>> markers;

    private TextAsset fileData;


    /*
  * groupList[task index] [list index] [element in the list];
  * Example: groupList [page one] [instruction list] [instruction one]
  * Example: groupList [page one] [image list] [image one]
  */

    void Awake()
    {
        markers = new List<List<string>>();


        loadMarkers();
        importMarkerList();
    }



    public void loadMarkers()
    {
        fileData = Resources.Load<TextAsset>("Tasks/NavigationMarkers");
    }

    public void importMarkerList()
    {

        string[] data = fileData.text.Split(new char[] { '\n' });


        for (int i = 0; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            //Debug.Log("row 1 L = " + row.Length);
            //Debug.Log("row 1 = " + row[0] );

            for (int j = 1; j < row.Length - 1; j++)
            {
                if (i == 0)
                {
                    List<string> temp = new List<string>();
                    markers.Add(temp);
                    //Debug.Log(tasks[0]);

                    markers[j - 1].Add(row[j]);


                }
                else
                {
                    if (row[j] != "")
                    {
                        markers[j - 1].Add(row[j].Replace("\n", ""));
                    }

                }

            }
        }

        //Debug.Log(tasks[0][0] + " " + tasks[0][1]);
    }

    public int getMarkerLength()
    {
        return markers[0].Count;
    }




    //Builds the string for the TextMeshPro

   /* public string getInstruction(int taskNumber)
    {
        //List<int> list = getInstructionIndex(pageCounter,taskNumber);
        int startIndex = 5;
        int endIndex = markers[taskNumber].Count - 1;
        string joinString = "";

        //displays the instruction per the indexs related to that page
        for (int j = endIndex; j >= startIndex; j--)
        {
            string tempInstruct = markers[taskNumber][j];
            if (tempInstruct != "")
            {
                if (tempInstruct.Contains("~"))
                {
                    string pictureName = tempInstruct.Replace("~", "");
                    joinString = "<size=1200%><sprite=" + pictureName + "> <size=100%>" + "\n" + joinString;
                    //joinString = "<indent=8%>" + "<size=1400%><sprite=\"Combo\" " + "index=" + pictureName + "> <size=100%> </indent>" + "\n" + joinString;

                }
                else
                {
                    joinString = j - 4 + "." + "<indent=8%>" + tempInstruct + "</indent>" + "\n" + joinString;
                }

            }
        }
        return joinString;
    }*/



    //Returns the entire list
    public List<List<string>> getMarkers()
    {
        return markers;
    }


}
