package com.monkey.sample
{
	import com.monkey.process.IConnector;
	import com.monkey.process.IProcess;
	import com.monkey.process.ParaItem;
	
	import flash.utils.Dictionary;
	
	import mx.collections.ArrayCollection;
	import mx.collections.ArrayList;
	
	//两个数分别相加、相减、相乘的结果
	public class ProcessAlgebraic implements IProcess
	{
		private var _id:int = 0;
		private var _inputSet:ArrayList = null;
		private var _outputSet:ArrayList = null;
		private var _inputConnectors:Dictionary = new Dictionary();
		private var _inputObjs:Dictionary = new Dictionary();
		private var _outputConnectors:Dictionary = new Dictionary();
		private var _outputObjs:Dictionary = new Dictionary();
		
		public function ProcessAlgebraic()
		{
		}
		
		public function get guid():String
		{
			return "2666EFD1-820C-B686-CD95-F6BFD776B045";
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
			return "monkey.Algebraic";
		}
		
		public function get title():String
		{
			return "monkey.Algebraic";
		}
		
		public function get abstract():String
		{
			return "monkey.Algebraic";
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
				p1.name = "first";
				p1.dataType = "number";
				_inputSet.addItem(p1);
				
				var p2:ParaItem = new ParaItem();
				p2.name = "second";
				p2.dataType = "number";
				_inputSet.addItem(p2);
			}
			
			return _inputSet;
		}
		
		public function get outputSet():ArrayList
		{
			if (null == _outputSet)
			{
				_outputSet = new ArrayList();
				var p1:ParaItem = new ParaItem();
				p1.name = "plus";
				p1.dataType = "number";
				_outputSet.addItem(p1);
				
				var p2:ParaItem = new ParaItem();
				p2.name = "decrease";
				p2.dataType = "number";
				_outputSet.addItem(p2);
				
				var p3:ParaItem = new ParaItem();
				p3.name = "multiply";
				p3.dataType = "number";
				_outputSet.addItem(p3);
			}
			return _outputSet;
		}
		
		public function get events():ArrayList
		{
			return null;
		}
		
		public function isReady():Boolean
		{			
			var c:IConnector = _inputConnectors["first"];
			var o:Object = null;
			if (null == c)
			{
				o = _inputObjs["first"];
				if (null == o)
				{
					return false;
				}
			}
			c = _inputConnectors["second"];
			if (null == c)
			{
				o = _inputObjs["second"];
				if (null == o)
				{
					return false;
				}
			}
				
			return true;
		}
		
		public function setInputConnector(parameter:String, connector:IConnector):Boolean
		{
			if ("first" == parameter || "second" == parameter)
			{
				_inputConnectors[parameter] = connector;
				return true;
			}
			return false;
		}
		
		public function setInputValue(parameter:String, value:Object):Boolean
		{
			if ("first" == parameter || "second" == parameter)
			{
				_inputObjs[parameter] = value;
				return true;
			}
			return false;
		}
		
		public function setOutputConnector(parameter:String, connector:IConnector):Boolean
		{
			if ("plus" == parameter || "decrease" == parameter|| "multiply" == parameter)
			{
				_outputConnectors[parameter] = connector;
				return true;
			}
			return false;
		}
		
		public function getOutputValue(parameter:String):Object
		{
			if ("plus" == parameter || "decrease" == parameter|| "multiply" == parameter)
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
				var f:Number = 0;
				var s:Number = 0;
				
				var c:IConnector = _inputConnectors["first"];
				var o:Object = null;
				if (null != c)
				{
					f = c.pop() as Number;
				}
				else
				{
					o = _inputObjs["first"];
					if (null == o)
					{
						return false;
					}			
					f = o as Number;
				}
				
				c = _inputConnectors["second"];
				if (null != c)
				{
					s = c.pop() as Number;
				}
				else
				{
					o = _inputObjs["second"];
					if (null == o)
					{
						return false;
					}			
					s = o as Number;
				}
			
				var plus:Number = f + s;
				var decrease:Number = f - s;
				var multiply:Number = f * s;
				
				c = _outputConnectors["plus"];
				if (null != c)
				{
					c.push(plus);
				}
				_outputObjs["plus"] = plus;
				
				c = _outputConnectors["decrease"];
				if (null != c)
				{
					c.push(plus);
				}
				_outputObjs["decrease"] = decrease;
				
				c = _outputConnectors["multiply"];
				if (null != c)
				{
					c.push(plus);
				}
				_outputObjs["multiply"] = multiply;
					
				return true;
			}
			catch(e:Error)
			{
				
			}
			
			return false;
		}
	}
}