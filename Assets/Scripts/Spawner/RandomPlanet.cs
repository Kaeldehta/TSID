using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RandomPlanet : MonoBehaviour
{
    [SerializeField]
    private int planetRadius = 300;
    [SerializeField]
    private float scale = 5;

    void Start()
    {

        Texture2D planetTexture = new Texture2D(planetRadius, planetRadius);

        Color[] pix = new Color[planetTexture.width * planetTexture.height];

        Color color1 = Random.ColorHSV();
        Color color2 = Random.ColorHSV();

        float color1H, color1S, color1V, color2H, color2S, color2V;

        Color.RGBToHSV(color1, out color1H, out color1S, out color1V);

        Color.RGBToHSV(color2, out color2H, out color2S, out color2V);

        float xOrg = Random.value * 10000;
        float yOrg = Random.value * 10000;


        for (float i = 0; i < planetTexture.width; i++)
        {
            for (float j = 0; j < planetTexture.height; j++)
            {
                float xCoord = xOrg + i / planetTexture.width * scale;
                float yCoord = yOrg + j / planetTexture.height * scale;

                float x = Mathf.PerlinNoise(xCoord, yCoord);
                //Debug.Log(x);
                Color color = new Color(x, x, x);

                if (x < 0.5f)
                {
                    color = Color.HSVToRGB(0.65f, 1, Mathf.Clamp(x, 0.3f, 0.5f) * 1.5f);
                }
                else
                {
                    color = Color.HSVToRGB(color2H, color2S, x);
                }

                pix[(int)j * planetTexture.width + (int)i] = color;
            }
        }

        planetTexture.SetPixels(pix);
        planetTexture.Apply();
        var pngData = planetTexture.EncodeToPNG();

        File.WriteAllBytes("Assets/texture.png", pngData);
    }

}
