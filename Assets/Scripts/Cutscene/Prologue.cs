using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    public Image scene1, scene2, scene3, scene4, scene5;
    public List<Image> scenelist;
    private bool fadeOut, fadeIn;
    private int page;
    
    // Start is called before the first frame update
    void Start()
    {
        scenelist = new List<Image>();
        scenelist.Add(this.scene1);
        scenelist.Add(this.scene2);
        scenelist.Add(this.scene3);
        scenelist.Add(this.scene4);
        scenelist.Add(this.scene5);

        page = 0;
        FadeInFuc(scenelist[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            scenelist[page].gameObject.SetActive(false);
            // FadeOutFuc(scenelist[page]);
            page+=1;
            if(page == 4){
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            }
        }
    }

    public void FadeInFuc(Image image){
        Color newColor = image.color;
        newColor.a += Time.deltaTime;
        image.color = newColor;
        if (image.color.a >=1){
            fadeOut = false;
        }
    }

    public void FadeOutFuc(Image image){
        Color newColor = image.color;
        newColor.a -= Time.deltaTime;
        image.color = newColor;
        if (image.color.a <=1){
            fadeOut = false;
        }
    }
}
