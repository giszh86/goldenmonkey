package com.monkey.sample;

import java.util.EventListener;
import java.util.ArrayList;
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

public class ProcessAlgebraic implements IProcess {

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

	//"TProcessA
	//为避免和其他人开发的功能名称重复，前面加上标识，以作区分
	@Override
	public String name() {
		// TODO Auto-generated method stub
		return "monkey.ProcessAlgebraic";
	}

	@Override
	public String getTitle() {
		// TODO Auto-generated method stub
		return "monkey.ProcessAlgebraic";
	}
	
	public void setTitle(String value) {		
	}

	@Override
	public String getAbstracts() {
		// TODO Auto-generated method stub
		return "monkey.ProcessAlgebraic";
	}
	
	public void setAbstracts(String value) {
		// TODO Auto-generated method stub		
	}

	@Override
	public ParaItem[] inputSet() {
		try{
			if (null == _inputSet){
				_inputSet = new ArrayList<ParaItem>();
				ParaItem p1 = new ParaItem();
				p1.setName("first");
				p1.setDataType("number");
				_inputSet.add(p1);
				
				ParaItem p2 = new ParaItem();
				p2.setName("second");
				p2.setDataType("number");
				_inputSet.add(p2);
			}
				
			ParaItem[] ps = new ParaItem[2];
			this._inputSet.toArray(ps);
			return ps;			
		}
		catch(Exception e){
			e.printStackTrace();
		}
		
		return null;
	}

	@Override
	public ParaItem[] outputSet() {
		try{
			if (null == _outputSet){
				_outputSet = new ArrayList<ParaItem>();
				ParaItem p1 = new ParaItem();
				p1.setName("plus");
				p1.setDataType("number");
				_outputSet.add(p1);
				
				ParaItem p2 = new ParaItem();
				p2.setName("decrease");
				p2.setDataType("number");
				_outputSet.add(p2);
				
				ParaItem p3 = new ParaItem();
				p3.setName("multiply");
				p3.setDataType("number");
				_outputSet.add(p3);
			}
		
			ParaItem[] ps = new ParaItem[3];
			this._outputSet.toArray(ps);
			return ps;
		}
		catch(Exception e){
			e.printStackTrace();
		}
		
		return null;
	}

	@Override
	public EventItem[] events() {
		return null;
	}

	@Override
	public boolean isReady() {		
		try{
			if (!_inputConnectors.containsKey("first") && 
					!_inputObjs.containsKey("first")){
				return false;		
			}		
			
			if (!_inputConnectors.containsKey("second") && 
					!_inputObjs.containsKey("second")){
				return false;		
			}		
				
			return true;
		}
		catch(Exception e){
			e.printStackTrace();
		}
		
		return false;
	}

	@Override
	public boolean setInputConnector(String parameter, IConnector connector) {
		if (parameter.equalsIgnoreCase("first") || parameter.equalsIgnoreCase("second")){
			_inputConnectors.put(parameter,connector);
			return true;
		}
		return false;
	}

	@Override
	public boolean setOutputConnector(String parameter, IConnector connector) {
		// TODO Auto-generated method stub
		if (parameter.equalsIgnoreCase("plus") || parameter.equalsIgnoreCase("decrease") || parameter.equalsIgnoreCase("multiply")){
			_outputConnectors.put(parameter,connector);
			return true;
		}
		return false;
	}

	@Override
	public boolean setInputValue(String parameter, Object value) {
		// TODO Auto-generated method stub
		if (parameter.equalsIgnoreCase("first") || parameter.equalsIgnoreCase("second")){
			_inputObjs.put(parameter,value);
			return true;
		}
		return false;
	}

	@Override
	public Object getOutputValue(String parameter) {
		// TODO Auto-generated method stub
		if (parameter.equalsIgnoreCase("plus") || parameter.equalsIgnoreCase("decrease") || parameter.equalsIgnoreCase("multiply")){
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
		try{			
			Number f = 0;
			Number s = 0;
			
			IConnector c = _inputConnectors.get("first");
			Object o = null;
			if (null != c){
				f = (Number)(c.pop());
			}
			else{
				o = _inputObjs.get("first");
				if (null == o){
					return false;
				}			
				f = (Number)o;
			}
			
			c = _inputConnectors.get("second");
			if (null != c){
				s = (Number)c.pop();
			}
			else{
				o = _inputObjs.get("second");
				if (null == o){
					return false;
				}			
				s = (Number)o;
			}
		
			Number plus = f.doubleValue() + s.doubleValue();
			Number decrease = f.doubleValue() - s.doubleValue();
			Number multiply = f.doubleValue() * s.doubleValue();
			
			c = _outputConnectors.get("plus");
			if (null != c){
				c.push(plus);
			}
			_outputObjs.put("plus", plus);
			
			c = _outputConnectors.get("decrease");
			if (null != c){
				c.push(plus);
			}
			_outputObjs.put("decrease",decrease);
			
			c = _outputConnectors.get("multiply");
			if (null != c){
				c.push(plus);
			}
			_outputObjs.put("multiply", multiply);
				
			return true;
		}
		catch(Error e){			
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
	
	public IConnectableObject getInputConnectableObject(){
		return null;
	}
	
	public void setInputConnectableObject(IConnectableObject value){
		
	}

	public IConnectableObject getOutputConnectableObject(){
        return null;
    }
    
	public void setOutputConnectableObject(IConnectableObject value){
    	
    }
}
