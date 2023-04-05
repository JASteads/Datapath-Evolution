using UnityEngine;
using UnityEngine.UI;

public class InterfaceTool
{
    public static void Toggle_Canvas_Priority(GameObject parent, Canvas priority)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GraphicRaycaster ray = parent.transform.GetChild(i).GetComponent<Canvas>().GetComponent<GraphicRaycaster>();
            ray.enabled = !ray.IsActive();
        }
        priority.GetComponent<GraphicRaycaster>().enabled = true;
    }

    public static GameObject Canvas_Setup(string name,
        Transform parent_tf, out Canvas newCanvas)
    {
        GameObject obj = new GameObject(name) { tag = "Canvas" };
        obj.transform.SetParent(parent_tf, false);

        newCanvas = obj.AddComponent<Canvas>();
        CanvasScaler scaler = obj.AddComponent<CanvasScaler>();
        GraphicRaycaster ray = obj.AddComponent<GraphicRaycaster>();
        RectMask2D mask = obj.AddComponent<RectMask2D>();

        newCanvas.worldCamera = Camera.main;
        newCanvas.renderMode = RenderMode.ScreenSpaceCamera;

        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.matchWidthOrHeight = 1;
        scaler.referencePixelsPerUnit = 100;

        return obj;
    }
    public static GameObject Img_Setup(string obj_name, Transform parent_tf, out Image img, bool raycasted)
    {
        GameObject img_obj = new GameObject(obj_name);
        img_obj.transform.SetParent(parent_tf, false);
        img = img_obj.AddComponent<Image>();

        img.raycastTarget = raycasted;

        return img_obj;
    }
    public static GameObject Img_Setup(string obj_name, Transform parent_tf, out Image img, Sprite sprite, bool raycasted)
    {
        GameObject img_obj = new GameObject(obj_name);
        img_obj.transform.SetParent(parent_tf, false);
        img = img_obj.AddComponent<Image>();
        img.sprite = sprite;
        img.type = Image.Type.Sliced;
        img.pixelsPerUnitMultiplier = 15;

        img.raycastTarget = raycasted;

        return img_obj;
    }
    public static GameObject Text_Setup(string obj_name, Transform parent_tf, out Text txt, bool raycasted)
    {
        GameObject txt_obj = new GameObject(obj_name);
        txt_obj.transform.SetParent(parent_tf, false);
        txt = txt_obj.AddComponent<Text>();

        txt.raycastTarget = raycasted;

        return txt_obj;
    }
    public static GameObject Button_Setup(string obj_name, Transform parent_tf, out Image img, out Button button, Sprite sprite, UnityEngine.Events.UnityAction call)
    {
        GameObject button_obj = new GameObject(obj_name);
        button_obj.transform.SetParent(parent_tf, false);
        img = button_obj.AddComponent<Image>();
        button = button_obj.AddComponent<Button>();

        img.sprite = sprite;
        img.type = Image.Type.Sliced;
        img.pixelsPerUnitMultiplier = 15;
        if (call != null)
            button.onClick.AddListener(call);

        return button_obj;
    }
    public static GameObject Scrollbar_Setup(Transform parent_tf, GameObject scroll_obj, RectTransform content_tf, int width)
    {
        GameObject scrollbar = Img_Setup("Scrollbar", parent_tf, out Image scroll_img, null, true);
        Format_Rect_NPos(scroll_img.rectTransform, new Vector2(width, 0), new Vector2(1, 0), Vector2.one, new Vector2(0, 0.5f));
        scroll_img.pixelsPerUnitMultiplier = 15;
        scroll_img.type = Image.Type.Sliced;
        Scrollbar scroll = scrollbar.AddComponent<Scrollbar>();
        scroll.direction = Scrollbar.Direction.BottomToTop;
        scroll_img.color = new Color(0.6f, 0.6f, 0.6f);

        GameObject scroll_area = new GameObject("Sliding Area");
        scroll_area.transform.SetParent(scrollbar.transform, false);
        Format_Rect_NPos(scroll_area.AddComponent<RectTransform>(), Vector2.zero,
            Vector2.zero, Vector2.one, new Vector2(0.5f, 0.5f));

        GameObject scroll_handle = Img_Setup("Handle", scroll_area.transform, out Image scroll_handle_img, null, true);
        Format_Rect_NPos(scroll_handle_img.rectTransform, Vector2.zero,
            new Vector2(0, 0.5f), new Vector2(1, 0.5f), new Vector2(0.5f, 0.5f));
        scroll.handleRect = scroll_handle_img.rectTransform;
        scroll_handle_img.pixelsPerUnitMultiplier = 15;
        scroll_handle_img.type = Image.Type.Sliced;

        ScrollRect scroll_rect = scroll_obj.AddComponent<ScrollRect>();
        scroll_rect.content = content_tf;
        scroll_rect.horizontal = false;
        scroll_rect.movementType = ScrollRect.MovementType.Clamped;
        scroll_rect.scrollSensitivity = 80;
        scroll_rect.verticalScrollbar = scroll;

        return scrollbar;
    }
    public static GameObject Scrollbar_Setup(Transform parent_tf, GameObject scroll_obj, RectTransform content_tf, 
        Vector2 size, Vector2 a_min, Vector2 a_max, Vector2 pivot, Vector2 a_pos)
    {
        GameObject scrollbar = Img_Setup("Scrollbar", parent_tf, out Image scroll_img, null, true);
        Format_Rect(scroll_img.rectTransform, size, a_min, a_max, pivot, a_pos);
        scroll_img.pixelsPerUnitMultiplier = 15;
        scroll_img.type = Image.Type.Sliced;
        Scrollbar scroll = scrollbar.AddComponent<Scrollbar>();
        scroll.direction = Scrollbar.Direction.BottomToTop;
        scroll_img.color = new Color(0.6f, 0.6f, 0.6f);

        GameObject scroll_area = new GameObject("Sliding Area");
        scroll_area.transform.SetParent(scrollbar.transform, false);
        Format_Rect_NPos(scroll_area.AddComponent<RectTransform>(), Vector2.zero,
            Vector2.zero, Vector2.one, new Vector2(0.5f, 0.5f));

        GameObject scroll_handle = Img_Setup("Handle", scroll_area.transform, out Image scroll_handle_img, null, true);
        Format_Rect_NPos(scroll_handle_img.rectTransform, Vector2.zero,
            new Vector2(0, 0.5f), new Vector2(1, 0.5f), new Vector2(0.5f, 0.5f));
        scroll.handleRect = scroll_handle_img.rectTransform;
        scroll_handle_img.pixelsPerUnitMultiplier = 15;
        scroll_handle_img.type = Image.Type.Sliced;

        ScrollRect scroll_rect = scroll_obj.AddComponent<ScrollRect>();
        scroll_rect.content = content_tf;
        scroll_rect.horizontal = false;
        scroll_rect.movementType = ScrollRect.MovementType.Clamped;
        scroll_rect.scrollSensitivity = 80;
        scroll_rect.verticalScrollbar = scroll;

        return scrollbar;
    }

    public static Text CreateHeader(string text, Transform parent,
        Vector2 size, Vector2 offset, int fontSize)
    {
        GameObject headerObj = Text_Setup(
            "Header", parent,
            out Text header, false);
        Format_Rect(header.rectTransform,
            size, new Vector2(0, 1),
            Vector2.one, new Vector2(),
            offset);
        InterfaceTool.Format_Text(header, SysManager.DEFAULT_FONT,
            fontSize, Color.white, TextAnchor.UpperLeft,
            FontStyle.Normal);
        header.text = text;

        return header;
    }
    public static Text CreateBody(string text, Transform parent, int fontSize)
    {
        GameObject bodyObj = Text_Setup(
            "Body", parent, out Text body,
            false);
        Format_Rect(body.rectTransform);
        Format_Text(body, SysManager.DEFAULT_FONT,
            fontSize, Color.black, TextAnchor.MiddleCenter,
            FontStyle.Normal);
        body.text = text;

        return body;
    }
    public static void Format_Text(Text txt, Font font, int font_size, Color color, TextAnchor alignment, FontStyle style)
    {
        txt.font = font;
        txt.color = color;
        txt.fontSize = font_size;
        txt.alignment = alignment;
        txt.fontStyle = style;
    }

    public static void Format_Rect_NPos(RectTransform tf, Vector2 size, Vector2 a_min, Vector2 a_max, Vector2 pivot)
    {
        tf.sizeDelta = size;
        tf.anchorMin = a_min;
        tf.anchorMax = a_max;
        tf.pivot = pivot;
    }
    public static void Format_Rect_NPos(RectTransform tf, Vector2 size)
    { tf.sizeDelta = size; }

    public static void Format_Rect(RectTransform tf) // For simple text objects : Stretch to fill parent area
    {
        tf.sizeDelta = new Vector2();
        tf.anchorMin = new Vector2();
        tf.anchorMax = Vector2.one;
    }
    public static void Format_Rect(RectTransform tf, Vector2 size, Vector2 a_pos)
    {
        tf.sizeDelta = size;
        tf.anchoredPosition = a_pos;
    }
    public static void Format_Rect(RectTransform tf, Vector2 size, Vector2 a_min, Vector2 a_max, Vector2 a_pos)
    {
        tf.sizeDelta = size;
        tf.anchorMin = a_min;
        tf.anchorMax = a_max;
        tf.anchoredPosition = a_pos;
    }
    public static void Format_Rect(RectTransform tf, Vector2 size, Vector2 a_min, Vector2 a_max, Vector2 pivot, Vector2 a_pos)
    {
        tf.sizeDelta = size;
        tf.anchorMin = a_min;
        tf.anchorMax = a_max;
        tf.pivot = pivot;
        tf.anchoredPosition = a_pos;
    }

    // NOT WORKING PROPERLY
    public static void FormatFillRect(RectTransform tf, 
        float top, float bottom, float left, float right)
    {
        RectTransform parentRectTF = tf.parent.GetComponent<RectTransform>();

        if (parentRectTF == null) return;

        tf.pivot = new Vector2(0.5f, 0);
        tf.anchorMin = new Vector2();
        tf.anchorMax = Vector2.one;
        tf.anchoredPosition = new Vector2((left - right) * 0.5f, bottom);
        tf.sizeDelta = new Vector2(-(left + right), -(parentRectTF.sizeDelta.y - (bottom - top)));
    }

    public static void FormatStretchW(RectTransform tf, 
        float left, float right, float yPos, float height, Vector2 pivot)
    {
        tf.sizeDelta = new Vector2(-(left + right), -height);
        tf.anchorMin = new Vector2();
        tf.anchorMax = Vector2.one;
        tf.pivot = new Vector2(0.5f, 0);
        tf.anchoredPosition = new Vector2((left - right) * 0.5f, yPos);
    }
}