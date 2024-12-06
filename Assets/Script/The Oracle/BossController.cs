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
        StartCoroutine(SpawmTiles());
    }

    private IEnumerator SpawmTiles()
    {
        Debug.Log("Starting to spawn tiles...");

        while (true)
        {
            yield return new WaitForSeconds(1); // thoi gian cho tuong ung vo animation tan cong

            animator.SetTrigger("Attack1");

            // lay vi tri hien tai cua player la diem bat dau
            currentDirection = (playerTransform.position - transform.position).normalized; // huong mac dinh cua vien gach

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
                // cho truoc khi tao o vuong tiep theo
                yield return new WaitForSeconds(tileSpawmInterval);
            }
            animator.SetTrigger("Indle");
            yield return new WaitForSeconds(3); //dot tan con tiep theo
        }
    }
}
