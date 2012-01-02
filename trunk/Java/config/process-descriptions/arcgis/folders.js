// 2 Objects in this package

// Swapper
//	pre-loading images

// Opener
// 	static methods



function Swapper (props)
// eg. props = {open: "open.gif",close: "closed.gif"} );
// Swapper Image Object
//var swapImg = new Swapper ({open: "open.gif",close: "closed.gif"} );

// Swapper Image using a hot rollover image
//var swapHot = new Swapper ({normal: "updown.gif",rollover: "updown_hot.gif"} );


{
	
	// index of images
	this.index = 0;
	
	// kept as hash and array
	this.images = new Array();
	
	if (typeof(_Swapper_prototype_called) == 'undefined') {
		_Swapper_prototype_called = true;
		
		// class method
		Swapper.prototype.nextImage   = nextImage;
		Swapper.prototype.changeImage = changeImage;
	}

	
	for (property in props)
	// add properties to this name space
	{
		// preload images
		
		//   into hash
		var img = new Image (16,16); // temp obj
		img.src = props[property];
	
		//   into indexable array & hash
		this.images.push (img);
		this.images[property] = img;
		
		
		
		
	}
	
	function nextImage (id)
	// id = the "NAME=xxx" of an IMG element
	{
		// INC or reset
		(this.index == (this.images.length-1)) ? this.index = 0 : this.index++;
		
		var obj = getImageObject (id);
		
		if (obj) {
			obj.src = this.images[this.index].src;
		}


	}
		
	function changeImage (id,to)
	// id = the "NAME=xxx" of an IMG element
	// to = the image to change to
	{
		var obj = getImageObject (id);
		
		if (obj) {
			obj.src = this.images[to].src;
		}
	}
	
}





function Opener ()
{

	Opener.visi = visi;
	Opener.block = block;
	

	//function showHideBlock (objName,trigger)
	//{
		// works with NS4, JS1.2+
		// NS4 doesn't recognize events for <img>
		//var theEvent = window.event || //arguments.callee.caller.arguments[0];
		
		//visi (objName);
		
	//}
	
	function visi(nr) 
	// from: http://www.xs4all.nl/~ppk/js/index.html
	{
		if (document.layers)
		{
			// elements HAVE TO have a 'CLASS=...' associated with it!
			//alert ("document.layers");
			vista = (document.layers[nr].visibility == 'hide') ? 'show' : 'hide'
			document.layers[nr].visibility = vista;
		}
		else if (document.all)
		{
			//alert ("document.all");
			vista = (document.all[nr].style.visibility == 'hidden') ? 'visible'	: 'hidden';
			document.all[nr].style.visibility = vista;
		}
		else if (document.getElementById)
		{
			//alert ("document.getElementById");
			vista = (document.getElementById(nr).style.visibility.toLowerCase() == 'hidden') ? 'visible' : 'hidden';
			document.getElementById(nr).style.visibility = vista;
	
		}
	}
	
	function block(nr) 
	// from: http://www.xs4all.nl/~ppk/js/index.html
	// This doesn't work for NS4
	{
	
		
		if (document.layers)
		{
			// elements HAVE TO have a 'CLASS=...' associated with it!
			//alert ("document.layers");
			current = (document.layers[nr].display == 'none') ? '' : 'none';
			
			// original code had 'block' here instead of nothing: ''
			//current = (document.layers[nr].display == 'none') ? 'block' : 'none';
			document.layers[nr].display = current;
		}
		else if (document.all)
		{
			//alert ("document.all");
			current = (document.all[nr].style.display == 'none') ? '' : 'none';
			document.all[nr].style.display = current;
		}
		else if (document.getElementById)
		{
			//alert ("document.getElementById");
			vista = (document.getElementById(nr).style.display == 'none') ? '' : 'none';
			document.getElementById(nr).style.display = vista;
		}
	}


}

Opener ();

