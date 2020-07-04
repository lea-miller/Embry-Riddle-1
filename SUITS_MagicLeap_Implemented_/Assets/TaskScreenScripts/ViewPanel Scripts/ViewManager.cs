using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewManager
{
    protected TaskScreenManager manager;
    protected int counter;

    protected void preSelected()
    {
        getValues();
        counter = counter - 1;
    }

    protected void nextSelected()
    {
        getValues();
        counter = counter + 1;
    }

    protected abstract void counterCheck();
    protected abstract void setValues();
    protected abstract void getValues();
}
