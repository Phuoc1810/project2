using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject explosiveTilePerfab; // Prefab của viên gạch
    public int numberOfTiles = 8; // Số lượng viên gạch cần spawn
    public float tileSpacing = 1.5f; // Khoảng cách giữa các viên gạch

    // Phương thức spawn các viên gạch theo đường vuông góc
    public void SpawnTiles(Vector3 startPosition, Transform playerTransform)
    {
        StartCoroutine(SpawnTilesCoroutine(startPosition, playerTransform));
    }

    private IEnumerator SpawnTilesCoroutine(Vector3 startPosition, Transform playerTransform)
    {
        Vector3 directionToPlayer = (playerTransform.position - startPosition).normalized; // Tính hướng từ boss đến player

        // Tính hướng vuông góc với hướng từ boss đến player. 
        Vector3 perpendicularDirection = new Vector3(-directionToPlayer.y, directionToPlayer.x, 0); // Vector vuông góc (xoay 90 độ)

        Vector3 lastTilePosition = startPosition; // Vị trí viên gạch đầu tiên là vị trí của boss

        for (int i = 0; i < numberOfTiles; i++)
        {
            // Spawn viên gạch tại vị trí tính toán
            GameObject tile = Instantiate(explosiveTilePerfab, lastTilePosition, Quaternion.identity);
            tile.GetComponent<ExplosiveTile>().Initialize(lastTilePosition);

            // Tính vị trí cho viên gạch tiếp theo, di chuyển theo hướng vuông góc
            lastTilePosition += perpendicularDirection * tileSpacing; // Di chuyển viên gạch tiếp theo theo hướng vuông góc với đường nối boss-player

            // Chờ một chút trước khi spawn viên gạch tiếp theo
            yield return new WaitForSeconds(0.3f); // Thời gian chờ giữa các lần spawn
        }
    }
}
