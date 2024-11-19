using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedichuyen : MonoBehaviour
{

    [SerializeField] private AudioClip jumpsound;
    bool isground;
    public Rigidbody2D rb;

    public Vector3 Moveinput;

    public Animator anim;

    public float wspeed;
    public float rspeed;
    public float speed;
    public float jump;
    private bool doublejump;

    public bool right = true;
    private bool candash = true;
    private bool isdashing;
    private float dashingpower = 24f;
    private float dashingtime = 0.2f;
    private float dashingcooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isdashing)
        {
            return;
        }

        dichuye();

        if (Input.GetKey(KeyCode.LeftShift))
            speed = rspeed;
        else
            speed = wspeed;
        if (Input.GetKeyDown(KeyCode.F) && candash)
        {
            StartCoroutine(Dash());
        }
      
    }
    private void FixedUpdate()
    {
        if (isdashing)
        {
            return;
        }
    }

    void dichuye()
    {
        Moveinput.x = Input.GetAxis("Horizontal");
        Moveinput.y = Input.GetAxis("Vertical");
        transform.position += Moveinput * speed * Time.deltaTime;
        anim.SetFloat("move", Moveinput.sqrMagnitude);
        if (Moveinput.x != 0)
        {
            if (Moveinput.x > 0)
                transform.localScale = new Vector3(1, 1, 0);
            else
                transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    private IEnumerator Dash()
    {
        candash = false;
        isdashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingpower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingtime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isdashing = false;
        yield return new WaitForSeconds(dashingcooldown);
        candash = true;
    }
    
}
