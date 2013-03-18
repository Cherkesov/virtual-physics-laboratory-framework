using System;
using UnityEngine;

public class MainGui : MonoBehaviour {

    public float TimelineFloatValue { get; set; }
    private int _timelineIntValue = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        // ������� ����
        Rect mainMenuRect = new Rect(10, 10, Screen.width - 20, 45);
        GUI.BeginGroup(mainMenuRect);
        GUI.Box(new Rect(0, 0, Screen.width - 20, 45), "");

        if (GUI.Button(new Rect(10, 5, 100, 35), "����������\n�������"))
            BeanManager.GetPhysicsObjectsManager().SetOpened(!BeanManager.GetPhysicsObjectsManager().IsOpened());
        if (GUI.Button(new Rect(115, 5, 100, 35), "���.\n������"))
            BeanManager.GetMathematicsModelView().SetOpened(!BeanManager.GetMathematicsModelView().IsOpened());
        if (GUI.Button(new Rect(220, 5, 100, 35), "��������\n������������"))
            BeanManager.GetConfigurationManager().SetOpened(!BeanManager.GetConfigurationManager().IsOpened());

        if (GUI.Button(new Rect(mainMenuRect.width - 215, 5, 100, 35), "�������"))
            BeanManager.GetOutputConsole().Visible = !BeanManager.GetOutputConsole().Visible;
        if (GUI.Button(new Rect(mainMenuRect.width - 110, 5, 100, 35), "��������\n��� ����"))
        {
            BeanManager.GetPhysicsObjectsManager().SetOpened(false);
            BeanManager.GetMathematicsModelView().SetOpened(false);
            BeanManager.GetConfigurationManager().SetOpened(false);

            BeanManager.GetOutputConsole().Visible = false;
        }

        GUI.EndGroup();

        // ������ ������������
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height - 60, 400, 100));

        try
        {
            if (!BeanManager.GetLabPlayer().IsPlay && BeanManager.GetMapleParser().HasFields())
            {
                TimelineFloatValue = GUI.HorizontalSlider(
                    new Rect(25, 25, 100, 30),
                    TimelineFloatValue,
                    BeanManager.GetConfigurationManager().GetConfig().Start,
                    BeanManager.GetConfigurationManager().GetConfig().Finish);
                _timelineIntValue = (int) Math.Round(TimelineFloatValue);
                BeanManager.GetMapleParser().Apply(_timelineIntValue);
            }
            else
                GUI.HorizontalSlider(
                    new Rect(25, 25, 100, 30),
                    TimelineFloatValue,
                    BeanManager.GetConfigurationManager().GetConfig().Start,
                    BeanManager.GetConfigurationManager().GetConfig().Finish);
        } catch (Exception exception)
        {
            BeanManager.GetOutputConsole().AddMessage(exception.Message);
        }

        GUI.Box(new Rect(0, 0, 400, 55), "������������� ������������ ������");

        if (GUI.Button(new Rect(0, 25, 100, 24), "���������"))
        {
            BeanManager.GetOutputConsole().AddMessage("Press button, Try Calculate");
            BeanManager.GetLabPlayer().CalculateLab();
        }
        if (BeanManager.GetLabPlayer().Response.Length > 0)
        {
            if (GUI.Button(new Rect(100, 25, 100, 24), "���������")) BeanManager.GetLabPlayer().PlayLab();
        }
        else GUI.Box(new Rect(100, 25, 100, 24), "���������");
        if (GUI.Button(new Rect(200, 25, 100, 24), "�����")) BeanManager.GetLabPlayer().PauseLab();
        if (GUI.Button(new Rect(300, 25, 100, 24), "�����")) BeanManager.GetLabPlayer().ResetLab();

        GUI.EndGroup();
    }
}
