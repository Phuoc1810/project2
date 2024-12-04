using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject explosiveTilePerfab; // prefab của viên gạch
    public int numberOfTiles = 8; // số viên gạch
    public float tileSpacing = 1.5f; // khoảng cách giữa các viên gạch
    public float spawmDelay = 0.5f; // thời gian giữa các lần spawn

    public void SpawmTitleInSequence(Vector3 bossPosition)
    {
        StartCoroutine(SpawmTilesCoroutine(bossPosition));
    }

    private IEnumerator SpawmTilesCoroutine(Vector3 bossPosition)
    {
        Vector3 lastTilePosition = bossPosition; // viên gạch đầu tiên spawn tại vị trí boss

        for (int i = 0; i < numberOfTiles; i++)
        {
            // Spawn viên gạch tại vị trí của viên gạch trước đó
            GameObject tile = Instantiate(explosiveTilePerfab, lastTilePosition, Quaternion.identity);

            // Khởi tạo viên gạch (vẫn giữ vị trí spawn của nó)
            tile.GetComponent<ExplosiveTile>().Initialize(lastTilePosition);

            // Cập nhật vị trí cho viên gạch tiếp theo (dọc theo đường thẳng)
            lastTilePosition += new Vector3(tileSpacing, 0, 0); // move theo hướng thẳng ngang (hoặc điều chỉnh theo ý bạn)

            yield return new WaitForSeconds(spawmDelay);
        }
    }
}
