using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskDisplay : MonoBehaviour
{

    public GameObject taskSelBtn, taskSelBtn1, taskSelBtn2;
    private GameObject instImageObj,instruct,pageText,taskLengthObj;
    private TextMeshProUGUI textInstruction, textPage, textTaskLength;
    private Material mat;
    private Image instImage;
    private static float waitTime = 0.3f;
    private CSVReader reader;


    void Awake()
    {
        instruct = GameObject.FindGameObjectWithTag("InstructText");
        pageText = GameObject.FindGameObjectWithTag("PageCounter");
        taskLengthObj = GameObject.FindGameObjectWithTag("TaskCounter");
        textInstruction = instruct.GetComponent<TextMeshProUGUI>();
        textPage = pageText.GetComponent<TextMeshProUGUI>();
        textTaskLength = taskLengthObj.GetComponent<TextMeshProUGUI>();
        
        instImageObj = GameObject.FindGameObjectWithTag("Task Image");
        mat = Resources.Load<Material>("Materials/Transparent");
        instImage = instImageObj.GetComponent<Image>();
        
        reader = gameObject.GetComponent<CSVReader>();

    }

    //Displays the page information to the GUI
    public void displayInstructionPanel(string joinString, int pageCounter, int taskCounter)
    {
        textInstruction.text = joinString;
        textPage.text = pageCounter + " out of " + reader.getMaxPages(taskCounter);
    }

    //Displays Current Task out of the Total Task
    public void displayTaskPanel(int taskCounter)
    {
        textTaskLength.text = ((taskCounter <= reader.getTaskLength()-1) ? taskCounter+1 : taskCounter) 
            + " out of " + reader.getTaskLength();
    }

    //Updates the impage based on the instruction
    public void updateImage(List<List<List<string>>> tasks, int taskCounter, int pageCounter)
    {
        //Only need to pull the first index of the instImage for the page
        List<int> list = reader.getInstructionIndex(pageCounter,taskCounter);
        int startIndex = list[0];
        string currImage = tasks[taskCounter][2][startIndex];
            //Trim is needed to remove the white spaces that are in the list
            string path = "Sprites/" + currImage.Trim();
            Sprite currSprite = Resources.Load<Sprite>(path);
            if(currSprite == null)
            {
                mat = Resources.Load<Material>("Materials/Transparent");
            }
            else
            {
                instImage.sprite = currSprite;
                mat = Resources.Load<Material>("Materials/White");
            }
            instImage.material = mat;
    }

}
