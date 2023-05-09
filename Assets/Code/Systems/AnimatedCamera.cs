using UnityEngine;

[RequireComponent(typeof(Camera))]
public class AnimatedCamera : MonoBehaviour
{
    Camera cam;

    const float DELTA_ANGLE = 0.01f;

    float sinAngle = 0;
    float rStart = 0.2f, rEnd = 0.225f,
          gStart = 0.2f, gEnd = 0.25f,
          bStart = 0.5f, bEnd = 0.525f;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        float sinVal = Mathf.Pow(Mathf.Sin(sinAngle), 2);
        float bgR = Mathf.Lerp(rStart, rEnd, sinVal),
              bgG = Mathf.Lerp(gStart, gEnd, sinVal),
              bgB = Mathf.Lerp(bStart, bEnd, sinVal);
        
        cam.backgroundColor = new Color(bgR, bgG, bgB);

        sinAngle += DELTA_ANGLE;
    }

    public void SetColors(Color start, Color end)
    {
        SetStart(start);
        SetEnd(end);
    }

    void SetStart(Color sColor)
    {
        rStart = sColor.r;
        gStart = sColor.g;
        bStart = sColor.b;
    }

    void SetEnd(Color eColor)
    {
        rEnd = eColor.r;
        gEnd = eColor.g;
        bEnd = eColor.b;
    }
}