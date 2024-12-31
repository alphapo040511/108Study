using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //드래그 될때 이동될 아이콘을 담는 static 변수
    public static GameObject beginDraggedIcon;

    //드래그 되는 동안 Icon을 배치할 부모 Transform;
    public Transform onDragParent;

    //슬롯에 드래그 되지 않았을 때 돌아갈 위치 백업
    private Vector3 startPosition;

    //돌아갈 부모 오브젝트 백업
    private Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //드래그가 시작 될 때 대상 오브젝트를 beginDraggedIcon 변수에 할당
        beginDraggedIcon = gameObject;

        //백업용 포지션을 백업 해둔다.
        startPosition = transform.position;
        startParent = transform.parent;

        //Drop 이벤트를 정상적으로 감지하기 위해 Icon RectTransform을 무시
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        //부모 오브젝트 변경
        transform.SetParent(onDragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //드래그 중에 Icon이 오브젝트를 따라다니도록 설정
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //드래그 대상을 지우고 해당 Icon에 이벤트 감지를 허용한다.
        beginDraggedIcon = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if(transform.parent == onDragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }
}
