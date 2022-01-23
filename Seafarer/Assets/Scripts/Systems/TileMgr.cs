using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMgr : MonoBehaviour
{
    #region Singleton
    public static TileMgr Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion


    public bool fogActive;
    public Tilemap fogTilemap, landTilemap;
    public Tile fogBig, fogSmall;
    public int mapWidth, mapHeight;

    private int playerFov = 2;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerFov = player.GetComponent<Player>().fov;

        InitFog();
    }

    private void LateUpdate()
    {
        UpdateFog();
    }

    // 初始化地图雾
    private void InitFog()
    {
        if (!fogActive) return;
        for (int dx = -mapWidth; dx <= mapWidth; dx++)
        {
            for (int dy = -mapHeight; dy <= mapHeight; dy++)
            {
                fogTilemap.SetTile(new Vector3Int(dx, dy, 0), fogBig);
            }
        }
    }

    void UpdateFog()
    {
        if (!fogActive) return;

        Vector3Int playerPos = fogTilemap.WorldToCell(player.transform.position);

        // 视野范围
        for (int dx = -playerFov; dx <= playerFov; dx++)
        {
            for (int dy = -playerFov; dy <= playerFov; dy++)
            {
                fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), null);
            }
        }

        Vector3Int tilePos;
        #region 可能的外边缘
        // 当前算法有问题。传送的话会有BUG
        for (int dx = -playerFov-1; dx <= playerFov + 1; dx++)
        {
            tilePos = playerPos + new Vector3Int(dx, -playerFov-1, 0);
            if (fogTilemap.GetTile(tilePos) != fogBig)
                fogTilemap.SetTile(tilePos, fogSmall);
            tilePos = playerPos + new Vector3Int(dx, playerFov+1, 0);
            if (fogTilemap.GetTile(tilePos) != fogBig)
            fogTilemap.SetTile(tilePos, fogSmall);
        }
        for (int dy= -playerFov-1; dy <= playerFov + 1; dy++)
        {
            tilePos = playerPos + new Vector3Int(-playerFov-1, dy, 0);
            if (fogTilemap.GetTile(tilePos) != fogBig)
                fogTilemap.SetTile(tilePos, fogSmall);
            tilePos = playerPos + new Vector3Int(playerFov+1, dy, 0);
            if (fogTilemap.GetTile(tilePos) != fogBig)
                fogTilemap.SetTile(tilePos, fogSmall);
        }
        #endregion
    }

    public bool IsPlayerOnLand()
    {
        Vector3Int playerPos = fogTilemap.WorldToCell(player.transform.position);
        if (landTilemap.HasTile(playerPos))
            return true;
        return false;
    }
    // void UpdateFog2()
    // {
    //     Vector3Int playerPos = fogTilemap.WorldToCell(player.transform.position);
    //     for (int dx = -10; dx <= 10; dx++)
    //     {
    //         for (int dy = -6; dy <= 6; dy++)
    //         {
    //             if (Mathf.Abs(dx) <= playerFov && Mathf.Abs(dy) <= playerFov)
    //                 fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), null);
    //             else if (Mathf.Abs(dx) <= playerFov + 1 && Mathf.Abs(dy) <= playerFov + 1)
    //                 fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), fogSmall);
    //             else
    //                 fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), fogBig);
    //         }
    //     }
    // }
}
