using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public GameObject Quizpanel;
    public GameObject Scoree1;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI questionText2;
    public TextMeshProUGUI questionText3;
    public TextMeshProUGUI scoreText;
    public Slider slider;
    int totalQuestions = 0;
    public int score;
    int progress1 = 0;
    public int currentQuestion;

    private void Start()
    {
        totalQuestions = QnA.Count;
        Scoree1.SetActive(false);
       generateQuestion();
      // Next();
    }

    public void GameOver()
    {
         Quizpanel.SetActive(false);
         Scoree1.SetActive(true);
         scoreText.text = score + "/" + totalQuestions;
    }

    

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    // public void Next()
    // {
    //     if(QnA.Count > 0)
    //     {
            
    //       //currentQuestion = Random.Range(0, QnA.Count);
    //       currentQuestion = currentQuestion + 1;
    //       questionText.text = QnA[currentQuestion].question;
    //       questionText2.text = QnA[currentQuestion].question2;
    //       questionText3.text = QnA[currentQuestion].question3;
    //     SetAnswer();
    //     progressupdate();
         
    //     }
    //     else
    //     {
    //         wrong();
    //         Debug.Log("No more questions");
    //         GameOver();
            
    //     }

    // }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(Waitfornext());
       // generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(Waitfornext());
       // generateQuestion();
    }

    IEnumerator Waitfornext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].answers[i];       
           

            if(QnA[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
            
            // {
            //     options[i].GetComponent<Image>().color = Color.green;
            // }
            // else
            // {
            //     options[i].GetComponent<Image>().color = Color.red;
            // }
        }
    }
    void progressupdate()
    {
        progress1 = progress1 + 1;
        slider.value = progress1;
    }


    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            
          //currentQuestion = Random.Range(0, QnA.Count);
          currentQuestion = 0;
          questionText.text = QnA[currentQuestion].question;
          questionText2.text = QnA[currentQuestion].question2;
          questionText3.text = QnA[currentQuestion].question3;
        SetAnswer();
        progressupdate();
         
        }
        else
        {
            Debug.Log("No more questions");
            GameOver();
        }
       // QnA.RemoveAt(currentQuestion);
    }

}
