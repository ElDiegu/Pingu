using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinguScript : MonoBehaviour
{
    public Animator anim;
    //pingu va a ser una máquina de estados
    public int state = 0;
    public GameObject fish;
    public GameObject mic;
    public AudioSource audioSourcePingu;
    [SerializeField] Slider hambre;

    private int idle = 1;
    private int done = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state){
            case 0:
                //Si no ocurre nada, hacer esta animacion idle
                if(idle == 1 && done == 0){
                    done = 1;
                    StartCoroutine(WaitRandomForIdle2(Random.Range(10.0f, 20.0f)));
                }else if (idle == 2 && done == 0){
                    done = 1;
                    StartCoroutine(WaitRandomForIdle3(Random.Range(10.0f, 20.0f)));
                }
                break;
            case 1:
                //animación de alimentar
                fish.SetActive(true);
                anim.Play("PinguEating");
                state = 0;
                //fish.SetActive(false);
                break;
            case 2:
                //animación hablar
                StartCoroutine(WaitToSpeak(audioSourcePingu.clip.length + 0.4f));
                mic.SetActive(true);
                anim.SetBool("Mic", false);
                anim.Play("PinguTalk");
                break;
            case 3:
                //animación idle2
                anim.Play("PinguIdle2");
                state = 0;
                break;
            case 4:
                //animación idle2
                anim.Play("PinguIdle3");
                state = 0;
                break;

        }

    }

    public void alimentarPingu(){
        state = 1;
    }
    public void repetirVoz(){
        state = 2;
    }

    private IEnumerator WaitToSpeak(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        mic.SetActive(false);
        anim.SetBool("Mic", true);
        state = 0;
    }
    
    private IEnumerator WaitRandomForIdle2(float waitTime){
        yield return new WaitForSeconds(waitTime);
        idle = 2;
        state = 3;
        done = 0;
    }
    private IEnumerator WaitRandomForIdle3(float waitTime){
        yield return new WaitForSeconds(waitTime);
        idle = 1;
        state = 4;
        done = 0;
    }
}
