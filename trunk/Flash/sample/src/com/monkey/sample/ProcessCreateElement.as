package com.monkey.sample
{
	import com.monkey.process.IConnector;
	import com.monkey.process.IProcess;
	import com.monkey.process.ParaItem;
	
	import flash.utils.Dictionary;
	
	import mx.collections.ArrayCollection;
	import mx.collections.ArrayList;
	
	public class ProcessCreateElement implements IProcess
	{
		private var _id:int = 0;
		private var _inputSet:ArrayList = null;
		private var _outputSet:ArrayList = null;
		private var _inputConnectors:Dictionary = new Dictionary();
		private var _inputObjs:Dictionary = new Dictionary();
		private var _outputConnectors:Dictionary = new Dictionary();
		private var _outputObjs:Dictionary = new Dictionary();
		
		public function ProcessCreateElement()
		{
		}
		
		public function get guid():String
		{
			return "4666EFD1-820C-B686-CD95-F6BFD776B045";
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
			return "monkey.CreateElement";
		}
		
		public function get title():String
		{
			return "monkey.CreateElement";
		}
		
		public function get abstract():String
		{
			return "monkey.CreateElement";
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
				p1.name = "key";
				p1.dataType = "String";
				_inputSet.addItem(p1);
				
				var p2:ParaItem = new ParaItem();
				p2.name = "value";
				p2.dataType = "number";
				_inputSet.addItem(p2);	
				
				var p3:ParaItem = new ParaItem();
				p3.name = "file";
				p3.dataType = "XML";
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
				p1.name = "file";
				p1.dataType = "XML";
				_outputSet.addItem(p1);							
			}
			return _outputSet;
		}
		
		public function get events():ArrayList
		{
			return null;
		}
		
		public function isReady():Boolean
		{
			var c:IConnector = _inputConnectors["key"];
			var o:Object = null;
			if (null == c)
			{
				o = _inputObjs["key"];
				if (null == o)
				{
					return false;
				}
			}
			c = _inputConnectors["value"];
			if (null == c)
			{
				o = _inputObjs["value"];
				if (null == o)
				{
					return false;
				}
			}
			c = _inputConnectors["file"];
			if (null == c)
			{
				o = _inputObjs["file"];
				if (null == o)
				{
					return false;
				}
			}
			
			return true;
		}
		
		public function setInputConnector(parameter:String, connector:IConnector):Boolean
		{
			if ("key" == parameter || "value" == parameter || "file" == parameter)
			{
				_inputConnectors[parameter] = connector;
				return true;
			}
			return false;
		}
		
		public function setInputValue(parameter:String, value:Object):Boolean
		{
			if ("key" == parameter || "value" == parameter || "file" == parameter)
			{
				_inputObjs[parameter] = value;
				return true;
			}
			return false;
		}
		
		public function setOutputConnector(parameter:String, connector:IConnector):Boolean
		{
			if ("file" == parameter)
			{
				_outputConnectors[parameter] = connector;
				return true;
			}
			return false;
		}
		
		public function getOutputValue(parameter:String):Object
		{
			if ("file" == parameter)
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
				var key:String = "";
				var value:Number = 0;
				var file:XML = null;
				
				var c:IConnector = _inputConnectors["key"];
				var o:Object = null;
				if (null != c)
				{
					key = c.pop() as String;
				}
				else
				{
					o = _inputObjs["key"];
					if (null == o)
					{
						return false;
					}			
					key = o as String;
				}
				
				c = _inputConnectors["value"];
				if (null != c)
				{
					value = c.pop() as Number;
				}
				else
				{
					o = _inputObjs["value"];
					if (null == o)
					{
						return false;
					}			
					value = o as Number;
				}
				
				c = _inputConnectors["file"];
				if (null != c)
				{
					file = c.pop() as XML;
				}
				else
				{
					o = _inputObjs["file"];
					if (null == o)
					{
						return false;
					}			
					file = o as XML;
				}
				
				var node:XML = <item key="" value="" ></item>
				node.@key = key;
				node.@value = value;				
				file.appendChild(node);
				
				c = _outputConnectors["file"];
				if (null != c)
				{
					c.push(file);
				}
				_outputObjs["file"] = file;
				
				return true;
			}
			catch(e:Error)
			{
			}
			
			return false;
		}
	}
}