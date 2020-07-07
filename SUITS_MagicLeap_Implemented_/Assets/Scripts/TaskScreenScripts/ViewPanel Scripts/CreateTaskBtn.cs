using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTaskBtn
{
    private GameObject button;
    private GameObject[] btns;

    public GameObject[] createBtn(int taskLength)
    {
        for(int i = 0; i<taskLength;i++)
        {
            button = new GameObject();
            button.AddComponent<RectTransform>();
            button.AddComponent<Button>();
            btns[i] = button;
        }
        return btns;
    }
}
