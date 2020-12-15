using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICollisionTask
{
     Image taskTopImage { get; set; }
     Image taskImage { get; set; }
     Image instructImage { get; set;}
     GameObject topPanel { get; set; }
     GameObject mainScreen { get; set; }
}
