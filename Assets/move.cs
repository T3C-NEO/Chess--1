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
    public GameObject[] colE;


    public List<GameObject[]> rows = new List<GameObject[]>();

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
                for(int i = posX; i < 8; i++)
                {
                    rows[posX].s
                }
            }
            transform.position = new Vector3(hit.rigidbody.transform.position.x, transform.position.y, hit.rigidbody.transform.position.z);

            posX = hit.rigidbody.GetComponent<local>().posX;
            posY = hit.rigidbody.GetComponent<local>().posY;

            Debug.Log("d");
            for (int i = 0; i < row4.Length; i++)
            {
                if (row4[i] == hit.rigidbody.gameObject)
                {
                    Debug.Log(hit.rigidbody.gameObject);
                    transform.position = new Vector3(hit.rigidbody.transform.position.x, transform.position.y, transform.position.z);
                    break;
                }
            }
        }
    }
}
