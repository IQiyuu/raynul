using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float canalisation = 0;
    private int selectedHand = 0;
    private bool charging = false;
    [SerializeField] HandManager[]   hands; // 0 = Right 1 = Left

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!charging) {
            canalisation = 0;
            if (Input.GetMouseButtonDown(0)) {
                if (!hands[0].getLaunched()) {
                    selectedHand = 0;
                    charging = true;
                }
                else if (!hands[1].getLaunched()) {
                    selectedHand = 1;
                    charging = true;
                }
                else
                    print("aucune main dispo");
            }
        } else {
            //print("charging" + canalisation);
            canalisation++;
            if (canalisation % 10 == 0)
                charge();
            if (Input.GetMouseButtonUp(0) || canalisation >= 200 ) {
                charging = false;
                if (!hands[0].getLaunched())
                    attack();
                else if (!hands[1].getLaunched())
                    attack();
                else
                    print("aucune main dispo");
            }
        }
    }

    void charge() {
        charging = true;
        hands[selectedHand].GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f - (canalisation / 100), 1f - (canalisation / 100), 1.0f));
    }

    void attack() {
        StartCoroutine(hands[selectedHand].launch(canalisation));
        hands[selectedHand].GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f, 1.0f));
    }
}
