using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResponsiveUIList : MonoBehaviour
{
    [Serializable]
    public struct BlogPosts
    {
        public string title;
        public string blog;
        public Sprite icon;
    }

    [SerializeField] BlogPosts[] allBlogPosts;

    // Start is called before the first frame update
    void Start()
    {
        generateBlogPosts();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void generateBlogPosts()
    {
        GameObject blogTemplate = transform.GetChild (0).gameObject;
        GameObject g;

        int n = allBlogPosts.Length;

        for (int i = 0; i < n; i++)
        {
            g = Instantiate(blogTemplate, transform);
            g.transform.GetChild(0).GetComponent<TMP_Text>().text = allBlogPosts[i].title;
            g.transform.GetChild(2).GetComponent<TMP_Text>().text = allBlogPosts[i].blog;
            g.transform.GetChild(1).GetComponent<Image>().sprite = allBlogPosts[i].icon;
        }

        Destroy (blogTemplate);


        //Because of the way layout groups apply, I need to reset the group here. Coroutine re-enables after one frame. 
        StartCoroutine(ResetLayout());

    }

    IEnumerator ResetLayout()  
    {
        GetComponent<VerticalLayoutGroup>().enabled = false;
        yield return 0;
        GetComponent<VerticalLayoutGroup>().enabled = true;
    }
}
