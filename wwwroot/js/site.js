// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var stocksUrl = 'https://api.privatbank.ua/p24api/pubinfo?exchange&json&coursid=11';

var PhotoPageUrl = window.location.href + "/photos";
var BooksPageUrl = "/books";
var ImagesPageUrl = "/images";
var CompositionsPageUrl = "/compositions";

var animation = true;
var looper;
var degrees =0;

//using for counting photos. When photos send onload, 
//count it and when responses equal to number we know that all photos is loaded
var ImagesNumber;


function GetPhotoPage(){
    console.log("Getting photo page");
    ActivateAwaiter(GetAwaiter(),20);
    
    fetchTextPageToLoader('/photos',function(){
        ImagesNumber = document.getElementById("PhotosCounter").innerText;
        ImagesNumber = parseInt(ImagesNumber,10);
    });

    

}

function GetStocksPage(){
    ActivateAwaiter(GetAwaiter(),20);
    fetchJsonPageToLoader(stocksUrl);
}

function GetRegistrationPage(){
    ActivateAwaiter(GetAwaiter(),20);
    fetchTextPageToLoader('/registration',function(){
        getPageFromPageLoader()
    });
}

function GetMainPage(){
    ActivateAwaiter(GetAwaiter(),20);
    fetchTextPageToLoader('/main',function(){
        getPageFromPageLoader()
    });
}

function GetAwaiter(){
    document.getElementById('mainContainer').innerHTML = "<i class='fab fa-affiliatetheme' id='LoadingIcon'></i>";
    return 'LoadingIcon';
}


function ActivateAwaiter(el,speed){
    elem = document.getElementById(el);
    if(elem == null){
        return;
    }
	if(navigator.userAgent.match("Chrome")){
		elem.style.WebkitTransform = "rotate("+degrees+"deg)";
	} else if(navigator.userAgent.match("Firefox")){
		elem.style.MozTransform = "rotate("+degrees+"deg)";
	} else if(navigator.userAgent.match("MSIE")){
		elem.style.msTransform = "rotate("+degrees+"deg)";
	} else if(navigator.userAgent.match("Opera")){
		elem.style.OTransform = "rotate("+degrees+"deg)";
	} else {
		elem.style.transform = "rotate("+degrees+"deg)";
    }
    if(animation == false){
        delete(elem);
        return;
    }
	looper = setTimeout('ActivateAwaiter(\''+el+'\','+speed+')',speed);
    degrees++;
    
	if(degrees > 359 ){
		degrees = 1;
    }
    
}

function ActivateReact(){
    ActivateAwaiter(GetAwaiter(),20);
    fetchTextPageToLoader('/react',function(){
        getPageFromPageLoader()
    });  
}

function getPageFromPageLoader(){
    document.getElementById('mainContainer').innerHTML = document.getElementById('pageLoader').innerHTML;
    delete(document.getElementById('pageLoader'));
    delete(document.getElementById('topMargin'));
    delete(document.getElementById('bottomMargin'));
}

function fetchJsonPageToLoader(url,afterlFunc = null){
    fetch(url)
    .then(page => page.json()) 
    .then(function(page){
        document.getElementById('mainContainer').innerHTML = '<link href="/css/stocks.css" rel="stylesheet">';
        page.forEach(pair => {
            let el = document.createElement("div");
            el.id = pair.ccy;
            el.className = "ValutePair";
            el.innerHTML= "<ul>"+pair.ccy+"<li>Buy - "+pair.buy+" UAH</li>"+"<li>Sell -"+pair.sell+" UAH</li>"+"</ul>"
            document.getElementById('mainContainer').appendChild(el);
        });
    })
    .then(page => function(){
        if(afterlFunc){
            afterlFunc();
        }
    });
}

//text means in text format
function fetchTextPageToLoader(url,afterlFunc = null){
    console.log("some1");
    fetch(url)
    .then(page => page.text()) 
    .then(function(page){
        let topMargin = document.createElement("div");
        let downMargin = document.createElement("div");

        let pageLoader = document.createElement("div");

        document.getElementById('mainContainer').insertBefore(topMargin,document.getElementById("LoadingIcon"));
        document.getElementById('mainContainer').append(downMargin);
        document.getElementById('mainContainer').appendChild(pageLoader);


        topMargin.style.height = "25vh";
        topMargin.style.width = "100%";
        topMargin.id = "topMargin";

        downMargin.style.height = "25vh";
        downMargin.style.width = "100%";
        downMargin.id = "bottomMargin";

        pageLoader.id = "pageLoader";
        pageLoader.style.display = "none";
        
        pageLoader.innerHTML = page;
        if(afterlFunc){
            afterlFunc();
        }
    })
    
    
    
}

function PhotoLoaded(){
    ImagesNumber--;
    console.log(ImagesNumber);
    if(ImagesNumber==0 && document.getElementById('pageLoader')!=null){
        console.log("Done");
        getPageFromPageLoader();
        ImagesNumber = document.getElementById("PhotosCounter").innerText;
        ImagesNumber = parseInt(ImagesNumber,10);
    }
}

/**
 * 
 * @param {object} element 
 * @param {int} RotationSpeed (recomend from 1 to 10, but you can set wharewer you want i`l transformate it ^_^ ) 
 * @param {int} start 
 */
function rotate(element,RotationSpeed,start){
    element.style.transform = "rotate(" + String(RotationSpeed+start) + "deg)"
}



 

