using UnityEngine;
using System.Collections;

public enum ErrorType{
	NoMoney,
	NoEnergy,
	NoRequirenments
};

// TODO этот же класс добавляет prefab что дается для отображения
public class TaskContainer : MonoBehaviour {

	[SerializeField]
	GameObject EffectPrefab;
	
	[SerializeField]
	UILabel taskNameLabel;

	[SerializeField]
	GameObject energyEffect;
	[SerializeField]
	GameObject moneyEffect;

	[SerializeField]
	Color aboveZeroColor;
	[SerializeField]
	Color belowZeroColor;

	[SerializeField]
	GameObject[] requirenmentObjects;

	[SerializeField]
	AudioSource clickSound;

	[SerializeField]
	AudioSource errorSound;

	[SerializeField]
	public UIWidget tintableWidget;

	// TODO use and give stuff from here


	public Task task;

	UISlider slider;


    [SerializeField]
    UILabel addExpLabel;

	// Use this for initialization
	void Start () {
		slider = GetComponent<UISlider> ();

        addExpLabel.gameObject.SetActive(Game.Instance.isDebug());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		updateRequirenments (true);
	}

	public void updateData()
	{
		taskNameLabel.text = task.name;

		updateEffect (energyEffect, task.getEffectByType (TaskEffectType.EnergyChange));
		updateEffect (moneyEffect, task.getEffectByType (TaskEffectType.MoneyChange));

		updateRequirenments ();


        if (Game.Instance.isDebug())
        {
            TaskEffect expTask = task.getEffectByType(TaskEffectType.BuildingExpChange);
            if(expTask != null){
                addExpLabel.text = "+" + expTask.amount.ToString();
            }
        }
	}

     public void updateEffect(GameObject effect, TaskEffect taskEffect)
     {
		if(taskEffect == null){
			effect.SetActive(false);
			return;
		}
		UILabel label = effect.GetComponentInChildren<UILabel> ();

		label.text = taskEffect.getAmountString ();
		if (taskEffect.amount < 0) {
			label.color = belowZeroColor;
		} else {
			label.color = aboveZeroColor;
		}
	}

	void updateRequirenments(bool onlyColor = false)
	{
		foreach (GameObject reqObject in requirenmentObjects) {
			reqObject.SetActive(false);
		}

		for(int i = 0; i < task.requirements.Count; ++i)
		{
			Requirement req = task.requirements[i];
			GameObject reqObject = requirenmentObjects[i];
			reqObject.SetActive(true);

			UILabel lable = reqObject.GetComponentInChildren<UILabel>();
			if(req.isEnough()){
				lable.color = new Color(255, 255, 255);
				
			}else{
				lable.color = belowZeroColor;
			}

			if(onlyColor){
				continue;
			}
			lable.text = string.Format("{0}", req.level);




			UISprite sprite = reqObject.GetComponentInChildren<UISprite>();
			sprite.spriteName = Requirement.getIconPath(req.type);
			// TODO snap sprite.
		}
	}


	private bool enoughEnergy()
	{
		TaskEffect effect = task.getEffectByType (TaskEffectType.EnergyChange);

		if(effect != null){
			if(effect.amount < 0){
				return Game.Instance.getPlayer().energy >= (-1 * effect.amount);
			}
		}

		return true;
	}

	private bool enoughMoney()
	{
		TaskEffect effect = task.getEffectByType (TaskEffectType.MoneyChange);
		
		if(effect != null){
			if(effect.amount < 0){
				return Game.Instance.getPlayer().money >= (-1 * effect.amount);
			}
		}
		return true;
	}

	private bool enoughRequirenments()
	{
		foreach (Requirement req in task.requirements) {
			if(!req.isEnough()){

				return false;
			}
		}

		return true;
	}

	public void increaseValue()
	{
		if (!enoughEnergy ()) {
			handleError(this.gameObject, ErrorType.NoEnergy);
			return;
		}
		if (!enoughMoney ()) {
			handleError(this.gameObject, ErrorType.NoMoney);
			return;
		}

		if (!enoughRequirenments ()) {
			handleError(this.gameObject, ErrorType.NoRequirenments);
			return;
		}

		playSound (clickSound);

		Game.Instance.getPlayer ().age.addWeek ();


		bool fullyCompleted = false;
        slider.value = slider.value + (1f / getClicksPerTask());
		if(slider.value >= 1){
			slider.value -= 1;

			fullyCompleted = true;
		}
		applyTaskEffects (task, fullyCompleted);
	}

	private void handleError(GameObject go, ErrorType type)
	{
		playSound (errorSound, false);
	}

	private void playSound(AudioSource asource, bool pitch = true)
	{
		//AudioSource audio = this.GetComponent<AudioSource> ();

		if (pitch) {
			asource.pitch = Random.Range (0.9f, 1.1f);
		}
		asource.Play();
	}

	public void applyTaskEffects(Task task, bool full)
	{
		foreach (TaskEffect effect in task.complitionEffects) {
			applyEffect(effect, full);
		}
	}

	public void applyEffect(TaskEffect effect, bool full)
	{
		/*if (full && (effect.type == TaskEffectType.BuildingExpChange)) {
			task.building.getCurrentBuildingLevel().addExp(effect.amount);
			// TODO и обновляем его бар?
			return;
		}*/

		switch (effect.type) {
		case TaskEffectType.MoneyChange:
			Game.Instance.getPlayer ().money += effect.amount;
			break;

		case TaskEffectType.EnergyChange:
			Game.Instance.getPlayer ().changeEnergy (effect.amount);
			break;
            
        case TaskEffectType.BuildingExpChange:
            task.building.getCurrentBuildingLevel().addExp(effect.amount);
            break;
		}
	}

    public int getClicksPerTask()
    {
        return 4; // because of the number of weeks
    }
}
