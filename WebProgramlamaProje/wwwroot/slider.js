

window.onload = function () {
    let counter = 0;
    const prev = document.querySelector('.prev');
    const next = document.querySelector('.next');
    const slider = document.querySelector('.slider');
    const sliderContainer = document.querySelector('.slider-container');
    const max = document.querySelectorAll('.slide').length - 1;

    function sliderFunc() {

        if (counter < max) {
            counter++;
            slider.style.left = '-' + 1000 * counter + 'px';
        }
        else {
            counter = 0;
            slider.style.left = '-' + 1000 * counter + 'px';
        }

    }


    let timer = setInterval(sliderFunc, 3000);

    sliderContainer.addEventListener('mouseover', () => {
        clearInterval(timer);
    });
    sliderContainer.addEventListener('mouseout', () => {
        timer = setInterval(sliderFunc, 3000);
    });

    next.addEventListener('click', sliderFunc);

    

    prev.addEventListener('click', () => {

        if (counter > 0) {
            counter--;
            slider.style.left = '-' + 1000 * counter + 'px';
        }
        else {
            counter = max;
            slider.style.left = '-' + 1000 * counter + 'px';
        }

    });
}