//=============================================
//=== Gets browser and platform information ===
//=============================================
function Is() {
    var agent = navigator.userAgent.toLowerCase();
	this.major = parseInt(navigator.appVersion);
    this.NN  = ((agent.indexOf('mozilla')!= -1) && ((agent.indexOf('spoofer')==-1) && (agent.indexOf('compatible') == -1)));
    this.IE   = (agent.indexOf("msie") != -1);
    this.WIN = (agent.indexOf("win") != -1);
    this.IE5 = (this.IE && (agent.indexOf('5') != -1));
}

//=============================================
//=== Removes the Help menu ===
//=============================================
function removeHelpMenu2(){
 var x;
 x = new ActiveXObject("esriHelp.HelpCore");
 x.MenuDelete2();
}


//====================================================================
//=== Inserts external style sheet reference depending on browser  ===
//====================================================================
function insertStyle() {
	var d = document;
	d.write('<STYLE TYPE="text/css">');
	if (is.NN) {
		d.write('.visible {position:absolute; visibility:visible} ');
		d.write('.subhead {position:absolute; visibility:visible; margin-left:30px;} ');
		d.write('.subcontent {position:absolute; visibility:visible; margin-left:30px;} ');
		d.write('.subh {position:absolute; visibility:visible} ');
		d.write('.subc {position:absolute; visibility:visible} ');
	} else {
		d.write('.subhead {display:none; margin-left:24px;} ');
		d.write('.subcontent {display:none; margin-left : 24px;} ');
		d.write('.subh {display:none;} ');
		d.write('.subc {display:none;} ');
	}
	d.write('</STYLE>');
}

//===================================================
//=== Initializes stuff, depending on the browser ===
//===================================================
var is = new Is();
var firstInd = null;
var pre = new Image();
pre.src = "sm_arrow_down.gif";
isExpanded = false;

//===================================================
//=== In ChmMode, the calling file has implemented===
//=== an iFrame to store the expanded topicID in  ===
//=== cookies. The cookies are retrieved and the  ===
//=== topics are restored to the states that when ===
//=== they were last opened						  ===
//===================================================

var ChmMode = document.URL.indexOf("~hh") == -1 ? true: false;

if (ChmMode)
{
  var fileName = getFileName();
  var hiddenLoaded = 0;
  var cookieURL = document.URL;


  if (cookieURL.indexOf("file://") != -1){
	cookieURL = cookieURL.substring(0, cookieURL.lastIndexOf("\\") + 1) + "hidden.htm"; 
	cookieURL = cookieURL.replace("file://", "file:\\\\");
  } else {
	//To accommodate both protocols: ms-its and MSITStore
	var start = cookieURL.indexOf("ms-its") == -1? 14:7;
	cookieURL = cookieURL.substring(start , cookieURL.indexOf("::")); 
	cookieURL = cookieURL.substring(0, cookieURL.lastIndexOf("\\") + 1); 
	cookieURL = "file:\\" + cookieURL + "hidden.htm"; 
  }
  while (cookieURL.indexOf("%20") != -1)
  {
	cookieURL = cookieURL.replace("%20", " ");
  }
}

function getFileName() {
  var str = document.location.pathname;      //sets str to the path name of the URL, omitting host and any queries
  return str;
}

function getFirstDiv_Frame() {
	if (is.NN) {
		firstInd = 0;
		arrange();
		initIt();
	} else {
	  if (hiddenLoaded != 0) {
		if (document.frames["hidden"].getCookie()) {
		  restorePageState(document.frames["hidden"].getCookie());
		} else {
		  initIt();
		}
	  } else {
		setTimeout("getFirstDiv()", 0);
	  }
	}
}

function getFirstDiv_NoFrame() {
	if (is.NN) {
		firstInd = 0;
	    arrange();
		initIt();
	} else {
		initIt();
	}
}

function getFirstDiv() {
	if (ChmMode) {
		getFirstDiv_Frame();
	} else {
		getFirstDiv_NoFrame();
	}
}



