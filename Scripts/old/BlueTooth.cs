using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class BlueTooth : MonoBehaviour {

	public static bool BTStatus = false;

	// ----------------------------------------------------------------- 
	// change these to match the bluetooth device you're connecting to:
	// ----------------------------------------------------------------- 

	private static string fullUID = "6e40****-b5a3-f393-e0a9-e50e24dcca9e";     // BLE-CC41a module pattern 
	private static string serviceUUID = "0001";
	private static string rCharacteristicUUID = "0003";//RX
	private static string wCharacteristicUUID = "0002";//TX
	private static string deviceToConnectTo = "FE:F8:9E:29:F9:C1";//藍芽位置 2號

	private bool readFound = false;
	private bool writeFound = false;
	private static bool readStart = false;
	public static string connectedID = null;

	private Dictionary<string, string> _peripheralList;

	public static string BTLog;
	private static bool iniStatus = false;

	void Awake()        //防止重複啟動
	{
		if (BTStatus)
			gameObject.SetActive(false);
	}

	void Start()
	{
		
		BTinitialize();
		Invoke("BTscan", 1f);	//掃描+連接
	}

	void Update()
	{

	}

	void BTinitialize()
	{
		if (iniStatus)
			return;
		BTLog = "Initialising bluetooth\n";
		BluetoothLEHardwareInterface.Initialize(true, false, () => {iniStatus = true; }, (error) => {iniStatus = false; });
	}

	void BTscan()
	{
		//FullUUID("0001");
		// the first callback will only get called the first time this device is seen 
		// this is because it gets added to a list in the BluetoothDeviceScript 
		// after that only the second callback will get called and only if there is 
		// advertising data available 
		BTLog = ("Starting scan \r\n");
		BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(null, 
			(address, name) => {addPeripheral(name, address);},
			(address, name, rssi, advertisingInfo) => {; });
	}

	void addPeripheral(string name, string address)
	{
		BTLog += ("Found " + address + " \r\n");
		if (_peripheralList == null)
		{
			_peripheralList = new Dictionary<string, string>();
		}
		if (!_peripheralList.ContainsKey(address))
		{
			_peripheralList[address] = name;
			if (address.Trim().ToLower() == deviceToConnectTo.Trim().ToLower())
			{
				BTLog += "Connecting to " + address + "\n";
				BTconnect(address);
			}
			else
			{
				BTLog += "Not what we're looking for \n";
			}
		}
		else
		{
			BTLog += "No address found \n";
		}
	}

	void BTconnect(string addr)
	{
		BluetoothLEHardwareInterface.ConnectToPeripheral(addr, (address) => {; },
		   (address, serviceUUID) => {; },
		   (address, serviceUUID, characteristicUUID) => 
		   {
			   // discovered characteristic 
			   if (IsEqual(serviceUUID, serviceUUID))
			   {
				   connectedID = address;
				   if (IsEqual(characteristicUUID, rCharacteristicUUID))
				   {
					   readFound = true;
					   BTLog += "readTrue \n";
				   }
				   if (IsEqual(characteristicUUID, wCharacteristicUUID))
				   {
					   writeFound = true;
					   BTLog += "writeTrue \n";
				   }
				   
				   if (readFound && writeFound)
				   {
					   BTLog += "Connected! \n";
					   Invoke("readReady", 1f);				   
				   }
				   else
				   {
					   BTStatus = false;
					   readStart = false;
				   }
				   BluetoothLEHardwareInterface.StopScan();
			   }
		   }, 
		   (address) => 
		   {
			   // this will get called when the device disconnects 
			   // be aware that this will also get called when the disconnect 
			   // is called above. both methods get call for the same action 
			   // this is for backwards compatibility
		   });

	}

	public static void BTread()
	{
		if (!readStart)
			return;
		BTLog += "readStart!";
		BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress(
			connectedID, FullUUID(serviceUUID), FullUUID(rCharacteristicUUID),
			(deviceAddress, notification) => {; },
			(deviceAddress2, characteristic, data) =>
			{
				readStart = false;
				if (deviceAddress2.CompareTo(connectedID) == 0)	//讀資料
				{				
					if (data.Length > 0)
					{
						string s = Encoding.UTF8.GetString(data); ///Byte to string
						receiveText(s);
					}
				}
			});
	}

	private static void receiveText(string s)	//讀取資料後的操作
	{
		Control.analysis(s);
	}


	public static void BTreadOff()
	{
		if (!BTStatus)
			return;
		/*BluetoothLEHardwareInterface.UnSubscribeCharacteristic(connectedID, FullUUID(serviceUUID), FullUUID(rCharacteristicUUID),
			(unSubscribe) =>
			{
				readStart = true;				
			});*/
		BluetoothLEHardwareInterface.DisconnectPeripheral(connectedID,
			(disconnect) =>
			{
				BTStatus = false;
				readStart = false;
			});
		
	}

	private void readReady()
	{
		BTStatus = true;
		readStart = true;
	}


	public static string FullUUID(string uuid)
	{
		return fullUID.Replace("****", uuid);
	}

	bool IsEqual(string uuid1, string uuid2)
	{
		if (uuid1.Length == 4)
		{
			uuid1 = FullUUID(uuid1);
		}
		if (uuid2.Length == 4)
		{
			uuid2 = FullUUID(uuid2);
		}
		return (uuid1.ToUpper().CompareTo(uuid2.ToUpper()) == 0);
	}

}
