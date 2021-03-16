using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskView : ViewManager
{
    private bool isSelectedNext;

    public TaskView(TaskScreenManager manager)
    {
        this.manager = manager;
    }

       public TaskView(TaskGalleryScreenManager manager)
    {
        this.manager = manager;
    }

    public TaskView (SciGalleryScreenManager manager)
    {
        this.manager = manager;
    }

    public void nextTask()
    {
        nextSelected();
        isSelectedNext = true;
        counterCheck();
    }

    public void prevTask()
    {
      preSelected();
      isSelectedNext = false;
      counterCheck();  
    }

    //Ensures that the user doesn't exceed the task limits
    protected override void counterCheck()
    {
        if (counter > manager.getReader().getTaskLength()-1)
        {
           counter = counter - 1;
        }
        else if (counter < 0)
        {
            counter = counter + 1;
        }
        setValues();
    }

    protected override void getValues()
    {
        counter = manager.getTaskCounter();
        isSelectedNext = manager.getSelectedTask();
    }

    protected override void setValues()
    {
        manager.setTaskCounter(counter);
        manager.setSelectedTask(isSelectedNext);
    }

}
