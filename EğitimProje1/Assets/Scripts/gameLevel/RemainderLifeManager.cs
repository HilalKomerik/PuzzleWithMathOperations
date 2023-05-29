using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainderLifeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject remainderHeart1, remainderHeart2, remainderHeart3;

    public void CheckRemainderLife(int remainderHeart)
    {
        switch (remainderHeart)
        {
            case 3:
                remainderHeart1.SetActive(true);
                remainderHeart2.SetActive(true);
                remainderHeart3.SetActive(true);
                break;

            case 2:
                remainderHeart1.SetActive(true);
                remainderHeart2.SetActive(true);
                remainderHeart3.SetActive(false);
                break;

            case 1:
                remainderHeart1.SetActive(true);
                remainderHeart2.SetActive(false);
                remainderHeart3.SetActive(false);
                break;

            case 0:
                remainderHeart1.SetActive(false);
                remainderHeart2.SetActive(false);
                remainderHeart3.SetActive(false);
                break;
        }

    }
}
