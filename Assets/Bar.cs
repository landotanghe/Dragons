using UnityEngine;

public class Bar : MonoBehaviour {
    public GameObject[] cells;
    public int fillRate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for(int i=0; i < cells.Length; i++)
        {
            cells[i].SetActive(i < fillRate);
        }
    }
}
