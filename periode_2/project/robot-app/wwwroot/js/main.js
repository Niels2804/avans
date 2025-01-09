window.onload = () => {
    // Laat de loader zien bij het starten van de pagina
    window.addEventListener('load', () => {
        document.getElementById('loader-overlay').style.visibility = 'hidden';
    });

    // Zorg ervoor dat de loader zichtbaar is bij het starten van de pagina
    window.addEventListener('beforeunload', () => {
        document.getElementById('loader-overlay').style.visibility = 'visible';
    });

    // Maak de observer aan
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            // Wanneer de sectie zichtbaar is (drempel van 50%)
            if (entry.isIntersecting) {
                const sectionId = entry.target.id;  // Haalt het id van het element op (bijv. 'dashboard', 'reminders', etc.)
                console.log(`Visible section: ${sectionId}`);
                
                // Update de URL zonder de pagina opnieuw te laden
                history.pushState(null, null, `#${sectionId}`);
                
                // Verwijder de 'active' klasse van alle nav-items
                document.querySelectorAll('.nav-item').forEach(el => el.classList.remove('active'));

                // Voeg de 'active' klasse toe aan het juiste nav-item
                document.querySelectorAll(`.nav-item[data-item="${sectionId}"]`).forEach(el => el.classList.add('active'));
            }
        });
    }, {
        threshold: 0.5 // Zorg ervoor dat 50% van de sectie zichtbaar is om deze te detecteren
    });

    // Selecteer de elementen waarop je de observer wilt toepassen
    document.querySelectorAll('.pages .page').forEach(element => {
        observer.observe(element); // Begin met het observeren van elk element
    });

    document.querySelectorAll('.nav-item').forEach(link => {
        link.addEventListener('click', () => {
            const item = link.getAttribute('data-item');
            document.querySelectorAll('.nav-item').forEach(el => el.classList.remove('active'));
            document.querySelectorAll(`.nav-item[data-item="${item}"]`).forEach(el => el.classList.add('active'));
        });
    });
    
    // 404 Animatie 
    lottie.loadAnimation({
        container: document.querySelector('.lottie-animation'),
        renderer: 'svg',
        loop: true,
        autoplay: true,
        path: 'https://lottie.host/d987597c-7676-4424-8817-7fca6dc1a33e/BVrFXsaeui.json'
    });
};