function restorePageState(list) {
  if (is.IE) {
    var count = 0;
		divColl = document.all.tags("DIV");
		for (i=0; i<divColl.length; i++) {
			whichDiv = divColl(i);
      whichDiv.style.display = "none";      
			if (list.indexOf(whichDiv.id) != -1) {  //if the layer is contained within the cookie list
        whichDiv.style.display = "block";
        count++;
        if (whichDiv.id.indexOf("Sub") == -1) {  //set the arrow on main headings to 'up'
          whichDiv.all['imEx'].src = "arrow_up.gif";
        }
        if (whichDiv.id.indexOf("Content") != -1) {  //if it's a 'content' layer, change the 'sub' layers arrow to 'down'
          index = whichDiv.id.indexOf("Content");
          str = whichDiv.id;
          p = str.slice(0, index);
          if (document.all[p] != null) {
            document.all[p].all['imEx'].src = "sm_arrow_down.gif"
          }
        }
        if (whichDiv.id.indexOf("Sub") != -1) {  //if it's a 'sub' layer, change the main heading arrow to 'down'
          index = whichDiv.id.indexOf("Sub");
          str = whichDiv.id;
          p = str.slice(0, index);
          if (document.all[p] != null) {
            document.all[p].all['imEx'].src = "arrow_down.gif"
          }
        }
      }
		}
    if (count == divColl.length) {
      for (i=0; i<document.images.length; i++) {
        if (document.images[i].src.indexOf("expand.gif") != -1) {
          document.images[i].src = "collapse.gif";
          isExpanded = true;
        }
      }
    }
	}
}

function getIndex(div) {
	ind = null;
	for (i=0; i < document.layers.length; i++) {
		whichDiv = document.layers[i];
		if (whichDiv.id == div) {
			ind = i;
			break;
		}
	}
	return ind;
}

function initIt() {
	if (is.NN) {
		for (i=firstInd+1; i<document.layers.length; i++) {
			whichDiv = document.layers[i];
			if (whichDiv.id.indexOf("Content") != -1) {
				whichDiv.visibility = "hide";
			}
			if (whichDiv.id.indexOf("how") == -1) {
				if (whichDiv.id.indexOf("Sub") != -1) whichDiv.visibility = "hide";
			} else {
				if (whichDiv.id.indexOf("Sub") != -1 && (whichDiv.id.indexOf("Content") == -1)) whichDiv.visibility = "show";
			}
		}
		arrange();
	} else {
		divColl = document.all.tags("DIV");
		for (i=0; i<divColl.length; i++) {
			whichDiv = divColl(i);
			if (whichDiv.className.indexOf("subc") != -1) whichDiv.style.display = "none";
			if (whichDiv.id.indexOf("how") == -1) {
				if (whichDiv.className.indexOf("subh") != -1) whichDiv.style.display = "none";
			} else {
				if (whichDiv.className.indexOf("subh") != -1) whichDiv.style.display = "block";
			}
		}
	}
}

function arrange() {
	nextY = document.layers[firstInd].pageY + document.layers[firstInd].document.height;
	for (i=firstInd+1; i<document.layers.length; i++) {
		whichDiv = document.layers[i];
		if (whichDiv.visibility != "hide") {
			whichDiv.pageY = nextY;
			nextY += whichDiv.document.height;
		}
	}
}
	
