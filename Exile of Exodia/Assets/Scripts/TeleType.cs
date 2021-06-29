using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleType : MonoBehaviour
{
    public TextMeshPro tmp;

    IEnumerator Start()
    {
        tmp = gameObject.GetComponent<TextMeshPro>() ?? gameObject.AddComponent<TextMeshPro>();


        int totalVisibleCharacters = tmp.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            //int visibleCount = counter % (totalVisibleCharacters + 1);

            tmp.maxVisibleCharacters = counter;

            if (counter >= totalVisibleCharacters)
            {
                //tmp.Page += 1;
                //tmp.maxVisibleCharacter = 0;
                yield return new WaitForSeconds(0.05f);
            }

            counter += 1;

            yield return new WaitForSeconds(0.005f);
        }
    }

}
