using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public List <Difference> Differences {get; private set;}
    public int DifferenceToFind {get;private set;}
    public int score {get;private set;}
   public bool isGameWon  {get;private set;}
    public event Action OnDifferenceFound;
    public event Action OnGameWon;
    private GameModel gameModel;
    private int totalDifferences ;
         
    public void Initialize(GameModel gameModel)
    {
        this.gameModel = gameModel;
        Differences = new List<Difference>(gameModel.Differences);
        DifferenceToFind =  CountSortingLayers();
        totalDifferences = DifferenceToFind;
        score=0;
        isGameWon = false;
       
    }
    

    public void OnDifferenceClicked(GameObject clickedObject)
    {
        string clickedSortingLayerName = clickedObject.GetComponent<SortingGroup>().sortingLayerName;
        Difference foundDifference = Differences.Find(difference => difference.SLName == clickedSortingLayerName);
        if (foundDifference != null && Differences.Count > 0)
        {
            IncreaseScore();
            RemoveDuplicateDifferences(clickedSortingLayerName);
            OnDifferenceFound?.Invoke();
        }
        
    }

    private void IncreaseScore()
    {
        score++;
        if (score == totalDifferences)
        {
            isGameWon = true;
            OnGameWon?.Invoke();
        }
    }

    private void RemoveDuplicateDifferences(string sortingLayerName)
    {
        Differences.RemoveAll(difference => difference.SLName == sortingLayerName);
        UpdateDIfferencesTofindeCount();
    }
    public int CountSortingLayers()
{
    HashSet<string> sortingLayers = new HashSet<string>();
    foreach (var difference in Differences)
    {
        sortingLayers.Add(difference.SLName);
    }
    return sortingLayers.Count;
}
    public void UpdateDIfferencesTofindeCount()
    {
        DifferenceToFind = CountSortingLayers();
    }
             
}


