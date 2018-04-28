using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D level;
    public PixelToPrefab[] colourMap;
    // Use this for initialization
    void Awake()
    {
        LevelGenerate();
    }

    void LevelGenerate()
    {
        for (int x = 0; x < level.width; x++)
        {
            for (int z = 0; z < level.height; z++)
            {
                TileGenerate(x, z);
            }
        }
    }

    void TileGenerate(int x, int z)
    {
        Color pixel = level.GetPixel(x, z);

        if (pixel.a == 0)
        {
            return;
        }

        foreach (PixelToPrefab mapColours in colourMap)
        {
            if (mapColours.colour.Equals(pixel))
            {
                Vector3 pos = new Vector3(x, 0, z);
                GameObject tilesObj = Instantiate(mapColours.prefabObj, pos, Quaternion.identity);
                tilesObj.transform.parent = gameObject.transform;
            }
        }
    }
}
