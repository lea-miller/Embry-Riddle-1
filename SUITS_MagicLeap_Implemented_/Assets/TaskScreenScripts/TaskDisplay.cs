using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskDisplay : MonoBehaviour
{

    [SerializeField] protected GameObject taskSelBtn, taskSelBtn1, taskSelBtn2;
   [SerializeField] protected Text taskName1, taskName2, taskName3;
    private GameObject instImageObj,instruct,pageText,taskLengthObj;
    private TextMeshProUGUI textInstruction, textPage, textTaskLength;
    private Material mat;
    private Image instImage;
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

    void Start()
    {
        displayTaskNames();
        string instructionString = reader.getInstruction(1,0);
        displayInstructionPanel(instructionString,1,0);
        displayTaskPanel(0);
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

    private void displayTaskNames()
    {
       List<string> taskNames = reader.getTaskNames();
       taskName1.text = taskNames[0];
       taskName2.text = taskNames[1];
       taskName3.text = taskNames[2];
    }

    
    public void changeActiceBtnState(bool btn, bool btn1, bool btn2)
    {
        changeBtnState(btn);
        changeBtn1State(btn1);
        changeBtn2State(btn2);
    }


    public void changeBtnState(bool isActive)
    {
        taskSelBtn.SetActive(isActive);
    }

    public void changeBtn1State(bool isActive)
    {
        taskSelBtn1.SetActive(isActive);
    }

    public void changeBtn2State(bool isActive)
    {
        taskSelBtn2.SetActive(isActive);
    }

}
