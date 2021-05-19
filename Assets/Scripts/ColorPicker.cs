using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



[Serializable]
public class ColorEvent : UnityEvent<Color>{}

public class ColorPicker : MonoBehaviour
{
    RectTransform Rect;
    Texture2D ColorTexture;
    public ColorEvent OnColorSelect;

    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
        ColorTexture = GetComponent<Image>().mainTexture as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {
        if(RectTransformUtility.RectangleContainsScreenPoint(Rect, Input.mousePosition))
       {
        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition,null, out delta);
        string debug = "mousePosition = " + Input.mousePosition;
        debug += "<br>delta" + delta;

        float width = Rect.rect.width;
        float height = Rect.rect.height;
        delta += new Vector2(width * .5f, height * .5f);
        debug += "<br>offset delta =" +delta;

        float x = Mathf.Clamp(delta.x /width,0f,1f);
        float y = Mathf.Clamp(delta.y /height,0f,1f);

        int texX = Mathf.RoundToInt(x * ColorTexture.width);
        int texY = Mathf.RoundToInt(y * ColorTexture.height);
    
        Color color = ColorTexture.GetPixel(texX,texY);
        
        if(Input.touchCount > 0)
        {
            OnColorSelect?.Invoke(color);
        }
        
        }
    }
}
