using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BackgroundImageScaler : MonoBehaviour
{
    public float maxHeight = 500f;
    public RectTransform childElement;
    private RectTransform _backgroundImage;
    
    private void UpdateBackgroundSize()
    {
        if (childElement != null)
        {
            if(_backgroundImage == null) _backgroundImage = GetComponent<RectTransform>();
            
            float childHeight = childElement.rect.height;
            float newHeight = Mathf.Min(childHeight, maxHeight);
            
            Vector2 anchoredPosition = _backgroundImage.anchoredPosition + _backgroundImage.sizeDelta/2;
            
            _backgroundImage.sizeDelta = new Vector2(_backgroundImage.sizeDelta.x, newHeight);

            _backgroundImage.anchoredPosition = new Vector2(
                _backgroundImage.anchoredPosition.x,
                anchoredPosition.y - newHeight / 2f
            );
        }
    }
    
    public void RefreshBackgroundSize()
    {
        UpdateBackgroundSize();
    }
}