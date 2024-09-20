using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject[] row1;
    public GameObject[] row2;
    public GameObject[] row3;
    public GameObject[] row4;
    public GameObject[] row5;
    public GameObject[] row6;
    public GameObject[] row7;
    public GameObject[] row8;

    public GameObject[] col1;
    public GameObject[] col2;
    public GameObject[] col3;
    public GameObject[] col4;
    public GameObject[] col5;
    public GameObject[] col6;
    public GameObject[] col7;
    public GameObject[] col8;


    public List<GameObject[]> rows = new List<GameObject[]>();
    public List<GameObject[]> cols = new List<GameObject[]>();

    public List<GameObject> enemies = new List<GameObject>();

    public int posX;
    public int posY;

    public int lastPosX;
    public int lastPosY;

    public bool blackTurn = false;

    GameObject currentPiece;

    public GameObject[] Pieces;

    public int enemyPosX;
    public int enemyPosY;

    bool selected = false;

    int itwo;

    // Start is called before the first frame update
    void Start()
    {
        rows.Add(row1);
        rows.Add(row2);
        rows.Add(row3);
        rows.Add(row4);
        rows.Add(row5);
        rows.Add(row6);
        rows.Add(row7);
        rows.Add(row8);

        cols.Add(col1);
        cols.Add(col2);
        cols.Add(col3);
        cols.Add(col4);
        cols.Add(col5);
        cols.Add(col6);
        cols.Add(col7);
        cols.Add(col8);
    }

    // Update is called once per frame
    void Update()
    {
        Ray beam = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(beam, out hit) && Input.GetMouseButtonDown(0) && hit.rigidbody != null)
        {
            if (hit.rigidbody.tag == "Rook" && blackTurn == hit.rigidbody.GetComponent<local>().black && selected == false)
            {
                selected = true;
                currentPiece = hit.rigidbody.gameObject;
                posX = currentPiece.GetComponent<local>().posX;
                posY = currentPiece.GetComponent<local>().posY;
                lastPosX = currentPiece.GetComponent<local>().lastPosX;
                lastPosY = currentPiece.GetComponent<local>().lastPosY;
                for (int i = posX; i <= 7; i++)
                {
                    rows[posY - 1][i].SetActive(true);
                    if (rows[posY - 1][i].GetComponent<local>().filled == true)
                    {

                        enemies.Add(rows[posY - 1][i]);
                        rows[posY - 1][i].SetActive(false);
                        break;
                    }
                }
                for (int i = posX - 2; i >= 0; i--)
                {
                    rows[posY - 1][i].SetActive(true);
                    if (rows[posY - 1][i].GetComponent<local>().filled == true)
                    {
                        enemies.Add(rows[posY - 1][i]);
                        rows[posY - 1][i].SetActive(false);
                        break;
                    }
                }

                for (int i = posY; i <= 7; i++)
                {
                    cols[posX - 1][i].SetActive(true);
                    if (cols[posX - 1][i].GetComponent<local>().filled == true)
                    {
                        enemies.Add(cols[posX - 1][i]);
                        cols[posX - 1][i].SetActive(false);
                        break;
                    }
                }
                for (int i = posY - 2; i >= 0; i--)
                {
                    cols[posX - 1][i].SetActive(true);
                    if (cols[posX - 1][i].GetComponent<local>().filled == true)
                    {
                        enemies.Add(cols[posX - 1][i]);
                        cols[posX - 1][i].SetActive(false);
                        break;
                    }
                }
            }
            if (hit.rigidbody.tag == "Bishop" && blackTurn == hit.rigidbody.GetComponent<local>().black && selected == false)
            {
                selected = true;
                currentPiece = hit.rigidbody.gameObject;
                posX = currentPiece.GetComponent<local>().posX;
                posY = currentPiece.GetComponent<local>().posY;
                lastPosX = currentPiece.GetComponent<local>().lastPosX;
                lastPosY = currentPiece.GetComponent<local>().lastPosY;
                itwo = 1;   
                //for (int i = posX; i <= 7 && ((posY - 1) + itwo) <= 7; i++)
                for (int i = posX; i < 7 && ((posY - 1) + itwo) < 7; i++)
                {
                    rows[(posY-1) + itwo][i].SetActive(true);
                    if (rows[(posY - 1) + itwo][i].GetComponent<local>().filled == true)
                    {

                        enemies.Add(rows[(posY - 1) + i][i]);
                        rows[(posY - 1) + itwo][i].SetActive(false);
                        break;
                    }
                    itwo++;
                }
                itwo = 1;
                for (int i = posX-2; i > 0 && ((posY - 1) + itwo) < 7; i--)
                {
                    rows[(posY - 1) + itwo][i].SetActive(true);
                    if (rows[(posY - 1) + itwo][i].GetComponent<local>().filled == true)
                    {

                        enemies.Add(rows[(posY - 1) + i][i]);
                        rows[(posY - 1) + itwo][i].SetActive(false);
                        break;
                    }
                    itwo++;

                }
                itwo = -1;
                for (int i = posX - 2; i > 0 && ((posY - 1) + itwo) > 0; i--)
                {
                    rows[(posY - 1) + itwo][i].SetActive(true);
                    if (rows[(posY - 1) + itwo][i].GetComponent<local>().filled == true)
                    {

                        enemies.Add(rows[(posY - 1) + i][i]);
                        rows[(posY - 1) + itwo][i].SetActive(false);
                        break;
                    }
                    itwo--;

                }
                
                itwo = -1;
                for (int i = posX; i < 7 && ((posY - 1) + itwo) > 0; i++)
                {
                    rows[(posY - 1) + itwo][i].SetActive(true);
                    if (rows[(posY - 1) + itwo][i].GetComponent<local>().filled == true)
                    {

                        enemies.Add(rows[(posY - 1) + i][i]);
                        rows[(posY - 1) + itwo][i].SetActive(false);
                        break;
                    }
                    itwo--;

                }
            }

            if (hit.rigidbody.tag == "Rook" && currentPiece.GetComponent<local>().black != hit.rigidbody.GetComponent<local>().black)
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    if (enemies[j].GetComponent<local>().posX == hit.rigidbody.GetComponent<local>().posX && enemies[j].GetComponent<local>().posY == hit.rigidbody.GetComponent<local>().posY)
                    {

                        currentPiece.transform.position = new Vector3(hit.rigidbody.transform.position.x, 1, hit.rigidbody.transform.position.z);

                        currentPiece.GetComponent<local>().posX = hit.rigidbody.GetComponent<local>().posX;
                        currentPiece.GetComponent<local>().posY = hit.rigidbody.GetComponent<local>().posY;

                        for (int i = 0; i < rows[lastPosY - 1].Length; i++)
                        {
                            if (rows[lastPosY - 1][i].GetComponent<local>().posX == lastPosX)
                            {
                                rows[lastPosY - 1][i].GetComponent<local>().filled = false;
                            }
                            rows[lastPosY - 1][i].SetActive(false);
                        }
                        for (int i = 0; i < cols[lastPosX - 1].Length; i++)
                        {
                            cols[lastPosX - 1][i].SetActive(false);
                        }
                        currentPiece.GetComponent<local>().lastPosX = currentPiece.GetComponent<local>().posX;
                        currentPiece.GetComponent<local>().lastPosY = currentPiece.GetComponent<local>().posY;

                        Destroy(hit.rigidbody.gameObject);

                        selected = false;
                        if (enemies.Count > 0)
                            enemies.Clear();
                        blackTurn = !blackTurn;
                        break;
                    }
                }
            }

            if (hit.rigidbody.tag == "Space")
            {

                currentPiece.transform.position = new Vector3(hit.rigidbody.transform.position.x, 1, hit.rigidbody.transform.position.z);
                hit.rigidbody.GetComponent<local>().filled = true;
                currentPiece.GetComponent<local>().posX = hit.rigidbody.GetComponent<local>().posX;
                currentPiece.GetComponent<local>().posY = hit.rigidbody.GetComponent<local>().posY;

                for (int i = 0; i < rows[lastPosY - 1].Length; i++)
                {
                    if (rows[lastPosY - 1][i].GetComponent<local>().posX == lastPosX)
                    {
                        rows[lastPosY - 1][i].GetComponent<local>().filled = false;
                    }
                        rows[lastPosY - 1][i].SetActive(false);
                }
                for (int i = 0; i < cols[lastPosX - 1].Length; i++)
                {
                    cols[lastPosX - 1][i].SetActive(false);
                }
                currentPiece.GetComponent<local>().lastPosX = currentPiece.GetComponent<local>().posX;
                currentPiece.GetComponent<local>().lastPosY = currentPiece.GetComponent<local>().posY;

                selected = false;
                if (enemies.Count > 0)
                    enemies.Clear();
                blackTurn = !blackTurn;
            }
            

            /*
            for (int i = 0; i < row4.Length; i++)
            {
                if (row4[i] == hit.rigidbody.gameObject)
                {
                    Debug.Log(hit.rigidbody.gameObject);
                    transform.position = new Vector3(hit.rigidbody.transform.position.x, transform.position.y, transform.position.z);
                    break;
                }
            }
            */
        }
    }
}
