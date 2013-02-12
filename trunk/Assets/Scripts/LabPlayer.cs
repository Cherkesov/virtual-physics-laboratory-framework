using UnityEngine;

public class LabPlayer : MonoBehaviour
{
    protected bool _isPlay = false;

    private WebConnector _webConnector;
    protected LabworkConfig _currentConfig;

    protected MapleBuilder _mapleBuilder;
    protected MapleParser _mapleParser;

    // Use this for initialization
    void Start()
    {
        _webConnector = (WebConnector)FindObjectOfType(typeof(WebConnector));
        ((LabworkConfigurationManager)FindObjectOfType(typeof(LabworkConfigurationManager))).SetDefaultConfig();
        _currentConfig =
            ((LabworkConfigurationManager)FindObjectOfType(typeof(LabworkConfigurationManager))).GetConfig();

        _mapleBuilder = new MapleBuilder(PhysicsObjectsManager.GetPhysicsObjects(), FormulasManager.GetFormulas());
        _mapleParser = new MapleParser(PhysicsObjectsManager.GetPhysicsObjects());
    }

    void Update()
    {
        if (_isPlay) _mapleParser.Apply();
    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height - 60, 400, 100));
        GUI.Box(new Rect(0, 0, 400, 55), "������������� ������������ ������");

        if (GUI.Button(new Rect(0, 25, 100, 24), "���������")) CalculateLab();
        if (_response.Length > 0)
        {
            if (GUI.Button(new Rect(100, 25, 100, 24), "���������")) PlayLab();
        }
        else GUI.Box(new Rect(100, 25, 100, 24), "���������");
        if (GUI.Button(new Rect(200, 25, 100, 24), "�����")) PauseLab();
        if (GUI.Button(new Rect(300, 25, 100, 24), "�����")) ResetLab();

        GUI.EndGroup();
    }

    void OnApplicationQuit()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.WindowsPlayer)
        {
            MapleCalculator.StopMaple();
        }
    }

    public void CalculateLab()
    {
        ((OutputConsole)FindObjectOfType(typeof(OutputConsole))).AddMessage("Calculate Lab");

        if (Application.platform == RuntimePlatform.WindowsWebPlayer)
        {
            ((OutputConsole)FindObjectOfType(typeof(OutputConsole))).AddMessage("WindowsWebPlayer");
            _webConnector.ExternallCall(_mapleBuilder.GetLabworkCode(_currentConfig));
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor || 
            Application.platform == RuntimePlatform.WindowsPlayer)
        {
            ((OutputConsole)FindObjectOfType(typeof(OutputConsole))).AddMessage("WindowsEditor || WindowsPlayer");
            MapleCalculator.Calculate(_mapleBuilder.GetLabworkCode(
                _currentConfig), 
                this,
                (OutputConsole)FindObjectOfType(typeof(OutputConsole)));
        }
    }

    protected void PlayLab()
    {
        _mapleParser.Apply();
        _isPlay = true;
    }

    protected void PauseLab()
    {
        _isPlay = false;
    }

    protected void ResetLab()
    {
        _isPlay = false;
        _mapleParser.Apply(0);
    }

    protected string _response = "";
    public void SetResponse(string resp)
    {
        _response = resp;
        _mapleParser.Process(_response);
    }
}
