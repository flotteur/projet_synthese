// two global variables
var secondsRemaining;
var intervalHandle;




function tick() {
  
     var timeDisplay = document.getElementById("time");
  
    // turn seconds into mm:ss
    var min = Math.floor(secondsRemaining / 60);
    var sec = secondsRemaining - (min * 60);
    
    // add a leading zero (as a string value) if seconds less than 10
    if (sec < 10) {
        sec = "0" + sec;
    }
    // concatenate with colon
    var message = min + ":" + sec;
    // now change the display
    timeDisplay.innerHTML = message;
    
    
     // changement de couleur pour la dernire minute !!!
    if (secondsRemaining < 60) {
        timeDisplay.setAttribute("style","font-size: 6em; color: #fc0008; background-color: #c2b8ee;");
     }
    
    
    // stop if down to zero
    if (secondsRemaining === 0) {        
        alert('Termin\351!');
        clearInterval(intervalHandle);
        
        document.getElementById("inputArea").style.display = "block";
        
        // couleur au dŽpart du compteur
        timeDisplay.setAttribute("style","font-size: 5em; color: #FF00FF; background-color: #D5D6D7;");
      }
     
    // subtract from seconds remaining
    secondsRemaining--;
}




function startCountdown() {
    
   
    // get contents of the "minutes" text box
    var minutes = document.getElementById("minutes").value;
 
 
     if (document.getElementById("inputArea").style.display == "none") {        
        alert("Pause...");
        return;
      }
    

    // check if not a number
    if (isNaN(minutes)) {
        alert("Entrez une valeur numŽrique svp!");
        return;
    }
    
    // how many seconds?
    secondsRemaining =  minutes * 60;
    // every second, call the "tick" function
    intervalHandle = setInterval(tick, 100);
    // hide the form
    document.getElementById("inputArea").style.display = "none";

}



// as soon as the page is loaded... crŽŽ ˆ la volŽe
window.onload =  function () {  
   // create input text box and give it an id of "minutes"
    var inputMinutes = document.createElement("input");
    
    inputMinutes.setAttribute("id", "minutes");
    inputMinutes.setAttribute("type", "text");
   
 
    // add to the DOM, to the div called "inputArea"
    document.getElementById("inputArea").appendChild(inputMinutes);
    inputMinutes.setAttribute("size", 20);
     
    inputMinutes.value = "2";
    
};