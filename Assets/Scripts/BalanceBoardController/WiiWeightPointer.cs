using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiiWeightPointer : MonoBehaviour
{
    [SerializeField] RectTransform pointerImageRect;

    // Update is called once per frame
    void Update()
    {
        bool isPointerActive = false;
        for (int i = 0; i < Wii.GetRemoteCount(); ++i)
        {
            if (Wii.IsActive(i) && Wii.GetExpType(i) == 3)
            {
                isPointerActive = true;
                Vector2 theCenter = Wii.GetCenterOfBalance(i);
                pointerImageRect.transform.position = new Vector3((1 + theCenter.x) * Screen.width / 2, (1 + theCenter.y) * Screen.height / 2);
                break;
            }
        }
        pointerImageRect.gameObject.SetActive(isPointerActive);
    }
}
