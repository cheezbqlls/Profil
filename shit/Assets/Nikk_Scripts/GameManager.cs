using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Elements")]
    [Range(2, 6)]
    [SerializeField] private int dificulty = 4;
    [SerializeField] private Transform gameHolder;
    [SerializeField] private Transform piecePrefab;

    [Header("UI Elements")]
    [SerializeField] private List<Texture2D> imageTextures;
    [SerializeField] private Transform levelSelectPanel;
    [SerializeField] private Image levelSelectPrefab;

    private List<Transform> pieces;
    private Vector2Int dimensions;

    private float width;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Texture2D texture in imageTextures)
        {
            Image image = Instantiate(levelSelectPrefab, levelSelectPanel);
            image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            image.GetComponent<Button>().onClick.AddListener(delegate { StartGame(texture); });
        }
    }

    public void StartGame(Texture2D jigsawTexture)
    {
        //Gömma UI
        levelSelectPanel.gameObject.SetActive(false);

        //Lista som storarar varje bit so vi kan hitta dem
        pieces = new List<Transform>();

        dimensions = GetDimensions(jigsawTexture, dificulty);

        CreateJigsawPieces(jigsawTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2Int GetDimensions(Texture2D jigsawTexture, int Dificulty)
    {
        Vector2Int dimensions = Vector2Int.zero;

        if(jigsawTexture.width < jigsawTexture.height)
        {
            dimensions.x = dificulty;
            dimensions.y = (dificulty * jigsawTexture.height) / jigsawTexture.width;

        }
        else
        {
            dimensions.x = (dificulty * jigsawTexture.height) / jigsawTexture.width;
            dimensions.y = dificulty;

        }

        return dimensions;
    }

    void CreateJigsawPieces(Texture2D jigsawTexture)
    {
        //calculerer storlek på del beroende på dimensionerna
        height = 1f / dimensions.y;
        float aspect = (float)jigsawTexture.width / jigsawTexture.height;
        width = aspect / dimensions.x;

        for (int row = 0; row < dimensions.y; row++)
        {
            for (int col = 0; col < dimensions.x ; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameHolder);
                piece.localPosition = new Vector3((-width * dimensions.x / 2) + (width * col) + (width / 2), (-height * dimensions.y) + (height * row) + (height / 2), -1);
                piece.localScale = new Vector3(width, height, 1f);

                piece.name = $"Piece {(row * dimensions.x) + col}";
                pieces.Add(piece);

                float width1 = 1f / dimensions.x;
                float height1 = 1f / dimensions.y;

                Vector2[] uv = new Vector2[4];
                uv[0] = new Vector2(width1 * col, height1 * row);
                uv[1] = new Vector2(width1 * (col+ 1), height1 * row);
                uv[2] = new Vector2(width1 * col, height1 * (row+1));
                uv[3] = new Vector2(width1 * (col+1), height1 * (row+1));

                Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                mesh.uv = uv;
                piece.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", jigsawTexture);

            }
        }

    }
}
