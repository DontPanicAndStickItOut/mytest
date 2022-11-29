using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class GridUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    #region 物品属性显示
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
    #region 物品拖动
    public static Action<Transform> BeginDrag;
    public static Action<Transform,Transform> EndDrag;
    /// <summary>
    /// 开始拖动
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
    /// 正在拖动
    /// </summary>

    public void OnDrag(PointerEventData eventData)
    {
       
    }
    /// <summary>
    /// 结束拖动
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
