using UnityEngine;
using System.Collections;

public class Egg : Food {
    public FoodType type;
    public float breakForce=6;
    public GameObject eggTop;
    public GameObject eggBottom;
    public GameObject yolk;
    // Use this for initialization
    void Start () {
        breakEvent.AddListener(BreakEgg);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().AddForce(-transform.up * 100, ForceMode.Impulse);
        }
    }
    
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.relativeVelocity.magnitude);
        if (col.relativeVelocity.magnitude >= breakForce)
        {
            breakEvent.Invoke();
        }
    }

    void BreakEgg()
    {
        GameObject temp = (GameObject)GameObject.Instantiate(eggBottom, transform.position, Quaternion.identity, gameObject.transform);
        Vector3 tempLocalScale = temp.transform.localScale;
        temp.transform.localPosition = new Vector3(0f, 0f, (temp.transform.localScale.z) - (tempLocalScale.z / 2));
        temp.transform.position = transform.position;
        temp.transform.SetParent(null);

        temp = (GameObject)GameObject.Instantiate(eggTop, transform.position, Quaternion.identity, gameObject.transform);
        tempLocalScale = temp.transform.localScale;
        temp.transform.localPosition = new Vector3(0f, 0f, (temp.transform.localScale.z) - (tempLocalScale.z / 2));
        temp.transform.position = transform.position;
        temp.transform.SetParent(null);

        temp = (GameObject)GameObject.Instantiate(yolk, transform.position, Quaternion.identity, gameObject.transform);
        tempLocalScale = temp.transform.localScale;
        temp.transform.localPosition = new Vector3(0f, 0f, (temp.transform.localScale.z) - (tempLocalScale.z / 2));
        temp.transform.position = transform.position;
        temp.transform.SetParent(null);

        GameManager.Instance.NextTask(2);
        breakEvent.RemoveAllListeners();
        Destroy(gameObject);
    }

}
