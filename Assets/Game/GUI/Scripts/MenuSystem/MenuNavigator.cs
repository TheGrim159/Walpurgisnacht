﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigator : MonoBehaviour
{
    [SerializeField][Tooltip("Set this to -1 for shared navigation")]
    private int playerNumber = -1;

    [SerializeField]
    private MenuNode start = null;

    private MenuNode _current;
    protected MenuNode Current
    {
        get { return _current; }
        set
        {
            if (_current != value)
            {
                _current?.DeselectNode();
                value.SelectNode();
            }
            _current = value;
        }
    }

    void Start()
    {
        Current = start;
    }

    void Update()
    {
        if (Current.Up && GetInputDown(ActionType.UP))
        {
            Current = Current.Up;
            AudioManager.instance.Play("MenuButtonClick1");
        }
        if (Current.Down && GetInputDown(ActionType.DOWN))
        {
            Current = Current.Down;
            AudioManager.instance.Play("MenuButtonClick1");
        }
        if (Current.Left && GetInputDown(ActionType.LEFT))
        {
            Current = Current.Left;
            AudioManager.instance.Play("MenuButtonClick1");
        }
        if (Current.Right && GetInputDown(ActionType.RIGHT))
        {
            Current = Current.Right;
            AudioManager.instance.Play("MenuButtonClick1");
        }
        if (GetInputDown(ActionType.CONFIRM))
        {
            AudioManager.instance.Play("MenuButtonClick2");
            Current.ActivateNode();
            if (Current.Forward)
                Current = Current.Forward;
        }
        if (GetInputDown(ActionType.BACK))
        {
            AudioManager.instance.Play("MenuButtonConfirm");
            Current.DeactivateNode();
            if (Current.Backward)
                Current = Current.Backward;
        }
    }

    private bool GetInputDown(ActionType action)
    {
        if (playerNumber == -1)
        {
            return InputMap.Instance.GetInputDown(0, action) || InputMap.Instance.GetInputDown(1, action);
        }
        else
            return InputMap.Instance.GetInputDown(playerNumber, action);
    }
}