function expandIt(div) {

	if (is.IE) {
		if (div.indexOf("Sub") != -1) {
			whichDiv = eval(div + "Content");
			whichIm = event.srcElement;
			if (whichDiv.style.display == "none") {
				whichDiv.style.display = "block";
				whichIm.src = "sm_arrow_down.gif";        
			} else {
				whichDiv.style.display = "none";
				whichIm.src = "small_arrow_up.gif";
			
			}
		} else {
			whichIm = event.srcElement;
			divColl = document.all.tags("DIV");
			for (i=0; i<divColl.length; i++) {
				whichDiv = divColl(i);
				if ((whichDiv.id.indexOf(div + "Sub") != -1) && (whichDiv.id.indexOf("Content") == -1)) {	
					if (whichDiv.style.display == "none") {
						whichDiv.style.display = "block";
						whichIm.src = "arrow_down.gif";
					} else {
						whichDiv.style.display = "none";
						whichIm.src = "arrow_up.gif";
						if (whichDiv.id.indexOf("Text") == -1) {
							whichOtherIm = whichDiv.all['imEx'];
							whichOtherIm.src = "small_arrow_up.gif";
						}
					}
				} else {
					if ((whichDiv.id.indexOf(div + "Sub") != -1) && (whichDiv.id.indexOf("Content") != -1)) {
						whichDiv.style.display = "none";
					}
				}
			}
		}
	if (ChmMode) {
	  getOpenMenus();
	}
	} else {
		if (div.indexOf("Sub") != -1) {
			whichDiv = eval("document." + div + "Content");
			whichIm = eval("document." + div + ".document.images['imEx']");
			if (whichDiv.visibility == "hide") {
				whichDiv.visibility = "show";
				whichIm.src = "sm_arrow_down.gif";
			} else {
				whichDiv.visibility = "hide";
				whichIm.src = "small_arrow_up.gif";
			}
		} else {
			whichIm = eval("document." + div + ".document.images['imEx']");
			for (i=firstInd+1; i<document.layers.length; i++) {
				whichDiv = document.layers[i];
				if ((whichDiv.id.indexOf(div + "Sub") != -1) && (whichDiv.id.indexOf("Content") == -1)) {
					if (whichDiv.visibility == "hide") {
						whichDiv.visibility = "show";
						whichIm.src = "arrow_down.gif";
					} else {
						whichDiv.visibility = "hide";
						whichIm.src = "arrow_up.gif";
						if (whichDiv.id.indexOf("Text") == -1) {
							whichOtherIm = eval("whichDiv.document.images['imEx']");
							whichOtherIm.src = "small_arrow_up.gif";
						}
					}
				} else {
					if ((whichDiv.id.indexOf(div + "Sub") != -1) && (whichDiv.id.indexOf("Content") != -1)) {
						whichDiv.visibility = "hide";
					}
				}
			}
		}
		arrange();
	}
}

function openit(tool) {
	var oShell = new ActiveXObject("Shell.Application");
	doc = document.URL
        x = doc.lastIndexOf("\\")
	path = doc.substring(0,x)
	y = path.indexOf("\%")
	if (y != -1) {
		a = path.substring(0,y);
		b = path.substring(y + 3, path.length);
		path = a + " " + b
	}
	commandtoRun = path + "\\runtool.exe";
	oShell.ShellExecute(commandtoRun, tool, "", "open", "1");
}

function expandAll() {
	newExpSrc = (isExpanded) ? "expand.gif" : "collapse.gif";
	arrowSrc = (isExpanded) ? "arrow_up.gif" : "arrow_down.gif";
	smallArrowSrc = (isExpanded) ? "small_arrow_up.gif" : "sm_arrow_down.gif";
	parentExists = 0;
	if (is.NN) {
		document.images["imEx"].src = newExpSrc;
		for (i=firstInd; i<document.layers.length; i++) {
			whichDiv = document.layers[i];
			if (whichDiv.id.indexOf("Sub") == -1) {
				whichDiv.document.images["imEx"].src = arrowSrc;
				parentExists++;
			}
			if (whichDiv.id.indexOf("Sub") != -1 && (whichDiv.id.indexOf("Content") == -1)) {
				if (whichDiv.id.indexOf("Text") == -1) {
					whichDiv.document.images["imEx"].src = smallArrowSrc;
				}
				if (parentExists > 0) {
					whichDiv.visibility = (isExpanded) ? "hide" : "show";
				}
			}
			if (whichDiv.id.indexOf("Content") != -1) {
				whichDiv.visibility = (isExpanded) ? "hide" : "show";
			}
		}
		arrange();
	} else {
		event.srcElement.src = newExpSrc;
		divColl = document.all.tags("DIV");
		for (i=0; i<divColl.length; i++) {
			whichDiv = divColl(i);
			if (whichDiv.id.indexOf("Sub") == -1) {
				whichDiv.all["imEx"].src = arrowSrc;
				parentExists++;
			}
			if (whichDiv.id.indexOf("Sub") != -1 && (whichDiv.id.indexOf("Content") == -1)) {
				if (whichDiv.id.indexOf("Text") == -1) {
					whichDiv.all["imEx"].src = smallArrowSrc;
				}
				if (parentExists > 0) {
					whichDiv.style.display = (isExpanded) ? "none" : "block";
				}
			}
			if (whichDiv.id.indexOf("Content") != -1) {
				whichDiv.style.display = (isExpanded) ? "none" : "block";
			}
		}
	if (ChmMode) {
	  getOpenMenus();
	}
	}
	isExpanded = !isExpanded;
}

