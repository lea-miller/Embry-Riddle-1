using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionEvaNotes : GenericCollision
{
  private Image border;

    void Awake()
    {
        border = GameObject.FindWithTag("EvaToolBtn").GetComponent<Image>();
    }

    void Start()
    {
        isOff();
    }

    public override void isOn()
    {
        border.enabled = true;
    }

    public override void isOff()
    {
        border.enabled = false;
    }
}
