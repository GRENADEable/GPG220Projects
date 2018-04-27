using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D level;
    // Use this for initialization
    void Start()
    {
        LevelGenerate();
    }

    void LevelGenerate()
    {
        for (int i = 0; i < level.width; i++)
        {
            for (int j = 0; j < level.height; j++)
            {
                TileGenerate(i, j);
            }
        }
    }

    void TileGenerate(int x, int y)
    {
        Color pixel = level.GetPixel(x, y);
		
        if (pixel.a == 0)
        {
            return;
        }
    }
}
