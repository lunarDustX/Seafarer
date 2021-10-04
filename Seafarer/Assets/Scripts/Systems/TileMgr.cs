using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMgr : MonoBehaviour
{
    public Tilemap fogTilemap;
    public Tile fogBig, fogSmall;

    private int playerFov = 2;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerFov = player.GetComponent<Player>().fov;
    }

    void Update()
    {

    }

    private void LateUpdate()
    {
        UpdateFog();
    }

    void UpdateFog()
    {
        Vector3Int playerPos = fogTilemap.WorldToCell(player.transform.position);
        for (int dx = -10; dx <= 10; dx++)
        {
            for (int dy = -6; dy <= 6; dy++)
            {
                if (Mathf.Abs(dx) <= playerFov && Mathf.Abs(dy) <= playerFov)
                    fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), null);
                else if (Mathf.Abs(dx) <= playerFov + 1 && Mathf.Abs(dy) <= playerFov + 1)
                    fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), fogSmall);
                else
                    fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), fogBig);
                /*
                int SQRD = dx * dx + dy * dy;
                if (SQRD <= playerFov * playerFov)
                    fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), null);
                else if (SQRD <= (playerFov + 1) * (playerFov + 1))
                    fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), fogSmall);
                else
                    fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), fogBig);
                */
            }
        }
    }
}
