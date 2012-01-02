package com.monkey.sample
{
	import com.monkey.process.IConnector;
	
	import flash.events.Event;
	import flash.events.TimerEvent;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import flash.utils.Timer;
	
	
	public class ConnectorStringToXML implements IConnector
	{
		private var _id:int = 0;
		private var _xml:XML = null;
		
		public function ConnectorStringToXML()
		{
		}
		
		public function get number():int
		{
			return _id;
		}
		
		public function set number(value:int):void
		{
			_id = value;
		}
		
		public function get inputType():String
		{
			return "String";
		}
		
		public function get outputType():String
		{
			return "XML";
		}
		
		public function clone():IConnector
		{
			return null;
		}
		
		public function pop():Object
		{			
			return _xml;
		}
		
		public function push(value:Object):void
		{
			var tag:String = value as String;
			_xml = new XML("<"+ tag + "/>");			
		}
	}
}