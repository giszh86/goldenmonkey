package com.monkey.sample
{
	import com.monkey.process.IConnector;
	import com.monkey.process.IProcess;
	import com.monkey.process.ParaItem;
	
	import flash.utils.Dictionary;
	
	import mx.collections.ArrayCollection;
	import mx.collections.ArrayList;
	
	public class ProcessCombineString implements IProcess
	{
		private var _id:int = 0;
		private var _inputSet:ArrayList = null;
		private var _outputSet:ArrayList = null;
		private var _inputConnectors:Dictionary = new Dictionary();
		private var _inputObjs:Dictionary = new Dictionary();
		private var _outputConnectors:Dictionary = new Dictionary();
		private var _outputObjs:Dictionary = new Dictionary();
		
		public function ProcessCombineString()
		{
		}
		
		public function get guid():String
		{
			return "3666EFD1-820C-B686-CD95-F6BFD776B045";
		}
		
		public function get number():int
		{
			return _id;
		}
		
		public function set number(value:int):void
		{
			_id = value;
		}
		
		public function get name():String
		{
			return "monkey.CombineString";
		}
		
		public function get title():String
		{
			return "monkey.CombineString";
		}
		
		public function get abstract():String
		{
			return "monkey.CombineString";
		}
		
		public function get asynchronous():Boolean{
			return false;
		}
		
		public function set processedHandler(listener:Function):void{		
		}
		
		public function get inputSet():ArrayList
		{
			if (null == _inputSet)
			{
				_inputSet = new ArrayList();
				var p1:ParaItem = new ParaItem();
				p1.name = "s1";
				p1.dataType = "String";
				_inputSet.addItem(p1);
				
				var p2:ParaItem = new ParaItem();
				p2.name = "s2";
				p2.dataType = "String";
				_inputSet.addItem(p2);
				
				var p3:ParaItem = new ParaItem();
				p3.name = "s3";
				p3.dataType = "String";
				_inputSet.addItem(p3);
			}
			
			return _inputSet;
		}
		
		public function get outputSet():ArrayList
		{
			if (null == _outputSet)
			{
				_outputSet = new ArrayList();
				var p1:ParaItem = new ParaItem();
				p1.name = "s12";
				p1.dataType = "String";
				_outputSet.addItem(p1);
				
				var p2:ParaItem = new ParaItem();
				p2.name = "s13";
				p2.dataType = "String";
				_outputSet.addItem(p2);				
			}
			return _outputSet;
		}
		
		public function get events():ArrayList
		{
			return null;
		}
		
		public function isReady():Boolean
		{
			var c:IConnector = _inputConnectors["s1"];
			var o:Object = null;
			if (null == c)
			{
				o = _inputObjs["s1"];
				if (null == o)
				{
					return false;
				}
			}
			c = _inputConnectors["s2"];
			if (null == c)
			{
				o = _inputObjs["s2"];
				if (null == o)
				{
					return false;
				}
			}
			c = _inputConnectors["s3"];
			if (null == c)
			{
				o = _inputObjs["s3"];
				if (null == o)
				{
					return false;
				}
			}
			
			return true;
		}
		
		public function setInputConnector(parameter:String, connector:IConnector):Boolean
		{
			if ("s1" == parameter || "s2" == parameter || "s3" == parameter)
			{
				_inputConnectors[parameter] = connector;
				return true;
			}
			return false;
		}
		
		public function setInputValue(parameter:String, value:Object):Boolean
		{
			if ("s1" == parameter || "s2" == parameter || "s3" == parameter)
			{
				_inputObjs[parameter] = value;
				return true;
			}
			return false;
		}
		
		public function setOutputConnector(parameter:String, connector:IConnector):Boolean
		{
			if ("s12" == parameter || "s13" == parameter)
			{
				_outputConnectors[parameter] = connector;
				return true;
			}
			return false;
		}
		
		public function getOutputValue(parameter:String):Object
		{
			if ("s12" == parameter || "s13" == parameter)
			{
				return _outputObjs[parameter];				
			}
			return null;
		}
		
		public function cancel():Boolean
		{
			return false;
		}
		
		public function pause():Boolean
		{
			return false;
		}
		
		public function clone():IProcess
		{
			return null;
		}
		
		public function execute():Boolean
		{
			try
			{
				var s1:String;
				var s2:String;
				var s3:String;
				
				var c:IConnector = _inputConnectors["s1"];
				var o:Object = null;
				if (null != c)
				{
					s1 = c.pop() as String;
				}
				else
				{
					o = _inputObjs["s1"];
					if (null == o)
					{
						return false;
					}			
					s1 = o as String;
				}
				
				c = _inputConnectors["s2"];
				if (null != c)
				{
					s2 = c.pop() as String;
				}
				else
				{
					o = _inputObjs["s2"];
					if (null == o)
					{
						return false;
					}			
					s2 = o as String;
				}
				
				c = _inputConnectors["s3"];
				if (null != c)
				{
					s3 = c.pop() as String;
				}
				else
				{
					o = _inputObjs["s3"];
					if (null == o)
					{
						return false;
					}			
					s3 = o as String;
				}
				
				var s12:String = s1 + s2;
				var s13:String = s1 + s3;			
				
				c = _outputConnectors["s12"];
				if (null != c)
				{
					c.push(s12);
				}
				_outputObjs["s12"] = s12;
				
				c = _outputConnectors["s13"];
				if (null != c)
				{
					c.push(s13);
				}
				_outputObjs["s13"] = s13;
				
				return true;
			}
			catch(e:Error)
			{
				
			}
			
			return false;
		}
	}
}