using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class ScreenDisplay
{
    public CreateTaskBtn _createBtns;
    public TextMeshProUGUI textInstruction, textPage, textTaskLength, textTitle, textDuration, textNextTitle, textNextDuration;
    public Material mat;
    public Image instImage;
    public TaskTimer timer;
    public List<List<string>> list;
    public GameObject[] btns;
}
