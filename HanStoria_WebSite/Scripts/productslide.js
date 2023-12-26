let slideIndex = 0;
const cardsToShow = 3; // Değiştirmek istediğiniz kart sayısı

function showSlides() {
    const cards = document.querySelectorAll('.cardItem');
    for (let i = 0; i < cards.length; i++) {
        cards[i].style.display = 'none';
    }
    for (let i = slideIndex; i < slideIndex + cardsToShow; i++) {
        if (cards[i]) {
            cards[i].style.display = 'block';
        }
    }
}

function nextSlide() {
    const cards = document.querySelectorAll('.cardItem');
    if (slideIndex < cards.length - cardsToShow) {
        slideIndex++;
        showSlides();
    }
}

function prevSlide() {
    if (slideIndex > 0) {
        slideIndex--;
        showSlides();
    }
}

document.querySelector('.next').addEventListener('click', nextSlide);
document.querySelector('.prev').addEventListener('click', prevSlide);

// İlk yükleme için slider'ı göster
showSlides();
