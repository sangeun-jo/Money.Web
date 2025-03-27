

// 스크롤 위치 저장
window.saveScrollPosition = (id) => {
    localStorage.setItem('scrollPosition', window.pageYOffset);
}

// 스크롤 위치 복원
window.restoreScrollPosition = function () {
    var position = localStorage.getItem('scrollPosition');
    if (!position) return;

    var checkLoaded = setInterval(() => {
        if (document.readyState === 'complete') {
            window.scrollTo(0, parseInt(position));
            localStorage.removeItem('scrollPosition');
            clearInterval(checkLoaded);
        }
    }, 100);

    // 10초 후 타임아웃
    setTimeout(() => clearInterval(checkLoaded), 10000);
}


window.historyBack = () => {
    window.history.back();
}

