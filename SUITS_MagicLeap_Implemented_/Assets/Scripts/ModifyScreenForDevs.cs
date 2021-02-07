using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ModifyScreenForDevs : MonoBehaviour
{
  
  public GameObject TaskScreen, NavScreen, SciScreen, MediaScreen, AppBar;
  public bool taskCondition,navCondition,sciCondition,mediaCondition,appCondition;

  void  FixedUpdate()
  {
      AppBar.SetActive(appCondition);
      TaskScreen.SetActive(taskCondition);
      NavScreen.SetActive(navCondition);
      SciScreen.SetActive(sciCondition);
      MediaScreen.SetActive(mediaCondition);
  }
  
}
