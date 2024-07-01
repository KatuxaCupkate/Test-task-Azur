using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewController : MonoBehaviour
{
    [SerializeField] private AnimatedProgressbar timeSlider;
    [SerializeField] private GameObject cursor;
    [SerializeField] private TextMeshProUGUI scoreCounter;
    [SerializeField] private ParticleSystem winParticle;

    private RectTransform cursorTransform;

    private GameController gameController;
    private float gameTime;
    private float elapsedTime = 0f;
  
public void Initialize(GameController gameController,GameModel gameModel) 
{
   cursorTransform = cursor.GetComponent<RectTransform>();
   this.gameController = gameController;
  gameTime = gameModel.GameTime;
 
}
private void Start() {
  MoveCursorToNextDifference();
}
    private void Update()
    {
        if (elapsedTime < gameTime && gameController.isGameWon == false)
        {
            elapsedTime += Time.deltaTime;
            timeSlider.FillAmount = (gameTime - elapsedTime) / gameTime;
        }


    }
      private void OnEnable() {
        gameController.OnDifferenceFound += ChekScorePoint;
        gameController.OnDifferenceFound += MoveCursorToNextDifference;
        gameController.OnGameWon += WinGameActions;
      }

      private void OnDisable() {
       gameController.OnDifferenceFound -= ChekScorePoint;
        gameController.OnDifferenceFound -= MoveCursorToNextDifference;
        gameController.OnGameWon -= WinGameActions;
       
      }
    public void ChekScorePoint()  
    {
       scoreCounter.text = gameController.DifferenceToFind.ToString();
    }


    public void MoveCursorToNextDifference()
    {
      int index = Random.Range(0, gameController.Differences.Count);
      if(gameController.Differences.Count > 0)
      {
       cursorTransform.localPosition = (Vector2)gameController.Differences[index].Position.localPosition;
      } 
      else
      {
        HideCursor();
      }

      cursor.GetComponent<Animation>().Play();
    }

public void ShowWinParticle()
{
  winParticle.Play();
}


public void HideCursor()
{
  cursor.SetActive(false);
}

public void WinGameActions()
{
  Invoke("ShowWinParticle",0.4f);
  HideCursor();
}

}
