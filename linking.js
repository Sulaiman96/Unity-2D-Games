const fractions = document.querySelectorAll(".fraction");
console.log("reached");
let hasBeenSelected = false;
let pieSelect, wordSelect;

function highlight(){
  this.classList.add('highlightBorder');

  if(!hasBeenSelected){
    //selectpie
    hasBeenSelected = true;
    pieSelect = this;
    console.log("works");
  }
  else{
    //select word representation
    hasBeenSelected = false;
    wordSelect = this;
    console.log("works2");

    //check pies Match
    if(pieSelect.dataset.framework === wordSelect.dataset.framework){
      //they Match
      pieSelect.removeEventListener('click', highlight);
      wordSelect.removeEventListener('click', highlight);
      console.log("works3");

    }
    else {
      //not a Match
      setTimeout(() => {
        pieSelect.classList.remove('highlightBorder');
        wordSelect.classList.remove('highlightBorder');
      }, 1500);
      console.log("works4");

    }
  }
}
fractions.forEach(fraction => fraction.addEventListener('click', highlight))
console.log("reached2");
