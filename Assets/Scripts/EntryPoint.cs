using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] differencesPrefabs;
    [SerializeField] private GameController gameController;
    [SerializeField] private ViewController viewController;
    [SerializeField] private int gameTime = 60;
  private GameModel gameModel;
 private Difference[] differenceToAdd;

private void   Awake() 
  
 {
     differenceToAdd = new Difference[differencesPrefabs.Length];
            for (int i = 0; i < differencesPrefabs.Length; i++)
            {
              differenceToAdd[i] = new Difference(differencesPrefabs[i].GetComponent<SortingGroup>().sortingLayerName, differencesPrefabs[i].GetComponent<RectTransform>());
              
            }
        gameModel = new GameModel(differenceToAdd, gameTime);
        gameController.Initialize(gameModel);

       viewController.Initialize(gameController,gameModel);
 }

}
