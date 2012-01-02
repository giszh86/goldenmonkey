package com.monkey.sample;

import java.util.ArrayList;
import java.util.EventListener;
import java.util.HashMap;

import org.w3c.dom.Element;

import com.monkey.designpattern.IConnectableObject;
import com.monkey.processing.EventItem;
import com.monkey.processing.ExecutedListener;
import com.monkey.processing.ExecutingListener;
import com.monkey.processing.IConnector;
import com.monkey.processing.IProcess;
import com.monkey.processing.ParaItem;
import com.monkey.processing.PausingListener;
import com.monkey.processing.SteppedListener;

public class ProcessCombineString implements IProcess {

	private int _id = 0;
	private ArrayList<ParaItem> _inputSet = null;
	private ArrayList<ParaItem> _outputSet = null;
	private HashMap<String, IConnector> _inputConnectors = new HashMap<String, IConnector>();
	private HashMap<String, Object> _inputObjs = new HashMap<String, Object>();
	private HashMap<String, IConnector> _outputConnectors = new HashMap<String, IConnector>();
	private HashMap<String, Object> _outputObjs = new HashMap<String, Object>();

	
	public void setGuid(String value){
		
	}
    public String getGuid(){
    	return "";
    }
    
	@Override
	public void setid(int value) {
		// TODO Auto-generated method stub
		this._id = value;
	}

	@Override
	public int getid() {
		// TODO Auto-generated method stub
		return this._id;
	}

	//为避免和其他人开发的功能名称重复，前面加上标识，以作区分
	@Override
	public String name() {
		// TODO Auto-generated method stub
		return "monkey.ProcessCombineString";
	}

	@Override
	public String getTitle() {
		// TODO Auto-generated method stub
		return "monkey.ProcessCombineString";
	}

	public void setTitle(String value) {		
	}
	
	@Override
	public String getAbstracts() {
		// TODO Auto-generated method stub
		return "monkey.ProcessCombineString";
	}
	
	public void setAbstracts(String value) {
		// TODO Auto-generated method stub		
	}

	@Override
	public ParaItem[] inputSet() {
		// TODO Auto-generated method stub
		try
		{
			if (null == _inputSet)
			{
				_inputSet = new ArrayList<ParaItem>();
				ParaItem p1 = new ParaItem();
				p1.setName("s1");
				p1.setDataType("String");
				_inputSet.add(p1);
				
				ParaItem p2 = new ParaItem();
				p2.setName("s2");
				p2.setDataType("String");
				_inputSet.add(p2);
				
				ParaItem p3 = new ParaItem();
				p3.setName("s3");
				p3.setDataType("String");
				_inputSet.add(p3);
			}
	
			ParaItem[] ps = new ParaItem[3];
			this._inputSet.toArray(ps);
			return ps;
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}
		
		return null;
	}

	@Override
	public ParaItem[] outputSet() {
		// TODO Auto-generated method stub
		try
		{
			if (null == _outputSet)
			{
				_outputSet = new ArrayList<ParaItem>();
				ParaItem p1 = new ParaItem();
				p1.setName("s12");
				p1.setDataType("String");
				_outputSet.add(p1);
				
				ParaItem p2 = new ParaItem();
				p2.setName("s13");
				p2.setDataType("String");
				_outputSet.add(p2);				
			}
			
			ParaItem[] ps = new ParaItem[2];
			this._outputSet.toArray(ps);
			return ps;
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}
		
		return null;
	}

	@Override
	public EventItem[] events() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean isReady() {
		// TODO Auto-generated method stub
		try
		{
			IConnector c = _inputConnectors.get("s1");
			Object o = null;
			if (null == c)
			{
				o = _inputObjs.get("s1");
				if (null == o)
				{
					return false;
				}
			}
			c = _inputConnectors.get("s2");
			if (null == c)
			{
				o = _inputObjs.get("s2");
				if (null == o)
				{
					return false;
				}
			}
			c = _inputConnectors.get("s3");
			if (null == c)
			{
				o = _inputObjs.get("s3");
				if (null == o)
				{
					return false;
				}
			}
			
			return true;
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}
		
		return false;
	}

