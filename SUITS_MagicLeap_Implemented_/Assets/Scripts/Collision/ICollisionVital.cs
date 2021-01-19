using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICollisionVital
{
    Image vitalImage { set; get; }
    Image vitalMainScreen { set; get; }
    GameObject mainScreen { set; get; }
    GameObject topView { set; get; }
}
