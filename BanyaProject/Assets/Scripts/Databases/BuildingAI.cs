using UnityEngine;
using System.Collections;

public class BuildingAI : MonoBehaviour {

	public int Id;
	
	public string Name;
	public string Description;
	public int IncreaseAWE;
	public int IncreaseACH;
	public int IncreaseFUN;
	public int IncreaseHGR;
	public int IncreaseTRF;
	public int IncreaseTHG;
	public int IncreaseAura;
	
	// Update is called once per frame
	void Update () {
	}

	public void SetStats(string name)
	{
		Id = BuildingBase.Get (name).Id;
		Name = name;
		Description = BuildingBase.Get (name).Description;
		IncreaseAWE = BuildingBase.Get (name).IncreaseAWE;
		IncreaseACH = BuildingBase.Get (name).IncreaseACH;
		IncreaseFUN = BuildingBase.Get (name).IncreaseFUN;
		IncreaseHGR = BuildingBase.Get (name).IncreaseHGR;
		IncreaseTRF = BuildingBase.Get (name).IncreaseTRF;
		IncreaseTHG = BuildingBase.Get (name).IncreaseTHG;
		IncreaseAura = BuildingBase.Get (name).IncreaseAura;

	}

	public int GetIncreaseAWE()
	{
		return IncreaseAWE;
	}
	public int GetIncreaseACH()
	{
		return IncreaseACH;
	}
	public int GetIncreaseFUN()
	{
		return IncreaseFUN;
	}
	public int GetIncreaseHGR()
	{
		return IncreaseHGR;
	}
	public int GetIncreaseTRF()
	{
		return IncreaseTRF;
	}
	public int GetIncreaseTHG()
	{
		return IncreaseTHG;
	}
	public int GetIncreaseAura()
	{
		return IncreaseACH + IncreaseAWE + IncreaseFUN + IncreaseHGR + IncreaseTRF + IncreaseTHG;
	}

}