	@Override
	public boolean setInputConnector(String parameter, IConnector connector) {
		// TODO Auto-generated method stub
		if (parameter.equalsIgnoreCase("s1") || parameter.equalsIgnoreCase("s2") || parameter.equalsIgnoreCase("s3")){
			_inputConnectors.put(parameter,connector);
			return true;
		}
		return false;
	}

	@Override
	public boolean setOutputConnector(String parameter, IConnector connector) {
		// TODO Auto-generated method stub
		if (parameter.equalsIgnoreCase("s12") || parameter.equalsIgnoreCase("s13")){
			_outputConnectors.put(parameter, connector);
			return true;
		}
		return false;
	}

	@Override
	public boolean setInputValue(String parameter, Object value) {
		// TODO Auto-generated method stub
		if (parameter.equalsIgnoreCase("s1") || parameter.equalsIgnoreCase("s2") || parameter.equalsIgnoreCase("s3")){
			_inputObjs.put(parameter,value);
			return true;
		}
		return false;
	}

	@Override
	public Object getOutputValue(String parameter) {
		// TODO Auto-generated method stub
		if (parameter.equalsIgnoreCase("s12") || parameter.equalsIgnoreCase("s13")){
			return _outputObjs.get(parameter);				
		}
		return null;
	}

	@Override
	public boolean bindingListener(String eventKey, EventListener l) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean execute() {
		try
		{
			String s1;
			String s2;
			String s3;
			
			IConnector c = _inputConnectors.get("s1");
			Object o = null;
			if (null != c)
			{
				s1 = (String)c.pop();
			}
			else
			{
				o = _inputObjs.get("s1");
				if (null == o)
				{
					return false;
				}			
				s1 = (String)o;
			}
			
			c = _inputConnectors.get("s2");
			if (null != c)
			{
				s2 = (String)c.pop();
			}
			else
			{
				o = _inputObjs.get("s2");
				if (null == o)
				{
					return false;
				}			
				s2 = (String)o;
			}
			
			c = _inputConnectors.get("s3");
			if (null != c)
			{
				s3 = (String)c.pop();
			}
			else
			{
				o = _inputObjs.get("s3");
				if (null == o)
				{
					return false;
				}			
				s3 = (String)o;
			}
			
			String s12 = s1 + s2;
			String s13 = s1 + s3;			
			
			c = _outputConnectors.get("s12");
			if (null != c)
			{
				c.push(s12);
			}
			_outputObjs.put("s12",s12);
			
			c = _outputConnectors.get("s13");
			if (null != c)
			{
				c.push(s13);
			}
			_outputObjs.put("s13",s13);
			
			return true;
		}
		catch(Error e)
		{
			
		}
		
		return false;
	}

	@Override
	public boolean cancel() {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean pause() {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean resume(Element state) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public void addSteppedListener(SteppedListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void removeSteppedListener(SteppedListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void addPausingListener(PausingListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void removePausingListener(PausingListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void addExecutingListener(ExecutingListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void removeExecutingListener(ExecutingListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void addExecutedListener(ExecutedListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void removeExecutedListener(ExecutedListener l) {
		// TODO Auto-generated method stub

	}

	public IProcess clone(){
		return null;
	}
	
	/**
     * 关联的输入连接对象
     */
	public IConnectableObject getInputConnectableObject(){
		return null;
	}
	public void setInputConnectableObject(IConnectableObject value){
		
	}

    /**
     * 关联的输出连接对象
     */
    public IConnectableObject getOutputConnectableObject(){
        return null;
    }
    public void setOutputConnectableObject(IConnectableObject value){
    	
    }
}
