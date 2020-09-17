using System.Collections.Generic;
using UnityEngine;

namespace HumanAPI
{
	public class BowlingAlley : Node, IReset
	{
		private enum BowlingState
		{
			BowlingState_InitialSetup,
			BowlingState_Ready,
			BowlingState_BallInPins,
			BowlingState_TidyingPins,
			BowlingState_Complete
		}

		public NodeInput ballInPinsArea;

		public NodeOutput bowlingComplete;

		public NodeOutput spareMode;

		public NodeOutput[] pinsDownOutputs;

		public BowlingPin[] bowlingPins;

		private BowlingState currentState;

		private bool inSpareMode;

		private float initialSetupTimer;

		private const float initialSetupDuration = 3f;

		private float pinsKnockDownTimer;

		private const float pinsKnockDownDuration = 10f;

		private bool initialSetup;

		private int pinsDown;

		protected override void CollectAllSockets(List<NodeSocket> sockets)
		{
			ballInPinsArea.name = "BallInPins";
			ballInPinsArea.node = this;
			sockets.Add(ballInPinsArea);
			bowlingComplete.name = "BowlingComplete";
			bowlingComplete.node = this;
			sockets.Add(bowlingComplete);
			spareMode.name = "SpareMode";
			spareMode.node = this;
			sockets.Add(spareMode);
			if (pinsDownOutputs == null || pinsDownOutputs.Length == 0)
			{
				UnityEngine.Debug.LogError("Combine node has no inputs!");
				return;
			}
			for (int i = 0; i < pinsDownOutputs.Length; i++)
			{
				pinsDownOutputs[i].node = this;
				pinsDownOutputs[i].name = "Pin down " + i.ToString();
				sockets.Add(pinsDownOutputs[i]);
			}
		}

		private void Start()
		{
			if (bowlingPins.Length != 10)
			{
				base.enabled = false;
			}
			if (pinsDownOutputs.Length != 10)
			{
				base.enabled = false;
			}
		}

		private void Update()
		{
			for (int i = 0; i < 10; i++)
			{
				if (!bowlingPins[i].IsInPlace())
				{
					pinsDownOutputs[i].SetValue(1f);
				}
				else
				{
					pinsDownOutputs[i].SetValue(0f);
				}
			}
			switch (currentState)
			{
				case BowlingState.BowlingState_Complete:
					break;
				case BowlingState.BowlingState_InitialSetup:
					initialSetupTimer += Time.deltaTime;
					if (initialSetupTimer >= 3f)
					{
						for (int n = 0; n < 10; n++)
						{
							bowlingPins[n].Show();
						}
						inSpareMode = false;
						spareMode.SetValue(0f);
						currentState = BowlingState.BowlingState_Ready;
					}
					break;
				case BowlingState.BowlingState_Ready:
					if (ballInPinsArea.value > 0.5f)
					{
						currentState = BowlingState.BowlingState_BallInPins;
						pinsKnockDownTimer = 0f;
					}
					break;
				case BowlingState.BowlingState_BallInPins:
					{
						pinsKnockDownTimer += Time.deltaTime;
						pinsDown = 0;
						for (int l = 0; l < 10; l++)
						{
							if (!bowlingPins[l].IsInPlace())
							{
								pinsDown++;
							}
						}
						if (pinsDown == 10)
						{
							for (int m = 0; m < 10; m++)
							{
								bowlingPins[m].Hide();
							}
							bowlingComplete.SetValue(1f);
							currentState = BowlingState.BowlingState_Complete;
						}
						else if (pinsKnockDownTimer >= 10f)
						{
							currentState = BowlingState.BowlingState_TidyingPins;
						}
						break;
					}
				case BowlingState.BowlingState_TidyingPins:
					if (inSpareMode)
					{
						for (int j = 0; j < 10; j++)
						{
							bowlingPins[j].Show();
						}
						inSpareMode = false;
						spareMode.SetValue(0f);
					}
					else
					{
						for (int k = 0; k < 10; k++)
						{
							if (!bowlingPins[k].IsInPlace())
							{
								bowlingPins[k].Hide();
							}
						}
						if (pinsDown != 0)
						{
							inSpareMode = true;
							spareMode.SetValue(1f);
						}
					}
					currentState = BowlingState.BowlingState_Ready;
					break;
			}
		}

		public void ResetState(int checkpoint, int subObjectives)
		{
			bowlingComplete.SetValue(0f);
			spareMode.SetValue(0f);
			initialSetupTimer = 0f;
			currentState = BowlingState.BowlingState_InitialSetup;
		}
	}
}
public class BowlingPin : MonoBehaviour
{
	public Transform spawnPosition;

	public Collider uprightCollider;

	public Collider uprightSensor;

	private Rigidbody rigidBody;

	private bool respawning;

	private float respawningTimer;

	private const float respawnDuration = 0.5f;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody>();
	}

	public bool IsInPlace()
	{
		return uprightCollider.bounds.Intersects(uprightSensor.bounds);
	}

	public void ResetPosition()
	{
		rigidBody.isKinematic = true;
		base.transform.position = spawnPosition.position;
		base.transform.rotation = Quaternion.identity;
		respawning = true;
		respawningTimer = 0f;
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
		ResetPosition();
	}

	private void Update()
	{
		if (respawning)
		{
			respawningTimer += Time.deltaTime;
			if (respawningTimer >= 0.5f)
			{
				rigidBody.isKinematic = false;
				respawning = false;
			}
		}
	}
}
