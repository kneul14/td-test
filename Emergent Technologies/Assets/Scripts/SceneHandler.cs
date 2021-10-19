using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    public GameObject Left_Marker;
    public GameObject Right_Marker;

    public GameObject Turret;

    public GameObject lastSelected = null;
    public List<Color> lastColors = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var Input = FindObjectOfType<Input_Received>();
        if (Input)
        {
            if (Input.left_activate)
            {
                UnHighlight();

                RaycastHit rh = RaycastScene(Left_Marker);
                if (rh.collider)
                {
                    Highlight(rh.collider.gameObject);
                    InstantiateTurret(rh.point, rh.collider.gameObject);

                }
                Input.left_activate = false;
            }

            if (Input.right_activate)
            {
                UnHighlight();

                RaycastHit rh = RaycastScene(Right_Marker);
                if (rh.collider)
                {
                    Highlight(rh.collider.gameObject);
                    InstantiateTurret(rh.point, rh.collider.gameObject);
                }
                Input.right_activate = false;
            }
        }
    }

    private void InstantiateTurret(Vector3 point, GameObject objectHit)
    {
        var ts = objectHit.GetComponentsInChildren<Transform>();
        for (int t = 0; t < ts.Length; t++)
        {
            if (ts[t].transform != objectHit.transform)
            {
                return;
            }
        }

        var turret = Instantiate(Turret, objectHit.transform);

        turret.transform.localPosition = objectHit.transform.parent.localPosition + new Vector3(0, point.y, 0);
        turret.transform.localEulerAngles = new Vector3(0, 90, 0);

    }

    private void UnHighlight()
    {
        if (lastSelected != null && lastSelected.tag == "Tower" && lastColors.Count > 0)
        {
            var rs = lastSelected.GetComponents<Renderer>();
            for (int r = 0; r < rs.Length; r++)
            {
                if (rs[r].material.HasProperty("_Color"))
                {
                    rs[r].material.SetColor("_Color", lastColors[r]);
                }
            }

        }
        lastSelected = null;
    }

    private void Highlight(GameObject objectHit)
    {
        if (objectHit.tag == "Tower")
        {
            lastSelected = objectHit;
            lastColors.Clear();
            var rs = lastSelected.GetComponents<Renderer>();
            for (int r = 0; r < rs.Length; r++)
            {
                if (rs[r].material.HasProperty("_Color"))
                {
                    lastColors.Add(rs[r].material.GetColor("_Color"));
                    rs[r].material.SetColor("_Color", Color.red);
                }
                else
                {
                    lastColors.Add(new Color());
                }
            }
        }
        else
        {
            lastSelected = null;
        }
    }

    private RaycastHit RaycastScene(GameObject marker)
    {
        RaycastHit rh;
        var mp = Camera.main.WorldToScreenPoint(marker.transform.position);

        if (Physics.Raycast(Camera.main.ScreenPointToRay(mp), out rh))
        {
            if (rh.collider != null)
            {
                return rh;
            }
        }
        return rh;
    }

}