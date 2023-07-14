using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.CanvasScaler;

public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;

    private void Update()
    {
        if (!_eventSystem.IsPointerOverGameObject())
        {
            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }

            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));

            if (hits.Length == 0)
            {
                return;
            }

            var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelecatable>())
            .Where(c => c != null)
            .FirstOrDefault();

            _selectedObject.SetValue(selectable);
        }
    }
}