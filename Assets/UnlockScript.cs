using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockScript : MonoBehaviour
{
    public List<Button> skinButtons;
    public List<Sprite> skinSprites;
    Button prevButton;

    IEnumerator UnlockCoroutine()
    {    
        for(int i=0; i< skinButtons.Count; i++)
        {
            if (prevButton==null)
            {
                skinButtons[0].GetComponent<Image>().color = Color.gray;
                skinButtons[0].GetComponent<Button>().interactable = false;
            }
            else
            {
                prevButton.GetComponent<Image>().color = Color.gray;
            }
            
            int randIndex = Random.Range(0, skinButtons.Count);
            skinButtons[randIndex].GetComponent<Image>().color=Color.green;
            prevButton = skinButtons[randIndex];
            yield return new WaitForSeconds(0.3f);

        }
        int randSprite = Random.Range(0, skinSprites.Count);
        prevButton.transform.Find("SkinImage").GetComponent<Image>().sprite = skinSprites[randSprite];
        prevButton.GetComponentInChildren<Button>().interactable = true;
        skinButtons.Remove(prevButton);
        skinSprites.Remove(skinSprites[randSprite]);
    }

    public void Unlock()
    {
        StartCoroutine(UnlockCoroutine());
    }
}