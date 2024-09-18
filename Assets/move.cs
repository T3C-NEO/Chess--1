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

    public int posX = 2;
    public int posY = 4;

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
            if (hit.rigidbody.tag == "Rook")
            {      
                for (int i = posX; i <= 7; i++)
                {
                    rows[posY - 1][i].SetActive(true);
                }
                for (int i = posX - 2; i >= 0; i--)
                {
                    rows[posY - 1][i].SetActive(true);
                }
            
                for (int i = posY; i <= 7; i++)
                {
                    cols[posX - 1][i].SetActive(true);
                }
                for (int i = posY - 2; i >= 0; i--)
                {
                    cols[posX - 1][i].SetActive(true);
                }
            }

            if (hit.rigidbody.tag == "Finish")
            {
                
                transform.position = new Vector3(hit.rigidbody.transform.position.x, transform.position.y, hit.rigidbody.transform.position.z);
                posX = hit.rigidbody.GetComponent<local>().posX;
                posY = hit.rigidbody.GetComponent<local>().posY;
                for (int i = 0; i < rows[posY - 1].Length; i++)
                {
                    rows[posY - 1][i].SetActive(false);
                }
                for (int i = 0; i < cols[posX - 1].Length; i++)
                {
                    cols[posX - 1][i].SetActive(false);
                }
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
