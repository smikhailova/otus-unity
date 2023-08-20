using UnityEngine;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour
{
    private const float PLAYER_Y_POS = .8f;
    private const float LINE_Y_POS = .51f;

    private Stack<Cell> _way;

    private float _progress = -.1f;

    private Vector3 _positionTo;
    private Vector3 _positionFrom;

    [SerializeField] private LineRendererController _line;


    void Start()
	{
        _way = new Stack<Cell>();
    }

	void Update()
	{
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.Z))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                SetWay(hit.collider.gameObject);
            }
        }

        if (_way.Count > 0 && (_progress >= 1f || _progress < 0f))
        {
            if (_way.Count > 0 && _progress == -.1f)
            {
                _line.AddPoint(new Vector3(transform.position.x, LINE_Y_POS, transform.position.z));
            }

            Cell nextStep = _way.Pop();

            _progress = 0f;
            _positionFrom = transform.position;
            _positionTo = new Vector3(nextStep.Position.x, PLAYER_Y_POS, nextStep.Position.z);

            _line.AddPoint(new Vector3(nextStep.Position.x, LINE_Y_POS, nextStep.Position.z));
        }

        if (_progress >= 0)
        {
            transform.position = Vector3.Lerp(_positionFrom, _positionTo, _progress > 1f ? 1f : _progress);
            _progress += .1f;
        }

        if (_progress > 1 && _way.Count == 0)
        {
            _progress = -.1f;
        }
    }

    private void SetWay(GameObject goal)
    {
        _way.Clear();
        _way = PathFinder.SearchAStar(
            new Cell(new Vector3Int(
                (int)Math.Round(transform.position.x),
                0,
                (int)Math.Round(transform.position.z)
            )),
            new Cell(new Vector3Int(
                (int)Math.Round(goal.transform.position.x),
                0,
                (int)Math.Round(goal.transform.position.z)
            )));
    }
}

