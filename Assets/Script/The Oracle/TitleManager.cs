using System.Collections;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject explosiveTilePrefab; // Prefab của viên gạch
    public int numberOfTiles = 8; // Số lượng viên gạch
    public float distanceBetweenTiles = 0.3f; // Khoảng cách giữa các viên gạch

    public void SpawnTiles(Vector3 bossPosition, Vector3 playerPosition)
    {
        StartCoroutine(SpawnTilesCoroutine(bossPosition, playerPosition));
    }

    private IEnumerator SpawnTilesCoroutine(Vector3 bossPosition, Vector3 playerPosition)
    {
        Vector3 directionToPlayer = (playerPosition - bossPosition).normalized; // Tính hướng từ boss tới player

        for (int i = 0; i < numberOfTiles; i++)
        {
            // Tính vị trí spawn cho viên gạch tiếp theo theo đường vuông góc
            Vector3 spawnPosition = bossPosition + new Vector3(directionToPlayer.y, -directionToPlayer.x, 0) * (i * distanceBetweenTiles);

            // Spawn viên gạch tại vị trí tính được
            Instantiate(explosiveTilePrefab, spawnPosition, Quaternion.identity);

            // Đợi trước khi spawn viên tiếp theo
            yield return new WaitForSeconds(0.5f); // Thời gian delay giữa các lần spawn viên gạch
        }
    }
}
