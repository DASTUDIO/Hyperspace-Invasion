using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    Image img; void Awake() { img = GetComponent<Image>(); img.enabled = true; }

    bool isSetTime ; float nextTime ; float timeInterval = 2f;

    void Update()
    {
        Ray anchorLine = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.5f));

        RaycastHit raycastResult;

        img.color = new Color(0f, 255f, 0f, 255f);

        if (Physics.Raycast(anchorLine, out raycastResult))
        {
            GameObject targetGo = raycastResult.collider.gameObject;
            
            if (targetGo.tag == "Enemy") { img.color = new Color(255f, 0f, 0f, 255f); }
        }   
    }

}