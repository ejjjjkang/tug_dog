using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;  //�ø��� ��Ʈ ���̺귯��
using System.Threading;
using System;

public class colider_dog_arduino : MonoBehaviour
{
	SerialPort sp = new SerialPort();
	public Animator animator;


	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		sp.PortName = "COM4";     // �Ƶ��̳� ��Ʈ
		sp.BaudRate = 9600;      // �Ƶ��̳� ���巹��Ʈ
		sp.DataBits = 8;
		sp.Parity = Parity.None;
		sp.StopBits = StopBits.One;
		sp.Open();
	}


	// Update is called once per frame

	private void OnCollisionEnter(Collision collision) //�ݶ��̴� �浹��
	{
		if (collision.gameObject.name == "stick") // ��ƽ�̶��� �����ϰ�
		{
			GetComponent<Animator>().Play("BeagleAggressiveAttack2");  // �ִϸ��̼� ��� ������ �ͱ׳���
			sp.WriteLine("a");  // �ø�����Ʈ�� ���ڿ� a ������
		}
	}
	private void OnCollisionExit(Collision collision) // �ݶ��̴� �浹 �����
	{
		if (collision.gameObject.name == "stick")
		{
			GetComponent<Animator>().Play("BeagleIdle", -1, 0);
			sp.WriteLine("b");
		}
	}
	private void OnApplicationQuit()

	{
		sp.Close();    //����Ƽ ������ �ø��� ���� ����
	}
}
