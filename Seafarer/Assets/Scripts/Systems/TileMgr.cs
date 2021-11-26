using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMgr : MonoBehaviour
{
    public Tilemap fogTilemap;
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

    void Update()
    {

    }

    private void LateUpdate()
    {
        UpdateFog();
    }

    // 初始化地图雾
    private void InitFog()
    {
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
