using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour {

    public GameObject prefab;
    public int FillRate { get; set; }

    private List<GameObject> cells;

	// Use this for initialization
	void Start () {
        cells = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        while(FillRate > cells.Count)
        {
            var newCell = Instantiate(prefab, transform.position + new Vector3(0, 0.4f * cells.Count, 0), Quaternion.identity);
            cells.Add(newCell);
        }

        for(int i=0; i < cells.Count; i++)
        {
            cells[i].SetActive(i < FillRate);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.25f);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up);
    }
}
