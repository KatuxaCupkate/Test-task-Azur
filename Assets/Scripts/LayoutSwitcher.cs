using UnityEngine;
using UnityEngine.UI;

public class LayoutSwitcher : MonoBehaviour
{
    public RectTransform verticalLayout;
    public RectTransform horizontalLayout;
    public Canvas mainCanvas;

    private bool isVertical;

    void Start()
    {
        UpdateLayout();
    }

    void Update()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            if (!isVertical)
            {
                isVertical = true;
                UpdateLayout();
            }
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            if (isVertical)
            {
                isVertical = false;
                UpdateLayout();
            }
        }
    }

    void UpdateLayout()
    {
        if (isVertical)
        {
            verticalLayout.gameObject.SetActive(true);
            horizontalLayout.gameObject.SetActive(false);
        }
        else
        {
            verticalLayout.gameObject.SetActive(false);
            horizontalLayout.gameObject.SetActive(true);
        }

        // Adjust Canvas settings if needed
        CanvasScaler scaler = mainCanvas.GetComponent<CanvasScaler>();
        scaler.referenceResolution = isVertical ? new Vector2(1080, 1920) : new Vector2(1920, 1080);
    }
}

