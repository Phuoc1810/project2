using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private int rspeed;
    [SerializeField] private int speed;
    private Rigidbody2D rb;
    private Animator anim;
    public static player _instance;

    public string namescene;
    public string lastscene;
    public Transform attackpoint;
    
    private float attacktime=.25f;
    private float attackcouter=.25f;
    private bool isattacking= false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //singleton: 1 chay xuyen suot 1 game;
        // khong xoa nv khi chuyen scene
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");
        //khuyen khich dung rigidbody de di chuyen
        anim.SetFloat("lastmoveX", moveX);
        anim.SetFloat("lastmoveY", moveY);
        if(Input.GetKey(KeyCode.LeftShift))
        rb.velocity = new Vector2(moveX, moveY) * rspeed;
        else
          rb.velocity = new Vector2(moveX, moveY) * speed;
        
        if (moveX >= 0.1 || moveX <= -0.1 || moveY >= 0.1 || moveY <= -0.1)
        {
            anim.SetFloat("moveX", moveX);
            anim.SetFloat("moveY", moveY);
        }
        if(isattacking)
        {
            
            attackcouter -= Time.deltaTime;
            if(attackcouter<=0)
            {
                anim.SetBool("isattacking", false);
                isattacking = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            attackcouter = attacktime;
            anim.SetBool("isattacking", true);
            isattacking = true;
        }
       
    }
}
