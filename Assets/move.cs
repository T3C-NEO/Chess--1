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

    public int posX;
    public int posY;

    public int lastPosX;
    public int lastPosY;

    public bool blackTurn = false;

    GameObject currentPiece;

    public GameObject[] Pieces;

    public int enemyPosX;
    public int enemyPosY;

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
            if (hit.rigidbody.tag == "Rook" && blackTurn == hit.rigidbody.GetComponent<local>().black)
            {
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
                        enemyPosX = rows[posY - 1][i].GetComponent<local>().posX;
                        enemyPosY = rows[posY - 1][i].GetComponent<local>().posY;
                        rows[posY - 1][i].SetActive(false);
                        break;
                    }
                }
                for (int i = posX - 2; i >= 0; i--)
                {
                    rows[posY - 1][i].SetActive(true);
                    if (rows[posY - 1][i].GetComponent<local>().filled == true)
                    {
                        enemyPosX = rows[posY - 1][i].GetComponent<local>().posX;
                        enemyPosY = rows[posY - 1][i].GetComponent<local>().posY;
                        rows[posY - 1][i].SetActive(false);
                        break;
                    }
                }

                for (int i = posY; i <= 7; i++)
                {
                    cols[posX - 1][i].SetActive(true);
                    if (cols[posX - 1][i].GetComponent<local>().filled == true)
                    {
                        enemyPosX = rows[posY - 1][i].GetComponent<local>().posX;
                        enemyPosY = rows[posY - 1][i].GetComponent<local>().posY;
                        cols[posX - 1][i].SetActive(false);
                        break;
                    }
                }
                for (int i = posY - 2; i >= 0; i--)
                {
                    cols[posX - 1][i].SetActive(true);
                    if (cols[posX - 1][i].GetComponent<local>().filled == true)
                    {
                        enemyPosX = rows[posY - 1][i].GetComponent<local>().posX;
                        enemyPosY = rows[posY - 1][i].GetComponent<local>().posY;
                        cols[posX - 1][i].SetActive(false);
                        break;
                    }
                }
            }

            if (hit.rigidbody.tag == "Rook" && blackTurn != hit.rigidbody.GetComponent<local>().black)
            {
                if (enemyPosX == hit.rigidbody.GetComponent<local>().posX && enemyPosY == hit.rigidbody.GetComponent<local>().posY)
                {
                    currentPiece.transform.position = new Vector3(hit.rigidbody.transform.position.x, 1, hit.rigidbody.transform.position.z);
                    Destroy(hit.rigidbody);

                    blackTurn = !blackTurn;
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
