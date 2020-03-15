using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public static Line instance;
    int vertexCount = 0;
    bool mouseDown = false;
    LineRenderer line;
    public GameObject blast;
    public bool gameOver;
    public GameObject cut1;
    public GameObject cut2;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetMouseButtonDown(0) && !gameOver)
            {
                mouseDown = true;
            }
            if (mouseDown)
            {
                line.positionCount = (vertexCount + 1);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector3 adjPos = new Vector3(mousePos.x, mousePos.y, mousePos.z + 2);
                line.SetPosition(vertexCount, adjPos);
                //line.SetPosition(vertexCount, mousePos);
                vertexCount++;

                BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
                box.transform.position = line.transform.position;
                box.size = new Vector2(0.5f, 0.5f);
            }
            if (Input.GetMouseButtonUp(0))
            {
                mouseDown = false;
                vertexCount = 0;
                line.positionCount = (0);

                BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D box in colliders)
                {
                    Destroy(box);
                }

            }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bomb" && !gameOver)
        {
            Destroy(col.gameObject); 
            GameObject b = Instantiate(blast, col.transform.position, Quaternion.identity) as GameObject;
            Destroy(b.gameObject, 5f);
            gameOver = true;              
            GameManager.instance.GameOver();
            

        }
        if (col.gameObject.tag == "fruit")
        {
            col.gameObject.tag = "Line";
            Destroy(col.gameObject);
            ScoreManager.instance.IncrementScore();
            GameObject c1 = Instantiate(cut1, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            GameObject c2 = Instantiate(cut2, new Vector3(col.gameObject.transform.position.x - 2f, col.gameObject.transform.position.y, 0), cut2.transform.rotation) as GameObject;



            c1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 2f), ForceMode2D.Impulse);
            c1.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-2f, 2f), ForceMode2D.Impulse);

            c2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 2f), ForceMode2D.Impulse);
            c2.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-2f, 2f), ForceMode2D.Impulse);

        }

    }
}
