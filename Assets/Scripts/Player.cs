using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public GameObject bullet;
    public GameObject panelMenu;
    public GameObject resumeMenu;
    public GameObject buttonStart;
    public Text textPoint;

    public Joystick moveJoystick;
    public float speed = 0.1f;
    public float speed1 = 5f;
    public Vector3 direction;

    private float cameraHeight;
    private float cameraWidth;
    private float widthPlayer;
    private float heightPlayer;

    private Animator anim;
    int idle = 0;
    int right = 1;
    int left = -1;


    public class rs
    {
        private int id;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;

        widthPlayer = (GetComponent<SpriteRenderer>().bounds.size.x) / 2;
        heightPlayer = (GetComponent<SpriteRenderer>().bounds.size.y) / 2;

        UnityWebRequest ww = UnityWebRequest.Get("http://demo.wp-api.org/wp-json/wp/v2/posts");
        rs t = JsonUtility.FromJson<rs>(ww.downloadHandler.text);

        Debug.Log(ww.downloadHandler.text);
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveJoystick();
        InputControl();
    }

    private void MoveJoystick()
    {
        direction = moveJoystick.InputDirection;
        if (direction.magnitude != 0)
        {
            if(direction.x < 0)
            {
                anim.SetBool("Left", true);
                //anim.SetFloat("Hai", direction.x);
                anim.SetFloat("LR", direction.x);
                transform.position += direction * speed;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -cameraWidth + widthPlayer, cameraWidth - widthPlayer), Mathf.Clamp(transform.position.y, -cameraHeight + heightPlayer, cameraHeight - heightPlayer), transform.position.z);
            } else if(direction.x > 0)
            {
                anim.SetBool("Right", true);
                anim.SetFloat("LR", direction.x);
                transform.position += direction * speed;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -cameraWidth + widthPlayer, cameraWidth - widthPlayer), Mathf.Clamp(transform.position.y, -cameraHeight + heightPlayer, cameraHeight - heightPlayer), transform.position.z);
            }
        }
        else
        {
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
        }
    }

    public void InputControl()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Left", true);

            if (transform.position.x > -cameraWidth)
            {
                transform.Translate(Vector3.left * speed1 * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < cameraWidth)
            {
                transform.Translate(Vector3.right * speed1 * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y < cameraHeight)
            {
                transform.Translate(Vector3.up * speed1 * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > -cameraHeight)
            {
                transform.Translate(Vector3.down * speed1 * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            SoundManagerScript.soundGameOver();
            PointSingleton.Instance.Point += 1;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Time.timeScale = 0;
            panelMenu.SetActive(true);
            buttonStart.SetActive(true);
            resumeMenu.SetActive(false);
        } else if(collision.tag.Equals("Rook") || collision.tag.Equals("BulletEnemy"))
        {
            SoundManagerScript.soundGameOver();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Time.timeScale = 0;
            panelMenu.SetActive(true);
            buttonStart.SetActive(true);
            resumeMenu.SetActive(false);
        }
    }

    // Event click
    public void ClickShooter()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
