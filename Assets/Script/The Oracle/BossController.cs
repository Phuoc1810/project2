using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject explosiveTilePerfab; // tham chieu den vien gach
    public Animator animator;
    public float tileSpawmInterval = 0.5f; // khoan thoi gian giua cac lan spawm o vuong
    public int numberOfTile = 8; // so o vuong xuat hien sau moi dot tan cong
    private Transform playerTransform; // vi tri cua nguoi choi
    public float timeStart = 2.5f; // thoi gian de boss bat dau tan cong
    private Vector3 currentDirection; // huong di chuyen cua chuoi gach

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform; // gan transform cua Player vao bien player
        }
        else
        {
            Debug.LogError("Dont Find game object with tag 'Player' !");
        }
        StartAttackSequence();
    }

    public void StartAttackSequence()
    {
        Debug.Log("Attack sequence started");
        StartCoroutine(BossStart());
    }

    private IEnumerator BossStart()
    {
        yield return new WaitForSeconds(timeStart);
        animator.SetTrigger("Attack1");
        animator.SetTrigger("Indle");
        StartCoroutine(SpawmTiles());
    }

    private IEnumerator SpawmTiles()
    {
        Debug.Log("Starting to spawn tiles...");
        yield return new WaitForSeconds(1); // thoi gian cho tuong ung vo animation tan cong

        // lay vi tri hien tai cua player la diem bat dau
        currentDirection = Vector3.up; // huong mac dinh cua vien gach

        float spacing = 1.5f; // khoang cach giua cac vien gach
        Vector3 lastTilePosition = playerTransform.position; // vi tri ban dau la vi tri player

        for (int i = 0; i < numberOfTile; i++)
        {
            // tinh toan vi tri moi (tinh theo vi tri cuoi cùng, không phải vị trí người chơi)
            Vector3 tilePosition = lastTilePosition + currentDirection * spacing;

            // tạo viên gạch tại vị trí tính toán
            if (playerTransform != null)
            {
                Debug.Log("Spawning tile");
                GameObject tile = Instantiate(explosiveTilePerfab, tilePosition, Quaternion.identity);
                tile.GetComponent<ExplosiveTile>().Initialize(playerTransform.position);
            }

            // cap nhat vi tri va huong
            lastTilePosition = tilePosition; // cap nhat vi tri cuoi cho viên gach tiếp theo
            currentDirection = GetNetDerection(currentDirection); // thay doi huong theo chuỗi
            // cho truoc khi tao o vuong tiep theo
            yield return new WaitForSeconds(tileSpawmInterval);
        }
    }

    private Vector3 GetNetDerection(Vector3 current)
    {
        // xoay huong theo chuỗi vuông góc: len, phai, xuong, trai
        if (current == Vector3.up) return Vector3.right;
        if (current == Vector3.right) return Vector3.down;
        if (current == Vector3.down) return Vector3.left;
        return Vector3.up;
    }
}
