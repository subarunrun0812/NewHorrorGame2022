using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// [RequireComponent(typeof(AudioSource))]
public class ElevatorScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource _audioSource;
    [Header("corpus = 外側,cabin = 内側")]
    [SerializeField] private AudioClip corpus_OpenDoorSE;
    [SerializeField] private AudioClip corpus_CloseDoorSE;
    [SerializeField] private AudioClip handleSE;
    [SerializeField] private Collider col;
    [SerializeField] private Elevator_CabinScript elevator_CabinScript;
    [SerializeField] private MoveHandle moveHandle;
    [SerializeField] private RequiredItemMessage requiredItemMessage;
    [SerializeField] private ChangeLanguage changeLanguage;
    public void ElevatorOpenDoor()
    {
        if (moveHandle.electricity == false)//エレベーターの電力が復旧していないとき
        {
            if (changeLanguage.lannum == 0)
                requiredItemMessage.RequiredMessage("エレベーターの電力が復旧していない");
            else if (changeLanguage.lannum == 1)
                requiredItemMessage.RequiredMessage("Elevator power has not been restored");
        }
        else
        {
            //外側の扉を初めに呼び出す
            Elevator_Handle();
            col.enabled = false;
            animator.SetTrigger("Open");
            animator.ResetTrigger("Close");
            StartCoroutine("CabinOpeDoorCorutine");

        }
    }
    IEnumerator CabinOpeDoorCorutine()
    {
        yield return new WaitForSeconds(3f);
        elevator_CabinScript.CabinOpenDoor();
    }
    public void Elevator_Handle()
    {
        _audioSource.PlayOneShot(handleSE);
    }
    //animationEventから呼び出す
    public void Elevator_Corpus_OpenDoor()
    {
        _audioSource.PlayOneShot(corpus_OpenDoorSE);
    }

    //ドアを閉じるとき
    public void Elevator_CloseDoor()
    {
        animator.ResetTrigger("Open");
        animator.SetTrigger("Close");
    }
    public void Elevator_Corpus_CloseDoor()
    {
        _audioSource.PlayOneShot(corpus_CloseDoorSE);
    }

}
