using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject explosiveTilePerfab; //tham chieu den vien gach
    public Animator animator;
    public float tileSpawmInterval = 0.5f; //khoan thoi gian giua cac lan spawm o vuong
    public int numberOfTile = 8; //so o vuon xuat hien sau moi dot tan cong
    private Transform playerTransform; //vi tri cua nguoi choi
    public float timeStart = 2.5f;//thoi gian de boss bat dau tan cong
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            playerTransform = player.transform; //gan transform cua Player vao bien player
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
        yield return new WaitForSeconds(1); //thoi gian cho tuong ung vo animation tan cong

        Vector3 startPosition = playerTransform.position;

        int tilesPerRows = 16; //moi dong co toi da 16 vien gach
        int rows = numberOfTile / tilesPerRows; //tinh so hang

        for(int i = 0; i < numberOfTile; i++)
        {
            //tinh toan vi tri cho moi vien gach theo mo hinh luoi
            int row = i / tilesPerRows; //xac dinh dong cua vien gach
            int column = i % tilesPerRows; //cot cua vien gach 

            //tinh toan vi tri theo hinh vuong goc (tao luoi)
            Vector3 tilePosition = startPosition + new Vector3(column * 1.0f, row * 1.0f, 0); //1.0 la khoang cach giua cac vien gach
            if (playerTransform != null)
            {
                Debug.Log("Spawning tile");
                //tao vien gach tai vi tri nguoi choi
                GameObject tile = Instantiate(explosiveTilePerfab, tilePosition, Quaternion.identity);
                tile.GetComponent<ExplosiveTile>().Initialize(playerTransform.position);
            }

            //cho truoc khi tao o vuong tiep theo
            yield return new WaitForSeconds(tileSpawmInterval);
        }
    }
}
