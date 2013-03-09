using System;
using UnityEngine;
using System.Collections;

public class OutputConsole : MonoBehaviour
{
    public bool Visible;
    public bool AutoClear = true;
    public int MaxLength = 500;

    private Rect _windowPosition = new Rect(10, Screen.height / 4 * 3 - 100, Screen.width - 100, Screen.height / 4);
    private Vector2 _scroll;// = new Vector2(100, 0);
    private String _content = "";
    
    public void AddMessage(String message)
    {
        message = message.Replace(" ", ""); 
        message = message.Replace("0,", ""); 
        message = message.Replace("e-", "-"); 

        //message.Trim(new char[] {' ', '_'});
        //if (message.Length > 0)
        //    _content += message.Substring(message.Length - 100, 100);

        if (message.Length > 0)
            _content += message;

        if (AutoClear && _content.Length > MaxLength)
        {
            string temp = _content.Substring(MaxLength, _content.Length) + "Cut.";
            _content = temp;
        }
    }

    void OnGUI()
    {
        if (Visible)
        {
            _windowPosition = GUI.Window(
                4,
                _windowPosition,
                DoWindow,
                "�������");
        }
    }

    void DoWindow(int id)
    {
        _scroll = GUILayout.BeginScrollView(_scroll);
        GUI.TextArea(new Rect(10, 30, _windowPosition.width - 80, _windowPosition.height - 60), _content);
        GUILayout.EndScrollView();

        GUI.DragWindow();
    }

    public static OutputConsole GetInstance()
    {
        return (OutputConsole)FindObjectOfType(typeof(OutputConsole));
    }
}