const fractions = document.querySelectorAll(".fraction");

let hasBeenSelected = false;
let pieSelect, wordSelect;

function highlight(){
  this.classList.add('highlightBorder');

  if(!hasBeenSelected){
    //selectpie
    hasBeenSelected = true;
    pieSelect = this;
  }
  else{
    //select word representation
    hasBeenSelected = false;
    wordSelect = this;

    //check pies Match
    if(pieSelect.dataset.framework === wordSelect.dataset.framework){
      //they Match
      pieSelect.removeEventListener('click', highlight);
      wordSelect.removeEventListener('click', highlight);
    }
    else {
      //not a Match
      setTimeout(() => {
        pieSelect.classList.remove('highlightBorder');
        wordSelect.classList.remove('highlightBorder');
      }, 1500);
    }
  }
}
fraction.forEach(fractions => fractions.addEventListener('click', highlight))
