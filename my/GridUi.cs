using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class GridUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    #region ��Ʒ������ʾ
    public static Action OnExit;
    public static Action<Transform> OnEnter;



    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag=="Grid")
        {

            if (OnEnter != null)
            {            
                    OnEnter(transform);                                              
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == "Grid")
        {
            if (OnExit != null)
            {
                OnExit();
            }
        }
    }
    #endregion
    #region ��Ʒ�϶�
    public static Action<Transform> BeginDrag;
    public static Action<Transform,Transform> EndDrag;
    /// <summary>
    /// ��ʼ�϶�
    /// </summary>

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button==PointerEventData.InputButton.Left)
        {
            if (BeginDrag != null)
            {
                BeginDrag(transform);
            }
        }                 
    }

    /// <summary>
    /// �����϶�
    /// </summary>

    public void OnDrag(PointerEventData eventData)
    {
       
    }
    /// <summary>
    /// �����϶�
    /// </summary>

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (EndDrag != null)
            {
                if (eventData.pointerEnter==null)
                {
                    EndDrag(transform, null);
                }
                else
                    EndDrag(transform,eventData.pointerEnter.transform);
            }
        }
    }
    #endregion
}
