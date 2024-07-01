using UnityEngine;
using UnityEngine.UI;

public class Difference  
{
    public string SLName { get; private set; }
    public RectTransform Position { get; private set; }

   

    public Difference(string sortingLayer, RectTransform position)
    {
       SLName = sortingLayer;
       Position = position;
    }
}

