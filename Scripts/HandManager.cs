using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    private     bool launched = false;
    [SerializeField] Vector3 dif;
    private Transform player;

    // Start is called before the first frame update
    void Start() {
        transform.localPosition = dif;
        player = transform.parent;
    }

    // Update is called once per frame
    void Update() {
    }

    public IEnumerator launch(float i) {
        float refresh = 0.01f;
        Vector3 finalPos;
        Vector3 initPos;

        finalPos = new Vector3(0, (i/50) * Mathf.Cos(player.Find("PlayerCamera").localRotation.y), 1 + (i/50));
        initPos = transform.localPosition;
        while (transform.localPosition != finalPos + initPos)
        {
            print(transform.localPosition);
            print(finalPos);
            print("");
            transform.localPosition = transform.localPosition + (finalPos / 5);
            yield return new WaitForSeconds(refresh);
        }
        launched = true;
        transform.parent = null;
        StartCoroutine("reGrab");
    }

    public void reAttach() {
        launched = false;
        transform.parent = player;
        transform.localPosition = dif;
        transform.rotation = player.Find("PlayerCamera").transform.rotation;
        print("main recuperee");
    }

    void    changeLaunched() {
        launched = !launched;
    }

    public bool getLaunched() { 
        return launched; 
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player" && launched)
            reAttach();
    }

    IEnumerator reGrab()
    {
        float speed = 10f;
        float refresh = 0.05f;
    
        yield return new WaitForSeconds(0.5f);
        while (launched)
        {
            transform.localRotation = player.Find("PlayerCamera").transform.rotation;
            Vector3 dir = new Vector3(transform.position.x - player.position.x, transform.position.y - player.position.y, transform.position.z - player.position.z);
            transform.position = transform.position - (dir / speed);
            speed /= 1.25f;
            yield return new WaitForSeconds(refresh);
        }
    }
}
