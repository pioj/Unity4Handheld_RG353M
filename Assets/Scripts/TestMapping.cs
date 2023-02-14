using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class TestMapping : MonoBehaviour
{
	[Header("nombreboton")]
	public TMP_Text label;
	public TMP_Text detected;
	private string[] _joynames;
	private float _joyAmount;
	
	[Header("Analogs")]
	public Animator leftAnalog;
	public Animator rightAnalog;
	private const string CONTROL_LEFTANALOG = "leftAnalog";
	private const string CONTROL_RIGHTANALOG = "rightAnalog";
	public int limit_analog;

	[Header("DPAD")] 
	public Animator dPad;
	private const string CONTROL_DPAD = "dPad";
	public int limit_dpad;

	[Header("Buttons")] 
	public Animator buttonA;
	public Animator buttonB;
	public Animator buttonX;
	public Animator buttonY;
	public Animator buttonL1;
	public Animator buttonL2;
	public Animator buttonR1;
	public Animator buttonR2;
	public Animator select;
	public Animator start;
	private const string CONTROL_BUTTONA = "buttonA";
	private const string CONTROL_BUTTONB = "buttonB";
	private const string CONTROL_BUTTONX = "buttonX";
	private const string CONTROL_BUTTONY = "buttonY";
	private const string CONTROL_BUTTONL1 = "buttonL1";
	private const string CONTROL_BUTTONL2 = "buttonL2";
	private const string CONTROL_BUTTONR1 = "buttonR1";
	private const string CONTROL_BUTTONR2 = "buttonR2";
	private const string CONTROL_SELECT = "select";
	private const string CONTROL_START = "start";
	
	
	void Start()
	{
		_joynames = Input.GetJoystickNames();
	}
	
	void Update()
	{
		Test_Analogs();
		Test_Dpad();
		Test_Buttons();
		
		//probemos a buscar un boton...
		Test_Any();
	}
	
	public void Test_Any()
	{
		//
		CycleJoyNames();
	}
	
	public void CycleJoyNames()
	{
		if (_joynames !=null && _joynames.Length > 0)
		{
			_joyAmount += Time.deltaTime;
			var indexjoy = Mathf.RoundToInt(_joyAmount);
			indexjoy = indexjoy % _joynames.Length;
			detected.text = _joynames[indexjoy].ToString();
		}
	}

	public void Test_Buttons()
	{
		buttonA.SetFloat(CONTROL_BUTTONA, Input.GetButton("ButtonA") ? 1 : 0);
		buttonB.SetFloat(CONTROL_BUTTONB, Input.GetButton("ButtonB") ? 1 : 0);
		buttonX.SetFloat(CONTROL_BUTTONX, Input.GetButton("ButtonX") ? 1 : 0);
		buttonY.SetFloat(CONTROL_BUTTONY, Input.GetButton("ButtonY") ? 1 : 0);
		buttonL1.SetFloat(CONTROL_BUTTONL1, Input.GetButton("ButtonL1") ? 1 : 0);
		buttonL2.SetFloat(CONTROL_BUTTONL2, Input.GetButton("ButtonL2") ? 1 : 0);
		buttonR1.SetFloat(CONTROL_BUTTONR1, Input.GetButton("ButtonR1") ? 1 : 0);
		buttonR2.SetFloat(CONTROL_BUTTONR2, Input.GetButton("ButtonR2") ? 1 : 0);
		select.SetFloat(CONTROL_SELECT, Input.GetButton("Select") ? 1 : 0);
		start.SetFloat(CONTROL_START, Input.GetButton("Start") ? 1 : 0);
		//
	}

	public void Test_Dpad()
	{
		var value = 0;
		if (Input.GetAxisRaw("DpadY") > 0f)
		{
			value = 1;
		}
		else if (Input.GetAxisRaw("DpadY") < 0f)
		{
			value = 2;
		}
		else if (Input.GetAxisRaw("DpadX") < 0f)
		{
			value = 3;
		}
		else if (Input.GetAxisRaw("DpadX") > 0f)
		{
			value = 4;
		}
		//
		value = value % limit_dpad;
		dPad.SetFloat(CONTROL_DPAD, value);
	}

	public void Test_Analogs()
	{
		var valuel = 0;	//idle
		var valuer = 0;
		///
		if (Input.GetAxisRaw("LeftAnalogY") > 0f)
		{
			valuel = 1;
		}
		else if (Input.GetAxisRaw("LeftAnalogY") < 0f)
		{
			valuel = 2;
		}
		else if (Input.GetAxisRaw("LeftAnalogX") < 0f)
		{
			valuel = 3;
		}
		else if (Input.GetAxisRaw("LeftAnalogX") > 0f)
		{
			valuel = 4;
		}
		else if (Input.GetButton("LeftAnalogButton"))
		{
			valuel = 5;
		}
		//
		if (Input.GetAxisRaw("RightAnalogY") > 0f)
		{
			valuer = 1;
		}
		else if (Input.GetAxisRaw("RightAnalogY") < 0f)
		{
			valuer = 2;
		}
		else if (Input.GetAxisRaw("RightAnalogX") < 0f)
		{
			valuer = 3;
		}
		else if (Input.GetAxisRaw("RightAnalogX") > 0f)
		{
			valuer = 4;
		}
		else if (Input.GetButton("RightAnalogButton"))
		{
			valuer = 5;
		}
		
		//apply
		valuel = valuel % limit_analog;
		valuer = valuer % limit_analog;
		leftAnalog.SetFloat(CONTROL_LEFTANALOG,valuel);
		rightAnalog.SetFloat(CONTROL_RIGHTANALOG, valuer);
	}
	
}