function getOpenMenus() {
  divColl = document.all.tags("DIV");
  openMenus = "";
  for (i=0; i<divColl.length; i++) {
 	  whichDiv = divColl(i);
    if (whichDiv.style.display != "none") {
      openMenus += whichDiv.id + ","
    }
  }  
  openMenus = openMenus.slice(0,-1);
  document.frames["hidden"].cookie(fileName, openMenus);
}


//=============================================
//=== Geoprocessing ===
//=============================================


function expandAllGP(path) {
	expand_img = path + "expand.gif"
	collapse_img = path + "collapse.gif"
	newExpSrc = (isExpanded) ? expand_img : collapse_img;
	parentExists = 0;
	{
		event.srcElement.src = newExpSrc;
		divColl = document.all.tags("DIV");
		imgColl = document.getElementsByName("imEx");
		for (i=0; i<divColl.length; i++) {
			whichDiv = divColl(i);
			whichImg = imgColl(i);
		parentExists++;
				if (whichDiv.id.indexOf("Text") == -1) {
			if (parentExists > 0) {

// need to sniff out if the which image to use
varResults = (imgColl(i).src.indexOf("2"));


 if (varResults  > -1) {
	down_img = path + "sm_arrow_down.gif";
	up_img = path + "small_arrow_up.gif";
 } else {
 	down_img = path + "sm_arrow_down.gif";
	up_img = path + "small_arrow_up.gif";
 }
			
					whichDiv.style.display = (isExpanded) ? "none" : "block";
					whichImg.src = (isExpanded) ? up_img : down_img;
					up_img = '';
					down_img= '';
				}
			}
			if (whichDiv.id.indexOf("Content") != -1) {
				whichDiv.style.display = (isExpanded) ? "none" : "block";
//need to change the arrow image					
whichImg.src = up_img;
			}
		}
	}
	isExpanded = !isExpanded;
	}

function expandItGP(div, path, img) {
if (img == "small_arrow_up2.gif" ) {
	imgUp = "small_arrow_up2.gif"; 
	imgDown = "sm_arrow_down2.gif";
	} else {
	imgUp = "small_arrow_up.gif";
	imgDown = "sm_arrow_down.gif";	
	}
	downPath = path + imgDown;
	upPath = path + imgUp;
	img = "";
	if (is.IE) {
//		if (div.indexOf("Sub") != -1) {
			whichDiv = eval(div);
			whichIm = event.srcElement;
				if (whichDiv.style.display == "none") {
				whichDiv.style.display = "block";				
			whichIm.src = downPath;        
			} else {
				whichDiv.style.display = "none";
				whichIm.src = upPath;
			}
//		}
	} else {
	//THIS IS FOR NETSCAPE	
		if (div.indexOf("Sub") != -1) {
			whichDiv = eval("document." + div + "Content");
			whichIm = eval("document." + div + ".document.images['imEx']");
			if (whichDiv.visibility == "hide") {
				whichDiv.visibility = "show";
				whichIm.src = "sm_arrow_down.gif";
			} else {
				whichDiv.visibility = "hide";
				whichIm.src = "small_arrow_up.gif";
			}
		} 
		arrange();
	}
}