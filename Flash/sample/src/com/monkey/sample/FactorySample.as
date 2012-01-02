package com.monkey.sample
{
	import com.monkey.process.IConnector;
	import com.monkey.process.IJob;
	import com.monkey.process.IPMFactory;
	import com.monkey.process.IProcess;
	import com.monkey.propertygrid.CustomProperty;
	import com.monkey.propertygrid.IUITypeEditor;
	
	import mx.collections.ArrayCollection;
	
	public class FactorySample implements IPMFactory
	{
		private var _processes:ArrayCollection = new ArrayCollection();
		public function FactorySample()
		{
			_processes.addItem("monkey.Algebraic");
			_processes.addItem("monkey.CombineString");
			_processes.addItem("monkey.CreateElement");
		}
		
		public function get guid():String
		{
			return "1666EFD1-820C-B686-CD95-F6BFD776B045";
		}
		
		public function get author():String
		{
			return null;
		}
		
		public function get version():String
		{
			return null;
		}
		
		public function get description():String
		{
			return null;
		}
		
		public function get processes():Array
		{
			return _processes.toArray();
		}
		
		public function get objectTypes():Array
		{
			return null;
		}
		
		public function get events():Array
		{
			return null;
		}
		
		public function get jobTypes():Array
		{
			return null;
		}
		
		public function get uiEditors():Array{
			return null;
		}
		
		public function createProcess(name:String):IProcess
		{
			switch (name)
			{
				case "monkey.Algebraic":
				{
					return new ProcessAlgebraic();
				}
				case "monkey.CombineString":
				{
					return new ProcessCombineString();
				}
				case "monkey.CreateElement":
				{
					return new ProcessCreateElement();
				}
			}
			return null;
		}
		
		public function createConnector(inParaType:String, outParaType:String):IConnector
		{
			if (inParaType == "String" && outParaType == "XML")
			{
				return new ConnectorStringToXML();
			}
			return null;
		}
		
		public function createObject(type:String, value:String):Object
		{
			return null;
		}
		
		public function createJob(type:String):IJob
		{
			return null;
		}
		
		public function createUIEditor(type:String, property:CustomProperty = null):IUITypeEditor{
			return null;
		}
	}
}