using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //�巡�� �ɶ� �̵��� �������� ��� static ����
    public static GameObject beginDraggedIcon;

    //�巡�� �Ǵ� ���� Icon�� ��ġ�� �θ� Transform;
    public Transform onDragParent;

    //���Կ� �巡�� ���� �ʾ��� �� ���ư� ��ġ ���
    private Vector3 startPosition;

    //���ư� �θ� ������Ʈ ���
    private Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //�巡�װ� ���� �� �� ��� ������Ʈ�� beginDraggedIcon ������ �Ҵ�
        beginDraggedIcon = gameObject;

        //����� �������� ��� �صд�.
        startPosition = transform.position;
        startParent = transform.parent;

        //Drop �̺�Ʈ�� ���������� �����ϱ� ���� Icon RectTransform�� ����
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        //�θ� ������Ʈ ����
        transform.SetParent(onDragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //�巡�� �߿� Icon�� ������Ʈ�� ����ٴϵ��� ����
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�巡�� ����� ����� �ش� Icon�� �̺�Ʈ ������ ����Ѵ�.
        beginDraggedIcon = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if(transform.parent == onDragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }
}
