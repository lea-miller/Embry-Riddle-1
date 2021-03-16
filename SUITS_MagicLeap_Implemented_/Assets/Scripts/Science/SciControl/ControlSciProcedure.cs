using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControlSciProcedure : ControlCommands
{
    private Image border;
    public TextMeshProUGUI page;
    public TextMeshProUGUI title;
    private int count = 1;
    public SpriteRenderer procedure;
    void Awake()
    {
        base.Awake();
        border =  GameObject.FindWithTag("SciProcedure").GetComponent<Image>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        changePageText();
        title.text = "Rock Sample";
    }

    public override void triggerUp()
    {
        if (border.enabled)
        {
            if(count<2)
            {
                count = count + 1;
                changePageText();
                title.text = "Regolith Sample Procedure";
                Sprite sprite = Resources.Load<Sprite>("SciProcedures/Regolith");
                procedure.sprite = sprite;
            }
        
        }
    }

    public override void bumperUp()
    {
        if (border.enabled)
        {
            if(count>1)
            {
                count = count - 1;
                changePageText();
                title.text = "Rock Sample Procedure";
                Sprite sprite = Resources.Load<Sprite>("SciProcedures/RockSample");
                procedure.sprite = sprite;
            }
        }
    }

    private void changePageText()
    {
        page.text = "Page Number " + count + "/2";
    }

    public override void triggerHold(){}
    public override void bumperHold(){}
}
