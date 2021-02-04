using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyScreenForDevs : MonoBehaviour
{
  
  public GameObject TaskScreen, NavScreen, SciScreen, MediaScreen, AppBar;
  public bool taskCondition,navCondition,sciCondition,mediaCondition;

  void Start()
  {
    //   TaskScreen = GameObject.FindWithTag("TaskScreen");
    //  NavScreen = GameObject.FindWithTag("NavigationScreen");
    //   SciScreen = GameObject.FindWithTag("ScienceScreen");
    //   MediaScreen = GameObject.FindWithTag("MediaScreen");
    //   AppBar = GameObject.FindWithTag("AppBar");
  }

  void  FixedUpdate()
  {
      AppBar.SetActive(false);
      TaskScreen.SetActive(taskCondition);
      NavScreen.SetActive(navCondition);
      SciScreen.SetActive(sciCondition);
      MediaScreen.SetActive(mediaCondition);
  }
  
}
